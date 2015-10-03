Public Class Form1

    Dim figura As PictureBox
    Dim Color_Inicio As Color
    Dim Color_Final As Color

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer 'posicion en x
        Dim y As Integer 'posicion en y




        For i = 0 To 7 'i --> recorre x

            For j = 0 To 7 'j --> recorre y


                'Jaime --> No cambiar las variables i-j por x-y porque bugea el bucle y adios form.
                'Si quereis hacer multicomentario seleccionar lo que quereis comentar y --> (Ctr+K y Ctr+C);
                'Para quitarlo (Ctr+K y Ctr+U); De nada :D



                Dim casilla As New PictureBox
                With casilla

                    .Name = "Casilla" & i & j
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y)
                    .BorderStyle = BorderStyle.FixedSingle
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Tag = 0



                    'Se diferencia el color de las casillas
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


                    'Se posicionan las piezas en los PictureBox
                    'Aqui las negras
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

                    'Aqui las blancas
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



        Dim pos_Inicio As Integer
        Dim pos_Fin As Integer


        'Primero check if figura -> guardada; Si -> seleccionar posicion; No --> pincha en una figura;





        If (sender.Tag <> "0") Then
            If figura Is Nothing Then
                figura = sender
                MsgBox("Figura guardada: " & figura.Name() & " Tag: " & figura.Tag())
                Color_Inicio = figura.BackColor
                figura.BackColor = Color.Red
            Else
                MsgBox("Ya tienes una figura guardada")
                'funcion para detectar si es del equipo contrario --> Comer; sino --> no deja moverse
            End If

        Else
            If figura IsNot Nothing Then
                MsgBox("Moviendo figura")
                Color_Final = sender.BackColor
                sender.BackColor = Color.Green

                sender.Tag = figura.Tag
                figura.Tag = "0"
                MsgBox(sender.Tag)
                sender.ImageLocation = figura.ImageLocation
                figura.ImageLocation = Nothing
                figura.BackColor = Color_Inicio
                sender.BackColor = Color_Final
                figura = Nothing
            Else
                MsgBox("Pincha primero en una figura")
            End If


        End If



    End Sub



End Class
