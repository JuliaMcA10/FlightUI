Public Class frmPilotAdd
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmPilotAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilotRoles As DataTable = New DataTable

        Try


            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If


            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilotRoles.Load(drSourceTable)


            cboRoles.ValueMember = "intPilotRoleID"
            cboRoles.DisplayMember = "strPilotRole"
            cboRoles.DataSource = dtPilotRoles


            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

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
            Add_Pilot(strFirstName, strLastName, strEmployeeID, dteDateOfHire, dteDateOfTermination, dteDateOfLicense, strLogin, strPassword)
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
        If txtLogin.Text = "" Then
            MessageBox.Show("Login ID is required")
            txtLogin.Focus()
        Else
            strLogin = txtLogin.Text
        End If
    End Sub

    Private Sub Get_Validate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Password is required")
        Else
            strPassword = txtPassword.Text
        End If
    End Sub
    Private Sub Add_Pilot(ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal dteDateOfHire As Date, ByVal dteDateOfTermination As Date, ByVal dteDateOfLicense As Date, ByVal strLogin As String, ByVal strPassword As String)
        Dim strSelect As String
        Dim strInsert As String
        Dim intPilotRoleID As Integer

        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey " &
                                " FROM TPilots"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                intNextPrimaryKey = 1

            Else

                intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

            End If

            intPilotRoleID = cboRoles.SelectedValue
            strInsert = "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dteDateOfHire & "','" & dteDateOfTermination & "','" & dteDateOfLicense & "'," & intPilotRoleID & ")"

            MessageBox.Show(strInsert)

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Pilot has been added")

            End If


            CloseDatabaseConnection()
            Close()

            intNewPilotID = intNextPrimaryKey

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class