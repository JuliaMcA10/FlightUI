Public Class frmPilotDelete
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
    Private Sub frmPilotDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable

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

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
        Dim dtPilots As DataTable = New DataTable
        Dim result As DialogResult

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            result = MessageBox.Show("Are you sure you want to Delete Pilot: " & cboPilot.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)


            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes



                    strDelete = "Delete FROM TPilotFlights Where intPilotID = " & cboPilot.SelectedValue.ToString

                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


                    strDelete = "Delete FROM TPilots Where intPilotID = " & cboPilot.SelectedValue.ToString


                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()



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