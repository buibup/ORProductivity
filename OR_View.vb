Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports InterSystems.Data.CacheClient
Imports System.Data.OleDb
Imports System.Data.DataSetExtensions


Namespace OR_Productivity
    <DesignerGenerated()> _
    Public Class OR_View
        Inherits Form
        ' Methods
        Public cacheDb As New CacheDb
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.OR_View_Load)
            Dim list As List(Of WeakReference) = OR_View.__ENCList
            SyncLock list
                OR_View.__ENCList.Add(New WeakReference(Me))
            End SyncLock
            Me.OCN1 = New OdbcConnection(Constants.OCN_MEDSD)
            Me.SCN_SQL3 = New SqlConnection(Constants.SCN_SQL3)
            Me.SCN_SQL2 = New SqlConnection(Constants.SCN_SQL2)
            Me.hour1 = 0
            Me.InitializeComponent()
        End Sub

        Private Sub BT_Clear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Clear.Click
            Me.TB_Need_RN.Text = ""
            Me.TB_Need_NA.Text = ""
            Me.TB_Actual_RN.Text = ""
            Me.TB_Actual_NA.Text = ""
            Me.TB_Hour.Text = ""
        End Sub

        Private Sub BT_Export_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_Export.Click
            Try
                Me.SaveFileDialog1.Filter = "Microsoft Office Exce(*.xls)|*.xls;"
                If ((Me.SaveFileDialog1.ShowDialog = DialogResult.OK) AndAlso Not ((Me.DGV_OR.Columns.Count = 0) Or (Me.DGV_OR.Rows.Count = 0))) Then
                    Dim current As DataColumn
                    Dim enumerator As IEnumerator
                    Dim enumerator2 As IEnumerator
                    Dim [set] As New DataSet
                    [set].Tables.Add()
                    Dim num6 As Integer = (Me.DGV_OR.ColumnCount - 1)
                    Dim i As Integer = 0
                    Do While (i <= num6)
                        [set].Tables.Item(0).Columns.Add(Me.DGV_OR.Columns.Item(i).HeaderText)
                        i += 1
                    Loop
                    Dim num7 As Integer = (Me.DGV_OR.RowCount - 1)
                    Dim j As Integer = 0
                    Do While (j <= num7)
                        Dim row2 As DataRow = [set].Tables.Item(0).NewRow
                        Dim num8 As Integer = (Me.DGV_OR.Columns.Count - 1)
                        Dim k As Integer = 0
                        Do While (k <= num8)
                            row2.Item(k) = RuntimeHelpers.GetObjectValue(Me.DGV_OR.Rows.Item(j).Cells.Item(k).Value)
                            k += 1
                        Loop
                        [set].Tables.Item(0).Rows.Add(row2)
                        j += 1
                    Loop
                    'Dim class2 As New Excel.ApplicationClass()
                    Dim class2 As New Microsoft.Office.Interop.Excel.Application
                    Dim workbook As Microsoft.Office.Interop.Excel.Workbook = class2.Workbooks.Add(Missing.Value)
                    Dim activeSheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
                    Dim table As DataTable = [set].Tables.Item(0)
                    Dim num As Integer = 0
                    Dim num2 As Integer = 0
                    Try
                        enumerator = table.Columns.GetEnumerator
                        Do While enumerator.MoveNext
                            current = DirectCast(enumerator.Current, DataColumn)
                            num += 1
                            If (Strings.LSet(current.ColumnName, 6) = "Column") Then
                                class2.Cells._Default(1, num) = ""
                            Else
                                class2.Cells._Default(1, num) = Strings.Replace(current.ColumnName, "Column", "", 1, -1, CompareMethod.Binary)
                            End If
                        Loop
                    Finally
                        If TypeOf enumerator Is IDisposable Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                    Try
                        enumerator2 = table.Rows.GetEnumerator
                        Do While enumerator2.MoveNext
                            Dim enumerator3 As IEnumerator
                            Dim row As DataRow = DirectCast(enumerator2.Current, DataRow)
                            num2 += 1
                            num = 0
                            Try
                                enumerator3 = table.Columns.GetEnumerator
                                Do While enumerator3.MoveNext
                                    current = DirectCast(enumerator3.Current, DataColumn)
                                    num += 1
                                    class2.Cells._Default((num2 + 1), num) = RuntimeHelpers.GetObjectValue(row.Item(current.ColumnName))
                                Loop
                            Finally
                                If TypeOf enumerator3 Is IDisposable Then
                                    TryCast(enumerator3, IDisposable).Dispose()
                                End If
                            End Try
                        Loop
                    Finally
                        If TypeOf enumerator2 Is IDisposable Then
                            TryCast(enumerator2, IDisposable).Dispose()
                        End If
                    End Try
                    class2.Range("A1:A2", Missing.Value).Merge(Missing.Value)
                    class2.Range("B1:B2", Missing.Value).Merge(Missing.Value)
                    class2.Range("C1:N1", Missing.Value).Merge(Missing.Value)
                    class2.Range("O1:O2", Missing.Value).Merge(Missing.Value)
                    class2.Range("P1:R1", Missing.Value).Merge(Missing.Value)
                    class2.Range("S1:U1", Missing.Value).Merge(Missing.Value)
                    class2.Range("V1:V2", Missing.Value).Merge(Missing.Value)
                    class2.Range("W1:W2", Missing.Value).Merge(Missing.Value)
                    class2.Range("A1:W21", Missing.Value).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    class2.Range("A1:W21", Missing.Value).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    activeSheet.Columns.AutoFit()
                    Dim fileName As String = Me.SaveFileDialog1.FileName
                    Dim flag As Boolean = False
                    Try
                        File.OpenWrite(fileName).Close()
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim exception As Exception = exception1
                        flag = False
                        ProjectData.ClearProjectError()
                    End Try
                    If File.Exists(fileName) Then
                        File.Delete(fileName)
                    End If
                    workbook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value)
                    class2.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value)
                    class2.Visible = True
                End If
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                Dim exception2 As Exception = exception3
                Interaction.MsgBox("กรุณาเลือก File ที่จะทำการ  Save", MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Private Sub BT_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_OK.Click
            Me.SetFrom()
            'Me.LoadActualStff()
            Me.Loaddata()
            Me.SaveData()
            Me.Loaddata_SumCurrent()
        End Sub

        Private Sub BT_PrintReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BT_PrintReport.Click
            Dim report As New Report
            Module1.pReport = "Daily"
            Module1.StaDate = Me.DateTimePicker2.Value.ToString("dd/MM/yyyy")
            Module1.EndDate = Me.DateTimePicker3.Value.ToString("dd/MM/yyyy")
            report.ShowDialog()
        End Sub

        Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DateTimePicker1.ValueChanged
            Me.ClearActualStaff()
            Me.SetFrom()
            Me.LoadActualStff()
            Me.Loaddata()
            Me.Loaddata_SumCurrent()
        End Sub

        Private Sub DGV_OR_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
            If ((e.RowIndex = -1) And (e.ColumnIndex > -1)) Then
                Dim cellBounds As Rectangle = e.CellBounds
                cellBounds.Y = CInt(Math.Round(CDbl((cellBounds.Y + (CDbl(e.CellBounds.Height) / 2)))))
                cellBounds.Height = CInt(Math.Round(CDbl((CDbl(e.CellBounds.Height) / 2))))
                e.PaintBackground(cellBounds, True)
                e.PaintContent(cellBounds)
                e.Handled = True
            End If
        End Sub

        Private Sub DGV_OR_ColumnWidthChanged(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs)
            Dim displayRectangle As Rectangle = Me.DGV_OR.DisplayRectangle
            displayRectangle.Height = CInt(Math.Round(CDbl((CDbl(Me.DGV_OR.ColumnHeadersHeight) / 2))))
            Me.DGV_OR.Invalidate(displayRectangle)
        End Sub

        Private Sub DGV_OR_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            Dim num2 As Integer
            Dim num6 As Integer
            Dim strArray As String() = New String() {"Month", "จน. Pt./day (ADC)", "Patient Classification", "ภาระงาน รวม (hours)", "Staff Need (Staff)", "Staff Actual (Staff)", "Produc tivity (%)", "RN;Non RN"}
            Dim rect As Rectangle = Me.DGV_OR.GetCellDisplayRectangle(0, -1, True)
            Dim width As Integer = Me.DGV_OR.GetCellDisplayRectangle(0, -1, True).Width
            e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
            Dim format As New StringFormat With { _
                .Alignment = StringAlignment.Center, _
                .LineAlignment = StringAlignment.Center _
            }
            e.Graphics.DrawString(strArray(0), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
            rect = Me.DGV_OR.GetCellDisplayRectangle(1, -1, True)
            width = Me.DGV_OR.GetCellDisplayRectangle(1, -1, True).Width
            rect.X += 1
            rect.Y += 1
            rect.Width = (rect.Width - 2)
            e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(strArray(1), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
            rect = Me.DGV_OR.GetCellDisplayRectangle(2, -1, True)
            rect.X += 1
            rect.Y += 1
            Dim columnIndex As Integer = 2
            Do
                width = Me.DGV_OR.GetCellDisplayRectangle(columnIndex, -1, True).Width
                num2 = (num2 + width)
                rect.Width = ((num2 + width) - 2)
                e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(strArray(2), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
                columnIndex += 1
                num6 = 10
            Loop While (columnIndex <= num6)
            rect = Me.DGV_OR.GetCellDisplayRectangle(12, -1, True)
            width = Me.DGV_OR.GetCellDisplayRectangle(1, -1, True).Width
            rect.X += 1
            rect.Y += 1
            rect.Width = (rect.Width - 2)
            e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(strArray(3), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
            num2 = 0
            rect = Me.DGV_OR.GetCellDisplayRectangle(13, -1, True)
            rect.X += 1
            rect.Y += 1
            Dim num4 As Integer = 13
            Do
                width = Me.DGV_OR.GetCellDisplayRectangle(num4, -1, True).Width
                num2 = (num2 + width)
                rect.Width = (num2 - 2)
                e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(strArray(4), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
                num4 += 1
                num6 = 15
            Loop While (num4 <= num6)
            num2 = 0
            rect = Me.DGV_OR.GetCellDisplayRectangle(&H10 + 2, -1, True)
            rect.X += 1
            rect.Y += 1
            Dim num5 As Integer = &H10 + 2
            Do
                width = Me.DGV_OR.GetCellDisplayRectangle(num5, -1, True).Width
                num2 = (num2 + width)
                rect.Width = (num2 - 2)
                e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
                format.Alignment = StringAlignment.Center
                format.LineAlignment = StringAlignment.Center
                e.Graphics.DrawString(strArray(5), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
                num5 += 1
                num6 = &H12 + 2
            Loop While (num5 <= num6)
            rect = Me.DGV_OR.GetCellDisplayRectangle(&H13 + 2, -1, True)
            width = Me.DGV_OR.GetCellDisplayRectangle(1, -1, True).Width
            rect.X += 1
            rect.Y += 1
            rect.Width = (rect.Width - 2)
            e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(strArray(6), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
            rect = Me.DGV_OR.GetCellDisplayRectangle(20, -1, True)
            width = Me.DGV_OR.GetCellDisplayRectangle(1, -1, True).Width
            rect.X += 1
            rect.Y += 1
            rect.Width = (rect.Width - 2)
            e.Graphics.FillRectangle(New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.BackColor), rect)
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(strArray(7), Me.DGV_OR.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DGV_OR.ColumnHeadersDefaultCellStyle.ForeColor), rect, format)
        End Sub

        Private Sub DGV_OR_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
            Dim displayRectangle As Rectangle = Me.DGV_OR.DisplayRectangle
            displayRectangle.Height = CInt(Math.Round(CDbl((CDbl(Me.DGV_OR.ColumnHeadersHeight) / 2))))
            Me.DGV_OR.Invalidate(displayRectangle)
        End Sub

        <DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If (disposing AndAlso (Not Me.components Is Nothing)) Then
                    Me.components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.DGV_OR = New System.Windows.Forms.DataGridView()
            Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BT_Export = New System.Windows.Forms.Button()
            Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TB_Class6 = New System.Windows.Forms.TextBox()
            Me.TB_Class6W = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.TB_Class5 = New System.Windows.Forms.TextBox()
            Me.TB_Class4 = New System.Windows.Forms.TextBox()
            Me.TB_Class3 = New System.Windows.Forms.TextBox()
            Me.TB_Class2 = New System.Windows.Forms.TextBox()
            Me.TB_Class1 = New System.Windows.Forms.TextBox()
            Me.TB_Class5W = New System.Windows.Forms.TextBox()
            Me.TB_Class4W = New System.Windows.Forms.TextBox()
            Me.TB_Class3W = New System.Windows.Forms.TextBox()
            Me.TB_Class2W = New System.Windows.Forms.TextBox()
            Me.TB_Class1W = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.TB_Actual_NA = New System.Windows.Forms.TextBox()
            Me.TB_Actual_RN = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.TB_Need_NA = New System.Windows.Forms.TextBox()
            Me.TB_Need_RN = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.BT_OK = New System.Windows.Forms.Button()
            Me.BT_Clear = New System.Windows.Forms.Button()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.TB_Hour = New System.Windows.Forms.TextBox()
            Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
            Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.BT_PrintReport = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            CType(Me.DGV_OR, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'DGV_OR
            '
            Me.DGV_OR.AllowDrop = True
            Me.DGV_OR.AllowUserToDeleteRows = False
            Me.DGV_OR.AllowUserToOrderColumns = True
            Me.DGV_OR.AllowUserToResizeColumns = False
            Me.DGV_OR.AllowUserToResizeRows = False
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.DGV_OR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DGV_OR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DGV_OR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DGV_OR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
            Me.DGV_OR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DGV_OR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column22, Me.Column23, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column3, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column14, Me.Column16, Me.Column15, Me.Column17, Me.Column13, Me.Column18, Me.Column19, Me.Column20, Me.Column21})
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DGV_OR.DefaultCellStyle = DataGridViewCellStyle3
            Me.DGV_OR.GridColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.DGV_OR.Location = New System.Drawing.Point(2, 183)
            Me.DGV_OR.Name = "DGV_OR"
            Me.DGV_OR.ReadOnly = True
            Me.DGV_OR.RowHeadersVisible = False
            Me.DGV_OR.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
            Me.DGV_OR.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
            Me.DGV_OR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.DGV_OR.Size = New System.Drawing.Size(1295, 438)
            Me.DGV_OR.TabIndex = 0
            '
            'Column1
            '
            Me.Column1.FillWeight = 240.0!
            Me.Column1.HeaderText = "Month"
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column22
            '
            Me.Column22.HeaderText = "จน. Pt./day (ADC)"
            Me.Column22.Name = "Column22"
            Me.Column22.ReadOnly = True
            '
            'Column23
            '
            Me.Column23.HeaderText = ""
            Me.Column23.Name = "Column23"
            Me.Column23.ReadOnly = True
            '
            'Column2
            '
            Me.Column2.HeaderText = ""
            Me.Column2.Name = "Column2"
            Me.Column2.ReadOnly = True
            Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column4
            '
            Me.Column4.HeaderText = ""
            Me.Column4.Name = "Column4"
            Me.Column4.ReadOnly = True
            Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column5
            '
            Me.Column5.HeaderText = ""
            Me.Column5.Name = "Column5"
            Me.Column5.ReadOnly = True
            Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column6
            '
            Me.Column6.HeaderText = "Patient Classification"
            Me.Column6.Name = "Column6"
            Me.Column6.ReadOnly = True
            Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column7
            '
            Me.Column7.HeaderText = ""
            Me.Column7.Name = "Column7"
            Me.Column7.ReadOnly = True
            Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column3
            '
            Me.Column3.FillWeight = 120.0!
            Me.Column3.HeaderText = ""
            Me.Column3.Name = "Column3"
            Me.Column3.ReadOnly = True
            Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column8
            '
            Me.Column8.HeaderText = ""
            Me.Column8.Name = "Column8"
            Me.Column8.ReadOnly = True
            Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column9
            '
            Me.Column9.HeaderText = ""
            Me.Column9.Name = "Column9"
            Me.Column9.ReadOnly = True
            Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column10
            '
            Me.Column10.HeaderText = ""
            Me.Column10.Name = "Column10"
            Me.Column10.ReadOnly = True
            Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column11
            '
            Me.Column11.HeaderText = ""
            Me.Column11.Name = "Column11"
            Me.Column11.ReadOnly = True
            Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column12
            '
            Me.Column12.HeaderText = ""
            Me.Column12.Name = "Column12"
            Me.Column12.ReadOnly = True
            Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column14
            '
            Me.Column14.FillWeight = 120.0!
            Me.Column14.HeaderText = "ภาระงาน รวม (hours)"
            Me.Column14.Name = "Column14"
            Me.Column14.ReadOnly = True
            Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column16
            '
            Me.Column16.HeaderText = ""
            Me.Column16.Name = "Column16"
            Me.Column16.ReadOnly = True
            Me.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column15
            '
            Me.Column15.HeaderText = "Staff Need (Staff)"
            Me.Column15.Name = "Column15"
            Me.Column15.ReadOnly = True
            Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column17
            '
            Me.Column17.HeaderText = ""
            Me.Column17.Name = "Column17"
            Me.Column17.ReadOnly = True
            Me.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column13
            '
            Me.Column13.HeaderText = ""
            Me.Column13.Name = "Column13"
            Me.Column13.ReadOnly = True
            Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column18
            '
            Me.Column18.HeaderText = "Staff Actual (Staff)"
            Me.Column18.Name = "Column18"
            Me.Column18.ReadOnly = True
            Me.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column19
            '
            Me.Column19.FillWeight = 120.0!
            Me.Column19.HeaderText = ""
            Me.Column19.Name = "Column19"
            Me.Column19.ReadOnly = True
            Me.Column19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column20
            '
            Me.Column20.HeaderText = "Produc tivity (%)"
            Me.Column20.Name = "Column20"
            Me.Column20.ReadOnly = True
            Me.Column20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Column21
            '
            Me.Column21.HeaderText = "RN;Non RN"
            Me.Column21.Name = "Column21"
            Me.Column21.ReadOnly = True
            Me.Column21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'BT_Export
            '
            Me.BT_Export.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.BT_Export.Location = New System.Drawing.Point(12, 628)
            Me.BT_Export.Name = "BT_Export"
            Me.BT_Export.Size = New System.Drawing.Size(136, 38)
            Me.BT_Export.TabIndex = 12
            Me.BT_Export.Text = "Export To Excel"
            Me.BT_Export.UseVisualStyleBackColor = True
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Location = New System.Drawing.Point(46, 12)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.Size = New System.Drawing.Size(184, 20)
            Me.DateTimePicker1.TabIndex = 13
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 18)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(28, 13)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "วันที่"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TB_Class6)
            Me.GroupBox1.Controls.Add(Me.TB_Class6W)
            Me.GroupBox1.Controls.Add(Me.Label13)
            Me.GroupBox1.Controls.Add(Me.TB_Class5)
            Me.GroupBox1.Controls.Add(Me.TB_Class4)
            Me.GroupBox1.Controls.Add(Me.TB_Class3)
            Me.GroupBox1.Controls.Add(Me.TB_Class2)
            Me.GroupBox1.Controls.Add(Me.TB_Class1)
            Me.GroupBox1.Controls.Add(Me.TB_Class5W)
            Me.GroupBox1.Controls.Add(Me.TB_Class4W)
            Me.GroupBox1.Controls.Add(Me.TB_Class3W)
            Me.GroupBox1.Controls.Add(Me.TB_Class2W)
            Me.GroupBox1.Controls.Add(Me.TB_Class1W)
            Me.GroupBox1.Controls.Add(Me.Label6)
            Me.GroupBox1.Controls.Add(Me.Label5)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.GroupBox1.Location = New System.Drawing.Point(2, 38)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(667, 139)
            Me.GroupBox1.TabIndex = 4
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Patient Classification"
            '
            'TB_Class6
            '
            Me.TB_Class6.Enabled = False
            Me.TB_Class6.Location = New System.Drawing.Point(539, 69)
            Me.TB_Class6.Name = "TB_Class6"
            Me.TB_Class6.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class6.TabIndex = 5
            Me.TB_Class6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class6W
            '
            Me.TB_Class6W.Enabled = False
            Me.TB_Class6W.Location = New System.Drawing.Point(539, 108)
            Me.TB_Class6W.Name = "TB_Class6W"
            Me.TB_Class6W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class6W.TabIndex = 7
            Me.TB_Class6W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(559, 21)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(54, 32)
            Me.Label13.TabIndex = 6
            Me.Label13.Text = "6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 39.0 )"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'TB_Class5
            '
            Me.TB_Class5.Enabled = False
            Me.TB_Class5.Location = New System.Drawing.Point(430, 69)
            Me.TB_Class5.Name = "TB_Class5"
            Me.TB_Class5.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class5.TabIndex = 0
            Me.TB_Class5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class4
            '
            Me.TB_Class4.Enabled = False
            Me.TB_Class4.Location = New System.Drawing.Point(324, 69)
            Me.TB_Class4.Name = "TB_Class4"
            Me.TB_Class4.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class4.TabIndex = 0
            Me.TB_Class4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class3
            '
            Me.TB_Class3.Enabled = False
            Me.TB_Class3.Location = New System.Drawing.Point(218, 69)
            Me.TB_Class3.Name = "TB_Class3"
            Me.TB_Class3.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class3.TabIndex = 0
            Me.TB_Class3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class2
            '
            Me.TB_Class2.Enabled = False
            Me.TB_Class2.Location = New System.Drawing.Point(112, 69)
            Me.TB_Class2.Name = "TB_Class2"
            Me.TB_Class2.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class2.TabIndex = 0
            Me.TB_Class2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class1
            '
            Me.TB_Class1.Enabled = False
            Me.TB_Class1.Location = New System.Drawing.Point(6, 69)
            Me.TB_Class1.Name = "TB_Class1"
            Me.TB_Class1.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class1.TabIndex = 0
            Me.TB_Class1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class5W
            '
            Me.TB_Class5W.Enabled = False
            Me.TB_Class5W.Location = New System.Drawing.Point(430, 108)
            Me.TB_Class5W.Name = "TB_Class5W"
            Me.TB_Class5W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class5W.TabIndex = 4
            Me.TB_Class5W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class4W
            '
            Me.TB_Class4W.Enabled = False
            Me.TB_Class4W.Location = New System.Drawing.Point(324, 108)
            Me.TB_Class4W.Name = "TB_Class4W"
            Me.TB_Class4W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class4W.TabIndex = 3
            Me.TB_Class4W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class3W
            '
            Me.TB_Class3W.Enabled = False
            Me.TB_Class3W.Location = New System.Drawing.Point(218, 108)
            Me.TB_Class3W.Name = "TB_Class3W"
            Me.TB_Class3W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class3W.TabIndex = 2
            Me.TB_Class3W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class2W
            '
            Me.TB_Class2W.Enabled = False
            Me.TB_Class2W.Location = New System.Drawing.Point(112, 108)
            Me.TB_Class2W.Name = "TB_Class2W"
            Me.TB_Class2W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class2W.TabIndex = 1
            Me.TB_Class2W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Class1W
            '
            Me.TB_Class1W.Enabled = False
            Me.TB_Class1W.Location = New System.Drawing.Point(6, 108)
            Me.TB_Class1W.Name = "TB_Class1W"
            Me.TB_Class1W.Size = New System.Drawing.Size(100, 22)
            Me.TB_Class1W.TabIndex = 0
            Me.TB_Class1W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(450, 21)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(54, 32)
            Me.Label6.TabIndex = 4
            Me.Label6.Text = "5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 27.0 )"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(347, 21)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(54, 32)
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 22.3 )"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(242, 21)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(54, 32)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 16.0 )"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(134, 21)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(54, 32)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 11.0 )"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(32, 21)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 32)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "( 8.2 )"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.Button2)
            Me.GroupBox2.Controls.Add(Me.TB_Actual_NA)
            Me.GroupBox2.Controls.Add(Me.TB_Actual_RN)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(895, 38)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(218, 139)
            Me.GroupBox2.TabIndex = 6
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Staff Actual (Staff)"
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(6, 100)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(206, 33)
            Me.Button2.TabIndex = 20
            Me.Button2.Text = "Set Staff"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'TB_Actual_NA
            '
            Me.TB_Actual_NA.Location = New System.Drawing.Point(112, 69)
            Me.TB_Actual_NA.Name = "TB_Actual_NA"
            Me.TB_Actual_NA.Size = New System.Drawing.Size(100, 22)
            Me.TB_Actual_NA.TabIndex = 8
            Me.TB_Actual_NA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Actual_RN
            '
            Me.TB_Actual_RN.Location = New System.Drawing.Point(6, 69)
            Me.TB_Actual_RN.Name = "TB_Actual_RN"
            Me.TB_Actual_RN.Size = New System.Drawing.Size(100, 22)
            Me.TB_Actual_RN.TabIndex = 7
            Me.TB_Actual_RN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(146, 37)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(29, 16)
            Me.Label8.TabIndex = 1
            Me.Label8.Text = "NA"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(40, 37)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(30, 16)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "RN"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(1013, -1)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(100, 33)
            Me.Button1.TabIndex = 19
            Me.Button1.Text = "Set Staff"
            Me.Button1.UseVisualStyleBackColor = True
            Me.Button1.Visible = False
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.TB_Need_NA)
            Me.GroupBox3.Controls.Add(Me.TB_Need_RN)
            Me.GroupBox3.Controls.Add(Me.Label9)
            Me.GroupBox3.Controls.Add(Me.Label10)
            Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.GroupBox3.Location = New System.Drawing.Point(675, 38)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(220, 139)
            Me.GroupBox3.TabIndex = 5
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Staff Need (Staff)"
            '
            'TB_Need_NA
            '
            Me.TB_Need_NA.Location = New System.Drawing.Point(112, 68)
            Me.TB_Need_NA.Name = "TB_Need_NA"
            Me.TB_Need_NA.Size = New System.Drawing.Size(100, 22)
            Me.TB_Need_NA.TabIndex = 6
            Me.TB_Need_NA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TB_Need_RN
            '
            Me.TB_Need_RN.Location = New System.Drawing.Point(6, 69)
            Me.TB_Need_RN.Name = "TB_Need_RN"
            Me.TB_Need_RN.Size = New System.Drawing.Size(100, 22)
            Me.TB_Need_RN.TabIndex = 5
            Me.TB_Need_RN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(148, 37)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(29, 16)
            Me.Label9.TabIndex = 1
            Me.Label9.Text = "NA"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(39, 35)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(30, 16)
            Me.Label10.TabIndex = 0
            Me.Label10.Text = "RN"
            '
            'BT_OK
            '
            Me.BT_OK.Location = New System.Drawing.Point(1218, 59)
            Me.BT_OK.Name = "BT_OK"
            Me.BT_OK.Size = New System.Drawing.Size(75, 45)
            Me.BT_OK.TabIndex = 10
            Me.BT_OK.Text = "OK"
            Me.BT_OK.UseVisualStyleBackColor = True
            '
            'BT_Clear
            '
            Me.BT_Clear.Location = New System.Drawing.Point(1218, 110)
            Me.BT_Clear.Name = "BT_Clear"
            Me.BT_Clear.Size = New System.Drawing.Size(75, 45)
            Me.BT_Clear.TabIndex = 11
            Me.BT_Clear.Text = "Clear All"
            Me.BT_Clear.UseVisualStyleBackColor = True
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.TB_Hour)
            Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.GroupBox4.Location = New System.Drawing.Point(1113, 38)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(99, 139)
            Me.GroupBox4.TabIndex = 7
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "ชั่วโมงเจ้าหน้าที่"
            '
            'TB_Hour
            '
            Me.TB_Hour.Location = New System.Drawing.Point(14, 69)
            Me.TB_Hour.Name = "TB_Hour"
            Me.TB_Hour.Size = New System.Drawing.Size(72, 21)
            Me.TB_Hour.TabIndex = 9
            Me.TB_Hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'DateTimePicker2
            '
            Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker2.Location = New System.Drawing.Point(247, 627)
            Me.DateTimePicker2.Name = "DateTimePicker2"
            Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
            Me.DateTimePicker2.TabIndex = 14
            '
            'DateTimePicker3
            '
            Me.DateTimePicker3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DateTimePicker3.Location = New System.Drawing.Point(516, 627)
            Me.DateTimePicker3.Name = "DateTimePicker3"
            Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
            Me.DateTimePicker3.TabIndex = 15
            '
            'Label11
            '
            Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(461, 633)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(43, 13)
            Me.Label11.TabIndex = 16
            Me.Label11.Text = "DateTo"
            '
            'Label12
            '
            Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label12.Location = New System.Drawing.Point(191, 633)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(50, 13)
            Me.Label12.TabIndex = 17
            Me.Label12.Text = "Datefrom"
            '
            'BT_PrintReport
            '
            Me.BT_PrintReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.BT_PrintReport.Location = New System.Drawing.Point(759, 627)
            Me.BT_PrintReport.Name = "BT_PrintReport"
            Me.BT_PrintReport.Size = New System.Drawing.Size(136, 38)
            Me.BT_PrintReport.TabIndex = 18
            Me.BT_PrintReport.Text = "Print Report Daily"
            Me.BT_PrintReport.UseVisualStyleBackColor = True
            '
            'Button3
            '
            Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Button3.Location = New System.Drawing.Point(938, 627)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(136, 38)
            Me.Button3.TabIndex = 20
            Me.Button3.Text = "Print Report Monthly"
            Me.Button3.UseVisualStyleBackColor = True
            '
            'OR_View
            '
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(1301, 674)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.BT_PrintReport)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.DateTimePicker3)
            Me.Controls.Add(Me.DateTimePicker2)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.BT_Clear)
            Me.Controls.Add(Me.BT_OK)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.DateTimePicker1)
            Me.Controls.Add(Me.BT_Export)
            Me.Controls.Add(Me.DGV_OR)
            Me.Name = "OR_View"
            Me.Text = "OR_View"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.DGV_OR, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox4.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private Function SelectDataFromDataTable(ByVal dt As DataTable, ByVal cmdString As String) As DataTable
            Dim dtResult As New DataTable

            dtResult = dt.Clone()

            Dim MyDataRow As DataRow
            'For Each MyDataRow In dt.Select("  ORI_OrderCategoryCode ='28' and   ORI_OrderStatusDesc not like 'D/C%' and PAPMI_HN <>'' ")
            For Each MyDataRow In dt.Select(cmdString)
                Dim row As Object() = MyDataRow.ItemArray
                dtResult.Rows.Add(row)
            Next MyDataRow


            Return dtResult

        End Function
        Private Function SelectDataFromDataSet(ByVal ds As DataSet, ByVal cmdString As String) As DataSet
            Dim dsResult As New DataSet

            dsResult = ds

            Dim MyDataRow As DataRow
            Try
                'For Each MyDataRow In dt.Tables(0).Select("  ORI_OrderCategoryCode ='28' and   ORI_OrderStatusDesc not like 'D/C%' and PAPMI_HN <>'' ")
                For Each MyDataRow In ds.Tables(0).Select(cmdString)
                    Dim row As Object() = MyDataRow.ItemArray
                    ds.Tables(0).Rows.Add(row)
                Next MyDataRow
            Catch

            End Try

            Return dsResult

        End Function
        Private Function ReadExcel(ByVal fileN As String, ByVal month As String) As DataSet
            Dim dsExcel As New DataSet

            Dim fileName As String = String.Format("{0}\" + fileN + " ", Directory.GetCurrentDirectory())
            Dim connectionString As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended properties=Excel 8.0;", fileName)

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" + month + "$]", connectionString)

            adapter.Fill(dsExcel, month)

            Return dsExcel
        End Function
        Private Function GetStaffDSFromExcel() As DataSet
            Dim dsExc As New DataSet
            Dim strMonth As Integer
            strMonth = Date.Now.Month

            Select Case strMonth
                Case 1
                    dsExc = ReadExcel("OR.xlsx", "jan")
                Case 2
                    dsExc = ReadExcel("OR.xlsx", "feb")
                Case 3
                    dsExc = ReadExcel("OR.xlsx", "mar")
                Case 4
                    dsExc = ReadExcel("OR.xlsx", "apr")
                Case 5
                    dsExc = ReadExcel("OR.xlsx", "may")
                Case 6
                    dsExc = ReadExcel("OR.xlsx", "jun")
                Case 7
                    dsExc = ReadExcel("OR.xlsx", "jul")
                Case 8
                    dsExc = ReadExcel("OR.xlsx", "aug")
                Case 9
                    dsExc = ReadExcel("OR.xlsx", "sep")
                Case 10
                    dsExc = ReadExcel("OR.xlsx", "oct")
                Case 11
                    dsExc = ReadExcel("OR.xlsx", "nov")
                Case 12
                    dsExc = ReadExcel("OR.xlsx", "dec")
            End Select

            Return dsExc
        End Function

        Public Sub Loaddata()

            Try
                Dim numClass6 As Integer
                Dim numClass6W As Integer
                Dim num2 As Integer
                Dim num3 As Integer
                Dim num4 As Integer
                Dim num5 As Integer
                Dim num6 As Integer
                Dim num9 As Integer
                Dim num10 As Integer
                Dim dataSet As New DataSet
                'If (Me.SCN_SQL3.State <> ConnectionState.Open) Then
                '    Me.SCN_SQL3.Open()
                'End If
                If OCN1.State <> ConnectionState.Open Then
                    OCN1.Open()
                End If
                Me.DGV_OR.Item(0, 1).Value = Me.DateTimePicker1.Value.ToString("dd/MM/yyyy")

                'Dim adapter As New SqlDataAdapter(("SELECT anaop_opstartdate, ANAOP_OPSTARTTIME, ANAOP_OPENDTIME, ANA_ANASTARTTIME, ANA_ANAFINISHTIME FROM dbo.vsvh_paorm WHERE   anaop_opstartdate ='" & Me.DateTimePicker1.Value.ToString("yyyyMMdd") & "' and  (RES_DESC LIKE '%SVH%') "), Me.SCN_SQL3) 'sql
                'Dim adapter As New OdbcDataAdapter(("SELECT anaop_opstartdate, isnull(ANAOP_OPSTARTTIME,'00:00') ANAOP_OPSTARTTIME, isnull(ANAOP_OPENDTIME, '00:00') ANAOP_OPENDTIME, isnull(ANA_ANASTARTTIME,'00:00') ANA_ANASTARTTIME, isnull(ANA_ANAFINISHTIME,'00:00') ANA_ANAFINISHTIME FROM vsvh_paorm WHERE   anaop_opstartdate ='" & Me.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and  (Trim(Left(PAADM_ADMNo,3)) like '%11%') "), Me.OCN1) 'cache by view
                'Dim adapter As New OdbcDataAdapter(("SELECT anaop_opstartdate, isnull(ANAOP_OPSTARTTIME,'00:00') ANAOP_OPSTARTTIME, isnull(ANAOP_OPENDTIME, '00:00') ANAOP_OPENDTIME, isnull(ANA_ANASTARTTIME,'00:00') ANA_ANASTARTTIME, isnull(ANA_ANAFINISHTIME,'00:00') ANA_ANAFINISHTIME FROM PA_Adm,OR_Anaesthesia,OR_Anaest_Operation WHERE PA_Adm.PAADM_RowID = OR_Anaesthesia.ANA_PAADM_ParRef and OR_Anaesthesia.ANA_RowId = OR_Anaest_Operation.ANAOP_Par_Ref and {fn CONVERT(anaop_opstartdate,SQL_VARCHAR)} ='" & Me.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and  (Trim(Left(PAADM_ADMNo,3)) like '%11%') "), Me.OCN1) 'cache by join table

                'TO_DATE('21/12/2015','DD/MM/YYYY')

                Dim dt1 As New DataTable
                Dim adapter As New OdbcDataAdapter
                dataSet.Clear()

                Dim queryString As String = "select ANAOP_OpStartDate,isnull(ANAOP_OPSTARTTIME,'00:00') ANAOP_OPSTARTTIME,isnull(ANAOP_OPENDTIME, '00:00') ANAOP_OPENDTIME,isnull(ANAOP_Par_Ref->ANA_AnaStartTime,'00:00') ANA_ANASTARTTIME,isnull(ANAOP_Par_Ref->ANA_ANAFINISHTIME,'00:00') ANA_ANAFINISHTIME ,RIGHT(LEFT(ANAOP_Par_Ref->ANA_PAADM_ParRef->PAADM_ADMNO,3),2) BUID from OR_Anaest_Operation where ANAOP_OpStartDate = '" & Me.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'"

                dt1 = cacheDb.GetDTByQueryString(queryString)

                Dim dv As DataView = New DataView(dt1)
                dv.RowFilter = "BUID = '11' "

                dt1 = dv.ToTable

                'dt1 = cacheDb.GetDTByQueryString("SELECT anaop_opstartdate, isnull(ANAOP_OPSTARTTIME,'00:00') ANAOP_OPSTARTTIME, isnull(ANAOP_OPENDTIME, '00:00') ANAOP_OPENDTIME, isnull(ANA_ANASTARTTIME,'00:00') ANA_ANASTARTTIME, isnull(ANA_ANAFINISHTIME,'00:00') ANA_ANAFINISHTIME FROM PA_Adm,OR_Anaesthesia,OR_Anaest_Operation WHERE PA_Adm.PAADM_RowID = OR_Anaesthesia.ANA_PAADM_ParRef and OR_Anaesthesia.ANA_RowId = OR_Anaest_Operation.ANAOP_Par_Ref and {fn CONVERT(anaop_opstartdate,SQL_VARCHAR)} ='" & Me.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and  (Trim(Left(PAADM_ADMNo,3)) like '%11%') ")
                'adapter.SelectCommand.CommandTimeout = 5000000
                'adapter.Fill(dataSet, "vsvh_paorm1")
                dataSet = New DataSet
                dataSet.Tables.Add(dt1)


                Dim num14 As Double = 0
                Dim num15 As Double = 0
                Dim num16 As Double = 0
                Dim num17 As Double = 0
                Dim num18 As Double = 0
                Dim num20 As Integer = (dataSet.Tables.Item(0).Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num20)

                    Dim n7ANASTARTTIME As Date = Date.Parse(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANASTARTTIME").ToString())
                    Dim n7ANAFINISHTIME As Date = Date.Parse(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANAFINISHTIME").ToString())
                    Dim n7OPSTARTTIME As Date = Date.Parse(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPSTARTTIME").ToString())
                    Dim n7OPENDTIME As Date = Date.Parse(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPENDTIME").ToString())

                    Dim num As Double
                    Dim time As DateTime
                    Dim num7 As Integer
                    Dim ts As TimeSpan = TimeSpan.Parse("00:00")
                    If Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANASTARTTIME"), ts, False), Operators.CompareObjectEqual(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANAFINISHTIME"), ts, False))) Then
                        If Operators.ConditionalCompareObjectGreater(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPSTARTTIME"), dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPENDTIME"), False) Then
                            time = Conversions.ToDate("23:59")
                            'num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPSTARTTIME")), time, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(n7OPSTARTTIME), time, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            time = Conversions.ToDate("00:00")
                            'num7 = (num7 + CInt(DateAndTime.DateDiff(DateInterval.Minute, time, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPENDTIME")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)))
                            num7 = (num7 + CInt(DateAndTime.DateDiff(DateInterval.Minute, time, Conversions.ToDate(n7OPENDTIME), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)))
                            num7 += 1
                        Else
                            'num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPSTARTTIME")), Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANAOP_OPENDTIME")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(n7OPSTARTTIME), Conversions.ToDate(n7OPENDTIME), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                        End If
                        num = Conversions.ToDouble((Conversions.ToString(Conversion.Int(CDbl((CDbl(num7) / 60)))) & "." & Conversions.ToString(CInt((num7 Mod 60)))))
                        If (num <= 1.3) Then ' dif ANAOP_OPSTARTTIME, ANAOP_OPENDTIME <= 78 minute
                            num2 += 1
                            Me.TB_Class1W.Text = Conversions.ToString(num2)
                        ElseIf ((num >= 1.31) And (num <= 2.3)) Then ' dif ANAOP_OPSTARTTIME, ANAOP_OPENDTIME 79-138
                            num3 += 1
                            Me.TB_Class2W.Text = Conversions.ToString(num3)
                        ElseIf ((num >= 2.31) And (num <= 3.3)) Then
                            num4 += 1
                            Me.TB_Class3W.Text = Conversions.ToString(num4)
                        ElseIf ((num >= 3.31) And (num <= 4.3)) Then
                            num5 += 1
                            Me.TB_Class4W.Text = Conversions.ToString(num5)
                        ElseIf ((num >= 4.31) And (num <= 6)) Then
                            num6 += 1
                            Me.TB_Class5W.Text = Conversions.ToString(num6)
                        ElseIf ((num > 6)) Then ' dif ANAOP_OPSTARTTIME, ANAOP_OPENDTIME > 360 minute
                            numClass6 += 1
                            Me.TB_Class6W.Text = Conversions.ToString(numClass6)
                        End If
                    Else
                        If Operators.ConditionalCompareObjectGreater(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANASTARTTIME"), dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANAFINISHTIME"), False) Then
                            time = Conversions.ToDate("23:59")
                            'num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANASTARTTIME")), time, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(n7ANASTARTTIME), time, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            time = Conversions.ToDate("00:00")
                            'num7 = (num7 + CInt(DateAndTime.DateDiff(DateInterval.Minute, time, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANAFINISHTIME")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)))
                            num7 = (num7 + CInt(DateAndTime.DateDiff(DateInterval.Minute, time, Conversions.ToDate(n7ANAFINISHTIME), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)))
                            num7 += 1
                        Else
                            'num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANASTARTTIME")), Conversions.ToDate(dataSet.Tables.Item(0).Rows.Item(i).Item("ANA_ANAFINISHTIME")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                            num7 = CInt(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(n7ANASTARTTIME), Conversions.ToDate(n7ANAFINISHTIME), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                        End If
                        num = Conversions.ToDouble((Conversions.ToString(Conversion.Int(CDbl((CDbl(num7) / 60)))) & "." & Conversions.ToString(CInt((num7 Mod 60)))))
                        If (num <= 1.3) Then
                            num2 += 1
                            Me.TB_Class1W.Text = Conversions.ToString(num2)
                        ElseIf ((num >= 1.31) And (num <= 2.3)) Then
                            num3 += 1
                            Me.TB_Class2W.Text = Conversions.ToString(num3)
                        ElseIf ((num >= 2.31) And (num <= 3.3)) Then
                            num4 += 1
                            Me.TB_Class3W.Text = Conversions.ToString(num4)
                        ElseIf ((num >= 3.31) And (num <= 4.3)) Then
                            num5 += 1
                            Me.TB_Class4W.Text = Conversions.ToString(num5)
                        ElseIf ((num >= 4.31) And (num <= 6)) Then
                            num6 += 1
                            Me.TB_Class5W.Text = Conversions.ToString(num6)
                        ElseIf (num > 6) Then
                            numClass6 += 1
                            Me.TB_Class6W.Text = Conversions.ToString(numClass6)
                        End If
                    End If
                    i += 1
                Loop
                If (Me.TB_Class1W.Text = "") Then
                    num2 = 0
                Else
                    num2 = Conversions.ToInteger(Me.TB_Class1W.Text)
                End If
                If (Me.TB_Class2W.Text = "") Then
                    num3 = 0
                Else
                    num3 = Conversions.ToInteger(Me.TB_Class2W.Text)
                End If
                If (Me.TB_Class3W.Text = "") Then
                    num4 = 0
                Else
                    num4 = Conversions.ToInteger(Me.TB_Class3W.Text)
                End If
                If (Me.TB_Class4W.Text = "") Then
                    num5 = 0
                Else
                    num5 = Conversions.ToInteger(Me.TB_Class4W.Text)
                End If
                If (Me.TB_Class5W.Text = "") Then
                    num6 = 0
                Else
                    num6 = Conversions.ToInteger(Me.TB_Class5W.Text)
                End If
                If (Me.TB_Class6W.Text = "") Then
                    numClass6 = 0
                Else
                    numClass6 = Conversions.ToInteger(Me.TB_Class6W.Text)
                End If
                num14 = (8.2 * num2)
                num15 = (11 * num3)
                num16 = (16 * num4)
                num17 = (22.3 * num5)
                num18 = (27 * num6)
                numClass6W = (39 * numClass6)
                Me.TB_Class1.Text = num14.ToString("N2")
                Me.TB_Class2.Text = num15.ToString("N2")
                Me.TB_Class3.Text = num16.ToString("N2")
                Me.TB_Class4.Text = num17.ToString("N2")
                Me.TB_Class5.Text = num18.ToString("N2")
                Me.TB_Class6.Text = numClass6W.ToString("N2")
                Me.DGV_OR.Item(1, 1).Value = ((((num2 + num3) + num4) + num5) + num6 + numClass6)
                Me.DGV_OR.Item(2, 1).Value = num2
                Me.DGV_OR.Item(3, 1).Value = num14.ToString("N2")
                Me.DGV_OR.Item(4, 1).Value = num3
                Me.DGV_OR.Item(5, 1).Value = num15.ToString("N2")
                Me.DGV_OR.Item(6, 1).Value = num4
                Me.DGV_OR.Item(7, 1).Value = num16.ToString("N2")
                Me.DGV_OR.Item(8, 1).Value = num5
                Me.DGV_OR.Item(9, 1).Value = num17.ToString("N2")
                Me.DGV_OR.Item(10, 1).Value = num6
                Me.DGV_OR.Item(11, 1).Value = num18.ToString("N2")
                Me.DGV_OR.Item(12, 1).Value = numClass6
                Me.DGV_OR.Item(13, 1).Value = numClass6W.ToString("N2")
                Me.DGV_OR.Item(14, 1).Value = ((((num14 + num15) + num16) + num17) + num18 + numClass6W).ToString("N2")
                Dim num13 As Double = Conversions.ToDouble((((((((num14 + num15) + num16) + num17) + num18 + numClass6W) / 8) * 80) / 100).ToString("n2"))
                Dim num12 As Double = Conversions.ToDouble((((((((num14 + num15) + num16) + num17) + num18 + numClass6W) / 8) * 20) / 100).ToString("n2"))
                Dim num11 As Double = Conversions.ToDouble((((((num14 + num15) + num16) + num17) + num18 + numClass6W) / 8).ToString("n2"))
                Me.TB_Need_RN.Text = num13.ToString("N2")
                Me.TB_Need_NA.Text = num12.ToString("N2")
                Me.DGV_OR.Item(15, 1).Value = num11.ToString("N2")
                Me.DGV_OR.Item(16, 1).Value = num13.ToString("N2")
                Me.DGV_OR.Item(17, 1).Value = num12.ToString("N2")
                If (Me.TB_Actual_NA.Text = "") Then
                    num9 = 0
                Else
                    num9 = Conversions.ToInteger(Me.TB_Actual_NA.Text)
                End If
                If (Me.TB_Actual_RN.Text = "") Then
                    num10 = 0
                Else
                    num10 = Conversions.ToInteger(Me.TB_Actual_RN.Text)
                End If
                Me.DGV_OR.Item(&H10 + 2, 1).Value = (Conversion.Int(num9) + Conversion.Int(num10))
                Me.DGV_OR.Item(&H11 + 2, 1).Value = num10
                Me.DGV_OR.Item(&H12 + 2, 1).Value = num9
                Dim num8 As Double = 0
                If (Me.TB_Hour.Text = "") Then
                    Me.hour1 = 0
                Else
                    Me.hour1 = Conversions.ToDouble(Me.TB_Hour.Text)
                End If
                'num8 is Productivity(%)
                num8 = Conversions.ToDouble(((((((num14 + num15) + num16) + num17) + num18 + numClass6W) / Me.hour1) * 100).ToString("N2"))
                Me.DGV_OR.Item(&H13 + 2, 1).Value = num8
                Me.DGV_OR.Item(22, 1).Value = (((CDbl(num10) / CDbl((num10 + num9))) * 100) / ((CDbl(num9) / CDbl((num10 + num9))) * 100)).ToString("n2")
                Me.SCN_SQL3.Close()
                Me.TB_Class1.Focus()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Interaction.MsgBox("ข้อมูลผิดพลาด หรือ Please Key Data Is Number : Loaddata() ! ; " + exception1.ToString + " ", MsgBoxStyle.ApplicationModal, Nothing)
                Me.TB_Class1.Focus()
                ProjectData.ClearProjectError()
                Return
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Sub Loaddata_SumCurrent()
            Try
                Dim str2 As String
                Dim num9 As Integer
                Dim dataSet As New DataSet
                Dim set2 As New DataSet
                Dim num2 As Integer = 3
                If (Me.SCN_SQL2.State <> ConnectionState.Open) Then
                    Me.SCN_SQL2.Open()
                End If
                If (Me.DateTimePicker1.Value.ToString("yyyy") <> DateAndTime.Now.Year.ToString("yyyy")) Then
                    str2 = (Me.DateTimePicker1.Value.ToString("yyyy") & "1231")
                Else
                    str2 = DateAndTime.Now.Year.ToString("yyyyMMdd")
                End If
                Dim adapter As New SqlDataAdapter(String.Concat(New String() {" select sum(SumADC) as SumADC, sum(Patient_Class1) as Patient_Class1, sum(Patient_ClassHour1) as Patient_ClassHour1, sum(Patient_Class2) as Patient_Class2, sum(Patient_ClassHour2) as Patient_ClassHour2, sum(Patient_Class3) as Patient_Class3, sum(Patient_ClassHour3) as Patient_ClassHour3, sum(Patient_Class4) as Patient_Class4,  sum(Patient_ClassHour4) as Patient_ClassHour4, sum(Patient_Class5) as Patient_Class5, sum(Patient_ClassHour5) as Patient_ClassHour5,sum(Patient_Class6) as Patient_Class6, sum(Patient_ClassHour6) as Patient_ClassHour6, sum(Sum_Hour) as Sum_Hour, sum(Staff_Need_Mix) as Staff_Need_Mix, sum(Staff_Need_RN) as Staff_Need_RN, sum(Staff_Need_NA) as Staff_Need_NA, sum(Staff_Actual_Mix) as Staff_Actual_Mix, sum(Staff_Actual_RN) as Staff_Actual_RN,  sum(Staff_Actual_NA) as Staff_Actual_NA, SUM(Productivity) AS Productivity,SUM(RN_Non) AS RN_Non, sum(Hour_User) as Hour_User  FROM  OR_Productivity WHERE Date_Add >= '", Me.DateTimePicker1.Value.ToString("yyyy"), "0101' and Date_Add <= '", str2, "' "}), Me.SCN_SQL2)
                dataSet.Clear()
                adapter.Fill(dataSet, "OR_Productivity")
                Dim num As Integer = 2
                Dim num7 As Integer = (dataSet.Tables.Item(0).Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num7)
                    Me.DGV_OR.Item(1, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("SumADC"))
                    Me.DGV_OR.Item(2, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class1"))
                    Me.DGV_OR.Item(3, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour1"))
                    Me.DGV_OR.Item(4, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class2"))
                    Me.DGV_OR.Item(5, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour2"))
                    Me.DGV_OR.Item(6, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class3"))
                    Me.DGV_OR.Item(7, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour3"))
                    Me.DGV_OR.Item(8, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class4"))
                    Me.DGV_OR.Item(9, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour4"))
                    Me.DGV_OR.Item(10, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class5"))
                    Me.DGV_OR.Item(11, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour5"))
                    Me.DGV_OR.Item(12, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_Class6"))
                    Me.DGV_OR.Item(13, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Patient_ClassHour6"))
                    Me.DGV_OR.Item(14, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Sum_Hour"))
                    Me.DGV_OR.Item(15, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Need_Mix"))
                    Me.DGV_OR.Item(16, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Need_RN"))
                    Me.DGV_OR.Item(17, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Need_NA"))
                    Me.DGV_OR.Item(&H10 + 2, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Actual_Mix"))
                    Me.DGV_OR.Item(&H11 + 2, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Actual_RN"))
                    Me.DGV_OR.Item(&H12 + 2, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Staff_Actual_NA"))
                    Me.DGV_OR.Item(&H13 + 2, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("Productivity"))
                    Me.DGV_OR.Item(22, num).Value = RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(i).Item("RN_Non"))
                    i += 1
                Loop
                Dim num4 As Integer = 3
                Do
                    Dim str3 As String = ""
                    If (num2 = 3) Then
                        str3 = (" WHERE      Month(Date_Add) = '01' and  Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 4) Then
                        str3 = (" WHERE      Month(Date_Add) = '02' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 5) Then
                        str3 = (" WHERE      Month(Date_Add) = '03' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 7) Then
                        str3 = (" WHERE      Month(Date_Add) = '04' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 8) Then
                        str3 = (" WHERE      Month(Date_Add) = '05' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 9) Then
                        str3 = (" WHERE      Month(Date_Add) = '06' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 11) Then
                        str3 = (" WHERE      Month(Date_Add) = '07' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 12) Then
                        str3 = (" WHERE      Month(Date_Add) = '08' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 13) Then
                        str3 = (" WHERE      Month(Date_Add) = '09' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 15) Then
                        str3 = (" WHERE      Month(Date_Add) = '10' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = &H10) Then
                        str3 = (" WHERE      Month(Date_Add) = '11' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = &H11) Then
                        str3 = (" WHERE      Month(Date_Add) = '12' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 6) Then
                        str3 = (" WHERE      Month(Date_Add) >= '01' and Month(Date_Add) <= '03' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 10) Then
                        str3 = (" WHERE      Month(Date_Add) >= '04' and Month(Date_Add) <= '06' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = 14) Then
                        str3 = (" WHERE      Month(Date_Add) >= '07' and Month(Date_Add) <= '09' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = &H12) Then
                        str3 = (" WHERE      Month(Date_Add) >= '10' and Month(Date_Add) <= '12' and Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'")
                    ElseIf (num2 = &H13) Then
                        str3 = (" WHERE      Year(Date_Add) = '" & Me.DateTimePicker1.Value.ToString("yyyy") & "'  ")
                    End If
                    Dim adapter2 As New SqlDataAdapter((" select sum(SumADC) as SumADC, sum(Patient_Class1) as Patient_Class1, sum(Patient_ClassHour1) as Patient_ClassHour1, sum(Patient_Class2) as Patient_Class2, sum(Patient_ClassHour2) as Patient_ClassHour2, sum(Patient_Class3) as Patient_Class3, sum(Patient_ClassHour3) as Patient_ClassHour3, sum(Patient_Class4) as Patient_Class4,  sum(Patient_ClassHour4) as Patient_ClassHour4, sum(Patient_Class5) as Patient_Class5, sum(Patient_ClassHour5) as Patient_ClassHour5, sum(Patient_Class6) as Patient_Class6, sum(Patient_ClassHour6) as Patient_ClassHour6, sum(Sum_Hour) as Sum_Hour, sum(Staff_Need_Mix) as Staff_Need_Mix, sum(Staff_Need_RN) as Staff_Need_RN, sum(Staff_Need_NA) as Staff_Need_NA, sum(Staff_Actual_Mix) as Staff_Actual_Mix, sum(Staff_Actual_RN) as Staff_Actual_RN,  sum(Staff_Actual_NA) as Staff_Actual_NA, SUM(Productivity) AS Productivity,SUM(RN_Non) AS RN_Non, sum(Hour_User) as Hour_User  FROM  OR_Productivity" & str3), Me.SCN_SQL2)
                    set2.Clear()
                    adapter2.Fill(set2, "OR_Productivity1")
                    Dim num8 As Integer = (set2.Tables.Item("OR_Productivity1").Rows.Count - 1)
                    Dim j As Integer = 0
                    Do While (j <= num8)
                        Me.DGV_OR.Item(1, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("SumADC"))
                        Me.DGV_OR.Item(2, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class1"))
                        Me.DGV_OR.Item(3, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour1"))
                        Me.DGV_OR.Item(4, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class2"))
                        Me.DGV_OR.Item(5, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour2"))
                        Me.DGV_OR.Item(6, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class3"))
                        Me.DGV_OR.Item(7, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour3"))
                        Me.DGV_OR.Item(8, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class4"))
                        Me.DGV_OR.Item(9, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour4"))
                        Me.DGV_OR.Item(10, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class5"))
                        Me.DGV_OR.Item(11, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour5"))
                        Me.DGV_OR.Item(12, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_Class6"))
                        Me.DGV_OR.Item(13, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Patient_ClassHour6"))
                        Me.DGV_OR.Item(14, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Sum_Hour"))
                        Me.DGV_OR.Item(15, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Need_Mix"))
                        Me.DGV_OR.Item(16, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Need_RN"))
                        Me.DGV_OR.Item(17, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Need_NA"))
                        Me.DGV_OR.Item(&H10 + 2, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Actual_Mix"))
                        Me.DGV_OR.Item(&H11 + 2, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Actual_RN"))
                        Me.DGV_OR.Item(&H12 + 2, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Staff_Actual_NA"))
                        Me.DGV_OR.Item(&H13 + 2, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("Productivity"))
                        Me.DGV_OR.Item(22, num2).Value = RuntimeHelpers.GetObjectValue(set2.Tables.Item(0).Rows.Item(j).Item("RN_Non"))
                        num2 += 1
                        j += 1
                    Loop
                    num4 += 1
                    num9 = &H13
                Loop While (num4 <= num9)
                Me.SCN_SQL3.Close()
                Me.TB_Class1.Focus()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Me.TB_Class1.Focus()
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Private Sub OR_View_Load(ByVal sender As Object, ByVal e As EventArgs)
            Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
            Me.DateTimePicker1.Value = DateAndTime.DateAdd(DateInterval.Day, -2, DateAndTime.Now.Date)
        End Sub

        Public Sub SaveData()
            Try
                If (Interaction.MsgBox("คุณต้องการบันทึกข้อมูลหรือไม่", MsgBoxStyle.OkCancel, Nothing) = MsgBoxResult.Ok) Then
                    Dim dataSet As New DataSet
                    If (Me.SCN_SQL2.State <> ConnectionState.Open) Then
                        Me.SCN_SQL2.Open()
                    End If
                    Dim adapter As New SqlDataAdapter((" select RowID, Date_Add, SumADC, Patient_Class1, Patient_ClassHour1, Patient_Class2, Patient_ClassHour2, Patient_Class3, Patient_ClassHour3, Patient_Class4,  Patient_ClassHour4, Patient_Class5, Patient_ClassHour5, Patient_Class6, Patient_ClassHour6, Sum_Hour, Staff_Need_Mix, Staff_Need_RN, Staff_Need_NA, Staff_Actual_Mix, Staff_Actual_RN,  Staff_Actual_NA, Hour_User  FROM  OR_Productivity WHERE      Date_Add = '" & Me.DateTimePicker1.Value.ToString("yyyyMMdd") & "' "), Me.SCN_SQL2)
                    dataSet.Clear()
                    adapter.Fill(dataSet, "OR_Productivity")
                    If (dataSet.Tables.Item(0).Rows.Count = 0) Then
                        Dim rd As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(("INSERT INTO [Productivity].[dbo].[OR_Productivity]([Date_Add], [SumADC], [Patient_Class1], [Patient_ClassHour1],  [Patient_Class2], [Patient_ClassHour2], [Patient_Class3], [Patient_ClassHour3], [Patient_Class4], [Patient_ClassHour4], [Patient_Class5], [Patient_ClassHour5], [Patient_Class6], [Patient_ClassHour6], [Sum_Hour], [Staff_Need_Mix], [Staff_Need_RN], [Staff_Need_NA], [Staff_Actual_Mix], [Staff_Actual_RN], [Staff_Actual_NA], [Productivity],[RN_Non],[Hour_User]) VALUES( '" & Me.DateTimePicker1.Value.ToString("yyyyMMdd") & "',"), Me.DGV_OR.Item(1, 1).Value), ", "), Me.DGV_OR.Item(2, 1).Value), ", "), Me.DGV_OR.Item(3, 1).Value), ", "), Me.DGV_OR.Item(4, 1).Value), ", "), Me.DGV_OR.Item(5, 1).Value), ","), " "), Me.DGV_OR.Item(6, 1).Value), ", "), Me.DGV_OR.Item(7, 1).Value), ", "), Me.DGV_OR.Item(8, 1).Value), ", "), Me.DGV_OR.Item(9, 1).Value), ", "), Me.DGV_OR.Item(10, 1).Value), ","), " "), Me.DGV_OR.Item(11, 1).Value), ", "), Me.DGV_OR.Item(12, 1).Value), ", "), Me.DGV_OR.Item(13, 1).Value), ", "), Me.DGV_OR.Item(14, 1).Value), ", "), Me.DGV_OR.Item(15, 1).Value), ", "), Me.DGV_OR.Item(16, 1).Value), ", "), Me.DGV_OR.Item(17, 1).Value), ","), " "), Me.DGV_OR.Item(&H10 + 2, 1).Value), ", "), Me.DGV_OR.Item(&H11 + 2, 1).Value), ","), Me.DGV_OR.Item(&H12 + 2, 1).Value), ","), Me.DGV_OR.Item(&H13 + 2, 1).Value), ","), Me.DGV_OR.Item(22, 1).Value), ", "), Me.hour1), ") "))
                        'Dim rd As String = "INSERT INTO [Productivity].[dbo].[OR_Productivity]([Date_Add], [SumADC], [Patient_Class1], [Patient_ClassHour1],  [Patient_Class2], [Patient_ClassHour2], [Patient_Class3], [Patient_ClassHour3], [Patient_Class4], [Patient_ClassHour4], [Patient_Class5], [Patient_ClassHour5], [Patient_Class6], [Patient_ClassHour6], [Sum_Hour], [Staff_Need_Mix], [Staff_Need_RN], [Staff_Need_NA], [Staff_Actual_Mix], [Staff_Actual_RN], [Staff_Actual_NA], [Productivity],[RN_Non],[Hour_User]) "
                        'rd += " Values (@Date_Add, @SumADC, @Patient_Class1, @Patient_ClassHour1,  @Patient_Class2, @Patient_ClassHour2, @Patient_Class3, @Patient_ClassHour3, @Patient_Class4, @Patient_ClassHour4, @Patient_Class5, @Patient_ClassHour5, @Patient_Class6, @Patient_ClassHour6, @Sum_Hour, @Staff_Need_Mix, @Staff_Need_RN, @Staff_Need_NA, @Staff_Actual_Mix, @Staff_Actual_RN, @Staff_Actual_NA, @Productivity,@RN_Non,@Hour_User) "

                        Dim reader As SqlDataReader = New SqlCommand(rd, Me.SCN_SQL2).ExecuteReader
                    Else
                        Dim rd2 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(("UPDATE [Productivity].[dbo].[OR_Productivity]  SET  [Date_Add]='" & Me.DateTimePicker1.Value.ToString("yyyyMMdd") & "', [SumADC]="), Me.DGV_OR.Item(1, 1).Value), ", "), " [Patient_Class1]="), Me.DGV_OR.Item(2, 1).Value), ", [Patient_ClassHour1]="), Me.DGV_OR.Item(3, 1).Value), ","), " [Patient_Class2]="), Me.DGV_OR.Item(4, 1).Value), ", [Patient_ClassHour2]="), Me.DGV_OR.Item(5, 1).Value), ", "), " [Patient_Class3]="), Me.DGV_OR.Item(6, 1).Value), ", [Patient_ClassHour3]="), Me.DGV_OR.Item(7, 1).Value), ", "), " [Patient_Class4]="), Me.DGV_OR.Item(8, 1).Value), ", [Patient_ClassHour4]="), Me.DGV_OR.Item(9, 1).Value), ", "), " [Patient_Class5]="), Me.DGV_OR.Item(10, 1).Value), ", [Patient_ClassHour5]="), Me.DGV_OR.Item(11, 1).Value), ", "), " [Patient_Class6]="), Me.DGV_OR.Item(12, 1).Value), ", [Patient_ClassHour6]="), Me.DGV_OR.Item(13, 1).Value), ", "), " [Sum_Hour]="), Me.DGV_OR.Item(14, 1).Value), ", [Staff_Need_Mix]="), Me.DGV_OR.Item(15, 1).Value), ", [Staff_Need_RN]="), Me.DGV_OR.Item(16, 1).Value), ","), " [Staff_Need_NA]="), Me.DGV_OR.Item(17, 1).Value), ", [Staff_Actual_Mix]="), Me.DGV_OR.Item(&H10 + 2, 1).Value), ", [Staff_Actual_RN]="), Me.DGV_OR.Item(&H11 + 2, 1).Value), ", "), " [Staff_Actual_NA]="), Me.DGV_OR.Item(&H12 + 2, 1).Value), ", Productivity="), Me.DGV_OR.Item(&H13 + 2, 1).Value), ",[RN_Non]="), Me.DGV_OR.Item(22, 1).Value), ",[Hour_User]= "), Me.hour1), ""), " where [Date_Add]='"), Me.DateTimePicker1.Value.ToString("yyyyMMdd")), "'"))
                        'Dim rd2 As String = "UPDATE [Productivity].[dbo].[OR_Productivity]  SET  [Date_Add]=@Date_Add , [SumADC]=@SumADC , [Patient_Class1]=@Patient_Class1 , [Patient_ClassHour1]=@Patient_ClassHour1, "
                        'rd2 += " [Patient_Class2]=@Patient_Class2,  [Patient_ClassHour2]=@Patient_ClassHour2, [Patient_Class3]=@Patient_Class3, [Patient_ClassHour3]=@Patient_ClassHour3, [Patient_Class4]=@Patient_Class4, [Patient_ClassHour4]=@Patient_ClassHour4, "
                        'rd2 += " [Patient_Class5]=@Patient_Class5, [Patient_ClassHour5]=@Patient_ClassHour5 ,  [Patient_Class6]=@Patient_Class6, [Patient_ClassHour6]=@Patient_ClassHour6,  [Sum_Hour]=@Sum_Hour,  [Staff_Need_Mix]=@Staff_Need_Mix,  "
                        'rd2 += " [Staff_Need_RN]=@Staff_Need_RN, [Staff_Need_NA]=@Staff_Need_NA, [Staff_Actual_Mix]=@Staff_Actual_Mix, [Staff_Actual_RN]=@Staff_Actual_RN, [Staff_Actual_NA]=@Staff_Actual_NA, Productivity=@Productivity, [RN_Non]=@RN_Non, [Hour_User]=@Hour_User  where [Date_Add]= "
                        Dim reader2 As SqlDataReader = New SqlCommand(rd2, Me.SCN_SQL2).ExecuteReader
                    End If
                End If
                Me.SCN_SQL2.Close()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Interaction.MsgBox("ข้อมูลผิดพลาด หรือ Please Key Data Is Number !", MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError()
                Return
                ProjectData.ClearProjectError()
            End Try
        End Sub
        Function InsertProductivity(ByVal strCmd As String) As Boolean

            Dim stat As Boolean = False

            Dim cmd As New SqlCommand(strCmd, SCN_SQL2)
            Try

                cmd.Parameters.AddWithValue("@Date_Add", Me.DateTimePicker1.Value.ToString("yyyyMMdd"))

                cmd.ExecuteNonQuery()
                stat = True
            Catch ex As Exception

            End Try


            Return stat
        End Function
        Function UpdateProductivity(ByVal strCmd As String) As Boolean

            Dim stat As Boolean = False

            Dim cmd As New SqlCommand(strCmd, SCN_SQL2)
            Try
                cmd.ExecuteNonQuery()
                stat = True
            Catch ex As Exception

            End Try


            Return stat
        End Function
        Public Sub ClearActualStaff()
            Me.TB_Actual_RN.Text = ""
            Me.TB_Actual_NA.Text = ""
            Me.TB_Hour.Text = ""
        End Sub
        Public Sub SetFrom()
            Me.TB_Class1.Text = ""
            Me.TB_Class1W.Text = ""
            Me.TB_Class2.Text = ""
            Me.TB_Class2W.Text = ""
            Me.TB_Class3.Text = ""
            Me.TB_Class3W.Text = ""
            Me.TB_Class4.Text = ""
            Me.TB_Class4W.Text = ""
            Me.TB_Class5.Text = ""
            Me.TB_Class5W.Text = ""

            'Me.TB_Actual_RN.Text = ""
            'Me.TB_Actual_NA.Text = ""
            'Me.TB_Hour.Text = ""

            Me.DGV_OR.Rows.Add(&H13)
            Me.DGV_OR.Item(0, 2).Value = "AVG.(Jan-Current Date)"
            Me.DGV_OR.Rows.Item(1).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Rows.Item(2).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(0, 3).Value = "January"
            Me.DGV_OR.Item(0, 4).Value = "February"
            Me.DGV_OR.Item(0, 5).Value = "March"
            Me.DGV_OR.Item(0, 6).Value = "Q1"
            Me.DGV_OR.Rows.Item(6).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(0, 7).Value = "April"
            Me.DGV_OR.Item(0, 8).Value = "May"
            Me.DGV_OR.Item(0, 9).Value = "June"
            Me.DGV_OR.Item(0, 10).Value = "Q2"
            Me.DGV_OR.Rows.Item(10).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(0, 11).Value = "July"
            Me.DGV_OR.Item(0, 12).Value = "August"
            Me.DGV_OR.Item(0, 13).Value = "September"
            Me.DGV_OR.Item(0, 14).Value = "Q3"
            Me.DGV_OR.Rows.Item(14).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(0, 15).Value = "October"
            Me.DGV_OR.Item(0, &H10).Value = "November"
            Me.DGV_OR.Item(0, &H11).Value = "December"
            Me.DGV_OR.Item(0, &H12).Value = "Q4"
            Me.DGV_OR.Rows.Item(&H12).DefaultCellStyle.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(0, &H13).Value = "Yearly"
            Me.DGV_OR.Rows.Item(&H13).DefaultCellStyle.BackColor = Color.DarkGray
            Me.DGV_OR.Item(2, 0).Value = "1"
            Me.DGV_OR.Item(3, 0).Value = "8.2"
            Me.DGV_OR.Item(3, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(4, 0).Value = "2"
            Me.DGV_OR.Item(5, 0).Value = "11.0"
            Me.DGV_OR.Item(5, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(6, 0).Value = "3"
            Me.DGV_OR.Item(7, 0).Value = "16.0"
            Me.DGV_OR.Item(7, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(8, 0).Value = "4"
            Me.DGV_OR.Item(9, 0).Value = "22.3"
            Me.DGV_OR.Item(9, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(10, 0).Value = "5"
            Me.DGV_OR.Item(11, 0).Value = "27.0"
            Me.DGV_OR.Item(11, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(12, 0).Value = "6"
            Me.DGV_OR.Item(13, 0).Value = "39.0"
            Me.DGV_OR.Item(13, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(14, 0).Style.BackColor = Color.Gainsboro
            Me.DGV_OR.Item(15, 0).Value = "Mix"
            Me.DGV_OR.Item(16, 0).Value = "RN(80%)"
            Me.DGV_OR.Item(17, 0).Value = "NRN(20%)"
            Me.DGV_OR.Item(&H10 + 2, 0).Value = "Staff Mix"
            Me.DGV_OR.Item(&H11 + 2, 0).Value = "RN"
            Me.DGV_OR.Item(&H12 + 2, 0).Value = "NA"
        End Sub


        ' Properties
        Friend WithEvents BT_Clear As Button

        Friend WithEvents BT_Export As Button


        Friend WithEvents BT_OK As Button


        Friend WithEvents BT_PrintReport As Button


        Friend WithEvents DateTimePicker1 As DateTimePicker


        Friend WithEvents DateTimePicker2 As DateTimePicker


        Friend WithEvents DateTimePicker3 As DateTimePicker

        Friend WithEvents DGV_OR As DataGridView


        Friend WithEvents GroupBox1 As GroupBox


        Friend WithEvents GroupBox2 As GroupBox


        Friend WithEvents GroupBox3 As GroupBox

        Friend WithEvents GroupBox4 As GroupBox

        Friend WithEvents Label1 As Label

        Friend WithEvents Label10 As Label


        Friend WithEvents Label11 As Label


        Friend WithEvents Label12 As Label

        Friend WithEvents Label2 As Label


        Friend WithEvents Label3 As Label


        Friend WithEvents Label4 As Label


        Friend WithEvents Label5 As Label


        Friend WithEvents Label6 As Label


        Friend WithEvents Label7 As Label


        Friend WithEvents Label8 As Label


        Friend WithEvents Label9 As Label


        Friend WithEvents SaveFileDialog1 As SaveFileDialog

        Friend WithEvents TB_Actual_NA As TextBox


        Friend WithEvents TB_Actual_RN As TextBox


        Friend WithEvents TB_Class1 As TextBox


        Friend WithEvents TB_Class1W As TextBox


        Friend WithEvents TB_Class2 As TextBox


        Friend WithEvents TB_Class2W As TextBox


        Friend WithEvents TB_Class3 As TextBox

        Friend WithEvents TB_Class3W As TextBox


        Friend WithEvents TB_Class4 As TextBox

        Friend WithEvents TB_Class4W As TextBox


        Friend WithEvents TB_Class5 As TextBox


        Friend WithEvents TB_Class5W As TextBox

        Friend WithEvents TB_Hour As TextBox

        Friend WithEvents TB_Need_NA As TextBox

        Friend WithEvents TB_Need_RN As TextBox


        ' Fields
        'Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)

        Private components As IContainer
        Private hour1 As Double
        Private OCN1 As OdbcConnection
        Private SCN_SQL2 As SqlConnection
        Friend WithEvents TB_Class6 As System.Windows.Forms.TextBox
        Friend WithEvents TB_Class6W As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Private SCN_SQL3 As SqlConnection

        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            Dim SetStaff As SetActualStaff = New SetActualStaff
            SetStaff.ShowDialog()
        End Sub

        Private Sub LoadActualStff()
            Dim dt As DataTable = BindDataDT("Select * From ORStaff Where StaffDate = '" + Me.DateTimePicker1.Value.ToString("yyyyMMdd") + "' ")
            If (dt.Rows.Count > 0) Then
                TB_Actual_RN.Text = dt.Rows(0)("RN").ToString()
                TB_Actual_NA.Text = dt.Rows(0)("NA").ToString()
                TB_Hour.Text = dt.Rows(0)("Hour").ToString()

            End If

        End Sub
        Function BindDataDT(ByVal str As String) As DataTable
            Dim dt As DataTable = New DataTable
            Using con As New SqlConnection(Constants.SCN_SQL2)
                Using cmd As New SqlCommand(str, con)
                    con.Open()
                    dt.Load(cmd.ExecuteReader)
                    con.Close()
                End Using
            End Using
            Return dt
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Sub OR_View_Load1(sender As Object, e As System.EventArgs)

        End Sub

        Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
            Dim path As String = Directory.GetCurrentDirectory
            path = Replace(path, "bin\Debug", "") & "ExcelReader\bin\Debug\ExcelReader.exe"
            Process.Start(path)

        End Sub

        Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
            Dim report As New Report
            Module1.pReport = "Monthly"
            Module1.StaDate = Me.DateTimePicker2.Value.ToString("dd/MM/yyyy")
            Module1.EndDate = Me.DateTimePicker3.Value.ToString("dd/MM/yyyy")
            report.ShowDialog()
        End Sub

    End Class
End Namespace

