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
        sel.Clear()

        'Außenkontur Farbe anpassen
        sel.Search("Name='Linie.1',all")
        CATIA.StartCommand("Automatische Suche")
        CATIA.ActiveDocument.Selection.VisProperties.SetRealColor(0, 0, 255, 0)
        sel.Clear()

        CATIA.ActiveDocument.SaveAs(partNamePath.)


    End Sub
End Class
