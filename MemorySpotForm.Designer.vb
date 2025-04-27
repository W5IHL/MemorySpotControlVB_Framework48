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
        Me.btnToggleSpots = New System.Windows.Forms.Button()
        Me.btnClearSpots = New System.Windows.Forms.Button()
        Me.btnSortXmlSpots = New System.Windows.Forms.Button()
        Me.colorPicker = New System.Windows.Forms.ComboBox()
        Me.lblVersion = New System.Windows.Forms.Label()
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
        'MemorySpotForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 200)
        Me.Controls.Add(Me.colorPicker)
        Me.Controls.Add(Me.btnSortXmlSpots)
        Me.Controls.Add(Me.btnClearSpots)
        Me.Controls.Add(Me.btnToggleSpots)
        Me.Controls.Add(Me.lblVersion)
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


End Class
