Public Class form_ajedrez


    'Asignacion de valores para cada caso
    Dim blanca As Integer = 2
    Dim negra As Integer = 1

    Dim peon As Integer = 1
    Dim torre As Integer = 2
    Dim caballo As Integer = 3
    Dim alfil As Integer = 4
    Dim reina As Integer = 5
    Dim rey As Integer = 6

    Dim turno As Boolean = True


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

                    .Name = i & j
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y)
                    .BorderStyle = BorderStyle.None
                    .Padding = New Padding(0, 0, 0, 0)
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
                    AddHandler casilla.MouseClick, AddressOf colocando

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
        Return CInt(CStr(obj.Name).Substring(0, 2)) 'Cambiar esto (poner el numero de caracter segun el nombre, que sera simplemente el numero) cuando cambie el nombre en la creacion del objeto
    End Function


    Private Function getPosicionFila(obj As PictureBox)
        Return CInt(CStr(obj.Name).Substring(0, 1)) 'Cambiar esto (poner el numero de caracter segun el nombre, que sera simplemente el numero) cuando cambie el nombre en la creacion del objeto
    End Function


    Private Function getPosicionColumna(obj As PictureBox)
        Return CInt(CStr(obj.Name).Substring(1, 1)) 'Cambiar esto (poner el numero de caracter segun el nombre, que sera simplemente el numero) cuando cambie el nombre en la creacion del objeto
    End Function


    Private Function horizontal(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 1,
                 getPosicion(click1st) + 1

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function


    Private Function vertical(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 10,
                 getPosicion(click1st) + 10

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function


    Private Function verticales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For vertical As Integer = 1 To 8
            Select Case getPosicion(click2nd)
                Case vertical & getPosicionColumna(click1st)

                    Return limite(getColor(click1st), getColor(click2nd))

            End Select
        Next

        Return False
    End Function


    Private Function horizontales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For horizontal As Integer = 1 To 8

            Select Case getPosicion(click2nd)
                Case getPosicionFila(click1st) & horizontal

                    Return limite(getColor(click1st), getColor(click2nd))

            End Select



        Next

        Return False
    End Function


    Private Function diagonal(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) - 9,
                 getPosicion(click1st) + 9,
                 getPosicion(click1st) - 11,
                 getPosicion(click1st) + 11


                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function


    Private Function diagonales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        For diagonal As Integer = 1 To 8

            Select Case getPosicion(click2nd)
                Case getPosicion(click1st) + diagonal * (-9),
                     getPosicion(click1st) + diagonal * (+9),
                     getPosicion(click1st) + diagonal * (-11),
                     getPosicion(click1st) + diagonal * (+11)

                    'MsgBox(click1st.Tag)


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


    'En el movimiento del peón no hace falta implementar una funcion "interponer" ya que solo come en diagonal, y he tenido que forzarlo directamente para que no coma hacia adelante
    Function MovPeon(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        'CREO que algo se podrá refactorizar aun mas...
        Select Case getColor(click1st)
            Case blanca
                If getPosicionFila(click1st) = 6 Then
                    Select Case getPosicion(click2nd)
                        Case getPosicion(click1st) - 10, getPosicion(click1st) - 20
                            If getColor(click2nd) = 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                        Case getPosicion(click1st) - 11, getPosicion(click1st) - 9
                            If getColor(click2nd) <> 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                    End Select
                Else
                    Select Case getPosicion(click2nd)
                        Case getPosicion(click1st) - 10
                            If getColor(click2nd) = 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                        Case getPosicion(click1st) - 11, getPosicion(click1st) - 9
                            If getColor(click2nd) <> 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                    End Select
                End If
            Case negra
                If getPosicionFila(click1st) = 1 Then
                    Select Case getPosicion(click2nd)
                        Case getPosicion(click1st) + 10, getPosicion(click1st) + 20
                            If getColor(click2nd) = 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                        Case getPosicion(click1st) + 11, getPosicion(click1st) + 9
                            If getColor(click2nd) <> 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                    End Select
                Else
                    Select Case getPosicion(click2nd)
                        Case getPosicion(click1st) + 10
                            If getColor(click2nd) = 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                        Case getPosicion(click1st) + 11, getPosicion(click1st) + 9
                            If getColor(click2nd) <> 0 Then
                                Return limite(getColor(click1st), getColor(click2nd))
                            End If
                    End Select
                End If
        End Select

        Return False
    End Function


    Function MovTorre(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If verticales(click1st, click2nd) Or horizontales(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function

    Function MovCaballo(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getPosicion(click2nd)
            Case getPosicion(click1st) + 8,
                 getPosicion(click1st) + 12,
                 getPosicion(click1st) + 19,
                 getPosicion(click1st) + 21,
                 getPosicion(click1st) - 8,
                 getPosicion(click1st) - 12,
                 getPosicion(click1st) - 19,
                 getPosicion(click1st) - 21

                Return limite(getColor(click1st), getColor(click2nd))

        End Select

        Return False
    End Function


    Function MovAlfil(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Return diagonales(click1st, click2nd)

    End Function


    Function MovReina(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        If verticales(click1st, click2nd) OrElse diagonales(click1st, click2nd) OrElse horizontales(click1st, click2nd) Then
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


    'Comprueba que se ha seleccionado una figura
    Function comprobador(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        Select Case getTipo(click1st)
            Case 1
                Return MovPeon(click1st, click2nd)
            Case 2
                Return MovTorre(click1st, click2nd)
            Case 3
                Return MovCaballo(click1st, click2nd)
            Case 4
                Return MovAlfil(click1st, click2nd)
            Case 5
                Return MovReina(click1st, click2nd)
            Case 6
                Return MovRey(click1st, click2nd)
        End Select

        Return False
    End Function


    'Color al seleccionar y al soltar, tambien por colores hexadecimales
    Dim bgcolorClick1st = ColorTranslator.FromHtml("#5DB3FF") '#f3fc41
    Dim bgcolorClick2nd = ColorTranslator.FromHtml("#57D837") '#4DFC41

    Dim colorClicked1st As Integer
    Dim clicked1st As PictureBox = Nothing

    Dim color1st As Color
    Dim color2nd As Color


    Private Sub guardarPieza(click As PictureBox)
        clicked1st = click
        colorClicked1st = getColor(clicked1st)
        color1st = clicked1st.BackColor
        clicked1st.BackColor = bgcolorClick1st
    End Sub


    'Dim ultimoMov As Integer = 0
    Private Sub moverClick(click As PictureBox)
        color2nd = click.BackColor

        click.Tag = clicked1st.Tag
        clicked1st.Tag = 0

        'MsgBox(click.Tag)

        click.ImageLocation = clicked1st.ImageLocation
        clicked1st.ImageLocation = Nothing

        clicked1st.BackColor = color1st
        'click.BackColor = bgcolorClick2nd
        click.BackColor = color2nd 'setea el color de fondo al soltar la pieza

        clicked1st = Nothing

        'ultimoMov = getPosicion(click)
    End Sub



    Private Sub mover(clicked2nd As PictureBox)
        If (getColor(clicked2nd) <> 0) Then

            If clicked1st Is Nothing Then
                guardarPieza(clicked2nd)
            End If


            Dim colorClicked2nd As Integer = getColor(clicked2nd)

            'si es del mismo color
            If colorClicked1st = colorClicked2nd Then
                clicked1st.BackColor = color1st 'setea el color que habia antes de fondo
                guardarPieza(clicked2nd)
            Else 'si no, la come
                If comprobador(clicked1st, clicked2nd) Then
                    moverClick(clicked2nd)
                End If
            End If

        Else

            If clicked1st IsNot Nothing Then 'si el en el segundo click no hay nada, la mueve libremente
                If comprobador(clicked1st, clicked2nd) Then
                    moverClick(clicked2nd)
                End If
            Else
                'MsgBox("Selecciona una pieza")
            End If

        End If
    End Sub




    'Dim primerclick As Boolean = True

    Private Sub colocando(clicked2nd As PictureBox, e As EventArgs)

        mover(clicked2nd)


        'eventos aparte para el primer y segundo click
        'If primerclick Then

        '    'If ultimoMov <> 0 Then

        '    '    For Each objeto In Me.Controls
        '    '        If TypeOf (objeto) Is System.Windows.Forms.PictureBox Then
        '    '            If getPosicion(objeto) = ultimoMov Then
        '    '                objeto.BackColor = color2nd
        '    '                Exit For
        '    '            End If
        '    '        End If
        '    '    Next

        '    'End If

        '    primerclick = False
        'Else

        '    primerclick = True
        'End If

    End Sub






End Class