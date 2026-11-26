Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Windows.Forms
Imports VisproPrakProjectAkhir.Modul

Namespace VisproPrakProjectAkhir.Forms.Umum

    ''' <summary>
    ''' Base form opsional dengan DoubleBuffered dan WS_EX_COMPOSITED (&amp;H2000000).
    ''' </summary>
    <DesignerCategory("Code")>
    Public Class BistroBaseForm
        Inherits Form

        Private Const WS_EX_COMPOSITED As Integer = &H2000000

        Public Shared Event DemoShortcutRequested(senderForm As Form)

        Protected Overridable ReadOnly Property UseComposited As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overridable ReadOnly Property AllowDemoShortcut As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub New()
            DoubleBuffered = True
            SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            ModTema.TerapkanForm(Me)
        End Sub

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If UseComposited AndAlso Not DesignMode Then
                    cp.ExStyle = cp.ExStyle Or WS_EX_COMPOSITED
                End If
                Return cp
            End Get
        End Property

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
            If AllowDemoShortcut AndAlso keyData = Keys.F9 Then
                RaiseEvent DemoShortcutRequested(Me)
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

    End Class
End Namespace

