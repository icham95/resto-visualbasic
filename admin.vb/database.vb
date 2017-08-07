Module database
    Public conn As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public conn1 As New ADODB.Connection
    Public rs1 As New ADODB.Recordset
    Public conn2 As New ADODB.Connection
    Public rs2 As New ADODB.Recordset
    Public conndb As New ADODB.Connection
    Public rsdb As New ADODB.Recordset
    Public Sub buka()
        conn.Open("dsn=resto")
    End Sub
    Public Sub tutup()
        conn.Close()
    End Sub
    Public Sub buka1()
        conn1.Open("dsn=resto")
    End Sub
    Public Sub tutup1()
        conn1.Close()
    End Sub
    Public Sub buka2()
        conn2.Open("dsn=resto")
    End Sub
    Public Sub tutup2()
        conn2.Close()
    End Sub
    Public Sub bukadb()
        conndb.Open("dsn=resto")
    End Sub
    Public Sub tutupdb()
        conndb.Close()
    End Sub
End Module
