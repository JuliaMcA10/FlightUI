Public Class frmAttendantFuture
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmAttendantFuture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtFlights As DataTable = New DataTable
            Dim dtAttendants As DataTable = New DataTable
            Dim dtAttendantFlights As DataTable = New DataTable
            Dim dtPlanes As DataTable = New DataTable
            Dim objParam As OleDb.OleDbParameter

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdSelect = New OleDb.OleDbCommand("uspAttendantFlightMilesFuture", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@Attendant_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboAttendant.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            lblTotal.Text = CInt(drSourceTable("TotalMilesFlown"))

            strSelect = "SELECT TA.intAttendantID, TF.intFlightID, TF.dtmFlightDate, TF.strFlightNumber,  TF.dtmTimeofDeparture, TF.dtmTimeOfLanding, TF.intFromAirportID, TF.intToAirportID, intMilesFlown, TP.strPlaneNumber " &
                        "FROM TAttendants AS TA JOIN TAttendantFlights  AS  TAF " &
                        "ON TA.intAttendantID = TAF.intAttendantID " &
                        "JOIN TFlights As TF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "JOIN TPlanes AS TP " &
                        "ON TP.intPlaneID = TF.intPlaneID " &
                        "Where TA.intAttendantID = " & cboAttendant.SelectedValue &
                        " AND dtmFlightDate > GETDATE()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            While drSourceTable.Read()

                lstInfo.Items.Add("  ")

                lstInfo.Items.Add("Flight ID: " & vbTab & drSourceTable("intFlightID"))
                lstInfo.Items.Add("Flight Date: " & drSourceTable("dtmFlightDate"))
                lstInfo.Items.Add("Flight Number: " & drSourceTable("strFlightNumber"))
                lstInfo.Items.Add("Flight Time of Departure: " & drSourceTable("dtmTimeofDeparture"))
                lstInfo.Items.Add("Flight Time of Landing: " & drSourceTable("dtmTimeOfLanding"))
                lstInfo.Items.Add("Flight From Airport ID: " & drSourceTable("intFromAirportID"))
                lstInfo.Items.Add("Flight To Airport ID: " & drSourceTable("intToAirportID"))
                lstInfo.Items.Add("Flight Miles Flown: " & drSourceTable("intMilesFlown"))
                lstInfo.Items.Add("Flight Plane Number: " & drSourceTable("strPlaneNumber"))

                lstInfo.Items.Add("  ")
                lstInfo.Items.Add("=======================================")

            End While
            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class