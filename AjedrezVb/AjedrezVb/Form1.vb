Public Class Form1

    Dim figura As PictureBox
    Dim Color_Inicio As Color
    Dim Color_Final As Color

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim coordX As Integer 'posicion en coordX
        Dim coordY As Integer 'posicion en coordY




        For x = 0 To 7 'i --> recorre coordX

            For y = 0 To 7 'j --> recorre coordY


                'Jaime --> No cambiar las variables i-j por coordX-coordY porque bugea el bucle coordY adios form.
                'Si quereis hacer multicomentario seleccionar lo que quereis comentar coordY --> (Ctr+K y Ctr+C);
                'Para quitarlo (Ctr+K y Ctr+U); De nada :D



                Dim casilla As New PictureBox
                With casilla

                    .Name = "Casilla" & x & y
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(coordX, coordY)
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
                        .Tag = 21
                        casilla.Load(Application.StartupPath & "/images/pb.png")
                    End If
                    If x = 7 And (y = 0 Or y = 7) Then
                        .Tag = 22
                        casilla.Load(Application.StartupPath & "/images/tb.png")
                    End If
                    If x = 7 And (y = 1 Or y = 6) Then
                        .Tag = 23
                        casilla.Load(Application.StartupPath & "/images/cb.png")
                    End If
                    If x = 7 And (y = 2 Or y = 5) Then
                        .Tag = 24
                        casilla.Load(Application.StartupPath & "/images/ab.png")
                    End If
                    If x = 7 And (y = 3) Then
                        .Tag = 25
                        casilla.Load(Application.StartupPath & "/images/qb.png")
                    End If
                    If x = 7 And (y = 4) Then
                        .Tag = 24
                        casilla.Load(Application.StartupPath & "/images/kb.png")
                    End If
                    'Hasta aqui se posicionan

                    Me.Controls.Add(casilla)
                    AddHandler casilla.MouseClick, AddressOf Colocar

                End With

                coordX += 75

            Next
            coordX = 0
            coordY += 75

        Next



    End Sub




    Private Sub Colocar(sender As Object, e As EventArgs)



        If (sender.Tag <> "0") Then                                                                                 'Si la posicion que pulsas es distinto de 0, es una figura
            If figura Is Nothing Then                                                                               'Si no tenemos figura guardada (null) --> la guarda
                figura = sender                                                                                     'Guardamos la figura
                MsgBox("Figura guardada: " & figura.Name() & " Tag: " & figura.Tag())
                Color_Inicio = figura.BackColor                                                                     'Guardamos el color del tablero de la posicion de la figura
                figura.BackColor = Color.Red                                                                        'Resaltamos la figura seleccionada en ese momento
            Else                                                                                                    'Si ya hay una figura seleccionada --> Teniendo una figura, Pulsas en otra figura. Comprobar si la figura que pulsas es una figura propia --> error, una figura enemiga --> comer
                MsgBox("Ya tienes una figura guardada")
                'Insertar funcion para detectar si es del equipo contrario --> Comer; sino --> no deja moverse
            End If

        Else                                                                                                        'Posicion pulsada es 0 --> Si hay figura --> moverse; sino --> Error --> Pinchar primero en una figura
            If figura IsNot Nothing Then                                                                            'Si tienes figura guardada (no null) --> Movemos la figura
                MsgBox("Moviendo figura")
                Color_Final = sender.BackColor                                                                      'Guardamos el color de la posicion a la que nos movemos
                sender.BackColor = Color.Green                                                                      'Seteamos el color de la posicion a verde (creo que se puede prescindir, abajo lo volvemos a poner al default...)
                sender.Tag = figura.Tag                                                                             'Establecemos el tag de la imagen a la posicion que hemos pulsado (la figura se mueve coordY ocupa la posicion vacia)
                figura.Tag = "0"                                                                                    'Establecemos la posicion donde estaba la figura a 0 (la figura se mueve coordY deja libre su posicion inicial)
                MsgBox(sender.Tag)
                sender.ImageLocation = figura.ImageLocation                                                         'Establecemos la imagen de la posicion vacia a la imagen de la figura que se mueve
                figura.ImageLocation = Nothing                                                                      'Quitamos la imagen de la figura de su posicion inicial (null)
                figura.BackColor = Color_Inicio                                                                     'Establecemos el color de fondo de la posicion inicial a la del tablero
                sender.BackColor = Color_Final                                                                      'Establecemos el color de la posicion a moverse a la del tablero (Creo que se puede prescindir esto junto al verde)
                figura = Nothing                                                                                    'Resetamos la figura seleccionada para el siguiente movimiento
            Else                                                                                                    'No hay figura guardada --> Error --> Pinchar primero una figura
                MsgBox("Pincha primero en una figura")
            End If


        End If



    End Sub



End Class
