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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnNesting = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtBoxHeight = New System.Windows.Forms.TextBox()
        Me.txtBoxWidth = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBoxDistanceOutside = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBoxDistanceInside = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkBoxAuto = New System.Windows.Forms.CheckBox()
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
        Me.dataGrid.Size = New System.Drawing.Size(515, 159)
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.DividerWidth = 1
        Me.Column4.FillWeight = 50.0!
        Me.Column4.HeaderText = "Anzahl"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 55
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
        Me.btnNewSheet.Location = New System.Drawing.Point(307, 314)
        Me.btnNewSheet.Name = "btnNewSheet"
        Me.btnNewSheet.Size = New System.Drawing.Size(220, 30)
        Me.btnNewSheet.TabIndex = 1
        Me.btnNewSheet.Text = "Neues Blatt hinzufügen"
        Me.btnNewSheet.UseVisualStyleBackColor = True
        '
        'comboMaterial
        '
        Me.comboMaterial.AutoCompleteCustomSource.AddRange(New String() {"Papier", "Holz", "Plexiglas"})
        Me.comboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMaterial.FormattingEnabled = True
        Me.comboMaterial.Items.AddRange(New Object() {"Fotokarton", "Holz", "Plexiglas", "Benutzerdefiniert"})
        Me.comboMaterial.Location = New System.Drawing.Point(392, 224)
        Me.comboMaterial.Name = "comboMaterial"
        Me.comboMaterial.Size = New System.Drawing.Size(135, 21)
        Me.comboMaterial.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(304, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Material:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(304, 251)
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
        Me.comboSize.Items.AddRange(New Object() {"DIN A1", "DIN A3"})
        Me.comboSize.Location = New System.Drawing.Point(392, 251)
        Me.comboSize.Name = "comboSize"
        Me.comboSize.Size = New System.Drawing.Size(135, 21)
        Me.comboSize.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnRefresh.Location = New System.Drawing.Point(12, 219)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(127, 61)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Liste aktualisieren"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnNesting
        '
        Me.btnNesting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.btnNesting.Location = New System.Drawing.Point(145, 219)
        Me.btnNesting.Name = "btnNesting"
        Me.btnNesting.Size = New System.Drawing.Size(141, 61)
        Me.btnNesting.TabIndex = 0
        Me.btnNesting.TabStop = False
        Me.btnNesting.Text = "Automatisch anordnen"
        Me.btnNesting.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnBack.Location = New System.Drawing.Point(451, 12)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(79, 26)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Zurück"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtBoxHeight
        '
        Me.txtBoxHeight.AcceptsReturn = True
        Me.txtBoxHeight.CausesValidation = False
        Me.txtBoxHeight.Enabled = False
        Me.txtBoxHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBoxHeight.Location = New System.Drawing.Point(405, 284)
        Me.txtBoxHeight.MaxLength = 4
        Me.txtBoxHeight.Name = "txtBoxHeight"
        Me.txtBoxHeight.Size = New System.Drawing.Size(40, 21)
        Me.txtBoxHeight.TabIndex = 4
        Me.txtBoxHeight.Text = "594"
        '
        'txtBoxWidth
        '
        Me.txtBoxWidth.Enabled = False
        Me.txtBoxWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBoxWidth.Location = New System.Drawing.Point(460, 284)
        Me.txtBoxWidth.MaxLength = 4
        Me.txtBoxWidth.Name = "txtBoxWidth"
        Me.txtBoxWidth.Size = New System.Drawing.Size(40, 21)
        Me.txtBoxWidth.TabIndex = 4
        Me.txtBoxWidth.Text = "841"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(445, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "x"
        Me.Label3.UseMnemonic = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(500, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "mm"
        Me.Label4.UseMnemonic = False
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(304, 279)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(99, 26)
        Me.lblError.TabIndex = 6
        Me.lblError.Text = "Werte zwischen " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10mm und 1500mm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(9, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Abstand vom Blattrand:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(9, 322)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Abstand zwischen Teilen:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(200, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "mm"
        Me.Label7.UseMnemonic = False
        '
        'txtBoxDistanceOutside
        '
        Me.txtBoxDistanceOutside.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBoxDistanceOutside.Location = New System.Drawing.Point(177, 290)
        Me.txtBoxDistanceOutside.MaxLength = 2
        Me.txtBoxDistanceOutside.Name = "txtBoxDistanceOutside"
        Me.txtBoxDistanceOutside.Size = New System.Drawing.Size(23, 21)
        Me.txtBoxDistanceOutside.TabIndex = 4
        Me.txtBoxDistanceOutside.Text = "5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(199, 323)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "mm"
        Me.Label8.UseMnemonic = False
        '
        'txtBoxDistanceInside
        '
        Me.txtBoxDistanceInside.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBoxDistanceInside.Location = New System.Drawing.Point(177, 319)
        Me.txtBoxDistanceInside.MaxLength = 2
        Me.txtBoxDistanceInside.Name = "txtBoxDistanceInside"
        Me.txtBoxDistanceInside.Size = New System.Drawing.Size(23, 21)
        Me.txtBoxDistanceInside.TabIndex = 4
        Me.txtBoxDistanceInside.Text = "5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(324, 350)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(207, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Automatisch neue Blätter hinzufügen"
        '
        'chkBoxAuto
        '
        Me.chkBoxAuto.AutoSize = True
        Me.chkBoxAuto.Checked = True
        Me.chkBoxAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoxAuto.Location = New System.Drawing.Point(307, 352)
        Me.chkBoxAuto.Name = "chkBoxAuto"
        Me.chkBoxAuto.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxAuto.TabIndex = 7
        Me.chkBoxAuto.UseVisualStyleBackColor = True
        '
        'Nesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 376)
        Me.Controls.Add(Me.chkBoxAuto)
        Me.Controls.Add(Me.txtBoxDistanceInside)
        Me.Controls.Add(Me.txtBoxDistanceOutside)
        Me.Controls.Add(Me.txtBoxWidth)
        Me.Controls.Add(Me.txtBoxHeight)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboSize)
        Me.Controls.Add(Me.comboMaterial)
        Me.Controls.Add(Me.dataGrid)
        Me.Controls.Add(Me.btnNesting)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnNewSheet)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblError)
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
    Friend WithEvents btnNewSheet As Button
    Friend WithEvents comboMaterial As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents comboSize As ComboBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnNesting As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents txtBoxHeight As TextBox
    Friend WithEvents txtBoxWidth As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblError As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents btnColumn1 As DataGridViewButtonColumn
    Friend WithEvents btnColumn2 As DataGridViewButtonColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBoxDistanceOutside As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBoxDistanceInside As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chkBoxAuto As CheckBox
End Class
