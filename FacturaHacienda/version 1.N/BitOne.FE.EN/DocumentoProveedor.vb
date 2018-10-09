Public Class DocumentoProveedor

    Private _clave As String

    Public Property Clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property

    Private _EmisorIdentificacion As String

    Public Property EmisorIdentificacion() As String
        Get
            Return _EmisorIdentificacion
        End Get
        Set(ByVal value As String)
            _EmisorIdentificacion = value
        End Set
    End Property

    Private _EmisorIdentificacionTipo As String

    Public Property EmisorIdentificacionTipo() As String
        Get
            Return _EmisorIdentificacionTipo
        End Get
        Set(ByVal value As String)
            _EmisorIdentificacionTipo = value
        End Set
    End Property

    Private _ReceptorIdentificacion As String

    Public Property ReceptorIdentificacion() As String
        Get
            Return _ReceptorIdentificacion
        End Get
        Set(ByVal value As String)
            _ReceptorIdentificacion = value
        End Set
    End Property

    Private _ReceptorIdentificacionTipo As String

    Public Property ReceptorIdentificacionTipo() As String
        Get
            Return _ReceptorIdentificacionTipo
        End Get
        Set(ByVal value As String)
            _ReceptorIdentificacionTipo = value
        End Set
    End Property

    Private _MontoTotalImpuesto As Decimal

    Public Property MontoTotalImpuesto() As Decimal
        Get
            Return _MontoTotalImpuesto
        End Get
        Set(ByVal value As Decimal)
            _MontoTotalImpuesto = value
        End Set
    End Property

    Private _TotalFactura As Decimal

    Public Property TotalFactura() As Decimal
        Get
            Return _TotalFactura
        End Get
        Set(ByVal value As Decimal)
            _TotalFactura = value
        End Set
    End Property


End Class
