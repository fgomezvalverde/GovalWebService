Public Class DocumentoDetalleImpuesto

    Private _tipo As String
    Property Tipo() As String
        Get
            Return _tipo
        End Get

        Set(ByVal Value As String)
            _tipo = Value
        End Set

    End Property

    Private _monto As Double
    Property Monto() As Double
        Get
            Return _monto
        End Get

        Set(ByVal Value As Double)
            _monto = Value
        End Set

    End Property

    Private _tarifa As Double
    Property Tarifa() As Double
        Get
            Return _tarifa
        End Get

        Set(ByVal Value As Double)
            _tarifa = Value
        End Set

    End Property

    Private _Exoneracion As DocumentoDetalleImpuestoExoneracion
    Property Exoneracion() As DocumentoDetalleImpuestoExoneracion
        Get
            Return _Exoneracion
        End Get
        Set(value As DocumentoDetalleImpuestoExoneracion)
            _Exoneracion = value
        End Set
    End Property

End Class
