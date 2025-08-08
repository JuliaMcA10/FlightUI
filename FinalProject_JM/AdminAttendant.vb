Public Class frmAdminAttendant
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAttendantAdd.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        frmAttendantDelete.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnFuture_Click(sender As Object, e As EventArgs) Handles btnFuture.Click
        frmAdminAddAttendantFlight.ShowDialog()

        Me.Hide()

    End Sub
End Class