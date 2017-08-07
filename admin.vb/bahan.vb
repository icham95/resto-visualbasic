Public Class bahan

    Private Sub bahan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buka()
        rs.Open("select * from satuan", conn)
        Me.ComboBox1.Items.Clear()
        While rs.EOF = False
            Me.ComboBox1.Items.Add(rs.Fields.Item("nama").Value)
            rs.MoveNext()
        End While
        tutup()

        Me.tampil()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nama As String = tnama.Text
        Dim harga As String = tharga.Text
        Dim jumlah As String = tjumlah.Text
        Dim satuan_id As Integer = 0
        Dim query As String

        'ambil satuan id
        buka()
        rs.Open("select * from satuan where nama = '" & ComboBox1.SelectedItem & "'", conn)
        satuan_id = rs.Fields.Item("id").Value
        tutup()

        buka()
        query = "call insertBahan('" & nama & "', '" & harga & "', '" & jumlah & "', '" & satuan_id & "', '" & login.userId & "')"
        conn.Execute(query)
        tutup()

        Me.tampil()

        MsgBox("berhasil di masukan")
    End Sub

    Private Sub tampil()
        Dim myDataAdapter As New Odbc.OdbcDataAdapter
        Dim myDataSet As New DataSet
        Dim myConn As New Odbc.OdbcConnection("DSN=resto")
        Dim query As String
        query = "select bahan.id, bahan.nama, bahan.harga, " & _
            "bahan.jumlah, satuan.nama as satuan, users.username as oleh from bahan " & _
            "inner join satuan on bahan.satuan_id = satuan.id " & _
            "inner join users on bahan.user_id = users.id "
        myConn.Open()
        myDataAdapter.SelectCommand = New Odbc.OdbcCommand(query, myConn)
        myDataAdapter.Fill(myDataSet)
        Me.BindingSource1.DataMember = myDataSet.Tables(0).TableName
        Me.BindingSource1.DataSource = myDataSet
        Me.DataGridView1.DataSource = Me.BindingSource1
        myConn.Close()
    End Sub
End Class