<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Exporter
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Exporter))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.progBar = New System.Windows.Forms.ProgressBar()
        Me.progressLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.samePath = New System.Windows.Forms.RadioButton()
        Me.diffPath = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.outputPathBox = New System.Windows.Forms.TextBox()
        Me.btnBack1 = New System.Windows.Forms.Button()
        Me.checkBoxSave = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button1.Location = New System.Drawing.Point(12, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "CATDrawings erzeugen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'progBar
        '
        Me.progBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progBar.Location = New System.Drawing.Point(12, 198)
        Me.progBar.Name = "progBar"
        Me.progBar.Size = New System.Drawing.Size(315, 23)
        Me.progBar.TabIndex = 1
        '
        'progressLbl
        '
        Me.progressLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressLbl.AutoSize = True
        Me.progressLbl.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.progressLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.progressLbl.Location = New System.Drawing.Point(15, 173)
        Me.progressLbl.Name = "progressLbl"
        Me.progressLbl.Size = New System.Drawing.Size(61, 13)
        Me.progressLbl.TabIndex = 2
        Me.progressLbl.Text = "progressLbl"
        Me.progressLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sheetmetal Part oder Produkt in Catia öffnen. "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'samePath
        '
        Me.samePath.AutoSize = True
        Me.samePath.Checked = True
        Me.samePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.samePath.Location = New System.Drawing.Point(6, 34)
        Me.samePath.Name = "samePath"
        Me.samePath.Size = New System.Drawing.Size(105, 17)
        Me.samePath.TabIndex = 5
        Me.samePath.TabStop = True
        Me.samePath.Text = "Pfad beibehalten"
        Me.samePath.UseVisualStyleBackColor = True
        '
        'diffPath
        '
        Me.diffPath.AutoSize = True
        Me.diffPath.Location = New System.Drawing.Point(114, 36)
        Me.diffPath.Name = "diffPath"
        Me.diffPath.Size = New System.Drawing.Size(14, 13)
        Me.diffPath.TabIndex = 6
        Me.diffPath.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.outputPathBox)
        Me.GroupBox1.Controls.Add(Me.samePath)
        Me.GroupBox1.Controls.Add(Me.diffPath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 66)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ausgabepfad"
        '
        'outputPathBox
        '
        Me.outputPathBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outputPathBox.Enabled = False
        Me.outputPathBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.outputPathBox.Location = New System.Drawing.Point(134, 33)
        Me.outputPathBox.Name = "outputPathBox"
        Me.outputPathBox.ReadOnly = True
        Me.outputPathBox.Size = New System.Drawing.Size(175, 20)
        Me.outputPathBox.TabIndex = 7
        '
        'btnBack1
        '
        Me.btnBack1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnBack1.Location = New System.Drawing.Point(223, 227)
        Me.btnBack1.Name = "btnBack1"
        Me.btnBack1.Size = New System.Drawing.Size(104, 33)
        Me.btnBack1.TabIndex = 0
        Me.btnBack1.TabStop = False
        Me.btnBack1.Text = "Zurück"
        Me.btnBack1.UseVisualStyleBackColor = True
        '
        'checkBoxSave
        '
        Me.checkBoxSave.AutoSize = True
        Me.checkBoxSave.Checked = True
        Me.checkBoxSave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxSave.Location = New System.Drawing.Point(15, 128)
        Me.checkBoxSave.Name = "checkBoxSave"
        Me.checkBoxSave.Size = New System.Drawing.Size(191, 17)
        Me.checkBoxSave.TabIndex = 8
        Me.checkBoxSave.Text = "Gleiche Parts mehrfach exportieren"
        Me.checkBoxSave.UseVisualStyleBackColor = True
        '
        'Exporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 279)
        Me.Controls.Add(Me.checkBoxSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.progressLbl)
        Me.Controls.Add(Me.progBar)
        Me.Controls.Add(Me.btnBack1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Exporter"
        Me.Text = "ShapeFormat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents progBar As ProgressBar
    Friend WithEvents progressLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents samePath As RadioButton
    Friend WithEvents diffPath As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents outputPathBox As TextBox
    Friend WithEvents btnBack1 As Button
    Friend WithEvents checkBoxSave As CheckBox
End Class
