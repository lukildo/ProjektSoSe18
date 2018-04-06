Public Class Main

    'Navigation zu Zeichnungserstellung
    Private Sub btnCreate_Click() Handles btnCreate.Click
        Exporter.Show()
        Me.Hide()
    End Sub

    'Navigation zum Anordnen
    Private Sub btnSort_Click() Handles btnSort.Click
        Nesting.Show()
        Me.Hide()
    End Sub

    'Anleitung öffnen
    Private Sub btnInstructions_Click() Handles btnInstructions.Click
        Dim myTempFile As String = IO.Path.Combine(IO.Path.GetTempPath, "Anleitung.pdf")
        'Resource als Datei im Temp-Ordner speichern
        My.Computer.FileSystem.WriteAllBytes(myTempFile, My.Resources.Anleitung, False)
        Process.Start(myTempFile)
    End Sub
End Class