Public Class DocumentoDetalle


    Private _documentoDetalleImpuesto As New List(Of DocumentoDetalleImpuesto)
    Public Property DocumentoDetalleImpuesto() As List(Of DocumentoDetalleImpuesto)
        Get
            Return _documentoDetalleImpuesto
        End Get
        Set(ByVal value As List(Of DocumentoDetalleImpuesto))
            _documentoDetalleImpuesto = value
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

    Private _tipo As String
    Property Tipo() As String
        Get
            Return _tipo
        End Get

        Set(ByVal Value As String)
            _tipo = Value
        End Set

    End Property
    
    Private _esProducto As Boolean
    Property EsProducto() As Boolean
        Get
            Return _esProducto
        End Get

        Set(ByVal Value As Boolean)
            _esProducto = Value
        End Set

    End Property

    Private _UnidadMedidaComercial As String
    Property UnidadMedidaComercial() As String
        Get
            Return _UnidadMedidaComercial
        End Get

        Set(ByVal Value As String)
            _UnidadMedidaComercial = Value
        End Set

    End Property

    Private Unidad_id As String
    Property Unidad() As String
        Get
            Return Unidad_id
        End Get

        Set(ByVal Value As String)
            Unidad_id = Value
        End Set

    End Property

    Private _precio As Double
    Property Precio() As Double
        Get
            Return _precio
        End Get

        Set(ByVal Value As Double)
            _precio = Value
        End Set

    End Property

    Private _cantidad As Double
    Property Cantidad() As Double
        Get
            Return _cantidad
        End Get

        Set(ByVal Value As Double)
            _cantidad = Value
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

    Private _descripcion As String
    Property Descripcion() As String
        Get
            Return _descripcion
        End Get

        Set(ByVal Value As String)
            _descripcion = Value
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

    Private _descuentoDescripcion As String
    Property DescuentoDescripcion() As String
        Get
            Return _descuentoDescripcion
        End Get

        Set(ByVal Value As String)
            _descuentoDescripcion = Value
        End Set

    End Property

End Class
