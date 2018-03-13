﻿Public Class Rect

    'Member Variablen
    Private m_sizeX As Double
    Private m_sizeY As Double
    Private m_originX As Double
    Private m_originY As Double

    'Konstruktor1
    Public Sub New(ByVal sizeX As Double, ByVal sizeY As Double)
        m_sizeX = sizeX
        m_sizeY = sizeY
    End Sub

    'Konstruktor2
    Public Sub New(ByVal sizeX As Double, ByVal sizeY As Double, ByVal originX As Double, ByVal originY As Double)
        m_sizeX = sizeX
        m_sizeY = sizeY
        m_originX = originX
        m_originY = originY
    End Sub

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

    'Ein Rechteck passt in dieses Rechteck
    Public Function fits(rectInsert As Rect) As Boolean
        If m_sizeX >= rectInsert.sizeX And m_sizeY >= rectInsert.sizeY Then Return True
        Return False
    End Function

End Class
