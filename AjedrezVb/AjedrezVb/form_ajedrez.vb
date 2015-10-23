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

    Dim arrayRecuento(11)


    Dim turno As Boolean = True
    Dim clicked1st As PictureBox = Nothing
    Dim ultimoMov As String = "-1"



    'Asignacion de color del tablero, por si mas adelante queremos modificar el color, asi como poner imagenes de fondo (si fuera posible sin alterar las img de las figuras)
    Dim colorNegroTablero = ColorTranslator.FromHtml("#C6932D")
    Dim colorBlancoTablrero = ColorTranslator.FromHtml("#FEE8B9")

    Dim arrayCas(7, 7) As PictureBox
    Dim arrayTablero(7, 7) As PictureBox


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

        'Carga las imgs del panel para cambiar el peon
        pb_c24.Load(Application.StartupPath & "/img/24.png")
        pb_c22.Load(Application.StartupPath & "/img/22.png")
        pb_c26.Load(Application.StartupPath & "/img/25.png")
        pb_c23.Load(Application.StartupPath & "/img/23.png")
        pb_c14.Load(Application.StartupPath & "/img/14.png")
        pb_c13.Load(Application.StartupPath & "/img/13.png")
        pb_c16.Load(Application.StartupPath & "/img/15.png")
        pb_c12.Load(Application.StartupPath & "/img/12.png")

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

    'Empieza el recuento de fichas comidas, el reseteo, el set de fichas, y el get
    Private Sub resetRecuento()
        For i = 0 To 11
            arrayRecuento(i) = 0
        Next
    End Sub

    Private Sub setRecuento(pieza As PictureBox)
        Select Case getColor(pieza)
            Case blanca

                Select Case getTipo(pieza)
                    Case peon
                        arrayRecuento(0) += 1
                    Case torre
                        arrayRecuento(1) += 1
                    Case caballo
                        arrayRecuento(2) += 1
                    Case alfil
                        arrayRecuento(3) += 1
                    Case rey
                        arrayRecuento(4) += 1
                    Case reina
                        arrayRecuento(5) += 1
                End Select

            Case negra

                Select Case getTipo(pieza)
                    Case peon
                        arrayRecuento(6) += 1
                    Case torre
                        arrayRecuento(7) += 1
                    Case caballo
                        arrayRecuento(8) += 1
                    Case alfil
                        arrayRecuento(9) += 1
                    Case rey
                        arrayRecuento(10) += 1
                    Case reina
                        arrayRecuento(11) += 1
                End Select

        End Select
    End Sub




    Private Function getRecuento(color As Integer, tipo As Integer)
        Select Case color
            Case blanca

                Select Case tipo
                    Case peon
                        Return arrayRecuento(0)
                    Case torre
                        Return arrayRecuento(1)
                    Case caballo
                        Return arrayRecuento(2)
                    Case alfil
                        Return arrayRecuento(3)
                    Case rey
                        Return arrayRecuento(4)
                    Case reina
                        Return arrayRecuento(5)
                End Select

            Case negra

                Select Case tipo
                    Case peon
                        Return arrayRecuento(6)
                    Case torre
                        Return arrayRecuento(7)
                    Case caballo
                        Return arrayRecuento(8)
                    Case alfil
                        Return arrayRecuento(9)
                    Case rey
                        Return arrayRecuento(10)
                    Case reina
                        Return arrayRecuento(11)
                End Select
        End Select

        Return False
    End Function







    Private Sub reset()

        'reseta el recuento de las fichas comidas
        resetRecuento()

        'reseta las figuras mostradas en el panel para cambiar el peon
        resetCambioPeon()

        'reseta el temporizador
        resetTemporizador()
        ms_temporizador.Enabled = True 'muestra la opcion del temporizador

        clicked1st = Nothing
        ultimoMov = "-1"
        turno = True
        primerclick = True

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


        'Resetea el color inicial del panel lateral
        ms_turno_color.BackColor = ColorTranslator.FromHtml("#F8F8F8")
    End Sub


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
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
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
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
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
                If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento
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


    'Function MovTorre(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

    '    If verticales(click1st, click2nd) Or horizontales(click1st, click2nd) Then
    '        Return True
    '    End If

    '    Return False
    'End Function

    Function MovTorre(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If verticales(click1st, click2nd) Or horizontales(click1st, click2nd) Then
            If getPosicion(click1st) = 0 Then
                torremovidaIN = True
            End If
            If getPosicion(click1st) = 7 Then
                torremovidaDN = True
            End If
            If getPosicion(click1st) = 70 Then
                torremovidaIB = True
            End If
            If getPosicion(click1st) = 77 Then
                torremovidaDB = True
            End If
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


    'Function MovRey(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

    '    If vertical(click1st, click2nd) Or horizontal(click1st, click2nd) Or diagonal(click1st, click2nd) Then
    '        Return True
    '    End If

    '    Return False
    'End Function

    Dim reymovidoB As Boolean = False
    Dim reymovidoN As Boolean = False
    Dim torremovidaDB As Boolean = False
    Dim torremovidaIB As Boolean = False
    Dim torremovidaDN As Boolean = False
    Dim torremovidaIN As Boolean = False
    Function MovRey(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)

        If vertical(click1st, click2nd) Or horizontal(click1st, click2nd) Or diagonal(click1st, click2nd) Then
            If click1st.Tag = 16 Then
                reymovidoN = True
            End If
            If click1st.Tag = 26 Then
                reymovidoB = True
            End If
            Return True

        End If
        If enroque(click1st) = 1 And reymovidoB = False And torremovidaDB = False And getPosicion(click2nd) = 76 Then



            Return 1
            ''  arrayCas(7, 4).Tag = 0
            'arrayCas(7, 4).Image = Nothing
            'arrayCas(7, 6).Tag = 26

            'arrayCas(7, 6).Load(Application.StartupPath & "/img/26.png")



        End If
        If enroque(click1st) = 3 And reymovidoN = False And torremovidaDN = False And getPosicion(click2nd) = 6 Then

            Return 3

        End If
        If enroque(click1st) = 2 And reymovidoB = False And torremovidaDN = False And getPosicion(click2nd) = 72 Then

            Return 2

        End If
        If enroque(click1st) = 4 And reymovidoN = False And torremovidaIN = False And getPosicion(click2nd) = 2 Then

            Return 4

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

    Dim color1st As Color
    Dim color2nd As Color


    Private Sub guardarPieza(click As PictureBox)
        clicked1st = click
        colorClicked1st = getColor(clicked1st)
        color1st = clicked1st.BackColor
        clicked1st.BackColor = bgcolorClick1st
    End Sub





    Private Sub moverClick(click As PictureBox)

        If ms_temporizador.Enabled Then
            ms_temporizador.Enabled = False
        End If

        color2nd = click.BackColor

        click.Tag = clicked1st.Tag
        clicked1st.Tag = 0

        click.ImageLocation = clicked1st.ImageLocation
        clicked1st.ImageLocation = Nothing

        clicked1st.BackColor = color1st
        click.BackColor = bgcolorClick2nd

        clicked1st = Nothing

        ultimoMov = click.Name

        If getColor(click) = negra Then
            ms_turno_color.BackColor = ColorTranslator.FromHtml("#F8F8F8")
            If ms_temporizador_nolimite.Checked = False Then
                timer_negras.Stop()
                timer_blancas.Start()
            End If
        End If
        If getColor(click) = blanca Then
            ms_turno_color.BackColor = ColorTranslator.FromHtml("#3F3F3F")
            If ms_temporizador_nolimite.Checked = False Then
                timer_blancas.Stop()
                timer_negras.Start()
            End If
        End If



    End Sub


    Private Function getFilaInt(num As String)
        Return CInt(num.Substring(0, 1))
    End Function
    Private Function getColumnaInt(num As String)
        Return CInt(num.Substring(1, 1))
    End Function


    Dim primerclick As Boolean = True

    Private Sub mover(clicked2nd As PictureBox)
        'Dim mov As PictureBox = clicked2nd


        If (getColor(clicked2nd) <> 0) Then

            If clicked1st Is Nothing Then
                guardarPieza(clicked2nd)
            End If


            'marca el ultimo movimiento
            If ultimoMov <> "-1" Then 'si es el primer movimiento de todos, que no haga nada
                arrayCas(getFilaInt(ultimoMov), getColumnaInt(ultimoMov)).BackColor = color2nd
            End If


            Dim colorClicked2nd As Integer = getColor(clicked2nd)

            'si es del mismo color
            If colorClicked1st = colorClicked2nd Then
                clicked1st.BackColor = color1st 'setea el color que habia antes de fondo
                guardarPieza(clicked2nd)
            Else 'si no, la come
                If comprobador(clicked1st, clicked2nd) Then

                    setRecuento(clicked2nd)

                    If getRecuento(blanca, rey) = 1 Then
                        If MsgBox("Gana el jugador2, ¿desea la revancha?", MsgBoxStyle.YesNo) <> 7 Then
                            reset()
                            Exit Sub
                        Else
                            End
                        End If
                    ElseIf getRecuento(negra, rey) = 1 Then
                        If MsgBox("Gana el jugador 1, ¿desea la revancha?", MsgBoxStyle.YesNo) <> 7 Then
                            reset()
                            Exit Sub
                        Else
                            End
                        End If
                    End If

                    moverClick(clicked2nd)
                    setCambioPeon(clicked2nd)

                End If
            End If

        Else

            If clicked1st IsNot Nothing Then 'si el en el segundo click no hay nada, la mueve libremente
                Select Case comprobador(clicked1st, clicked2nd)
                    Case True
                        moverClick(clicked2nd)
                        setCambioPeon(clicked2nd)

                    Case 1
                        moverClick(clicked2nd)
                        arrayCas(7, 7).Tag = 0
                        arrayCas(7, 7).Image = Nothing
                        arrayCas(7, 5).Tag = 22
                        arrayCas(7, 5).Load(Application.StartupPath & "/img/22.png")
                    Case 2
                        moverClick(clicked2nd)
                        arrayCas(7, 0).Tag = 0
                        arrayCas(7, 0).Image = Nothing
                        arrayCas(7, 3).Tag = 22
                        arrayCas(7, 3).Load(Application.StartupPath & "/img/22.png")
                    Case 3
                        moverClick(clicked2nd)
                        arrayCas(0, 7).Tag = 0
                        arrayCas(0, 7).Image = Nothing
                        arrayCas(0, 5).Tag = 12
                        arrayCas(0, 5).Load(Application.StartupPath & "/img/12.png")
                    Case 4
                        moverClick(clicked2nd)
                        arrayCas(0, 0).Tag = 0
                        arrayCas(0, 0).Image = Nothing
                        arrayCas(0, 3).Tag = 12

                        arrayCas(0, 3).Load(Application.StartupPath & "/img/12.png")

                End Select





            Else
                primerclick = True
                'MsgBox("Selecciona una pieza")
            End If

        End If
    End Sub


    Private Sub colocando(clicked As PictureBox, e As EventArgs)

        If cambiandoPeon = False Then

            If primerclick Then
                primerclick = False


                If turno Then
                    If getColor(clicked) = blanca Then
                        mover(clicked)
                        turno = False
                    Else
                        'MsgBox("Mueve una figura blanca!")
                        primerclick = True
                    End If

                Else

                    If getColor(clicked) = negra Then
                        mover(clicked)
                        turno = True
                    Else
                        'MsgBox("Mueve una figura negra!")
                        primerclick = True
                    End If
                End If


            Else

                primerclick = True

                If getColor(clicked) = blanca And getColor(clicked1st) = blanca Then
                    turno = False
                    primerclick = False
                End If

                If getColor(clicked) = negra And getColor(clicked1st) = negra Then
                    turno = True
                    primerclick = False
                End If

                If comprobador(clicked1st, clicked) = False Then
                    primerclick = False
                End If

                mover(clicked)
            End If

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


    Private Sub ms_nuevapartida_Click(sender As Object, e As EventArgs) Handles ms_archivo_nuevapartida.Click
        If MsgBox("¿Seguro que quieres abandonar la partida actual?", MsgBoxStyle.YesNo, "Nueva partida") <> 7 Then
            reset()
        End If
    End Sub


    Private Sub ms_archivo_salir_Click(sender As Object, e As EventArgs) Handles ms_archivo_salir.Click
        If MsgBox("¿Seguro que quieres salir del juego?", MsgBoxStyle.YesNo, "Salir del juego") <> 7 Then
            End
        End If
    End Sub


    Private Function temporizador(tiempoText As String)
        Dim min = CInt(tiempoText.Substring(0, 2))
        Dim seg = CInt(tiempoText.Substring(3, 2))

        Dim comodinMin As String = "0"
        Dim comodinSeg As String = "0"


        If seg = 0 Then
            seg = 60
            min -= 1
        End If

        seg -= 1

        If seg >= 10 Then
            comodinSeg = ""
        End If
        If min >= 10 Then
            comodinMin = ""
        End If

        If min = 0 And seg = 0 Then
            timer_blancas.Stop()
            timer_negras.Stop()

            If MsgBox("Has perdido, ¿quieres la revancha?", MsgBoxStyle.YesNo, "¡TIEMPO!") <> 7 Then
                reset()
            Else
                End
            End If
        End If


        Return comodinMin & min & ":" & comodinSeg & seg

    End Function


    Private Sub ms_temporizador_limite_5_Click(sender As Object, e As EventArgs) Handles ms_temporizador_limite_5.Click

        lbl_contador_blancas.Text = "05:00"
        lbl_contador_negras.Text = "05:00"
        ms_temporizador_limite_5.Checked = True
        ms_temporizador_limite_10.Checked = False
        ms_temporizador_nolimite.Checked = False

        lbl_contador_blancas.ForeColor = System.Drawing.Color.Silver
        lbl_contador_negras.ForeColor = System.Drawing.Color.Silver

    End Sub

    Private Sub ms_temporizador_limite_10_Click(sender As Object, e As EventArgs) Handles ms_temporizador_limite_10.Click

        lbl_contador_blancas.Text = "10:00"
        lbl_contador_negras.Text = "10:00"
        ms_temporizador_limite_10.Checked = True
        ms_temporizador_limite_5.Checked = False
        ms_temporizador_nolimite.Checked = False

        lbl_contador_blancas.ForeColor = System.Drawing.Color.Silver
        lbl_contador_negras.ForeColor = System.Drawing.Color.Silver

    End Sub
    Private Sub timer_blancas_Tick(sender As Object, e As EventArgs) Handles timer_blancas.Tick

        lbl_contador_negras.ForeColor = ColorTranslator.FromHtml("#AAAAAA")

        If CInt(lbl_contador_blancas.Text.Substring(0, 2)) < 2 Then
            lbl_contador_blancas.ForeColor = ColorTranslator.FromHtml("#BE432D")
        Else
            lbl_contador_blancas.ForeColor = ColorTranslator.FromHtml("#666666")
        End If

        lbl_contador_blancas.Text = temporizador(lbl_contador_blancas.Text)

    End Sub

    Private Sub timer_negras_Tick(sender As Object, e As EventArgs) Handles timer_negras.Tick

        lbl_contador_blancas.ForeColor = ColorTranslator.FromHtml("#AAAAAA")


        If CInt(lbl_contador_negras.Text.Substring(0, 2)) < 2 Then
            lbl_contador_negras.ForeColor = ColorTranslator.FromHtml("#BE432D")
        Else
            lbl_contador_negras.ForeColor = ColorTranslator.FromHtml("#666666")
        End If

        lbl_contador_negras.Text = temporizador(lbl_contador_negras.Text)

    End Sub

    Private Sub resetTemporizador()
        timer_blancas.Stop()
        timer_negras.Stop()


        lbl_contador_blancas.Text = "00:00"
        lbl_contador_negras.Text = "00:00"

        lbl_contador_blancas.ForeColor = ColorTranslator.FromHtml("#E5E5E5")
        lbl_contador_negras.ForeColor = ColorTranslator.FromHtml("#E5E5E5")

        ms_temporizador_limite_5.Checked = False
        ms_temporizador_limite_10.Checked = False
        ms_temporizador_nolimite.Checked = True
    End Sub

    Private Sub ms_temporizador_nolimite_Click(sender As Object, e As EventArgs) Handles ms_temporizador_nolimite.Click

        resetTemporizador()

    End Sub

    Private Sub ms_principal_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ms_principal.ItemClicked
        timer_blancas.Stop()
        timer_negras.Stop()
    End Sub



    'CAMBIO DE PEON
    Dim settingCambioPeon As PictureBox
    Dim cambiandoPeon As Boolean = False


    Private Sub setVisibleCambioPeonBlancas()
        Dim setColor = ColorTranslator.FromHtml("#222222")

        pb_c24.BackColor = setColor
        pb_c23.BackColor = setColor
        pb_c22.BackColor = setColor
        pb_c26.BackColor = setColor

        pb_c24.Visible = True
        pb_c23.Visible = True
        pb_c22.Visible = True
        pb_c26.Visible = True

    End Sub


    Private Sub setVisibleCambioPeonNegras()
        Dim setColor = ColorTranslator.FromHtml("#FFFFFF")

        pb_c14.BackColor = setColor
        pb_c13.BackColor = setColor
        pb_c12.BackColor = setColor
        pb_c16.BackColor = setColor

        pb_c14.Visible = True
        pb_c13.Visible = True
        pb_c12.Visible = True
        pb_c16.Visible = True

    End Sub


    Private Sub resetCambioPeon()
        Dim setColor = Color.Transparent

        pb_c24.Visible = False
        pb_c23.Visible = False
        pb_c22.Visible = False
        pb_c26.Visible = False

        pb_c14.Visible = False
        pb_c13.Visible = False
        pb_c12.Visible = False
        pb_c16.Visible = False


        pb_c24.BackColor = setColor
        pb_c23.BackColor = setColor
        pb_c22.BackColor = setColor
        pb_c26.BackColor = setColor

        pb_c14.BackColor = setColor
        pb_c13.BackColor = setColor
        pb_c12.BackColor = setColor
        pb_c16.BackColor = setColor

        cambiandoPeon = False
    End Sub


    Private Sub doCambioPeon(pieza As Integer)
        settingCambioPeon.Tag = pieza

        Dim fila As Integer = getPosicionFila(settingCambioPeon)
        Dim columna As Integer = getPosicionColumna(settingCambioPeon)

        arrayCas(fila, columna).Load(Application.StartupPath & "/img/" & pieza & ".png")

        resetCambioPeon()
    End Sub


    Private Sub setCambioPeon(ByRef piezaClicked2nd As PictureBox)
        settingCambioPeon = piezaClicked2nd

        If getPosicionFila(piezaClicked2nd) = 0 And piezaClicked2nd.Tag = 21 Then
            setVisibleCambioPeonBlancas()
            cambiandoPeon = True
        ElseIf getPosicionFila(piezaClicked2nd) = 7 And piezaClicked2nd.Tag = 11 Then
            setVisibleCambioPeonNegras()
            cambiandoPeon = True
        End If


    End Sub


    Private Sub pb_pb_torre_Click(sender As Object, e As EventArgs) Handles pb_c22.Click
        doCambioPeon(22)
    End Sub

    Private Sub pb_pb_caballo_Click(sender As Object, e As EventArgs) Handles pb_c23.Click
        doCambioPeon(23)
    End Sub

    Private Sub pb_pb_alfil_Click(sender As Object, e As EventArgs) Handles pb_c24.Click
        doCambioPeon(24)
    End Sub
    Sub pb_pb_reina_Click(sender As Object, e As EventArgs) Handles pb_c26.Click
        doCambioPeon(25)
    End Sub

    Private Sub pb_pn_torre_Click(sender As Object, e As EventArgs) Handles pb_c12.Click
        doCambioPeon(12)
    End Sub

    Private Sub pb_pn_caballo_Click(sender As Object, e As EventArgs) Handles pb_c13.Click
        doCambioPeon(13)
    End Sub

    Private Sub pb_pn_alfil_Click(sender As Object, e As EventArgs) Handles pb_c14.Click
        doCambioPeon(14)
    End Sub
    Private Sub pb_pn_reina_Click(sender As Object, e As EventArgs) Handles pb_c16.Click
        doCambioPeon(15)
    End Sub





    'ENROQUE


    Function enroque(ByVal click1 As PictureBox)

        If arrayCas(7, 6).Tag = 0 And arrayCas(7, 5).Tag = 0 Then
            Return 1
        End If
        If arrayCas(7, 3).Tag = 0 And arrayCas(7, 2).Tag = 0 And arrayCas(7, 1).Tag = 0 Then
            Return 2
        End If
        If arrayCas(0, 6).Tag = 0 And arrayCas(0, 5).Tag = 0 Then
            Return 3
        End If
        If arrayCas(0, 3).Tag = 0 And arrayCas(0, 2).Tag = 0 And arrayCas(0, 1).Tag = 0 Then
            Return 4
        End If

    End Function











End Class