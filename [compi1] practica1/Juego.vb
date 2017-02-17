Public Class Juego
    Dim lista_escenarios As List(Of String)
    Dim pos_ref As Integer = 3
    Dim eleccion As String
    Dim fondo_actual As String
    Dim sonido_actual As String
    Dim id_actual As String

    Private Sub Comenzar_Click(sender As Object, e As EventArgs) Handles Comenzar.Click
        btnanterior.Visible = True
        btnanterior.Enabled = False
        btnseleccionar.Visible = True
        btnsiguiente.Visible = True
        PictureBox1.Visible = True
        Comenzar.Visible = False
        primer_escenario()
    End Sub

    Private Sub Juego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        btnanterior.Visible = False
        btnseleccionar.Visible = False
        btnsiguiente.Visible = False
        'si llena lista_escenarios
        lista_escenarios = MyParser.retornar_escenarios()
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

    Private Sub btnsiguiente_Click(sender As Object, e As EventArgs) Handles btnsiguiente.Click
        wmpFondo.Ctlcontrols.stop()
        For posicion As Integer = pos_ref To pos_ref + 2
            Dim linea As String = lista_escenarios.Item(posicion)
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
                Catch ex As Exception
                    MsgBox("No existe el archivo que esta en la ruta:" + vbNewLine + tmp)
                End Try
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
            End If
        Next

        pos_ref += 3
        Dim tam As Integer = lista_escenarios.Count - 1
        If tam <= pos_ref Then
            btnsiguiente.Enabled = False
        End If
        btnanterior.Enabled = True
    End Sub

    Private Sub btnanterior_Click(sender As Object, e As EventArgs) Handles btnanterior.Click
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
            ElseIf String.Compare(linea_split(0), "id") = 0 Then
                lbltitulo.Text = linea_split(1)
            End If
        Next

        pos_ref -= 6
        If (pos_ref <= 0) Then
            btnanterior.Enabled = False
        End If
    End Sub

    Private Sub btnseleccionar_Click(sender As Object, e As EventArgs) Handles btnseleccionar.Click

    End Sub
End Class