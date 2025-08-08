Public Class frmPassengerUpdate
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmPassengerUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtStates As DataTable = New DataTable
        Dim dtPassengers As DataTable = New DataTable
        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT intStateID, strState FROM TStates"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtStates.Load(drSourceTable)


            cboState.ValueMember = "intStateID"
            cboState.DisplayMember = "strState"
            cboState.DataSource = dtStates


            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName As strFullName FROM TPassengers"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPassengers.Load(drSourceTable)


            cboPassenger.ValueMember = "intPassengerID"
            cboPassenger.DisplayMember = "strFullName"
            cboPassenger.DataSource = dtPassengers

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub
    Private Sub cboPassenger_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPassenger.SelectedIndexChanged
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPassengers As DataTable = New DataTable
        Dim objParam As OleDb.OleDbParameter

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdSelect = New OleDb.OleDbCommand("uspPassengerInfo", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@Passenger_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboPassenger.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtAddress.Text = drSourceTable("strAddress")
            txtCity.Text = drSourceTable("strCity")
            cboState.SelectedValue = drSourceTable("intStateID")
            txtZip.Text = drSourceTable("strZip")
            txtPhoneNumber.Text = drSourceTable("strPhoneNumber")
            txtEmail.Text = drSourceTable("strEmail")
            txtLoginID.Text = drSourceTable("strLoginID")
            txtPassword.Text = drSourceTable("strPassword")


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intStateID As Integer
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim strLogin As String
        Dim strPassword As String

        Dim blnValidated As Boolean = True

        Get_Validated_Input(strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLogin, strPassword, blnValidated)
        If blnValidated = True Then
            Update_Passenger(strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLogin, strPassword)
        End If

    End Sub

    Private Sub Get_Validated_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intStateID As Integer, ByRef strZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String, ByRef strLogin As String, ByRef strPassword As String, ByRef blnValidated As Boolean)

        Get_Validate_First_Name(strFirstName, blnValidated)
        If blnValidated Then
            Get_Validate_Last_Name(strLastName, blnValidated)
            If blnValidated Then
                Get_Validate_Address(strAddress, blnValidated)
                If blnValidated Then
                    Get_Validate_City(strCity, blnValidated)
                    If blnValidated Then
                        Get_Validate_State(intStateID, blnValidated)
                        If blnValidated Then
                            Get_Validate_Zip(strZip, blnValidated)
                            If blnValidated Then
                                Get_Validate_Phone_Number(strPhoneNumber, blnValidated)
                                If blnValidated Then
                                    Get_Validate_Email(strEmail, blnValidated)
                                    If blnValidated Then
                                        Get_Validate_Login(strLogin, blnValidated)
                                        If blnValidated Then
                                            Get_Validate_Password(strPassword, blnValidated)

                                        End If
                                    End If
                                End If
                            End If
                        End If
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

    Private Sub Get_Validate_Address(ByRef strAddress As String, ByRef blnValidated As Boolean)
        If txtAddress.Text = "" Then
            MessageBox.Show("Address is required")
            txtAddress.Focus()
        Else
            strAddress = txtAddress.Text
        End If
    End Sub

    Private Sub Get_Validate_City(ByRef strCity As String, ByRef blnValidated As Boolean)
        If txtCity.Text = "" Then
            MessageBox.Show("City is required")
            txtCity.Focus()
        Else
            strCity = txtCity.Text
        End If
    End Sub

    Private Sub Get_Validate_State(ByRef intStateID As Integer, ByRef blnValidated As Boolean)
        If cboState.SelectedIndex + 1 > 0 < 4 Then
            intStateID = cboState.SelectedIndex + 1
        Else
            MessageBox.Show("State is required")
            blnValidated = False
            cboState.Focus()
        End If

    End Sub

    Private Sub Get_Validate_Zip(ByRef strZip As String, ByRef blnValidated As Boolean)
        If txtZip.Text = "" Then
            MessageBox.Show("Zip code is required")
            txtZip.Focus()
        Else
            strZip = txtZip.Text
        End If
    End Sub

    Private Sub Get_Validate_Phone_Number(ByRef strPhoneNumber As String, ByRef blnValidated As Boolean)
        If txtPhoneNumber.Text = "" Then
            MessageBox.Show("Phone number is required")
            txtPhoneNumber.Focus()
        Else
            strPhoneNumber = txtPhoneNumber.Text
        End If
    End Sub

    Private Sub Get_Validate_Email(ByRef strEmail As String, ByRef blnValidated As Boolean)
        If txtEmail.Text = "" Then
            MessageBox.Show("Email is required")
            txtEmail.Focus()
            blnValidated = False
        Else
            If Not txtEmail.Text.IndexOf("@") > 0 Then
                MessageBox.Show("Email must have an @ symbol")
                txtEmail.Focus()
                blnValidated = False
            End If
            strEmail = txtEmail.Text
        End If

    End Sub

    Private Sub Get_Validate_Login(ByRef strLogin As String, ByRef blnValidated As Boolean)
        If txtLoginID.Text = "" Then
            MessageBox.Show("Login ID is required")
            txtLoginID.Focus()
        Else
            strLogin = txtLoginID.Text
        End If
    End Sub

    Private Sub Get_Validate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Password is required")
            txtPassword.Focus()
        Else
            strPassword = txtPassword.Text
        End If
    End Sub


    Private Sub Update_Passenger(ByVal strFirstName As String, ByVal strLastName As String, ByVal strAddress As String, ByVal strCity As String, ByVal intStateID As Integer, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String, ByVal strLogin As String, ByVal strPassword As String)

        Dim intPKID As Integer
        Dim intRowsAffected As Integer

        Dim cmdUpdatePassenger As New OleDb.OleDbCommand()

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            intPKID = cboPassenger.SelectedValue

            cmdUpdatePassenger.CommandText = "EXECUTE uspUpdatePassenger '" & intPKID & "','" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "','" & intStateID & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & strLogin & "','" & strPassword & "'"
            cmdUpdatePassenger.CommandType = CommandType.StoredProcedure

            cmdUpdatePassenger = New OleDb.OleDbCommand(cmdUpdatePassenger.CommandText, m_conAdministrator)

            intRowsAffected = cmdUpdatePassenger.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Update successful Passenger " & strLastName & " has been updated.")

            Else
                MessageBox.Show("Update failed")

            End If

            Close()
            frmPassengerMain.ShowDialog()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class