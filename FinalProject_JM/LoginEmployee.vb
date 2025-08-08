Public Class frmLoginEmployee
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strUsername As String
        Dim strPassword As String

        Dim blnValidated As Boolean = True

        Get_Validated_Input(strUsername, strPassword, blnValidated)
        If blnValidated = True Then
            User_Login(strUsername, strPassword)
        End If
    End Sub

    Private Sub Get_Validated_Input(ByRef strUsername As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Get_Validate_Username(strUsername, blnValidated)
        If blnValidated = True Then
            Get_Validate_Password(strPassword, blnValidated)
        End If

    End Sub

    Private Sub Get_Validate_Username(ByRef strUsername As String, ByRef blnValidated As Boolean)
        If txtUsername.Text = "" Then
            MessageBox.Show("Username is required")
            blnValidated = False
            txtUsername.Focus()
        Else
            strUsername = txtUsername.Text
        End If

    End Sub

    Private Sub Get_Validate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Password is required")
            blnValidated = False
            txtPassword.Focus()
        Else
            strPassword = txtPassword.Text
        End If

    End Sub

    Private Sub User_Login(ByVal strUsername As String, ByVal strPassword As String)
        Try
            Dim cmdEmployeeLogin As New OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim objParam As OleDb.OleDbParameter

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdEmployeeLogin.CommandText = "uspEmployeeLogin"
            cmdEmployeeLogin.CommandType = CommandType.StoredProcedure
            cmdEmployeeLogin.Connection = m_conAdministrator

            cmdEmployeeLogin.Parameters.Add(New OleDb.OleDbParameter("@LoginID", OleDb.OleDbType.VarChar)).Value = strUsername
            cmdEmployeeLogin.Parameters.Add(New OleDb.OleDbParameter("@Password", OleDb.OleDbType.VarChar)).Value = strPassword

            drSourceTable = cmdEmployeeLogin.ExecuteReader()
            Using drSourceTable
                If drSourceTable.HasRows Then
                    MessageBox.Show("Login successful.")
                Else
                    MessageBox.Show("Invalid username or password")
                End If
            End Using

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        frmAdminMain.ShowDialog()

        Me.Hide()

    End Sub
End Class