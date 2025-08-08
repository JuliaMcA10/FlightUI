Public Class frmMain
    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        frmLoginEmployee.ShowDialog()

        Me.Hide()

    End Sub

    Private Sub btnPassenger_Click(sender As Object, e As EventArgs) Handles btnPassenger.Click
        frmLoginPassenger.ShowDialog()

        Me.Hide()

    End Sub
End Class
