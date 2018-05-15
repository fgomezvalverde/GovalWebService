<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInicio))
        Me.btnRegistrarFactura = New System.Windows.Forms.Button()
        Me.btnRegistrarTiquete = New System.Windows.Forms.Button()
        Me.btnRegistrarNotaDebito = New System.Windows.Forms.Button()
        Me.btnRegistrarNotaCredito = New System.Windows.Forms.Button()
        Me.btnGenerarToken = New System.Windows.Forms.Button()
        Me.btnValidarCertificado = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPOSTHacienda = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtArchivoEnvio = New System.Windows.Forms.TextBox()
        Me.btnExaminarEnvio = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClaveEnvio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmisorIdentificacionEnvio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmisorTipoEnvio = New System.Windows.Forms.TextBox()
        Me.txtReceptorTipoEnvio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReceptorIdentificacionEnvio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGETHacienda = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtClaveRecepcion = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnEnviarRespuesta = New System.Windows.Forms.Button()
        Me.rb07 = New System.Windows.Forms.RadioButton()
        Me.rb06 = New System.Windows.Forms.RadioButton()
        Me.rb05 = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtXMLProveedor = New System.Windows.Forms.TextBox()
        Me.btnExaminarXMLProveedor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtRutaAlmacenamiento = New System.Windows.Forms.TextBox()
        Me.btnRutaAlmacenamiento = New System.Windows.Forms.Button()
        Me.btnUrlHacienda = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rbAmbienteDesarrollo = New System.Windows.Forms.RadioButton()
        Me.rbAmbienteProduccion = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCertificado = New System.Windows.Forms.TextBox()
        Me.btnRutaCertificado = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCertificadoPIN = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtClaveHacienda = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtUsuarioHacienda = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRegistrarFactura
        '
        Me.btnRegistrarFactura.Location = New System.Drawing.Point(25, 24)
        Me.btnRegistrarFactura.Name = "btnRegistrarFactura"
        Me.btnRegistrarFactura.Size = New System.Drawing.Size(158, 48)
        Me.btnRegistrarFactura.TabIndex = 0
        Me.btnRegistrarFactura.Text = "Registrar Factura"
        Me.btnRegistrarFactura.UseVisualStyleBackColor = True
        '
        'btnRegistrarTiquete
        '
        Me.btnRegistrarTiquete.Location = New System.Drawing.Point(25, 78)
        Me.btnRegistrarTiquete.Name = "btnRegistrarTiquete"
        Me.btnRegistrarTiquete.Size = New System.Drawing.Size(158, 48)
        Me.btnRegistrarTiquete.TabIndex = 1
        Me.btnRegistrarTiquete.Text = "Registrar Tiquete"
        Me.btnRegistrarTiquete.UseVisualStyleBackColor = True
        '
        'btnRegistrarNotaDebito
        '
        Me.btnRegistrarNotaDebito.Location = New System.Drawing.Point(25, 132)
        Me.btnRegistrarNotaDebito.Name = "btnRegistrarNotaDebito"
        Me.btnRegistrarNotaDebito.Size = New System.Drawing.Size(158, 48)
        Me.btnRegistrarNotaDebito.TabIndex = 2
        Me.btnRegistrarNotaDebito.Text = "Registrar Nota Debito (+)"
        Me.btnRegistrarNotaDebito.UseVisualStyleBackColor = True
        '
        'btnRegistrarNotaCredito
        '
        Me.btnRegistrarNotaCredito.Location = New System.Drawing.Point(25, 186)
        Me.btnRegistrarNotaCredito.Name = "btnRegistrarNotaCredito"
        Me.btnRegistrarNotaCredito.Size = New System.Drawing.Size(158, 48)
        Me.btnRegistrarNotaCredito.TabIndex = 3
        Me.btnRegistrarNotaCredito.Text = "Registrar Nota Crédito (-)"
        Me.btnRegistrarNotaCredito.UseVisualStyleBackColor = True
        '
        'btnGenerarToken
        '
        Me.btnGenerarToken.Location = New System.Drawing.Point(25, 25)
        Me.btnGenerarToken.Name = "btnGenerarToken"
        Me.btnGenerarToken.Size = New System.Drawing.Size(158, 48)
        Me.btnGenerarToken.TabIndex = 4
        Me.btnGenerarToken.Text = "Generar Token"
        Me.btnGenerarToken.UseVisualStyleBackColor = True
        '
        'btnValidarCertificado
        '
        Me.btnValidarCertificado.Location = New System.Drawing.Point(25, 80)
        Me.btnValidarCertificado.Name = "btnValidarCertificado"
        Me.btnValidarCertificado.Size = New System.Drawing.Size(158, 48)
        Me.btnValidarCertificado.TabIndex = 5
        Me.btnValidarCertificado.Text = "Validar Certificado"
        Me.btnValidarCertificado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGenerarToken)
        Me.GroupBox1.Controls.Add(Me.btnValidarCertificado)
        Me.GroupBox1.Location = New System.Drawing.Point(271, 287)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 141)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Validaciones Generales"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRegistrarFactura)
        Me.GroupBox2.Controls.Add(Me.btnRegistrarTiquete)
        Me.GroupBox2.Controls.Add(Me.btnRegistrarNotaDebito)
        Me.GroupBox2.Controls.Add(Me.btnRegistrarNotaCredito)
        Me.GroupBox2.Location = New System.Drawing.Point(271, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 252)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generar Documentos"
        '
        'btnPOSTHacienda
        '
        Me.btnPOSTHacienda.Location = New System.Drawing.Point(252, 244)
        Me.btnPOSTHacienda.Name = "btnPOSTHacienda"
        Me.btnPOSTHacienda.Size = New System.Drawing.Size(121, 48)
        Me.btnPOSTHacienda.TabIndex = 6
        Me.btnPOSTHacienda.Text = "Enviar XML"
        Me.btnPOSTHacienda.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtArchivoEnvio
        '
        Me.txtArchivoEnvio.Location = New System.Drawing.Point(159, 184)
        Me.txtArchivoEnvio.Name = "txtArchivoEnvio"
        Me.txtArchivoEnvio.Size = New System.Drawing.Size(194, 20)
        Me.txtArchivoEnvio.TabIndex = 7
        '
        'btnExaminarEnvio
        '
        Me.btnExaminarEnvio.Location = New System.Drawing.Point(359, 178)
        Me.btnExaminarEnvio.Name = "btnExaminarEnvio"
        Me.btnExaminarEnvio.Size = New System.Drawing.Size(107, 31)
        Me.btnExaminarEnvio.TabIndex = 8
        Me.btnExaminarEnvio.Text = "Examinar"
        Me.btnExaminarEnvio.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(156, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Clave:"
        '
        'txtClaveEnvio
        '
        Me.txtClaveEnvio.Location = New System.Drawing.Point(159, 41)
        Me.txtClaveEnvio.MaxLength = 50
        Me.txtClaveEnvio.Name = "txtClaveEnvio"
        Me.txtClaveEnvio.Size = New System.Drawing.Size(339, 20)
        Me.txtClaveEnvio.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Emisor Identificación:"
        '
        'txtEmisorIdentificacionEnvio
        '
        Me.txtEmisorIdentificacionEnvio.Location = New System.Drawing.Point(159, 86)
        Me.txtEmisorIdentificacionEnvio.Name = "txtEmisorIdentificacionEnvio"
        Me.txtEmisorIdentificacionEnvio.Size = New System.Drawing.Size(104, 20)
        Me.txtEmisorIdentificacionEnvio.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Emisor Tipo:"
        '
        'txtEmisorTipoEnvio
        '
        Me.txtEmisorTipoEnvio.Location = New System.Drawing.Point(286, 86)
        Me.txtEmisorTipoEnvio.Name = "txtEmisorTipoEnvio"
        Me.txtEmisorTipoEnvio.Size = New System.Drawing.Size(104, 20)
        Me.txtEmisorTipoEnvio.TabIndex = 14
        Me.txtEmisorTipoEnvio.Text = "02"
        '
        'txtReceptorTipoEnvio
        '
        Me.txtReceptorTipoEnvio.Location = New System.Drawing.Point(286, 137)
        Me.txtReceptorTipoEnvio.Name = "txtReceptorTipoEnvio"
        Me.txtReceptorTipoEnvio.Size = New System.Drawing.Size(104, 20)
        Me.txtReceptorTipoEnvio.TabIndex = 18
        Me.txtReceptorTipoEnvio.Text = "01"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(286, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Receptor Tipo:"
        '
        'txtReceptorIdentificacionEnvio
        '
        Me.txtReceptorIdentificacionEnvio.Location = New System.Drawing.Point(159, 137)
        Me.txtReceptorIdentificacionEnvio.Name = "txtReceptorIdentificacionEnvio"
        Me.txtReceptorIdentificacionEnvio.Size = New System.Drawing.Size(104, 20)
        Me.txtReceptorIdentificacionEnvio.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Receptor Identificación:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Archivo XML a enviar:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(505, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(646, 399)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.btnPOSTHacienda)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtReceptorTipoEnvio)
        Me.TabPage1.Controls.Add(Me.txtArchivoEnvio)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btnExaminarEnvio)
        Me.TabPage1.Controls.Add(Me.txtReceptorIdentificacionEnvio)
        Me.TabPage1.Controls.Add(Me.txtClaveEnvio)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtEmisorTipoEnvio)
        Me.TabPage1.Controls.Add(Me.txtEmisorIdentificacionEnvio)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(638, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ENVIO DE DOCUMENTOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(379, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "* UTILICE PARA ENVIAR UN XML FIRMADOR AL SERVICIO DE HACIENDA"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.btnGETHacienda)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtClaveRecepcion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(638, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "OBTENER ACUSE DE RECIBO"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(89, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(474, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "* UTILICE ESTA OPCIÓN PARA OBTENER EL ACUSE DE RECIBO DE HACIENDA"
        '
        'btnGETHacienda
        '
        Me.btnGETHacienda.Location = New System.Drawing.Point(254, 126)
        Me.btnGETHacienda.Name = "btnGETHacienda"
        Me.btnGETHacienda.Size = New System.Drawing.Size(121, 48)
        Me.btnGETHacienda.TabIndex = 21
        Me.btnGETHacienda.Text = "Recibir XML"
        Me.btnGETHacienda.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(146, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Clave:"
        '
        'txtClaveRecepcion
        '
        Me.txtClaveRecepcion.Location = New System.Drawing.Point(149, 64)
        Me.txtClaveRecepcion.MaxLength = 50
        Me.txtClaveRecepcion.Name = "txtClaveRecepcion"
        Me.txtClaveRecepcion.Size = New System.Drawing.Size(339, 20)
        Me.txtClaveRecepcion.TabIndex = 24
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.btnEnviarRespuesta)
        Me.TabPage3.Controls.Add(Me.rb07)
        Me.TabPage3.Controls.Add(Me.rb06)
        Me.TabPage3.Controls.Add(Me.rb05)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.txtXMLProveedor)
        Me.TabPage3.Controls.Add(Me.btnExaminarXMLProveedor)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(638, 373)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "RECEPCION DE DOCUMENTOS DE PROVEEDORES"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "3- Resultado"
        '
        'btnEnviarRespuesta
        '
        Me.btnEnviarRespuesta.Location = New System.Drawing.Point(240, 174)
        Me.btnEnviarRespuesta.Name = "btnEnviarRespuesta"
        Me.btnEnviarRespuesta.Size = New System.Drawing.Size(158, 48)
        Me.btnEnviarRespuesta.TabIndex = 38
        Me.btnEnviarRespuesta.Text = "3 - Enviar Respuesta Hacienda"
        Me.btnEnviarRespuesta.UseVisualStyleBackColor = True
        '
        'rb07
        '
        Me.rb07.AutoSize = True
        Me.rb07.Location = New System.Drawing.Point(142, 139)
        Me.rb07.Name = "rb07"
        Me.rb07.Size = New System.Drawing.Size(279, 17)
        Me.rb07.TabIndex = 37
        Me.rb07.Text = "Confirmación de rechazo del comprobante electrónico"
        Me.rb07.UseVisualStyleBackColor = True
        '
        'rb06
        '
        Me.rb06.AutoSize = True
        Me.rb06.Location = New System.Drawing.Point(142, 116)
        Me.rb06.Name = "rb06"
        Me.rb06.Size = New System.Drawing.Size(328, 17)
        Me.rb06.TabIndex = 36
        Me.rb06.Text = "Confirmación de aceptación parcial del comprobante electrónico"
        Me.rb06.UseVisualStyleBackColor = True
        '
        'rb05
        '
        Me.rb05.AutoSize = True
        Me.rb05.Checked = True
        Me.rb05.Location = New System.Drawing.Point(142, 93)
        Me.rb05.Name = "rb05"
        Me.rb05.Size = New System.Drawing.Size(294, 17)
        Me.rb05.TabIndex = 35
        Me.rb05.TabStop = True
        Me.rb05.Text = "Confirmación de aceptación del comprobante electrónico"
        Me.rb05.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(304, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "2- Seleccione una respuesta al XML recibido por su proveedor:"
        '
        'txtXMLProveedor
        '
        Me.txtXMLProveedor.Location = New System.Drawing.Point(259, 28)
        Me.txtXMLProveedor.Name = "txtXMLProveedor"
        Me.txtXMLProveedor.Size = New System.Drawing.Size(232, 20)
        Me.txtXMLProveedor.TabIndex = 31
        '
        'btnExaminarXMLProveedor
        '
        Me.btnExaminarXMLProveedor.Location = New System.Drawing.Point(497, 22)
        Me.btnExaminarXMLProveedor.Name = "btnExaminarXMLProveedor"
        Me.btnExaminarXMLProveedor.Size = New System.Drawing.Size(94, 31)
        Me.btnExaminarXMLProveedor.TabIndex = 32
        Me.btnExaminarXMLProveedor.Text = "Examinar"
        Me.btnExaminarXMLProveedor.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(228, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "1- Seleccione el XML recibido de su proveedor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(49, 334)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(542, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "* UTILICE SOMO PARA EMITIR SU RESPUESTA AL XML DE UN PROVEEDOR AL SERVICIO DE HAC" & _
    "IENDA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtRutaAlmacenamiento)
        Me.GroupBox3.Controls.Add(Me.btnRutaAlmacenamiento)
        Me.GroupBox3.Controls.Add(Me.btnUrlHacienda)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.rbAmbienteDesarrollo)
        Me.GroupBox3.Controls.Add(Me.rbAmbienteProduccion)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtCertificado)
        Me.GroupBox3.Controls.Add(Me.btnRutaCertificado)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtCertificadoPIN)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtClaveHacienda)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtUsuarioHacienda)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(251, 399)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos Globales"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 318)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(134, 13)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Ruta Almacenamiento Xml:"
        '
        'txtRutaAlmacenamiento
        '
        Me.txtRutaAlmacenamiento.Location = New System.Drawing.Point(15, 344)
        Me.txtRutaAlmacenamiento.Name = "txtRutaAlmacenamiento"
        Me.txtRutaAlmacenamiento.Size = New System.Drawing.Size(117, 20)
        Me.txtRutaAlmacenamiento.TabIndex = 27
        '
        'btnRutaAlmacenamiento
        '
        Me.btnRutaAlmacenamiento.Location = New System.Drawing.Point(138, 338)
        Me.btnRutaAlmacenamiento.Name = "btnRutaAlmacenamiento"
        Me.btnRutaAlmacenamiento.Size = New System.Drawing.Size(94, 31)
        Me.btnRutaAlmacenamiento.TabIndex = 28
        Me.btnRutaAlmacenamiento.Text = "Examinar"
        Me.btnRutaAlmacenamiento.UseVisualStyleBackColor = True
        '
        'btnUrlHacienda
        '
        Me.btnUrlHacienda.Location = New System.Drawing.Point(66, 275)
        Me.btnUrlHacienda.Name = "btnUrlHacienda"
        Me.btnUrlHacienda.Size = New System.Drawing.Size(107, 31)
        Me.btnUrlHacienda.TabIndex = 26
        Me.btnUrlHacienda.Text = "Ver Url Hacienda"
        Me.btnUrlHacienda.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 219)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Tipo de Ambiente:"
        '
        'rbAmbienteDesarrollo
        '
        Me.rbAmbienteDesarrollo.AutoSize = True
        Me.rbAmbienteDesarrollo.Checked = True
        Me.rbAmbienteDesarrollo.Location = New System.Drawing.Point(125, 244)
        Me.rbAmbienteDesarrollo.Name = "rbAmbienteDesarrollo"
        Me.rbAmbienteDesarrollo.Size = New System.Drawing.Size(72, 17)
        Me.rbAmbienteDesarrollo.TabIndex = 24
        Me.rbAmbienteDesarrollo.TabStop = True
        Me.rbAmbienteDesarrollo.Text = "Desarrollo"
        Me.rbAmbienteDesarrollo.UseVisualStyleBackColor = True
        '
        'rbAmbienteProduccion
        '
        Me.rbAmbienteProduccion.AutoSize = True
        Me.rbAmbienteProduccion.Location = New System.Drawing.Point(21, 244)
        Me.rbAmbienteProduccion.Name = "rbAmbienteProduccion"
        Me.rbAmbienteProduccion.Size = New System.Drawing.Size(79, 17)
        Me.rbAmbienteProduccion.TabIndex = 23
        Me.rbAmbienteProduccion.Text = "Producción"
        Me.rbAmbienteProduccion.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 166)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Llave criptográfica:"
        '
        'txtCertificado
        '
        Me.txtCertificado.Location = New System.Drawing.Point(17, 188)
        Me.txtCertificado.Name = "txtCertificado"
        Me.txtCertificado.Size = New System.Drawing.Size(102, 20)
        Me.txtCertificado.TabIndex = 20
        '
        'btnRutaCertificado
        '
        Me.btnRutaCertificado.Location = New System.Drawing.Point(125, 182)
        Me.btnRutaCertificado.Name = "btnRutaCertificado"
        Me.btnRutaCertificado.Size = New System.Drawing.Size(107, 31)
        Me.btnRutaCertificado.TabIndex = 21
        Me.btnRutaCertificado.Text = "Examinar"
        Me.btnRutaCertificado.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 13)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "PIN llave criptográfica:"
        '
        'txtCertificadoPIN
        '
        Me.txtCertificadoPIN.Location = New System.Drawing.Point(15, 134)
        Me.txtCertificadoPIN.MaxLength = 4
        Me.txtCertificadoPIN.Name = "txtCertificadoPIN"
        Me.txtCertificadoPIN.Size = New System.Drawing.Size(217, 20)
        Me.txtCertificadoPIN.TabIndex = 15
        Me.txtCertificadoPIN.UseSystemPasswordChar = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Clave Hacienda:"
        '
        'txtClaveHacienda
        '
        Me.txtClaveHacienda.Location = New System.Drawing.Point(15, 86)
        Me.txtClaveHacienda.MaxLength = 100
        Me.txtClaveHacienda.Name = "txtClaveHacienda"
        Me.txtClaveHacienda.Size = New System.Drawing.Size(217, 20)
        Me.txtClaveHacienda.TabIndex = 13
        Me.txtClaveHacienda.UseSystemPasswordChar = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Usuario Hacienda:"
        '
        'txtUsuarioHacienda
        '
        Me.txtUsuarioHacienda.Location = New System.Drawing.Point(15, 39)
        Me.txtUsuarioHacienda.MaxLength = 200
        Me.txtUsuarioHacienda.Name = "txtUsuarioHacienda"
        Me.txtUsuarioHacienda.Size = New System.Drawing.Size(217, 20)
        Me.txtUsuarioHacienda.TabIndex = 11
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1163, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 444)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(259, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Todos los derechos reservados 2018 Versión: 2.0.0.0"
        '
        'FrmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 466)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FE - BitOne"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRegistrarFactura As System.Windows.Forms.Button
    Friend WithEvents btnRegistrarTiquete As System.Windows.Forms.Button
    Friend WithEvents btnRegistrarNotaDebito As System.Windows.Forms.Button
    Friend WithEvents btnRegistrarNotaCredito As System.Windows.Forms.Button
    Friend WithEvents btnGenerarToken As System.Windows.Forms.Button
    Friend WithEvents btnValidarCertificado As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPOSTHacienda As System.Windows.Forms.Button
    Friend WithEvents btnExaminarEnvio As System.Windows.Forms.Button
    Friend WithEvents txtArchivoEnvio As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtClaveEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmisorIdentificacionEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmisorTipoEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReceptorTipoEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReceptorIdentificacionEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGETHacienda As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtClaveRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioHacienda As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtClaveHacienda As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCertificadoPIN As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCertificado As System.Windows.Forms.TextBox
    Friend WithEvents btnRutaCertificado As System.Windows.Forms.Button
    Friend WithEvents rbAmbienteDesarrollo As System.Windows.Forms.RadioButton
    Friend WithEvents rbAmbienteProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnUrlHacienda As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtRutaAlmacenamiento As System.Windows.Forms.TextBox
    Friend WithEvents btnRutaAlmacenamiento As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtXMLProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminarXMLProveedor As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rb07 As System.Windows.Forms.RadioButton
    Friend WithEvents rb06 As System.Windows.Forms.RadioButton
    Friend WithEvents rb05 As System.Windows.Forms.RadioButton
    Friend WithEvents btnEnviarRespuesta As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
