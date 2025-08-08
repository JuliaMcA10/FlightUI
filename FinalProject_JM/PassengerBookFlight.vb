Public Class frmPassengerBookFlight
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
    Private Sub frmPassengerBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtFlights As New DataTable
        Dim dtPassengers As New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            strSelect = "SELECT intFlightID, strFlightNumber " &
                    "FROM TFlights " &
                    "WHERE TFlights.dtmFlightDate > GETDATE()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtFlights.Load(drSourceTable)
            drSourceTable.Close()

            cboFlight.ValueMember = "intFlightID"
            cboFlight.DisplayMember = "strFlightNumber"
            cboFlight.DataSource = dtFlights

            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName AS strFullName FROM TPassengers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dtPassengers.Load(drSourceTable)
            drSourceTable.Close()

            cboPassenger.ValueMember = "intPassengerID"
            cboPassenger.DisplayMember = "strFullName"
            cboPassenger.DataSource = dtPassengers

            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)
        End Try
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim intFlightID = cboFlight.SelectedValue
        Dim intTotalMilesFlown As Integer
        Dim intTotalPassengers As Integer
        Dim strPlaneType As String
        Dim strAirportCode As String
        Dim intTotalFlights As Integer
        Dim intAge As Integer
        Dim intDesignatedCost As Integer
        Dim intReservedCost As Integer
        Dim intPassengerID As Integer
        Dim intCost As Integer

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

            strSelect = "SELECT SUM(intMilesFlown) As TotalMilesFlown " &
                                   "From TFlights " &
                                    "WHERE TFlights.intFlightID = " & cboFlight.SelectedValue

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            intTotalMilesFlown = CInt(drSourceTable("TotalMilesFlown"))

            Close()

            strSelect = "SELECT COUNT(TFP.intPassengerID) As TotalPassengers " &
                                "FROM TFlightPassengers AS TFP JOIN TFlights AS TF " &
                                "ON TFP.intFlightID = TF.intFlightID " &
                                " WHERE TF.intFlightID = " & cboFlight.SelectedValue

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            intTotalPassengers = CInt(drSourceTable("TotalPassengers"))

            Close()

            strSelect = "SELECT strLastname, dtmDateOfBirth, FLOOR(DATEDIFF(DAY, dtmDateOfBirth, GetDate()) / 365.25) AS Age FROM TPassengers WHERE intPassengerID = " & cboPassenger.SelectedValue

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            intAge = CInt(drSourceTable("Age"))

            Close()

            strSelect = "SELECT COUNT(TFP.intPassengerID) AS TotalFlights " &
                                "FROM TPassengers AS TP JOIN TFlightPassengers  AS TFP " &
                                "ON TP.intPassengerID = TFP.intPassengerID " &
                                "JOIN TFlights AS TF " &
                                "ON TF.intFlightID = TFP.intFlightID " &
                                "WHERE TF.dtmFlightDate < GETDATE() AND TP.intPassengerID = " & cboPassenger.SelectedValue

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            intTotalFlights = CInt(drSourceTable("TotalFlights"))

            Close()

            If intTotalMilesFlown > 750 Then
                intDesignatedCost = 250 + 50
            End If
            If intTotalPassengers > 8 Then
                intDesignatedCost += intDesignatedCost + 100
            Else
                intDesignatedCost += intDesignatedCost - 50
            End If
            If strPlaneType = "Airbus A350" Then
                intDesignatedCost += intDesignatedCost + 35
            Else
                If strPlaneType = "Boeing 747-8" Then
                    intDesignatedCost += intDesignatedCost - 25
                End If
            End If
            If radReserved.Checked Then
                intReservedCost = intDesignatedCost + 125
            End If

            If intAge > 64 Then
                intDesignatedCost = intDesignatedCost * 0.8
                intReservedCost = intReservedCost * 0.8
            Else
                If intAge < 6 Then
                    intDesignatedCost = intDesignatedCost * 0.35
                    intReservedCost = intReservedCost * 0.35
                End If
            End If

            If intTotalFlights > 10 Then
                intDesignatedCost = intDesignatedCost * 0.8
                intReservedCost = intReservedCost * 0.8
            Else
                If intTotalFlights > 5 Then
                    intDesignatedCost = intDesignatedCost * 0.9
                    intReservedCost = intReservedCost * 0.9
                End If
            End If

            lblDesignatedCost.Text = intDesignatedCost
            lblReserveCost.Text = intReservedCost

            result = MessageBox.Show("Are you sure you want to Book this flight: " & cboFlight.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes



                    strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey " &
                                " FROM TFlightPassengers"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then

                        intNextPrimaryKey = 1

                    Else

                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                    End If


                    intPassengerID = cboPassenger.SelectedValue

                    If radDesignated.Checked Then
                        intCost = intDesignatedCost
                    Else
                        intCost = intReservedCost
                    End If
                    strInsert = "INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, intCost)" &
                            " VALUES (" & intNextPrimaryKey & "," & intFlightID & "," & intPassengerID & " , " & "'1B'" & ", " & intCost & ")"

                    MessageBox.Show(strInsert)

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Passenger has been added")

                    End If


                    CloseDatabaseConnection()
                    Close()
                    frmPassengerMain.ShowDialog()

            End Select



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class