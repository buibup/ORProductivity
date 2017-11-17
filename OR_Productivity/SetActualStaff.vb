Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System
Imports Microsoft.VisualBasic

Public Class SetActualStaff
    'Dim conStrSVHSQL2 As String = "Server=svh-sql2.samitivej.co.th;uid=sa;pwd=sa;database=Productivity"
    Dim conStrSVHSQL2 As String = ConfigurationManager.ConnectionStrings("SVH-SQL2").ToString
    Private Sub SetActualStaff_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub BindDataGridView()
        Dim dt As New DataTable()
        Using con As New SqlConnection(conStrSVHSQL2)
            'FORMAT(Now(),'YYYY-MM-DD') AS PerDate
            Using cmd As New SqlCommand("Select top 20 RowId, CONVERT(VARCHAR(11), StaffDate, 103) AS StaffDate, RN, NA, Hour From ORStaff order by RowId Desc", con)
                con.Open()
                dt.Load(cmd.ExecuteReader)
                con.Close()
            End Using
        End Using
        DataGridView1.DataSource = dt
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub btAdd_Click(sender As System.Object, e As System.EventArgs) Handles btAdd.Click
        'For Each row As DataGridViewRow In DataGridView1.Rows
        Dim Rn As Double = Double.Parse(TB_Actual_RN.Text)
        Dim Na As Double = Double.Parse(TB_Actual_NA.Text)
        Dim Hour As Double = Double.Parse(TB_Hour.Text)
        Dim dt As DataTable = BindDataDT("Select StaffDate From ORStaff Where StaffDate = '" + Me.DateTimePicker1.Value.ToString("yyyyMMdd") + "' ")
        If (dt.Rows.Count > 0) Then
            Using con As New SqlConnection(conStrSVHSQL2)
                Using cmd As New SqlCommand("sp_UpdateActualStaff", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@StaffDate", Me.DateTimePicker1.Value.ToString("yyyyMMdd"))
                    cmd.Parameters.AddWithValue("@RN", Rn)
                    cmd.Parameters.AddWithValue("@NA", Na)
                    cmd.Parameters.AddWithValue("@Hour", Hour)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            MessageBox.Show("Records Updated.")
        Else
            Using con As New SqlConnection(conStrSVHSQL2)
                Using cmd As New SqlCommand("INSERT INTO ORStaff VALUES(@StaffDate, @RN, @NA, @Hour)", con)
                    cmd.Parameters.AddWithValue("@StaffDate", Me.DateTimePicker1.Value.ToString("yyyyMMdd"))
                    cmd.Parameters.AddWithValue("@RN", Rn)
                    cmd.Parameters.AddWithValue("@NA", Na)
                    cmd.Parameters.AddWithValue("@Hour", Hour)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            MessageBox.Show("Records inserted.")
        End If
        
        'Next

    End Sub

    Private Sub btRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btRefresh.Click
        BindDataGridView()
    End Sub
    Function BindDataDT(ByVal str As String) As DataTable
        Dim dt As DataTable = New DataTable
        Using con As New SqlConnection(conStrSVHSQL2)
            Using cmd As New SqlCommand(str, con)
                con.Open()
                dt.Load(cmd.ExecuteReader)
                con.Close()
            End Using
        End Using
        Return dt
    End Function
    Private Sub btClose_Click(sender As System.Object, e As System.EventArgs) Handles btClose.Click
        Dim clsForm As SetActualStaff = New SetActualStaff
        Me.Close()
    End Sub
    Private Sub FindActualStaffByDateAdd(ByVal _date As String)
        Dim dt As New DataTable()
        Using con As New SqlConnection(conStrSVHSQL2)
            Using cmd As New SqlCommand("Select * From ORStaff Where StaffDate = '" + _date + "'", con)
                con.Open()
                dt.Load(cmd.ExecuteReader)
                con.Close()
            End Using
        End Using
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btSearch_Click(sender As System.Object, e As System.EventArgs) Handles btSearch.Click
        FindActualStaffByDateAdd(Me.DateTimePicker1.Value.ToString("yyyyMMdd"))
    End Sub
End Class