Imports System.IO
Imports System.Runtime.InteropServices

Public Class Nesting
    Dim otherTrue As Boolean

    Private Sub Nesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Startwerte setzen
        shapeDrawings.Clear()
        dataGrid = dataGridView
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
        If dataGridView.Rows.Count > 0 Then
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

    Public Sub btnNewSheet_Click(sender As Object, e As EventArgs) Handles btnNewSheet.Click

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
        setSheetSize(sheets.ActiveSheet)
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        'CATDrawings laden und in Array laden
        Dim openDialog As New OpenFileDialog
        Dim fileName As String
        Dim CATIA As INFITF.Application
        Dim i As Integer

        'Catia Verbindung aufbauen
        Try
            CATIA = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        openDialog.Filter = "CATIA Zeichnung|*.CATDrawing"
        openDialog.Multiselect = True

        If openDialog.ShowDialog = DialogResult.OK Then

            Dim mainIndex As Integer = -1
            Dim newIndex As Integer
            Dim sel As Selection
            Dim sheets As DrawingSheets
            Dim alreadyLoaded As Boolean
            Dim loadError As String = ""

            'Zeichnung neu erstellen
            If dataGridView.Rows.Count = 0 Then
                CATIA.Documents.Add("Drawing")
                sheets = CATIA.ActiveDocument.Sheets
                sheets.Add("Blatt 1 - " & comboSize.Text & " - " & comboMaterial.Text)
                sheets.Remove(1)
                setSheetSize(sheets.ActiveSheet)
                CATIA.ActiveWindow.ActiveViewer.Reframe()
                'Index bestimmen für spätere Dokumentenwechsel
                For i = 1 To CATIA.Documents.Count
                    If CATIA.Documents.Item(i).Equals(CATIA.ActiveDocument) Then
                        mainIndex = i
                        Exit For
                    End If
                Next i
            Else
                'Dateien werden zur Zeichnung hinzugefügt
                For i = 1 To CATIA.Documents.Count
                    'Nach einer Zeichnung suchen
                    Try
                        sheets = CATIA.Documents.Item(i).sheets
                    Catch ex As Exception
                        Continue For
                    End Try
                    If sheets.Item(1).Name.Contains("Blatt 1 ") Then
                        mainIndex = i
                        Exit For
                    End If
                Next i
            End If

            If mainIndex = -1 Then
                MessageBox.Show("Hauptzeichnung konnte nicht gefunden werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Alle ausgewählten Dateien durchgehen
            For Each fileName In openDialog.FileNames
                'Neues Objekt erzeugen
                Dim shapeDrawing1 As New ShapeDrawing
                Dim shapeDrawingSaved As ShapeDrawing
                Dim loadPartName As String
                Dim loadName As String
                Dim counter As Integer = 0

                loadPartName = fileName.Substring(fileName.LastIndexOf(Path.DirectorySeparatorChar) + 1)
                If loadPartName.Contains("_Laser") Then
                    loadName = loadPartName.Substring(0, loadPartName.LastIndexOf("_"))
                    For Each fileName2 In openDialog.FileNames
                        If fileName2.Contains(loadName) Then counter += 1
                    Next fileName2
                Else
                    counter = 1
                    loadName = loadPartName.Replace(".CATDrawing", "")
                End If
                alreadyLoaded = False
                'Prüfen, ob die Datei schon geladen wurde
                For Each shapeDrawingSaved In shapeDrawings
                    If loadName = shapeDrawingSaved.name Then
                        alreadyLoaded = True
                        Exit For
                    End If
                Next
                'Mit der nächsten Datei weitermachen, falls die Datei schon geladen wurde
                If alreadyLoaded Then Continue For

                For i = 1 To CATIA.Documents.Count
                    'Momentan geöffnete Zeichnung können nicht geladen werden
                    If CATIA.Documents.Item(i).Name = loadPartName Then
                        If loadError.Length > 0 Then
                            loadError = loadError & ", " & loadName
                        Else
                            loadError = loadName
                        End If
                        Exit For
                    End If
                Next i
                'Mit der nächsten Datei weitermachen
                If loadError.Contains(loadName) Then Continue For

                'Daten übernehmen und anpassen
                CATIA.Documents.Open(fileName)
                shapeDrawing1.name = loadName

                shapeDrawing1.status = "Geladen"
                shapeDrawing1.count = counter
                sheets = CATIA.ActiveDocument.Sheets
                sheets.ActiveSheet.Views.ActiveView.SetViewName("", shapeDrawing1.name, "")
                'Dokumentenindex bestimmen
                For i = 1 To CATIA.Documents.Count
                    If CATIA.Documents.Item(i).Equals(CATIA.ActiveDocument) Then
                        newIndex = i
                        Exit For
                    End If
                Next i
                'Main View aktivieren, um Koordinatenprobleme zu vermeiden
                sheets.ActiveSheet.Views.Item(1).Activate()

                'Variant Array
                Dim arr(4)
                'Größe der BoundingBox
                sheets.ActiveSheet.Views.Item(3).Size(arr)
                'Xmax - Xmin
                shapeDrawing1.sizeX = arr(1) - arr(0)
                'Ymax-Ymin
                shapeDrawing1.sizeY = arr(3) - arr(2)
                'Ursprungspunkte speichern
                shapeDrawing1.originX = sheets.ActiveSheet.Views.Item(3).x - arr(0)
                shapeDrawing1.originY = sheets.ActiveSheet.Views.Item(3).y - arr(2)
                'DrawingView kopieren
                sel = CATIA.ActiveDocument.Selection
                sel.Add(sheets.ActiveSheet.Views.Item(3))
                sel.Copy()
                'Dokument wechseln und einfügen
                CATIA.Documents.Item(mainIndex).Activate()
                sheets = CATIA.ActiveDocument.Sheets
                sel = CATIA.ActiveDocument.Selection
                For i = 1 To counter
                    sel.Add(sheets.Item(sheets.Count))
                    sel.Paste()
                    sel.Clear()
                Next i

                CATIA.Documents.Item(newIndex).Close()
                'Daten in das globale Array übernehmen
                shapeDrawings.Add(shapeDrawing1)
                'Daten darstellen
                shapeDrawing1.updateGrid(dataGridView)
            Next fileName

            If loadError.Length > 0 Then

                MessageBox.Show(loadError & " konnte nicht geladen werden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Else
            'Abbrechen
            Exit Sub
        End If
    End Sub

    Private Sub dataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellContentClick
        'Einfügen
        If e.ColumnIndex = 4 Then
            Dim shapeDrawing1 As ShapeDrawing
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

            'Objekt aus der Liste finden
            shapeDrawing1 = shapeDrawings.Find(Function(x) x.name = dataGridView.Rows(e.RowIndex).Cells(0).Value)
            If shapeDrawing1 IsNot Nothing Then
                Dim sel As Selection

                sel = CATIA.ActiveDocument.Selection
                sel.Clear()
                sel.Search("Name=" & shapeDrawing1.name & "*,all")
                'Prüfen, ob gespeicherte Daten mit Daten in Catia übereinstimmen
                If Not sel.Count2 = shapeDrawing1.count Then
                    MessageBox.Show("Liste vorher aktualisieren!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sel.Clear()
                    Exit Sub
                End If
                'Nur ein DrawingView selektieren
                While sel.Count2 > 1
                    sel.Remove(1)
                End While

                sel.Copy()
                sel.Remove(1)
                sel.Add(CATIA.ActiveDocument.Sheets.ActiveSheet)
                sel.Paste()
                sel.Clear()

                'Eingefügte DrawingView verschieben
                sheets = CATIA.ActiveDocument.Sheets
                Dim drwView As DrawingView = sheets.ActiveSheet.Views.Item(sheets.ActiveSheet.Views.Count)
                drwView.Angle = 0
                drwView.x = shapeDrawing1.originX
                drwView.y = shapeDrawing1.originY

                shapeDrawing1.count = shapeDrawing1.count + 1
                shapeDrawing1.updateGrid(dataGridView)
            End If
            'Löschen
        ElseIf e.ColumnIndex = 5 Then
            Dim shapeDrawing1 As ShapeDrawing
            Dim CATIA As INFITF.Application

            'Catia Verbindung aufbauen
            Try
                CATIA = Marshal.GetActiveObject("CATIA.Application")
            Catch ex As COMException
                'Fehlermeldung bei Verbindungsproblem und Programmende
                MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Objekt aus der Liste finden
            shapeDrawing1 = shapeDrawings.Find(Function(x) x.name = dataGridView.Rows(e.RowIndex).Cells(0).Value)
            If shapeDrawing1 IsNot Nothing Then
                Dim sel As Selection

                sel = CATIA.ActiveDocument.Selection
                sel.Clear()
                sel.Search("Name=" & shapeDrawing1.name & "+Name=" & shapeDrawing1.name & "[*" & ",all")
                'Prüfen, ob gespeicherte Daten mit Daten in Catia übereinstimmen
                If Not sel.Count2 = shapeDrawing1.count Then
                    MessageBox.Show("Liste vorher aktualisieren!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    sel.Clear()
                    Exit Sub
                End If
                'Nur ein DrawingView löschen
                While sel.Count2 > 1
                    sel.Remove(1)
                End While
                sel.Delete()
                sel.Clear()

                shapeDrawing1.count = shapeDrawing1.count - 1
                'Löschen, wenn alle Views gelöscht wurden
                If shapeDrawing1.count = 0 Then
                    shapeDrawings.Remove(shapeDrawing1)
                    dataGridView.Rows.Remove(dataGridView.Rows(e.RowIndex))
                Else
                    shapeDrawing1.updateGrid(dataGridView)
                End If
            End If
        End If
    End Sub

    Public Sub setSheetSize(ByVal sheet As DrawingSheet)
        If comboSize.SelectedItem = "DIN A0" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA0
        ElseIf comboSize.SelectedItem = "DIN A1" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA1
        ElseIf comboSize.SelectedItem = "DIN A2" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA2
        ElseIf comboSize.SelectedItem = "DIN A3" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA3
        ElseIf comboSize.SelectedItem = "DIN A4" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperA4
        ElseIf comboSize.SelectedItem = "Benutzerdefiniert" Then
            sheet.PaperSize = DRAFTINGITF.CatPaperSize.catPaperUser
            sheet.SetPaperHeight(txtBoxHeight.Text)
            sheet.SetPaperWidth(txtBoxWidth.Text)
        End If
    End Sub
    'Benutzereingaben prüfen
    Private Sub txtBoxDistanceOutside_Leave(sender As Object, e As EventArgs) Handles txtBoxDistanceOutside.Leave
        Dim value As Integer

        'Auf den Standardwert zurücksetzen, wenn die Eingabe nicht passt
        If Int32.TryParse(txtBoxDistanceOutside.Text, value) Then
            If value > 99 And value < 0 Then txtBoxDistanceOutside.Text = 5
        Else
            txtBoxDistanceOutside.Text = 5
        End If
    End Sub
    'Benutzereingaben prüfen
    Private Sub txtBoxDistanceInside_TextChanged(sender As Object, e As EventArgs) Handles txtBoxDistanceInside.TextChanged
        Dim value As Integer

        'Auf den Standardwert zurücksetzen, wenn die Eingabe nicht passt
        If Int32.TryParse(txtBoxDistanceInside.Text, value) Then
            If value > 99 And value < 0 Then txtBoxDistanceInside.Text = 5
        Else
            txtBoxDistanceInside.Text = 5
        End If
    End Sub

    Private Sub btnNesting_Click(sender As Object, e As EventArgs) Handles btnNesting.Click
        'Liste erst aktualisieren
        Call btnRefresh_Click(Nothing, Nothing)
        'UI Werte weitergeben
        autoPosition(chkBoxAuto.Checked, txtBoxDistanceInside.Text, txtBoxDistanceOutside.Text)
    End Sub
    'Aktualisieren
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim Catia As INFITF.Application
        Dim sel As Selection
        Dim i As Integer
        Dim removeList As New List(Of ShapeDrawing)

        'Catia Verbindung aufbauen
        Try
            Catia = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim sheets As DrawingSheets
        Try
            sheets = Catia.ActiveDocument.Sheets
        Catch ex As Exception
            'Fehlermeldung
            MessageBox.Show("Keine Zeichnung geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        sel = Catia.ActiveDocument.Selection

        For Each shapeDrawing1 In shapeDrawings
            sel.Clear()
            sel.Search("Name=" & shapeDrawing1.name & "+Name=" & shapeDrawing1.name & "[*,all")
            'Gespeicherte Anzahl stimmt mit der aktuellen Anzahl überein
            If shapeDrawing1.count = sel.Count2 Then Continue For

            'Falls gelöscht auch Daten löschen
            If sel.Count2 = 0 Then
                removeList.Add(shapeDrawing1)
                For i = 1 To dataGridView.Rows.Count
                    If dataGridView.Rows(i - 1).Cells(0).Value = shapeDrawing1.name Then
                        dataGridView.Rows.Remove(dataGridView.Rows(i - 1))
                        Exit For
                    End If
                Next i
            Else
                'Daten in der Liste aktualisieren
                shapeDrawing1.count = sel.Count2
                shapeDrawing1.updateGrid(dataGridView)
            End If
        Next shapeDrawing1
        sel.Clear()

        'Alle gelöschten Daten aus der Liste entfernen
        For Each shapeDrawing1 In removeList
            shapeDrawings.Remove(shapeDrawing1)
        Next shapeDrawing1
    End Sub
End Class