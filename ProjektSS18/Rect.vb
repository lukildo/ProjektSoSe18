'Rechteck-Klasse enthält die 2D-Größe und den 2D-Ursprungspunkt
Public Class Rect

    'Member Variablen
    Private m_sizeX As Double
    Private m_sizeY As Double
    Private m_originX As Double
    Private m_originY As Double

    'Konstruktor mit Größe
    Public Sub New(ByVal sizeX As Double, ByVal sizeY As Double)
        m_sizeX = sizeX
        m_sizeY = sizeY
    End Sub

    'Konstruktor mit Größe und Ursprung
    Public Sub New(ByVal sizeX As Double, ByVal sizeY As Double, ByVal originX As Double, ByVal originY As Double)
        m_sizeX = sizeX
        m_sizeY = sizeY
        m_originX = originX
        m_originY = originY
    End Sub

    'Kopier Konstruktor
    Public Sub New(ByVal copyRect As Rect)
        m_sizeX = copyRect.sizeX
        m_sizeY = copyRect.sizeY
        m_originX = copyRect.originX
        m_originY = copyRect.originY
    End Sub

    'Eigenschaften
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

    'Prüfen, ob das übergebene Rechteck in dieses Rechteck passt
    Public Function fits(rectInsert As Rect) As Boolean
        Return m_sizeX >= rectInsert.sizeX And m_sizeY >= rectInsert.sizeY
    End Function

    'Prüfen, ob das übergebene Rechteck innerhalb dieses Rechtecks liegt
    Public Function contains(rectInsert As Rect) As Boolean
        Return rectInsert.originX >= m_originX And rectInsert.originY >= m_originY _
            And rectInsert.originX + rectInsert.sizeX <= m_originX + m_sizeX _
            And rectInsert.originY + rectInsert.sizeY <= m_originY + m_sizeY
    End Function

    'Prüfen, ob die beiden Rechtecke schneiden
    Public Function intersects(rectIntersect As Rect) As Boolean
        If rectIntersect.originX >= m_originX + m_sizeX Or rectIntersect.originX + rectIntersect.sizeX <= m_originX Or
        rectIntersect.originY >= m_originY + m_sizeY Or rectIntersect.originY + rectIntersect.sizeY <= m_originY Then
            Return False
        End If
        Return True
    End Function

    'Werte tauschen für Drehung um 90°
    Public Function rotated() As Rect
        Return New Rect(m_sizeY, m_sizeX, m_originX, m_originY)
    End Function
End Class
