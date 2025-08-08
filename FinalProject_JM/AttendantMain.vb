Public Class frmAttendantMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmAttendantUpdate.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnPast_Click(sender As Object, e As EventArgs) Handles btnPast.Click
        frmAttendantPast.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnFuture_Click(sender As Object, e As EventArgs) Handles btnFuture.Click
        frmAttendantFuture.ShowDialog()

        Me.Hide()

    End Sub
End Class