Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Interaction
Imports System.Threading
Imports System.IO


Public Class Exporter

    Public progMax As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim sel As Selection

        Dim outputPath As String
        Dim partName As String
        Dim partNamePath As String
        Dim fileDxf As String
        Dim timeElapsed As Integer

        'UI blockieren
        btnBack1.Enabled = False
        Button1.Enabled = False
        progBar.Value = 0

        'Catia Verbindung aufbauen
        Try
            CATIA = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If Not CATIA.GetWorkbenchId.Equals("SmdNewDesignWorkbench") And Not CATIA.GetWorkbenchId.Equals("SheWorkshop") Then
            'Fehlermeldung wenn es kein Sheetmetal Part ist
            MessageBox.Show("Kein Sheetmetal Part geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'UI aktivieren
            btnBack1.Enabled = True
            Button1.Enabled = True
            Exit Sub
        End If

        progMax = 4
        partName = CATIA.ActiveDocument.Name.Replace(".CATPart", "")
        partNamePath = CATIA.ActiveDocument.FullName.Replace(".CATPart", "")

        'Output festlegen
        If diffPath.Checked Then
            outputPath = outputPathBox.Text + "\" + partName + ".CATDrawing"
        Else
            outputPath = partNamePath + ".CATDrawing"
        End If

        'Datei löschen, falls schon vorhanden
        fileDxf = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & partName & ".dxf"
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
        'Verzeichnis auf Desktop wechseln und vorher Verzeichnis ändern
        SendKeys.Send("{%}appdata{%}{ENTER}shell:Desktop{ENTER}{ENTER}")

        timeElapsed = 0
        While Not File.Exists(fileDxf)
            Thread.Sleep(500)
            timeElapsed = timeElapsed + 1
            'Fehlermeldung, falls nach der Wartezeit noch keine Datei vorhanden ist
            If timeElapsed > 6 Then
                MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'UI aktivieren
                btnBack1.Enabled = True
                Button1.Enabled = True
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
        sel.Clear()

        'erstes Objekt nach dem Achsensystem ist Start der Außenkontur
        sel.Add(CATIA.ActiveDocument.Sheets.ActiveSheet.Views.ActiveView.GeometricElements.Item(2))
        CATIA.StartCommand("Automatische Suche")
        'Außenkontur Farbe anpassen
        CATIA.ActiveDocument.Selection.VisProperties.SetRealColor(0, 0, 255, 0)
        sel.Clear()

        'Datei überschreiben und speichern
        If File.Exists(outputPath) Then File.Delete(outputPath)
            CATIA.ActiveDocument.SaveAs(outputPath)
            CATIA.ActiveDocument.Close()

            '##ProgressUpdate
            progUpdate(partName + ".CATDrawing fertig")
        'UI aktivieren
        btnBack1.Enabled = True
        Button1.Enabled = True
    End Sub

    'Output mit Dialog festlegen
    Private Sub outputPathBox_Click(sender As Object, e As EventArgs) Handles outputPathBox.Click

        Dim dialog As New FolderBrowserDialog()

        If dialog.ShowDialog = DialogResult.OK Then
            outputPathBox.Text = dialog.SelectedPath
        End If

    End Sub

    'Standard Output als Desktop festlegen
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        outputPathBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        progressLbl.Text = ""
    End Sub

    'Textbox mit den Radiobuttons aktivieren
    Private Sub diffPath_CheckedChanged(sender As Object, e As EventArgs) Handles diffPath.CheckedChanged
        If diffPath.Checked Then
            outputPathBox.Enabled = True
        Else
            outputPathBox.Enabled = False
        End If
    End Sub
    'Progressbar aktualisieren
    Private Sub progUpdate(ByVal msg As String, Optional ByVal times As Integer = 1)
        Dim progValue As Integer

        progressLbl.Text = msg
        progValue = progBar.Value + times * 100 / progMax

        If progValue > 100 Then progValue = 100
        progBar.Value = progValue
    End Sub
    'Zwischen den Forms wechseln
    Private Sub btnBack1_Click(sender As Object, e As EventArgs) Handles btnBack1.Click
        Main.Show()
        Me.Close()
    End Sub
    'Programm schließen, wenn auf das x gedrückt wird
    Private Sub Exporter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Main.Visible Then System.Windows.Forms.Application.Exit()
    End Sub
End Class
