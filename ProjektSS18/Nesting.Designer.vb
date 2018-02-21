<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nesting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nesting))
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.dataGrid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnNewSheet = New System.Windows.Forms.Button()
        Me.comboMaterial = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboSize = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnSelect.Location = New System.Drawing.Point(12, 12)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(316, 33)
        Me.btnSelect.TabIndex = 0
        Me.btnSelect.Text = "Zeichnungen auswählen und laden"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'dataGrid
        '
        Me.dataGrid.AllowUserToAddRows = False
        Me.dataGrid.AllowUserToDeleteRows = False
        Me.dataGrid.AllowUserToOrderColumns = True
        Me.dataGrid.AllowUserToResizeRows = False
        Me.dataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column3, Me.btnColumn1, Me.btnColumn2})
        Me.dataGrid.Location = New System.Drawing.Point(12, 55)
        Me.dataGrid.Name = "dataGrid"
        Me.dataGrid.ReadOnly = True
        Me.dataGrid.RowHeadersVisible = False
        Me.dataGrid.ShowCellErrors = False
        Me.dataGrid.ShowCellToolTips = False
        Me.dataGrid.ShowEditingIcon = False
        Me.dataGrid.ShowRowErrors = False
        Me.dataGrid.Size = New System.Drawing.Size(538, 159)
        Me.dataGrid.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.DividerWidth = 1
        Me.Column1.HeaderText = "Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DividerWidth = 1
        Me.Column2.HeaderText = "Größe"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column4
        '
        Me.Column4.DividerWidth = 1
        Me.Column4.FillWeight = 50.0!
        Me.Column4.HeaderText = "Blatt Nr."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 85
        '
        'Column3
        '
        Me.Column3.DividerWidth = 1
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 120
        '
        'btnColumn1
        '
        Me.btnColumn1.DividerWidth = 1
        Me.btnColumn1.HeaderText = ""
        Me.btnColumn1.Name = "btnColumn1"
        Me.btnColumn1.ReadOnly = True
        Me.btnColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.btnColumn1.Text = "Einfügen"
        Me.btnColumn1.Width = 65
        '
        'btnColumn2
        '
        Me.btnColumn2.DividerWidth = 1
        Me.btnColumn2.HeaderText = ""
        Me.btnColumn2.Name = "btnColumn2"
        Me.btnColumn2.ReadOnly = True
        Me.btnColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnColumn2.Width = 65
        '
        'btnNewSheet
        '
        Me.btnNewSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnNewSheet.Location = New System.Drawing.Point(327, 296)
        Me.btnNewSheet.Name = "btnNewSheet"
        Me.btnNewSheet.Size = New System.Drawing.Size(202, 30)
        Me.btnNewSheet.TabIndex = 0
        Me.btnNewSheet.Text = "Neues Blatt hinzufügen"
        Me.btnNewSheet.UseVisualStyleBackColor = True
        '
        'comboMaterial
        '
        Me.comboMaterial.AutoCompleteCustomSource.AddRange(New String() {"Papier", "Holz", "Plexiglas"})
        Me.comboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMaterial.FormattingEnabled = True
        Me.comboMaterial.Items.AddRange(New Object() {"Papier", "Holz", "Plexiglas"})
        Me.comboMaterial.Location = New System.Drawing.Point(408, 231)
        Me.comboMaterial.Name = "comboMaterial"
        Me.comboMaterial.Size = New System.Drawing.Size(121, 21)
        Me.comboMaterial.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(324, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Material:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(324, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Blattgröße:"
        '
        'comboSize
        '
        Me.comboSize.AutoCompleteCustomSource.AddRange(New String() {"Papier", "Holz", "Plexiglas"})
        Me.comboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSize.FormattingEnabled = True
        Me.comboSize.Items.AddRange(New Object() {"DIN A1"})
        Me.comboSize.Location = New System.Drawing.Point(408, 266)
        Me.comboSize.Name = "comboSize"
        Me.comboSize.Size = New System.Drawing.Size(121, 21)
        Me.comboSize.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button1.Location = New System.Drawing.Point(35, 297)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(204, 31)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Liste aktualisieren"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button2.Location = New System.Drawing.Point(35, 223)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(204, 31)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Alles einfügen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button3.Location = New System.Drawing.Point(35, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(204, 31)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Automatisch anordnen"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button4.Location = New System.Drawing.Point(474, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(79, 26)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Zurück"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Nesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 346)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboSize)
        Me.Controls.Add(Me.comboMaterial)
        Me.Controls.Add(Me.dataGrid)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnNewSheet)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Nesting"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ShapeFormat"
        CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelect As Button
    Friend WithEvents dataGrid As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents btnColumn1 As DataGridViewButtonColumn
    Friend WithEvents btnColumn2 As DataGridViewButtonColumn
    Friend WithEvents btnNewSheet As Button
    Friend WithEvents comboMaterial As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents comboSize As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
