Imports System.IO
Public Class Form1
    Dim lista_errores_lexicos As List(Of String)
    Dim lista_errores_sintacticos As List(Of String)


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If rtbxcodigo.Text = vbNullString Then
            MessageBox.Show("No hay escrito nada.")
        Else
            MyParser.Setup()
            MyParser.Parse(New StringReader(rtbxcodigo.Text))
            If MyParser.validar_errores() Then
                Button3.Enabled = True
                MsgBox("Hay errores en el codigo." + vbNewLine + "Revisa los errores en ""Ver Errores"".")
            Else
                Button4.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'cargar
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbxcodigo.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        End If


    End Sub
    Private Sub rtbxcodigo_TextChanged(sender As Object, e As EventArgs) Handles rtbxcodigo.TextChanged
        ListBox1.Items.Clear()
        For i As Integer = 0 To rtbxcodigo.Lines.Length
            ListBox1.Items.Add(i)
        Next
    End Sub

    Private Sub rtbxcodigo_SelectionChanged(sender As Object, e As EventArgs) Handles rtbxcodigo.SelectionChanged
        'ListBox1.SelectedItems.Add(rtbxcodigo.GetLineFromCharIndex(rtbxcodigo.SelectionStart) + 1)
        ListBox1.SelectedItems.Add(rtbxcodigo.GetLineFromCharIndex(rtbxcodigo.SelectionStart))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Enabled = False
        ListBox2.Visible = False
        Button3.Enabled = False
        Button4.Enabled = False
        ListBox1.ScrollAlwaysVisible = False
        ListBox1.HorizontalScrollbar = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text.Equals("Ver Errores") Then
            ListBox1.Visible = False
            rtbxcodigo.Visible = False
            Label1.Visible = False
            ListBox2.Visible = True
            Button3.Text = "Regresar"
            cargar_errores()

        Else
            ListBox2.Visible = False
            ListBox2.ClearSelected()
            ListBox1.Visible = True
            Label1.Visible = True
            rtbxcodigo.Visible = True
            Button3.Text = "Ver Errores"
            'ListBox2.Items.Clear()
            lista_errores_lexicos.Clear()
            lista_errores_sintacticos.Clear()

        End If
    End Sub

    Private Sub cargar_errores()
        lista_errores_lexicos = MyParser.retornar_errores_lexicos
        lista_errores_sintacticos = MyParser.retornar_errores_sintacticos

        If lista_errores_lexicos.Count <> 0 Then
            ListBox2.Items.Add("<==== ERRORES LEXICOS ====>")
            For Each e As String In lista_errores_lexicos
                ListBox2.Items.Add(e)
            Next

        End If

        If lista_errores_sintacticos.Count <> 0 Then
            ListBox2.Items.Add("<==== ERRORES SINTACTICOS ====>")
            For Each e As String In lista_errores_sintacticos
                ListBox2.Items.Add(e)
            Next

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MyParser.mo()

    End Sub
End Class
