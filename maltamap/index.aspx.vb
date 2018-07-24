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


        'Dim conString As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        'Dim cmd As New SqlCommand(query)
        'Using con As New SqlConnection(conString)
        '    Using sda As New SqlDataAdapter()
        '        cmd.Connection = con

        '        sda.SelectCommand = cmd
        '        Using dt As New DataTable()
        '            sda.Fill(dt)
        '            Return dt
        '        End Using
        '    End Using
        'End Using


        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        Dim objConn As New SqlConnection(strConn)

        objConn.Open()
        ' Dim strSQL As String = "SELECT * FROM qryTitlesScenesLocationSites"
        Dim strSQL As String = "SELECT * FROM vw_LocationPlacesSites WHERE MapInfoHtml Is Not Null"
        Dim dbComm = New SqlCommand(strSQL, objConn)
        Dim dt = dbComm.ExecuteReader()
        
        Repeater1.DataSource = dt
        Repeater1.DataBind()

        'strTitleList.Value = dt("TitleList")
        
        dt.Close()
        objConn.Close()


    End Sub


End Class