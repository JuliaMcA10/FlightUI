<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantMain
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
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(136, 104)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(81, 71)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnFuture
        '
        Me.btnFuture.Location = New System.Drawing.Point(220, 11)
        Me.btnFuture.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFuture.Name = "btnFuture"
        Me.btnFuture.Size = New System.Drawing.Size(81, 71)
        Me.btnFuture.TabIndex = 16
        Me.btnFuture.Text = "Show Future Flights"
        Me.btnFuture.UseVisualStyleBackColor = True
        '
        'btnPast
        '
        Me.btnPast.Location = New System.Drawing.Point(136, 11)
        Me.btnPast.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPast.Name = "btnPast"
        Me.btnPast.Size = New System.Drawing.Size(81, 71)
        Me.btnPast.TabIndex = 15
        Me.btnPast.Text = "Show Past Flights"
        Me.btnPast.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(53, 11)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 71)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.Text = "Update Attendant Proflie"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmAttendantMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 213)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnFuture)
        Me.Controls.Add(Me.btnPast)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmAttendantMain"
        Me.Text = "Attendant Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnFuture As Button
    Friend WithEvents btnPast As Button
    Friend WithEvents btnUpdate As Button
End Class
