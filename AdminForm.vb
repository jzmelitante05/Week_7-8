Public Class AdminForm

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblAdmin.Text = "Welcome Admin"

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Form1.Show()
        Me.Close()

    End Sub

End Class
