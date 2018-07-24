Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Partial Class _MaltaMap

    Inherits Page



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            GetData()
        End If

    End Sub

    Public Sub GetData()




        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        Dim objConn As New SqlConnection(strConn)

        objConn.Open()
        Dim strSQL As String = "SELECT * FROM vw_LocationAliases WHERE Latitude is not Null"
        Dim dbComm = New SqlCommand(strSQL, objConn)
        Dim dt = dbComm.ExecuteReader()
        
        Repeater1.DataSource = dt
        Repeater1.DataBind()

        dt.Close()
        objConn.Close()


    End Sub


End Class