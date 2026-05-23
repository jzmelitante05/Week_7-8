Public Class UserForm

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblUser.Text = "Welcome User"

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Form1.Show()
        Me.Close()

    End Sub

End Class
