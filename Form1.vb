Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMessage.Text = ""
        txtPassword.UseSystemPasswordChar = True

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim filePath As String = "credentials.csv"

        Try

            ' Check if file exists
            If Not File.Exists(filePath) Then

                MessageBox.Show("credentials.csv file not found!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

                Exit Sub

            End If

            Dim loginSuccess As Boolean = False

            Using reader As New StreamReader(filePath)

                ' Skip CSV header
                reader.ReadLine()

                While Not reader.EndOfStream

                    Dim line As String = reader.ReadLine()

                    Dim data() As String = line.Split(","c)

                    If data.Length >= 3 Then

                        Dim storedUsername As String = data(0).Trim()
                        Dim storedPassword As String = data(1).Trim()
                        Dim role As String = data(2).Trim()

                        ' Validate login
                        If username = storedUsername And password = storedPassword Then

                            loginSuccess = True

                            MessageBox.Show("Login Successful!",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information)

                            ' Open forms based on role
                            If role = "Admin" Then

                                Dim admin As New AdminForm()
                                admin.Show()
                                Me.Hide()

                            ElseIf role = "User" Then

                                Dim user As New UserForm()
                                user.Show()
                                Me.Hide()

                            End If

                            Exit While

                        End If

                    End If

                End While

            End Using

            ' Invalid login
            If loginSuccess = False Then

                lblMessage.Text = "Invalid Username or Password"

            End If

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message,
                            "System Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

End Class
