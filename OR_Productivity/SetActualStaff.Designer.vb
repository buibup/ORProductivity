<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetActualStaff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Actual_NA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TB_Actual_RN = New System.Windows.Forms.TextBox()
        Me.TB_Hour = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(508, 211)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(74, 23)
        Me.btAdd.TabIndex = 8
        Me.btAdd.Text = "Add"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(570, 193)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Set Staff Actual"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TB_Actual_NA, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TB_Actual_RN, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TB_Hour, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(555, 137)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "วันที่"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Hour"
        '
        'TB_Actual_NA
        '
        Me.TB_Actual_NA.Location = New System.Drawing.Point(50, 59)
        Me.TB_Actual_NA.Name = "TB_Actual_NA"
        Me.TB_Actual_NA.Size = New System.Drawing.Size(100, 22)
        Me.TB_Actual_NA.TabIndex = 8
        Me.TB_Actual_NA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "NA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "RN"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(50, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(282, 22)
        Me.DateTimePicker1.TabIndex = 14
        '
        'TB_Actual_RN
        '
        Me.TB_Actual_RN.Location = New System.Drawing.Point(50, 31)
        Me.TB_Actual_RN.Name = "TB_Actual_RN"
        Me.TB_Actual_RN.Size = New System.Drawing.Size(100, 22)
        Me.TB_Actual_RN.TabIndex = 7
        Me.TB_Actual_RN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_Hour
        '
        Me.TB_Hour.Location = New System.Drawing.Point(50, 87)
        Me.TB_Hour.Name = "TB_Hour"
        Me.TB_Hour.Size = New System.Drawing.Size(100, 22)
        Me.TB_Hour.TabIndex = 16
        Me.TB_Hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 240)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(570, 176)
        Me.DataGridView1.TabIndex = 10
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(12, 422)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(74, 23)
        Me.btRefresh.TabIndex = 11
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(508, 422)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(74, 23)
        Me.btClose.TabIndex = 12
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(12, 211)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(103, 23)
        Me.btSearch.TabIndex = 13
        Me.btSearch.Text = "SearchByDate"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'SetActualStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 453)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btAdd)
        Me.Name = "SetActualStaff"
        Me.Text = "SetActualStaff"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_Actual_NA As System.Windows.Forms.TextBox
    Friend WithEvents TB_Actual_RN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Hour As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents btSearch As System.Windows.Forms.Button
End Class
