Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace OR_Productivity
    Public Class Report_OR
        Inherits ReportClass
        ' Methods
        Public Sub New()
            Dim list As List(Of WeakReference) = Report_OR.__ENCList
            SyncLock list
                Report_OR.__ENCList.Add(New WeakReference(Me))
            End SyncLock
        End Sub


        ' Properties
        Public Overrides Property FullResourceName As String
            Get
                Return "OR_Productivity.Report_OR.rpt"
            End Get
            Set(ByVal Value As String)
            End Set
        End Property

        Public Overrides Property NewGenerator As Boolean
            Get
                Return True
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
        Public ReadOnly Property Parameter_Date_from As IParameterField
            Get
                Return Me.DataDefinition.ParameterFields.Item(0)
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
        Public ReadOnly Property Parameter_Date_To As IParameterField
            Get
                Return Me.DataDefinition.ParameterFields.Item(1)
            End Get
        End Property

        Public Overrides Property ResourceName As String
            Get
                Return "Report_OR.rpt"
            End Get
            Set(ByVal Value As String)
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Section1 As Section
            Get
                Return Me.ReportDefinition.Sections.Item(0)
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Section2 As Section
            Get
                Return Me.ReportDefinition.Sections.Item(1)
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Section3 As Section
            Get
                Return Me.ReportDefinition.Sections.Item(2)
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Section4 As Section
            Get
                Return Me.ReportDefinition.Sections.Item(3)
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Section5 As Section
            Get
                Return Me.ReportDefinition.Sections.Item(4)
            End Get
        End Property


        ' Fields
        'Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
    End Class
End Namespace

