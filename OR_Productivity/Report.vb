Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.IO

Namespace OR_Productivity
    <DesignerGenerated> _
    Public Class Report
        Inherits Form
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Report_Load)
            Dim list As List(Of WeakReference) = Report.__ENCList
            SyncLock list
                Report.__ENCList.Add(New WeakReference(Me))
            End SyncLock
            Me.InitializeComponent
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try 
                If (disposing AndAlso (Not Me.components Is Nothing)) Then
                    Me.components.Dispose
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.CrystalReportViewer1 = New CrystalReportViewer
            Me.SuspendLayout
            Me.CrystalReportViewer1.ActiveViewIndex = -1
            Me.CrystalReportViewer1.BorderStyle = BorderStyle.FixedSingle
            Me.CrystalReportViewer1.DisplayGroupTree = False
            Me.CrystalReportViewer1.Dock = DockStyle.Fill
            Dim point As New Point(0, 0)
            Me.CrystalReportViewer1.Location = point
            Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
            Me.CrystalReportViewer1.SelectionFormula = ""
            Dim size As New Size(&H324, &H20D)
            Me.CrystalReportViewer1.Size = size
            Me.CrystalReportViewer1.TabIndex = 0
            Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H324, &H20D)
            Me.ClientSize = size
            Me.Controls.Add(Me.CrystalReportViewer1)
            Me.Name = "Report"
            Me.Text = "Report"
            Me.ResumeLayout(False)
        End Sub

        Private Sub Report_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim document As New ReportDocument
            Dim path As String = Directory.GetCurrentDirectory()
            'Module1.strReportName = "C:\VBnet\Samit\OR_Productivity\bin\Debug\Report\Report_OR.rpt"

            If Module1.pReport = "Monthly" Then
                Module1.strReportName = path & "\Report\Report_OR_Monthly.rpt"
                document.Load(Module1.strReportName)
                document.SetDatabaseLogon("sa", "sa", "svh-sql2", "Productivity")
                Me.CrystalReportViewer1.ReportSource = document
                Me.CrystalReportViewer1.ReportSource = document
                document.SetParameterValue("Date_From", Module1.StaDate)
                document.SetParameterValue("Date_To", Module1.EndDate)
            ElseIf Module1.pReport = "Daily" Then
                Module1.strReportName = path & "\Report\Report_OR.rpt"
                document.Load(Module1.strReportName)
                document.SetDatabaseLogon("sa", "sa", "svh-sql2", "Productivity")
                Me.CrystalReportViewer1.ReportSource = document
                Me.CrystalReportViewer1.ReportSource = document
                document.SetParameterValue("Date_From", Module1.StaDate)
                document.SetParameterValue("Date_To", Module1.EndDate)
            ElseIf Module1.pReport = "Detail" Then
                Module1.strReportName = path & "\Report\DataDetail.rpt"
                document.Load(Module1.strReportName)
                document.SetDatabaseLogon("sa", "sa", "svh-sql2.samitivej.co.th", "Productivity")
                Me.CrystalReportViewer1.ReportSource = document
                Me.CrystalReportViewer1.ReportSource = document
                document.SetParameterValue("Date_From", Module1.StaDate)
                document.SetParameterValue("Date_To", Module1.EndDate)
            End If

            'document.Load(Module1.strReportName)
            'document.SetDatabaseLogon("sa", "sa", "svh-sql2", "Productivity")
            'Me.CrystalReportViewer1.ReportSource = document
            'Me.CrystalReportViewer1.ReportSource = document
            'document.SetParameterValue("Date_From", Module1.StaDate)
            'document.SetParameterValue("Date_To", Module1.EndDate)
        End Sub


        ' Properties
        Friend Overridable Property CrystalReportViewer1 As CrystalReportViewer
            <DebuggerNonUserCode> _
            Get
                Return Me._CrystalReportViewer1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As CrystalReportViewer)
                Me._CrystalReportViewer1 = WithEventsValue
            End Set
        End Property


        ' Fields
        'Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        <AccessedThroughProperty("CrystalReportViewer1")> _
        Private _CrystalReportViewer1 As CrystalReportViewer
        Private components As IContainer
    End Class
End Namespace

