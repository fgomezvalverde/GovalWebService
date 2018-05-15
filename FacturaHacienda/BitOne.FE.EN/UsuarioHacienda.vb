Public Class UsuarioHacienda

    Private _username As String

    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property


    Private _password As String

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property


    Private _cert As Byte()

    Public Property Certificado() As Byte()
        Get
            Return _cert
        End Get
        Set(ByVal value As Byte())
            _cert = value
        End Set
    End Property

    Private _pin As String

    Public Property Pin() As String
        Get
            Return _pin
        End Get
        Set(ByVal value As String)
            _pin = value
        End Set
    End Property


    Private _modalidadProduccion As Boolean

    Public Property modalidadProduccion() As Boolean
        Get
            Return _modalidadProduccion
        End Get
        Set(ByVal value As Boolean)
            _modalidadProduccion = value
        End Set
    End Property

    Private _urlhaciendaAuthApiProduccion As String

    Public Property urlhaciendaAuthApiProduccion() As String
        Get
            Return _urlhaciendaAuthApiProduccion
        End Get
        Set(ByVal value As String)
            _urlhaciendaAuthApiProduccion = value
        End Set
    End Property

    Private _urlhaciendaAuthApiDesarrollo As String

    Public Property urlhaciendaAuthApiDesarrollo() As String
        Get
            Return _urlhaciendaAuthApiDesarrollo
        End Get
        Set(ByVal value As String)
            _urlhaciendaAuthApiDesarrollo = value
        End Set
    End Property

    Private _urlhaciendaApiProduccion As String

    Public Property urlhaciendaApiProduccion() As String
        Get
            Return _urlhaciendaApiProduccion
        End Get
        Set(ByVal value As String)
            _urlhaciendaApiProduccion = value
        End Set
    End Property

    Private _urlhaciendaApiDesarrollo As String

    Public Property urlhaciendaApiDesarrollo() As String
        Get
            Return _urlhaciendaApiDesarrollo
        End Get
        Set(ByVal value As String)
            _urlhaciendaApiDesarrollo = value
        End Set
    End Property


End Class
