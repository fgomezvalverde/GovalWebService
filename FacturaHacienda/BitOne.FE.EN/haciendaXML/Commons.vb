'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class CodigoType

    Private tipoField As String

    Private codigoField As String

    '''<remarks/>
    Public Property Tipo() As String
        Get
            Return Me.tipoField
        End Get
        Set(value As String)
            Me.tipoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Codigo() As String
        Get
            Return Me.codigoField
        End Get
        Set(value As String)
            Me.codigoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class UbicacionType

    Private provinciaField As String

    Private cantonField As String

    Private distritoField As String

    Private barrioField As String

    Private otrasSenasField As String

    '''<remarks/>
    Public Property Provincia() As String
        Get
            Return Me.provinciaField
        End Get
        Set(value As String)
            Me.provinciaField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Canton() As String
        Get
            Return Me.cantonField
        End Get
        Set(value As String)
            Me.cantonField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Distrito() As String
        Get
            Return Me.distritoField
        End Get
        Set(value As String)
            Me.distritoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Barrio() As String
        Get
            Return Me.barrioField
        End Get
        Set(value As String)
            Me.barrioField = value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasSenas() As String
        Get
            Return Me.otrasSenasField
        End Get
        Set(value As String)
            Me.otrasSenasField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class ReceptorType

    Private nombreField As String

    Private identificacionField As IdentificacionType

    Private identificacionExtranjeroField As String

    Private nombreComercialField As String

    Private ubicacionField As UbicacionType

    Private telefonoField As TelefonoType

    Private faxField As TelefonoType

    Private correoElectronicoField As String

    '''<remarks/>
    Public Property Nombre() As String
        Get
            Return Me.nombreField
        End Get
        Set(value As String)
            Me.nombreField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Identificacion() As IdentificacionType
        Get
            Return Me.identificacionField
        End Get
        Set(value As IdentificacionType)
            Me.identificacionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property IdentificacionExtranjero() As String
        Get
            Return Me.identificacionExtranjeroField
        End Get
        Set(value As String)
            Me.identificacionExtranjeroField = value
        End Set
    End Property

    '''<remarks/>
    Public Property NombreComercial() As String
        Get
            Return Me.nombreComercialField
        End Get
        Set(value As String)
            Me.nombreComercialField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Ubicacion() As UbicacionType
        Get
            Return Me.ubicacionField
        End Get
        Set(value As UbicacionType)
            Me.ubicacionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Telefono() As TelefonoType
        Get
            Return Me.telefonoField
        End Get
        Set(value As TelefonoType)
            Me.telefonoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Fax() As TelefonoType
        Get
            Return Me.faxField
        End Get
        Set(value As TelefonoType)
            Me.faxField = value
        End Set
    End Property

    '''<remarks/>
    Public Property CorreoElectronico() As String
        Get
            Return Me.correoElectronicoField
        End Get
        Set(value As String)
            Me.correoElectronicoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class TelefonoType

    Private codigoPaisField As String

    Private numTelefonoField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property CodigoPais() As String
        Get
            Return Me.codigoPaisField
        End Get
        Set(value As String)
            Me.codigoPaisField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property NumTelefono() As String
        Get
            Return Me.numTelefonoField
        End Get
        Set(value As String)
            Me.numTelefonoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class EmisorType

    Private nombreField As String

    Private identificacionField As IdentificacionType

    Private nombreComercialField As String

    Private ubicacionField As UbicacionType

    Private telefonoField As TelefonoType

    Private faxField As TelefonoType

    Private correoElectronicoField As String

    '''<remarks/>
    Public Property Nombre() As String
        Get
            Return Me.nombreField
        End Get
        Set(value As String)
            Me.nombreField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Identificacion() As IdentificacionType
        Get
            Return Me.identificacionField
        End Get
        Set(value As IdentificacionType)
            Me.identificacionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property NombreComercial() As String
        Get
            Return Me.nombreComercialField
        End Get
        Set(value As String)
            Me.nombreComercialField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Ubicacion() As UbicacionType
        Get
            Return Me.ubicacionField
        End Get
        Set(value As UbicacionType)
            Me.ubicacionField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
    Public Property Telefono() As TelefonoType
        Get
            Return Me.telefonoField
        End Get
        Set(value As TelefonoType)
            Me.telefonoField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)> _
    Public Property Fax() As TelefonoType
        Get
            Return Me.faxField
        End Get
        Set(value As TelefonoType)
            Me.faxField = value
        End Set
    End Property

    '''<remarks/>
    Public Property CorreoElectronico() As String
        Get
            Return Me.correoElectronicoField
        End Get
        Set(value As String)
            Me.correoElectronicoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class IdentificacionType

    Private tipoField As String

    Private numeroField As String

    '''<remarks/>
    Public Property Tipo() As String
        Get
            Return Me.tipoField
        End Get
        Set(value As String)
            Me.tipoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Numero() As String
        Get
            Return Me.numeroField
        End Get
        Set(value As String)
            Me.numeroField = value
        End Set
    End Property
End Class


'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class ExoneracionType

    Private tipoDocumentoField As String

    Private numeroDocumentoField As String

    Private nombreInstitucionField As String

    Private fechaEmisionField As Date

    Private montoImpuestoField As Decimal

    Private porcentajeCompraField As String

    '''<remarks/>
    Public Property TipoDocumento() As String
        Get
            Return Me.tipoDocumentoField
        End Get
        Set(value As String)
            Me.tipoDocumentoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property NumeroDocumento() As String
        Get
            Return Me.numeroDocumentoField
        End Get
        Set(value As String)
            Me.numeroDocumentoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property NombreInstitucion() As String
        Get
            Return Me.nombreInstitucionField
        End Get
        Set(value As String)
            Me.nombreInstitucionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property FechaEmision() As Date
        Get
            Return Me.fechaEmisionField
        End Get
        Set(value As Date)
            Me.fechaEmisionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property MontoImpuesto() As Decimal
        Get
            Return Me.montoImpuestoField
        End Get
        Set(value As Decimal)
            Me.montoImpuestoField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property PorcentajeCompra() As String
        Get
            Return Me.porcentajeCompraField
        End Get
        Set(value As String)
            Me.porcentajeCompraField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class ImpuestoType

    Private codigoField As String

    Private tarifaField As Decimal

    Private montoField As Decimal

    Private exoneracionField As ExoneracionType

    '''<remarks/>
    Public Property Codigo() As String
        Get
            Return Me.codigoField
        End Get
        Set(value As String)
            Me.codigoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Tarifa() As Decimal
        Get
            Return Me.tarifaField
        End Get
        Set(value As Decimal)
            Me.tarifaField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Monto() As Decimal
        Get
            Return Me.montoField
        End Get
        Set(value As Decimal)
            Me.montoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Exoneracion() As ExoneracionType
        Get
            Return Me.exoneracionField
        End Get
        Set(value As ExoneracionType)
            Me.exoneracionField = value
        End Set
    End Property
End Class


'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class InformacionReferencia

    Private tipoDocField As String

    Private numeroField As String

    Private fechaEmisionField As Date

    Private codigoField As String

    Private razonField As String

    '''<remarks/>
    Public Property TipoDoc() As String
        Get
            Return Me.tipoDocField
        End Get
        Set(value As String)
            Me.tipoDocField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Numero() As String
        Get
            Return Me.numeroField
        End Get
        Set(value As String)
            Me.numeroField = value
        End Set
    End Property

    '''<remarks/>
    Public Property FechaEmision() As Date
        Get
            Return Me.fechaEmisionField
        End Get
        Set(value As Date)
            Me.fechaEmisionField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Codigo() As String
        Get
            Return Me.codigoField
        End Get
        Set(value As String)
            Me.codigoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Razon() As String
        Get
            Return Me.razonField
        End Get
        Set(value As String)
            Me.razonField = value
        End Set
    End Property
End Class