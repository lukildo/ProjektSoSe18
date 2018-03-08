Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Interaction
Imports System.Threading
Imports System.IO


Public Class Exporter

    Public progMax As Integer
    Public Property M_Doc_Structure As Object

    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim sel As Selection
        Dim selDraw As Selection
        Dim outputPath As String
        Dim outputPathNew As String
        Dim partName As String
        Dim partNamePath As String
        Dim fileDxf As String
        Dim timeElapsed As Integer
        Dim i As Integer    'Zählvariable for-next-schleife Parttyp Abfrage
        Dim k As Integer    'Zählvariable for-next-schleife namensvergebung
        Dim myPart As Part
        Dim Dok As Object
        Dim name As String
        Dim exist As Integer    'variable um zu prüfen ob CATDrawing-Datei bereits existiert
        Dim sheetmetalpart As Integer   'variable um zu prüfen ob's ein sheetmetalpart ist oder nicht
        Dim count As Integer        'Zählt die gespeicherten CATDrawing Dateien

        count = 0

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


        'Nacheinander alle Parts abfragen:
        sel = CATIA.ActiveDocument.Selection
        sel.Clear()
        sel.Search("(CATPrtSearch.PartFeature),all")

        For i = 1 To sel.Count
            myPart = sel.Item2(i).Value

            'prüfen, ob Part eine Sheetmetal Datei ist:
            Try
                Dim str As String = myPart.SheetMetalParameters.Name
                System.Console.WriteLine(myPart.Parent.FullName & ": " & "Ein Sheetmetalpart")
                sheetmetalpart = True
            Catch ex As Exception
                System.Console.WriteLine(myPart.Name & ": " & "Kein Sheetmetalpart")
                sheetmetalpart = False
            End Try


            'wenn Sheetmetal-Datei, dann ... in neuem Fenster öffnen und exportieren
            If sheetmetalpart = True Then

                name = myPart.Parent.FullName
                Dok = CATIA.Documents.Open(name)

                progMax = 4
                partName = CATIA.ActiveDocument.Name.Replace(".CATPart", "")
                partNamePath = CATIA.ActiveDocument.FullName.Replace(".CATPart", "")

                'Output festlegen
                If diffPath.Checked Then
                    outputPath = outputPathBox.Text + "\" + partName + ".CATDrawing"
                Else
                    outputPath = partNamePath + ".CATDrawing"
                End If





                'dxf nur exportieren wenn   ".../###.CATDrawing"   des Teils noch nicht vorhanden

                'ist der Dateiname in dem Ordner bereits vergeben so wird die bereitsbestehende Datei KOPIERT und um eine fortlaufende 
                'Zahl erweitert (z.B. Part1.CATDrawing -> Part1_2.CATDrawing)
                'So muss man später beim Anordnen der Zeichnungen auf einem Blatt nicht überlegen, Wieviel Stück von welchem Teil 
                'Verbaut sind


                'Wenn Datei existiert : ...
                If File.Exists(outputPath) Then


                    outputPathNew = outputPath
                    exist = True
                    k = 2
                    Do                                      '...Namen um fortlaufende Nummer ergenzen...
                        If diffPath.Checked Then
                            outputPathNew = outputPathBox.Text & "\" & partName & "_" & k & ".CATDrawing"
                        Else
                            outputPathNew = partNamePath & "_" & k & ".CATDrawing"
                        End If
                        If Not File.Exists(outputPathNew) Then exist = False
                        k = k + 1
                    Loop Until exist = False

                    CATIA.FileSystem.CopyFile(outputPath, outputPathNew, False)   '... und Kopie mit geändertem Namen speichern,
                    CATIA.ActiveDocument.Close()                                  'dann Fenster mit Part wieder schließen.




                    'Wenn Datei NICHT existiert : Dxf exportieren und CATDrawing Datei speichern
                Else

                    'Dxf-Datei löschen, falls schon vorhanden
                    fileDxf = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & partName & ".dxf"
                    If File.Exists(fileDxf) Then File.Delete(fileDxf)

                    '##ProgressUpdate
                    progUpdate(partName + ".dxf exportieren")

                    'Catia in den Vordergrund
                    AppActivate("CATIA")
                    'Command ausführen, noch unschön
                    CATIA.StartCommand("Als DXF sichern")
                    'jeweils auf das öffnen der Fenster warten
                    Thread.Sleep(2000)
                    SendKeys.Send("{ENTER}")
                    Thread.Sleep(2000)
                    'Verzeichnis auf Desktop wechseln und vorher Verzeichnis ändern
                    SendKeys.Send("{%}appdata{%}{ENTER}shell:Desktop{ENTER}{ENTER}")

                    timeElapsed = 0
                    While Not File.Exists(fileDxf)
                        Thread.Sleep(500)
                        timeElapsed = timeElapsed + 1
                        'Fehlermeldung, falls nach der Wartezeit noch keine Datei vorhanden ist
                        If timeElapsed > 60 Then
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
                    selDraw = CATIA.ActiveDocument.Selection
                    selDraw.Search("Type=*,all")
                    CATIA.ActiveDocument.Selection.VisProperties.SetRealLineType(1, 0)
                    CATIA.ActiveDocument.Selection.VisProperties.SetRealWidth(1, 0)
                    selDraw.Clear()

                    'erstes Objekt nach dem Achsensystem ist Start der Außenkontur
                    selDraw.Add(CATIA.ActiveDocument.Sheets.ActiveSheet.Views.ActiveView.GeometricElements.Item(2))
                    CATIA.StartCommand("Automatische Suche")
                    'Außenkontur Farbe anpassen
                    CATIA.ActiveDocument.Selection.VisProperties.SetRealColor(0, 0, 255, 0)
                    selDraw.Clear()

                    'Datei überschreiben und speichern
                    CATIA.ActiveDocument.SaveAs(outputPath)
                    'Drawing-Fenster schließen
                    CATIA.ActiveDocument.Close()

                    '##ProgressUpdate
                    progUpdate(partName + ".CATDrawing fertig")
                    'UI aktivieren
                    btnBack1.Enabled = True
                    Button1.Enabled = True
                    'Part-Fenster wieder schließen            Problem: Wenn nur ein PART und kein Product exportiert wird auch das Fenster davon geschlossen (unschön) !!
                    CATIA.ActiveDocument.Close()

                End If

                count = count + 1   'zählen der gespeicherten Dateien

            End If

        Next i  'Nächstes Bauteil im Strukturbaum prüfen

        MsgBox("Es wurden " & count & " Zeichnungs-Dateien gespeichert!")
    End Sub







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
