﻿Public Class Form1

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
                        .Tag = 21
                        casilla.Load(Application.StartupPath & "/images/pb.png")
                    End If
                    If i = 7 And (j = 0 Or j = 7) Then
                        .Tag = 22
                        casilla.Load(Application.StartupPath & "/images/tb.png")
                    End If
                    If i = 7 And (j = 1 Or j = 6) Then
                        .Tag = 23
                        casilla.Load(Application.StartupPath & "/images/cb.png")
                    End If
                    If i = 7 And (j = 2 Or j = 5) Then
                        .Tag = 24
                        casilla.Load(Application.StartupPath & "/images/ab.png")
                    End If
                    If i = 7 And (j = 3) Then
                        .Tag = 25
                        casilla.Load(Application.StartupPath & "/images/qb.png")
                    End If
                    If i = 7 And (j = 4) Then
                        .Tag = 24
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


    Dim tagFigura As String

    Private Sub Colocar(sender As Object, e As EventArgs)



        If (sender.Tag <> "0") Then                                                                                 'Si la posicion que pulsas es distinto de 0, es una figura

            If figura Is Nothing Then                                                                               'Si no tenemos figura guardada (null) --> la guarda
                figura = sender                                                                                     'Guardamos la figura
                tagFigura = figura.Tag
                tagFigura = tagFigura.Substring(0, 1)
                MsgBox("Figura guardada: " & figura.Name() & " Tag: " & figura.Tag() & " TEAM: " & tagFigura)
                Color_Inicio = figura.BackColor                                                                     'Guardamos el color del tablero de la posicion de la figura
                figura.BackColor = Color.Red                                                                        'Resaltamos la figura seleccionada en ese momento
                'Si ya hay una figura seleccionada --> Teniendo una figura, Pulsas en otra figura. Comprobar si la figura que pulsas es una figura propia --> error, una figura enemiga --> comer



                'Insertar funcion para detectar si es del equipo contrario --> Comer; sino --> no deja moverse
            End If
            'calcula los tag de la nueva figura
            Dim tagSender As String
            tagSender = sender.tag
            tagSender = tagSender.Substring(0, 1)

            'controlador para cambiar  de figura
            If tagFigura = tagSender Then
                'Guardamos la figura
                figura.BackColor = Color_Inicio
                figura = sender
                tagFigura = figura.Tag
                tagFigura = tagFigura.Substring(0, 1)
                MsgBox("Figura guardada: " & figura.Name() & " Tag: " & figura.Tag() & " TEAM: " & tagFigura)
                Color_Inicio = figura.BackColor                                                                     'Guardamos el color del tablero de la posicion de la figura
                figura.BackColor = Color.Red
            End If
            'controlador para cuando seleccionamos una figura de otro equipo
            If tagFigura <> tagSender Then
                If comprobador(figura, sender) Then
                    MsgBox("Moviendo figura")
                    Color_Final = sender.BackColor                                                                      'Guardamos el color de la posicion a la que nos movemos
                    sender.BackColor = Color.Green                                                                      'Seteamos el color de la posicion a verde (creo que se puede prescindir, abajo lo volvemos a poner al default...)
                    sender.Tag = figura.Tag                                                                             'Establecemos el tag de la imagen a la posicion que hemos pulsado (la figura se mueve y ocupa la posicion vacia)
                    figura.Tag = "0"                                                                                    'Establecemos la posicion donde estaba la figura a 0 (la figura se mueve y deja libre su posicion inicial)
                    MsgBox(sender.Tag)
                    sender.ImageLocation = figura.ImageLocation                                                         'Establecemos la imagen de la posicion vacia a la imagen de la figura que se mueve
                    figura.ImageLocation = Nothing                                                                      'Quitamos la imagen de la figura de su posicion inicial (null)
                    figura.BackColor = Color_Inicio                                                                     'Establecemos el color de fondo de la posicion inicial a la del tablero
                    sender.BackColor = Color_Final                                                                      'Establecemos el color de la posicion a moverse a la del tablero (Creo que se puede prescindir esto junto al verde)
                    figura = Nothing
                End If

            End If

        Else                                                                                                        'Posicion pulsada es 0 --> Si hay figura --> moverse; sino --> Error --> Pinchar primero en una figura
            'Si tienes figura guardada (no null) --> Movemos la figura
            If figura Is Nothing Then
                MsgBox("Pincha primero en una figura")
            Else
                If comprobador(figura, sender) Then

                    MsgBox("Moviendo figura")
                    Color_Final = sender.BackColor                                                                      'Guardamos el color de la posicion a la que nos movemos
                    sender.BackColor = Color.Green                                                                      'Seteamos el color de la posicion a verde (creo que se puede prescindir, abajo lo volvemos a poner al default...)
                    sender.Tag = figura.Tag                                                                             'Establecemos el tag de la imagen a la posicion que hemos pulsado (la figura se mueve y ocupa la posicion vacia)
                    figura.Tag = "0"                                                                                    'Establecemos la posicion donde estaba la figura a 0 (la figura se mueve y deja libre su posicion inicial)
                    MsgBox(sender.Tag)
                    sender.ImageLocation = figura.ImageLocation                                                         'Establecemos la imagen de la posicion vacia a la imagen de la figura que se mueve
                    figura.ImageLocation = Nothing                                                                      'Quitamos la imagen de la figura de su posicion inicial (null)
                    figura.BackColor = Color_Inicio                                                                     'Establecemos el color de fondo de la posicion inicial a la del tablero
                    sender.BackColor = Color_Final                                                                      'Establecemos el color de la posicion a moverse a la del tablero (Creo que se puede prescindir esto junto al verde)
                    figura = Nothing                                                                                    'Resetamos la figura seleccionada para el siguiente movimiento
                    'No hay figura guardada --> Error --> Pinchar primero una figura

                End If
            End If




        End If



    End Sub

    'filtro de figuras y sus movimientos
    Function comprobador(ByVal figura As PictureBox, ByVal nCasilla As PictureBox)
        MsgBox(figura.Tag & "ESTO ES LA FUNCION COMPROBAR")
        Select Case figura.Tag
            Case 11

            Case 12
                Return True
            Case 13
            Case 14
            Case 15
            Case 16
            Case 21
                Return MovPeon11(figura, nCasilla)
            Case 22
            Case 23
            Case 24
            Case 25
            Case 26
            Case 0
                MsgBox("Selecciona una figura")



        End Select




    End Function
    'Movimiento del peon

    Function MovPeon11(ByVal peon As PictureBox, ByVal nuevaCasilla As PictureBox)
        Dim posInicial As String
        Dim posFinal As String
        Dim inicio As String

        posInicial = peon.Name                          'Calcula las posiciones tanto del inicio como del final
        posInicial = posInicial.Substring(7)
        posFinal = nuevaCasilla.Name
        posFinal = posFinal.Substring(7)
        inicio = posInicial.Substring(0, 1)

        MsgBox(posInicial & " ,pos final: " & posFinal)

        'condicion para primer movimiento del peon
        If inicio = 6 Then
            If posFinal = posInicial - 10 Then
                Return True
            End If
            If posFinal = posInicial - 20 Then
                Return True


            End If
        Else
            'controlador del movimiento del peon
            If posFinal = posInicial - 10 Then
                If nuevaCasilla.Tag > 10 Then
                    Return False
                Else
                    Return True
                End If

            End If
            'controlador como come el peon
            If posFinal = posInicial - 11 Then
                If nuevaCasilla.Tag > 10 Then
                    Return True
                Else
                    Return False
                End If
            End If
            If posFinal = posInicial - 9 Then
                If nuevaCasilla.Tag > 10 Then
                    Return True
                Else
                    Return False
                End If
            End If

        End If


    End Function





End Class
