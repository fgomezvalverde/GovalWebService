Public Class DocumentoDetalleImpuestoExoneracion

    Private _TipoDocumento As String
    Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get

        Set(ByVal Value As String)
            _TipoDocumento = Value
        End Set

    End Property

    Private _NumeroDocumento As String
    Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get

        Set(ByVal Value As String)
            _NumeroDocumento = Value
        End Set

    End Property

    Private _NombreInstitucion As String
    Property NombreInstitucion() As String
        Get
            Return _NombreInstitucion
        End Get

        Set(ByVal Value As String)
            _NombreInstitucion = Value
        End Set

    End Property

    Private _fechaEmision As System.DateTime
    Property FechaEmision() As System.DateTime
        Get
            Return _fechaEmision
        End Get

        Set(ByVal Value As System.DateTime)
            _fechaEmision = Value
        End Set

    End Property

    Private _MontoImpuesto As Decimal
    Property MontoImpuesto() As Decimal
        Get
            Return _MontoImpuesto
        End Get

        Set(ByVal Value As Decimal)
            _MontoImpuesto = Value
        End Set

    End Property

    Private _PorcentajeCompra As String
    Property PorcentajeCompra() As String
        Get
            Return _PorcentajeCompra
        End Get

        Set(ByVal Value As String)
            _PorcentajeCompra = Value
        End Set

    End Property

End Class
