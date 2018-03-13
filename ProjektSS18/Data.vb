Imports System.Runtime.InteropServices

Module Data
    'Alle geladenen Daten in einer globalen Variable speichern
    Public shapeDrawings As New List(Of ShapeDrawing)
    'Listen für die automatische Positionierung
    Private usedRects As New List(Of Rect)
    Private freeRects As New List(Of Rect)

    'Automatische Positionierung als Funktion ausgelagert
    Public Sub autoPosition(ByVal newSheets As Boolean)
        Dim Catia As INFITF.Application

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

        'Auf das erste Blatt wechseln
        sheets.Item(1).Activate()

        'Variablen zurücksetzen
        resetPlaced()
        usedRects.Clear()
        freeRects.Clear()
        'Gesamtes Blatt ist die erste freie Möglichkeit
        freeRects.Add(New Rect(sheets.ActiveSheet.GetPaperWidth, sheets.ActiveSheet.GetPaperHeight, 0, 0))

        'Gesamte geladene Daten durchgehen
        For Each shapeDrawing1 In shapeDrawings
            'Wurde bereits platziert
            If shapeDrawing1.placed = shapeDrawing1.count Then Continue For
            Dim shapeRect As New Rect(shapeDrawing1.sizeX, shapeDrawing1.sizeY)

            Dim placeX As Double = Double.MaxValue
            Dim placeY As Double = Double.MaxValue

            'Gesamte Anzahl durchgehen
            Do
                Dim usedRect As Rect
                'Alle Platzierungsmöglichkeiten durchgehen
                For Each rect1 In freeRects
                    'Prüfen, ob die drwView in das Feld passt
                    If rect1.fits(shapeRect) Then
                        'Bestes Feld auswählen, minimales Y und minimales X
                        If rect1.originY < placeY Or (rect1.originY = placeY And rect1.originX < placeX) Then
                            placeX = rect1.originX
                            placeY = rect1.originY
                            usedRect = rect1
                        End If
                    End If
                Next rect1

                If placeX < Double.MaxValue And placeY < Double.MaxValue Then
                    System.Console.WriteLine("Position konnte gefunden werden")

                    shapeDrawing1.placed = shapeDrawing1.placed + 1
                    placeShape(shapeDrawing1, placeX, placeY)
                    updateFreeRects(usedRect, shapeDrawing1)
                Else
                    Exit Do
                End If
            Loop Until shapeDrawing1.placed = shapeDrawing1.count

        Next shapeDrawing1
    End Sub

    'Shape an gewünschte Position setzen
    Public Sub placeShape(ByVal shapeDrawing1 As ShapeDrawing, ByVal x As Double, ByVal y As Double)
        Dim Catia As INFITF.Application
        Dim sel As Selection

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
        If shapeDrawing1.placed = 0 Then
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

        'An die gewünschte Stelle platzieren
        drwView.x = shapeDrawing1.originX + x
        drwView.y = shapeDrawing1.originY + y

    End Sub

    Public Sub resetPlaced()
        For Each shapeDrawing1 In shapeDrawings
            shapeDrawing1.placed = 0
        Next
    End Sub

    Public Sub updateFreeRects(ByVal usedRect As Rect, shapeDrawing1 As ShapeDrawing)


        'Sonderfälle zuerst betrachten
        If usedRect.sizeX = shapeDrawing1.sizeX And usedRect.sizeY = shapeDrawing1.sizeY Then
            freeRects.Remove(usedRect)
        ElseIf usedRect.sizeY = shapeDrawing1.sizeY Then
            freeRects.Remove(usedRect)
            Dim newRect As New Rect(usedRect.sizeX - shapeDrawing1.sizeX, usedRect.sizeY, usedRect.originX + shapeDrawing1.sizeX, usedRect.originY)
            freeRects.Add(newRect)
        ElseIf usedRect.sizeY = shapeDrawing1.sizeY Then
            freeRects.Remove(usedRect)
            Dim newRect As New Rect(usedRect.sizeX, usedRect.sizeY - shapeDrawing1.sizeY, usedRect.originX, usedRect.originY + shapeDrawing1.sizeY)
            freeRects.Add(newRect)
        End If


    End Sub

End Module
