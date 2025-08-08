Public Class frmPilotMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmPilotUpdate.ShowDialog()

        Me.Close()

    End Sub

    Private Sub btnPast_Click(sender As Object, e As EventArgs) Handles btnPast.Click
        frmPilotPast.ShowDialog()

        Me.Close()

    End Sub

    Private Sub btnFuture_Click(sender As Object, e As EventArgs) Handles btnFuture.Click
        frmPilotFuture.ShowDialog()

        Me.Close()

    End Sub
End Class