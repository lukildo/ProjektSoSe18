Public Class Main
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Exporter.Show()
        Me.Hide()
    End Sub

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        Nesting.Show()
        Me.Hide()
    End Sub
End Class