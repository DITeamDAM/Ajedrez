﻿Public Class form_ajedrez

    Dim figura As PictureBox
    Dim Color_Inicio As Color
    Dim Color_Final As Color

    'Asignacion de valores para cada caso
    Dim blanca As Integer = 2
    Dim negra As Integer = 1

    Dim peon As Integer = 1
    Dim torre As Integer = 2
    Dim caballo As Integer = 3
    Dim alfil As Integer = 4
    Dim reina As Integer = 5
    Dim rey As Integer = 6


    Private Sub form_ajedrez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer

        'Asignacion de color del tablero, por si mas adelante queremos modificar el color, asi como poner imagenes de fondo (si fuera posible sin alterar las img de las figuras)
        Dim colorNegro = ColorTranslator.FromHtml("#C6932D")
        Dim colorBlanco = ColorTranslator.FromHtml("#FEE8B9")


        For i = 0 To 7
            For j = 0 To 7

                Dim casilla As New PictureBox
                With casilla

                    .Name = "Casilla" & i & j
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y)
                    '.BorderStyle = BorderStyle.FixedSingle
                    .BorderStyle = BorderStyle.None
                    .Padding = New Padding(0, 0, 0, 0)
                    '.SizeMode = PictureBoxSizeMode.StretchImage
                    .SizeMode = PictureBoxSizeMode.Normal
                    .Tag = 0


                    'Se diferencia el color de las casillas
                    If i Mod 2 = 0 Then
                        .BackColor = colorBlanco
                        If j Mod 2 <> 0 Then
                            .BackColor = colorNegro
                        End If
                    Else
                        .BackColor = colorNegro
                        If j Mod 2 <> 0 Then
                            .BackColor = colorBlanco
                        End If
                    End If


                    Select Case i
                        Case 0
                            Select Case j
                                Case 0, 7
                                    setFigura(casilla, negra, torre)
                                Case 1, 6
                                    setFigura(casilla, negra, caballo)
                                Case 2, 5
                                    setFigura(casilla, negra, alfil)
                                Case 3
                                    setFigura(casilla, negra, reina)
                                Case 4
                                    setFigura(casilla, negra, rey)
                                Case Else
                                    .Tag = 0
                            End Select
                        Case 1
                            setFigura(casilla, negra, peon)
                        Case 6
                            setFigura(casilla, blanca, peon)
                        Case 7
                            Select Case j
                                Case 0, 7
                                    setFigura(casilla, blanca, torre)
                                Case 1, 6
                                    setFigura(casilla, blanca, caballo)
                                Case 2, 5
                                    setFigura(casilla, blanca, alfil)
                                Case 3
                                    setFigura(casilla, blanca, reina)
                                Case 4
                                    setFigura(casilla, blanca, rey)
                                Case Else
                                    .Tag = 0
                            End Select
                    End Select


                    Me.Controls.Add(casilla)
                    AddHandler casilla.MouseClick, AddressOf Colocar

                End With

                x += 75
            Next

            x = 0
            y += 75
        Next
    End Sub

    'Para crear las figuras segun los parametros, valido tambien para futuros usos en otros metodos
    Private Sub setFigura(obj As PictureBox, color As Integer, tipo As Integer)
        obj.Tag = color & tipo
        obj.Load(Application.StartupPath & "/img/" & color & tipo & ".png")
    End Sub




    Private Function getColor(obj As PictureBox)
        Return CInt(CStr(obj.Tag).Substring(0, 1))
    End Function

    Private Function getTipo(obj As PictureBox)
        Return CInt(CStr(obj.Tag).Substring(1, 1))
    End Function

    Private Function getPosicion(obj As PictureBox)
        Return CInt(CStr(obj.Name).Substring(7, 2)) 'Cambiar esto (poner el numero de caracter segun el nombre, que sera simplemente el numero) cuando cambie el nombre en la creacion del objeto
    End Function












    Private Function horizontal(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 10, getPosicion(click1st) + 10

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function


    Private Function vertical(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 1, getPosicion(click1st) + 1

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function



    Private Function horizontales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For horizontal As Integer = 1 To 8
            Select Case getPosicion(click2nd)
                Case getPosicion(click1st) + horizontal * (-10), getPosicion(click1st) + horizontal * (+10)

                    Return limite(getColor(click1st), getColor(click2nd))

            End Select
        Next

        Return False
    End Function


    Private Function verticales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For horizontal As Integer = 1 To 8
            Select Case getPosicion(click2nd)
                Case getPosicion(click1st) + horizontal * (-1), getPosicion(click1st) + horizontal * (+1)

                    Return limite(getColor(click1st), getColor(click2nd))

            End Select
        Next

        Return False
    End Function


    Private Function diagonal(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 9, getPosicion(click1st) + 9, getPosicion(click1st) - 11, getPosicion(click1st) + 11

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function

    Private Function diagonales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For diagonal As Integer = 1 To 8

            Select Case getPosicion(click2nd)
                Case getPosicion(click1st) + diagonal * (-9), getPosicion(click1st) + diagonal * (+9), getPosicion(click1st) + diagonal * (-11), getPosicion(click1st) + diagonal * (+11)

                    Return limite(getColor(click1st), getColor(click2nd))

            End Select

        Next

        Return False
    End Function


    Private Function limite(ByVal click1st As Integer, click2nd As Integer)

        If click1st <> click2nd Then
            Return True
        End If

        Return False
    End Function






    'Movimiento del peon

    'Function MovPeon11(ByVal peon As PictureBox, ByVal nuevaCasilla As PictureBox)
    '    Dim posInicial As String
    '    Dim posFinal As String
    '    Dim inicio As String

    '    posInicial = peon.Name                          'Calcula las posiciones tanto del inicio como del final
    '    posInicial = posInicial.Substring(7)
    '    posFinal = nuevaCasilla.Name
    '    posFinal = posFinal.Substring(7)
    '    inicio = posInicial.Substring(0, 1)

    '    MsgBox(posInicial & " ,pos final: " & posFinal)

    '    'condicion para primer movimiento del peon
    '    If inicio = 6 Then
    '        If posFinal = posInicial - 10 Then
    '            Return True
    '        End If
    '        If posFinal = posInicial - 20 Then
    '            Return True


    '        End If
    '    Else
    '        'controlador del movimiento del peon
    '        If posFinal = posInicial - 10 Then
    '            If nuevaCasilla.Tag > 10 Then
    '                Return False
    '            Else
    '                Return True
    '            End If

    '        End If
    '        'controlador como come el peon
    '        If posFinal = posInicial - 11 Then
    '            If nuevaCasilla.Tag > 10 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End If
    '        If posFinal = posInicial - 9 Then
    '            If nuevaCasilla.Tag > 10 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End If

    '    End If


    'End Function


    Function MovTorre(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If horizontales(click1st, click2nd) Or verticales(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function


    'Function MovCaballo23(ByVal rey As PictureBox, ByVal nuevaCasilla As PictureBox)
    '    Dim posInicial As String
    '    Dim posFinal As String


    '    posInicial = rey.Name                          'Calcula las posiciones tanto del inicio como del final
    '    posInicial = posInicial.Substring(7)
    '    posFinal = nuevaCasilla.Name
    '    posFinal = posFinal.Substring(7)

    '    'controlador vertical del caballo
    '    If posFinal = posInicial + 21 Or posFinal = posInicial + 19 Or posFinal = posInicial - 21 Or posFinal = posInicial - 19 Then

    '        If nuevaCasilla.Tag > 10 And nuevaCasilla.Tag < 17 Then
    '            Return True
    '        End If
    '        If nuevaCasilla.Tag > 20 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End If
    '    'controlador horizontal del caballo
    '    If posFinal = posInicial + 12 Or posFinal = posInicial + 8 Or posFinal = posInicial - 12 Or posFinal = posInicial - 8 Then
    '        If nuevaCasilla.Tag > 10 And nuevaCasilla.Tag < 17 Then
    '            Return True
    '        End If
    '        If nuevaCasilla.Tag > 20 Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End If

    'End Function



    'Function Interponer(ByVal figura As PictureBox, ByVal nuevaCasilla As PictureBox)


    '    Dim posInicial As String
    '    Dim posFinal As String


    '    Dim posVertical_Inicial As String
    '    Dim posVertical_Final As String
    '    Dim posHorizontal_Inicial As String
    '    Dim posHorizontal_Final As String



    '    posInicial = figura.Name                          'Calcula las posiciones tanto del inicio como del final
    '    posInicial = posInicial.Substring(7)
    '    Dim contador As Integer = posInicial
    '    posFinal = nuevaCasilla.Name
    '    posFinal = posFinal.Substring(7)



    '    'comprobador vertical



    'End Function

    Function MovAlfil(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Return diagonales(click1st, click2nd)

    End Function

    Function MovReina(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If horizontales(click1st, click2nd) Or verticales(click1st, click2nd) Or diagonales(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function


    Function MovRey(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If vertical(click1st, click2nd) Or horizontal(click1st, click2nd) Or diagonal(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function





    'filtro de figuras y sus movimientos
    Function comprobador(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getTipo(click1st)
            Case 2
                MsgBox(MovTorre(click1st, click2nd))
                Return MovTorre(click1st, click2nd)
            Case 4
                MsgBox(MovAlfil(click1st, click2nd))
                Return MovAlfil(click1st, click2nd)
            Case 5
                MsgBox(MovReina(click1st, click2nd))
                Return MovReina(click1st, click2nd)
            Case 6
                MsgBox(MovRey(click1st, click2nd))
                Return MovRey(click1st, click2nd)
        End Select

        Return False
    End Function





    Dim tagFigura As String
    Private Sub Colocar(sender As Object, e As EventArgs)

        'Color al seleccionar y al soltar, tambien por colores hexadecimales
        Dim colorSelected = ColorTranslator.FromHtml("#5DB3FF") '#f3fc41
        Dim colorSoltado = ColorTranslator.FromHtml("#57D837") '#4DFC41

        If (sender.Tag <> "0") Then                                                                                 'Si la posicion que pulsas es distinto de 0, es una figura

            If figura Is Nothing Then                                                                               'Si no tenemos figura guardada (null) --> la guarda
                figura = sender                                                                                     'Guardamos la figura
                tagFigura = figura.Tag
                tagFigura = tagFigura.Substring(0, 1)
                MsgBox("Figura guardada: " & figura.Name() & " Tag: " & figura.Tag() & " TEAM: " & tagFigura)
                Color_Inicio = figura.BackColor                                                                     'Guardamos el color del tablero de la posicion de la figura
                figura.BackColor = colorSelected                                                                        'Resaltamos la figura seleccionada en ese momento
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
                figura.BackColor = colorSelected
            End If
            'controlador para cuando seleccionamos una figura de otro equipo
            If tagFigura <> tagSender Then
                If comprobador(figura, sender) Then
                    MsgBox("Moviendo figura")
                    Color_Final = sender.BackColor                                                                      'Guardamos el color de la posicion a la que nos movemos
                    sender.BackColor = colorSoltado                                                                      'Seteamos el color de la posicion a verde (creo que se puede prescindir, abajo lo volvemos a poner al default...)
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
                    sender.BackColor = colorSoltado                                                                    'Seteamos el color de la posicion a verde (creo que se puede prescindir, abajo lo volvemos a poner al default...)
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






End Class