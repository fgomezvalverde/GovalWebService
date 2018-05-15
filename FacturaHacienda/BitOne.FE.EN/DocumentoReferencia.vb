Public Class DocumentoReferencia


    Private _tipoDoc As String

    Property TipoDoc() As String
        Get
            Return _tipoDoc
        End Get

        Set(ByVal Value As String)
            _tipoDoc = Value
        End Set

    End Property

    Private _numero As String

    Property Numero() As String
        Get
            Return _numero
        End Get

        Set(ByVal Value As String)
            _numero = Value
        End Set

    End Property

    Private _fechaEmision As Date

    Property FechaEmision() As Date
        Get
            Return _fechaEmision
        End Get

        Set(ByVal Value As Date)
            _fechaEmision = Value
        End Set

    End Property

    Private _codigo As String

    Property Codigo() As String
        Get
            Return _codigo
        End Get

        Set(ByVal Value As String)
            _codigo = Value
        End Set

    End Property

    Private _razon As String

    Property Razon() As String
        Get
            Return _razon
        End Get

        Set(ByVal Value As String)
            _razon = Value
        End Set

    End Property


End Class
