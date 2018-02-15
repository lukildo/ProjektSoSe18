Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Interaction
Imports System.Threading
Imports System.IO


Public Class Form1
    'fff
    Public progMax As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim sel As Selection


        Dim outputPath As String
        Dim partName As String
        Dim i As Integer
        Dim partNamePath As String
        Dim fileDxf As String
        Dim timeElapsed As Integer

        'Catia Verbindung aufbauen
        Try
            CATIA = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If Not CATIA.GetWorkbenchId.Equals("SmdNewDesignWorkbench") Then
            'Fehlermeldung wenn es kein Sheetmetal Part ist
            MessageBox.Show("Kein Sheetmetal Part geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        progMax = 4
        partName = CATIA.ActiveDocument.Name
        partNamePath = CATIA.ActiveDocument.FullName.Replace(".CATPart", "")

        'Mit Kopiespeicherung den Pfad zurücksetzen
        Try
            CATIA.ActiveDocument.SaveAs(partNamePath + "CopyS.CATPart")
        Catch
            'Fehlermeldung wird später angezeigt
        End Try

        timeElapsed = 0
        While Not File.Exists(partNamePath + "CopyS.CATPart")
            Thread.Sleep(500)
            timeElapsed = timeElapsed + 1
            'Fehlermeldung, falls es Probleme beim Speichern gab
            If timeElapsed > 6 Then
                MessageBox.Show(partName + " konnte nicht gespeichert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End While
        'Datei direkt wieder löschen
        File.Delete(partNamePath + "CopyS.CATPart")

        'Datei löschen, falls schon vorhanden
        fileDxf = CATIA.ActiveDocument.FullName.Replace("CATPart", "dxf")
        If File.Exists(fileDxf) Then File.Delete(fileDxf)

        '##ProgressUpdate
        progUpdate(partName + ".dxf exportieren")

        'Catia in den Vordergrund
        AppActivate("CATIA")
        'Command ausführen, noch unschön
        CATIA.StartCommand("Als DXF sichern")
        'jeweils auf das öffnen der Fenster warten
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")

        timeElapsed = 0
        While Not File.Exists(fileDxf)
            Thread.Sleep(500)
            timeElapsed = timeElapsed + 1

            'Fehlermeldung, falls nach der Wartezeit noch keine Datei vorhanden ist
            If timeElapsed > 10 Then
                MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End While

        '##ProgressUpdate
        progUpdate(partName + ".dxf öffnen")
        'Exportierte Datei öffnen
        CATIA.Documents.Open(fileDxf)

        'DXF wird nicht mehr gebraucht
        File.Delete(fileDxf)

        '##ProgressUpdate
        progUpdate(partName + ".dxf anpassen und speichern")
        'alles selektieren und Linienart und Linienbreite anpassen
        sel = CATIA.ActiveDocument.Selection
        sel.Search("Type=*,all")
        CATIA.ActiveDocument.Selection.VisProperties.SetRealLineType(1, 0)
        CATIA.ActiveDocument.Selection.VisProperties.SetRealWidth(1, 0)


        Dim j As Integer
        Dim sheets As DrawingSheets

        sheets = CATIA.ActiveDocument.Sheets
        System.Console.WriteLine(sheets.ActiveSheet.Views.Item(3).GeometricElements.Count)

        For i = 1 To sheets.ActiveSheet.Views.Count
            System.Console.WriteLine(sheets.ActiveSheet.Views.Item(i).Name)
            System.Console.WriteLine(sheets.ActiveSheet.Views.Item(i).x)
            System.Console.WriteLine(sheets.ActiveSheet.Views.Item(i).y)
            For j = 1 To sheets.ActiveSheet.Views.Item(i).GeometricElements.Count
                System.Console.WriteLine(sheets.ActiveSheet.Views.Item(i).GeometricElements.Item(j).Name)
                'CATIA.ActiveDocument.Selection.Remove(i)
                'System.Console.WriteLine(i)
            Next j
        Next i

        sel.Clear()

        'erstes Objekt nach dem Achsensystem ist Start der Außenkontur
        sel.Add(sheets.ActiveSheet.Views.Item(3).GeometricElements.Item(2))
        CATIA.StartCommand("Automatische Suche")
        'Außenkontur Farbe anpassen
        CATIA.ActiveDocument.Selection.VisProperties.SetRealColor(0, 0, 255, 0)
        sel.Clear()

        '##ProgressUpdate
        progUpdate(partName + ".CATDrawing fertisch")

        'CATIA.ActiveDocument.SaveAs(partNamePath.)


    End Sub

    'Output mit Dialog festlegen
    Private Sub outputPath_Click(sender As Object, e As EventArgs) Handles outputPath.Click

        Dim dialog As New FolderBrowserDialog()

        If dialog.ShowDialog = DialogResult.OK Then
            outputPath.Text = dialog.SelectedPath
        End If

    End Sub

    'Standard Output als Desktop festlegen
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        outputPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        progressLbl.Text = ""
    End Sub

    'Textbox mit den Radiobuttons aktivieren
    Private Sub diffPath_CheckedChanged(sender As Object, e As EventArgs) Handles diffPath.CheckedChanged
        If diffPath.Checked Then
            outputPath.Enabled = True
        Else
            outputPath.Enabled = False
        End If
    End Sub

    Private Sub progUpdate(ByVal msg As String)
        Dim progValue As Integer

        progressLbl.Text = msg
        progValue = progBar.Value + 100 / progMax

        If progValue > 100 Then progValue = 100
        progBar.Value = progValue
    End Sub
End Class
