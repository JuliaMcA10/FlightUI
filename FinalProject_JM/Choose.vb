Public Class Choose
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnPassenger_Click(sender As Object, e As EventArgs) Handles btnPassenger.Click
        frmPassengerMain.ShowDialog()

    End Sub

    Private Sub btnPilot_Click(sender As Object, e As EventArgs) Handles btnPilot.Click
        frmPilotMain.ShowDialog()

    End Sub

    Private Sub btnAttendant_Click(sender As Object, e As EventArgs) Handles btnAttendant.Click
        frmAttendantMain.ShowDialog()

    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        frmAdminMain.ShowDialog()

    End Sub
End Class