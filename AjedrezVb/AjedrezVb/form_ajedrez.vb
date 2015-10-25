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
    Dim colorBlancoTablero = ColorTranslator.FromHtml("#FEE8B9")

    Dim arrayCas(7, 7) As PictureBox
    Dim arrayTablero(7, 7) As Color


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
    Private Sub setFigura(ByVal obj As PictureBox, color As Integer, tipo As Integer)
        obj.Tag = color & tipo
        obj.Load(Application.StartupPath & "/img/" & color & tipo & ".png")
    End Sub


    Private Sub borrarPieza(ByVal obj As PictureBox)
        Dim casillaClick As PictureBox = arrayCas(getPosicionFila(obj), getPosicionColumna(obj))
        casillaClick.Tag = 0
        casillaClick.Image = Nothing
        casillaClick.BackColor = arrayTablero(getPosicionFila(obj), getPosicionColumna(obj))
    End Sub


    Private Function getColor(ByVal obj As PictureBox)
        Return CInt(CStr(obj.Tag).Substring(0, 1))
    End Function


    Private Function getTipo(ByVal obj As PictureBox)
        Return CInt(CStr(obj.Tag).Substring(1, 1))
    End Function


    Private Function getPosicion(ByVal obj As PictureBox)
        Return CInt(obj.Name.Substring(0, 2))
    End Function


    Private Function getPosicionFila(ByVal obj As PictureBox)
        Return CInt(obj.Name.Substring(0, 1))
    End Function


    Private Function getPosicionColumna(ByVal obj As PictureBox)
        Return CInt(obj.Name.Substring(1, 1))
    End Function


    'Empieza el recuento de fichas comidas, el reseteo, el set de fichas, y el get
    Private Sub resetRecuento()
        For i = 0 To 11
            arrayRecuento(i) = 0
        Next
    End Sub


    Private Sub setRecuento(ByVal pieza As PictureBox)
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


    Private Function getRecuento(ByVal color As Integer, ByVal tipo As Integer)
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

        'resetea el enroque
        resetEnroque()

        clicked1st = Nothing
        ultimoMov = "-1"
        turno = True
        primerclick = True

        For x = 0 To 7
            For y = 0 To 7

                arrayCas(x, y).Image = Nothing
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


    Private Function MovPeon(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        Dim normal As Integer = 0
        Dim doble As Integer = 0

        Select Case getColor(click1st)
            Case blanca
                If getPosicionFila(click1st) = 6 Then
                    doble = -2
                End If
                normal = -1
            Case negra
                If getPosicionFila(click1st) = 1 Then
                    doble = +2
                End If
                normal = +1
        End Select

        Dim paso As PictureBox = arrayCas(getPosicionFila(click1st) + normal, getPosicionColumna(click1st))
        Dim pasos As PictureBox = arrayCas(getPosicionFila(click1st) + doble, getPosicionColumna(click1st))

        Select Case getPosicion(click2nd)
            'paso para alante simple
            Case getPosicion(paso)
                If getColor(paso) = 0 Then
                    Return limite(getColor(click1st), getColor(click2nd))
                End If
            'paso para alante doble
            Case getPosicion(pasos)
                If getColor(paso) = 0 And getColor(pasos) = 0 Then
                    Return limite(getColor(click1st), getColor(click2nd))
                End If
            'comiendo
            Case getPosicion(paso) - 1, getPosicion(paso) + 1
                If getColor(click2nd) <> 0 Then
                    Return limite(getColor(click1st), getColor(click2nd))
                End If
        End Select

        Return False
    End Function


    Private Function MovTorre(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        If verticales(click1st, click2nd) Or horizontales(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function


    'JAQUE OFENSIVO
    Private Sub infoJaque()
        MsgBox("Movimiento de Jaque", MsgBoxStyle.OkOnly, "¡ATENCIÓN!")
    End Sub


    Private Sub checkJaquePeon(ByVal click As PictureBox)
        Dim columna = getPosicionColumna(click)
        Dim fila = getPosicionFila(click)

        Dim normal As Integer = 0
        Dim avance As Integer = -1

        Select Case getColor(click)
            Case blanca
                normal = -1
            Case negra
                normal = +1
        End Select

        For i As Integer = 0 To 1
            Try
                Dim paso As PictureBox = arrayCas(fila + normal, columna + avance)

                If getTipo(paso) = rey And getColor(click) <> getColor(paso) Then
                    infoJaque()
                    Exit For
                End If

                avance = +1
            Catch ex As Exception
                Exit Sub
            End Try
        Next
    End Sub


    Private Sub checkJaqueDiagonales(ByVal click As PictureBox)
        Dim posicion = getPosicion(click)
        Dim columna = getPosicionColumna(click)

        Dim direccion As Integer = 0
        Dim fin As Integer = 0

        For i As Integer = 0 To 3

            Select Case i
                Case 0, 1
                    fin = 0
                    direccion = -1
                Case 2, 3
                    fin = 7
                    direccion = +1
            End Select

            For fila = getPosicionFila(click) To fin Step direccion
                Try
                    If (fila & columna) <> posicion Then 'busca sin contar la posicion de la ficha
                        If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento

                            If getTipo(arrayCas(fila, columna)) = rey And getColor(click) <> getColor(arrayCas(fila, columna)) Then
                                arrayCas(fila, columna).BackColor = ColorTranslator.FromHtml("#D92E2E")
                                infoJaque()
                                arrayCas(fila, columna).BackColor = arrayTablero(fila, columna)
                                Exit Sub
                            End If

                            Exit For
                        End If
                    End If


                    Select Case i
                        Case 0, 3
                            columna -= 1
                        Case 1, 2
                            columna += 1
                    End Select

                Catch ex As Exception 'si se sale del tablero sale del for
                    Exit For
                End Try
            Next

            columna = getPosicionColumna(click)
        Next
    End Sub


    Private Sub checkJaqueVerticales(ByVal click As PictureBox)
        Dim posicion = getPosicion(click)
        Dim columna = getPosicionColumna(click)

        Dim direccion As Integer = 0
        Dim fin As Integer = 0

        For i As Integer = 0 To 1

            Select Case i
                Case 0
                    fin = 0
                    direccion = -1
                Case 1
                    fin = 7
                    direccion = +1
            End Select

            For fila = getPosicionFila(click) To fin Step direccion

                Try
                    If (fila & columna) <> posicion Then 'busca sin contar la posicion de la ficha
                        If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento

                            If getTipo(arrayCas(fila, columna)) = rey And getColor(click) <> getColor(arrayCas(fila, columna)) Then
                                arrayCas(fila, columna).BackColor = ColorTranslator.FromHtml("#D92E2E")
                                infoJaque()
                                arrayCas(fila, columna).BackColor = arrayTablero(fila, columna)
                                Exit Sub
                            End If

                            Exit For
                        End If
                    End If


                Catch ex As Exception
                    Exit For
                End Try
            Next

        Next
    End Sub


    Private Sub checkJaqueHorizontales(ByVal click As PictureBox)
        Dim posicion = getPosicion(click)
        Dim fila = getPosicionFila(click)

        Dim direccion As Integer = 0
        Dim fin As Integer = 0

        For i As Integer = 0 To 1

            Select Case i
                Case 0
                    fin = 0
                    direccion = -1
                Case 1
                    fin = 7
                    direccion = +1
            End Select

            For columna = getPosicionColumna(click) To fin Step direccion

                Try
                    If (fila & columna) <> posicion Then 'busca sin contar la posicion de la ficha
                        If getColor(arrayCas(fila, columna)) <> 0 Then 'si ve que hay algo en el recorrido devuelve false y acaba el movimiento

                            If getTipo(arrayCas(fila, columna)) = rey And getColor(click) <> getColor(arrayCas(fila, columna)) Then
                                arrayCas(fila, columna).BackColor = ColorTranslator.FromHtml("#D92E2E")
                                infoJaque()
                                arrayCas(fila, columna).BackColor = arrayTablero(fila, columna)
                                Exit Sub
                            End If

                            Exit For
                        End If
                    End If


                Catch ex As Exception
                    Exit For
                End Try
            Next

        Next
    End Sub


    Private Sub checkJaqueCaballo(ByVal click As PictureBox)
        Dim posicion As Integer = getPosicion(click)
        Dim fila = getPosicionFila(click)
        Dim columna = getPosicionColumna(click)

        For i As Integer = 0 To 7 Step +1
            Select Case i
                Case 0
                    fila += 1
                    columna -= 2
                Case 1
                    fila += 1
                    columna += 2
                Case 2
                    fila += 2
                    columna -= 1
                Case 3
                    fila += 2
                    columna += 1
                Case 4
                    fila -= 1
                    columna -= 2
                Case 5
                    fila -= 1
                    columna += 2
                Case 6
                    fila -= 2
                    columna += 1
                Case 7
                    fila -= 2
                    columna -= 1
            End Select

            Try
                If getPosicion(arrayCas(fila, columna)) <> posicion Then 'busca sin contar la posicion de la ficha

                    If getTipo(arrayCas(fila, columna)) = rey And getColor(click) <> getColor(arrayCas(fila, columna)) Then
                        arrayCas(fila, columna).BackColor = ColorTranslator.FromHtml("#D92E2E")
                        infoJaque()
                        arrayCas(fila, columna).BackColor = arrayTablero(fila, columna)
                        Exit Sub
                    End If

                End If
            Catch ex As Exception
                'Exit Sub
            End Try

            fila = getPosicionFila(click)
            columna = getPosicionColumna(click)
        Next
    End Sub


    'ENROQUE
    Dim arrayCheckMovido(5) As Boolean '0 rey blanco, 1 rey negro, 2 y 3 torres blancas, 4 y 5 torres negras


    Private Sub resetEnroque()
        For i = 0 To 5
            arrayCheckMovido(i) = False
        Next
    End Sub


    Private Function doEnroque(ByVal click2nd As PictureBox)
        If arrayCheckMovido(0) = False Then
            If arrayCheckMovido(2) = False And getPosicion(click2nd) = 71 Then
                For i = 3 To 2 Step -1
                    If getColor(arrayCas(7, i)) <> 0 Then
                        Return False
                    End If
                    borrarPieza(arrayCas(7, 0))
                    setFigura(arrayCas(7, 2), blanca, torre)
                    Return True
                Next
            End If
            If arrayCheckMovido(3) = False And getPosicion(click2nd) = 76 Then
                If getColor(arrayCas(7, 5)) <> 0 Then
                    Return False
                End If
                borrarPieza(arrayCas(7, 7))
                setFigura(arrayCas(7, 5), blanca, torre)
                Return True
            End If
        End If

        If arrayCheckMovido(1) = False Then
            If arrayCheckMovido(4) = False And getPosicion(click2nd) = 1 Then
                For i = 3 To 2 Step -1
                    If getColor(arrayCas(0, i)) <> 0 Then
                        Return False
                    End If
                    borrarPieza(arrayCas(0, 0))
                    setFigura(arrayCas(0, 2), negra, torre)
                    Return True
                Next
            End If
            If arrayCheckMovido(5) = False And getPosicion(click2nd) = 6 Then
                If getColor(arrayCas(0, 5)) <> 0 Then
                    Return False
                End If
                borrarPieza(arrayCas(0, 7))
                setFigura(arrayCas(0, 5), negra, torre)
                Return True
            End If
        End If

        Return False
    End Function


    Private Function MovCaballo(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
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


    Private Function MovAlfil(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        Return diagonales(click1st, click2nd)
    End Function


    Private Function MovReina(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        If verticales(click1st, click2nd) OrElse diagonales(click1st, click2nd) OrElse horizontales(click1st, click2nd) Then
            Return True
        End If

        Return False
    End Function


    Private Function MovRey(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
        If vertical(click1st, click2nd) Or horizontal(click1st, click2nd) Or diagonal(click1st, click2nd) Or doEnroque(click2nd) Then
            Return True
        End If

        Return False
    End Function


    'Comprueba que se ha seleccionado una figura
    Private Function comprobador(ByVal click1st As PictureBox, ByVal click2nd As PictureBox)
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


    Private Sub guardarPieza(ByVal click As PictureBox)
        clicked1st = click
        clicked1st.BackColor = bgcolorClick1st
    End Sub


    Private Sub moviendo(click As PictureBox)
        If ms_temporizador.Enabled Then
            ms_temporizador.Enabled = False
        End If

        'seteando el segundo click con los datos del primero, el efecto de mover
        click.Tag = clicked1st.Tag
        click.Image = clicked1st.Image
        click.BackColor = bgcolorClick2nd

        ultimoMov = click.Name

        If getColor(click) = negra Then
            Select Case getTipo(click)
                Case rey
                    arrayCheckMovido(1) = True
                Case torre And getPosicion(clicked1st) = 0
                    arrayCheckMovido(4) = True
                Case torre And getPosicion(clicked1st) = 7
                    arrayCheckMovido(5) = True
            End Select

            ms_turno_color.BackColor = ColorTranslator.FromHtml("#F8F8F8")
            If ms_temporizador_nolimite.Checked = False Then
                lbl_contador_blancas.Text = temporizadorIncremento(lbl_contador_blancas.Text)
                timer_negras.Stop()
                timer_blancas.Start()

                If panel_pause.Image Is Nothing Then
                    panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
                End If

            End If
        End If

        If getColor(click) = blanca Then
            Select Case getTipo(click)
                Case rey
                    arrayCheckMovido(0) = True
                'MsgBox("rey blanco movido")
                Case torre
                    If getPosicion(clicked1st) = 70 Then
                        arrayCheckMovido(2) = True
                        'MsgBox("torre blanca izquierda movida")
                    ElseIf getPosicion(clicked1st) = 77
                        arrayCheckMovido(3) = True
                        'MsgBox("torre blanca derecha movida")
                    End If
            End Select

            ms_turno_color.BackColor = ColorTranslator.FromHtml("#3F3F3F")
            If ms_temporizador_nolimite.Checked = False Then
                lbl_contador_negras.Text = temporizadorIncremento(lbl_contador_negras.Text)
                timer_blancas.Stop()
                timer_negras.Start()

                If panel_pause.Image Is Nothing Then
                    panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
                End If

            End If
        End If


        borrarPieza(clicked1st)
        clicked1st = Nothing
    End Sub


    Private Function getFilaInt(ByVal num As String)
        Return CInt(num.Substring(0, 1))
    End Function


    Private Function getColumnaInt(ByVal num As String)
        Return CInt(num.Substring(1, 1))
    End Function


    Private Sub doJaque(ByVal obj As PictureBox)
        Select Case getTipo(obj)
            Case alfil
                checkJaqueDiagonales(obj)
            Case reina
                checkJaqueVerticales(obj)
                checkJaqueHorizontales(obj)
                checkJaqueDiagonales(obj)
            Case torre
                checkJaqueVerticales(obj)
                checkJaqueHorizontales(obj)
            Case caballo
                checkJaqueCaballo(obj)
            Case peon
                checkJaquePeon(obj)
        End Select
    End Sub


    Dim primerclick As Boolean = True

    Private Sub mover(ByVal clicked As PictureBox)
        If clicked1st Is Nothing Then

            If getColor(clicked) <> 0 Then
                guardarPieza(clicked)
                primerclick = False
                Exit Sub
            Else
                primerclick = True
                clicked1st = Nothing
            End If

        Else
            'marca el ultimo movimiento
            If ultimoMov <> "-1" Then 'si es el primer movimiento de todos, que no haga nada
                arrayCas(getFilaInt(ultimoMov), getColumnaInt(ultimoMov)).BackColor = arrayTablero(getFilaInt(ultimoMov), getColumnaInt(ultimoMov))
            End If

            If getColor(clicked) <> 0 Then 'si el segundo click esta ocupado mira si es del mismo color, o no

                If getColor(clicked1st) = getColor(clicked) Then 'si son del mismo equipo
                    clicked1st.BackColor = getColorTablero(clicked1st) 'setea el color de la casilla
                    clicked1st = Nothing 'borra el objeto de la pieza guardada
                    guardarPieza(clicked) 'vuelve a guardar la pieza clickeada

                Else 'si no, se la come (borra la pieza y pone la guardada ahi)

                    If comprobador(clicked1st, clicked) Then 'comprueba si el movimiento es correcto, y si es correcto:

                        setRecuento(clicked)

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

                        moviendo(clicked)
                        doJaque(clicked)
                        setCambioPeon(clicked)
                    Else
                        primerclick = False
                    End If

                End If

            Else 'si no esta ocupada, mueve la pieza sin hacer nada mas
                If comprobador(clicked1st, clicked) Then 'comprueba si el movimiento es correcto, y si es correcto:
                    moviendo(clicked)
                    doJaque(clicked)
                    setCambioPeon(clicked)
                Else
                    primerclick = False
                End If
            End If

        End If
    End Sub


    Private Function getColorTablero(ByVal obj As PictureBox)
        Return arrayTablero(getPosicionFila(obj), getPosicionColumna(obj))
    End Function


    Private Sub colocando(ByVal clicked As PictureBox, e As EventArgs)
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

                mover(clicked)
            End If

        End If
    End Sub


    Private Sub setTablero(ByVal x As Integer, ByVal y As Integer)
        If x Mod 2 = 0 Then
            arrayCas(x, y).BackColor = colorBlancoTablero
            arrayTablero(x, y) = colorBlancoTablero
            If y Mod 2 <> 0 Then
                arrayCas(x, y).BackColor = colorNegroTablero
                arrayTablero(x, y) = colorNegroTablero
            End If
        Else
            arrayCas(x, y).BackColor = colorNegroTablero
            arrayTablero(x, y) = colorNegroTablero
            If y Mod 2 <> 0 Then
                arrayCas(x, y).BackColor = colorBlancoTablero
                arrayTablero(x, y) = colorBlancoTablero
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


    Private Function temporizador(ByVal tiempoText As String)
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


    Private Function temporizadorIncremento(ByVal tiempoText As String)
        Dim min = CInt(tiempoText.Substring(0, 2))
        Dim seg = CInt(tiempoText.Substring(3, 2))

        Dim comodinMin As String = "0"
        Dim comodinSeg As String = "0"

        seg += 5

        If seg > 60 Then
            seg -= 60
            min += 1
        End If

        If seg >= 10 Then
            comodinSeg = ""
        End If
        If min >= 10 Then
            comodinMin = ""
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

        panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
    End Sub


    Private Sub ms_temporizador_limite_10_Click(sender As Object, e As EventArgs) Handles ms_temporizador_limite_10.Click
        lbl_contador_blancas.Text = "10:00"
        lbl_contador_negras.Text = "10:00"
        ms_temporizador_limite_10.Checked = True
        ms_temporizador_limite_5.Checked = False
        ms_temporizador_nolimite.Checked = False

        lbl_contador_blancas.ForeColor = System.Drawing.Color.Silver
        lbl_contador_negras.ForeColor = System.Drawing.Color.Silver

        panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
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

        panel_pause.Image = Nothing

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

        panel_pause.Image = Nothing
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


    Private Sub doCambioPeon(ByVal pieza As Integer)
        settingCambioPeon.Tag = pieza

        Dim fila As Integer = getPosicionFila(settingCambioPeon)
        Dim columna As Integer = getPosicionColumna(settingCambioPeon)

        arrayCas(fila, columna).Load(Application.StartupPath & "/img/" & pieza & ".png")

        If ms_temporizador_nolimite.Checked = False Then
            If getColor(arrayCas(fila, columna)) = blanca Then
                timer_negras.Start()
                panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
            ElseIf getColor(arrayCas(fila, columna)) = negra Then
                timer_blancas.Start()
                panel_pause.Load(Application.StartupPath & "/img/panel_pause.png")
            End If
        End If

        resetCambioPeon()
    End Sub


    Private Sub setCambioPeon(ByVal piezaClicked2nd As PictureBox)
        settingCambioPeon = piezaClicked2nd

        If getPosicionFila(piezaClicked2nd) = 0 And piezaClicked2nd.Tag = 21 Then
            setVisibleCambioPeonBlancas()
            If ms_temporizador_nolimite.Checked = False Then
                timer_negras.Stop()

                panel_pause.Image = Nothing
            End If
            cambiandoPeon = True
        ElseIf getPosicionFila(piezaClicked2nd) = 7 And piezaClicked2nd.Tag = 11 Then
            setVisibleCambioPeonNegras()
            If ms_temporizador_nolimite.Checked = False Then
                timer_blancas.Stop()

                panel_pause.Image = Nothing
            End If
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

    Private Sub panel_pause_Click(sender As Object, e As EventArgs) Handles panel_pause.Click
        timer_blancas.Stop()
        timer_negras.Stop()

        panel_pause.Image = Nothing
    End Sub

End Class