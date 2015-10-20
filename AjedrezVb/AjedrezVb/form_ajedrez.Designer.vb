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
        Me.ms_principal = New System.Windows.Forms.MenuStrip()
        Me.ms_archivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_archivo_nuevapartida = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_archivo_salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_contador_negras = New System.Windows.Forms.Label()
        Me.ms_opciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_opciones_limite = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_opciones_limite_10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_opciones_limite_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms_opciones_nolimite = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel_ajedrez.SuspendLayout()
        Me.ms_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_ajedrez
        '
        Me.panel_ajedrez.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.panel_ajedrez.Controls.Add(Me.lbl_contador_negras)
        Me.panel_ajedrez.Location = New System.Drawing.Point(601, 25)
        Me.panel_ajedrez.Name = "panel_ajedrez"
        Me.panel_ajedrez.Size = New System.Drawing.Size(150, 600)
        Me.panel_ajedrez.TabIndex = 0
        '
        'ms_principal
        '
        Me.ms_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo, Me.ms_opciones})
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
        'lbl_contador_negras
        '
        Me.lbl_contador_negras.AutoSize = True
        Me.lbl_contador_negras.BackColor = System.Drawing.Color.Gainsboro
        Me.lbl_contador_negras.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contador_negras.ForeColor = System.Drawing.Color.DarkGray
        Me.lbl_contador_negras.Location = New System.Drawing.Point(12, 18)
        Me.lbl_contador_negras.Name = "lbl_contador_negras"
        Me.lbl_contador_negras.Size = New System.Drawing.Size(126, 57)
        Me.lbl_contador_negras.TabIndex = 0
        Me.lbl_contador_negras.Text = "00:00"
        '
        'ms_opciones
        '
        Me.ms_opciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_opciones_limite, Me.ms_opciones_nolimite})
        Me.ms_opciones.Name = "ms_opciones"
        Me.ms_opciones.Size = New System.Drawing.Size(69, 20)
        Me.ms_opciones.Text = "Opciones"
        '
        'ms_opciones_limite
        '
        Me.ms_opciones_limite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_opciones_limite_5, Me.ms_opciones_limite_10})
        Me.ms_opciones_limite.Name = "ms_opciones_limite"
        Me.ms_opciones_limite.Size = New System.Drawing.Size(152, 22)
        Me.ms_opciones_limite.Text = "Límite"
        '
        'ms_opciones_limite_10
        '
        Me.ms_opciones_limite_10.Name = "ms_opciones_limite_10"
        Me.ms_opciones_limite_10.Size = New System.Drawing.Size(152, 22)
        Me.ms_opciones_limite_10.Text = "10 min."
        '
        'ms_opciones_limite_5
        '
        Me.ms_opciones_limite_5.Name = "ms_opciones_limite_5"
        Me.ms_opciones_limite_5.Size = New System.Drawing.Size(152, 22)
        Me.ms_opciones_limite_5.Text = "5 min."
        '
        'ms_opciones_nolimite
        '
        Me.ms_opciones_nolimite.Name = "ms_opciones_nolimite"
        Me.ms_opciones_nolimite.Size = New System.Drawing.Size(152, 22)
        Me.ms_opciones_nolimite.Text = "Sin límite"
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
        Me.panel_ajedrez.PerformLayout()
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
    Friend WithEvents ms_opciones As ToolStripMenuItem
    Friend WithEvents ms_opciones_limite As ToolStripMenuItem
    Friend WithEvents ms_opciones_limite_5 As ToolStripMenuItem
    Friend WithEvents ms_opciones_limite_10 As ToolStripMenuItem
    Friend WithEvents ms_opciones_nolimite As ToolStripMenuItem
End Class
