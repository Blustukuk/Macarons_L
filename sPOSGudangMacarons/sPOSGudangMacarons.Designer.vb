Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sPOSGudangMacarons
    Inherits System.ServiceProcess.ServiceBase

    'UserService overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <MTAThread()>
    <System.Diagnostics.DebuggerNonUserCode()>
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New sPOSGudangMacarons}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.taddPenerimaanTemp = New System.Timers.Timer()
        Me.bwaddPenerimaanTemp = New System.ComponentModel.BackgroundWorker()
        Me.tVoucher = New System.Timers.Timer()
        Me.bwVoucher = New System.ComponentModel.BackgroundWorker()
        Me.tBrand = New System.Timers.Timer()
        Me.bwBrand = New System.ComponentModel.BackgroundWorker()
        Me.tArtikel = New System.Timers.Timer()
        Me.bwArtikel = New System.ComponentModel.BackgroundWorker()
        Me.tSupplier = New System.Timers.Timer()
        Me.bwSupplier = New System.ComponentModel.BackgroundWorker()
        Me.tReturPengiriman = New System.Timers.Timer()
        Me.bwReturPengiriman = New System.ComponentModel.BackgroundWorker()
        Me.tPenjualan = New System.Timers.Timer()
        Me.bwPenjualan = New System.ComponentModel.BackgroundWorker()
        CType(Me.taddPenerimaanTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tArtikel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tReturPengiriman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPenjualan, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'taddPenerimaanTemp
        '
        Me.taddPenerimaanTemp.Enabled = True
        Me.taddPenerimaanTemp.Interval = 60000.0R
        '
        'bwaddPenerimaanTemp
        '
        Me.bwaddPenerimaanTemp.WorkerSupportsCancellation = True
        '
        'tVoucher
        '
        Me.tVoucher.Enabled = True
        Me.tVoucher.Interval = 100000.0R
        '
        'bwVoucher
        '
        Me.bwVoucher.WorkerSupportsCancellation = True
        '
        'tBrand
        '
        Me.tBrand.Enabled = True
        Me.tBrand.Interval = 7000000.0R
        '
        'bwBrand
        '
        Me.bwBrand.WorkerSupportsCancellation = True
        '
        'tArtikel
        '
        Me.tArtikel.Enabled = True
        Me.tArtikel.Interval = 6000000.0R
        '
        'bwArtikel
        '
        Me.bwArtikel.WorkerSupportsCancellation = True
        '
        'tSupplier
        '
        Me.tSupplier.Enabled = True
        Me.tSupplier.Interval = 9000000.0R
        '
        'bwSupplier
        '
        Me.bwSupplier.WorkerSupportsCancellation = True
        '
        'tReturPengiriman
        '
        Me.tReturPengiriman.Enabled = True
        Me.tReturPengiriman.Interval = 100000.0R
        '
        'bwReturPengiriman
        '
        Me.bwReturPengiriman.WorkerSupportsCancellation = True
        '
        'tPenjualan
        '
        Me.tPenjualan.Enabled = True
        Me.tPenjualan.Interval = 10000.0R
        '
        'bwPenjualan
        '
        Me.bwPenjualan.WorkerSupportsCancellation = True
        '
        'sPOSGudangMacarons
        '
        Me.ServiceName = "Service1"
        CType(Me.taddPenerimaanTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tBrand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tArtikel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tReturPengiriman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPenjualan, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents taddPenerimaanTemp As Timers.Timer
    Friend WithEvents bwaddPenerimaanTemp As ComponentModel.BackgroundWorker
    Friend WithEvents tVoucher As Timers.Timer
    Friend WithEvents bwVoucher As ComponentModel.BackgroundWorker
    Friend WithEvents tBrand As Timers.Timer
    Friend WithEvents bwBrand As ComponentModel.BackgroundWorker
    Friend WithEvents tArtikel As Timers.Timer
    Friend WithEvents bwArtikel As ComponentModel.BackgroundWorker
    Friend WithEvents tSupplier As Timers.Timer
    Friend WithEvents bwSupplier As ComponentModel.BackgroundWorker
    Friend WithEvents tReturPengiriman As Timers.Timer
    Friend WithEvents bwReturPengiriman As ComponentModel.BackgroundWorker
    Friend WithEvents tPenjualan As Timers.Timer
    Friend WithEvents bwPenjualan As ComponentModel.BackgroundWorker
End Class
