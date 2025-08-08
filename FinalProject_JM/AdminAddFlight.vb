Public Class frmAdminAddFlight
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
    Private Sub frmAdminAddFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPlanes As New DataTable
        Dim dtAirportsFrom As New DataTable
        Dim dtAirportsTo As New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            ' Load planes
            strSelect = "SELECT intPlaneID, strPlaneNumber FROM TPlanes"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtPlanes.Load(drSourceTable)
            drSourceTable.Close()

            cboPlane.ValueMember = "intPlaneID"
            cboPlane.DisplayMember = "strPlaneNumber"
            cboPlane.DataSource = dtPlanes

            ' Load airports for From combo
            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtAirportsFrom.Load(drSourceTable)
            drSourceTable.Close()

            cboFrom.ValueMember = "intAirportID"
            cboFrom.DisplayMember = "strAirportCity"
            cboFrom.DataSource = dtAirportsFrom

            ' Load airports for To combo
            strSelect = "SELECT intAirportID, strAirportCity FROM TAirports"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtAirportsTo.Load(drSourceTable)
            drSourceTable.Close()

            cboTo.ValueMember = "intAirportID"
            cboTo.DisplayMember = "strAirportCity"
            cboTo.DataSource = dtAirportsTo

            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)
        End Try
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFlightNumber As String
        Dim strDeparture As String
        Dim strArrival As String
        Dim intMilesFlown As Integer
        Dim blnValidated As Boolean = True

        Get_Validate_Input(strFlightNumber, strDeparture, strArrival, intMilesFlown, blnValidated)
        If blnValidated Then
            Add_Flight(strFlightNumber, strDeparture, strArrival, intMilesFlown)
        End If
    End Sub

    Private Sub Get_Validate_Input(ByRef strFlightNumber As String, ByRef strDeparture As String, ByRef strArrival As String, ByRef intMilesFlown As Integer, ByRef blnValidated As Boolean)
        Get_Validate_Flight_Number(strFlightNumber, blnValidated)
        If blnValidated Then
            Get_Validate_Departure_Time(strDeparture, blnValidated)
            If blnValidated Then
                Get_Validate_Arrival_Time(strArrival, blnValidated)
                If blnValidated Then
                    Get_Validate_Miles(intMilesFlown, blnValidated)
                End If
            End If
        End If

    End Sub

    Private Sub Get_Validate_Flight_Number(ByRef strFlightNumber As String, ByRef blnValidated As Boolean)
        If txtFlightNumber.Text = "" Then
            MessageBox.Show("Flight number is required")
            txtFlightNumber.Focus()
        Else
            strFlightNumber = txtFlightNumber.Text

        End If

    End Sub

    Private Sub Get_Validate_Departure_Time(ByRef strDeparture As String, ByRef blnValidated As Boolean)
        If txtDepartureTime.Text = "" Then
            MessageBox.Show("Departure time is required")
            txtDepartureTime.Focus()
        Else
            strDeparture = txtDepartureTime.Text
        End If

    End Sub

    Private Sub Get_Validate_Arrival_Time(ByRef strArrival As String, ByRef blnValidated As Boolean)
        If txtDepartureTime.Text = "" Then
            MessageBox.Show("Arrival time is required")
            txtArrivalTime.Focus()
        Else
            strArrival = txtArrivalTime.Text
        End If
    End Sub

    Private Sub Get_Validate_Miles(ByRef intMilesFlown As Integer, ByRef blnValidated As Boolean)
        If Integer.TryParse(txtMilesFlown.Text, intMilesFlown) Then
            intMilesFlown = txtMilesFlown.Text
        Else
            MessageBox.Show("Flight miles is required and must be numeric")
        End If
    End Sub
    Private Sub Add_Flight(ByVal strFlightNumber As String, ByVal strDeparture As String, ByVal strArrival As String, ByVal intMilesFlown As Integer)
        Dim strSelect As String
        Dim strInsert As String
        Dim intFromAirportID As Integer
        Dim intToAirportID As Integer
        Dim intPlaneID As Integer
        Dim dtmFlightDate As Date
        Dim intNewFlightID As Integer

        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            strSelect = "SELECT MAX(intFlightID) + 1 AS intNextPrimaryKey " &
                                " FROM TFlights"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                intNextPrimaryKey = 1

            Else

                intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

            End If

            dtmFlightDate = dteFlightDate.Value
            intFromAirportID = cboFrom.SelectedValue
            intToAirportID = cboTo.SelectedValue
            intPlaneID = cboPlane.SelectedValue

            strInsert = "INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & dtmFlightDate & "','" & strFlightNumber & "','" & strDeparture & "','" & strArrival & "','" & intFromAirportID & "','" & intToAirportID & "'," & intMilesFlown & ", " & intPlaneID & ")"

            MessageBox.Show(strInsert)

            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Flight has been added")

            End If


            CloseDatabaseConnection()
            Close()

            intNewFlightID = intNextPrimaryKey

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class