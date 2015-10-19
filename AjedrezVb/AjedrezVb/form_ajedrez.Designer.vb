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
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.panel_ajedrez.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_ajedrez
        '
        Me.panel_ajedrez.BackColor = System.Drawing.Color.White
        Me.panel_ajedrez.Controls.Add(Me.btn_reset)
        Me.panel_ajedrez.Location = New System.Drawing.Point(601, 0)
        Me.panel_ajedrez.Name = "panel_ajedrez"
        Me.panel_ajedrez.Size = New System.Drawing.Size(150, 600)
        Me.panel_ajedrez.TabIndex = 0
        '
        'btn_reset
        '
        Me.btn_reset.Location = New System.Drawing.Point(16, 554)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(122, 34)
        Me.btn_reset.TabIndex = 0
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseVisualStyleBackColor = True
        '
        'form_ajedrez
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(751, 600)
        Me.Controls.Add(Me.panel_ajedrez)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_ajedrez"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajedrez"
        Me.panel_ajedrez.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panel_ajedrez As Panel
    Friend WithEvents btn_reset As Button
End Class
