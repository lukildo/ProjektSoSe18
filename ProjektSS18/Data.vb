Imports System.Runtime.InteropServices

Module Data
    'Alle geladenen Daten in einer globalen Variable speichern
    Public shapeDrawings As New List(Of ShapeDrawing)
    'Globaler Zugriff auf das DataGrid
    Public dataGrid As DataGridView
    'Listen für die automatische Positionierung
    Private freeRects As New List(Of Rect)

    'Automatische Positionierung als Funktion ausgelagert
    Public Sub autoPosition(ByVal newSheets As Boolean, ByVal distanceInside As Integer, ByVal distanceOutSide As Integer)
        Dim Catia As INFITF.Application
        Dim alreadyPlaced As Integer
        Dim failedPlacements As Integer
        Dim currentSheet As Integer

        'Catia Verbindung aufbauen
        Try
            Catia = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Prüfen auf Zeichnung
        Dim sheets As DrawingSheets
        Try
            sheets = Catia.ActiveDocument.Sheets
        Catch ex As Exception
            'Fehlermeldung
            MessageBox.Show("Keine Zeichnung geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Variablen zurücksetzen
        resetPlaced()
        freeRects.Clear()
        alreadyPlaced = 0
        failedPlacements = 0
        currentSheet = 1

        'Auf das erste Blatt wechseln
        sheets.Item(currentSheet).Activate()

        'Gesamtes Blatt ist die erste freie Möglichkeit
        freeRects.Add(New Rect(sheets.ActiveSheet.GetPaperWidth - 2 * distanceOutSide, sheets.ActiveSheet.GetPaperHeight - 2 * distanceOutSide, distanceOutSide, distanceOutSide))
        'Gesamte geladene Daten durchgehen
        Do
            For Each shapeDrawing1 In shapeDrawings
                'Wurde bereits platziert
                If shapeDrawing1.placed = shapeDrawing1.count Then Continue For

                'Komplette Liste passt nicht
                If failedPlacements = shapeDrawings.Count Then
                    If sheets.Count > currentSheet Then
                        currentSheet = currentSheet + 1
                        sheets.Item(currentSheet).Activate()
                        freeRects.Clear()
                        freeRects.Add(New Rect(sheets.ActiveSheet.GetPaperWidth - 2 * distanceOutSide, sheets.ActiveSheet.GetPaperHeight - 2 * distanceOutSide, distanceOutSide, distanceOutSide))
                        failedPlacements = 0
                    ElseIf newSheets Then
                        Call Nesting.btnNewSheet_Click(Nothing, Nothing)
                        currentSheet = currentSheet + 1
                        sheets.Item(currentSheet).Activate()
                        freeRects.Clear()
                        freeRects.Add(New Rect(sheets.ActiveSheet.GetPaperWidth - 2 * distanceOutSide, sheets.ActiveSheet.GetPaperHeight - 2 * distanceOutSide, distanceOutSide, distanceOutSide))
                        failedPlacements = 0
                    Else
                        MessageBox.Show("Es konnten nicht alle Zeichnungen auf den vorhandenen Blättern platziert werden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                Dim shapeRect As New Rect(shapeDrawing1.sizeX + distanceInside, shapeDrawing1.sizeY + distanceInside)
                'Gesamte Anzahl durchgehen
                Do
                    Dim bestY As Double = Double.MaxValue
                    Dim topY As Double
                    Dim rotate As Boolean
                    'Alle Platzierungsmöglichkeiten durchgehen
                    For Each rect1 In freeRects
                        'Prüfen, ob die drwView in das Feld passt
                        If rect1.fits(shapeRect) Then
                            'Bestes Feld auswählen, minimales Y und minimales X
                            topY = rect1.originY + shapeDrawing1.sizeY
                            If topY < bestY Or (topY.Equals(bestY) And rect1.originX < shapeRect.originX) Then
                                bestY = topY
                                shapeRect.originX = rect1.originX
                                shapeRect.originY = rect1.originY
                                rotate = False
                            End If
                        End If
                        'Mit Drehung probieren
                        If rect1.fits(shapeRect.rotated()) Then
                            topY = rect1.originY + shapeDrawing1.sizeX
                            'Bestes Feld auswählen, minimales Y und minimales X
                            If topY < bestY Or (topY.Equals(bestY) And rect1.originX < shapeRect.originX) Then
                                bestY = topY
                                shapeRect.originX = rect1.originX
                                shapeRect.originY = rect1.originY
                                rotate = True
                            End If
                        End If
                    Next rect1

                    'Wenn etwas gefunden wurde, dann an die Koordinaten platzieren
                    If bestY < Double.MaxValue Then
                        shapeDrawing1.placed = shapeDrawing1.placed + 1
                        If shapeDrawing1.placed = shapeDrawing1.count Then alreadyPlaced = alreadyPlaced + 1

                        placeShape(shapeDrawing1, shapeRect.originX, shapeRect.originY, currentSheet, rotate)
                        'Statusupdate
                        shapeDrawing1.status = shapeDrawing1.placed & "/" & shapeDrawing1.count & " platziert"
                        shapeDrawing1.updateGrid(dataGrid)
                        If rotate Then
                            updateFreeRects(shapeRect.rotated())
                        Else
                            updateFreeRects(shapeRect)
                        End If
                        failedPlacements = 0
                    Else
                        failedPlacements = failedPlacements + 1
                        System.Console.WriteLine(shapeDrawing1.name & " konnte nicht platziert werden")
                        Exit Do
                    End If
                Loop Until shapeDrawing1.placed = shapeDrawing1.count
            Next shapeDrawing1
        Loop Until shapeDrawings.Count <= alreadyPlaced
    End Sub

    'Shape an gewünschte Position setzen
    Public Sub placeShape(ByVal shapeDrawing1 As ShapeDrawing, ByVal x As Double, ByVal y As Double, ByVal sheetNumber As Integer, ByVal rotate As Boolean)
        Dim Catia As INFITF.Application
        Dim sel As Selection
        Dim i As Integer

        'Catia Verbindung aufbauen
        Try
            Catia = Marshal.GetActiveObject("CATIA.Application")
        Catch ex As COMException
            'Fehlermeldung bei Verbindungsproblem und Programmende
            MessageBox.Show("Catia nicht gefunden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'Prüfen auf Zeichnung
        Dim sheets As DrawingSheets
        Try
            sheets = Catia.ActiveDocument.Sheets
        Catch ex As Exception
            'Fehlermeldung
            MessageBox.Show("Keine Zeichnung geöffnet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        sel = Catia.ActiveDocument.Selection
        sel.Clear()
        'Richtige DrawingView finden
        If shapeDrawing1.placed = 1 Then
            sel.Search("Name=" & shapeDrawing1.name & ",all")
        Else
            sel.Search("Name=" & shapeDrawing1.name & "[" & shapeDrawing1.placed & "],all")
        End If

        Dim drwView As DrawingView
        Try
            drwView = sel.Item2(1).Value
        Catch ex As Exception
            System.Console.WriteLine(shapeDrawing1.name & "(" & shapeDrawing1.placed & ") nicht gefunden")
            Exit Sub
        End Try

        Dim parentSheet As DrawingSheet = drwView.Parent
        'Blattnummer herausfinden
        For i = 1 To sheets.Count
            If sheets.Item(i).Name.Equals(parentSheet.Name) Then Exit For
        Next i

        'Drehung ausführen
        If rotate Then
            drwView.Angle = -1.5708
            If sheetNumber.Equals(i) Then
                'An die gewünschte Stelle platzieren
                drwView.x = shapeDrawing1.originY + x
                drwView.y = shapeDrawing1.sizeX - shapeDrawing1.originX + y
            Else
                'View auf ein anderes Blatt verschieben
                sel.Clear()
                sel.Add(drwView)
                sel.Cut()
                sel.Add(sheets.Item(sheetNumber))
                sel.Paste()

                drwView = sel.Item2(1).Value
                drwView.x = shapeDrawing1.originY + x
                drwView.y = shapeDrawing1.sizeX - shapeDrawing1.originX + y
            End If
        Else
            drwView.Angle = 0
            If sheetNumber.Equals(i) Then
                'An die gewünschte Stelle platzieren
                drwView.x = shapeDrawing1.originX + x
                drwView.y = shapeDrawing1.originY + y
            Else
                'View auf ein anderes Blatt verschieben
                sel.Clear()
                sel.Add(drwView)
                sel.Cut()
                sel.Add(sheets.Item(sheetNumber))
                sel.Paste()

                drwView = sel.Item2(1).Value
                drwView.x = shapeDrawing1.originX + x
                drwView.y = shapeDrawing1.originY + y
            End If
        End If

        sel.Clear()

    End Sub

    Public Sub resetPlaced()
        For Each shapeDrawing1 In shapeDrawings
            shapeDrawing1.placed = 0
        Next
    End Sub

    Public Sub updateFreeRects(ByVal usedRect As Rect)

        Dim i As Integer
        Dim freeRectCount As Integer = freeRects.Count
        System.Console.WriteLine(freeRectCount)

        For i = 0 To freeRectCount - 1
            If freeRects.Item(i).intersects(usedRect) Then
                Dim freeRect As Rect = freeRects.Item(i)
                Dim newFreeRect As Rect
                'Neues unten anfügen
                If usedRect.originY > freeRect.originY Then
                    System.Console.WriteLine("Unten anfügen")
                    newFreeRect = New Rect(freeRect)
                    newFreeRect.sizeY = usedRect.originY - freeRect.originY
                    freeRects.Add(newFreeRect)
                End If
                'Neues oben anfügen
                If usedRect.originY + usedRect.sizeY < freeRect.originY + freeRect.sizeY Then
                    System.Console.WriteLine("Oben anfügen")
                    newFreeRect = New Rect(freeRect)
                    newFreeRect.originY = usedRect.originY + usedRect.sizeY
                    newFreeRect.sizeY = freeRect.originY + freeRect.sizeY - usedRect.originY - usedRect.sizeY
                    freeRects.Add(newFreeRect)
                End If

                'Neues links anfügen
                If usedRect.originX > freeRect.originX Then
                    System.Console.WriteLine("Links anfügen")
                    newFreeRect = New Rect(freeRect)
                    newFreeRect.sizeX = usedRect.originX - freeRect.originX
                    freeRects.Add(newFreeRect)
                End If

                'Neues rechts anfügen
                If usedRect.originX + usedRect.sizeX < freeRect.originX + freeRect.sizeX Then
                    System.Console.WriteLine("Rechts anfügen")
                    newFreeRect = New Rect(freeRect)
                    newFreeRect.originX = usedRect.originX + usedRect.sizeX
                    newFreeRect.sizeX = freeRect.originX + freeRect.sizeX - usedRect.originX - usedRect.sizeX
                    freeRects.Add(newFreeRect)
                End If

                If newFreeRect IsNot Nothing Then
                    freeRects.RemoveAt(i)
                    i = i - 1
                    freeRectCount = freeRectCount - 1
                End If
            End If
        Next i

        'Doppelte Freiflächen entfernen
        Dim j As Integer
        For i = 0 To freeRects.Count - 1
            For j = i + 1 To freeRects.Count - 1
                If j = freeRects.Count Then Exit For
                System.Console.WriteLine(i & " und " & j)
                If freeRects.Item(j).contains(freeRects.Item(i)) Then
                    freeRects.RemoveAt(i)
                    System.Console.WriteLine("Entferne i")
                    i = i - 1
                    Exit For
                End If

                If freeRects.Item(i).contains(freeRects.Item(j)) Then
                    freeRects.RemoveAt(j)
                    System.Console.WriteLine("Entferne j")
                    j = j - 1
                End If
            Next j
        Next i


    End Sub

End Module
