Public Class frmStatistics
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtPassengers As DataTable = New DataTable
            Dim dtFlightPassengers As DataTable = New DataTable
            Dim dtFlights As DataTable = New DataTable
            Dim dtPilots As DataTable = New DataTable
            Dim dtPilotFlights As DataTable = New DataTable
            Dim dtAttendants As DataTable = New DataTable
            Dim dtAttendantFlights As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT Count(*) as TotalPassengers " &
                        "FROM TFlightPassengers"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                lblNumberofPassengers.Text = 0

            Else

                lblNumberofPassengers.Text = CInt(drSourceTable("TotalPassengers"))

            End If

            strSelect = "SELECT Count(*) as TotalFlights " &
                           "FROM TFlights"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                lblNumberofFlights.Text = 0

            Else
                lblNumberofFlights.Text = CInt(drSourceTable("TotalFlights"))

            End If

            strSelect = "SELECT AVG(TF.intMilesFlown) As AverageMilesFlown " &
                        "From TFlights AS TF " &
                        "Where TF.dtmFlightDate > GETDATE()"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                lblAverage.Text = 0

            Else

                lblAverage.Text = CInt(drSourceTable("AverageMilesFlown"))

            End If

            strSelect = "SELECT SUM(TF.intMilesFlown) As TotalMilesFlown, TP.strFirstName, TP.strLastName " &
                        "FROM TPilots As TP LEFT JOIN TPilotFlights As TPF " &
                        "ON TP.intPilotID = TPF.intPilotID " &
                        "JOIN TFlights AS TF " &
                        "ON TF.intFlightID = TPF.intFlightID " &
                        "GROUP BY TP.strFirstName, TP.strLastName"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            lstPilots.Items.Add("Total Miles Per Pilot")
            lstPilots.Items.Add("  ")
            lstPilots.Items.Add("=======================================")

            While drSourceTable.Read()

                lstPilots.Items.Add("  ")

                lstPilots.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstPilots.Items.Add("Last Name: " & vbTab & drSourceTable("strLastName"))
                lstPilots.Items.Add("Has Flownn : " & vbTab & drSourceTable("TotalMilesFlown") & " Miles")


                lstPilots.Items.Add("  ")
                lstPilots.Items.Add("=======================================")

            End While

            strSelect = "SELECT SUM(TF.intMilesFlown) As TotalMilesFlown, TA.strFirstName, TA.strLastName " &
                        "FROM TAttendants As TA LEFT JOIN TAttendantFlights As TAF " &
                        "ON TA.intAttendantID = TAF.intAttendantID " &
                        "JOIN TFlights AS TF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "GROUP BY TA.strFirstName, TA.strLastName"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            lstAttendants.Items.Add("Total Miles Per Attendant")
            lstAttendants.Items.Add("  ")
            lstAttendants.Items.Add("=======================================")

            While drSourceTable.Read()

                lstAttendants.Items.Add("  ")

                lstAttendants.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstAttendants.Items.Add("Last Name: " & vbTab & drSourceTable("strLastName"))
                lstAttendants.Items.Add("Has Flownn : " & vbTab & drSourceTable("TotalMilesFlown") & " Miles")


                lstAttendants.Items.Add("  ")
                lstAttendants.Items.Add("=======================================")

            End While


            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try

    End Sub
End Class