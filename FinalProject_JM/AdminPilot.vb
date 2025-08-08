Public Class frmAdminPilot
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmPilotAdd.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        frmPilotDelete.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnFuture_Click(sender As Object, e As EventArgs) Handles btnFuture.Click
        frmAdminAddPilotFlight.ShowDialog()

        Me.Hide()

    End Sub
End Class