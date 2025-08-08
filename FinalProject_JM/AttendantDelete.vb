Public Class frmAttendantDelete
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmAttendantDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim intPKID As Integer
        Dim strDelete As String = ""
        Dim strDeleteLogin As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim dtAttendants As DataTable = New DataTable
        Dim result As DialogResult

        Dim cmdDeleteAttendant As New OleDb.OleDbCommand()

        Try

            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If


            result = MessageBox.Show("Are you sure you want to Delete Attendant: " & cboAttendant.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    intPKID = cboAttendant.SelectedIndex + 1

                    strDelete = "Delete FROM TAttendantFlights Where intAttendantID = " & cboAttendant.SelectedValue.ToString

                    cmdDeleteAttendant = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDeleteAttendant.ExecuteNonQuery()

                    strDeleteLogin = "Delete FROM TAttendantFlights Where intFKmployeeID = " & cboAttendant.SelectedValue.ToString

                    cmdDeleteAttendant = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDeleteAttendant.ExecuteNonQuery()


                    cmdDeleteAttendant.CommandText = "EXECUTE uspDeleteAttendant '" & intPKID & "'"
                    cmdDeleteAttendant.CommandType = CommandType.StoredProcedure

                    cmdDeleteAttendant = New OleDb.OleDbCommand(cmdDeleteAttendant.CommandText, m_conAdministrator)

                    intRowsAffected = cmdDeleteAttendant.ExecuteNonQuery()

                    CloseDatabaseConnection()

                    If intRowsAffected > 0 Then

                        MessageBox.Show("Delete successful")


                    End If

            End Select


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class