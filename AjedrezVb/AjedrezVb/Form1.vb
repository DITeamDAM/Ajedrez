Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer 'posicion en x
        Dim y As Integer 'posicion en y



        For x = 0 To 7 'x --> recorre x

            For y = 0 To 7 'y --> recorre y


                'LUIS -> Les he cambiado el nombre a las vars por x e y (Y)

                Dim casilla As New PictureBox
                With casilla

                    .Name = "Casilla" & x & y
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y)
                    .BorderStyle = BorderStyle.FixedSingle
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Tag = 0



                    'Se diferencia el color de las casillas
                    If x Mod 2 = 0 Then
                        .BackColor = Color.WhiteSmoke
                        If y Mod 2 <> 0 Then
                            .BackColor = Color.BurlyWood
                        End If
                    Else
                        '.BackColor = Color.Black
                        .BackColor = Color.BurlyWood
                        If y Mod 2 <> 0 Then
                            .BackColor = Color.WhiteSmoke
                        End If
                    End If


                    'Se posicionan las piezas en los PictureBox
                    'Aqui las negras
                    If x = 1 Then
                        .Tag = 11
                        casilla.Load(Application.StartupPath & "/images/pn.png")
                    End If
                    If x = 0 And (y = 0 Or y = 7) Then
                        .Tag = 12
                        casilla.Load(Application.StartupPath & "/images/tn.png")
                    End If
                    If x = 0 And (y = 1 Or y = 6) Then
                        .Tag = 13
                        casilla.Load(Application.StartupPath & "/images/cn.png")
                    End If
                    If x = 0 And (y = 2 Or y = 5) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/an.png")
                    End If
                    If x = 0 And (y = 3) Then
                        .Tag = 15
                        casilla.Load(Application.StartupPath & "/images/qn.png")
                    End If
                    If x = 0 And (y = 4) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/kn.png")
                    End If

                    'Aqui las blancas
                    If x = 6 Then
                        .Tag = 11
                        casilla.Load(Application.StartupPath & "/images/pb.png")
                    End If
                    If x = 7 And (y = 0 Or y = 7) Then
                        .Tag = 12
                        casilla.Load(Application.StartupPath & "/images/tb.png")
                    End If
                    If x = 7 And (y = 1 Or y = 6) Then
                        .Tag = 13
                        casilla.Load(Application.StartupPath & "/images/cb.png")
                    End If
                    If x = 7 And (y = 2 Or y = 5) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/ab.png")
                    End If
                    If x = 7 And (y = 3) Then
                        .Tag = 15
                        casilla.Load(Application.StartupPath & "/images/qb.png")
                    End If
                    If x = 7 And (y = 4) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/kb.png")
                    End If
                    'Hasta aqui se posicionan

                    Me.Controls.Add(casilla)
                    AddHandler casilla.MouseClick, AddressOf Colocar

                End With



                x += 75

            Next
            x = 0
            y += 75

        Next



    End Sub




    Private Sub Colocar(sender As Object, e As EventArgs)

        MsgBox("Nombre: " & sender.Name & " Tag: " & sender.Tag)


        'prueba master jaime

    End Sub



End Class
