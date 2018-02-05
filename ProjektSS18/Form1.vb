Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CATIA As INFITF.Application



        'Catia Verbindung aufbauen
        Try
            CATIA = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        System.Console.WriteLine("Catia Verbindung steht")

    End Sub
End Class
