<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddFlight
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.dteFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDepartureTime = New System.Windows.Forms.TextBox()
        Me.txtArrivalTime = New System.Windows.Forms.TextBox()
        Me.txtMilesFlown = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboPlane = New System.Windows.Forms.ComboBox()
        Me.cboTo = New System.Windows.Forms.ComboBox()
        Me.cboFrom = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Flight Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Flight Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time of Departure"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Time of Landing"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "From Airport"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "To Airport"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Total Miles"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Plane Number"
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(147, 4)
        Me.txtFlightNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightNumber.TabIndex = 1
        '
        'dteFlightDate
        '
        Me.dteFlightDate.Location = New System.Drawing.Point(147, 32)
        Me.dteFlightDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dteFlightDate.Name = "dteFlightDate"
        Me.dteFlightDate.Size = New System.Drawing.Size(200, 20)
        Me.dteFlightDate.TabIndex = 2
        '
        'txtDepartureTime
        '
        Me.txtDepartureTime.Location = New System.Drawing.Point(147, 64)
        Me.txtDepartureTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDepartureTime.Name = "txtDepartureTime"
        Me.txtDepartureTime.Size = New System.Drawing.Size(100, 20)
        Me.txtDepartureTime.TabIndex = 3
        '
        'txtArrivalTime
        '
        Me.txtArrivalTime.Location = New System.Drawing.Point(147, 94)
        Me.txtArrivalTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtArrivalTime.Name = "txtArrivalTime"
        Me.txtArrivalTime.Size = New System.Drawing.Size(100, 20)
        Me.txtArrivalTime.TabIndex = 4
        '
        'txtMilesFlown
        '
        Me.txtMilesFlown.Location = New System.Drawing.Point(147, 185)
        Me.txtMilesFlown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMilesFlown.Name = "txtMilesFlown"
        Me.txtMilesFlown.Size = New System.Drawing.Size(100, 20)
        Me.txtMilesFlown.TabIndex = 7
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(77, 272)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 9
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(216, 272)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboPlane
        '
        Me.cboPlane.FormattingEnabled = True
        Me.cboPlane.Location = New System.Drawing.Point(147, 219)
        Me.cboPlane.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPlane.Name = "cboPlane"
        Me.cboPlane.Size = New System.Drawing.Size(160, 24)
        Me.cboPlane.TabIndex = 8
        '
        'cboTo
        '
        Me.cboTo.FormattingEnabled = True
        Me.cboTo.Location = New System.Drawing.Point(147, 152)
        Me.cboTo.Name = "cboTo"
        Me.cboTo.Size = New System.Drawing.Size(121, 24)
        Me.cboTo.TabIndex = 6
        '
        'cboFrom
        '
        Me.cboFrom.FormattingEnabled = True
        Me.cboFrom.Location = New System.Drawing.Point(147, 122)
        Me.cboFrom.Name = "cboFrom"
        Me.cboFrom.Size = New System.Drawing.Size(121, 24)
        Me.cboFrom.TabIndex = 5
        '
        'frmAdminAddFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 308)
        Me.Controls.Add(Me.cboFrom)
        Me.Controls.Add(Me.cboTo)
        Me.Controls.Add(Me.cboPlane)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtMilesFlown)
        Me.Controls.Add(Me.txtArrivalTime)
        Me.Controls.Add(Me.txtDepartureTime)
        Me.Controls.Add(Me.dteFlightDate)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmAdminAddFlight"
        Me.Text = "Add A Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents dteFlightDate As DateTimePicker
    Friend WithEvents txtDepartureTime As TextBox
    Friend WithEvents txtArrivalTime As TextBox
    Friend WithEvents txtMilesFlown As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cboPlane As ComboBox
    Friend WithEvents cboTo As ComboBox
    Friend WithEvents cboFrom As ComboBox
End Class
