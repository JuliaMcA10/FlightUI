<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassengerMain
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
        Me.btnFuture = New System.Windows.Forms.Button()
        Me.btnPast = New System.Windows.Forms.Button()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnNewPassenger = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(172, 207)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(79, 61)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnFuture
        '
        Me.btnFuture.Location = New System.Drawing.Point(256, 120)
        Me.btnFuture.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFuture.Name = "btnFuture"
        Me.btnFuture.Size = New System.Drawing.Size(79, 61)
        Me.btnFuture.TabIndex = 8
        Me.btnFuture.Text = "Show Future Flights"
        Me.btnFuture.UseVisualStyleBackColor = True
        '
        'btnPast
        '
        Me.btnPast.Location = New System.Drawing.Point(93, 120)
        Me.btnPast.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPast.Name = "btnPast"
        Me.btnPast.Size = New System.Drawing.Size(79, 61)
        Me.btnPast.TabIndex = 7
        Me.btnPast.Text = "Show Past Flights"
        Me.btnPast.UseVisualStyleBackColor = True
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Location = New System.Drawing.Point(303, 30)
        Me.btnBookFlight.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(79, 61)
        Me.btnBookFlight.TabIndex = 6
        Me.btnBookFlight.Text = "Book Flight"
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(47, 30)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(99, 61)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update Passenger Proflie"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnNewPassenger
        '
        Me.btnNewPassenger.Location = New System.Drawing.Point(173, 30)
        Me.btnNewPassenger.Name = "btnNewPassenger"
        Me.btnNewPassenger.Size = New System.Drawing.Size(93, 61)
        Me.btnNewPassenger.TabIndex = 10
        Me.btnNewPassenger.Text = "New Passenger"
        Me.btnNewPassenger.UseVisualStyleBackColor = True
        '
        'frmPassengerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 299)
        Me.Controls.Add(Me.btnNewPassenger)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnFuture)
        Me.Controls.Add(Me.btnPast)
        Me.Controls.Add(Me.btnBookFlight)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmPassengerMain"
        Me.Text = "Passenger Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnFuture As Button
    Friend WithEvents btnPast As Button
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnNewPassenger As Button
End Class
