<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_ajedrez
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_ajedrez))
        Me.panel_ajedrez = New System.Windows.Forms.Panel()
        Me.pb_pb_alfil = New System.Windows.Forms.PictureBox()
        Me.pb_pb_caballo = New System.Windows.Forms.PictureBox()
        Me.pb_pb_torre = New System.Windows.Forms.PictureBox()
        Me.pb_pb_reina = New System.Windows.Forms.PictureBox()
        Me.pb_pn_alfil = New System.Windows.Forms.PictureBox()
        Me.pb_pn_caballo = New System.Windows.Forms.PictureBox()
        Me.pb_pn_torre = New System.Windows.Forms.PictureBox()
        Me.pb_pn_reina = New System.Windows.Forms.PictureBox()
        Me.ms_turno_color = New System.Windows.Forms.Panel()
        Me.lbl_turno = New System.Windows.Forms.Label()
        Me.lbl_contador_blancas = New System.Windows.Forms.Label()
        Me.lbl_contador_negras = New System.Windows.Forms.Label()
        Me.ms_principal = New System.Windows.Forms.MenuStrip()
        Me.ms_archivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_archivo_nuevapartida = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_archivo_salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite_10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_nolimite = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel_ajedrez.SuspendLayout()
        CType(Me.pb_pb_alfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pb_caballo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pb_torre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pb_reina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pn_alfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pn_caballo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pn_torre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pn_reina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ms_turno_color.SuspendLayout()
        Me.ms_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_ajedrez
        '
        Me.panel_ajedrez.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.panel_ajedrez.Controls.Add(Me.pb_pb_alfil)
        Me.panel_ajedrez.Controls.Add(Me.pb_pb_caballo)
        Me.panel_ajedrez.Controls.Add(Me.pb_pb_torre)
        Me.panel_ajedrez.Controls.Add(Me.pb_pb_reina)
        Me.panel_ajedrez.Controls.Add(Me.pb_pn_alfil)
        Me.panel_ajedrez.Controls.Add(Me.pb_pn_caballo)
        Me.panel_ajedrez.Controls.Add(Me.pb_pn_torre)
        Me.panel_ajedrez.Controls.Add(Me.pb_pn_reina)
        Me.panel_ajedrez.Controls.Add(Me.ms_turno_color)
        Me.panel_ajedrez.Controls.Add(Me.lbl_contador_blancas)
        Me.panel_ajedrez.Controls.Add(Me.lbl_contador_negras)
        Me.panel_ajedrez.Location = New System.Drawing.Point(601, 25)
        Me.panel_ajedrez.Name = "panel_ajedrez"
        Me.panel_ajedrez.Size = New System.Drawing.Size(150, 600)
        Me.panel_ajedrez.TabIndex = 0
        '
        'pb_pb_alfil
        '

        Me.pb_pb_alfil.Location = New System.Drawing.Point(92, 539)
        Me.pb_pb_alfil.Name = "pb_pb_alfil"
        Me.pb_pb_alfil.Size = New System.Drawing.Size(45, 45)
        Me.pb_pb_alfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pb_alfil.TabIndex = 10
        Me.pb_pb_alfil.TabStop = False
        Me.pb_pb_alfil.Tag = "24"
        Me.pb_pb_alfil.Visible = False
        '
        'pb_pb_caballo
        '

        Me.pb_pb_caballo.Location = New System.Drawing.Point(12, 539)
        Me.pb_pb_caballo.Name = "pb_pb_caballo"
        Me.pb_pb_caballo.Size = New System.Drawing.Size(45, 45)
        Me.pb_pb_caballo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pb_caballo.TabIndex = 9
        Me.pb_pb_caballo.TabStop = False
        Me.pb_pb_caballo.Tag = "23"
        Me.pb_pb_caballo.Visible = False
        '
        'pb_pb_torre
        '

        Me.pb_pb_torre.Location = New System.Drawing.Point(92, 466)
        Me.pb_pb_torre.Name = "pb_pb_torre"
        Me.pb_pb_torre.Size = New System.Drawing.Size(45, 45)
        Me.pb_pb_torre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pb_torre.TabIndex = 8
        Me.pb_pb_torre.TabStop = False
        Me.pb_pb_torre.Tag = "22"
        Me.pb_pb_torre.Visible = False
        '
        'pb_pb_reina
        '

        Me.pb_pb_reina.Location = New System.Drawing.Point(12, 466)
        Me.pb_pb_reina.Name = "pb_pb_reina"
        Me.pb_pb_reina.Size = New System.Drawing.Size(45, 45)
        Me.pb_pb_reina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pb_reina.TabIndex = 7
        Me.pb_pb_reina.TabStop = False
        Me.pb_pb_reina.Tag = "26"
        Me.pb_pb_reina.Visible = False
        '
        'pb_pn_alfil
        '

        Me.pb_pn_alfil.Location = New System.Drawing.Point(92, 88)
        Me.pb_pn_alfil.Name = "pb_pn_alfil"
        Me.pb_pn_alfil.Size = New System.Drawing.Size(45, 45)
        Me.pb_pn_alfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_pn_alfil.TabIndex = 6
        Me.pb_pn_alfil.TabStop = False
        Me.pb_pn_alfil.Tag = "14"
        Me.pb_pn_alfil.Visible = False
        '
        'pb_pn_caballo
        '

        Me.pb_pn_caballo.Location = New System.Drawing.Point(12, 88)
        Me.pb_pn_caballo.Name = "pb_pn_caballo"
        Me.pb_pn_caballo.Size = New System.Drawing.Size(45, 45)
        Me.pb_pn_caballo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pn_caballo.TabIndex = 5
        Me.pb_pn_caballo.TabStop = False
        Me.pb_pn_caballo.Tag = "13"
        Me.pb_pn_caballo.Visible = False
        '
        'pb_pn_torre
        '

        Me.pb_pn_torre.Location = New System.Drawing.Point(93, 16)
        Me.pb_pn_torre.Name = "pb_pn_torre"
        Me.pb_pn_torre.Size = New System.Drawing.Size(45, 45)
        Me.pb_pn_torre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pn_torre.TabIndex = 4
        Me.pb_pn_torre.TabStop = False
        Me.pb_pn_torre.Tag = "12"
        Me.pb_pn_torre.Visible = False
        '
        'pb_pn_reina
        '

        Me.pb_pn_reina.Location = New System.Drawing.Point(12, 15)
        Me.pb_pn_reina.Name = "pb_pn_reina"
        Me.pb_pn_reina.Size = New System.Drawing.Size(45, 45)
        Me.pb_pn_reina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pn_reina.TabIndex = 3
        Me.pb_pn_reina.TabStop = False
        Me.pb_pn_reina.Tag = "16"
        Me.pb_pn_reina.Visible = False
        '
        'ms_turno_color
        '
        Me.ms_turno_color.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ms_turno_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ms_turno_color.Controls.Add(Me.lbl_turno)
        Me.ms_turno_color.Location = New System.Drawing.Point(13, 241)
        Me.ms_turno_color.Name = "ms_turno_color"
        Me.ms_turno_color.Size = New System.Drawing.Size(124, 120)
        Me.ms_turno_color.TabIndex = 2
        '
        'lbl_turno
        '
        Me.lbl_turno.Location = New System.Drawing.Point(0, 0)
        Me.lbl_turno.Name = "lbl_turno"
        Me.lbl_turno.Size = New System.Drawing.Size(100, 23)
        Me.lbl_turno.TabIndex = 0
        '
        'lbl_contador_blancas
        '
        Me.lbl_contador_blancas.BackColor = System.Drawing.Color.Gainsboro
        Me.lbl_contador_blancas.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_contador_blancas.ForeColor = System.Drawing.Color.DarkGray
        Me.lbl_contador_blancas.Location = New System.Drawing.Point(13, 383)
        Me.lbl_contador_blancas.Name = "lbl_contador_blancas"
        Me.lbl_contador_blancas.Size = New System.Drawing.Size(124, 52)
        Me.lbl_contador_blancas.TabIndex = 1
        Me.lbl_contador_blancas.Text = "00:00"
        Me.lbl_contador_blancas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_contador_negras
        '
        Me.lbl_contador_negras.BackColor = System.Drawing.Color.Gainsboro
        Me.lbl_contador_negras.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contador_negras.ForeColor = System.Drawing.Color.DarkGray
        Me.lbl_contador_negras.Location = New System.Drawing.Point(12, 167)
        Me.lbl_contador_negras.Name = "lbl_contador_negras"
        Me.lbl_contador_negras.Size = New System.Drawing.Size(125, 52)
        Me.lbl_contador_negras.TabIndex = 0
        Me.lbl_contador_negras.Text = "00:00"
        Me.lbl_contador_negras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ms_principal
        '
        Me.ms_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo, Me.ms_temporizador})
        Me.ms_principal.Location = New System.Drawing.Point(0, 0)
        Me.ms_principal.Name = "ms_principal"
        Me.ms_principal.Size = New System.Drawing.Size(751, 24)
        Me.ms_principal.TabIndex = 1
        Me.ms_principal.Text = "MenuStrip1"
        '
        'ms_archivo
        '
        Me.ms_archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo_nuevapartida, Me.ms_archivo_salir})
        Me.ms_archivo.Name = "ms_archivo"
        Me.ms_archivo.Size = New System.Drawing.Size(60, 20)
        Me.ms_archivo.Text = "Archivo"
        '
        'ms_archivo_nuevapartida
        '
        Me.ms_archivo_nuevapartida.Name = "ms_archivo_nuevapartida"
        Me.ms_archivo_nuevapartida.Size = New System.Drawing.Size(148, 22)
        Me.ms_archivo_nuevapartida.Text = "Nueva partida"
        '
        'ms_archivo_salir
        '
        Me.ms_archivo_salir.Name = "ms_archivo_salir"
        Me.ms_archivo_salir.Size = New System.Drawing.Size(148, 22)
        Me.ms_archivo_salir.Text = "Salir"
        '
        'ms_temporizador
        '
        Me.ms_temporizador.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_temporizador_limite, Me.ms_temporizador_nolimite})
        Me.ms_temporizador.Name = "ms_temporizador"
        Me.ms_temporizador.Size = New System.Drawing.Size(92, 20)
        Me.ms_temporizador.Text = "Temporizador"
        '
        'ms_temporizador_limite
        '
        Me.ms_temporizador_limite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_temporizador_limite_5, Me.ms_temporizador_limite_10})
        Me.ms_temporizador_limite.Name = "ms_temporizador_limite"
        Me.ms_temporizador_limite.Size = New System.Drawing.Size(123, 22)
        Me.ms_temporizador_limite.Text = "Límite"
        '
        'ms_temporizador_limite_5
        '
        Me.ms_temporizador_limite_5.Name = "ms_temporizador_limite_5"
        Me.ms_temporizador_limite_5.Size = New System.Drawing.Size(113, 22)
        Me.ms_temporizador_limite_5.Text = "5 min."
        '
        'ms_temporizador_limite_10
        '
        Me.ms_temporizador_limite_10.Name = "ms_temporizador_limite_10"
        Me.ms_temporizador_limite_10.Size = New System.Drawing.Size(113, 22)
        Me.ms_temporizador_limite_10.Text = "10 min."
        '
        'ms_temporizador_nolimite
        '
        Me.ms_temporizador_nolimite.Name = "ms_temporizador_nolimite"
        Me.ms_temporizador_nolimite.Size = New System.Drawing.Size(123, 22)
        Me.ms_temporizador_nolimite.Text = "Sin límite"
        '
        'form_ajedrez
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(751, 625)
        Me.Controls.Add(Me.panel_ajedrez)
        Me.Controls.Add(Me.ms_principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.ms_principal
        Me.Name = "form_ajedrez"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajedrez"
        Me.panel_ajedrez.ResumeLayout(False)
        CType(Me.pb_pb_alfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pb_caballo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pb_torre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pb_reina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pn_alfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pn_caballo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pn_torre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pn_reina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ms_turno_color.ResumeLayout(False)
        Me.ms_principal.ResumeLayout(False)
        Me.ms_principal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panel_ajedrez As Panel
    Friend WithEvents ms_principal As MenuStrip
    Friend WithEvents ms_archivo As ToolStripMenuItem
    Friend WithEvents ms_archivo_nuevapartida As ToolStripMenuItem
    Friend WithEvents ms_archivo_salir As ToolStripMenuItem
    Friend WithEvents lbl_contador_negras As Label
    Friend WithEvents ms_temporizador As ToolStripMenuItem
    Friend WithEvents ms_temporizador_limite As ToolStripMenuItem
    Friend WithEvents ms_temporizador_limite_5 As ToolStripMenuItem
    Friend WithEvents ms_temporizador_limite_10 As ToolStripMenuItem
    Friend WithEvents ms_temporizador_nolimite As ToolStripMenuItem
    Friend WithEvents lbl_contador_blancas As Label
    Friend WithEvents ms_turno_color As Panel
    Friend WithEvents lbl_turno As Label
    Friend WithEvents pb_pb_alfil As PictureBox
    Friend WithEvents pb_pb_caballo As PictureBox
    Friend WithEvents pb_pb_torre As PictureBox
    Friend WithEvents pb_pb_reina As PictureBox
    Friend WithEvents pb_pn_alfil As PictureBox
    Friend WithEvents pb_pn_caballo As PictureBox
    Friend WithEvents pb_pn_torre As PictureBox
    Friend WithEvents pb_pn_reina As PictureBox
End Class
