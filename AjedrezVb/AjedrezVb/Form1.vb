Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer 'posicion en x
        Dim y As Integer 'posicion en y



        For i = 0 To 7 'i --> recorre x

            For j = 0 To 7 'j --> recorre y




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

                    If i = 1 Then
                        .Tag = 11
                        casilla.Load(Application.StartupPath & "/images/pn.png")
                    End If
                    If i = 0 And (j = 0 Or j = 7) Then
                        .Tag = 12
                        casilla.Load(Application.StartupPath & "/images/tn.png")
                    End If
                    If i = 0 And (j = 1 Or j = 6) Then
                        .Tag = 13
                        casilla.Load(Application.StartupPath & "/images/cn.png")
                    End If
                    If i = 0 And (j = 2 Or j = 5) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/an.png")
                    End If
                    If i = 0 And (j = 3) Then
                        .Tag = 15
                        casilla.Load(Application.StartupPath & "/images/qn.png")
                    End If
                    If i = 0 And (j = 4) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/kn.png")
                    End If


                    If i = 6 Then
                        .Tag = 11
                        casilla.Load(Application.StartupPath & "/images/pb.png")
                    End If
                    If i = 7 And (j = 0 Or j = 7) Then
                        .Tag = 12
                        casilla.Load(Application.StartupPath & "/images/tb.png")
                    End If
                    If i = 7 And (j = 1 Or j = 6) Then
                        .Tag = 13
                        casilla.Load(Application.StartupPath & "/images/cb.png")
                    End If
                    If i = 7 And (j = 2 Or j = 5) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/ab.png")
                    End If
                    If i = 7 And (j = 3) Then
                        .Tag = 15
                        casilla.Load(Application.StartupPath & "/images/qb.png")
                    End If
                    If i = 7 And (j = 4) Then
                        .Tag = 14
                        casilla.Load(Application.StartupPath & "/images/kb.png")
                    End If


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

        MsgBox("Nombre: " & sender.Name & " Tag: " & sender.Tag)

        MsgBox("Nombre: " & sender.Name & " Tag: " & sender.Tag)

        MsgBox("Nombre: " & sender.Name & " Tag: " & sender.Tag)


        'prueba master jaime

    End Sub



End Class
