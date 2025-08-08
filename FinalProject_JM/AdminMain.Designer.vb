<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMain
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
        Me.btnPilots = New System.Windows.Forms.Button()
        Me.btnAttendants = New System.Windows.Forms.Button()
        Me.btnFlight = New System.Windows.Forms.Button()
        Me.btnStatistics = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPilots
        '
        Me.btnPilots.Location = New System.Drawing.Point(58, 9)
        Me.btnPilots.Name = "btnPilots"
        Me.btnPilots.Size = New System.Drawing.Size(89, 51)
        Me.btnPilots.TabIndex = 0
        Me.btnPilots.Text = "Manage Pilots"
        Me.btnPilots.UseVisualStyleBackColor = True
        '
        'btnAttendants
        '
        Me.btnAttendants.Location = New System.Drawing.Point(153, 9)
        Me.btnAttendants.Name = "btnAttendants"
        Me.btnAttendants.Size = New System.Drawing.Size(89, 51)
        Me.btnAttendants.TabIndex = 1
        Me.btnAttendants.Text = "Manage Attendants"
        Me.btnAttendants.UseVisualStyleBackColor = True
        '
        'btnFlight
        '
        Me.btnFlight.Location = New System.Drawing.Point(58, 85)
        Me.btnFlight.Name = "btnFlight"
        Me.btnFlight.Size = New System.Drawing.Size(89, 51)
        Me.btnFlight.TabIndex = 2
        Me.btnFlight.Text = "Add A Flight"
        Me.btnFlight.UseVisualStyleBackColor = True
        '
        'btnStatistics
        '
        Me.btnStatistics.Location = New System.Drawing.Point(153, 85)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(89, 51)
        Me.btnStatistics.TabIndex = 3
        Me.btnStatistics.Text = "View Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(114, 159)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(89, 51)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAdminMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 218)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnStatistics)
        Me.Controls.Add(Me.btnFlight)
        Me.Controls.Add(Me.btnAttendants)
        Me.Controls.Add(Me.btnPilots)
        Me.Name = "frmAdminMain"
        Me.Text = "Admin Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPilots As Button
    Friend WithEvents btnAttendants As Button
    Friend WithEvents btnFlight As Button
    Friend WithEvents btnStatistics As Button
    Friend WithEvents btnExit As Button
End Class
