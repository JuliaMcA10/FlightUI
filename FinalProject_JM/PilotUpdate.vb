Public Class frmPilotUpdate
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmPilotUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable
        Dim dtPilotRoles As DataTable = New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName As strFullName FROM TPilots"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilots.Load(drSourceTable)


            cboPilot.ValueMember = "intPilotID"
            cboPilot.DisplayMember = "strFullName"
            cboPilot.DataSource = dtPilots


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"



            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilotRoles.Load(drSourceTable)


            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dtPilotRoles

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try

    End Sub
    Private Sub cboPilot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPilot.SelectedIndexChanged
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable
        Dim dtPilotRoles As DataTable = New DataTable
        Dim objParam As OleDb.OleDbParameter

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdSelect = New OleDb.OleDbCommand("uspPilotListbyIDRole", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@pilot_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboPilot.SelectedValue

            objParam = cmdSelect.Parameters.Add("@role_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = 1

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmHire.Value = drSourceTable("dtmDateofHire")
            dtmTermination.Value = drSourceTable("dtmDateofTermination")
            dtmLicense.Value = drSourceTable("dtmDateofLicense")
            cboPilotRole.SelectedValue = drSourceTable("strPilotRole")

            cmdSelect = New OleDb.OleDbCommand("uspEmployeeLoginIDnPassword", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@employee_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboPilot.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtUpdateLogin.Text = drSourceTable("strEmployeeLoginID")
            txtUpdatePassword.Text = drSourceTable("strEmployeePassword")





        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteDateOfHire As Date
        Dim dteDateOfTermination As Date
        Dim dteDateOfLicense As Date
        Dim strLogin As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True

        dteDateOfHire = dtmHire.Value
        dteDateOfTermination = dtmTermination.Value
        dteDateOfLicense = dtmLicense.Value

        Get_Validated_Input(strFirstName, strLastName, strEmployeeID, strLogin, strPassword, blnValidated)
        If blnValidated = True Then
            Update_Pilot(strFirstName, strLastName, strEmployeeID, dteDateOfHire, dteDateOfTermination, dteDateOfLicense, strLogin, strPassword)
        End If

    End Sub

    Private Sub Get_Validated_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef strLogin As String, ByRef strPassword As String, ByRef blnValidated As Boolean)

        Get_Validate_First_Name(strFirstName, blnValidated)
        If blnValidated Then
            Get_Validate_Last_Name(strLastName, blnValidated)
            If blnValidated Then
                Get_Validate_EmployeeID(strEmployeeID, blnValidated)
                If blnValidated Then
                    Get_Validate_Login(strLogin, blnValidated)
                    If blnValidated Then
                        Get_Validate_Password(strPassword, blnValidated)
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub Get_Validate_First_Name(ByRef strFirstName As String, ByRef blnValidated As Boolean)

        If txtFirstName.Text = "" Then
            MessageBox.Show("First name Is required")
            txtFirstName.Focus()
        Else
            strFirstName = txtFirstName.Text
        End If
    End Sub

    Private Sub Get_Validate_Last_Name(ByRef strLastName As String, ByRef blnValidated As Boolean)
        If txtLastName.Text = "" Then
            MessageBox.Show("Last name Is required")
            txtLastName.Focus()
        Else
            strLastName = txtLastName.Text
        End If
    End Sub

    Private Sub Get_Validate_EmployeeID(ByRef strEmployeeID As String, ByRef blnValidated As Boolean)
        If txtEmployeeID.Text = "" Then
            MessageBox.Show("EmployeeID Is required")
            txtEmployeeID.Focus()
        Else
            strEmployeeID = txtEmployeeID.Text
        End If
    End Sub

    Private Sub Get_Validate_Login(ByRef strLogin As String, ByRef blnValidated As Boolean)
        If txtUpdateLogin.Text = "" Then
            MessageBox.Show("Login ID is required")
            txtUpdateLogin.Focus()
        Else
            strLogin = txtUpdateLogin.Text
        End If
    End Sub

    Private Sub Get_Validate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtUpdatePassword.Text = "" Then
            MessageBox.Show("Password is required")
        Else
            strPassword = txtUpdatePassword.Text
        End If
    End Sub
    Private Sub Update_Pilot(ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal dteDateOfHire As Date, ByVal dteDateOfTermination As Date, ByVal dteDateOfLicense As Date, ByVal strLogin As String, ByVal strPassword As String)
        Dim intRowsAffected As Integer
        Dim strSelect As String
        Dim intPilotRoleID As Integer
        Dim strPilotRole As String

        Dim cmdUpdate As OleDb.OleDbCommand
        Dim cmdUpdateLogin As OleDb.OleDbCommand

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If



            strFirstName = txtFirstName.Text
            strLastName = txtLastName.Text
            strEmployeeID = txtEmployeeID.Text
            dteDateOfHire = dtmHire.Value
            dteDateOfTermination = dtmTermination.Value
            dteDateOfLicense = dtmLicense.Value
            strPilotRole = cboPilotRole.SelectedText
            strLogin = txtUpdateLogin.Text
            strPassword = txtUpdatePassword.Text

            If strPilotRole = "Co-Pilot" Then
                intPilotRoleID = 1
            Else
                intPilotRoleID = 2
            End If

            strSelect = "Update TPilots Set " &
                        "strFirstName = '" & strFirstName & "', " &
                        "strLastName = '" & strLastName & "', " &
                        "strEmployeeID = '" & strEmployeeID & "', " &
                        "dtmDateofHire = '" & dteDateOfHire & "', " &
                        "dtmDateofTermination = '" & dteDateOfTermination & "', " &
                        "dtmDateofLicense = '" & dteDateOfLicense & "', " &
                        "intPilotRoleID = " & intPilotRoleID &
                        " Where intPilotID = " & cboPilot.SelectedValue



            MessageBox.Show(strSelect)

            cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            intRowsAffected = cmdUpdate.ExecuteNonQuery()

            If intRowsAffected = 1 Then
                MessageBox.Show("Update successful")
            Else
                MessageBox.Show("Update failed")
            End If


            strPilotRole = cboPilot.Text

            strSelect = "Update TEmployees Set " &
                            "strEmployeeLoginID = '" & strLogin & "', " &
                            "strEmployeePassword = '" & strPassword & "', " &
                            "strEmployeeRole = '" & strPilotRole & "'" &
                            "Where intFKEmployeeID = " & cboPilot.SelectedValue

            MessageBox.Show(strSelect)


            cmdUpdateLogin = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            intRowsAffected = cmdUpdateLogin.ExecuteNonQuery()

            If intRowsAffected = 1 Then
                MessageBox.Show("Update successful")
            Else
                MessageBox.Show("Update failed")
            End If

            CloseDatabaseConnection()

            Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class