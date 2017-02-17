<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Juego
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Juego))
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.Comenzar = New System.Windows.Forms.Button()
        Me.btnanterior = New System.Windows.Forms.Button()
        Me.btnseleccionar = New System.Windows.Forms.Button()
        Me.btnsiguiente = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.wmpFondo = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wmpFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.White
        Me.lbltitulo.Location = New System.Drawing.Point(191, 28)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(167, 25)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "Space Invaders"
        '
        'Comenzar
        '
        Me.Comenzar.Location = New System.Drawing.Point(208, 204)
        Me.Comenzar.Name = "Comenzar"
        Me.Comenzar.Size = New System.Drawing.Size(150, 66)
        Me.Comenzar.TabIndex = 1
        Me.Comenzar.Text = "Comenzar"
        Me.Comenzar.UseVisualStyleBackColor = True
        '
        'btnanterior
        '
        Me.btnanterior.Location = New System.Drawing.Point(112, 420)
        Me.btnanterior.Name = "btnanterior"
        Me.btnanterior.Size = New System.Drawing.Size(75, 23)
        Me.btnanterior.TabIndex = 3
        Me.btnanterior.Text = "Anterior"
        Me.btnanterior.UseVisualStyleBackColor = True
        '
        'btnseleccionar
        '
        Me.btnseleccionar.Location = New System.Drawing.Point(251, 420)
        Me.btnseleccionar.Name = "btnseleccionar"
        Me.btnseleccionar.Size = New System.Drawing.Size(75, 23)
        Me.btnseleccionar.TabIndex = 4
        Me.btnseleccionar.Text = "Seleccionar"
        Me.btnseleccionar.UseVisualStyleBackColor = True
        '
        'btnsiguiente
        '
        Me.btnsiguiente.Location = New System.Drawing.Point(400, 420)
        Me.btnsiguiente.Name = "btnsiguiente"
        Me.btnsiguiente.Size = New System.Drawing.Size(75, 23)
        Me.btnsiguiente.TabIndex = 5
        Me.btnsiguiente.Text = "Siguiente"
        Me.btnsiguiente.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(58, 71)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(446, 343)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'wmpFondo
        '
        Me.wmpFondo.Enabled = True
        Me.wmpFondo.Location = New System.Drawing.Point(429, 12)
        Me.wmpFondo.Name = "wmpFondo"
        Me.wmpFondo.OcxState = CType(resources.GetObject("wmpFondo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpFondo.Size = New System.Drawing.Size(75, 23)
        Me.wmpFondo.TabIndex = 7
        Me.wmpFondo.Visible = False
        '
        'Juego
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(559, 472)
        Me.Controls.Add(Me.wmpFondo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnsiguiente)
        Me.Controls.Add(Me.btnseleccionar)
        Me.Controls.Add(Me.btnanterior)
        Me.Controls.Add(Me.Comenzar)
        Me.Controls.Add(Me.lbltitulo)
        Me.Name = "Juego"
        Me.Text = "Juego"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wmpFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Comenzar As System.Windows.Forms.Button
    Friend WithEvents btnanterior As System.Windows.Forms.Button
    Friend WithEvents btnseleccionar As System.Windows.Forms.Button
    Friend WithEvents btnsiguiente As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents wmpFondo As AxWMPLib.AxWindowsMediaPlayer
End Class
