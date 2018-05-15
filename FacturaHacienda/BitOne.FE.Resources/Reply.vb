Imports System.Xml
Imports BitOne.FE.EN

Public Class Reply

    Public Sub Reply()
        Me.token = Nothing
        Me.reasonPhraseGETHacienda = String.Empty
        Me.reasonPhrasePOSTHacienda = String.Empty
        Me.statusCodeGETHacienda = String.Empty
        Me.statusCodePOSTHacienda = String.Empty
        Me.contingencia = False
        Me.ok = True
        Me.msg = String.Empty
        Me.estado = String.Empty
        Me.xmlDocumento = Nothing
        Me.xmlRespuesta = Nothing
        Me.claveXMLRespuesta = String.Empty
    End Sub

    'Public Sub toError(msg As String, objObjeto As T)
    '    Me.obj = obj
    '    Me.ok = False
    '    Me.msg = msg
    '    Me.contingencia = False
    'End Sub

    'Private _obj As T
    Private _ReasonPhrasePOSTHacienda As String
    Private _ReasonPhraseGETHacienda As String
    Private _StatusCodePOSTHacienda As String
    Private _StatusCodeGETHacienda As String
    Private _ok As Boolean
    Private _token As Token
    Private _contingencia As Boolean
    Private _msg As String
    Private _estado As String
    Private _xmlDocumento As String
    Private _xmlRespuesta As String
    Private _claveXMLRespuesta As String

    'Public Property obj() As T
    '    Get
    '        Return _obj
    '    End Get
    '    Set(value As T)
    '        _obj = value
    '    End Set
    'End Property

    Public Property token() As Token
        Get
            Return _token
        End Get
        Set(value As Token)
            _token = value
        End Set
    End Property

    Public Property reasonPhrasePOSTHacienda() As String
        Get
            Return _ReasonPhrasePOSTHacienda
        End Get
        Set(value As String)
            _ReasonPhrasePOSTHacienda = value
        End Set
    End Property

    Public Property reasonPhraseGETHacienda() As String
        Get
            Return _ReasonPhraseGETHacienda
        End Get
        Set(value As String)
            _ReasonPhraseGETHacienda = value
        End Set
    End Property

    Public Property statusCodePOSTHacienda() As String
        Get
            Return _StatusCodePOSTHacienda
        End Get
        Set(value As String)
            _StatusCodePOSTHacienda = value
        End Set
    End Property

    Public Property statusCodeGETHacienda() As String
        Get
            Return _StatusCodeGETHacienda
        End Get
        Set(value As String)
            _StatusCodeGETHacienda = value
        End Set
    End Property

    Public Property contingencia() As Boolean
        Get
            Return _contingencia
        End Get
        Set(value As Boolean)
            _contingencia = value
        End Set
    End Property

    Public Property ok() As Boolean
        Get
            Return _ok
        End Get
        Set(value As Boolean)
            _ok = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property msg() As String
        Get
            Return _msg
        End Get
        Set(value As String)
            _msg = value
        End Set
    End Property

    Public Property xmlDocumento() As String
        Get
            Return _xmlDocumento
        End Get
        Set(value As String)
            _xmlDocumento = value
        End Set
    End Property

    Public Property xmlRespuesta() As String
        Get
            Return _xmlRespuesta
        End Get
        Set(value As String)
            _xmlRespuesta = value
        End Set
    End Property

    Public Property claveXMLRespuesta() As String
        Get
            Return _claveXMLRespuesta
        End Get
        Set(value As String)
            _claveXMLRespuesta = value
        End Set
    End Property

End Class

