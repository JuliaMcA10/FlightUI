<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotUpdate
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
        Me.txtUpdateLogin = New System.Windows.Forms.TextBox()
        Me.txtUpdatePassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtmTermination = New System.Windows.Forms.DateTimePicker()
        Me.dtmHire = New System.Windows.Forms.DateTimePicker()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtmLicense = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboPilotRole = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPilot = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtUpdateLogin
        '
        Me.txtUpdateLogin.Location = New System.Drawing.Point(167, 96)
        Me.txtUpdateLogin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUpdateLogin.Name = "txtUpdateLogin"
        Me.txtUpdateLogin.Size = New System.Drawing.Size(100, 20)
        Me.txtUpdateLogin.TabIndex = 4
        '
        'txtUpdatePassword
        '
        Me.txtUpdatePassword.Location = New System.Drawing.Point(167, 122)
        Me.txtUpdatePassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUpdatePassword.Name = "txtUpdatePassword"
        Me.txtUpdatePassword.Size = New System.Drawing.Size(100, 20)
        Me.txtUpdatePassword.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 15)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Update Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 15)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Update Login ID"
        '
        'dtmTermination
        '
        Me.dtmTermination.Location = New System.Drawing.Point(167, 207)
        Me.dtmTermination.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtmTermination.Name = "dtmTermination"
        Me.dtmTermination.Size = New System.Drawing.Size(151, 20)
        Me.dtmTermination.TabIndex = 8
        '
        'dtmHire
        '
        Me.dtmHire.Location = New System.Drawing.Point(167, 181)
        Me.dtmHire.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtmHire.Name = "dtmHire"
        Me.dtmHire.Size = New System.Drawing.Size(151, 20)
        Me.dtmHire.TabIndex = 7
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(167, 149)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(76, 20)
        Me.txtEmployeeID.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Date of Hire"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Employee ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 15)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Date of Termination"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(188, 321)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 36)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(69, 321)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(72, 36)
        Me.btnSubmit.TabIndex = 11
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(167, 68)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(76, 20)
        Me.txtLastName.TabIndex = 3
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(167, 41)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(76, 20)
        Me.txtFirstName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Last Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "First Name"
        '
        'dtmLicense
        '
        Me.dtmLicense.Location = New System.Drawing.Point(167, 233)
        Me.dtmLicense.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtmLicense.Name = "dtmLicense"
        Me.dtmLicense.Size = New System.Drawing.Size(151, 20)
        Me.dtmLicense.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 266)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Pilot Role"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Date of License"
        '
        'cboPilotRole
        '
        Me.cboPilotRole.FormattingEnabled = True
        Me.cboPilotRole.Location = New System.Drawing.Point(167, 260)
        Me.cboPilotRole.Name = "cboPilotRole"
        Me.cboPilotRole.Size = New System.Drawing.Size(121, 24)
        Me.cboPilotRole.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Pilot"
        '
        'cboPilot
        '
        Me.cboPilot.FormattingEnabled = True
        Me.cboPilot.Location = New System.Drawing.Point(167, 12)
        Me.cboPilot.Name = "cboPilot"
        Me.cboPilot.Size = New System.Drawing.Size(121, 24)
        Me.cboPilot.TabIndex = 1
        '
        'frmPilotUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 361)
        Me.Controls.Add(Me.cboPilot)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboPilotRole)
        Me.Controls.Add(Me.dtmLicense)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtUpdateLogin)
        Me.Controls.Add(Me.txtUpdatePassword)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtmTermination)
        Me.Controls.Add(Me.dtmHire)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmPilotUpdate"
        Me.Text = "Update Pilot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUpdateLogin As TextBox
    Friend WithEvents txtUpdatePassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtmTermination As DateTimePicker
    Friend WithEvents dtmHire As DateTimePicker
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtmLicense As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cboPilotRole As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPilot As ComboBox
End Class
