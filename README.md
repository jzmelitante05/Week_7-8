# VB.NET Login System

A simple Login System developed using VB.NET Windows Forms Application with CSV file authentication. This project demonstrates basic login validation, role-based access, file handling using `StreamReader`, and error handling using `Try-Catch`.

---

# Features

- Admin Login
- User Login
- CSV-based authentication
- Role-based navigation
- Error handling
- Windows Forms Application
- StreamReader file reading

---

# Technologies Used

- VB.NET
- Windows Forms
- .NET Framework
- CSV File
- StreamReader

---

# Project Structure

```plaintext
LoginSystemProject/
│
├── credentials.csv
├── Form1.vb
├── AdminForm.vb
├── UserForm.vb
├── README.md
└── Screenshots/
```

---

# System Requirements

## Software Requirements

- Visual Studio 2019 or later
- .NET Framework
- Windows Operating System

---

# Step 1 — Create credentials.csv

Create a file named:

```plaintext
credentials.csv
```

Place the file inside:

```plaintext
bin/Debug/
```

## Sample CSV Content

```csv
username,password,role
admin,admin123,Admin
john,user123,User
maria,pass456,User
```

---

# Step 2 — Design the Login Form

## Form Name

```plaintext
Form1
```

## Controls Needed

| Control Type | Name | Text |
|---|---|---|
| Label | lblTitle | LOGIN SYSTEM |
| Label | lblUsername | Username |
| Label | lblPassword | Password |
| TextBox | txtUsername | |
| TextBox | txtPassword | |
| Button | btnLogin | Login |
| Label | lblMessage | |

---

# Suggested Form Design

```plaintext
----------------------------------
|         LOGIN SYSTEM           |
|                                |
| Username: [______________]     |
| Password: [______________]     |
|                                |
|          [ LOGIN ]             |
|                                |
| Message Here                   |
----------------------------------
```

---

# Important Properties

## txtPassword

```vb
UseSystemPasswordChar = True
```

## lblMessage

```vb
ForeColor = Red
```

---

# Step 3 — Create Admin Form

## Form Name

```plaintext
AdminForm
```

## Controls

| Control | Text |
|---|---|
| Label | Welcome Admin |

---

# Step 4 — Create User Form

## Form Name

```plaintext
UserForm
```

## Controls

| Control | Text |
|---|---|
| Label | Welcome User |

---

# Step 5 — Login System Code

## Form1.vb

```vb
Imports System.IO

Public Class Form1

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim filePath As String = "credentials.csv"

        Try

            If Not File.Exists(filePath) Then
                MessageBox.Show("credentials.csv file not found!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim loginSuccess As Boolean = False

            Using reader As New StreamReader(filePath)

                ' Skip header row
                reader.ReadLine()

                While Not reader.EndOfStream

                    Dim line As String = reader.ReadLine()
                    Dim data() As String = line.Split(","c)

                    If data.Length >= 3 Then

                        Dim storedUsername As String = data(0)
                        Dim storedPassword As String = data(1)
                        Dim role As String = data(2)

                        If username = storedUsername And password = storedPassword Then

                            loginSuccess = True

                            If role = "Admin" Then

                                AdminForm.Show()
                                Me.Hide()

                            ElseIf role = "User" Then

                                UserForm.Show()
                                Me.Hide()

                            End If

                            Exit While

                        End If

                    End If

                End While

            End Using

            If loginSuccess = False Then
                lblMessage.Text = "Invalid Username or Password"
            End If

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)

        End Try

    End Sub

End Class
```

---

# AdminForm.vb

```vb
Public Class AdminForm

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
```

---

# UserForm.vb

```vb
Public Class UserForm

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
```

---

# Code Explanation

## Imports System.IO

Used for file handling.

```vb
Imports System.IO
```

---

## StreamReader

Reads the CSV file line by line.

```vb
Using reader As New StreamReader(filePath)
```

---

## Split Function

Separates CSV values.

```vb
Dim data() As String = line.Split(","c)
```

---

## Try-Catch

Handles errors safely.

```vb
Try
Catch ex As Exception
```

---

# Program Flow

```plaintext
START
   ↓
Open Login Form
   ↓
Enter Username & Password
   ↓
Read credentials.csv
   ↓
Compare Credentials
   ↓
Correct?
 ├── YES → Check Role
 │          ├── Admin → Open Admin Form
 │          └── User → Open User Form
 │
 └── NO → Display Error Message
   ↓
END
```

---

# Features of the System

| Feature | Description |
|---|---|
| Login Authentication | Checks username and password |
| CSV Database | Stores user accounts |
| Admin Role | Opens Admin Panel |
| User Role | Opens User Dashboard |
| Error Handling | Prevents crashes |
| StreamReader | Reads CSV file |

---

# Testing the System

## Test Case 1 — Admin Login

| Input | Expected Result |
|---|---|
| Username: admin | Opens Admin Form |
| Password: admin123 | |

---

## Test Case 2 — User Login

| Input | Expected Result |
|---|---|
| Username: john | Opens User Form |
| Password: user123 | |

---

## Test Case 3 — Invalid Login

| Input | Expected Result |
|---|---|
| Wrong Username | Error Message |
| Wrong Password | |

---

# Error Handling

The system handles the following errors:

| Error | Solution |
|---|---|
| Missing CSV File | Displays message box |
| Wrong Username | Shows invalid login message |
| Wrong Password | Shows invalid login message |
| Invalid CSV Format | Prevents program crash |

---

# How to Run the Project

1. Open the project in Visual Studio.
2. Create the forms:
   - Form1
   - AdminForm
   - UserForm
3. Add the controls to Form1.
4. Copy the provided VB.NET code.
5. Create `credentials.csv`.
6. Place the CSV file inside `bin/Debug/`.
7. Run the application.
8. Login using sample accounts.

---

# Sample Accounts

| Username | Password | Role |
|---|---|---|
| admin | admin123 | Admin |
| john | user123 | User |
| maria | pass456 | User |

---

# Learning Outcomes

This project helped develop skills in:

- VB.NET Programming
- Windows Forms Design
- File Handling
- Authentication Systems
- Error Handling
- Role-Based Access Control

---

# Conclusion

The Login System successfully demonstrates authentication using VB.NET and CSV file handling. The system validates usernames and passwords, identifies user roles, and redirects users to appropriate dashboards. The project also implements error handling using `Try-Catch` blocks to improve system reliability and usability.

---

# Future Improvements

- Add registration feature
- Encrypt passwords
- Use MySQL database
- Add logout button
- Add password recovery
- Improve UI design
- Add activity logs

---

# Submitted By

| Information | Details |
|---|---|
| Name | Joezainne Melitante |
| Course & Section | 2.1 BSIT |
| Instructor | Mr. Edward James V. Grageda |
| Date Submitted | May 23, 2026 |

---
