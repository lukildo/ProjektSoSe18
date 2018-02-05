Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Interaction
Imports System.Threading
Imports System.IO


Public Class Form1
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
     ByVal lpClassName As String,
     ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim CATIA As INFITF.Application
        Dim myDoc As Document

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

        System.Console.WriteLine("hat alles geklappt")

    End Sub
End Class
