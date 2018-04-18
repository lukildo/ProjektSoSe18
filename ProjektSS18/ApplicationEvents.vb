Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException() Handles Me.UnhandledException
            MessageBox.Show("Ein unbekannter Fehler ist aufgetreten!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
    End Class
End Namespace
