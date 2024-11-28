Imports MySql.Data.MySqlClient

Public Class pgCustomer

    Private connectionString As String = "Server=localhost;Database=dbcustomers;Uid=root;Pwd=12Yellow34!"
    Private customerData As DataTable
    Private currentIndex As Integer = -1

    Private Sub pgCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCustomerData()

        If customerData.Rows.Count > 0 Then
            currentIndex = 0
            DisplayRecord(currentIndex)
        Else
            MessageBox.Show("No records found!")
        End If

    End Sub

    Private Sub LoadCustomerData()

        Using conn As New MySqlConnection(connectionString)

            Try
                conn.Open()
                Dim query As String = "SELECT * FROM tblcustomer"
                Dim adapter As New MySqlDataAdapter(query, conn)
                customerData = New DataTable()
                adapter.Fill(customerData)
            Catch ex As Exception
                MessageBox.Show("Error loading data: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub DisplayRecord(index As Integer)

        If index >= 0 AndAlso index < customerData.Rows.Count Then
            Dim row As DataRow = customerData.Rows(index)
            txtCid.Text = row("uid").ToString()
            txtTitle.Text = row("title").ToString()
            txtForename.Text = row("forename").ToString()
            txtSurname.Text = row("surname").ToString()
            txtAge.Text = row("age").ToString()
            txtUsername.Text = row("username").ToString()
            txtPassword.Text = row("passwd").ToString()
        End If

    End Sub

    Private Sub lblNext_Click(sender As Object, e As EventArgs) Handles lblNext.Click
        If currentIndex < customerData.Rows.Count - 1 Then
            currentIndex += 1
            DisplayRecord(currentIndex)
        Else
            MessageBox.Show("You are at the last record.")
        End If
    End Sub


    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles lblPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplayRecord(currentIndex)
        Else
            MessageBox.Show("You are at the first record.")
        End If
    End Sub

    Private Sub lblFirst_Click(sender As Object, e As EventArgs) Handles lblFirst.Click

        If customerData.Rows.Count > 0 Then
            currentIndex = 0 ' Set to the first record
            DisplayRecord(currentIndex) ' Display the first record
        Else
            MessageBox.Show("No records to display.")
        End If

    End Sub

    Private Sub lblLast_Click(sender As Object, e As EventArgs) Handles lblLast.Click

        If customerData.Rows.Count > 0 Then
            currentIndex = customerData.Rows.Count - 1 ' Set to the last record
            DisplayRecord(currentIndex) ' Display the last record
        Else
            MessageBox.Show("No records to display.")
        End If

    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click

        Exit Sub

    End Sub

    Private Sub lblBackButton_Click(sender As Object, e As EventArgs) Handles lblBackButton.Click

        pgMenu.Show()
        Me.Hide()

    End Sub
End Class