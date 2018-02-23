
Public Class Main
    'Navigation zu Zeichnungserstellung
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Exporter.Show()
        Me.Hide()
    End Sub
    'Navigation zum Anordnen
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        Nesting.Show()
        Me.Hide()
    End Sub
    'Anleitung öffnen
    Private Sub btnInstructions_Click(sender As Object, e As EventArgs) Handles btnInstructions.Click
        Dim myTempFile As String = IO.Path.Combine(IO.Path.GetTempPath, "Anleitung.pdf")
        My.Computer.FileSystem.WriteAllBytes(myTempFile, My.Resources.Anleitung, False)
        Process.Start(myTempFile)
    End Sub
End Class