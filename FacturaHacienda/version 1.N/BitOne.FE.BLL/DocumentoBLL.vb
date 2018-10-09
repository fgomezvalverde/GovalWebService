Imports BitOne.FE.EN
Imports BitOne.FE.Resources
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Text
Imports BitOne.FE.EN.BitOne.FE.EN.TiqueteElectronico
Imports BitOne.FE.EN.BitOne.FE.EN.NotaCreditoElectronica
Imports BitOne.FE.EN.BitOne.FE.EN.NotaDebitoElectronica
Imports BitOne.FE.EN.BitOne.FE.EN.FacturaElectronica
Imports System.IO
Imports System.Xml.Serialization
Imports BitOne.FE.EN.BitOne.FE.EN.MensajeReceptor

Public Class DocumentoBLL

    Public vDoucumentoEncabezado As New DocumentoEncabezado
    Public vDocumento As Object

    ''' <summary>
    ''' Valida que sea un email valido
    ''' </summary>
    ''' <param name="pCorreo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fValidarCorreo(pCorreo As String) As Boolean

        If pCorreo = String.Empty Then Return False

        '' Compruebo si el formato de la dirección es correcto.
        'Dim re As Regex = New Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
        'Dim m As Match = re.Match(pCorreo)

        'If m.Captures.Count <> 0 Then
        Return True
        'Else
        '    Return False
        'End If

    End Function

    ''' <summary>
    ''' Valida que el documento recibido del proveedor contenga
    ''' datos validos antes de ser procesado
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <param name="pXmlProveedor"></param>
    ''' <param name="pClave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fValidarDocumentoRecepcion(pDocumento As DocumentoEncabezado, pXmlProveedor As XmlDocument, pClave As String) As Reply

        Dim vReply As New Reply
        Dim vDocumentoProveedor As New DocumentoProveedor()

        Try

            ' Obtiene datos
            Dim VDocumento As XElement = XElement.Parse(pXmlProveedor.InnerXml)
            Dim vNameSpace As XNamespace = VDocumento.Attribute("xmlns").Value

            vDocumentoProveedor.Clave = pClave

            ' Existe el nodo emisor
            If (Not VDocumento.Element(vNameSpace + "Emisor") Is Nothing) Then

                If ((VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value Is Nothing) Or
                        (VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value Is Nothing)) Then

                    vReply.msg = "El XML recibido del proveedor es invalido. No posee nodo de Emisor correcto."
                    vReply.ok = False
                    vReply.estado = "ERROR"
                    Return vReply

                Else

                    vDocumentoProveedor.EmisorIdentificacion = VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value
                    vDocumentoProveedor.EmisorIdentificacionTipo = VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value

                End If

            Else

                vReply.msg = "El XML recibido del proveedor es invalido. No posee nodo de Emisor."
                vReply.ok = False
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Existe el nodo receptor
            If (Not VDocumento.Element(vNameSpace + "Receptor") Is Nothing) Then

                If ((VDocumento.Element(vNameSpace + "Receptor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value Is Nothing) Or
                        (VDocumento.Element(vNameSpace + "Receptor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value Is Nothing)) Then

                    vReply.msg = "El XML recibido del proveedor es invalido. No posee nodo de Receptor correcto."
                    vReply.ok = False
                    vReply.estado = "ERROR"
                    Return vReply

                Else

                    vDocumentoProveedor.ReceptorIdentificacion = VDocumento.Element(vNameSpace + "Receptor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value
                    vDocumentoProveedor.ReceptorIdentificacionTipo = VDocumento.Element(vNameSpace + "Receptor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value

                    ' Vaida que el XML del proveedor corresponda a la empresa seleccionada
                    If (vDocumentoProveedor.ReceptorIdentificacion <> pDocumento.Emisor.Identificacion Or
                       vDocumentoProveedor.ReceptorIdentificacionTipo <> pDocumento.Emisor.IdentificacionTipo) Then

                        vReply.msg = "El XML recibido del proveedor no esta dirigido a la empresa. Emitido para: Identificación (" + vDocumentoProveedor.ReceptorIdentificacion + ") Tipo (" + vDocumentoProveedor.ReceptorIdentificacionTipo + ")"
                        vReply.ok = False
                        vReply.estado = "ERROR"
                        Return vReply


                    End If

                End If

            Else

                vReply.msg = "El XML recibido del proveedor es invalido. No posee nodo de Receptor."
                vReply.ok = False
                vReply.estado = "ERROR"
                Return vReply

            End If

            Dim vFirma As XElement = VDocumento.LastNode

            ' Si la firma no existe
            If vFirma.Attribute("Id") Is Nothing Then

                vReply.msg = "El XML recibido del proveedor es invalido. No posee la firma del proveedor."
                vReply.ok = False
                vReply.estado = "ERROR"
                Return vReply

            End If

            vReply.ok = True

        Catch ex As Exception

            vReply.msg = "Ocurrió un error al validar documento procedente del proveedor"
            vReply.ok = False

        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Valida que el documento contenga datos validos
    ''' antes de ser procesado
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fValidarDocumento(pDocumento As DocumentoEncabezado, pDocCondicion As String) As Reply

        Dim vReply As New Reply

        Try

            ' Valores iniciales
            vReply.msg = String.Empty
            vReply.ok = True

            ' Valida que los tipos de documentos sean los correctos
            If pDocumento.Tipo <> Diccionario.TipoDocumentoFactura And pDocumento.Tipo <> Diccionario.TipoDocumentoTiquete And
                pDocumento.Tipo <> Diccionario.TipoDocumentoNotaCredito And pDocumento.Tipo <> Diccionario.TipoDocumentoNotaDebito Then

                vReply.msg = "El tipo de documento es distinto de: FACTURA, TIQUETE, NOTA DE CRÉDITO O DÉBITO ELECTRONICA"
                vReply.ok = False

                Return vReply

            End If

            'Si existe identificación Extranjero en el receptor no puede tener más de 20 caracteres
            If Not pDocumento.Receptor.IdentificacionExtranjero Is Nothing Then
                If pDocumento.Receptor.IdentificacionExtranjero.Length > 20 Then

                    vReply.msg = "La Identificación extranjera de un receptor debe tener máximo 20 caracteres."
                    vReply.ok = False

                    Return vReply
                End If
            End If

            ' Receptor
            'Si identificacion y tipo existen
            If (Not pDocumento.Receptor.Identificacion Is Nothing And Not pDocumento.Receptor.IdentificacionTipo Is Nothing) Then

                'pDocumento.Receptor.Barrio.Length <> 2 Or
                ' Validar Pais, Provincia, Canton, Distrito, Barrio y Dirección
                If (pDocumento.Receptor.CodigoPais.Length <= 0 Or pDocumento.Receptor.Provincia.Length <> 1 Or
                    pDocumento.Receptor.Canton.Length <> 2 Or pDocumento.Receptor.Distrito.Length <> 2 Or
                     pDocumento.Receptor.Direccion.Length <= 0) Then

                    vReply.msg = "Debe completar los datos de Ubicación del Receptor correctamente"
                    vReply.ok = False

                    Return vReply

                End If

                ' Validar Email
                If fValidarCorreo(pDocumento.Receptor.Email) = False Then

                    vReply.msg = "El Email del Receptor es invalido"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Fisica, tiene que tener 9 caracteres
                If (pDocumento.Receptor.Identificacion.Length <> 9 And pDocumento.Receptor.IdentificacionTipo = "01") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación Física"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Juridica, tiene que tener 10 caracteres
                If (pDocumento.Receptor.Identificacion.Length <> 10 And pDocumento.Receptor.IdentificacionTipo = "02") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación Jurídica"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Dimer, tiene que tener 12 caracteres
                If (pDocumento.Receptor.Identificacion.Length <> 12 And pDocumento.Receptor.IdentificacionTipo = "03") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación DIMEX"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Nite, tiene que tener 10 caracteres y Tipo 04
                If (pDocumento.Receptor.Identificacion.Length <> 10 And pDocumento.Receptor.IdentificacionTipo = "04") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación NITE"
                    vReply.ok = False

                    Return vReply

                End If

            ElseIf pDocumento.Receptor.IdentificacionExtranjero Is Nothing Then
                pDocumento.Receptor = Nothing
            End If


            'Valida que la sucursal siempre tenga 3 y termial 5
            If (pDocumento.Sucursal.Length <> 3 Or pDocumento.Terminal.Length <> 5) Then

                vReply.msg = "La sucursal (3 Caracteres) o la terminal (5 Caracteres) no poseen la cantidad de caracteres correctos"
                vReply.ok = False

                Return vReply

            End If

            ' Emisor
            'Valida que Todos los datos del emisor estén llenos 
            If (pDocumento.Emisor.Identificacion.Length <= 0 Or pDocumento.Emisor.IdentificacionTipo.Length <= 0 Or
                pDocumento.Emisor.Nombre.Length <= 0) Then

                vReply.msg = "La identificación, tipo de identificación, nombre legal del Emisor son Obligatorios"
                vReply.ok = False

                Return vReply

            Else

                'pDocumento.Emisor.Barrio.Length <> 2 Or
                ' Validar Ubicación del Emisor
                If (pDocumento.Emisor.CodigoPais.Length <= 0 Or pDocumento.Emisor.Provincia.Length <> 1 Or
                    pDocumento.Emisor.Canton.Length <> 2 Or pDocumento.Emisor.Distrito.Length <> 2 Or
                     pDocumento.Emisor.Direccion.Length <= 0) Then

                    vReply.msg = "Complete correctamente los datos de ubicación del Emisor"
                    vReply.ok = False

                    Return vReply

                End If


                ' Validar Email
                If fValidarCorreo(pDocumento.Emisor.Email) = False Then

                    vReply.msg = "El Email del Emisor es invalido"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Fisica, tiene que tener 9 caracteres
                If (pDocumento.Emisor.Identificacion.Length <> 9 And pDocumento.Emisor.IdentificacionTipo = "01") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación Física"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Juridica, tiene que tener 10 caracteres
                If (pDocumento.Emisor.Identificacion.Length <> 10 And pDocumento.Emisor.IdentificacionTipo = "02") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación Jurídica"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Dimer, tiene que tener 12 caracteres
                If (pDocumento.Emisor.Identificacion.Length <> 12 And pDocumento.Emisor.IdentificacionTipo = "03") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación DIMEX"
                    vReply.ok = False

                    Return vReply

                End If

                'Si es cedula Nite, tiene que tener 10 caracteres y Tipo 04
                If (pDocumento.Emisor.Identificacion.Length <> 10 And pDocumento.Emisor.IdentificacionTipo = "04") Then

                    vReply.msg = "El numero de digitos no corresponde a una identificación NITE"
                    vReply.ok = False

                    Return vReply

                End If

            End If


            'Valida que el documento al menos posea una línea de detalle
            If (pDocumento.DocumentoDetalle.Count <= 0) Then

                vReply.msg = "El documento no posee líneas de detalle"
                vReply.ok = False

                Return vReply

            Else

                ' Validar las lineas
                For Each vDocumentoDetalle As DocumentoDetalle In pDocumento.DocumentoDetalle

                    'Valida que cantdad tenga menos de 20 caracteres
                    If (vDocumentoDetalle.Codigo.Length > 20) Then
                        vReply.msg = "La cantidad no puede ser mayor a 20 caracteres"
                        vReply.ok = False
                        Return vReply
                    End If


                    'Sin nombre tiene mas de 160 
                    If vDocumentoDetalle.Nombre.Length > 160 Then

                        vReply.msg = "El nombre no puede ser mayor a 160 caracteres"
                        vReply.ok = False

                    End If


                    'Validad que unidad de medidad sea mayor a 0
                    If (vDocumentoDetalle.Unidad.Length < 0) Then

                        vReply.msg = "La unidad de medidad debe de ser mayor a 0"
                        vReply.ok = False

                        Return vReply

                    End If

                Next

            End If

            ' Si Consecutivo Tiene 50 caracteres
            If (pDocumento.Clave.ToString.Length <> 50) Then

                vReply.msg = "El consecutivo debe tener 50 caracteres"
                vReply.ok = False

                Return vReply

            End If

            ' Si el documento tiene estado contingencia
            If (pDocumento.Referencia.Count = 0 And pDocCondicion = Diccionario.SituacionContingencia) Then

                vReply.msg = "El documento en Contingencia debe tener al menos una referencia"
                vReply.ok = False

                Return vReply

            End If

            ' Si el documento posee más de 10 referencias
            If (pDocumento.Referencia.Count > 10) Then

                vReply.msg = "El documento posee más de 10 referencias"
                vReply.ok = False

                Return vReply

            End If

        Catch ex As Exception

            vReply.msg = "Ocurrió un error al validar documento"
            vReply.ok = False

        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Agrega el detalle del Xml a la variable general
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <remarks></remarks>
    Public Function fAsignaLineaDetalle(pDocumento As DocumentoEncabezado) As Reply

        Dim vHaciendaDetalleListado As Object = Nothing
        Dim totalSerG As Double = 0
        Dim totalSerE As Double = 0
        Dim totalMerG As Double = 0
        Dim totalMerE As Double = 0
        Dim esGravado As Boolean
        Dim totalLineaImpuesto As Double = 0
        Dim totalImpuesto As Double = 0
        Dim totalDescuento As Double = 0
        Dim vNumeroLinea As Integer = 1
        Dim vReply As New Reply

        Try

            Select Case pDocumento.Tipo
                Case Diccionario.TipoDocumentoFactura
                    vHaciendaDetalleListado = New List(Of FacturaElectronicaLineaDetalle)
                Case Diccionario.TipoDocumentoTiquete
                    vHaciendaDetalleListado = New List(Of TiqueteElectronicoLineaDetalle)
                Case Diccionario.TipoDocumentoNotaCredito
                    vHaciendaDetalleListado = New List(Of NotaCreditoElectronicaLineaDetalle)
                Case Diccionario.TipoDocumentoNotaDebito
                    vHaciendaDetalleListado = New List(Of NotaDebitoElectronicaLineaDetalle)
            End Select

            ' Recorre uno a uno el detalle del listado
            For Each vDetalle As DocumentoDetalle In pDocumento.DocumentoDetalle

                Dim vHaciendaDetalle As Object = Nothing
                Dim ListadoImpuestoType As Object = New List(Of BitOne.FE.EN.ImpuestoType)

                Select Case pDocumento.Tipo
                    Case Diccionario.TipoDocumentoFactura
                        vHaciendaDetalle = New FacturaElectronicaLineaDetalle
                    Case Diccionario.TipoDocumentoTiquete
                        vHaciendaDetalle = New TiqueteElectronicoLineaDetalle
                    Case Diccionario.TipoDocumentoNotaCredito
                        vHaciendaDetalle = New NotaCreditoElectronicaLineaDetalle
                    Case Diccionario.TipoDocumentoNotaDebito
                        vHaciendaDetalle = New NotaDebitoElectronicaLineaDetalle
                End Select

                esGravado = False

                vDetalle.Precio = FormatNumber(vDetalle.Precio, 5)
                vDetalle.Descuento = FormatNumber(vDetalle.Descuento, 5)

                ' Código
                vHaciendaDetalle.Codigo = {New BitOne.FE.EN.CodigoType With {.Codigo = vDetalle.Codigo,
                                                                             .Tipo = CType([Enum].Parse(GetType(BitOne.FE.EN.CodigoTypeTipo), vDetalle.Tipo, True), BitOne.FE.EN.CodigoTypeTipo)}}

                ' Número de Línea
                vHaciendaDetalle.NumeroLinea = vNumeroLinea

                ' Cantidad
                vHaciendaDetalle.Cantidad = FormatNumber(vDetalle.Cantidad, 3)

                ' Nombre
                vHaciendaDetalle.Detalle = vDetalle.Nombre

                ' Unidad
                vHaciendaDetalle.UnidadMedida = CType([Enum].Parse(GetType(BitOne.FE.EN.UnidadMedidaType), vDetalle.Unidad, True), BitOne.FE.EN.UnidadMedidaType)

                ' Unidad de Medida Comercial
                If (vDetalle.UnidadMedidaComercial Is Nothing) Then
                    vHaciendaDetalle.UnidadMedidaComercial = ""
                Else
                    vHaciendaDetalle.UnidadMedidaComercial = vDetalle.UnidadMedidaComercial
                End If

                ' Precio
                vHaciendaDetalle.PrecioUnitario = FormatNumber(vDetalle.Precio, 5)

                ' Monto Total
                vHaciendaDetalle.MontoTotal = FormatNumber(vDetalle.Cantidad * vDetalle.Precio, 5)

                ' Monto Descuento
                vHaciendaDetalle.MontoDescuento = FormatNumber(vDetalle.Descuento, 5)

                ' Descripción del descuento
                vHaciendaDetalle.NaturalezaDescuento = vDetalle.DescuentoDescripcion

                ' Si el monto del descuento y la descripción es vació
                If vHaciendaDetalle.MontoDescuento > 0 Then
                    vHaciendaDetalle.MontoDescuentoSpecified = True
                    If vHaciendaDetalle.NaturalezaDescuento = String.Empty Then
                        vHaciendaDetalle.NaturalezaDescuento = "N/D"
                    End If
                End If

                    ' Subtotal
                    vHaciendaDetalle.SubTotal = FormatNumber((vDetalle.Cantidad * vDetalle.Precio) - vDetalle.Descuento, 5)
                'vHaciendaDetalle.SubTotal = FormatNumber((vDetalle.Cantidad * vDetalle.Precio), 5)

                ' ------------------------- Detalle Impuesto -------------------------
                totalLineaImpuesto = 0

                ' Si posee impuestos
                If vDetalle.DocumentoDetalleImpuesto.Count > 0 Then

                    ' Recorre los impuestos de la linea
                    For Each Imp As DocumentoDetalleImpuesto In vDetalle.DocumentoDetalleImpuesto

                        Imp.Monto = FormatNumber(Imp.Monto, 5)

                        ' Si es Gravado (Posee impuesto de Ventas) 
                        If Imp.Tipo = "01" Then
                            esGravado = True
                        End If

                        ' Si es gravado y posee exoneración
                        If Imp.Tipo = "01" And Not Imp.Exoneracion Is Nothing Then

                            Dim pExoneracion As New ExoneracionType

                            pExoneracion.TipoDocumento = CType([Enum].Parse(GetType(BitOne.FE.EN.ExoneracionTypeTipoDocumento), Imp.Exoneracion.TipoDocumento, True), BitOne.FE.EN.ExoneracionTypeTipoDocumento)
                            pExoneracion.NumeroDocumento = Imp.Exoneracion.NumeroDocumento
                            pExoneracion.NombreInstitucion = Imp.Exoneracion.NombreInstitucion
                            pExoneracion.FechaEmision = Imp.Exoneracion.FechaEmision.ToString("o")
                            pExoneracion.MontoImpuesto = Imp.Exoneracion.MontoImpuesto
                            pExoneracion.PorcentajeCompra = Imp.Exoneracion.PorcentajeCompra

                            ' Le rebaja la exoneración al monto y porcentaje del impuesto
                            Imp.Monto = Imp.Monto - pExoneracion.MontoImpuesto
                            Imp.Tarifa = Imp.Tarifa - (Imp.Tarifa * (pExoneracion.PorcentajeCompra / 100))

                            ListadoImpuestoType.Add(New BitOne.FE.EN.ImpuestoType With {.Codigo = DirectCast([Enum].Parse(GetType(ImpuestoTypeCodigo), Imp.Tipo), ImpuestoTypeCodigo),
                                                                                        .Monto = FormatNumber(Imp.Monto, 5),
                                                                                        .Tarifa = FormatNumber(Imp.Tarifa, 2),
                                                                                        .Exoneracion = pExoneracion})

                        Else

                            ListadoImpuestoType.Add(New BitOne.FE.EN.ImpuestoType With {.Codigo = DirectCast([Enum].Parse(GetType(ImpuestoTypeCodigo), Imp.Tipo), ImpuestoTypeCodigo),
                                                            .Monto = FormatNumber(Imp.Monto, 5),
                                                            .Tarifa = FormatNumber(Imp.Tarifa, 2)})

                        End If

                        ' Suma al Total de impuestos de la linea
                        totalLineaImpuesto = totalLineaImpuesto + Imp.Monto

                        ' Suma al Total de impuestos
                        totalImpuesto = totalImpuesto + FormatNumber(Imp.Monto, 5)

                        ' Agrega el impuesto al arreglo
                        vHaciendaDetalle.Impuesto = ListadoImpuestoType.ToArray

                    Next

                End If
                ' -------------------------------------------------------------------

                ' Calcula el monto de la línea
                vHaciendaDetalle.MontoTotalLinea = FormatNumber((vDetalle.Cantidad * vDetalle.Precio) - vDetalle.Descuento + totalLineaImpuesto, 5)

                ' Suma el total de descuento
                totalDescuento = totalDescuento + vHaciendaDetalle.MontoDescuento

                ' Si no es un producto
                If vDetalle.EsProducto = False Then
                    ' Si es gravado
                    If esGravado Then
                        totalSerG = totalSerG + vHaciendaDetalle.MontoTotal
                    Else
                        totalSerE = totalSerE + vHaciendaDetalle.MontoTotal
                    End If
                Else
                    ' Si es gravado
                    If esGravado Then
                        totalMerG = totalMerG + vHaciendaDetalle.MontoTotal
                    Else
                        totalMerE = totalMerE + vHaciendaDetalle.MontoTotal
                    End If
                End If

                ' Agrega el Objecto al listado
                vHaciendaDetalleListado.Add(vHaciendaDetalle)

                ' Aumenta el número de línea
                vNumeroLinea = vNumeroLinea + 1

            Next

            ' Asigna el Listado al XML
            vDocumento.DetalleServicio = vHaciendaDetalleListado.ToArray

            ' Resumen del Documento
            vDocumento.ResumenFactura.TipoCambio = FormatNumber(pDocumento.TipoCambio, 5)
            vDocumento.ResumenFactura.TipoCambioSpecified = True
            vDocumento.ResumenFactura.TotalServGravados = FormatNumber(totalSerG, 5)

            vDocumento.ResumenFactura.TotalServGravadosSpecified = True
            vDocumento.ResumenFactura.TotalServExentos = FormatNumber(totalSerE, 5)
            vDocumento.ResumenFactura.TotalServExentosSpecified = True
            vDocumento.ResumenFactura.TotalMercanciasGravadas = FormatNumber(totalMerG, 5)
            vDocumento.ResumenFactura.TotalMercanciasGravadasSpecified = True
            vDocumento.ResumenFactura.TotalMercanciasExentas = FormatNumber(totalMerE, 5)
            vDocumento.ResumenFactura.TotalMercanciasExentasSpecified = True
            vDocumento.ResumenFactura.TotalGravado = FormatNumber(totalSerG + totalMerG, 5)
            vDocumento.ResumenFactura.TotalGravadoSpecified = True
            vDocumento.ResumenFactura.TotalExento = FormatNumber(totalSerE + totalMerE, 5)
            vDocumento.ResumenFactura.TotalExentoSpecified = True
            vDocumento.ResumenFactura.TotalVenta = FormatNumber(vDocumento.ResumenFactura.TotalGravado + vDocumento.ResumenFactura.TotalExento, 5)
            vDocumento.ResumenFactura.TotalDescuentos = FormatNumber(totalDescuento, 5)
            vDocumento.ResumenFactura.TotalDescuentosSpecified = True
            vDocumento.ResumenFactura.TotalVentaNeta = FormatNumber(vDocumento.ResumenFactura.TotalVenta - vDocumento.ResumenFactura.TotalDescuentos, 5)
            vDocumento.ResumenFactura.TotalImpuestoSpecified = True
            vDocumento.ResumenFactura.TotalImpuesto = FormatNumber(totalImpuesto, 5)
            vDocumento.ResumenFactura.TotalComprobante = FormatNumber(vDocumento.ResumenFactura.TotalVentaNeta + totalImpuesto, 5)

            vReply.ok = True
            vReply.msg = "Detalle del Xml generado"

        Catch ex As Exception
            vReply.ok = False
            vReply.msg = "Ocurrió un error"
        End Try

        Return vReply

    End Function


    ''' <summary>
    ''' Esta función genera el xml utilizado para enviar la respuesta 
    ''' a un documento de un proveedor, a los servicios de hacienda
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <param name="pRespuesta"></param>
    ''' <param name="pXmlProveedor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fGenerarXMLMensajeReceptor(pDocumento As DocumentoEncabezado, pRespuesta As String, pXmlProveedor As XmlDocument) As Reply

        Dim vReply As New Reply
        Dim vDocumentoProveedor As New DocumentoProveedor()
        Dim vCommon As New Common
        Dim vMontoTotalImpuesto As Decimal = 0
        Dim vTotalFactura As Decimal = 0
        Dim vClaveXMLProveedor As String = String.Empty

        Try

            ' Aceptado
            If pRespuesta = "05" Then
                pRespuesta = "Item1"
            ElseIf pRespuesta = "06" Then
                pRespuesta = "Item2"
            Else
                pRespuesta = "Item3"
            End If

            ' Obtiene datos
            Dim vXMLProveedor As XElement = XElement.Parse(pXmlProveedor.InnerXml)
            Dim vNameSpace As XNamespace = vXMLProveedor.Attribute("xmlns").Value

            vDocumentoProveedor.EmisorIdentificacion = vXMLProveedor.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value
            vDocumentoProveedor.EmisorIdentificacionTipo = vXMLProveedor.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value

            If Not vXMLProveedor.Element(vNameSpace + "ResumenFactura").Element(vNameSpace + "TotalImpuesto").Value Is Nothing Then
                vMontoTotalImpuesto = vXMLProveedor.Element(vNameSpace + "ResumenFactura").Element(vNameSpace + "TotalImpuesto").Value
            End If

            If Not vXMLProveedor.Element(vNameSpace + "ResumenFactura").Element(vNameSpace + "TotalComprobante").Value Is Nothing Then
                vTotalFactura = vXMLProveedor.Element(vNameSpace + "ResumenFactura").Element(vNameSpace + "TotalComprobante").Value
            End If

            vClaveXMLProveedor = vXMLProveedor.Element(vNameSpace + "Clave")

            vDocumento = Nothing

            vDocumento = New MensajeReceptor

            ' Asigna datos del XML
            vDocumento.Clave = vClaveXMLProveedor
            vDocumento.NumeroCedulaEmisor = vDocumentoProveedor.EmisorIdentificacion.PadLeft(12, "0")
            vDocumento.FechaEmisionDoc = pDocumento.Fecha
            vDocumento.Mensaje = CType([Enum].Parse(GetType(MensajeReceptorMensaje), pRespuesta, True), MensajeReceptorMensaje)
            vDocumento.DetalleMensaje = pDocumento.Observacion
            vDocumento.MontoTotalImpuesto = vMontoTotalImpuesto
            vDocumento.TotalFactura = vTotalFactura
            vDocumento.NumeroCedulaReceptor = pDocumento.Emisor.Identificacion.PadLeft(12, "0")
            vDocumento.NumeroConsecutivoReceptor = pDocumento.Clave.Substring(21, 20)

            ' Asigna el string con el XML
            vReply.xmlDocumento = vCommon.SerializeToXML(vDocumento)
            vReply.msg = "Documento XML Generado"
            vReply.ok = True

        Catch ex As Exception
            vReply.msg = "Ocurrió un error al generar XML"
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Genera el Xml del Documento
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fGenerarXML(pDocumento As DocumentoEncabezado, pDocCondicion As String) As Reply

        Dim vReply As New Reply
        Dim vReplyDatosEmisor As New Reply
        Dim vReplyDatosReceptor As New Reply
        Dim vMediosPagos = Nothing
        Dim vReferencias As Object = Nothing
        Dim vCodigoMoneda As Integer
        Dim vCommon As New Common

        Try

            vDocumento = Nothing

            Select Case pDocumento.Tipo

                Case Diccionario.TipoDocumentoFactura

                    vDocumento = New FacturaElectronica
                    vDocumento.ResumenFactura = New FacturaElectronicaResumenFactura
                    vCodigoMoneda = DirectCast([Enum].Parse(GetType(FacturaElectronicaResumenFacturaCodigoMoneda), pDocumento.Moneda), FacturaElectronicaResumenFacturaCodigoMoneda)
                    vDocumento.Normativa = New FacturaElectronicaNormativa
                    vDocumento.ResumenFactura = New FacturaElectronicaResumenFactura
                    vDocumento.CondicionVenta = DirectCast([Enum].Parse(GetType(FacturaElectronicaCondicionVenta), pDocumento.CondicionVenta), FacturaElectronicaCondicionVenta)

                    ' Observación
                    If (pDocumento.Observacion.Length > 0) Then
                        vDocumento.Otros = New FacturaElectronicaOtros
                        vDocumento.Otros.OtroTexto = {New FacturaElectronicaOtrosOtroTexto With {.codigo = "obs", .Value = pDocumento.Observacion}}
                    End If

                    ' Medios de Pago
                    vMediosPagos = New List(Of FacturaElectronicaMedioPago)
                    For Each vMetodoPago As DocumentoMedioPago In pDocumento.MedioPago
                        vMediosPagos.Add(DirectCast([Enum].Parse(GetType(FacturaElectronicaMedioPago), vMetodoPago.Codigo), FacturaElectronicaMedioPago))
                    Next

                Case Diccionario.TipoDocumentoTiquete

                    vDocumento = New TiqueteElectronico
                    vDocumento.ResumenFactura = New TiqueteElectronicoResumenFactura
                    vCodigoMoneda = DirectCast([Enum].Parse(GetType(TiqueteElectronicoResumenFacturaCodigoMoneda), pDocumento.Moneda), TiqueteElectronicoResumenFacturaCodigoMoneda)
                    vDocumento.Normativa = New TiqueteElectronicoNormativa
                    vDocumento.ResumenFactura = New TiqueteElectronicoResumenFactura
                    vDocumento.CondicionVenta = DirectCast([Enum].Parse(GetType(TiqueteElectronicoCondicionVenta), pDocumento.CondicionVenta), TiqueteElectronicoCondicionVenta)

                    ' Observación
                    If (pDocumento.Observacion.Length > 0) Then
                        vDocumento.Otros = New TiqueteElectronicoOtros
                        vDocumento.Otros.OtroTexto = {New TiqueteElectronicoOtrosOtroTexto With {.codigo = "obs", .Value = pDocumento.Observacion}}
                    End If

                    ' Medios de Pago
                    vMediosPagos = New List(Of TiqueteElectronicoMedioPago)
                    For Each vMetodoPago As DocumentoMedioPago In pDocumento.MedioPago
                        vMediosPagos.Add(DirectCast([Enum].Parse(GetType(TiqueteElectronicoMedioPago), vMetodoPago.Codigo), TiqueteElectronicoMedioPago))
                    Next

                Case Diccionario.TipoDocumentoNotaCredito

                    vDocumento = New NotaCreditoElectronica
                    vDocumento.ResumenFactura = New NotaCreditoElectronicaResumenFactura
                    vCodigoMoneda = DirectCast([Enum].Parse(GetType(NotaCreditoElectronicaResumenFacturaCodigoMoneda), pDocumento.Moneda), NotaCreditoElectronicaResumenFacturaCodigoMoneda)
                    vDocumento.Normativa = New NotaCreditoElectronicaNormativa
                    vDocumento.ResumenFactura = New NotaCreditoElectronicaResumenFactura
                    vDocumento.CondicionVenta = DirectCast([Enum].Parse(GetType(NotaCreditoElectronicaCondicionVenta), pDocumento.CondicionVenta), NotaCreditoElectronicaCondicionVenta)

                    ' Observación
                    If (pDocumento.Observacion.Length > 0) Then
                        vDocumento.Otros = New NotaCreditoElectronicaOtros
                        vDocumento.Otros.OtroTexto = {New NotaCreditoElectronicaOtrosOtroTexto With {.codigo = "obs", .Value = pDocumento.Observacion}}
                    End If

                    ' Medios de Pago
                    vMediosPagos = New List(Of NotaCreditoElectronicaMedioPago)
                    For Each vMetodoPago As DocumentoMedioPago In pDocumento.MedioPago
                        vMediosPagos.Add(DirectCast([Enum].Parse(GetType(NotaCreditoElectronicaMedioPago), vMetodoPago.Codigo), NotaCreditoElectronicaMedioPago))
                    Next

                Case Diccionario.TipoDocumentoNotaDebito

                    vDocumento = New NotaDebitoElectronica
                    vDocumento.ResumenFactura = New NotaDebitoElectronicaResumenFactura
                    vCodigoMoneda = DirectCast([Enum].Parse(GetType(NotaDebitoElectronicaResumenFacturaCodigoMoneda), pDocumento.Moneda), NotaDebitoElectronicaResumenFacturaCodigoMoneda)
                    vDocumento.Normativa = New NotaDebitoElectronicaNormativa
                    vDocumento.ResumenFactura = New NotaDebitoElectronicaResumenFactura
                    vDocumento.CondicionVenta = DirectCast([Enum].Parse(GetType(NotaDebitoElectronicaCondicionVenta), pDocumento.CondicionVenta), NotaDebitoElectronicaCondicionVenta)

                    ' Observación
                    If (pDocumento.Observacion.Length > 0) Then
                        vDocumento.Otros = New NotaDebitoElectronicaOtros
                        vDocumento.Otros.OtroTexto = {New NotaDebitoElectronicaOtrosOtroTexto With {.codigo = "obs", .Value = pDocumento.Observacion}}
                    End If

                    ' Medios de Pago
                    vMediosPagos = New List(Of NotaDebitoElectronicaMedioPago)
                    For Each vMetodoPago As DocumentoMedioPago In pDocumento.MedioPago
                        vMediosPagos.Add(DirectCast([Enum].Parse(GetType(NotaDebitoElectronicaMedioPago), vMetodoPago.Codigo), NotaDebitoElectronicaMedioPago))
                    Next

            End Select

            ' Emisor
            vDocumento.Emisor = New BitOne.FE.EN.EmisorType
            vDocumento.Emisor.Identificacion = New BitOne.FE.EN.IdentificacionType
            vDocumento.Emisor.Ubicacion = New BitOne.FE.EN.UbicacionType
            vDocumento.Emisor.Telefono = New BitOne.FE.EN.TelefonoType
            vDocumento.Emisor.Fax = New BitOne.FE.EN.TelefonoType

            ' Si datos del receptor existen
            If Not pDocumento.Receptor Is Nothing Then

                ' Receptor
                vDocumento.Receptor = New BitOne.FE.EN.ReceptorType()
                vDocumento.Receptor.Identificacion = New BitOne.FE.EN.IdentificacionType
                vDocumento.Receptor.Ubicacion = New BitOne.FE.EN.UbicacionType
                vDocumento.Receptor.Telefono = New BitOne.FE.EN.TelefonoType
                vDocumento.Receptor.Fax = New BitOne.FE.EN.TelefonoType

            End If

            ' Clave
            vDocumento.Clave = pDocumento.Clave

            ' Consecutivo 
            vDocumento.NumeroConsecutivo = pDocumento.Sucursal & pDocumento.Terminal & pDocumento.Tipo & pDocumento.DocumentoConsecutivo.ToString.PadLeft(10, "0")

            ' Fecha
            vDocumento.FechaEmision = pDocumento.Fecha.ToString("o")

            ' Medio Pago
            vDocumento.MedioPago = vMediosPagos.ToArray

            ' Pazo Crédito
            vDocumento.PlazoCredito = pDocumento.PlazoCredito

            ' Normativa
            vDocumento.Normativa.FechaResolucion = pDocumento.NormativaFechaResolucion
            vDocumento.Normativa.NumeroResolucion = pDocumento.NormativaNumeroResolucion

            ' Si el código de moneda es distinto de cero
            If vCodigoMoneda <> 0 Then
                vDocumento.ResumenFactura.CodigoMoneda = vCodigoMoneda
                vDocumento.ResumenFactura.CodigoMonedaSpecified = True
            End If

            ' Emisor
            vReplyDatosEmisor = fAsignarDatosEmisor(pDocumento)

            ' Si el Emisor no se asigno correctamente
            If vReplyDatosEmisor.ok = False Then
                vReply.ok = False
                vReply.msg = vReplyDatosEmisor.msg
                Return vReply
            End If

            ' Si datos del receptor existen
            If Not pDocumento.Receptor Is Nothing Then

                ' Receptor
                vReplyDatosReceptor = fAsignarDatosReceptor(pDocumento)

                ' Si el Receptor no se asigno correctamente
                If vReplyDatosReceptor.ok = False Then
                    vReply.ok = False
                    vReply.msg = vReplyDatosReceptor.msg
                    Return vReply
                End If

            End If

            ' Si es contingencia
            If pDocumento.Referencia.Count > 0 Then

                vReferencias = New List(Of InformacionReferencia)
                For Each vReferencia As DocumentoReferencia In pDocumento.Referencia

                    Dim vInformacionReferencia As New InformacionReferencia

                    vInformacionReferencia.TipoDoc = CType([Enum].Parse(GetType(InformacionReferenciaTipoDoc), vReferencia.TipoDoc, True), InformacionReferenciaTipoDoc)
                    vInformacionReferencia.Numero = vReferencia.Numero
                    vInformacionReferencia.FechaEmision = vReferencia.FechaEmision
                    vInformacionReferencia.Codigo = CType([Enum].Parse(GetType(InformacionReferenciaCodigo), vReferencia.Codigo, True), InformacionReferenciaCodigo)
                    vInformacionReferencia.Razon = vReferencia.Razon

                    vReferencias.Add(vInformacionReferencia)

                Next

                vDocumento.InformacionReferencia = vReferencias.toArray

            End If

            ' Asigna las lineas de detalle
            If (fAsignaLineaDetalle(pDocumento).ok = False) Then

                vReply.msg = "Ocurrió un error al generar XML"
                vReply.ok = False

                Return vReply

            End If

            ' Asigna el string con el XML
            vReply.xmlDocumento = vCommon.SerializeToXML(vDocumento)
            vReply.msg = "Documento XML Generado"
            vReply.ok = True

        Catch ex As Exception
            vReply.msg = "Ocurrió un error al generar XML"
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Asigna datos del Emisor
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fAsignarDatosEmisor(pDocumento As DocumentoEncabezado) As Reply

        Dim vReply As New Reply

        Try

            If (pDocumento.Emisor.Nombre.Length <= 80 And pDocumento.Emisor.Direccion.Length > 0 Or pDocumento.Emisor.Direccion.Length <= 160 And pDocumento.Emisor.CodigoPais.Length > 0 And
            pDocumento.Emisor.Telefono.Length < 20 And pDocumento.PlazoCredito.Length <= 10 And pDocumento.PlazoCredito.Count < 0 And pDocumento.MedioPago.Count >= 4) Then

                vReply.ok = True

                pDocumento.Emisor.Telefono = Regex.Replace(pDocumento.Emisor.Telefono, "[^0-9]", " ")
                pDocumento.Emisor.Fax = Regex.Replace(pDocumento.Emisor.Fax, "[^0-9]", " ")

                Select Case pDocumento.Emisor.IdentificacionTipo
                    Case "01"
                        vDocumento.Emisor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item01
                    Case "02"
                        vDocumento.Emisor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item02
                    Case "03"
                        vDocumento.Emisor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item03
                    Case "04"
                        vDocumento.Emisor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item04
                End Select

                vDocumento.Emisor.Identificacion.Numero = pDocumento.Emisor.Identificacion
                vDocumento.Emisor.Nombre = pDocumento.Emisor.Nombre
                vDocumento.Emisor.NombreComercial = pDocumento.Emisor.NombreComercial

                ' Ubicación
                vDocumento.Emisor.Ubicacion.Provincia = pDocumento.Emisor.Provincia
                vDocumento.Emisor.Ubicacion.Canton = pDocumento.Emisor.Canton
                vDocumento.Emisor.Ubicacion.Distrito = pDocumento.Emisor.Distrito
                vDocumento.Emisor.Ubicacion.Barrio = pDocumento.Emisor.Barrio
                vDocumento.Emisor.Ubicacion.OtrasSenas = pDocumento.Emisor.Direccion

                ' Telefono
                vDocumento.Emisor.Telefono.CodigoPais = pDocumento.Emisor.CodigoPais
                vDocumento.Emisor.Telefono.NumTelefono = pDocumento.Emisor.Telefono

                ' Fax
                vDocumento.Emisor.Fax.CodigoPais = pDocumento.Emisor.CodigoPais
                vDocumento.Emisor.Fax.NumTelefono = pDocumento.Emisor.Fax

                ' Email
                vDocumento.Emisor.CorreoElectronico = pDocumento.Emisor.Email

            End If

        Catch ex As Exception
            vReply.ok = False
            vReply.msg = "Ocurrió un error al cargar datos del Emisor"
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Asigna datos del Receptor
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fAsignarDatosReceptor(pDocumento As DocumentoEncabezado) As Reply

        Dim vReply As New Reply

        Try


            If (pDocumento.Receptor.Nombre.Length <= 80 And pDocumento.Receptor.Direccion.Length > 0 Or pDocumento.Receptor.Direccion.Length <= 160 And
                    pDocumento.Receptor.CodigoPais.Length > 0 And
                    pDocumento.Receptor.Telefono.Length < 20 And pDocumento.PlazoCredito.Length <= 10 And pDocumento.MedioPago.Count < 0 And
                        pDocumento.MedioPago.Count >= 4) Then

                vReply.ok = True

                pDocumento.Receptor.Telefono = Regex.Replace(pDocumento.Receptor.Telefono, "[^0-9]", " ")
                pDocumento.Receptor.Fax = Regex.Replace(pDocumento.Receptor.Fax, "[^0-9]", " ")

                ' Si identificación Extranjero no esta vació
                If Not pDocumento.Receptor.IdentificacionExtranjero Is Nothing Then

                    vDocumento.Receptor.IdentificacionExtranjero = pDocumento.Receptor.IdentificacionExtranjero
                    vDocumento.Receptor.Identificacion = Nothing

                Else

                    Select Case pDocumento.Receptor.IdentificacionTipo
                        Case "01"
                            vDocumento.Receptor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item01
                        Case "02"
                            vDocumento.Receptor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item02
                        Case "03"
                            vDocumento.Receptor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item03
                        Case "04"
                            vDocumento.Receptor.Identificacion.Tipo = BitOne.FE.EN.IdentificacionTypeTipo.Item04
                    End Select

                    vDocumento.Receptor.Identificacion.Numero = pDocumento.Receptor.Identificacion

                End If

                vDocumento.Receptor.Nombre = pDocumento.Receptor.Nombre
                vDocumento.Receptor.NombreComercial = pDocumento.Receptor.NombreComercial

                ' Ubicación            
                vDocumento.Receptor.Ubicacion.Provincia = pDocumento.Receptor.Provincia
                vDocumento.Receptor.Ubicacion.Canton = pDocumento.Receptor.Canton
                vDocumento.Receptor.Ubicacion.Distrito = pDocumento.Receptor.Distrito
                vDocumento.Receptor.Ubicacion.Barrio = pDocumento.Receptor.Barrio
                vDocumento.Receptor.Ubicacion.OtrasSenas = pDocumento.Receptor.Direccion

                ' Telefono            
                vDocumento.Receptor.Telefono.CodigoPais = pDocumento.Receptor.CodigoPais
                vDocumento.Receptor.Telefono.NumTelefono = pDocumento.Receptor.Telefono

                ' Fax            
                vDocumento.Receptor.Fax.CodigoPais = pDocumento.Receptor.CodigoPais
                vDocumento.Receptor.Fax.NumTelefono = pDocumento.Receptor.Fax

                ' Email
                vDocumento.Receptor.CorreoElectronico = pDocumento.Receptor.Email

            End If

        Catch ex As Exception
            vReply.ok = False
            vReply.msg = "Ocurrió un error al cargar datos del Receptor"
        End Try

        Return vReply

    End Function

End Class
