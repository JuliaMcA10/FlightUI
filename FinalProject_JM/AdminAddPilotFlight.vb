Public Class frmAdminAddPilotFlight
    Private Sub frmAdminAddPilotFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable
        Dim dtFlights As DataTable = New DataTable

        Try


            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName AS strFullName FROM TPilots"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilots.Load(drSourceTable)

            cboPilot.ValueMember = "intPilotID"
            cboPilot.DisplayMember = "strFullName"
            cboPilot.DataSource = dtPilots

            strSelect = "SELECT intFlightID, strFlightNumber From TFlights Where TFlights.dtmFlightDate > GETDATE()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtFlights.Load(drSourceTable)

            cboFlight.ValueMember = "intFlightID"
            cboFlight.DisplayMember = "strFlightNumber"
            cboFlight.DataSource = dtFlights


            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim intPilotID = cboPilot.SelectedValue
        Dim intFlightID = cboFlight.SelectedValue

        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer
        Dim result As DialogResult

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            result = MessageBox.Show("Are you sure you want to Add this Pilot: " & cboPilot.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strSelect = "SELECT MAX(intPilotFlightID) + 1 AS intNextPrimaryKey " &
                                " FROM TPilotFlights"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then

                        intNextPrimaryKey = 1

                    Else

                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                    End If

                    strInsert = "INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID)" &
                            " VALUES (" & intNextPrimaryKey & "," & intPilotID & "," & intFlightID & ")"

                    MessageBox.Show(strInsert)

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Pilot has been added")

                    End If


                    CloseDatabaseConnection()
                    Close()

            End Select



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class