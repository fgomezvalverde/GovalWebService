'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class CodigoType

    Private tipoField As CodigoTypeTipo

    Private codigoField As String

    '''<remarks/>
    Public Property Tipo() As CodigoTypeTipo
        Get
            Return Me.tipoField
        End Get
        Set(value As CodigoTypeTipo)
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

    Private tipoField As IdentificacionTypeTipo

    Private numeroField As String

    '''<remarks/>
    Public Property Tipo() As IdentificacionTypeTipo
        Get
            Return Me.tipoField
        End Get
        Set(value As IdentificacionTypeTipo)
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
 System.SerializableAttribute()> _
Public Enum IdentificacionTypeTipo

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute()>
Public Enum CodigoTypeTipo

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute()> _
Public Enum UnidadMedidaType

    '''<remarks/>
    Sp

    '''<remarks/>
    m

    '''<remarks/>
    kg

    '''<remarks/>
    s

    '''<remarks/>
    A

    '''<remarks/>
    K

    '''<remarks/>
    mol

    '''<remarks/>
    cd

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("mÂ²")> _
    mÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("mÂ³")> _
    mÂ1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("m/s")> _
    ms

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("m/sÂ²")> _
    msÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1/m")> _
    Item1m

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("kg/mÂ³")> _
    kgmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A/mÂ²")> _
    AmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A/m")> _
    Am

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("mol/mÂ³")> _
    molmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("cd/mÂ²")> _
    cdmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")> _
    Item1

    '''<remarks/>
    rad

    '''<remarks/>
    sr

    '''<remarks/>
    Hz

    '''<remarks/>
    N

    '''<remarks/>
    Pa

    '''<remarks/>
    J

    '''<remarks/>
    W

    '''<remarks/>
    C

    '''<remarks/>
    V

    '''<remarks/>
    F

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("â„¦")> _
    â

    '''<remarks/>
    Wb

    '''<remarks/>
    T

    '''<remarks/>
    H

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Â°C")> _
    ÂC

    '''<remarks/>
    lm

    '''<remarks/>
    lx

    '''<remarks/>
    Bq

    '''<remarks/>
    Gy

    '''<remarks/>
    Sv

    '''<remarks/>
    kat

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("PaÂ·s")> _
    PaÂs

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("NÂ·m")> _
    NÂm

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("N/m")> _
    Nm

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("rad/s")> _
    rads

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("rad/sÂ²")> _
    radsÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("W/mÂ²")> _
    WmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/K")> _
    JK

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/(kgÂ·K)")> _
    JkgÂK

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/kg")> _
    Jkg

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("W/(mÂ·K)")> _
    WmÂK

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/mÂ³")> _
    JmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("V/m")> _
    Vm

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("C/mÂ³")> _
    CmÂ

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("C/mÂ²")> _
    CmÂ1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("F/m")> _
    Fm

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("H/m")> _
    Hm

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/mol")> _
    Jmol

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("J/(molÂ·K)")> _
    JmolÂK

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("C/kg")> _
    Ckg

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Gy/s")> _
    Gys

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("W/sr")> _
    Wsr

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("W/(mÂ²Â·sr)")> _
    WmÂÂsr

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("kat/mÂ³")> _
    katmÂ

    '''<remarks/>
    min


    '''<remarks/>
    d

    '''<remarks/>
    Âº

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Â´Â´")> _
    ÂÂ

    '''<remarks/>
    L

    '''<remarks/>
    Np

    '''<remarks/>
    B

    '''<remarks/>
    eV

    '''<remarks/>
    u

    '''<remarks/>
    ua

    '''<remarks/>
    Unid

    '''<remarks/>
    Gal

    '''<remarks/>
    g

    '''<remarks/>
    Km

    '''<remarks/>
    ln

    '''<remarks/>
    cm

    '''<remarks/>
    mL

    '''<remarks/>
    mm

    '''<remarks/>
    Oz

    '''<remarks/>
    Otros
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute()> _
Public Enum ImpuestoTypeCodigo

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("06")> _
    Item06

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("07")> _
    Item07

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("08")> _
    Item08

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("09")> _
    Item09

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("10")> _
    Item10

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("11")> _
    Item11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("12")> _
    Item12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("98")> _
    Item98

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute()> _
Public Enum ExoneracionTypeTipoDocumento

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class ExoneracionType

    Private tipoDocumentoField As ExoneracionTypeTipoDocumento

    Private numeroDocumentoField As String

    Private nombreInstitucionField As String

    Private fechaEmisionField As Date

    Private montoImpuestoField As Decimal

    Private porcentajeCompraField As String

    '''<remarks/>
    Public Property TipoDocumento() As ExoneracionTypeTipoDocumento
        Get
            Return Me.tipoDocumentoField
        End Get
        Set(value As ExoneracionTypeTipoDocumento)
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

    Private codigoField As ImpuestoTypeCodigo

    Private tarifaField As Decimal

    Private montoField As Decimal

    Private exoneracionField As ExoneracionType

    '''<remarks/>
    Public Property Codigo() As ImpuestoTypeCodigo
        Get
            Return Me.codigoField
        End Get
        Set(value As ImpuestoTypeCodigo)
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
 System.SerializableAttribute()> _
Public Enum InformacionReferenciaTipoDoc

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("06")> _
    Item06

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("07")> _
    Item07

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("08")> _
    Item08

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute()> _
Public Enum InformacionReferenciaCodigo

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("01")> _
    Item01

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("02")> _
    Item02

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("03")> _
    Item03

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("04")> _
    Item04

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("05")> _
    Item05

'''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("99")> _
    Item99
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code")> _
Partial Public Class InformacionReferencia

Private tipoDocField As InformacionReferenciaTipoDoc

Private numeroField As String

Private fechaEmisionField As Date

Private codigoField As InformacionReferenciaCodigo

Private razonField As String

'''<remarks/>
Public Property TipoDoc() As InformacionReferenciaTipoDoc
    Get
        Return Me.tipoDocField
    End Get
    Set(value As InformacionReferenciaTipoDoc)
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
Public Property Codigo() As InformacionReferenciaCodigo
    Get
        Return Me.codigoField
    End Get
    Set(value As InformacionReferenciaCodigo)
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