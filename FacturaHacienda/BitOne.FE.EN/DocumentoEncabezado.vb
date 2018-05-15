Public Class DocumentoEncabezado

    Private _Emisor As New Emisor
    Public Property Emisor() As Emisor
        Get
            Return _Emisor
        End Get
        Set(ByVal value As Emisor)
            _Emisor = value
        End Set
    End Property

    Private _Receptor As New Receptor
    Public Property Receptor() As Receptor
        Get
            Return _Receptor
        End Get
        Set(ByVal value As Receptor)
            _Receptor = value
        End Set
    End Property

    Private _CondicionVenta As String
    Property CondicionVenta() As String
        Get
            Return _CondicionVenta
        End Get
        Set(value As String)
            _CondicionVenta = value
        End Set
    End Property

    Private _MedioPago As New List(Of DocumentoMedioPago)
    Property MedioPago() As List(Of DocumentoMedioPago)
        Get
            Return _MedioPago
        End Get
        Set(value As List(Of DocumentoMedioPago))
            _MedioPago = value
        End Set
    End Property

    Private _PlazoCredito As String
    Property PlazoCredito() As String
        Get
            Return _PlazoCredito
        End Get
        Set(value As String)
            _PlazoCredito = value
        End Set
    End Property

    Private _fecha As System.DateTime
    Property Fecha() As System.DateTime
        Get
            Return _fecha
        End Get

        Set(ByVal Value As System.DateTime)
            _fecha = Value
        End Set

    End Property

    Private _observacion As String
    Property Observacion() As String
        Get
            Return _observacion
        End Get

        Set(ByVal Value As String)
            _observacion = Value
        End Set

    End Property

    Private _documentoDetalle As New List(Of DocumentoDetalle)
    Public Property DocumentoDetalle() As List(Of DocumentoDetalle)
        Get
            Return _documentoDetalle
        End Get
        Set(ByVal value As List(Of DocumentoDetalle))
            _documentoDetalle = value
        End Set
    End Property

    Private _sucursal As String
    Property Sucursal() As String
        Get
            Return _sucursal
        End Get

        Set(ByVal Value As String)
            _sucursal = Value
        End Set

    End Property

    Private _terminal As String
    Property Terminal() As String
        Get
            Return _terminal
        End Get

        Set(ByVal Value As String)
            _terminal = Value
        End Set

    End Property

    Private _clave As String
    Property Clave() As String
        Get
            Return _clave
        End Get

        Set(ByVal Value As String)
            _clave = Value
        End Set

    End Property

    Private _tipo As String
    Property Tipo() As String
        Get
            Return _tipo
        End Get

        Set(ByVal Value As String)
            _tipo = Value
        End Set

    End Property

    Private _normativaFechaResolucion As String
    Property NormativaFechaResolucion() As String
        Get
            Return _normativaFechaResolucion
        End Get

        Set(ByVal Value As String)
            _normativaFechaResolucion = Value
        End Set

    End Property

    Private _normativaNumeroResolucion As String
    Property NormativaNumeroResolucion() As String
        Get
            Return _normativaNumeroResolucion
        End Get

        Set(ByVal Value As String)
            _normativaNumeroResolucion = Value
        End Set

    End Property

    Private documentoEncabezado_id As String
    Property DocumentoConsecutivo() As String
        Get
            Return documentoEncabezado_id
        End Get

        Set(ByVal Value As String)
            documentoEncabezado_id = Value
        End Set

    End Property

    Private _moneda As String
    Property Moneda() As String
        Get
            Return _moneda
        End Get

        Set(ByVal Value As String)
            _moneda = Value
        End Set

    End Property

    Private _tipoCambio As Double
    Property TipoCambio() As Double
        Get
            Return _tipoCambio
        End Get

        Set(ByVal Value As Double)
            _tipoCambio = Value
        End Set

    End Property

    Private _subTotal As Double
    Property SubTotal() As Double
        Get
            Return _subTotal
        End Get

        Set(ByVal Value As Double)
            _subTotal = Value
        End Set

    End Property

    Private _descuento As Double
    Property Descuento() As Double
        Get
            Return _descuento
        End Get

        Set(ByVal Value As Double)
            _descuento = Value
        End Set

    End Property

    Private _exento As Double
    Property Exento() As Double
        Get
            Return _exento
        End Get

        Set(ByVal Value As Double)
            _exento = Value
        End Set

    End Property

    Private _impuesto As Double
    Property Impuesto() As Double
        Get
            Return _impuesto
        End Get

        Set(ByVal Value As Double)
            _impuesto = Value
        End Set

    End Property

    Private _estado As Integer
    Property Estado() As Integer
        Get
            Return _estado
        End Get

        Set(ByVal Value As Integer)
            _estado = Value
        End Set

    End Property

    Private _referencia As New List(Of DocumentoReferencia)
    Property Referencia() As List(Of DocumentoReferencia)
        Get
            Return _referencia
        End Get

        Set(ByVal Value As List(Of DocumentoReferencia))
            _referencia = Value
        End Set

    End Property

End Class
