Public Class Nesting
    Private Sub Nesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGrid.Rows.Add("Grundplatte", "200x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Gelenk1", "200x22 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Gelenk2", "340x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Blech", "20x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Aufbau", "200x40 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Blech1", "20x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        dataGrid.Rows.Add("Aufbau", "200x40 mm", "1", "Geladen", "Einfügen", "Löschen")

        comboMaterial.SelectedIndex = 0
        comboSize.SelectedIndex = 0
    End Sub

    Private Sub Nesting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        System.Windows.Forms.Application.Exit()
    End Sub
End Class