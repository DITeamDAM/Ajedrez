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


    'Asignacion de color del tablero, por si mas adelante queremos modificar el color, asi como poner imagenes de fondo (si fuera posible sin alterar las img de las figuras)
    Dim colorNegroTablero = ColorTranslator.FromHtml("#C6932D")
    Dim colorBlancoTablrero = ColorTranslator.FromHtml("#FEE8B9")

    Dim arrayCas(8, 8) As PictureBox
    Dim arrayTablero(8, 8) As PictureBox



    Private Sub form_ajedrez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer

        For i = 0 To 7
            For j = 0 To 7

                Dim casilla As New PictureBox
                With casilla

                    .Name = i & j
                    .Size = New System.Drawing.Size(75, 75)
                    .Location = New System.Drawing.Point(x, y + 25)
                    .BorderStyle = BorderStyle.None
                    .Padding = New Padding(0, 0, 0, 0)
                    .SizeMode = PictureBoxSizeMode.Normal
                    .Tag = 0

                    arrayCas(i, j) = casilla
                    arrayTablero(i, j) = casilla

                    setTablero(i, j)

                    Me.Controls.Add(casilla)
                    AddHandler casilla.MouseClick, AddressOf colocando

                End With

                x += 75
            Next

            x = 0
            y += 75
        Next

        reset()

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
        Return CInt(obj.Name.Substring(0, 2))
    End Function


    Private Function getPosicionFila(obj As PictureBox)
        Return CInt(obj.Name.Substring(0, 1))
    End Function


    Private Function getPosicionColumna(obj As PictureBox)
        Return CInt(obj.Name.Substring(1, 1))
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
        Dim direccion As Integer
        Dim columna As Integer = getPosicionColumna(click1st)

        If getPosicionFila(click1st) = getPosicionFila(click2nd) Or getPosicionColumna(click1st) <> getPosicionColumna(click2nd) Then
            Return False
        ElseIf getPosicionFila(click1st) > getPosicionFila(click2nd) Then
            direccion = -1
        Else
            direccion = +1
        End If

        For fila = getPosicionFila(click1st) To getPosicionFila(click2nd) Step direccion

            If (fila & columna) <> getPosicion(click1st) And (fila & columna) <> getPosicion(click2nd) Then 'busca en el recorrido todos los picturebox que existan en medio
                'MsgBox(getPosicion(arrayCas(fila, columna)) & ", " & getColor(arrayCas(fila, columna)))
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
                    'MsgBox("hay una ficha en medio")
                    Return False
                End If
            End If


            Select Case getPosicion(click2nd)
                Case fila & columna
                    Return limite(getColor(click1st), getColor(click2nd))
            End Select



        Next

        Return False
    End Function


    Private Function horizontales(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        Dim direccion As Integer
        Dim fila As Integer = getPosicionFila(click1st)

        If getPosicionFila(click1st) <> getPosicionFila(click2nd) Or getPosicionColumna(click1st) = getPosicionColumna(click2nd) Then
            Return False
        ElseIf getPosicionColumna(click1st) > getPosicionColumna(click2nd) Then
            direccion = -1
        Else
            direccion = +1
        End If

        For columna = getPosicionColumna(click1st) To getPosicionColumna(click2nd) Step direccion


            If (fila & columna) <> getPosicion(click1st) And (fila & columna) <> getPosicion(click2nd) Then 'busca en el recorrido todos los picturebox que existan en medio
                'MsgBox(getPosicion(arrayCas(fila, columna)) & ", " & getColor(arrayCas(fila, columna)))
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
                    'MsgBox("hay una ficha en medio")
                    Return False
                End If
            End If

            Select Case getPosicion(click2nd)
                Case fila & columna
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
        Dim direccion As Integer
        Dim columna = getPosicionColumna(click1st)

        If getPosicionFila(click1st) = getPosicionFila(click2nd) Or getPosicionColumna(click1st) = getPosicionColumna(click2nd) Then 'si los clicks son en las mismas filas o columnas devuelve false
            Return False
        ElseIf getPosicionFila(click1st) > getPosicionFila(click2nd) Then 'si la fila del primer click es mayor q la del segundo, se va decrementando, si no, se va incrementando
            direccion = -1
        Else
            direccion = +1
        End If


        For fila = getPosicionFila(click1st) To getPosicionFila(click2nd) Step direccion 'fila va desde el primer click hasta el segundo, con incremento o de cremento de 1 dependiendo de la direccion (hecha arriba)


            If (fila & columna) <> getPosicion(click1st) And (fila & columna) <> getPosicion(click2nd) Then 'busca en el recorrido todos los picturebox que existan en medio
                'MsgBox(getPosicion(arrayCas(fila, columna)) & ", " & getColor(arrayCas(fila, columna)))
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
                    'MsgBox("hay una ficha en medio")
                    Return False
                End If
            End If

            Select Case getPosicion(click2nd) 'si la posicion de destino coincide con el posible recorrido, la suelta ahi
                Case (fila & columna)
                    Return limite(getColor(click1st), getColor(click2nd))
            End Select


            If columna < getPosicionColumna(click2nd) Then 'si la columna del primer click es menor que la del segundo, se incrementa, si no, se decrementa 
                columna += 1
            Else
                columna -= 1
            End If
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


    Dim ultimoMov As Integer = 0
    Dim ultimoMovF As Integer = 0
    Dim ultimoMovC As Integer = 0
    Private Sub moverClick(click As PictureBox)
        color2nd = click.BackColor

        click.Tag = clicked1st.Tag
        clicked1st.Tag = 0

        'MsgBox(click.Tag)

        click.ImageLocation = clicked1st.ImageLocation
        clicked1st.ImageLocation = Nothing

        clicked1st.BackColor = color1st
        click.BackColor = bgcolorClick2nd
        'click.BackColor = color2nd 'setea el color de fondo al soltar la pieza

        clicked1st = Nothing

        ultimoMov = getPosicion(click)
        ultimoMovF = getPosicionFila(click)
        ultimoMovC = getPosicionColumna(click)
        turno = True
    End Sub



    Dim primerclick As Boolean = True

    Private Sub mover(clicked2nd As PictureBox)
        If (getColor(clicked2nd) <> 0) Then

            If clicked1st Is Nothing Then
                guardarPieza(clicked2nd)
            End If



            'marca el ultimo movimiento
            If ultimoMov <> 0 Then 'si es el primer movimiento de todos, que no haga nada
                arrayCas(ultimoMovF, ultimoMovC).BackColor = color2nd
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
                primerclick = True
                'MsgBox("Selecciona una pieza")
            End If

        End If
    End Sub




    Private Sub colocando(clicked As PictureBox, e As EventArgs)


        'If getColor(clicked) = blanca Then

        '    MsgBox("clickeado a la blanca")

        'ElseIf getColor(clicked) = negra


        '    MsgBox("clickeado a la negra")

        'End If




        If primerclick Then
            'MsgBox("primer click")
            primerclick = False




            If turno Then
                mover(clicked)
            Else
                primerclick = True
            End If


        Else
            'MsgBox("segundo click")
            mover(clicked)
            primerclick = True
        End If

    End Sub

    Private Sub setTablero(x As Integer, y As Integer)

        If x Mod 2 = 0 Then
            arrayCas(x, y).BackColor = colorBlancoTablrero
            If y Mod 2 <> 0 Then
                arrayCas(x, y).BackColor = colorNegroTablero
            End If
        Else
            arrayCas(x, y).BackColor = colorNegroTablero
            If y Mod 2 <> 0 Then
                arrayCas(x, y).BackColor = colorBlancoTablrero
            End If
        End If
    End Sub


    Private Sub reset()

        For x = 0 To 7
            For y = 0 To 7

                arrayCas(x, y).ImageLocation = Nothing
                arrayCas(x, y).Tag = 0

                setTablero(x, y)

                Select Case x
                    Case 0
                        Select Case y
                            Case 0, 7
                                setFigura(arrayCas(x, y), negra, torre)
                            Case 1, 6
                                setFigura(arrayCas(x, y), negra, caballo)
                            Case 2, 5
                                setFigura(arrayCas(x, y), negra, alfil)
                            Case 3
                                setFigura(arrayCas(x, y), negra, reina)
                            Case 4
                                setFigura(arrayCas(x, y), negra, rey)
                        End Select
                    Case 1
                        setFigura(arrayCas(x, y), negra, peon)
                    Case 6
                        setFigura(arrayCas(x, y), blanca, peon)
                    Case 7
                        Select Case y
                            Case 0, 7
                                setFigura(arrayCas(x, y), blanca, torre)
                            Case 1, 6
                                setFigura(arrayCas(x, y), blanca, caballo)
                            Case 2, 5
                                setFigura(arrayCas(x, y), blanca, alfil)
                            Case 3
                                setFigura(arrayCas(x, y), blanca, reina)
                            Case 4
                                setFigura(arrayCas(x, y), blanca, rey)
                        End Select
                End Select

            Next
        Next
    End Sub


    Private Sub ms_nuevapartida_Click(sender As Object, e As EventArgs) Handles ms_archivo_nuevapartida.Click
        If MsgBox("¿Estás seguro que quieres abandonar la partida actual?", MsgBoxStyle.YesNo) <> 7 Then
            reset()
        End If
    End Sub

    Private Sub ms_archivo_salir_Click(sender As Object, e As EventArgs) Handles ms_archivo_salir.Click
        If MsgBox("¿Estás seguro que quieres salir del juego?", MsgBoxStyle.YesNo) <> 7 Then
            End
        End If
    End Sub



    'color de fondo del panel cuando estan las negras en hexadecimal 242424
End Class