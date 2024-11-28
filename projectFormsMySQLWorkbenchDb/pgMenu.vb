Public Class pgMenu
    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click

        pgCustomer.Show()
        Me.Hide()

    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click

        pgLogin.Show()
        Me.Hide()

        Exit Sub

    End Sub
End Class