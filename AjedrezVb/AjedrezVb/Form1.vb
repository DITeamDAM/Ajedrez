Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer 'posicion en x
        Dim y As Integer 'posicion en y



        For i = 0 To 7 'i --> recorre x

            For j = 0 To 7 'j --> recorre y
                Dim pieza As New PictureBox
                With pieza
                    SetStyle(ControlStyles.SupportsTransparentBackColor, True)

                    If i = 0 And (j = 0 Or j = 7) Then


                        .Name = "pn_torre"
                        .Size = New System.Drawing.Size(75, 75)

                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/tn.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 0 And (j = 1 Or j = 6) Then

                        .Name = "pn_caballo"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/cn.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 0 And (j = 2 Or j = 5) Then

                        .Name = "pn_alfil"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/an.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 0 And (j = 3) Then

                        .Name = "pn_reina"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/qn.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 0 And (j = 4) Then

                        .Name = "pn_rey"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/kn.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 1 Then

                        .Name = "pn_peon" & j
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/pn.png")
                        Me.Controls.Add(pieza)
                    End If


                    If i = 7 And (j = 0 Or j = 7) Then

                        .Name = "pb_torre"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/tb.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 7 And (j = 1 Or j = 6) Then

                        .Name = "pb_caballo"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/cb.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 7 And (j = 2 Or j = 5) Then

                        .Name = "pb_alfil"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/ab.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 7 And (j = 3) Then

                        .Name = "pb_reina"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/qb.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 7 And (j = 4) Then

                        .Name = "pb_rey"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/kb.png")
                        Me.Controls.Add(pieza)
                    End If
                    If i = 6 Then

                        .Name = "pb_torre"
                        .Size = New System.Drawing.Size(75, 75)


                        .BorderStyle = BorderStyle.FixedSingle
                        .SizeMode = PictureBoxSizeMode.StretchImage

                        .Location = New System.Drawing.Point(x, y)
                        pieza.Load(Application.StartupPath & "/images/pb.png")
                        Me.Controls.Add(pieza)

                    End If

                End With



                Dim casilla As New PictureBox
                With casilla

                    .Name = "Casilla" & i & j
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y)
                    .BorderStyle = BorderStyle.FixedSingle
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Tag = 0


                    If i Mod 2 = 0 Then
                        .BackColor = Color.WhiteSmoke
                        If j Mod 2 <> 0 Then
                            .BackColor = Color.BurlyWood
                        End If
                    Else
                        '.BackColor = Color.Black
                        .BackColor = Color.BurlyWood
                        If j Mod 2 <> 0 Then
                            .BackColor = Color.WhiteSmoke
                        End If
                    End If


                    Me.Controls.Add(casilla)


                End With

                x += 75

            Next
            x = 0
            y += 75

        Next



    End Sub



End Class
