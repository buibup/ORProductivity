Imports InterSystems.Data.CacheClient
Imports System
Imports System.Configuration
Imports System.Data
Imports Microsoft.VisualBasic

Public Class CacheDb

    Dim strCon As String = ConfigurationManager.ConnectionStrings("CacheConnect").ToString()

    Public Function GetDTByQueryString(ByVal cmd As String) As DataTable
        Dim dt As DataTable = New DataTable

        Using con As New CacheConnection(strCon)
            con.Open()

            Using adp As New CacheDataAdapter(cmd, con)
                adp.Fill(dt)
            End Using

        End Using


        Return dt
    End Function

    Public Function GetDSByQueryString(ByVal cmd As String) As DataSet
        Dim ds As DataSet = New DataSet

        Using con As New CacheConnection(strCon)
            con.Open()

            Using adp As New CacheDataAdapter(cmd, con)
                adp.Fill(ds)
            End Using


        End Using

        Return ds
    End Function

End Class
