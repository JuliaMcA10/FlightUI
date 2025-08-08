Public Class frmPassengerPast
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
    Private Sub frmPassengerPast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPassengers As DataTable = New DataTable
        Try


            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

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
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtFlights As DataTable = New DataTable
            Dim dtPassengers As DataTable = New DataTable
            Dim dtFlightPassengers As DataTable = New DataTable
            Dim dtPlanes As DataTable = New DataTable
            Dim objParam As OleDb.OleDbParameter

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            cmdSelect = New OleDb.OleDbCommand("uspPassengerFlightMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@Passenger_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboPassenger.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            lblTotal.Text = CInt(drSourceTable("TotalMilesFlown"))



            cmdSelect = New OleDb.OleDbCommand("uspPassengerFlightInfo", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@Passenger_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = cboPassenger.SelectedValue

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

            MessageBox.Show(ex.ToString)

        End Try
    End Sub


End Class