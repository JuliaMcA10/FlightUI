<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Choose
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
        Me.btnPassenger = New System.Windows.Forms.Button()
        Me.btnPilot = New System.Windows.Forms.Button()
        Me.btnAttendant = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPassenger
        '
        Me.btnPassenger.Location = New System.Drawing.Point(48, 36)
        Me.btnPassenger.Name = "btnPassenger"
        Me.btnPassenger.Size = New System.Drawing.Size(92, 23)
        Me.btnPassenger.TabIndex = 0
        Me.btnPassenger.Text = "Passengers"
        Me.btnPassenger.UseVisualStyleBackColor = True
        '
        'btnPilot
        '
        Me.btnPilot.Location = New System.Drawing.Point(211, 36)
        Me.btnPilot.Name = "btnPilot"
        Me.btnPilot.Size = New System.Drawing.Size(92, 23)
        Me.btnPilot.TabIndex = 1
        Me.btnPilot.Text = "Pilots"
        Me.btnPilot.UseVisualStyleBackColor = True
        '
        'btnAttendant
        '
        Me.btnAttendant.Location = New System.Drawing.Point(48, 142)
        Me.btnAttendant.Name = "btnAttendant"
        Me.btnAttendant.Size = New System.Drawing.Size(92, 23)
        Me.btnAttendant.TabIndex = 2
        Me.btnAttendant.Text = "Attendants"
        Me.btnAttendant.UseVisualStyleBackColor = True
        '
        'btnAdmin
        '
        Me.btnAdmin.Location = New System.Drawing.Point(211, 142)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(92, 23)
        Me.btnAdmin.TabIndex = 3
        Me.btnAdmin.Text = "Admin"
        Me.btnAdmin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(121, 244)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(92, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Choose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 303)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdmin)
        Me.Controls.Add(Me.btnAttendant)
        Me.Controls.Add(Me.btnPilot)
        Me.Controls.Add(Me.btnPassenger)
        Me.Name = "Choose"
        Me.Text = "Choose"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPassenger As Button
    Friend WithEvents btnPilot As Button
    Friend WithEvents btnAttendant As Button
    Friend WithEvents btnAdmin As Button
    Friend WithEvents btnExit As Button
End Class
