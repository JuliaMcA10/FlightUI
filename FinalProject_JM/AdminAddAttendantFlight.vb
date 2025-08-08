Public Class frmAdminAddAttendantFlight
    Private Sub frmAdminAddAttendantFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtAttendants As DataTable = New DataTable
        Dim dtFlights As DataTable = New DataTable

        Try


            ' open the DB this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName As strFullName FROM TAttendants"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtAttendants.Load(drSourceTable)

            cboAttendant.ValueMember = "intAttendantID"
            cboAttendant.DisplayMember = "strFullName"
            cboAttendant.DataSource = dtAttendants

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
        Dim intAttendantID = cboAttendant.SelectedValue
        Dim intFlightID = cboFlight.SelectedValue

        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer
        Dim result As DialogResult

        Try

            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            result = MessageBox.Show("Are you sure you want to Add this Attendant: " & cboAttendant.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strSelect = "SELECT MAX(intAttendantFlightID) + 1 AS intNextPrimaryKey " &
                                " FROM TAttendantFlights"


                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then


                        intNextPrimaryKey = 1

                    Else


                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                    End If


                    strInsert = "INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID)" &
                            " VALUES (" & intNextPrimaryKey & "," & intAttendantID & "," & intFlightID & ")"

                    MessageBox.Show(strInsert)

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()


                    If intRowsAffected > 0 Then
                        MessageBox.Show("Attendant has been added")

                    End If


                    CloseDatabaseConnection()
                    Close()

            End Select



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class