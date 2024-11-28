Imports MySql.Data.MySqlClient

Public Class pgLogin

    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click

        lblInformation.ForeColor = ColorTranslator.FromHtml("#8c1308")
        Dim connectionString As String = "Server=localhost;Database=dbcustomers;Uid=root;Pwd=12Yellow34!"

        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            lblInformation.ForeColor = ColorTranslator.FromHtml("#9BE2F2")
            lblInformation.Text = "Please enter both username and password."
            Return
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()

                ' SQL query to find the username and passwords
                Dim query As String = "SELECT COUNT(*) FROM tblcustomer WHERE username = @username AND passwd = @password"

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    ' Execute the query
                    Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' If the result is greater than 0, the login is successful
                    If result > 0 Then
                        lblInformation.ForeColor = ColorTranslator.FromHtml("#9BE2F2")
                        lblInformation.Text = "Login successful!"
                        pgMenu.Show()
                        Me.Hide()
                    Else
                        lblInformation.ForeColor = ColorTranslator.FromHtml("#9BE2F2")
                        lblInformation.Text = "Invalid username or password."
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click

        Me.Close()

    End Sub


End Class
