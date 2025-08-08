<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassengerBookFlight
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
        Me.cboFlight = New System.Windows.Forms.ComboBox()
        Me.radReserved = New System.Windows.Forms.RadioButton()
        Me.radDesignated = New System.Windows.Forms.RadioButton()
        Me.lblReserveCost = New System.Windows.Forms.Label()
        Me.lblDesignatedCost = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPassenger = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select a Flight"
        '
        'cboFlight
        '
        Me.cboFlight.FormattingEnabled = True
        Me.cboFlight.Location = New System.Drawing.Point(129, 44)
        Me.cboFlight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboFlight.Name = "cboFlight"
        Me.cboFlight.Size = New System.Drawing.Size(121, 24)
        Me.cboFlight.TabIndex = 2
        '
        'radReserved
        '
        Me.radReserved.AutoSize = True
        Me.radReserved.Location = New System.Drawing.Point(15, 88)
        Me.radReserved.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.radReserved.Name = "radReserved"
        Me.radReserved.Size = New System.Drawing.Size(108, 19)
        Me.radReserved.TabIndex = 3
        Me.radReserved.TabStop = True
        Me.radReserved.Text = "Reserved Seat"
        Me.radReserved.UseVisualStyleBackColor = True
        '
        'radDesignated
        '
        Me.radDesignated.AutoSize = True
        Me.radDesignated.Location = New System.Drawing.Point(15, 115)
        Me.radDesignated.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.radDesignated.Name = "radDesignated"
        Me.radDesignated.Size = New System.Drawing.Size(182, 19)
        Me.radDesignated.TabIndex = 4
        Me.radDesignated.TabStop = True
        Me.radDesignated.Text = "Designated Seat at Check In"
        Me.radDesignated.UseVisualStyleBackColor = True
        '
        'lblReserveCost
        '
        Me.lblReserveCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReserveCost.Location = New System.Drawing.Point(164, 88)
        Me.lblReserveCost.Name = "lblReserveCost"
        Me.lblReserveCost.Size = New System.Drawing.Size(100, 23)
        Me.lblReserveCost.TabIndex = 7
        '
        'lblDesignatedCost
        '
        Me.lblDesignatedCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDesignatedCost.Location = New System.Drawing.Point(257, 115)
        Me.lblDesignatedCost.Name = "lblDesignatedCost"
        Me.lblDesignatedCost.Size = New System.Drawing.Size(100, 23)
        Me.lblDesignatedCost.TabIndex = 8
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(68, 166)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 32)
        Me.btnSubmit.TabIndex = 5
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(195, 166)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 32)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Passenger"
        '
        'cboPassenger
        '
        Me.cboPassenger.FormattingEnabled = True
        Me.cboPassenger.Location = New System.Drawing.Point(129, 2)
        Me.cboPassenger.Name = "cboPassenger"
        Me.cboPassenger.Size = New System.Drawing.Size(121, 24)
        Me.cboPassenger.TabIndex = 1
        '
        'frmPassengerBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 211)
        Me.Controls.Add(Me.cboPassenger)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblDesignatedCost)
        Me.Controls.Add(Me.lblReserveCost)
        Me.Controls.Add(Me.radDesignated)
        Me.Controls.Add(Me.radReserved)
        Me.Controls.Add(Me.cboFlight)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmPassengerBookFlight"
        Me.Text = "Book a Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboFlight As ComboBox
    Friend WithEvents radReserved As RadioButton
    Friend WithEvents radDesignated As RadioButton
    Friend WithEvents lblReserveCost As Label
    Friend WithEvents lblDesignatedCost As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPassenger As ComboBox
End Class
