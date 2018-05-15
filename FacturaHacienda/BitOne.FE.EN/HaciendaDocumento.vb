Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace BitOne.FE.EN.Hacienda

    Public Class HaciendaDocumento

        Private _clave As String
        Private _fecha As String
        Private _emisor As emisor
        Private _receptor As receptor
        Private _consecutivoReceptor As String
        Private _comprobanteXml As String

        Public Property clave() As String
            Get
                Return _clave
            End Get
            Set(value As String)
                _clave = value
            End Set
        End Property

        Public Property fecha() As String
            Get
                Return _fecha
            End Get
            Set(value As String)
                _fecha = value
            End Set
        End Property

        Public Property emisor() As emisor
            Get
                Return _emisor
            End Get
            Set(value As emisor)
                _emisor = value
            End Set
        End Property

        Public Property receptor() As receptor
            Get
                Return _receptor
            End Get
            Set(value As receptor)
                _receptor = value
            End Set
        End Property

        Public Property consecutivoReceptor() As String
            Get
                Return _consecutivoReceptor
            End Get
            Set(value As String)
                _consecutivoReceptor = value
            End Set
        End Property

        Public Property comprobanteXml() As String
            Get
                Return _comprobanteXml
            End Get
            Set(value As String)
                _comprobanteXml = value
            End Set
        End Property

    End Class

    Public Class emisor

        Private _tipoIdentificacion As String
        Private _numeroIdentificacion As String

        Public Property tipoIdentificacion() As String
            Get
                Return _tipoIdentificacion
            End Get
            Set(value As String)
                _tipoIdentificacion = value
            End Set
        End Property

        Public Property numeroIdentificacion() As String
            Get
                Return _numeroIdentificacion
            End Get
            Set(value As String)
                _numeroIdentificacion = value
            End Set
        End Property

    End Class

    Public Class receptor

        Private _tipoIdentificacion As String
        Private _numeroIdentificacion As String

        Public Property tipoIdentificacion() As String
            Get
                Return _tipoIdentificacion
            End Get
            Set(value As String)
                _tipoIdentificacion = value
            End Set
        End Property

        Public Property numeroIdentificacion() As String
            Get
                Return _numeroIdentificacion
            End Get
            Set(value As String)
                _numeroIdentificacion = value
            End Set
        End Property

    End Class

    Public Class ResponseMessage

        Private _RMclave As String

        Public Property clave() As String
            Get
                Return _RMclave
            End Get
            Set(value As String)
                _RMclave = value
            End Set
        End Property

        Private _RMfecha As String

        Public Property fecha() As String
            Get
                Return _RMfecha
            End Get
            Set(value As String)
                _RMfecha = value
            End Set
        End Property

        Private _RMindEstado As String

        <JsonProperty("ind-Estado")>
        Public Property indEstado() As String
            Get
                Return _RMindEstado
            End Get
            Set(value As String)
                _RMindEstado = value
            End Set
        End Property

        Private _RMrespuestaXml As String

        <JsonProperty("respuesta-Xml")>
        Public Property respuestaXml() As String
            Get
                Return _RMrespuestaXml
            End Get
            Set(value As String)
                _RMrespuestaXml = value
            End Set
        End Property

    End Class



    Public Class ResponseHeaders

        Private _RMclave As String

        Public Property XErrorCause() As String
            Get
                Return _RMclave
            End Get
            Set(value As String)
                _RMclave = value
            End Set
        End Property

    End Class

End Namespace