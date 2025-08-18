Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sGudangMacaronsLeo
    Inherits System.ServiceProcess.ServiceBase

    'UserService overrides dispose to clean up the component list.
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

    ' The main entry point for the process
    <MTAThread()> _
    <System.Diagnostics.DebuggerNonUserCode()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New sGudangMacaronsLeo}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tItem = New System.Timers.Timer()
        Me.bwItem = New System.ComponentModel.BackgroundWorker()
        Me.tPenjualanNESP = New System.Timers.Timer()
        Me.bwPenjualanNESP = New System.ComponentModel.BackgroundWorker()
        CType(Me.tItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPenjualanNESP, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'tItem
        '
        Me.tItem.Enabled = True
        Me.tItem.Interval = 10000.0R
        '
        'bwItem
        '
        Me.bwItem.WorkerSupportsCancellation = True
        '
        'tPenjualanNESP
        '
        Me.tPenjualanNESP.Enabled = True
        Me.tPenjualanNESP.Interval = 5000.0R
        '
        'bwPenjualanNESP
        '
        Me.bwPenjualanNESP.WorkerSupportsCancellation = True
        '
        'sGudangMacaronsLeo
        '
        Me.ServiceName = "Service1"
        CType(Me.tItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPenjualanNESP, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents tItem As Timers.Timer
    Friend WithEvents bwItem As ComponentModel.BackgroundWorker
    Friend WithEvents tPenjualanNESP As Timers.Timer
    Friend WithEvents bwPenjualanNESP As ComponentModel.BackgroundWorker
End Class
