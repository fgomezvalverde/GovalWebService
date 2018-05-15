Public Class Receptor


    Private _identificacionExtranjero As String
    Public Property IdentificacionExtranjero() As String
        Get
            Return _identificacionExtranjero
        End Get
        Set(ByVal value As String)
            _identificacionExtranjero = value
        End Set

    End Property

    Private _identificacion As String
    Public Property Identificacion() As String
        Get
            Return _identificacion
        End Get
        Set(ByVal value As String)
            _identificacion = value
        End Set

    End Property

    Private _identificacionTipo As String
    Property IdentificacionTipo() As String
        Get
            Return _identificacionTipo
        End Get

        Set(ByVal Value As String)
            _identificacionTipo = Value
        End Set

    End Property

    Private _nombre As String
    Property Nombre() As String
        Get
            Return _nombre
        End Get

        Set(ByVal Value As String)
            _nombre = Value
        End Set

    End Property

    Private _nombreComercial As String
    Property NombreComercial() As String
        Get
            Return _nombreComercial
        End Get

        Set(ByVal Value As String)
            _nombreComercial = Value
        End Set

    End Property

    Private _telefono As String
    Property Telefono() As String
        Get
            Return _telefono
        End Get

        Set(ByVal Value As String)
            _telefono = Value
        End Set

    End Property

    Private _fax As String
    Property Fax() As String
        Get
            Return _fax
        End Get

        Set(ByVal Value As String)
            _fax = Value
        End Set

    End Property

    Private _codigoPais As String
    Public Property CodigoPais() As String
        Get
            Return _codigoPais
        End Get
        Set(ByVal value As String)
            _codigoPais = value
        End Set

    End Property

    Private _provincia As String
    Property Provincia() As String
        Get
            Return _provincia
        End Get

        Set(ByVal Value As String)
            _provincia = Value
        End Set

    End Property

    Private _canton As String
    Property Canton() As String
        Get
            Return _canton
        End Get

        Set(ByVal Value As String)
            _canton = Value
        End Set

    End Property

    Private _distrito As String
    Property Distrito() As String
        Get
            Return _distrito
        End Get

        Set(ByVal Value As String)
            _distrito = Value
        End Set

    End Property

    Private _barrio As String
    Property Barrio() As String
        Get
            Return _barrio
        End Get

        Set(ByVal Value As String)
            _barrio = Value
        End Set

    End Property

    Private _direccion As String
    Property Direccion() As String
        Get
            Return _direccion
        End Get

        Set(ByVal Value As String)
            _direccion = Value
        End Set

    End Property

    Private _email As String
    Property Email() As String
        Get
            Return _email
        End Get

        Set(ByVal Value As String)
            _email = Value
        End Set

    End Property

End Class
