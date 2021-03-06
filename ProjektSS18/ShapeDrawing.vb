﻿'ShapeDrawing Klasse enthält alle geladenen Daten einer DrawingView
Public Class ShapeDrawing

    'Member Variablen
    Private m_name As String
    Private m_sizeX As Double
    Private m_sizeY As Double
    Private m_originX As Double
    Private m_originY As Double
    Private m_status As String
    Private m_count As Integer
    Private m_placed As Integer

    'Standardkonstruktor
    Public Sub New()
    End Sub

    'Eigenschaften
    Public Property name As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property

    Public Property sizeX As Double
        Get
            Return m_sizeX
        End Get
        Set(value As Double)
            m_sizeX = value
        End Set
    End Property

    Public Property sizeY As Double
        Get
            Return m_sizeY
        End Get
        Set(value As Double)
            m_sizeY = value
        End Set
    End Property

    Public Property originX As Double
        Get
            Return m_originX
        End Get
        Set(value As Double)
            m_originX = value
        End Set
    End Property

    Public Property originY As Double
        Get
            Return m_originY
        End Get
        Set(value As Double)
            m_originY = value
        End Set
    End Property

    Public Property status As String
        Get
            Return m_status
        End Get
        Set(value As String)
            m_status = value
        End Set
    End Property

    Public Property count As Integer
        Get
            Return m_count
        End Get
        Set(value As Integer)
            m_count = value
        End Set
    End Property

    Public Property placed As Integer
        Get
            Return m_placed
        End Get
        Set(value As Integer)
            m_placed = value
        End Set
    End Property

    'Neue Daten in die Tabelle eintragen
    Public Sub updateGrid(ByVal dataGrid As DataGridView)
        Dim i As Integer

        'Reihe ändern, falls der Eintrag schon besteht
        For i = 1 To dataGrid.Rows.Count
            If dataGrid.Rows(i - 1).Cells(0).Value = m_name Then
                dataGrid.Rows(i - 1).Cells(2).Value = m_count
                dataGrid.Rows(i - 1).Cells(3).Value = m_status
                Exit Sub
            End If
        Next i

        'Neue Reihe bei neuem Eintrag erstellen
        Dim size As String
        size = Math.Round(m_sizeX) & " x " & Math.Round(m_sizeY) & " mm"
        dataGrid.Rows.Add(m_name, size, m_count, m_status, "Einfügen", "Löschen")
    End Sub
End Class
