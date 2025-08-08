Public Class frmPassengerFuture
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
    Private Sub frmPassengerFuture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader

            ' Get total miles flown for selected passenger's future flights
            cmdSelect = New OleDb.OleDbCommand("uspPassengerFlightMilesFuture", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.Add("@Passenger_id", OleDb.OleDbType.Integer).Value = cboPassenger.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                If IsDBNull(drSourceTable("TotalMilesFlown")) Then
                    lblTotal.Text = "0"
                Else
                    lblTotal.Text = drSourceTable("TotalMilesFlown").ToString()
                End If
            Else
                lblTotal.Text = "0"
            End If

            drSourceTable.Close()

            ' Get detailed future flight info for the passenger
            cmdSelect = New OleDb.OleDbCommand("uspPassengerFlightInfoFuture", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.Add("@Passenger_id", OleDb.OleDbType.Integer).Value = cboPassenger.SelectedValue

            drSourceTable = cmdSelect.ExecuteReader()

            lstInfo.Items.Clear()  ' Clear previous info before adding new

            While drSourceTable.Read()
                lstInfo.Items.Add("  ")
                lstInfo.Items.Add("Flight ID: " & drSourceTable("intFlightID").ToString())
                lstInfo.Items.Add("Flight Date: " & drSourceTable("dtmFlightDate").ToString())
                lstInfo.Items.Add("Flight Number: " & drSourceTable("strFlightNumber").ToString())
                lstInfo.Items.Add("Flight Time of Departure: " & drSourceTable("dtmTimeofDeparture").ToString())
                lstInfo.Items.Add("Flight Time of Landing: " & drSourceTable("dtmTimeOfLanding").ToString())
                lstInfo.Items.Add("Flight From Airport ID: " & drSourceTable("intFromAirportID").ToString())
                lstInfo.Items.Add("Flight To Airport ID: " & drSourceTable("intToAirportID").ToString())
                lstInfo.Items.Add("Flight Miles Flown: " & drSourceTable("intMilesFlown").ToString())
                lstInfo.Items.Add("Flight Plane Number: " & drSourceTable("strPlaneNumber").ToString())
                lstInfo.Items.Add("  ")
                lstInfo.Items.Add("=======================================")
            End While

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub


End Class