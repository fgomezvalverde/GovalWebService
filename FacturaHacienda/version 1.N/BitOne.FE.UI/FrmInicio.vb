Imports BitOne.FE.BLL
Imports BitOne.FE.Resources
Imports BitOne.FE.EN
Imports System.Xml
Imports System.Text
Imports System.IO


Public Class FrmInicio

    Public vServicioBLL As New ServicioBLL
    'Public vUsuario As String = "cpj-3-101-635084@stag.comprobanteselectronicos.go.cr"
    'Public vPassword As String = "Y|H:Pgt-4_q!)./)8)WO"
    'Public vPin As String = "9482"
    'Public vCertificado() As Byte = IO.File.ReadAllBytes("c://a.p12")
    'Public vModalidadProduccion As Boolean = False
    Public vUrlhaciendaAuthApiDesarrollo As String = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/"
    Public vUrlhaciendaAuthApiProduccion As String = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/"
    Public vUrlhaciendaApiProduccion As String = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/"
    Public vUrlhaciendaApiDesarrollo As String = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/"
    Public vCantidadIntentos As Integer = 100

    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub btnRegistrarTiquete_Click(sender As Object, e As EventArgs) Handles btnRegistrarTiquete.Click

        Dim vReply As New Reply
        Dim b() As Byte = IO.File.ReadAllBytes(txtCertificado.Text)
        Dim vDocumentoEncabezado As New DocumentoEncabezado()
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vMediosPago As New List(Of DocumentoMedioPago)


        ' Emisor
        vDocumentoEncabezado.Emisor.Identificacion = "0000000000"
        vDocumentoEncabezado.Emisor.IdentificacionTipo = "02"
        vDocumentoEncabezado.Emisor.Direccion = "San José"
        vDocumentoEncabezado.Emisor.CodigoPais = "506"
        vDocumentoEncabezado.Emisor.Provincia = "1"
        vDocumentoEncabezado.Emisor.Canton = "01"
        vDocumentoEncabezado.Emisor.Distrito = "01"
        'vDocumentoEncabezado.Emisor.Barrio = "01"
        vDocumentoEncabezado.Emisor.Nombre = "EJEMPLO S.A."
        vDocumentoEncabezado.Emisor.NombreComercial = ""
        vDocumentoEncabezado.Emisor.Telefono = "00000000"
        vDocumentoEncabezado.Emisor.Fax = "00000000"
        vDocumentoEncabezado.Emisor.Email = "email@email.com"


        ' Receptor        
        'vDocumentoEncabezado.Receptor.IdentificacionExtranjero = "0000000000" ' Max 20 caracteres
        ''vDocumentoEncabezado.Receptor.Identificacion = "0000000000"
        'vDocumentoEncabezado.Receptor.IdentificacionTipo = "02"
        'vDocumentoEncabezado.Receptor.Direccion = "Cartago"
        'vDocumentoEncabezado.Receptor.CodigoPais = "506"
        'vDocumentoEncabezado.Receptor.Provincia = "1"
        'vDocumentoEncabezado.Receptor.Canton = "01"
        'vDocumentoEncabezado.Receptor.Distrito = "01"
        ''vDocumentoEncabezado.Receptor.Barrio = "01"
        'vDocumentoEncabezado.Receptor.Nombre = "Empresa S.A."
        'vDocumentoEncabezado.Receptor.NombreComercial = "Marca"
        'vDocumentoEncabezado.Receptor.Telefono = "00000000"
        'vDocumentoEncabezado.Receptor.Fax = "00000000"
        'vDocumentoEncabezado.Receptor.Email = "test@test.com"

        ' Encabezado
        vDocumentoEncabezado.Clave = "50611011800310163508400100001040000000105100000002"
        vDocumentoEncabezado.TipoCambio = 1 '571 '1
        vDocumentoEncabezado.Fecha = DateTime.Now
        vDocumentoEncabezado.Moneda = "CRC" '"USD"
        vDocumentoEncabezado.CondicionVenta = "Item01"
        vDocumentoEncabezado.PlazoCredito = "0"
        vDocumentoEncabezado.NormativaFechaResolucion = "20-02-2017 13:22:22"
        vDocumentoEncabezado.NormativaNumeroResolucion = "DGT-R-48-2016"
        vDocumentoEncabezado.Observacion = "Esta es la observación"


        '' Referencia
        'Dim vLineasReferencia As New List(Of DocumentoReferencia)

        'Dim referencia1 As New DocumentoReferencia
        'referencia1.TipoDoc = "Item01"
        'referencia1.Numero = "010"
        'referencia1.FechaEmision = "2018-01-31T11:20:51.7553435-06:00"
        'referencia1.Codigo = "Item03"
        'referencia1.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia1)

        'Dim referencia2 As New DocumentoReferencia
        'referencia2.TipoDoc = "Item02"
        'referencia2.Numero = "011"
        'referencia2.FechaEmision = "2018-01-17T20:12:21.3698995-06:00"
        'referencia2.Codigo = "Item03"
        'referencia2.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia2)

        'vDocumentoEncabezado.Referencia = vLineasReferencia



        ' Medios de Pago
        Dim vMedioPago1 As New DocumentoMedioPago
        vMedioPago1.Codigo = "Item01"
        vMediosPago.Add(vMedioPago1)

        'Dim vMedioPago2 As New DocumentoMedioPago
        'vMedioPago2.Codigo = "Item02"
        'vMediosPago.Add(vMedioPago2)
        'vDocumentoEncabezado.MedioPago = vMediosPago

        ' Detalle de las lineas
        Dim vLineas As New List(Of DocumentoDetalle)

        'Dim vLinea1 As New DocumentoDetalle

        'vLinea1.Cantidad = 1
        'vLinea1.Nombre = "Producto 1"
        'vLinea1.Descripcion = "Descripción del Producto 1"
        'vLinea1.Codigo = "00Gen."
        'vLinea1.Tipo = "Item99"
        'vLinea1.Unidad = "Unid"
        'vLinea1.EsProducto = True
        'vLinea1.Precio = 1000.0
        'vLinea1.Descuento = 100
        'vLinea1.DescuentoDescripcion = ""

        'Dim vListadoImpuesto As New List(Of DocumentoDetalleImpuesto)

        'Dim vImpuesto1 As New DocumentoDetalleImpuesto
        'vImpuesto1.Tipo = "Item01"
        'vImpuesto1.Tarifa = 13
        'vImpuesto1.Monto = 117
        'vListadoImpuesto.Add(vImpuesto1)

        'Dim vImpuesto2 As New DocumentoDetalleImpuesto
        'vImpuesto2.Tipo = "Item02"
        'vImpuesto2.Tarifa = 5
        'vImpuesto2.Monto = 500.0
        'vListadoImpuesto.Add(vImpuesto2)

        'vLinea1.DocumentoDetalleImpuesto = vListadoImpuesto

        'vLineas.Add(vLinea1)

        vDocumentoEncabezado.DocumentoDetalle = vLineas

        ' Datos de Hacienda
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text
        vUsuarioHacienda.Certificado = b
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        vReply = vServicioBLL.fGenerarDocumento(vDocumentoEncabezado, vUsuarioHacienda, vCantidadIntentos)

        If vReply.ok Then

            ' Si contiene el XMLDocumento
            If Not vReply.xmlDocumento Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlDocumento)
                doc.Save(txtRutaAlmacenamiento.Text & "/TQ-ENV-" & vDocumentoEncabezado.Clave & ".xml")

            End If


            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlRespuesta)
                doc.Save(txtRutaAlmacenamiento.Text & "/TQ-REC-" & vDocumentoEncabezado.Clave & ".xml")

            End If

        End If

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))


    End Sub

    Private Sub btnRegistrarFactura_Click(sender As Object, e As EventArgs) Handles btnRegistrarFactura.Click

        Dim vReply As New Reply
        Dim b() As Byte = IO.File.ReadAllBytes(txtCertificado.Text)
        Dim vDocumentoEncabezado As New DocumentoEncabezado()
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vMediosPago As New List(Of DocumentoMedioPago)


        ' Emisor
        vDocumentoEncabezado.Emisor.Identificacion = "0000000000"
        vDocumentoEncabezado.Emisor.IdentificacionTipo = "02"
        vDocumentoEncabezado.Emisor.Direccion = "San José"
        vDocumentoEncabezado.Emisor.CodigoPais = "506"
        vDocumentoEncabezado.Emisor.Provincia = "1"
        vDocumentoEncabezado.Emisor.Canton = "01"
        vDocumentoEncabezado.Emisor.Distrito = "01"
        'vDocumentoEncabezado.Emisor.Barrio = "01"
        vDocumentoEncabezado.Emisor.Nombre = "EJEMPLO S.A."
        vDocumentoEncabezado.Emisor.NombreComercial = ""
        vDocumentoEncabezado.Emisor.Telefono = "00000000"
        vDocumentoEncabezado.Emisor.Fax = "00000000"
        vDocumentoEncabezado.Emisor.Email = "email@email.com"

        ' Receptor        
        'vDocumentoEncabezado.Receptor.IdentificacionExtranjero = "0000000000" ' Max 20 caracteres
        ''vDocumentoEncabezado.Receptor.Identificacion = "0000000000"
        'vDocumentoEncabezado.Receptor.IdentificacionTipo = "02"
        'vDocumentoEncabezado.Receptor.Direccion = "Cartago"
        'vDocumentoEncabezado.Receptor.CodigoPais = "506"
        'vDocumentoEncabezado.Receptor.Provincia = "1"
        'vDocumentoEncabezado.Receptor.Canton = "01"
        'vDocumentoEncabezado.Receptor.Distrito = "01"
        ''vDocumentoEncabezado.Receptor.Barrio = "01"
        'vDocumentoEncabezado.Receptor.Nombre = "Empresa S.A."
        'vDocumentoEncabezado.Receptor.NombreComercial = "Marca"
        'vDocumentoEncabezado.Receptor.Telefono = "00000000"
        'vDocumentoEncabezado.Receptor.Fax = "00000000"
        'vDocumentoEncabezado.Receptor.Email = "test@test.com"


        ' Encabezado
        vDocumentoEncabezado.Clave = "50611011800310163508400100001010000000206100000002"
        vDocumentoEncabezado.TipoCambio = 1 '571 '1
        vDocumentoEncabezado.Fecha = DateTime.Now
        vDocumentoEncabezado.Moneda = "CRC" '"USD"
        vDocumentoEncabezado.CondicionVenta = "Item01"
        vDocumentoEncabezado.PlazoCredito = "0"
        vDocumentoEncabezado.NormativaFechaResolucion = "20-02-2017 13:22:22"
        vDocumentoEncabezado.NormativaNumeroResolucion = "DGT-R-48-2016"
        vDocumentoEncabezado.Observacion = "Esta es la observación"

        '' Referencia
        'Dim vLineasReferencia As New List(Of DocumentoReferencia)

        'Dim referencia1 As New DocumentoReferencia
        'referencia1.TipoDoc = "Item01"
        'referencia1.Numero = "010"
        'referencia1.FechaEmision = "2018-01-31T11:20:51.7553435-06:00"
        'referencia1.Codigo = "Item03"
        'referencia1.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia1)

        'Dim referencia2 As New DocumentoReferencia
        'referencia2.TipoDoc = "Item02"
        'referencia2.Numero = "011"
        'referencia2.FechaEmision = "2018-01-17T20:12:21.3698995-06:00"
        'referencia2.Codigo = "Item03"
        'referencia2.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia2)

        'vDocumentoEncabezado.Referencia = vLineasReferencia


        ' Medios de Pago
        Dim vMedioPago1 As New DocumentoMedioPago
        vMedioPago1.Codigo = "Item01"
        vMediosPago.Add(vMedioPago1)

        'Dim vMedioPago2 As New DocumentoMedioPago
        'vMedioPago2.Codigo = "Item02"
        'vMediosPago.Add(vMedioPago2)
        vDocumentoEncabezado.MedioPago = vMediosPago

        ' Detalle de las lineas
        Dim vLineas As New List(Of DocumentoDetalle)

        Dim vLinea1 As New DocumentoDetalle

        vLinea1.Cantidad = 1
        vLinea1.Nombre = "Producto 1"
        vLinea1.Descripcion = "Descripción del Producto 1"
        vLinea1.Codigo = "00Gen."
        vLinea1.Tipo = "Item99"
        vLinea1.Unidad = "Unid"
        vLinea1.EsProducto = True
        vLinea1.Precio = 1000.0
        vLinea1.Descuento = 0 ' %
        vLinea1.DescuentoDescripcion = ""

        Dim vListadoImpuesto As New List(Of DocumentoDetalleImpuesto)

        Dim vImpuesto1 As New DocumentoDetalleImpuesto
        vImpuesto1.Tipo = "Item01"
        vImpuesto1.Tarifa = 13
        vImpuesto1.Monto = 130

        '' La exoneración solamente aplica para 
        '' el Impuesto de Ventas Item01
        'Dim vImpuesto1Exoneracion As New DocumentoDetalleImpuestoExoneracion

        'vImpuesto1Exoneracion.TipoDocumento = "Item01"
        'vImpuesto1Exoneracion.NumeroDocumento = "001"
        'vImpuesto1Exoneracion.NombreInstitucion = "Cruz Roja Costarricense"
        'vImpuesto1Exoneracion.FechaEmision = DateTime.Now
        'vImpuesto1Exoneracion.MontoImpuesto = 68.25
        'vImpuesto1Exoneracion.PorcentajeCompra = 50

        'vImpuesto1.Exoneracion = vImpuesto1Exoneracion

        vListadoImpuesto.Add(vImpuesto1)

        'Dim vImpuesto2 As New DocumentoDetalleImpuesto
        'vImpuesto2.Tipo = "Item02"
        'vImpuesto2.Tarifa = 5
        'vImpuesto2.Monto = 50.0

        'vListadoImpuesto.Add(vImpuesto2)

        vLinea1.DocumentoDetalleImpuesto = vListadoImpuesto

        vLineas.Add(vLinea1)


        'Dim vLinea2 As New DocumentoDetalle

        'vLinea2.Cantidad = 1
        'vLinea2.Nombre = "Servicios Profesionales"
        'vLinea2.Descripcion = "Servicios Profesionales"
        'vLinea2.Codigo = "00Gen."
        'vLinea2.Tipo = "Item99"
        'vLinea2.Unidad = "Unid"
        'vLinea2.EsProducto = False
        'vLinea2.Precio = 1145.7
        'vLinea2.Descuento = 0
        'vLinea2.DescuentoDescripcion = ""

        'vLineas.Add(vLinea2)

        vDocumentoEncabezado.DocumentoDetalle = vLineas

        ' Datos de Hacienda
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text
        vUsuarioHacienda.Certificado = b
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        vReply = vServicioBLL.fGenerarDocumento(vDocumentoEncabezado, vUsuarioHacienda, vCantidadIntentos)

        If vReply.ok Then

            ' Si contiene el XMLDocumento
            If Not vReply.xmlDocumento Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlDocumento)
                doc.Save(txtRutaAlmacenamiento.Text & "/FAC-ENV-" & vDocumentoEncabezado.Clave & ".xml")

            End If


            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlRespuesta)
                doc.Save(txtRutaAlmacenamiento.Text & "/FAC-REC-" & vDocumentoEncabezado.Clave & ".xml")

            End If

        End If

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))

    End Sub

    Private Sub btnGenerarToken_Click(sender As Object, e As EventArgs) Handles btnGenerarToken.Click

        Dim vReply As New Reply
        Dim vUsuarioHacienda As New UsuarioHacienda()

        ' Asigna datos
        vUsuarioHacienda.modalidadProduccion = False
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text

        ' Genera Token 
        vReply = vServicioBLL.fGenerarToken(vUsuarioHacienda)

        If Not vReply.token Is Nothing Then
            MessageBox.Show("Mensaje: " & vReply.msg & Chr(13) & _
                            "Token: " & vReply.token.access_token)
        Else
            MessageBox.Show("Mensaje: " & vReply.msg & Chr(13) & "Token: NULL")
        End If



    End Sub

    Private Sub btnValidarCertificado_Click(sender As Object, e As EventArgs) Handles btnValidarCertificado.Click

        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vReply As New Reply

        ' Asigna datos
        vUsuarioHacienda.Certificado = IO.File.ReadAllBytes(txtCertificado.Text)
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text

        ' Valida PIN y Certificado
        vReply = vServicioBLL.fValidarCertificado(vUsuarioHacienda)

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))

    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminarEnvio.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtArchivoEnvio.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnPOSTHacienda_Click(sender As Object, e As EventArgs) Handles btnPOSTHacienda.Click

        Dim vClave As String = txtClaveEnvio.Text
        Dim vEmisorIdentificacion As String = txtEmisorIdentificacionEnvio.Text
        Dim vEmisorIdentificacionTipo As String = txtEmisorTipoEnvio.Text
        Dim vReceptorIdentificacion As String = txtReceptorIdentificacionEnvio.Text
        Dim vReceptorIdentificacionTipo As String = txtReceptorTipoEnvio.Text
        Dim vUsuarioHacienda As New UsuarioHacienda()


        ' Asigna datos
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        ' Envia documento         
        MessageBox.Show(vServicioBLL.fHaciendaEnviaDocumento(txtArchivoEnvio.Text, vClave, vUsuarioHacienda, vEmisorIdentificacion, vEmisorIdentificacionTipo,
                                             vReceptorIdentificacion, vReceptorIdentificacionTipo).msg)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim win As New FrmAcerca
        win.Show()
    End Sub

    Private Sub btnUrlHacienda_Click(sender As Object, e As EventArgs) Handles btnUrlHacienda.Click
        Dim win As New FrmHacienda
        win.Show()
    End Sub

    Private Sub btnGETHacienda_Click(sender As Object, e As EventArgs) Handles btnGETHacienda.Click

        Dim vClave As String = txtClaveRecepcion.Text
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vReply As New Reply

        ' Asigna datos
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        ' Consulta estado del documento
        vReply = vServicioBLL.fHaciendaRespuestaDocumento(vClave, vUsuarioHacienda)

        If vReply.ok Then

            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim wr As XmlWriter = New XmlTextWriter(txtRutaAlmacenamiento.Text & "/REC-" & vClave & ".xml", Encoding.UTF8)
                Dim xmlDoc As New XmlDocument
                xmlDoc.InnerXml = vReply.xmlRespuesta
                xmlDoc.Save(wr)

                wr.Close()

            End If

        End If

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))


    End Sub

    Private Sub btnRegistrarNotaDebito_Click(sender As Object, e As EventArgs) Handles btnRegistrarNotaDebito.Click

        Dim vReply As New Reply
        Dim b() As Byte = IO.File.ReadAllBytes(txtCertificado.Text)
        Dim vDocumentoEncabezado As New DocumentoEncabezado()
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vMediosPago As New List(Of DocumentoMedioPago)


        ' Emisor
        vDocumentoEncabezado.Emisor.Identificacion = "0000000000"
        vDocumentoEncabezado.Emisor.IdentificacionTipo = "02"
        vDocumentoEncabezado.Emisor.Direccion = "San José"
        vDocumentoEncabezado.Emisor.CodigoPais = "506"
        vDocumentoEncabezado.Emisor.Provincia = "1"
        vDocumentoEncabezado.Emisor.Canton = "01"
        vDocumentoEncabezado.Emisor.Distrito = "01"
        'vDocumentoEncabezado.Emisor.Barrio = "01"
        vDocumentoEncabezado.Emisor.Nombre = "EJEMPLO S.A."
        vDocumentoEncabezado.Emisor.NombreComercial = ""
        vDocumentoEncabezado.Emisor.Telefono = "00000000"
        vDocumentoEncabezado.Emisor.Fax = "00000000"
        vDocumentoEncabezado.Emisor.Email = "email@email.com"


        ' Receptor        
        'vDocumentoEncabezado.Receptor.IdentificacionExtranjero = "0000000000" ' Max 20 caracteres
        ''vDocumentoEncabezado.Receptor.Identificacion = "0000000000"
        'vDocumentoEncabezado.Receptor.IdentificacionTipo = "02"
        'vDocumentoEncabezado.Receptor.Direccion = "Cartago"
        'vDocumentoEncabezado.Receptor.CodigoPais = "506"
        'vDocumentoEncabezado.Receptor.Provincia = "1"
        'vDocumentoEncabezado.Receptor.Canton = "01"
        'vDocumentoEncabezado.Receptor.Distrito = "01"
        ''vDocumentoEncabezado.Receptor.Barrio = "01"
        'vDocumentoEncabezado.Receptor.Nombre = "Empresa S.A."
        'vDocumentoEncabezado.Receptor.NombreComercial = "Marca"
        'vDocumentoEncabezado.Receptor.Telefono = "00000000"
        'vDocumentoEncabezado.Receptor.Fax = "00000000"
        'vDocumentoEncabezado.Receptor.Email = "test@test.com"

        ' Encabezado
        vDocumentoEncabezado.Clave = "50611011800310163508400100001020000000110100000002"
        vDocumentoEncabezado.TipoCambio = 1
        vDocumentoEncabezado.Fecha = DateTime.Now
        vDocumentoEncabezado.Moneda = "CRC"
        vDocumentoEncabezado.CondicionVenta = "Item01"
        vDocumentoEncabezado.PlazoCredito = "0"
        vDocumentoEncabezado.NormativaFechaResolucion = "20-02-2017 13:22:22"
        vDocumentoEncabezado.NormativaNumeroResolucion = "DGT-R-48-2016"
        vDocumentoEncabezado.Observacion = "Esta es la observación"

        ' Referencia
        Dim vLineasReferencia As New List(Of DocumentoReferencia)

        Dim referencia1 As New DocumentoReferencia
        referencia1.TipoDoc = "Item01"
        referencia1.Numero = "50611011800310163508400100001010000000169100000002"
        referencia1.FechaEmision = "2017-10-09T21:36:21.35"
        referencia1.Codigo = "Item03"
        referencia1.Razon = "Monto Modificado"
        vLineasReferencia.Add(referencia1)

        'Dim referencia2 As New DocumentoReferencia
        'referencia2.TipoDoc = "Item01"
        'referencia2.Numero = "001"
        'referencia2.FechaEmision = "2018-01-17T20:12:21.3698995-06:00"
        'referencia2.Codigo = "Item03"
        'referencia2.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia2)

        vDocumentoEncabezado.Referencia = vLineasReferencia


        ' Medios de Pago
        Dim vMedioPago1 As New DocumentoMedioPago
        vMedioPago1.Codigo = "Item01"
        vMediosPago.Add(vMedioPago1)

        'Dim vMedioPago2 As New DocumentoMedioPago
        'vMedioPago2.Codigo = "Item02"
        'vMediosPago.Add(vMedioPago2)
        'vDocumentoEncabezado.MedioPago = vMediosPago

        ' Detalle de las lineas
        Dim vLineas As New List(Of DocumentoDetalle)

        'Dim vLinea1 As New DocumentoDetalle

        'vLinea1.Cantidad = 1
        'vLinea1.Nombre = "Producto 1"
        'vLinea1.Descripcion = "Descripción del Producto 1"
        'vLinea1.Codigo = "00Gen."
        'vLinea1.Tipo = "Item99"
        'vLinea1.Unidad = "Unid"
        'vLinea1.EsProducto = True
        'vLinea1.Precio = 10000.0
        'vLinea1.Descuento = 0
        'vLinea1.DescuentoDescripcion = ""

        'Dim vListadoImpuesto As New List(Of DocumentoDetalleImpuesto)

        'Dim vImpuesto1 As New DocumentoDetalleImpuesto
        'vImpuesto1.Tipo = "Item01"
        'vImpuesto1.Tarifa = 13
        'vImpuesto1.Monto = 1300.0
        'vListadoImpuesto.Add(vImpuesto1)

        ''Dim vImpuesto2 As New DocumentoDetalleImpuesto
        ''vImpuesto2.Tipo = "Item02"
        ''vImpuesto2.Tarifa = 5
        ''vImpuesto2.Monto = 500.0
        ''vListadoImpuesto.Add(vImpuesto2)

        'vLinea1.DocumentoDetalleImpuesto = vListadoImpuesto

        'vLineas.Add(vLinea1)

        Dim vLinea2 As New DocumentoDetalle

        vLinea2.Cantidad = 1
        vLinea2.Nombre = "Servicios Profesionales"
        vLinea2.Descripcion = "Servicios Profesionales"
        vLinea2.Codigo = "00Gen."
        vLinea2.Tipo = "Item99"
        vLinea2.Unidad = "Unid"
        vLinea2.EsProducto = False
        vLinea2.Precio = 1145.7
        vLinea2.Descuento = 0
        vLinea2.DescuentoDescripcion = ""

        vLineas.Add(vLinea2)

        vDocumentoEncabezado.DocumentoDetalle = vLineas

        ' Datos de Hacienda
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text
        vUsuarioHacienda.Certificado = b
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        vReply = vServicioBLL.fGenerarDocumento(vDocumentoEncabezado, vUsuarioHacienda, vCantidadIntentos)

        If vReply.ok Then

            ' Si contiene el XMLDocumento
            If Not vReply.xmlDocumento Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlDocumento)
                doc.Save(txtRutaAlmacenamiento.Text & "/NTD-ENV-" & vDocumentoEncabezado.Clave & ".xml")

            End If


            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlRespuesta)
                doc.Save(txtRutaAlmacenamiento.Text & "/NTD-REC-" & vDocumentoEncabezado.Clave & ".xml")

            End If

        End If

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))


    End Sub

    Private Sub btnRegistrarNotaCredito_Click(sender As Object, e As EventArgs) Handles btnRegistrarNotaCredito.Click


        Dim vReply As New Reply
        Dim b() As Byte = IO.File.ReadAllBytes(txtCertificado.Text)
        Dim vDocumentoEncabezado As New DocumentoEncabezado()
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vMediosPago As New List(Of DocumentoMedioPago)


        ' Emisor
        vDocumentoEncabezado.Emisor.Identificacion = "0000000000"
        vDocumentoEncabezado.Emisor.IdentificacionTipo = "02"
        vDocumentoEncabezado.Emisor.Direccion = "San José"
        vDocumentoEncabezado.Emisor.CodigoPais = "506"
        vDocumentoEncabezado.Emisor.Provincia = "1"
        vDocumentoEncabezado.Emisor.Canton = "01"
        vDocumentoEncabezado.Emisor.Distrito = "01"
        'vDocumentoEncabezado.Emisor.Barrio = "01"
        vDocumentoEncabezado.Emisor.Nombre = "EJEMPLO S.A."
        vDocumentoEncabezado.Emisor.NombreComercial = ""
        vDocumentoEncabezado.Emisor.Telefono = "00000000"
        vDocumentoEncabezado.Emisor.Fax = "00000000"
        vDocumentoEncabezado.Emisor.Email = "email@email.com"

        ' Receptor        
        'vDocumentoEncabezado.Receptor.IdentificacionExtranjero = "0000000000" ' Max 20 caracteres
        ''vDocumentoEncabezado.Receptor.Identificacion = "0000000000"
        'vDocumentoEncabezado.Receptor.IdentificacionTipo = "02"
        'vDocumentoEncabezado.Receptor.Direccion = "Cartago"
        'vDocumentoEncabezado.Receptor.CodigoPais = "506"
        'vDocumentoEncabezado.Receptor.Provincia = "1"
        'vDocumentoEncabezado.Receptor.Canton = "01"
        'vDocumentoEncabezado.Receptor.Distrito = "01"
        ''vDocumentoEncabezado.Receptor.Barrio = "01"
        'vDocumentoEncabezado.Receptor.Nombre = "Empresa S.A."
        'vDocumentoEncabezado.Receptor.NombreComercial = "Marca"
        'vDocumentoEncabezado.Receptor.Telefono = "00000000"
        'vDocumentoEncabezado.Receptor.Fax = "00000000"
        'vDocumentoEncabezado.Receptor.Email = "test@test.com"

        ' Encabezado
        vDocumentoEncabezado.Clave = "50611011800310163508400100001030000000005100000002"
        vDocumentoEncabezado.TipoCambio = 1
        vDocumentoEncabezado.Fecha = DateTime.Now
        vDocumentoEncabezado.Moneda = "CRC"
        vDocumentoEncabezado.CondicionVenta = "Item01"
        vDocumentoEncabezado.PlazoCredito = "0"
        vDocumentoEncabezado.NormativaFechaResolucion = "20-02-2017 13:22:22"
        vDocumentoEncabezado.NormativaNumeroResolucion = "DGT-R-48-2016"
        vDocumentoEncabezado.Observacion = "Esta es la observación"

        ' Referencia
        Dim vLineasReferencia As New List(Of DocumentoReferencia)

        Dim referencia1 As New DocumentoReferencia
        referencia1.TipoDoc = "Item01"
        referencia1.Numero = "50609121700310163508400100001010000000006100000002"
        referencia1.FechaEmision = "2017-10-09T21:36:21.35"
        referencia1.Codigo = "Item01"
        referencia1.Razon = "Anula Documento"
        vLineasReferencia.Add(referencia1)

        'Dim referencia2 As New DocumentoReferencia
        'referencia2.TipoDoc = "Item01"
        'referencia2.Numero = "001"
        'referencia2.FechaEmision = "2018-01-17T20:12:21.3698995-06:00"
        'referencia2.Codigo = "Item03"
        'referencia2.Razon = "Comprobante Provisional"
        'vLineasReferencia.Add(referencia2)

        vDocumentoEncabezado.Referencia = vLineasReferencia


        ' Medios de Pago
        Dim vMedioPago1 As New DocumentoMedioPago
        vMedioPago1.Codigo = "Item01"
        vMediosPago.Add(vMedioPago1)

        'Dim vMedioPago2 As New DocumentoMedioPago
        'vMedioPago2.Codigo = "Item02"
        'vMediosPago.Add(vMedioPago2)
        'vDocumentoEncabezado.MedioPago = vMediosPago

        ' Detalle de las lineas
        Dim vLineas As New List(Of DocumentoDetalle)

        'Dim vLinea1 As New DocumentoDetalle

        'vLinea1.Cantidad = 1
        'vLinea1.Nombre = "Producto 1"
        'vLinea1.Descripcion = "Descripción del Producto 1"
        'vLinea1.Codigo = "00Gen."
        'vLinea1.Tipo = "Item99"
        'vLinea1.Unidad = "Unid"
        'vLinea1.EsProducto = True
        'vLinea1.Precio = 10000.0
        'vLinea1.Descuento = 0
        'vLinea1.DescuentoDescripcion = ""

        'Dim vListadoImpuesto As New List(Of DocumentoDetalleImpuesto)

        'Dim vImpuesto1 As New DocumentoDetalleImpuesto
        'vImpuesto1.Tipo = "Item01"
        'vImpuesto1.Tarifa = 13
        'vImpuesto1.Monto = 1300.0
        'vListadoImpuesto.Add(vImpuesto1)

        ''Dim vImpuesto2 As New DocumentoDetalleImpuesto
        ''vImpuesto2.Tipo = "Item02"
        ''vImpuesto2.Tarifa = 5
        ''vImpuesto2.Monto = 500.0
        ''vListadoImpuesto.Add(vImpuesto2)

        'vLinea1.DocumentoDetalleImpuesto = vListadoImpuesto

        'vLineas.Add(vLinea1)

        Dim vLinea2 As New DocumentoDetalle

        vLinea2.Cantidad = 1
        vLinea2.Nombre = "Servicios Profesionales"
        vLinea2.Descripcion = "Servicios Profesionales"
        vLinea2.Codigo = "00Gen."
        vLinea2.Tipo = "Item99"
        vLinea2.Unidad = "Unid"
        vLinea2.EsProducto = False
        vLinea2.Precio = 1145.7
        vLinea2.Descuento = 0
        vLinea2.DescuentoDescripcion = ""

        vLineas.Add(vLinea2)

        vDocumentoEncabezado.DocumentoDetalle = vLineas

        ' Datos de Hacienda
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text
        vUsuarioHacienda.Certificado = b
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion

        vReply = vServicioBLL.fGenerarDocumento(vDocumentoEncabezado, vUsuarioHacienda, vCantidadIntentos)

        If vReply.ok Then

            ' Si contiene el XMLDocumento
            If Not vReply.xmlDocumento Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlDocumento)
                doc.Save(txtRutaAlmacenamiento.Text & "/NTC-ENV-" & vDocumentoEncabezado.Clave & ".xml")

            End If


            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlRespuesta)
                doc.Save(txtRutaAlmacenamiento.Text & "/NTC-REC-" & vDocumentoEncabezado.Clave & ".xml")

            End If

        End If

        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))

    End Sub

    Private Sub btnRutaCertificado_Click(sender As Object, e As EventArgs) Handles btnRutaCertificado.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtCertificado.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnRutaAlmacenamiento_Click(sender As Object, e As EventArgs) Handles btnRutaAlmacenamiento.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtRutaAlmacenamiento.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnExaminarXMLProveedor_Click(sender As Object, e As EventArgs) Handles btnExaminarXMLProveedor.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtXMLProveedor.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnEnviarRespuesta_Click(sender As Object, e As EventArgs) Handles btnEnviarRespuesta.Click

        Dim vReply As New Reply
        Dim b() As Byte = IO.File.ReadAllBytes(txtCertificado.Text)
        Dim vDocumentoEncabezado As New DocumentoEncabezado()
        Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vRespuesta As String


        If (rb05.Checked) Then
            ' Aceptado
            vRespuesta = "05"
        ElseIf (rb06.Checked) Then
            ' Aceptado Parcialmente
            vRespuesta = "06"
        Else
            ' Rechazado
            vRespuesta = "07"
        End If

        Dim VDocumentoProveedor As XmlDocument = New XmlDocument()
        Dim fs As New FileStream(txtXMLProveedor.Text, FileMode.Open, FileAccess.Read)

        VDocumentoProveedor.Load(fs)


        ' Emisor
        ' Datos de la empresa a la cual va dirigido el XML emito por el 
        ' proveedor
        vDocumentoEncabezado.Emisor.Identificacion = "0000000000"
        vDocumentoEncabezado.Emisor.IdentificacionTipo = "02"
        vDocumentoEncabezado.Emisor.Direccion = "San José"
        vDocumentoEncabezado.Emisor.CodigoPais = "506"
        vDocumentoEncabezado.Emisor.Provincia = "1"
        vDocumentoEncabezado.Emisor.Canton = "01"
        vDocumentoEncabezado.Emisor.Distrito = "01"
        'vDocumentoEncabezado.Emisor.Barrio = "01"
        vDocumentoEncabezado.Emisor.Nombre = "EMPRESA S.A."
        vDocumentoEncabezado.Emisor.NombreComercial = ""
        vDocumentoEncabezado.Emisor.Telefono = "00000000"
        vDocumentoEncabezado.Emisor.Fax = "00000000"
        vDocumentoEncabezado.Emisor.Email = "test@test.com"

        ' Encabezado
        vDocumentoEncabezado.Clave = "50607051800310163508400100001" & vRespuesta & "0000000005100000002"
        vDocumentoEncabezado.Fecha = DateTime.Now
        vDocumentoEncabezado.Observacion = "" '"Este es el detalle del Mensaje" ' MAX 80 caracteres

        ' Datos de Hacienda
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text
        vUsuarioHacienda.Certificado = b
        vUsuarioHacienda.modalidadProduccion = IIf(rbAmbienteProduccion.Checked = True, True, False)
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.urlhaciendaApiDesarrollo = vUrlhaciendaApiDesarrollo
        vUsuarioHacienda.urlhaciendaApiProduccion = vUrlhaciendaApiProduccion


        ' Atención: Debido a las validaciones que deben realizarse a la hora de comprobar el estado del XML del proveedor
        ' contra el servicio de hacienda, está función solamente admite un estado NORMAL. El estado de CONTINGENCIA y SIN INTERNET
        ' como se contempla ni contemplará en este complemento
        vReply = vServicioBLL.fRegistraRecepcion(vDocumentoEncabezado, vUsuarioHacienda, VDocumentoProveedor, vRespuesta, 100)

        If vReply.ok Then

            ' Si contiene el XMLDocumento
            If Not vReply.xmlDocumento Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlDocumento)
                doc.Save(txtRutaAlmacenamiento.Text & "/RESPUESTA-ENVIADA-" & vDocumentoEncabezado.Clave & ".xml")

            End If


            ' Si contiene el XMLRespuesta
            If Not vReply.xmlRespuesta Is Nothing Then

                Dim doc As XmlDocument = New XmlDocument()
                doc.LoadXml(vReply.xmlRespuesta)
                doc.Save(txtRutaAlmacenamiento.Text & "/RESPUESTA-RECIBIDA-" & vDocumentoEncabezado.Clave & ".xml")

            End If

            ' IMPORTANTE: Recuerde que debe enviar la respuesta a su proveedor vía email
            ' **************************************************************************
            ' **************************************************************************
            ' **************************************************************************
            ' **************************************************************************
            ' **************************************************************************

        End If


        MessageBox.Show("Mensaje: " & vReply.msg & Chr(13))

    End Sub
End Class
