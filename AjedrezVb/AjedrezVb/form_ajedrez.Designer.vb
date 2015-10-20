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
        Me.ms_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_ajedrez
        '
        Me.panel_ajedrez.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.panel_ajedrez.Location = New System.Drawing.Point(601, 25)
        Me.panel_ajedrez.Name = "panel_ajedrez"
        Me.panel_ajedrez.Size = New System.Drawing.Size(150, 600)
        Me.panel_ajedrez.TabIndex = 0
        '
        'ms_principal
        '
        Me.ms_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_archivo})
        Me.ms_principal.Location = New System.Drawing.Point(0, 0)
        Me.ms_principal.Name = "ms_principal"
        Me.ms_principal.Size = New System.Drawing.Size(752, 24)
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
        Me.ms_archivo_nuevapartida.Size = New System.Drawing.Size(152, 22)
        Me.ms_archivo_nuevapartida.Text = "Nueva partida"
        '
        'ms_archivo_salir
        '
        Me.ms_archivo_salir.Name = "ms_archivo_salir"
        Me.ms_archivo_salir.Size = New System.Drawing.Size(152, 22)
        Me.ms_archivo_salir.Text = "Salir"
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
End Class
