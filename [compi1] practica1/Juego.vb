Public Class Juego
    Dim lista_escenarios As List(Of String)
    Dim lista_naves As List(Of String)
    Dim pos_ref As Integer = 3
    Dim pos_refe As Integer = 6
    Dim eleccion As String
    Dim eleccion_naves As String

    Dim fondo_actual As String
    Dim sonido_actual As String

    Dim id_nave As String
    Dim imagen_nave As String
    Dim disparo_nave As String
    Dim sonido_nave As String
    Dim vida_nave As String
    Dim ataque_nave As String

    Dim eligiendo_escenario As Boolean = True
    Dim id_actual As String

    Private Sub Comenzar_Click(sender As Object, e As EventArgs) Handles Comenzar.Click
        btnanterior.Visible = True
        btnanterior.Enabled = False
        btnseleccionar.Visible = True
        btnsiguiente.Visible = True
        PictureBox1.Visible = True
        Comenzar.Visible = False
        primer_escenario()
        Me.Text = "Selecciona un Escenario."
    End Sub

    Private Sub Juego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        Label1.Visible = False
        btnanterior.Visible = False
        btnseleccionar.Visible = False
        lblataque.Visible = False
        lblvida.Visible = False
        btnsiguiente.Visible = False
        lista_escenarios = MyParser.retornar_escenarios()
        lista_naves = MyParser.retornar_naves()
        'primera_nave()

    End Sub

    Private Sub primer_escenario()
        For i As Integer = 0 To 2
            Dim linea As String = lista_escenarios.Item(i)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "fondo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                    'wmp1.Ctlcontrols.pause()
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
            End If
        Next
        If pos_ref > lista_escenarios.Count Then
            btnsiguiente.Enabled = False
        End If
    End Sub

    Private Sub primera_nave()
        For i As Integer = 0 To 5
            Dim linea As String = lista_naves.Item(i)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "imagen") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "disparo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox2.Load(tmp)
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "vida") = 0 Then
                lblvida.Text = "Vida: " + linea_split(1)
            ElseIf String.Compare(linea_split(0), "ataque") = 0 Then
                lblataque.Text = "Ataque: " + linea_split(1)
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
            End If
        Next
        If pos_refe > lista_naves.Count Then
            btnsiguiente.Enabled = False
        End If
    End Sub

    Private Sub btnsiguiente_Click(sender As Object, e As EventArgs) Handles btnsiguiente.Click
        If eligiendo_escenario = True Then
            siguiente_escenario()
        Else
            siguiente_nave()
        End If
    End Sub

    Private Sub siguiente_escenario()
        wmpFondo.Ctlcontrols.stop()
        For posicion As Integer = pos_ref To pos_ref + 2
            Dim linea As String = lista_escenarios.Item(posicion)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "fondo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                    fondo_actual = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    fondo_actual = "vacio"
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                    sonido_actual = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    sonido_actual = "vacio"
                End Try
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
                id_actual = linea_split(1)
            End If
        Next

        pos_ref += 3
        Dim tam As Integer = lista_escenarios.Count - 1
        If tam <= pos_ref Then
            btnsiguiente.Enabled = False
        End If
        btnanterior.Enabled = True
    End Sub

    Private Sub siguiente_nave()
        wmpFondo.Ctlcontrols.stop()
        For posicion As Integer = pos_refe To pos_refe + 5
            Dim linea As String = lista_naves.Item(posicion)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "imagen") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "disparo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox2.Load(tmp)
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "vida") = 0 Then
                lblvida.Text = "Vida: " + linea_split(1)
            ElseIf String.Compare(linea_split(0), "ataque") = 0 Then
                lblataque.Text = "Ataque: " + linea_split(1)
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
            End If
        Next

        pos_refe += 6
        Dim tam As Integer = lista_escenarios.Count - 1
        If tam <= pos_refe Then
            btnsiguiente.Enabled = False
        End If
        btnanterior.Enabled = True
    End Sub

    Private Sub btnanterior_Click(sender As Object, e As EventArgs) Handles btnanterior.Click
        If eligiendo_escenario = True Then
            anterior_escenario()
        Else
            anterior_nave()
        End If
    End Sub

    Private Sub anterior_escenario()
        btnsiguiente.Enabled = True
        wmpFondo.Ctlcontrols.stop()
        For posicion As Integer = (pos_ref - 6) To (pos_ref - 4)
            Dim linea As String = lista_escenarios.Item(posicion)
            'MsgBox("atras: " + linea)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "fondo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                    fondo_actual = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    fondo_actual = "vacio"
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                    sonido_actual = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    sonido_actual = "vacio"
                End Try
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
                id_actual = linea_split(1)
            End If
        Next

        pos_ref -= 6
        If (pos_ref <= 0) Then
            btnanterior.Enabled = False
        End If
    End Sub

    Private Sub anterior_nave()
        btnsiguiente.Enabled = True
        wmpFondo.Ctlcontrols.stop()
        For posicion As Integer = (pos_refe - 12) To (pos_refe - 7)
            Dim linea As String = lista_naves.Item(posicion)
            Dim linea_split() As String = linea.Split(";")
            If String.Compare(linea_split(0), "imagen") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox1.Load(tmp)
                    imagen_nave = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    imagen_nave = "nada"
                End Try
            ElseIf String.Compare(linea_split(0), "disparo") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    PictureBox2.Load(tmp)
                    disparo_nave = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    disparo_nave = "nada"
                End Try
            ElseIf String.Compare(linea_split(0), "sonido") = 0 Then
                Dim tmp As String = linea_split(1).Replace("""", "")
                Try
                    wmpFondo.URL = tmp
                    sonido_nave = tmp
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                    sonido_nave = "nada"
                End Try
            ElseIf String.Compare(linea_split(0), "vida") = 0 Then
                lblvida.Text = "Vida: " + linea_split(1)
                vida_nave = linea_split(1)
            ElseIf String.Compare(linea_split(0), "ataque") = 0 Then
                lblataque.Text = "Ataque: " + linea_split(1)
                ataque_nave = linea_split(1)
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
                id_nave = linea_split(1)
            End If
        Next

        pos_refe -= 12
        If (pos_refe <= 0) Then
            btnanterior.Enabled = False
        End If
        btnsiguiente.Enabled = True
    End Sub

    Private Sub btnseleccionar_Click(sender As Object, e As EventArgs) Handles btnseleccionar.Click
        If eligiendo_escenario = True Then
            eleccion = fondo_actual + ";" + sonido_actual + ";" + id_actual
            eligiendo_escenario = False
            wmpFondo.Ctlcontrols.stop()
            lblataque.Visible = True
            lblvida.Visible = True
            Label1.Visible = True
            PictureBox2.Visible = True
            Me.Text = "Selecciona una Nave."
            primera_nave()
            btnanterior.Enabled = False
            btnsiguiente.Enabled = True
        Else
            wmpFondo.Ctlcontrols.stop()
            eleccion_naves = imagen_nave + ";" + disparo_nave + ";" + sonido_nave + ";" + vida_nave + ";" + ataque_nave + ";" + id_nave
            SpaceInvaders.Show()
            Me.Close()
        End If
    End Sub

    Public Function obtener_eleccion() As String
        Return eleccion
    End Function
    Public Function obtener_nave() As String
        Return eleccion_naves
    End Function
End Class