Public Class frmAttendantUpdate
    Private Sub frmUpdateAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtAttendants As DataTable = New DataTable

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName As strFullName FROM TAttendants"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtAttendants.Load(drSourceTable)


            cboAttendant.ValueMember = "intAttendantID"
            cboAttendant.DisplayMember = "strFullName"
            cboAttendant.DataSource = dtAttendants

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub cboAttendant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAttendant.SelectedIndexChanged
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtAttendants As DataTable = New DataTable
        Dim objParam As OleDb.OleDbParameter

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdSelect = New OleDb.OleDbCommand("uspAttendantInfo", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@Attendant_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboAttendant.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmHire.Value = drSourceTable("dtmDateofHire")
            dtmTermination.Value = drSourceTable("dtmDateofTermination")

            cmdSelect = New OleDb.OleDbCommand("uspEmployeeLoginIDnPasswordAttendant", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@employee_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboAttendant.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtUpdateLogin.Text = drSourceTable("strEmployeeLoginID")
            txtUpdatePassword.Text = drSourceTable("strEmployeePassword")

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim strLogin As String
        Dim strPassword As String
        Dim dteDateOfHire As Date
        Dim dteDateOfTermination As Date
        Dim blnValidated As Boolean = True

        dteDateOfHire = dtmHire.Value
        dteDateOfTermination = dtmTermination.Value


        Get_Validated_Input(strFirstName, strLastName, strEmployeeID, strLogin, strPassword, blnValidated)
        If blnValidated = True Then
            Update_Attendant(strFirstName, strLastName, strEmployeeID, strLogin, strPassword, dteDateOfHire, dteDateOfTermination)
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
                        Get_Validate_Passwrord(strPassword, blnValidated)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Get_Validate_First_Name(ByRef strFirstName As String, ByRef blnValidated As Boolean)

        If txtFirstName.Text = "" Then
            MessageBox.Show("First name is required")
            txtFirstName.Focus()
        Else
            strFirstName = txtFirstName.Text
        End If
    End Sub

    Private Sub Get_Validate_Last_Name(ByRef strLastName As String, ByRef blnValidated As Boolean)
        If txtLastName.Text = "" Then
            MessageBox.Show("Last name is required")
            txtLastName.Focus()
        Else
            strLastName = txtLastName.Text
        End If
    End Sub

    Private Sub Get_Validate_EmployeeID(ByRef strEmployeeID As String, ByRef blnValidated As Boolean)
        If txtEmployeeID.Text = "" Then
            MessageBox.Show("EmployeeID is required")
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

    Private Sub Get_Validate_Passwrord(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtUpdatePassword.Text = "" Then
            MessageBox.Show("Password is required")
            txtUpdatePassword.Focus()
        Else
            strPassword = txtUpdatePassword.Text
        End If
    End Sub

    Private Sub Update_Attendant(ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal strLogin As String, ByVal strPassword As String, ByVal dteDateOfHire As Date, dteDateOfTermination As Date)

        Dim intPKID As Integer
        Dim intRowsAffected As Integer
        Dim strSelect As String

        Dim cmdUpdateAttendant As New OleDb.OleDbCommand()
        Dim cmdSelect As New OleDb.OleDbCommand()
        Dim drSourceTable As OleDb.OleDbDataReader

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            intPKID = cboAttendant.SelectedIndex + 1

            cmdUpdateAttendant.CommandText = "EXECUTE uspUpdateAttendant '" & intPKID & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dteDateOfHire & "','" & dteDateOfTermination & "'"
            cmdUpdateAttendant.CommandType = CommandType.StoredProcedure

            cmdUpdateAttendant = New OleDb.OleDbCommand(cmdUpdateAttendant.CommandText, m_conAdministrator)

            strSelect = "Update TEmployees Set " &
                        "strEmployeeLoginID = '" & strLogin & "', " &
                        "strEmployeePassword = '" & strPassword & "'" &
                        "Where intFKEmployeeID = " & cboAttendant.SelectedValue

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            intRowsAffected = cmdUpdateAttendant.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Update successful Attendant " & strLastName & " has been updated.")

            Else
                MessageBox.Show("Update failed")

            End If

            Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
End Class