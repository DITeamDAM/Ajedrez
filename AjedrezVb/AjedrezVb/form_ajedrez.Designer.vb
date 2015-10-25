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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_ajedrez))
        Me.panel_ajedrez = New System.Windows.Forms.Panel()
        Me.pb_c24 = New System.Windows.Forms.PictureBox()
        Me.pb_c23 = New System.Windows.Forms.PictureBox()
        Me.pb_c22 = New System.Windows.Forms.PictureBox()
        Me.pb_c26 = New System.Windows.Forms.PictureBox()
        Me.pb_c14 = New System.Windows.Forms.PictureBox()
        Me.pb_c13 = New System.Windows.Forms.PictureBox()
        Me.pb_c12 = New System.Windows.Forms.PictureBox()
        Me.pb_c16 = New System.Windows.Forms.PictureBox()
        Me.ms_turno_color = New System.Windows.Forms.Panel()
        Me.panel_pause = New System.Windows.Forms.PictureBox()
        Me.lbl_turno = New System.Windows.Forms.Label()
        Me.lbl_contador_blancas = New System.Windows.Forms.Label()
        Me.lbl_contador_negras = New System.Windows.Forms.Label()
        Me.ms_principal = New System.Windows.Forms.MenuStrip()
        Me.ms_archivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_archivo_nuevapartida = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ms_archivo_salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_temporizador_limite_10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ms_temporizador_nolimite = New System.Windows.Forms.ToolStripMenuItem()
        Me.timer_blancas = New System.Windows.Forms.Timer(Me.components)
        Me.timer_negras = New System.Windows.Forms.Timer(Me.components)
        Me.panel_ajedrez.SuspendLayout()
        CType(Me.pb_c24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_c16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ms_turno_color.SuspendLayout()
        CType(Me.panel_pause, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ms_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_ajedrez
        '
        Me.panel_ajedrez.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.panel_ajedrez.Controls.Add(Me.pb_c24)
        Me.panel_ajedrez.Controls.Add(Me.pb_c23)
        Me.panel_ajedrez.Controls.Add(Me.pb_c22)
        Me.panel_ajedrez.Controls.Add(Me.pb_c26)
        Me.panel_ajedrez.Controls.Add(Me.pb_c14)
        Me.panel_ajedrez.Controls.Add(Me.pb_c13)
        Me.panel_ajedrez.Controls.Add(Me.pb_c12)
        Me.panel_ajedrez.Controls.Add(Me.pb_c16)
        Me.panel_ajedrez.Controls.Add(Me.ms_turno_color)
        Me.panel_ajedrez.Controls.Add(Me.lbl_contador_blancas)
        Me.panel_ajedrez.Controls.Add(Me.lbl_contador_negras)
        resources.ApplyResources(Me.panel_ajedrez, "panel_ajedrez")
        Me.panel_ajedrez.Name = "panel_ajedrez"
        '
        'pb_c24
        '
        resources.ApplyResources(Me.pb_c24, "pb_c24")
        Me.pb_c24.Name = "pb_c24"
        Me.pb_c24.TabStop = False
        Me.pb_c24.Tag = "24"
        '
        'pb_c23
        '
        resources.ApplyResources(Me.pb_c23, "pb_c23")
        Me.pb_c23.Name = "pb_c23"
        Me.pb_c23.TabStop = False
        Me.pb_c23.Tag = "23"
        '
        'pb_c22
        '
        resources.ApplyResources(Me.pb_c22, "pb_c22")
        Me.pb_c22.Name = "pb_c22"
        Me.pb_c22.TabStop = False
        Me.pb_c22.Tag = "22"
        '
        'pb_c26
        '
        resources.ApplyResources(Me.pb_c26, "pb_c26")
        Me.pb_c26.Name = "pb_c26"
        Me.pb_c26.TabStop = False
        Me.pb_c26.Tag = "26"
        '
        'pb_c14
        '
        resources.ApplyResources(Me.pb_c14, "pb_c14")
        Me.pb_c14.Name = "pb_c14"
        Me.pb_c14.TabStop = False
        Me.pb_c14.Tag = "14"
        '
        'pb_c13
        '
        resources.ApplyResources(Me.pb_c13, "pb_c13")
        Me.pb_c13.Name = "pb_c13"
        Me.pb_c13.TabStop = False
        Me.pb_c13.Tag = "13"
        '
        'pb_c12
        '
        resources.ApplyResources(Me.pb_c12, "pb_c12")
        Me.pb_c12.Name = "pb_c12"
        Me.pb_c12.TabStop = False
        Me.pb_c12.Tag = "12"
        '
        'pb_c16
        '
        resources.ApplyResources(Me.pb_c16, "pb_c16")
        Me.pb_c16.Name = "pb_c16"
        Me.pb_c16.TabStop = False
        Me.pb_c16.Tag = "16"
        '
        'ms_turno_color
        '
        Me.ms_turno_color.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ms_turno_color.Controls.Add(Me.panel_pause)
        Me.ms_turno_color.Controls.Add(Me.lbl_turno)
        resources.ApplyResources(Me.ms_turno_color, "ms_turno_color")
        Me.ms_turno_color.Name = "ms_turno_color"
        '
        'panel_pause
        '
        resources.ApplyResources(Me.panel_pause, "panel_pause")
        Me.panel_pause.Name = "panel_pause"
        Me.panel_pause.TabStop = False
        '
        'lbl_turno
        '
        resources.ApplyResources(Me.lbl_turno, "lbl_turno")
        Me.lbl_turno.Name = "lbl_turno"
        '
        'lbl_contador_blancas
        '
        Me.lbl_contador_blancas.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        resources.ApplyResources(Me.lbl_contador_blancas, "lbl_contador_blancas")
        Me.lbl_contador_blancas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.lbl_contador_blancas.Name = "lbl_contador_blancas"
        '
        'lbl_contador_negras
        '
        Me.lbl_contador_negras.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        resources.ApplyResources(Me.lbl_contador_negras, "lbl_contador_negras")
        Me.lbl_contador_negras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.lbl_contador_negras.Name = "lbl_contador_negras"
        '
        'ms_principal
        '
        Me.ms_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo, Me.ms_temporizador})
        resources.ApplyResources(Me.ms_principal, "ms_principal")
        Me.ms_principal.Name = "ms_principal"
        '
        'ms_archivo
        '
        Me.ms_archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo_nuevapartida, Me.ToolStripMenuItem2, Me.ms_archivo_salir})
        Me.ms_archivo.Name = "ms_archivo"
        resources.ApplyResources(Me.ms_archivo, "ms_archivo")
        '
        'ms_archivo_nuevapartida
        '
        Me.ms_archivo_nuevapartida.Name = "ms_archivo_nuevapartida"
        resources.ApplyResources(Me.ms_archivo_nuevapartida, "ms_archivo_nuevapartida")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ms_archivo_salir
        '
        Me.ms_archivo_salir.Name = "ms_archivo_salir"
        resources.ApplyResources(Me.ms_archivo_salir, "ms_archivo_salir")
        '
        'ms_temporizador
        '
        Me.ms_temporizador.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_temporizador_limite, Me.ToolStripMenuItem1, Me.ms_temporizador_nolimite})
        Me.ms_temporizador.Name = "ms_temporizador"
        resources.ApplyResources(Me.ms_temporizador, "ms_temporizador")
        '
        'ms_temporizador_limite
        '
        Me.ms_temporizador_limite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_temporizador_limite_5, Me.ms_temporizador_limite_10})
        Me.ms_temporizador_limite.Name = "ms_temporizador_limite"
        resources.ApplyResources(Me.ms_temporizador_limite, "ms_temporizador_limite")
        '
        'ms_temporizador_limite_5
        '
        Me.ms_temporizador_limite_5.Name = "ms_temporizador_limite_5"
        resources.ApplyResources(Me.ms_temporizador_limite_5, "ms_temporizador_limite_5")
        '
        'ms_temporizador_limite_10
        '
        Me.ms_temporizador_limite_10.Name = "ms_temporizador_limite_10"
        resources.ApplyResources(Me.ms_temporizador_limite_10, "ms_temporizador_limite_10")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ms_temporizador_nolimite
        '
        Me.ms_temporizador_nolimite.Name = "ms_temporizador_nolimite"
        resources.ApplyResources(Me.ms_temporizador_nolimite, "ms_temporizador_nolimite")
        '
        'timer_blancas
        '
        Me.timer_blancas.Interval = 1000
        '
        'timer_negras
        '
        Me.timer_negras.Interval = 1000
        '
        'form_ajedrez
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.panel_ajedrez)
        Me.Controls.Add(Me.ms_principal)
        Me.MainMenuStrip = Me.ms_principal
        Me.MaximizeBox = False
        Me.Name = "form_ajedrez"
        Me.panel_ajedrez.ResumeLayout(False)
        CType(Me.pb_c24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_c16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ms_turno_color.ResumeLayout(False)
        CType(Me.panel_pause, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pb_c24 As PictureBox
    Friend WithEvents pb_c23 As PictureBox
    Friend WithEvents pb_c22 As PictureBox
    Friend WithEvents pb_c26 As PictureBox
    Friend WithEvents pb_c14 As PictureBox
    Friend WithEvents pb_c13 As PictureBox
    Friend WithEvents pb_c12 As PictureBox
    Friend WithEvents pb_c16 As PictureBox
    Friend WithEvents timer_blancas As Timer
    Friend WithEvents timer_negras As Timer
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents panel_pause As PictureBox
End Class
