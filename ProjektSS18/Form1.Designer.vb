<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.progressLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.samePath = New System.Windows.Forms.RadioButton()
        Me.diffPath = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.outputPath = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(12, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(315, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "CATDrawings erzeugen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 204)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(315, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'progressLbl
        '
        Me.progressLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressLbl.AutoSize = True
        Me.progressLbl.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.progressLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.progressLbl.Location = New System.Drawing.Point(127, 179)
        Me.progressLbl.Name = "progressLbl"
        Me.progressLbl.Size = New System.Drawing.Size(84, 17)
        Me.progressLbl.TabIndex = 2
        Me.progressLbl.Text = "ProgressLbl"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 40)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sheetmetal Part oder Produkt in Catia öffnen. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Programm starten."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'samePath
        '
        Me.samePath.AutoSize = True
        Me.samePath.Checked = True
        Me.samePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.samePath.Location = New System.Drawing.Point(6, 34)
        Me.samePath.Name = "samePath"
        Me.samePath.Size = New System.Drawing.Size(84, 17)
        Me.samePath.TabIndex = 5
        Me.samePath.TabStop = True
        Me.samePath.Text = "Unverändert"
        Me.samePath.UseVisualStyleBackColor = True
        '
        'diffPath
        '
        Me.diffPath.AutoSize = True
        Me.diffPath.Location = New System.Drawing.Point(106, 36)
        Me.diffPath.Name = "diffPath"
        Me.diffPath.Size = New System.Drawing.Size(14, 13)
        Me.diffPath.TabIndex = 6
        Me.diffPath.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.outputPath)
        Me.GroupBox1.Controls.Add(Me.samePath)
        Me.GroupBox1.Controls.Add(Me.diffPath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 66)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ausgabepfad"
        '
        'outputPath
        '
        Me.outputPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outputPath.Enabled = False
        Me.outputPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.outputPath.Location = New System.Drawing.Point(126, 33)
        Me.outputPath.Name = "outputPath"
        Me.outputPath.ReadOnly = True
        Me.outputPath.Size = New System.Drawing.Size(183, 20)
        Me.outputPath.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 276)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.progressLbl)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "ShapeFormat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents progressLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents samePath As RadioButton
    Friend WithEvents diffPath As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents outputPath As TextBox
End Class
