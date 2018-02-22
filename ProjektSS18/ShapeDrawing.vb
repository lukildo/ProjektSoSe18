Public Class ShapeDrawing

    'Member Variablen
    Private m_name As String
    Private m_sizeX As Double
    Private m_sizeY As Double
    Private m_originX As Double
    Private m_originY As Double
    Private m_status As String
    Private m_sheetNumber As Integer

    'Konstruktor
    Public Sub New()

    End Sub

    'Getter-Setter
    Public Property Name() As String
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

    Public Property sheetNumber As Integer
        Get
            Return m_sheetNumber
        End Get
        Set(value As Integer)
            m_sheetNumber = value
        End Set
    End Property
End Class
