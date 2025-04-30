Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MemorySpotForm
    Inherits System.Windows.Forms.Form

    ' Dispose to clean up components
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

    ' Required by Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' Initialize Components
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemorySpotForm))
        Me.btnToggleSpots = New System.Windows.Forms.Button()
        Me.btnClearSpots = New System.Windows.Forms.Button()
        Me.btnSortXmlSpots = New System.Windows.Forms.Button()
        Me.colorPicker = New System.Windows.Forms.ComboBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIpAddress = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.lblConnectionStatus = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnToggleSpots
        '
        Me.btnToggleSpots.Location = New System.Drawing.Point(13, 13)
        Me.btnToggleSpots.Name = "btnToggleSpots"
        Me.btnToggleSpots.Size = New System.Drawing.Size(100, 30)
        Me.btnToggleSpots.TabIndex = 0
        Me.btnToggleSpots.Text = "Send Spots"
        Me.btnToggleSpots.UseVisualStyleBackColor = True
        '
        'btnClearSpots
        '
        Me.btnClearSpots.Location = New System.Drawing.Point(13, 57)
        Me.btnClearSpots.Name = "btnClearSpots"
        Me.btnClearSpots.Size = New System.Drawing.Size(100, 30)
        Me.btnClearSpots.TabIndex = 1
        Me.btnClearSpots.Text = "Clear Spots"
        Me.btnClearSpots.UseVisualStyleBackColor = True
        '
        'btnSortXmlSpots
        '
        Me.btnSortXmlSpots.Location = New System.Drawing.Point(12, 142)
        Me.btnSortXmlSpots.Name = "btnSortXmlSpots"
        Me.btnSortXmlSpots.Size = New System.Drawing.Size(100, 30)
        Me.btnSortXmlSpots.TabIndex = 2
        Me.btnSortXmlSpots.Text = "Sort XML"
        Me.btnSortXmlSpots.UseVisualStyleBackColor = True
        '
        'colorPicker
        '
        Me.colorPicker.FormattingEnabled = True
        Me.colorPicker.Items.AddRange(New Object() {"Red", "Green", "Blue", "Yellow", "Orange", "Cyan", "Magenta", "White", "Black"})
        Me.colorPicker.Location = New System.Drawing.Point(12, 102)
        Me.colorPicker.Name = "colorPicker"
        Me.colorPicker.Size = New System.Drawing.Size(121, 21)
        Me.colorPicker.TabIndex = 3
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblVersion.Location = New System.Drawing.Point(0, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(0, 15)
        Me.lblVersion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(191, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "TCI IP Address"
        '
        'txtIpAddress
        '
        Me.txtIpAddress.Location = New System.Drawing.Point(178, 23)
        Me.txtIpAddress.Name = "txtIpAddress"
        Me.txtIpAddress.Size = New System.Drawing.Size(100, 20)
        Me.txtIpAddress.TabIndex = 6
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(178, 83)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "TCI Port #"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(194, 129)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveSettings.TabIndex = 9
        Me.btnSaveSettings.Text = "Save TCI"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.AutoSize = True
        Me.lblConnectionStatus.ForeColor = System.Drawing.Color.Red
        Me.lblConnectionStatus.Location = New System.Drawing.Point(173, 168)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(115, 13)
        Me.lblConnectionStatus.TabIndex = 10
        Me.lblConnectionStatus.Text = "Status: Not Connected"
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtLog.Location = New System.Drawing.Point(0, 194)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(300, 48)
        Me.txtLog.TabIndex = 11
        '
        'MemorySpotForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 242)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.lblConnectionStatus)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtIpAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.colorPicker)
        Me.Controls.Add(Me.btnSortXmlSpots)
        Me.Controls.Add(Me.btnClearSpots)
        Me.Controls.Add(Me.btnToggleSpots)
        Me.Controls.Add(Me.lblVersion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MemorySpotForm"
        Me.Text = "Memory Spot Control"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnToggleSpots As Button
    Friend WithEvents btnClearSpots As Button
    Friend WithEvents btnSortXmlSpots As Button
    Friend WithEvents colorPicker As ComboBox

    Friend WithEvents lblVersion As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIpAddress As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents lblConnectionStatus As Label
    Friend WithEvents txtLog As TextBox
End Class
