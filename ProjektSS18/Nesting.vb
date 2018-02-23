Imports System.Runtime.InteropServices

Public Class Nesting
    Dim otherTrue As Boolean

    Private Sub Nesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dataGrid.Rows.Add("Grundplatte", "200x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Gelenk1", "200x22 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Gelenk2", "340x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Blech", "20x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Aufbau", "200x40 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Blech1", "20x200 mm", "1", "Geladen", "Einfügen", "Löschen")
        'dataGrid.Rows.Add("Aufbau", "200x40 mm", "1", "Geladen", "Einfügen", "Löschen")

        'Startwerte setzen
        lblError.Visible = False
        comboMaterial.SelectedIndex = 0
        comboSize.SelectedIndex = 0
        otherTrue = True
    End Sub

    Private Sub Nesting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Nur das Programm beenden, wenn auf das x gedrückt wird
        If Not Main.Visible Then System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Abfrage, wenn schon Daten geladen worden sind
        If dataGrid.Rows.Count > 0 Then
            Dim result As DialogResult
            result = MessageBox.Show("Sind Sie sicher? Alle geladenen Daten werden gelöscht.", "Sicher?", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Main.Show()
                Me.Close()
            End If
        Else
            Main.Show()
            Me.Close()
        End If


    End Sub

    Private Sub comboMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboMaterial.SelectedIndexChanged
        'Auswahl dem Material anpassen
        comboSize.Enabled = True
        txtBoxHeight.Enabled = False
        txtBoxWidth.Enabled = False

        If comboMaterial.SelectedItem = "Fotokarton" Then
            comboSize.Items.Clear()
            comboSize.Items.AddRange({"DIN A1", "DIN A3"})
        ElseIf comboMaterial.SelectedItem = "Holz" Then
            comboSize.Items.Clear()
            comboSize.Items.AddRange({"DIN A0", "DIN A1"})
        ElseIf comboMaterial.SelectedItem = "Plexiglas" Then
            comboSize.Items.Clear()
            comboSize.Items.AddRange({"DIN A1"})
        ElseIf comboMaterial.SelectedItem = "Benutzerdefiniert" Then
            comboSize.Enabled = False
            comboSize.Items.Clear()
            comboSize.Items.AddRange({"Benutzerdefiniert"})
            txtBoxHeight.Enabled = True
            txtBoxWidth.Enabled = True
        End If

        comboSize.SelectedIndex = 0
    End Sub

    Private Sub comboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSize.SelectedIndexChanged
        If comboSize.SelectedItem = "DIN A0" Then
            txtBoxHeight.Text = 841
            txtBoxWidth.Text = 1189
        ElseIf comboSize.SelectedItem = "DIN A1" Then
            txtBoxHeight.Text = 594
            txtBoxWidth.Text = 841
        ElseIf comboSize.SelectedItem = "DIN A2" Then
            txtBoxHeight.Text = 420
            txtBoxWidth.Text = 594
        ElseIf comboSize.SelectedItem = "DIN A3" Then
            txtBoxHeight.Text = 297
            txtBoxWidth.Text = 420
        ElseIf comboSize.SelectedItem = "DIN A4" Then
            txtBoxHeight.Text = 210
            txtBoxWidth.Text = 297
        End If
    End Sub

    'Benutzereingaben prüfen
    Private Sub txtBoxHeight_TextChanged(sender As Object, e As EventArgs) Handles txtBoxHeight.TextChanged
        Dim value As Integer

        If Int32.TryParse(txtBoxHeight.Text, value) Then
            If value >= 10 And value <= 1500 Then
                If otherTrue Then
                    btnNewSheet.Enabled = True
                    lblError.Visible = False
                Else
                    otherTrue = True
                    Call txtBoxWidth_TextChanged(Nothing, Nothing)
                End If
            Else
                otherTrue = False
                btnNewSheet.Enabled = False
                lblError.Visible = True
            End If
        End If
    End Sub
    'Benutzereingaben überprüfen
    Private Sub txtBoxWidth_TextChanged(sender As Object, e As EventArgs) Handles txtBoxWidth.TextChanged
        Dim value As Integer

        If Int32.TryParse(txtBoxWidth.Text, value) Then
            If value >= 10 And value <= 1500 Then
                If otherTrue Then
                    btnNewSheet.Enabled = True
                    lblError.Visible = False
                Else
                    otherTrue = True
                    Call txtBoxHeight_TextChanged(Nothing, Nothing)
                End If
            Else
                otherTrue = False
                btnNewSheet.Enabled = False
                lblError.Visible = True
            End If
        End If
    End Sub

    Private Sub btnNewSheet_Click(sender As Object, e As EventArgs) Handles btnNewSheet.Click

        Dim CATIA As INFITF.Application

        'Catia Verbindung aufbauen
        Try
            CATIA = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim sheets As DrawingSheets
        Try
            sheets = CATIA.ActiveDocument.Sheets
        Catch ex As Exception
            'Fehlermeldung
            MessageBox.Show("Keine Zeichnung geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        sheets.Add("Blatt " & sheets.Count + 1 & " - " & comboSize.Text & " - " & comboMaterial.Text)

        If comboSize.SelectedItem = "DIN A0" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA0
        ElseIf comboSize.SelectedItem = "DIN A1" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA1
        ElseIf comboSize.SelectedItem = "DIN A2" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA2
        ElseIf comboSize.SelectedItem = "DIN A3" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA3
        ElseIf comboSize.SelectedItem = "DIN A4" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA4
        ElseIf comboSize.SelectedItem = "Benutzerdefiniert" Then
            sheets.ActiveSheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperUser
            sheets.ActiveSheet.SetPaperHeight(txtBoxHeight.Text)
            sheets.ActiveSheet.SetPaperWidth(txtBoxWidth.Text)
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        'CATDrawings laden und in Array laden
        Dim openDialog As New OpenFileDialog
        Dim fileName As String
        Dim CATIA As INFITF.Application
        Dim i As Integer = 0

        openDialog.Filter = "CATIA Zeichnung|*.CATDrawing"
        openDialog.Multiselect = True

        If openDialog.ShowDialog = DialogResult.OK Then

            'Catia Verbindung aufbauen
            Try
                CATIA = Marshal.GetActiveObject("CATIA.Application")
            Catch ex As COMException
                'Fehlermeldung bei Verbindungsproblem und Programmende
                MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Alle ausgewählten Dateien durchgehen
            For Each fileName In openDialog.FileNames
                Dim shapeDrawing1 As New ShapeDrawing
                Dim drwTest As DrawingView

                CATIA.Documents.Open(fileName)
                shapeDrawing1.Name = CATIA.ActiveDocument.Name.Replace(".CATDrawing", "")
                shapeDrawing1.status = "Geladen"
                shapeDrawing1.sheetNumber = "/"
                CATIA.ActiveDocument.Sheets.ActiveSheet.Views.ActiveView.setViewName("", shapeDrawing1.Name, "")
                drwTest = CATIA.ActiveDocument.Sheets.ActiveSheet.Views.ActiveView
                shapeDrawing1.drwView = drwTest
                System.Console.WriteLine(drwTest.GeometricElements.Count)
                'Variant Array
                Dim arr(4)
                'Größe der BoundingBox
                CATIA.ActiveDocument.Sheets.ActiveSheet.Views.ActiveView.size(arr)
                'Xmax - Xmin
                shapeDrawing1.sizeX = arr(1) - arr(0)
                'Ymax-Ymin
                shapeDrawing1.sizeY = arr(3) - arr(2)
                shapeDrawings(i) = shapeDrawing1
                'CATIA.ActiveDocument.Close()
                'Daten in das globale Array übernehmen

                i = i + 1

                'Daten darstellen
                shapeDrawing1.updateGrid(dataGrid)
            Next fileName
        Else
            'Abbrechen
            Exit Sub
        End If
    End Sub

    Private Sub dataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellContentClick
        If e.ColumnIndex = 4 Then
            Dim i As Integer
            System.Console.WriteLine(shapeDrawings(e.RowIndex).drwView.GeometricElements.Count)
            System.Console.WriteLine(shapeDrawings(e.RowIndex).Name)
            For i = 1 To shapeDrawings(e.RowIndex).drwView.GeometricElements.Count
                System.Console.WriteLine(shapeDrawings(e.RowIndex).drwView.GeometricElements.Item(i).Name)
            Next i
        End If
    End Sub
End Class