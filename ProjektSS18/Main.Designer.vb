<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnSort = New System.Windows.Forms.Button()
        Me.btnInstructions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ShapeFormat"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(331, 79)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mit diesem Programm können Sie aus einer Blechkonstruktion in Catia eine Zeichnun" &
    "g erstellen und für die Laserschneidanlage vorbereiten."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnCreate.Location = New System.Drawing.Point(12, 110)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(158, 44)
        Me.btnCreate.TabIndex = 1
        Me.btnCreate.TabStop = False
        Me.btnCreate.Text = "Zeichnung erstellen"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnSort
        '
        Me.btnSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnSort.Location = New System.Drawing.Point(183, 110)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(158, 44)
        Me.btnSort.TabIndex = 1
        Me.btnSort.TabStop = False
        Me.btnSort.Text = "Zeichnung anordnen"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'btnInstructions
        '
        Me.btnInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnInstructions.Location = New System.Drawing.Point(97, 160)
        Me.btnInstructions.Name = "btnInstructions"
        Me.btnInstructions.Size = New System.Drawing.Size(158, 44)
        Me.btnInstructions.TabIndex = 1
        Me.btnInstructions.TabStop = False
        Me.btnInstructions.Text = "Anleitung"
        Me.btnInstructions.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 216)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.btnInstructions)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "ShapeFormat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnSort As Button
    Friend WithEvents btnInstructions As Button
End Class
