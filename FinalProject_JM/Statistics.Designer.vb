<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstAttendants = New System.Windows.Forms.ListBox()
        Me.lstPilots = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAverage = New System.Windows.Forms.Label()
        Me.lblNumberofFlights = New System.Windows.Forms.Label()
        Me.lblNumberofPassengers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(260, 320)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(56, 24)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstAttendants
        '
        Me.lstAttendants.FormattingEnabled = True
        Me.lstAttendants.ItemHeight = 16
        Me.lstAttendants.Location = New System.Drawing.Point(317, 102)
        Me.lstAttendants.Margin = New System.Windows.Forms.Padding(2)
        Me.lstAttendants.Name = "lstAttendants"
        Me.lstAttendants.Size = New System.Drawing.Size(248, 196)
        Me.lstAttendants.TabIndex = 16
        '
        'lstPilots
        '
        Me.lstPilots.FormattingEnabled = True
        Me.lstPilots.ItemHeight = 16
        Me.lstPilots.Location = New System.Drawing.Point(11, 102)
        Me.lstPilots.Margin = New System.Windows.Forms.Padding(2)
        Me.lstPilots.Name = "lstPilots"
        Me.lstPilots.Size = New System.Drawing.Size(250, 196)
        Me.lstPilots.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(164, 71)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Average Miles Flown"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(164, 43)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Total Number of Flights"
        '
        'lblAverage
        '
        Me.lblAverage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverage.Location = New System.Drawing.Point(337, 71)
        Me.lblAverage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAverage.Name = "lblAverage"
        Me.lblAverage.Size = New System.Drawing.Size(75, 19)
        Me.lblAverage.TabIndex = 12
        '
        'lblNumberofFlights
        '
        Me.lblNumberofFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumberofFlights.Location = New System.Drawing.Point(337, 43)
        Me.lblNumberofFlights.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumberofFlights.Name = "lblNumberofFlights"
        Me.lblNumberofFlights.Size = New System.Drawing.Size(75, 19)
        Me.lblNumberofFlights.TabIndex = 11
        '
        'lblNumberofPassengers
        '
        Me.lblNumberofPassengers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumberofPassengers.Location = New System.Drawing.Point(336, 15)
        Me.lblNumberofPassengers.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumberofPassengers.Name = "lblNumberofPassengers"
        Me.lblNumberofPassengers.Size = New System.Drawing.Size(75, 19)
        Me.lblNumberofPassengers.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(164, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Total Number of Passengers"
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 358)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstAttendants)
        Me.Controls.Add(Me.lstPilots)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblAverage)
        Me.Controls.Add(Me.lblNumberofFlights)
        Me.Controls.Add(Me.lblNumberofPassengers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmStatistics"
        Me.Text = "Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lstAttendants As ListBox
    Friend WithEvents lstPilots As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblAverage As Label
    Friend WithEvents lblNumberofFlights As Label
    Friend WithEvents lblNumberofPassengers As Label
    Friend WithEvents Label1 As Label
End Class
