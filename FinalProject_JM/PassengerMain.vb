Public Class frmPassengerMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Me.Hide()

        frmPassengerUpdate.ShowDialog()

        Me.Show()

    End Sub

    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        Me.Hide()

        frmPassengerBookFlight.ShowDialog()

        Me.Show()

    End Sub

    Private Sub btnPast_Click(sender As Object, e As EventArgs) Handles btnPast.Click
        Me.Hide()

        frmPassengerPast.ShowDialog()

        Me.Show()

    End Sub

    Private Sub btnFuture_Click(sender As Object, e As EventArgs) Handles btnFuture.Click
        Me.Hide()

        frmPassengerFuture.ShowDialog()

        Me.Show()

    End Sub

    Private Sub btnNewPassenger_Click(sender As Object, e As EventArgs) Handles btnNewPassenger.Click
        Me.Hide()

        frmPassengerAdd.ShowDialog()

        Me.Show()
    End Sub
End Class