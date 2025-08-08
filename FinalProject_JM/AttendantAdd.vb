Public Class frmAttendantAdd
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

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
            Add_Attendant(strFirstName, strLastName, strEmployeeID, strLogin, strPassword, dteDateOfHire, dteDateOfTermination)
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
        If txtLogin.Text = "" Then
            MessageBox.Show("Login ID is required")
            txtLogin.Focus()
        Else
            strLogin = txtLogin.Text
        End If
    End Sub

    Private Sub Get_Validate_Passwrord(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Password is required")
            txtPassword.Focus()
        Else
            strPassword = txtPassword.Text
        End If
    End Sub

    Private Sub Add_Attendant(ByVal strFirstName As String, ByVal strLastName As String, ByVal strEmployeeID As String, ByVal strLogin As String, ByVal strPassword As String, ByVal dteDateOfHire As Date, dteDateOfTermination As Date)
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        Dim cmdAddAttendant As New OleDb.OleDbCommand()
        Dim cmdAddAttendantLogin As New OleDb.OleDbCommand()


        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdAddAttendant.CommandText = "EXECUTE uspAddAttendant '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dteDateOfHire & "','" & dteDateOfTermination & "'"
            cmdAddAttendant.CommandType = CommandType.StoredProcedure


            intNewAttendantID = intNextPrimaryKey

            cmdAddAttendant = New OleDb.OleDbCommand(cmdAddAttendant.CommandText, m_conAdministrator)

            cmdAddAttendantLogin.CommandText = "EXECUTE uspAddAttendantLoginInfo '" & intNextPrimaryKey & "','" & strLogin & "','" & strPassword & "','" & "'Attendant'" & "','" & intNewAttendantID & "'"
            cmdAddAttendantLogin.CommandType = CommandType.StoredProcedure

            cmdAddAttendant = New OleDb.OleDbCommand(cmdAddAttendant.CommandText, m_conAdministrator)

            intRowsAffected = cmdAddAttendant.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Attendant " & strLastName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmployeeID.Clear()


    End Sub
End Class