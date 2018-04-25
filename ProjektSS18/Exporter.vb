Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO

Public Class Exporter

    Public progMax As Integer

    Private Sub Button1_Click() Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim sel As Selection
        Dim window As IntPtr
        Dim okButton As IntPtr

        Dim outputPath As String
        Dim partName As String
        Dim partNamePath As String
        Dim fileDxf As String
        Dim timeElapsed As Integer

        Dim myPart As Part
        Dim savedParts As New Dictionary(Of Part, Integer)
        Dim isPart As Boolean

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
            Me.Activate()
            Exit Sub
        End Try

        'Part oder Produkt geöffnet
        isPart = Not CATIA.ActiveDocument.Name.Contains(".CATProduct")

        'Alle Parts auswählen
        sel = CATIA.ActiveDocument.Selection
        sel.Clear()
        sel.Search("(CATPrtSearch.PartFeature),all")

        For i = 1 To sel.Count
            myPart = sel.Item2(i).Value

            'Part auf Sheetmetal prüfen
            Try
                Dim str As String = myPart.SheetMetalParameters.Name
            Catch ex As Exception
                Continue For
            End Try

            'Doppelte Parts mit Anzahl speichern
            If checkBoxSave.Checked And savedParts.ContainsKey(myPart) Then
                savedParts(myPart) += 1
            ElseIf Not savedParts.ContainsKey(myPart) Then
                savedParts.Add(myPart, 1)
            End If
        Next i

        sel.Clear()

        If savedParts.Count = 0 Then
            'Fehlermeldung, wenn das Produkt keine Sheetmetal Parts enthält
            MessageBox.Show("Das Produkt enthält keine Sheetmetal Parts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'UI aktivieren
            btnBack1.Enabled = True
            Button1.Enabled = True
            Exit Sub
        End If

        'Abschnitte der ProgressBar berechnen
        progMax = 4 * savedParts.Count

        'Sheetmetal Workbench aktivieren
        If Not isPart Then
            CATIA.Documents.Add("Part")
            CATIA.StartWorkbench("SmdNewDesignWorkbench")
            CATIA.ActiveDocument.Close()
        End If

        'Liste durchgehen und exportieren
        For Each kvp As KeyValuePair(Of Part, Integer) In savedParts
            If Not isPart Then
                Try
                    CATIA.Documents.Open(kvp.Key.Parent.FullName)
                Catch ex As Exception
                    btnBack1.Enabled = True
                    Button1.Enabled = True
                    MessageBox.Show("Fehler beim Öffnen der Datei", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Activate()
                    'UI aktivieren
                    Exit Sub
                End Try
            End If

            partName = CATIA.ActiveDocument.Name.Replace(".CATPart", "")
            partNamePath = CATIA.ActiveDocument.FullName.Replace(".CATPart", "")

            'Ausgabepfad festlegen
            If diffPath.Checked Then
                outputPath = outputPathBox.Text + "\" + partName + "_Laser.CATDrawing"
            Else
                outputPath = partNamePath + "_Laser.CATDrawing"
            End If

            'Datei löschen, falls schon vorhanden
            fileDxf = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & partName & ".dxf"
            If File.Exists(fileDxf) Then File.Delete(fileDxf)

            '##ProgressUpdate
            progUpdate(partName + ".dxf exportieren")

            'Exportieren über StartCommand
            CATIA.StartCommand("SmDxf")

            'Warten bis das erste Fenster geöffnet ist; mit Timeout
            timeElapsed = 0
            While FindWindow(Nothing, "DXF-Datei auswählen").Equals(IntPtr.Zero)
                Thread.Sleep(30)
                timeElapsed += 1

                If timeElapsed > 70 Then
                    'UI aktivieren
                    btnBack1.Enabled = True
                    Button1.Enabled = True

                    MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Activate()
                    Exit Sub
                End If
            End While
            window = FindWindow(Nothing, "DXF-Datei auswählen")

            'Save As Button erkennen; mit Timeout
            timeElapsed = 0
            While GetDlgItem(window, 0) = 0
                Thread.Sleep(10)
                timeElapsed += 1
                If timeElapsed > 100 Then Exit While
            End While
            okButton = GetDlgItem(window, 0)
            'Button drücken
            SendMessage(okButton, BM_CLICK, IntPtr.Zero, IntPtr.Zero)
            CATIA.Interactive = False
            'Warten bis das zweite Fenster geöffnet ist; mit Timeout
            timeElapsed = 0
            While FindWindow(Nothing, "Sichern unter").Equals(IntPtr.Zero)
                Thread.Sleep(30)
                timeElapsed += 1
                If timeElapsed > 70 Then
                    'UI aktivieren
                    btnBack1.Enabled = True
                    Button1.Enabled = True

                    MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Activate()
                    Exit Sub
                End If
            End While

            'Pfad in der Zwischenablage speichern
            Clipboard.Clear()
            Clipboard.SetText(fileDxf)

            'Pfad solange eingeben, bis sich das Fenster geschlossen hat
            timeElapsed = 0
            While Not FindWindow(Nothing, "Sichern unter") = 0
                timeElapsed += 1
                SetForegroundWindow(FindWindow(Nothing, "Sichern unter"))
                SendKeys.SendWait("^v{Enter}")
                Thread.Sleep(30)

                If timeElapsed > 100 Then
                    'UI aktivieren
                    btnBack1.Enabled = True
                    Button1.Enabled = True
                    CATIA.Interactive = True

                    MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Activate()
                    Exit Sub
                End If
            End While
            Clipboard.Clear()

            'Überprüfen, ob die DXF richtig gespeichert wurde
            timeElapsed = 0
            While Not File.Exists(fileDxf)
                Thread.Sleep(30)
                timeElapsed += 1
                'Fehlermeldung, falls nach der Wartezeit noch keine Datei vorhanden ist
                If timeElapsed > 100 Then
                    'UI aktivieren
                    btnBack1.Enabled = True
                    Button1.Enabled = True
                    CATIA.Interactive = True

                    MessageBox.Show("DXF konnte nicht exportiert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Activate()
                    Exit Sub
                End If
            End While

            '##ProgressUpdate
            progUpdate(partName + ".dxf öffnen")

            SetForegroundWindow(FindWindow(Nothing, "ShapeFormat"))
            'Exportierte Datei öffnen und DXF danach löschen
            CATIA.Interactive = True
            CATIA.Documents.Open(fileDxf)

            File.Delete(fileDxf)

            '##ProgressUpdate
            progUpdate(partName + ".dxf anpassen und speichern")

            'Alles selektieren und Linienart und Linienbreite anpassen
            sel = CATIA.ActiveDocument.Selection
            sel.Clear()
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
            Try
                CATIA.ActiveDocument.SaveAs(outputPath)
            Catch ex As Exception
                'UI aktivieren
                btnBack1.Enabled = True
                Button1.Enabled = True

                'Fehlermeldung innerhalb von Catia
                Exit Sub

            End Try

            'Doppelte Parts einzeln speichern
            If kvp.Value > 1 Then
                Dim outputPathNew As String
                For i = 2 To kvp.Value
                    outputPathNew = outputPath.Replace(".CATDrawing", i & ".CATDrawing")
                    If File.Exists(outputPathNew) Then File.Delete(outputPathNew)
                    File.Copy(outputPath, outputPathNew)
                Next i
            End If

            'Zeichnung und Part schließen
            CATIA.ActiveDocument.Close()
            If Not isPart Then
                CATIA.ActiveDocument.Close()
            End If

            '##ProgressUpdate
            progUpdate(partName + "_Laser.CATDrawing wurde erstellt")
        Next kvp

        'Abschließende Ausgabenachricht und ProgressBar auf 100%
        If savedParts.Count = 1 Then
            progUpdate(partName + "_Laser.CATDrawing wurde erstellt", 100)
        Else
            progUpdate("Alle " & savedParts.Count & " (verschiedenen) Parts wurden exportiert!", 100)
        End If

        'UI aktivieren
        btnBack1.Enabled = True
        Button1.Enabled = True
    End Sub

    'Ausgabepfad mit Dialog festlegen
    Private Sub outputPathBox_Click() Handles outputPathBox.Click
        Dim dialog As New FolderBrowserDialog()

        'Pfadauswahl mit DialogBox
        If dialog.ShowDialog = DialogResult.OK Then
            outputPathBox.Text = dialog.SelectedPath
        End If
    End Sub

    'Standard Ausgabepfad als Desktop festlegen
    Private Sub Form1_Load() Handles MyBase.Load
        outputPathBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        progressLbl.Text = ""
    End Sub

    'Textbox mit den Radiobuttons aktivieren
    Private Sub diffPath_CheckedChanged() Handles diffPath.CheckedChanged
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

    'Zwischen den Fenstern wechseln
    Private Sub btnBack1_Click(sender As Object, e As EventArgs) Handles btnBack1.Click
        Main.Show()
        Me.Close()
    End Sub

    'Programm schließen, wenn auf das x gedrückt wird
    Private Sub Exporter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Main.Visible Then System.Windows.Forms.Application.Exit()
    End Sub
End Class
