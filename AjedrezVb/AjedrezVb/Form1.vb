Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer 'posicion en x
        Dim y As Integer 'posicion en y



        For i = 0 To 7 'i --> recorre x

            For j = 0 To 7 'j --> recorre y

                Dim casilla As New PictureBox

                With casilla

                    .Name = "Casilla" & i & j
                    .Size = New System.Drawing.Size(100, 100)
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


                    Me.Controls.Add(casilla)


                End With


                x += 100

            Next
            x = 0
            y += 100

        Next



    End Sub
End Class
