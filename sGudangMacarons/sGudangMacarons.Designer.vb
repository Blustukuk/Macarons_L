Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sGudangMacarons
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
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New sGudangMacarons}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bwPenjualanNESP = New System.ComponentModel.BackgroundWorker()
        Me.tPenjualanNESP = New System.Timers.Timer()
        Me.tPenjualanMacarons = New System.Timers.Timer()
        Me.bwPenjualanMacarons = New System.ComponentModel.BackgroundWorker()
        Me.tSupplier = New System.Timers.Timer()
        Me.bwSupplier = New System.ComponentModel.BackgroundWorker()
        Me.tBrand = New System.Timers.Timer()
        Me.bwBrand = New System.ComponentModel.BackgroundWorker()
        Me.tArtikel = New System.Timers.Timer()
        Me.bwArtikel = New System.ComponentModel.BackgroundWorker()
        Me.tVoucher = New System.Timers.Timer()
        Me.bwVoucher = New System.ComponentModel.BackgroundWorker()
        Me.bwItem = New System.ComponentModel.BackgroundWorker()
        Me.tItem = New System.Timers.Timer()
        Me.tReturPenjualan = New System.Timers.Timer()
        Me.bwReturPenjualan = New System.ComponentModel.BackgroundWorker()
        CType(Me.tPenjualanNESP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPenjualanMacarons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tReturPenjualan, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'bwPenjualanNESP
        '
        Me.bwPenjualanNESP.WorkerSupportsCancellation = True
        '
        'tPenjualanNESP
        '
        Me.tPenjualanNESP.Enabled = True
        Me.tPenjualanNESP.Interval = 5000.0R
        '
        'tPenjualanMacarons
        '
        Me.tPenjualanMacarons.Enabled = True
        Me.tPenjualanMacarons.Interval = 1000.0R
        '
        'bwPenjualanMacarons
        '
        Me.bwPenjualanMacarons.WorkerSupportsCancellation = True
        '
        'tSupplier
        '
        Me.tSupplier.Enabled = True
        Me.tSupplier.Interval = 6000000.0R
        '
        'bwSupplier
        '
        Me.bwSupplier.WorkerSupportsCancellation = True
        '
        'tBrand
        '
        Me.tBrand.Enabled = True
        Me.tBrand.Interval = 600000.0R
        '
        'bwBrand
        '
        Me.bwBrand.WorkerSupportsCancellation = True
        '
        'tArtikel
        '
        Me.tArtikel.Enabled = True
        Me.tArtikel.Interval = 100000.0R
        '
        'bwArtikel
        '
        Me.bwArtikel.WorkerSupportsCancellation = True
        '
        'tVoucher
        '
        Me.tVoucher.Enabled = True
        Me.tVoucher.Interval = 8000.0R
        '
        'bwVoucher
        '
        Me.bwVoucher.WorkerSupportsCancellation = True
        '
        'bwItem
        '
        Me.bwItem.WorkerSupportsCancellation = True
        '
        'tItem
        '
        Me.tItem.Enabled = True
        Me.tItem.Interval = 10000.0R
        '
        'tReturPenjualan
        '
        Me.tReturPenjualan.Enabled = True
        Me.tReturPenjualan.Interval = 10000.0R
        '
        'bwReturPenjualan
        '
        Me.bwReturPenjualan.WorkerSupportsCancellation = True
        '
        'sGudangMacarons
        '
        Me.ServiceName = "Service1"
        CType(Me.tPenjualanNESP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPenjualanMacarons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tBrand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tArtikel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tReturPenjualan, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents bwPenjualanNESP As ComponentModel.BackgroundWorker
    Friend WithEvents tPenjualanNESP As Timers.Timer
    Friend WithEvents tPenjualanMacarons As Timers.Timer
    Friend WithEvents bwPenjualanMacarons As ComponentModel.BackgroundWorker
    Friend WithEvents tSupplier As Timers.Timer
    Friend WithEvents bwSupplier As ComponentModel.BackgroundWorker
    Friend WithEvents tBrand As Timers.Timer
    Friend WithEvents bwBrand As ComponentModel.BackgroundWorker
    Friend WithEvents tArtikel As Timers.Timer
    Friend WithEvents bwArtikel As ComponentModel.BackgroundWorker
    Friend WithEvents tVoucher As Timers.Timer
    Friend WithEvents bwVoucher As ComponentModel.BackgroundWorker
    Friend WithEvents bwItem As ComponentModel.BackgroundWorker
    Friend WithEvents tItem As Timers.Timer
    Friend WithEvents tReturPenjualan As Timers.Timer
    Friend WithEvents bwReturPenjualan As ComponentModel.BackgroundWorker
End Class
