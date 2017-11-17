Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace OR_Productivity
    <DesignerGenerated> _
    Public Class OR_Input
        Inherits Form
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.OR_Input_Load)
            Dim list As List(Of WeakReference) = OR_Input.__ENCList
            SyncLock list
                OR_Input.__ENCList.Add(New WeakReference(Me))
            End SyncLock
            Me.InitializeComponent
        End Sub

        Private Sub BT_View_Click(ByVal sender As Object, ByVal e As EventArgs)
            'New OR_View().ShowDialog
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
            Me.Label1 = New Label
            Me.GroupBox1 = New GroupBox
            Me.TextBox5 = New TextBox
            Me.TextBox4 = New TextBox
            Me.TextBox3 = New TextBox
            Me.TextBox2 = New TextBox
            Me.TextBox1 = New TextBox
            Me.Label6 = New Label
            Me.Label5 = New Label
            Me.Label4 = New Label
            Me.Label3 = New Label
            Me.Label2 = New Label
            Me.GroupBox2 = New GroupBox
            Me.TextBox8 = New TextBox
            Me.TextBox7 = New TextBox
            Me.TextBox6 = New TextBox
            Me.Label9 = New Label
            Me.Label8 = New Label
            Me.Label7 = New Label
            Me.BT_View = New Button
            Me.GroupBox1.SuspendLayout
            Me.GroupBox2.SuspendLayout
            Me.SuspendLayout
            Me.Label1.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.Label1.AutoSize = True
            Dim point As New Point(&H309, &HC4)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            Dim size As New Size(&H6C, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Develop By Patiwat.s"
            Me.GroupBox1.Controls.Add(Me.TextBox5)
            Me.GroupBox1.Controls.Add(Me.TextBox4)
            Me.GroupBox1.Controls.Add(Me.TextBox3)
            Me.GroupBox1.Controls.Add(Me.TextBox2)
            Me.GroupBox1.Controls.Add(Me.TextBox1)
            Me.GroupBox1.Controls.Add(Me.Label6)
            Me.GroupBox1.Controls.Add(Me.Label5)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, &HDE)
            Me.GroupBox1.ForeColor = SystemColors.ControlText
            point = New Point(12, 10)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(&H219, &H97)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "จำนวนเจ้าหน้าที่ตาม Patient Classification"
            point = New Point(430, &H5C)
            Me.TextBox5.Location = point
            Me.TextBox5.Name = "TextBox5"
            size = New Size(100, &H16)
            Me.TextBox5.Size = size
            Me.TextBox5.TabIndex = 9
            Me.TextBox5.TextAlign = HorizontalAlignment.Center
            point = New Point(&H144, &H5C)
            Me.TextBox4.Location = point
            Me.TextBox4.Name = "TextBox4"
            size = New Size(100, &H16)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 8
            Me.TextBox4.TextAlign = HorizontalAlignment.Center
            point = New Point(&HDA, &H5C)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(100, &H16)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 7
            Me.TextBox3.TextAlign = HorizontalAlignment.Center
            point = New Point(&H70, &H5C)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(100, &H16)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 6
            Me.TextBox2.TextAlign = HorizontalAlignment.Center
            point = New Point(6, &H5C)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(100, &H16)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 5
            Me.TextBox1.TextAlign = HorizontalAlignment.Center
            Me.Label6.AutoSize = True
            point = New Point(&H1B9, &H21)
            Me.Label6.Location = point
            Me.Label6.Name = "Label6"
            size = New Size(&H4B, &H20)
            Me.Label6.Size = size
            Me.Label6.TabIndex = 4
            Me.Label6.Text = "5" & Chr(13) & ChrW(10) & "( 26.9 hr. )"
            Me.Label6.TextAlign = ContentAlignment.TopCenter
            Me.Label5.AutoSize = True
            point = New Point(&H151, &H21)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H4B, &H20)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "4" & ChrW(13) & ChrW(10) & "( 22.6 hr. )"
            Me.Label5.TextAlign = ContentAlignment.TopCenter
            Me.Label4.AutoSize = True
            point = New Point(&HE5, &H21)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H4B, &H20)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "3" & ChrW(13) & ChrW(10) & "( 16.3 hr. )"
            Me.Label4.TextAlign = ContentAlignment.TopCenter
            Me.Label3.AutoSize = True
            point = New Point(&H7B, &H21)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H4B, &H20)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "2" & ChrW(13) & ChrW(10) & "( 11.3 hr. )"
            Me.Label3.TextAlign = ContentAlignment.TopCenter
            Me.Label2.AutoSize = True
            point = New Point(&H15, &H21)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H43, &H20)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "1" & ChrW(13) & ChrW(10) & "( 8.0 hr. )"
            Me.Label2.TextAlign = ContentAlignment.TopCenter
            Me.GroupBox2.Controls.Add(Me.TextBox8)
            Me.GroupBox2.Controls.Add(Me.TextBox7)
            Me.GroupBox2.Controls.Add(Me.TextBox6)
            Me.GroupBox2.Controls.Add(Me.Label9)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, &HDE)
            point = New Point(&H22B, 12)
            Me.GroupBox2.Location = point
            Me.GroupBox2.Name = "GroupBox2"
            size = New Size(&H143, &H95)
            Me.GroupBox2.Size = size
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Staff Actual (Staff)"
            point = New Point(&HD7, 90)
            Me.TextBox8.Location = point
            Me.TextBox8.Name = "TextBox8"
            size = New Size(100, &H16)
            Me.TextBox8.Size = size
            Me.TextBox8.TabIndex = 12
            Me.TextBox8.TextAlign = HorizontalAlignment.Center
            point = New Point(&H70, 90)
            Me.TextBox7.Location = point
            Me.TextBox7.Name = "TextBox7"
            size = New Size(100, &H16)
            Me.TextBox7.Size = size
            Me.TextBox7.TabIndex = 11
            Me.TextBox7.TextAlign = HorizontalAlignment.Center
            point = New Point(6, 90)
            Me.TextBox6.Location = point
            Me.TextBox6.Name = "TextBox6"
            size = New Size(100, &H16)
            Me.TextBox6.Size = size
            Me.TextBox6.TabIndex = 10
            Me.TextBox6.TextAlign = HorizontalAlignment.Center
            Me.Label9.AutoSize = True
            point = New Point(&HED, &H2F)
            Me.Label9.Location = point
            Me.Label9.Name = "Label9"
            size = New Size(&H2C, &H10)
            Me.Label9.Size = size
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "Total"
            Me.Label8.AutoSize = True
            point = New Point(&H93, &H2F)
            Me.Label8.Location = point
            Me.Label8.Name = "Label8"
            size = New Size(&H1D, &H10)
            Me.Label8.Size = size
            Me.Label8.TabIndex = 1
            Me.Label8.Text = "NA"
            Me.Label7.AutoSize = True
            point = New Point(40, &H2F)
            Me.Label7.Location = point
            Me.Label7.Name = "Label7"
            size = New Size(30, &H10)
            Me.Label7.Size = size
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "RN"
            point = New Point(12, &HA7)
            Me.BT_View.Location = point
            Me.BT_View.Name = "BT_View"
            size = New Size(&H4B, &H27)
            Me.BT_View.Size = size
            Me.BT_View.TabIndex = 3
            Me.BT_View.Text = "ตกลง"
            Me.BT_View.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.LightSteelBlue
            size = New Size(&H379, &HD6)
            Me.ClientSize = size
            Me.Controls.Add(Me.BT_View)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Label1)
            Me.Name = "OR_Input"
            Me.Text = "Or_Productivity"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub OR_Input_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub


        ' Properties
        Friend Overridable Property BT_View As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._BT_View
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.BT_View_Click)
                If (Not Me._BT_View Is Nothing) Then
                    RemoveHandler Me._BT_View.Click, handler
                End If
                Me._BT_View = WithEventsValue
                If (Not Me._BT_View Is Nothing) Then
                    AddHandler Me._BT_View.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property GroupBox1 As GroupBox
            <DebuggerNonUserCode> _
            Get
                Return Me._GroupBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property GroupBox2 As GroupBox
            <DebuggerNonUserCode> _
            Get
                Return Me._GroupBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._GroupBox2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label1 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label3 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label4 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label5 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label6 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label7 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label8 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label8 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label9 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Label9 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox1 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox2 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox3 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox4 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox5 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox6 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox7 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TextBox8 As TextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._TextBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBox)
                Me._TextBox8 = WithEventsValue
            End Set
        End Property


        ' Fields
        'Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        <AccessedThroughProperty("BT_View")> _
        Private _BT_View As Button
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("GroupBox2")> _
        Private _GroupBox2 As GroupBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("Label8")> _
        Private _Label8 As Label
        <AccessedThroughProperty("Label9")> _
        Private _Label9 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        <AccessedThroughProperty("TextBox4")> _
        Private _TextBox4 As TextBox
        <AccessedThroughProperty("TextBox5")> _
        Private _TextBox5 As TextBox
        <AccessedThroughProperty("TextBox6")> _
        Private _TextBox6 As TextBox
        <AccessedThroughProperty("TextBox7")> _
        Private _TextBox7 As TextBox
        <AccessedThroughProperty("TextBox8")> _
        Private _TextBox8 As TextBox
        Private components As IContainer
    End Class
End Namespace

