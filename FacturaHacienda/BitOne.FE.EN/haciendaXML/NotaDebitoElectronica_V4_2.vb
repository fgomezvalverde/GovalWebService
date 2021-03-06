﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.33440.
'

Namespace BitOne.FE.EN.NotaDebitoElectronica

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica", IsNullable:=False)> _
    Partial Public Class NotaDebitoElectronica

        Private claveField As String

        Private numeroConsecutivoField As String

        Private fechaEmisionField As Date

        Private emisorField As EmisorType

        Private receptorField As ReceptorType

        Private condicionVentaField As String

        Private plazoCreditoField As String

        Private medioPagoField() As String

        Private detalleServicioField() As NotaDebitoElectronicaLineaDetalle

        Private resumenFacturaField As NotaDebitoElectronicaResumenFactura

        Private informacionReferenciaField() As InformacionReferencia

        Private normativaField As NotaDebitoElectronicaNormativa

        Private otrosField As NotaDebitoElectronicaOtros

        '''<remarks/>
        Public Property Clave() As String
            Get
                Return Me.claveField
            End Get
            Set(value As String)
                Me.claveField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NumeroConsecutivo() As String
            Get
                Return Me.numeroConsecutivoField
            End Get
            Set(value As String)
                Me.numeroConsecutivoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FechaEmision() As Date
            Get
                Return Me.fechaEmisionField
            End Get
            Set(value As Date)
                Me.fechaEmisionField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Emisor() As EmisorType
            Get
                Return Me.emisorField
            End Get
            Set(value As EmisorType)
                Me.emisorField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Receptor() As ReceptorType
            Get
                Return Me.receptorField
            End Get
            Set(value As ReceptorType)
                Me.receptorField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CondicionVenta() As String
            Get
                Return Me.condicionVentaField
            End Get
            Set(value As String)
                Me.condicionVentaField = value
            End Set
        End Property

        '''<remarks/>
        Public Property PlazoCredito() As String
            Get
                Return Me.plazoCreditoField
            End Get
            Set(value As String)
                Me.plazoCreditoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("MedioPago")> _
        Public Property MedioPago() As String()
            Get
                Return Me.medioPagoField
            End Get
            Set(value As String())
                Me.medioPagoField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("LineaDetalle", IsNullable:=False)> _
        Public Property DetalleServicio() As NotaDebitoElectronicaLineaDetalle()
            Get
                Return Me.detalleServicioField
            End Get
            Set(value As NotaDebitoElectronicaLineaDetalle())
                Me.detalleServicioField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ResumenFactura() As NotaDebitoElectronicaResumenFactura
            Get
                Return Me.resumenFacturaField
            End Get
            Set(value As NotaDebitoElectronicaResumenFactura)
                Me.resumenFacturaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("InformacionReferencia")> _
        Public Property InformacionReferencia() As InformacionReferencia()
            Get
                Return Me.informacionReferenciaField
            End Get
            Set(value As InformacionReferencia())
                Me.informacionReferenciaField = value
            End Set
        End Property

        '''<remarks/>
        Public Property Normativa() As NotaDebitoElectronicaNormativa
            Get
                Return Me.normativaField
            End Get
            Set(value As NotaDebitoElectronicaNormativa)
                Me.normativaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Otros() As NotaDebitoElectronicaOtros
            Get
                Return Me.otrosField
            End Get
            Set(value As NotaDebitoElectronicaOtros)
                Me.otrosField = Value
            End Set
        End Property
    End Class


    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Public Enum NotaDebitoElectronicaMedioPago

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
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaLineaDetalle

        Private numeroLineaField As String

        Private codigoField() As CodigoType

        Private cantidadField As Decimal

        Private unidadMedidaField As String

        Private unidadMedidaComercialField As String

        Private detalleField As String

        Private precioUnitarioField As Decimal

        Private montoTotalField As Decimal

        Private montoDescuentoField As Decimal

        Private montoDescuentoFieldSpecified As Boolean

        Private naturalezaDescuentoField As String

        Private subTotalField As Decimal

        Private impuestoField() As ImpuestoType

        Private montoTotalLineaField As Decimal

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")> _
        Public Property NumeroLinea() As String
            Get
                Return Me.numeroLineaField
            End Get
            Set(value As String)
                Me.numeroLineaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Codigo")> _
        Public Property Codigo() As CodigoType()
            Get
                Return Me.codigoField
            End Get
            Set(value As CodigoType())
                Me.codigoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Cantidad() As Decimal
            Get
                Return Me.cantidadField
            End Get
            Set(value As Decimal)
                Me.cantidadField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property UnidadMedida() As String
            Get
                Return Me.unidadMedidaField
            End Get
            Set(value As String)
                Me.unidadMedidaField = value
            End Set
        End Property

        '''<remarks/>
        Public Property UnidadMedidaComercial() As String
            Get
                Return Me.unidadMedidaComercialField
            End Get
            Set(value As String)
                Me.unidadMedidaComercialField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Detalle() As String
            Get
                Return Me.detalleField
            End Get
            Set(value As String)
                Me.detalleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PrecioUnitario() As Decimal
            Get
                Return Me.precioUnitarioField
            End Get
            Set(value As Decimal)
                Me.precioUnitarioField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MontoTotal() As Decimal
            Get
                Return Me.montoTotalField
            End Get
            Set(value As Decimal)
                Me.montoTotalField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MontoDescuento() As Decimal
            Get
                Return Me.montoDescuentoField
            End Get
            Set(value As Decimal)
                Me.montoDescuentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property MontoDescuentoSpecified() As Boolean
            Get
                Return Me.montoDescuentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.montoDescuentoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NaturalezaDescuento() As String
            Get
                Return Me.naturalezaDescuentoField
            End Get
            Set(value As String)
                Me.naturalezaDescuentoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SubTotal() As Decimal
            Get
                Return Me.subTotalField
            End Get
            Set(value As Decimal)
                Me.subTotalField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Impuesto")> _
        Public Property Impuesto() As ImpuestoType()
            Get
                Return Me.impuestoField
            End Get
            Set(value As ImpuestoType())
                Me.impuestoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MontoTotalLinea() As Decimal
            Get
                Return Me.montoTotalLineaField
            End Get
            Set(value As Decimal)
                Me.montoTotalLineaField = Value
            End Set
        End Property
    End Class


    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaResumenFactura

        Private codigoMonedaField As NotaDebitoElectronicaResumenFacturaCodigoMoneda

        Private codigoMonedaFieldSpecified As Boolean

        Private tipoCambioField As Decimal

        Private tipoCambioFieldSpecified As Boolean

        Private totalServGravadosField As Decimal

        Private totalServGravadosFieldSpecified As Boolean

        Private totalServExentosField As Decimal

        Private totalServExentosFieldSpecified As Boolean

        Private totalMercanciasGravadasField As Decimal

        Private totalMercanciasGravadasFieldSpecified As Boolean

        Private totalMercanciasExentasField As Decimal

        Private totalMercanciasExentasFieldSpecified As Boolean

        Private totalGravadoField As Decimal

        Private totalGravadoFieldSpecified As Boolean

        Private totalExentoField As Decimal

        Private totalExentoFieldSpecified As Boolean

        Private totalVentaField As Decimal

        Private totalDescuentosField As Decimal

        Private totalDescuentosFieldSpecified As Boolean

        Private totalVentaNetaField As Decimal

        Private totalImpuestoField As Decimal

        Private totalImpuestoFieldSpecified As Boolean

        Private totalComprobanteField As Decimal

        '''<remarks/>
        Public Property CodigoMoneda() As NotaDebitoElectronicaResumenFacturaCodigoMoneda
            Get
                Return Me.codigoMonedaField
            End Get
            Set(value As NotaDebitoElectronicaResumenFacturaCodigoMoneda)
                Me.codigoMonedaField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property CodigoMonedaSpecified() As Boolean
            Get
                Return Me.codigoMonedaFieldSpecified
            End Get
            Set(value As Boolean)
                Me.codigoMonedaFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TipoCambio() As Decimal
            Get
                Return Me.tipoCambioField
            End Get
            Set(value As Decimal)
                Me.tipoCambioField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TipoCambioSpecified() As Boolean
            Get
                Return Me.tipoCambioFieldSpecified
            End Get
            Set(value As Boolean)
                Me.tipoCambioFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalServGravados() As Decimal
            Get
                Return Me.totalServGravadosField
            End Get
            Set(value As Decimal)
                Me.totalServGravadosField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalServGravadosSpecified() As Boolean
            Get
                Return Me.totalServGravadosFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalServGravadosFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalServExentos() As Decimal
            Get
                Return Me.totalServExentosField
            End Get
            Set(value As Decimal)
                Me.totalServExentosField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalServExentosSpecified() As Boolean
            Get
                Return Me.totalServExentosFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalServExentosFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalMercanciasGravadas() As Decimal
            Get
                Return Me.totalMercanciasGravadasField
            End Get
            Set(value As Decimal)
                Me.totalMercanciasGravadasField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalMercanciasGravadasSpecified() As Boolean
            Get
                Return Me.totalMercanciasGravadasFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalMercanciasGravadasFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalMercanciasExentas() As Decimal
            Get
                Return Me.totalMercanciasExentasField
            End Get
            Set(value As Decimal)
                Me.totalMercanciasExentasField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalMercanciasExentasSpecified() As Boolean
            Get
                Return Me.totalMercanciasExentasFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalMercanciasExentasFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalGravado() As Decimal
            Get
                Return Me.totalGravadoField
            End Get
            Set(value As Decimal)
                Me.totalGravadoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalGravadoSpecified() As Boolean
            Get
                Return Me.totalGravadoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalGravadoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalExento() As Decimal
            Get
                Return Me.totalExentoField
            End Get
            Set(value As Decimal)
                Me.totalExentoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalExentoSpecified() As Boolean
            Get
                Return Me.totalExentoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalExentoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalVenta() As Decimal
            Get
                Return Me.totalVentaField
            End Get
            Set(value As Decimal)
                Me.totalVentaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalDescuentos() As Decimal
            Get
                Return Me.totalDescuentosField
            End Get
            Set(value As Decimal)
                Me.totalDescuentosField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalDescuentosSpecified() As Boolean
            Get
                Return Me.totalDescuentosFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalDescuentosFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalVentaNeta() As Decimal
            Get
                Return Me.totalVentaNetaField
            End Get
            Set(value As Decimal)
                Me.totalVentaNetaField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalImpuesto() As Decimal
            Get
                Return Me.totalImpuestoField
            End Get
            Set(value As Decimal)
                Me.totalImpuestoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()> _
        Public Property TotalImpuestoSpecified() As Boolean
            Get
                Return Me.totalImpuestoFieldSpecified
            End Get
            Set(value As Boolean)
                Me.totalImpuestoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TotalComprobante() As Decimal
            Get
                Return Me.totalComprobanteField
            End Get
            Set(value As Decimal)
                Me.totalComprobanteField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Public Enum NotaDebitoElectronicaResumenFacturaCodigoMoneda

        '''<remarks/>
        AED

        '''<remarks/>
        AFN

        '''<remarks/>
        ALL

        '''<remarks/>
        AMD

        '''<remarks/>
        ANG

        '''<remarks/>
        AOA

        '''<remarks/>
        ARS

        '''<remarks/>
        AUD

        '''<remarks/>
        AWG

        '''<remarks/>
        AZN

        '''<remarks/>
        BAM

        '''<remarks/>
        BBD

        '''<remarks/>
        BDT

        '''<remarks/>
        BGN

        '''<remarks/>
        BHD

        '''<remarks/>
        BIF

        '''<remarks/>
        BMD

        '''<remarks/>
        BND

        '''<remarks/>
        BOB

        '''<remarks/>
        BOV

        '''<remarks/>
        BRL

        '''<remarks/>
        BSD

        '''<remarks/>
        BTN

        '''<remarks/>
        BWP

        '''<remarks/>
        BYR

        '''<remarks/>
        BZD

        '''<remarks/>
        CAD

        '''<remarks/>
        CDF

        '''<remarks/>
        CHE

        '''<remarks/>
        CHF

        '''<remarks/>
        CHW

        '''<remarks/>
        CLF

        '''<remarks/>
        CLP

        '''<remarks/>
        CNY

        '''<remarks/>
        COP

        '''<remarks/>
        COU

        '''<remarks/>
        CRC

        '''<remarks/>
        CUC

        '''<remarks/>
        CUP

        '''<remarks/>
        CVE

        '''<remarks/>
        CZK

        '''<remarks/>
        DJF

        '''<remarks/>
        DKK

        '''<remarks/>
        DOP

        '''<remarks/>
        DZD

        '''<remarks/>
        EGP

        '''<remarks/>
        ERN

        '''<remarks/>
        ETB

        '''<remarks/>
        EUR

        '''<remarks/>
        FJD

        '''<remarks/>
        FKP

        '''<remarks/>
        GBP

        '''<remarks/>
        GEL

        '''<remarks/>
        GHS

        '''<remarks/>
        GIP

        '''<remarks/>
        GMD

        '''<remarks/>
        GNF

        '''<remarks/>
        GTQ

        '''<remarks/>
        GYD

        '''<remarks/>
        HKD

        '''<remarks/>
        HNL

        '''<remarks/>
        HRK

        '''<remarks/>
        HTG

        '''<remarks/>
        HUF

        '''<remarks/>
        IDR

        '''<remarks/>
        ILS

        '''<remarks/>
        INR

        '''<remarks/>
        IQD

        '''<remarks/>
        IRR

        '''<remarks/>
        ISK

        '''<remarks/>
        JMD

        '''<remarks/>
        JOD

        '''<remarks/>
        JPY

        '''<remarks/>
        KES

        '''<remarks/>
        KGS

        '''<remarks/>
        KHR

        '''<remarks/>
        KMF

        '''<remarks/>
        KPW

        '''<remarks/>
        KRW

        '''<remarks/>
        KWD

        '''<remarks/>
        KYD

        '''<remarks/>
        KZT

        '''<remarks/>
        LAK

        '''<remarks/>
        LBP

        '''<remarks/>
        LKR

        '''<remarks/>
        LRD

        '''<remarks/>
        LSL

        '''<remarks/>
        LYD

        '''<remarks/>
        MAD

        '''<remarks/>
        MDL

        '''<remarks/>
        MGA

        '''<remarks/>
        MKD

        '''<remarks/>
        MMK

        '''<remarks/>
        MNT

        '''<remarks/>
        MOP

        '''<remarks/>
        MRO

        '''<remarks/>
        MUR

        '''<remarks/>
        MVR

        '''<remarks/>
        MWK

        '''<remarks/>
        MXN

        '''<remarks/>
        MXV

        '''<remarks/>
        MYR

        '''<remarks/>
        MZN

        '''<remarks/>
        NAD

        '''<remarks/>
        NGN

        '''<remarks/>
        NIO

        '''<remarks/>
        NOK

        '''<remarks/>
        NPR

        '''<remarks/>
        NZD

        '''<remarks/>
        OMR

        '''<remarks/>
        PAB

        '''<remarks/>
        PEN

        '''<remarks/>
        PGK

        '''<remarks/>
        PHP

        '''<remarks/>
        PKR

        '''<remarks/>
        PLN

        '''<remarks/>
        PYG

        '''<remarks/>
        QAR

        '''<remarks/>
        RON

        '''<remarks/>
        RSD

        '''<remarks/>
        RUB

        '''<remarks/>
        RWF

        '''<remarks/>
        SAR

        '''<remarks/>
        SBD

        '''<remarks/>
        SCR

        '''<remarks/>
        SDG

        '''<remarks/>
        SEK

        '''<remarks/>
        SGD

        '''<remarks/>
        SHP

        '''<remarks/>
        SLL

        '''<remarks/>
        SOS

        '''<remarks/>
        SRD

        '''<remarks/>
        SSP

        '''<remarks/>
        STD

        '''<remarks/>
        SVC

        '''<remarks/>
        SYP

        '''<remarks/>
        SZL

        '''<remarks/>
        THB

        '''<remarks/>
        TJS

        '''<remarks/>
        TMT

        '''<remarks/>
        TND

        '''<remarks/>
        TOP

        '''<remarks/>
        [TRY]

        '''<remarks/>
        TTD

        '''<remarks/>
        TWD

        '''<remarks/>
        TZS

        '''<remarks/>
        UAH

        '''<remarks/>
        UGX

        '''<remarks/>
        USD

        '''<remarks/>
        USN

        '''<remarks/>
        UYI

        '''<remarks/>
        UYU

        '''<remarks/>
        UZS

        '''<remarks/>
        VEF

        '''<remarks/>
        VND

        '''<remarks/>
        VUV

        '''<remarks/>
        WST

        '''<remarks/>
        XAF

        '''<remarks/>
        XAG

        '''<remarks/>
        XAU

        '''<remarks/>
        XBA

        '''<remarks/>
        XBB

        '''<remarks/>
        XBC

        '''<remarks/>
        XBD

        '''<remarks/>
        XCD

        '''<remarks/>
        XDR

        '''<remarks/>
        XOF

        '''<remarks/>
        XPD

        '''<remarks/>
        XPF

        '''<remarks/>
        XPT

        '''<remarks/>
        XSU

        '''<remarks/>
        XTS

        '''<remarks/>
        XUA

        '''<remarks/>
        XXX

        '''<remarks/>
        YER

        '''<remarks/>
        ZAR

        '''<remarks/>
        ZMW

        '''<remarks/>
        ZWL
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaNormativa

        Private numeroResolucionField As String

        Private fechaResolucionField As String

        '''<remarks/>
        Public Property NumeroResolucion() As String
            Get
                Return Me.numeroResolucionField
            End Get
            Set(value As String)
                Me.numeroResolucionField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FechaResolucion() As String
            Get
                Return Me.fechaResolucionField
            End Get
            Set(value As String)
                Me.fechaResolucionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaOtros

        Private otroTextoField() As NotaDebitoElectronicaOtrosOtroTexto

        Private otroContenidoField() As NotaDebitoElectronicaOtrosOtroContenido

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("OtroTexto")> _
        Public Property OtroTexto() As NotaDebitoElectronicaOtrosOtroTexto()
            Get
                Return Me.otroTextoField
            End Get
            Set(value As NotaDebitoElectronicaOtrosOtroTexto())
                Me.otroTextoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("OtroContenido")> _
        Public Property OtroContenido() As NotaDebitoElectronicaOtrosOtroContenido()
            Get
                Return Me.otroContenidoField
            End Get
            Set(value As NotaDebitoElectronicaOtrosOtroContenido())
                Me.otroContenidoField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaOtrosOtroTexto

        Private codigoField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property codigo() As String
            Get
                Return Me.codigoField
            End Get
            Set(value As String)
                Me.codigoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()> _
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set(value As String)
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")> _
    Partial Public Class NotaDebitoElectronicaOtrosOtroContenido

        Private anyField As System.Xml.XmlElement

        Private codigoField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyElementAttribute()> _
        Public Property Any() As System.Xml.XmlElement
            Get
                Return Me.anyField
            End Get
            Set(value As System.Xml.XmlElement)
                Me.anyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()> _
        Public Property codigo() As String
            Get
                Return Me.codigoField
            End Get
            Set(value As String)
                Me.codigoField = Value
            End Set
        End Property
    End Class

End Namespace