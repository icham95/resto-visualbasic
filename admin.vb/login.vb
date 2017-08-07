Public Class login
    Public userId As Integer = 0
    Public userName As String = ""
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "raisa"
        TextBox2.Text = "123123"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        buka()
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        rs.Open("select users.id as userId, users.username as userName from users " & _
                "inner join user_level on user_level.user_id = users.id " & _
                "where users.username = '" & username & "' and users.password = '" & password & "' " & _
                " and user_level.level_id = '1' and users.status = '2'", conn)
        If rs.EOF = False Then
            Me.userId = rs.Fields.Item("userId").Value
            Me.userName = rs.Fields.Item("userName").Value
            Me.Hide()
            admin.Show()
        Else
            MsgBox("nama dan password tidak cocok")
        End If
            tutup()
    End Sub
End Class
