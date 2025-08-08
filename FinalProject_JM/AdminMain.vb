Public Class frmAdminMain
    Private Sub btnFlight_Click(sender As Object, e As EventArgs) Handles btnFlight.Click
        frmAdminAddFlight.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnPilots_Click(sender As Object, e As EventArgs) Handles btnPilots.Click
        frmAdminPilot.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnAttendants_Click(sender As Object, e As EventArgs) Handles btnAttendants.Click
        frmAdminAttendant.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        frmStatistics.ShowDialog()

        Me.Hide()

    End Sub
End Class