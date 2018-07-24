Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Title
    Inherits Page
    Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
    'MS Access
    'Dim objConn As New OleDbConnection(strConn)
    'SQL Server as new  
    Dim objConn As New SqlConnection(strConn)


    Public intTitleID As Integer
    Public intIndexID As Integer ' Flag thunm index page to remember where to go back to (Main list (1) or by location list (2)
    Public strSQL As String



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        intindexID = 1 'Main index.aspx home page
        'Dim intTitleID as integer= 4 ' test
        '  Dim strSQL As String = "SELECT * FROM qryTitles WHERE tblScenes.TitleID=" & intTitleID


        If Not Page.IsPostBack() Then
            intPageSize.Text = "15"
            intCurrIndex.Text = "0"
            BindDataGrid()
            BindDataList()

        End If

        If Not IsPostBack Then

            BindDataGrid()

        End If

    End Sub


    Public Sub BindDataGrid()

        Dim strTitle As String
        Dim intColCount As Integer

        Try
            objConn.Open()

            intTitleID = Request.QueryString("TitleID")
            'MS Access
            'strSQL = "SELECT * FROM qryTitles WHERE tblScenes.TitleID=" & intTitleID
            'SQL Server
            strSQL = "SELECT * FROM vw_Movies WHERE SceneTitleID=" & intTitleID

            '  Dim intIndexID As Integer = Request.QueryString("intIndexID") 'Which thumb index page...Title.aspx(1) or MoviesByLocationThumbs.aspx (2)
            ' Dim strTitle As String = Request.QueryString("intIndexID") 'Which thumb index page...Title.aspx(1) or MoviesByLocationThumbs.aspx (2)
            'MS Access
            'Dim dbComm = New OleDbCommand(strSQL, objConn)
            Dim dbComm = New SqlCommand(strSQL, objConn)


            Dim dtrTitle = dbComm.ExecuteReader()
            dtrTitle.Read()
            strTitle = dtrTitle("TitleAndYear")
            ltWidescreen.Text = dtrTitle("Widescreen")
            'Set column count depending on title being in WS (2.35:1)
            If ltWidescreen.Text = "True" Then
                intColCount = 3
                'DataList1.RepeatColumns = 3
            Else
                intColCount = 4
                ' DataList1.RepeatColumns = 4
            End If
            DataList1.RepeatColumns = intColCount
            intPageSize.Text = intColCount * 5


            lblHeader.Text = strTitle
            Response.Write("<title>" & strTitle & " | Movies Made in Malta</title>")
            dtrTitle.Close()

            dtrTitle = dbComm.ExecuteReader()
            Gridview1.DataSource = dtrTitle
            Gridview1.DataBind()
            dtrTitle.Close()
            objConn.Close()
            ' End Try
        Catch ex As Exception
            Response.Write(ex.Message())
        Finally
        End Try


    End Sub
    Sub BindDataList()

        ' objConn.Open()

        intTitleID = Request.QueryString("TitleID")
        ' MS Access
        'strSQL = "SELECT * FROM qryTitlesAndScenes WHERE TitleID=" & intTitleID
        'SQl Server
        strSQL = "SELECT * FROM vw_MoviesScenesLocationsPlacesSitesAliases WHERE TitleID=" & intTitleID

        Dim ds As DataSet
        'MS Access
        'Dim da As OleDbDataAdapter
        'SQL
        Dim da As SqlDataAdapter


        'SCENES ..paging dataset
        ds = New DataSet
        'MS Access
        ' da = New OleDbDataAdapter(strSQL, objConn)
        'SQl Server
        da = New SqlDataAdapter(strSQL, objConn)

        If Not Page.IsPostBack() Then

            da.Fill(ds)
            intRecordCount.Text = CStr(ds.Tables(0).Rows.Count)
            ds = Nothing
            ds = New DataSet()
        End If

        'MS Access
        'da.Fill(ds, CInt(intCurrIndex.Text), CInt(intPageSize.Text), "qryTitlesAndScenes")
        'SQL
        da.Fill(ds, CInt(intCurrIndex.Text), CInt(intPageSize.Text), "vw_MoviesScenesLocationsPlacesSitesAliases")

        DataList1.DataSource = ds.Tables(0).DefaultView
        DataList1.DataBind()
        objConn.Close()
        PrintStatus()

    End Sub


    '-------------NAVIGATION ROUTINES ------------------

    Public Sub ShowFirst(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = "0"
        BindDataList()
    End Sub


    Public Sub ShowPrevious(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) - CInt(intPageSize.Text))
        If CInt(intCurrIndex.Text) < 0 Then
            intCurrIndex.Text = "0"
        End If
        BindDataList()
    End Sub

    Public Sub ShowNext(ByVal s As Object, ByVal e As EventArgs)
        If CInt(intCurrIndex.Text) + 1 < CInt(intRecordCount.Text) Then
            intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) + CInt(intPageSize.Text))
        End If
        BindDataList()
    End Sub

    Public Sub ShowLast(ByVal s As Object, ByVal e As EventArgs)
        Dim tmpInt As Integer

        tmpInt = CInt(intRecordCount.Text) Mod CInt(intPageSize.Text)
        If tmpInt > 0 Then
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - tmpInt)
        Else
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - CInt(intPageSize.Text))
        End If
        BindDataList()
    End Sub

    Private Sub PrintStatus()
        lblStatus.Text = "Total Scenes:<b>" & intRecordCount.Text
        lblStatus.Text += "</b> - Showing Page:<b> "
        lblStatus.Text += CStr(CInt(CInt(intCurrIndex.Text) / CInt(intPageSize.Text) + 1))
        lblStatus.Text += "</b> of <b>"

        If (CInt(intRecordCount.Text) Mod CInt(intPageSize.Text)) > 0 Then
            lblStatus.Text += CStr(CInt(CInt(intRecordCount.Text) / CInt(intPageSize.Text) + 1))
        Else
            lblStatus.Text += CStr(CInt(intRecordCount.Text) / CInt(intPageSize.Text))
        End If
        lblStatus.Text += "</b>"
    End Sub



End Class