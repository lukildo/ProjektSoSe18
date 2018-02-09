Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Interaction
Imports System.Threading
Imports System.IO


Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim myDoc As Document
        Dim sel As Selection

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

        myDoc = CATIA.ActiveDocument

        'Dateiauswahl auf Outputpath setzen
        myDoc.SaveAs(myDoc.FullName)

        partNamePath = myDoc.FullName.Replace("CATPart", "")
        'Datei löschen, falls schon vorhanden
        fileDxf = myDoc.FullName.Replace("CATPart", "dxf")
        If File.Exists(fileDxf) Then File.Delete(fileDxf)

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
            If timeElapsed > 6 Then
                MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End While

        'Exportierte Datei öffnen
        CATIA.Documents.Open(fileDxf)
        Thread.Sleep(2000)

        'alles selektieren und Linienart und Linienbreite anpassen
        sel = CATIA.ActiveDocument.Selection
        sel.Search("Type=*,all")
        CATIA.ActiveDocument.Selection.VisProperties.SetRealLineType(1, 0)
        CATIA.ActiveDocument.Selection.VisProperties.SetRealWidth(1, 0)

        Dim i As Integer
        Dim j As Integer
        Dim sheets As DrawingSheets

        sheets = CATIA.ActiveDocument.Sheets


        sheets.ActiveSheet.Views.Item(3).x = 100
        sheets.ActiveSheet.Views.Item(3).y = 100
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

        'Außenkontur Farbe anpassen
        sel.Search("Name='Linie.1',all")
        CATIA.StartCommand("Automatische Suche")
        CATIA.ActiveDocument.Selection.VisProperties.SetRealColor(0, 0, 255, 0)
        sel.Clear()

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
    End Sub

    'Textbox mit den Radiobuttons aktivieren
    Private Sub diffPath_CheckedChanged(sender As Object, e As EventArgs) Handles diffPath.CheckedChanged
        If diffPath.Checked Then
            outputPath.Enabled = True
        Else
            outputPath.Enabled = False
        End If
    End Sub
End Class
