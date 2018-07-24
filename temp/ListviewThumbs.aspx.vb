Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
 Imports System.Configuration

Partial Class _Thumbs
    Inherits Page
    Public Shared intIndexId As Integer 'Flag thumb index page to remember where to go back to (Main list (1) or by location list (2))
    Dim strTitle As String
    Dim strSQL As String ' = "SELECT * FROM qryTitlesAndScenes WHERE LocationSiteID=" & intLocationSiteID
    Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
    Dim objConn As New OleDbConnection(strConn)
    Dim dbComm As New OleDbCommand(strSQL, objConn)
    Dim dt As Object
    Public Shared intLocationSiteID As Integer

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        intLocationSiteID = Request.QueryString("LocationSiteID")
        intIndexId = 2 ' By Location
        strSQL = "SELECT * FROM qryTitlesAndScenes WHERE LocationSiteID=" & intLocationSiteID

        If Not Page.IsPostBack() Then
            intPageSize.Text = "20"
            intCurrIndex.Text = "0"
            BindListView()

        End If

        If Not IsPostBack Then
            objConn.Open()
            'Title Only
            dbComm = New OleDbCommand(strSQL, objConn)

            dt = dbComm.ExecuteReader()
            dt.Read()
            strTitle = dt("LocationPlaceAndSiteName")
            lblHeader.Text = "Location - " & strTitle
            Response.Write("<title>" & strTitle & "</title>")
            dt.Close()
            objConn.Close()


        End If

    End Sub
    Public Sub BindListView()
        ' Dim intIndexId As Integer = 2 'Flag thumb index page to remember where to go back to (Main list (1) or by location list (2))
        'Dim intLocationSiteID As Integer = Request.QueryString("LocationSiteID") ' USE
        intLocationSiteID = Request.QueryString("LocationSiteID")
        intIndexId = 2 ' By Location
        'intLocationSiteID = 2  'test
        strSQL = "SELECT * FROM qryTitlesAndScenes WHERE LocationSiteID=" & intLocationSiteID

        '------------------

        Dim ds As DataSet
        Dim da As OleDbDataAdapter
        ' Dim intLocationSiteID As Integer
        'intLocationSiteID = Request.QueryString("LocationSiteID") ' USE
        'intLocationSiteID  = 2  'test
        'Dim strSQL As String = "SELECT * FROM qryTitlesAndScenes WHERE LocationSiteID=" & intLocationSiteID
        'SCENES ..paging dataset
        ds = New DataSet
        dt = New OleDbDataAdapter(strSQL, objConn)

        If Not Page.IsPostBack() Then

            dt.Fill(ds)
            intRecordCount.Text = CStr(ds.Tables(0).Rows.Count)
            ds = Nothing
            ds = New DataSet()
        End If

        'lblHeader.Text=ds.Tables("qryHolidayPhotos").Rows(1)("LocationSiteAndPlaceName")

        dt.Fill(ds, CInt(intCurrIndex.Text), CInt(intPageSize.Text), "qryTitlesAndScenes")

        ListView1.DataSource = ds.Tables(0).DefaultView
        ListView1.DataBind()
        objConn.Close()
        PrintStatus()


    End Sub
    '-------------NAVIGATION ROUTINES ------------------

    Public Sub ShowFirst(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = "0"
        BindListView()
    End Sub


    Public Sub ShowPrevious(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) - CInt(intPageSize.Text))
        If CInt(intCurrIndex.Text) < 0 Then
            intCurrIndex.Text = "0"
        End If
        BindListView()
    End Sub

    Public Sub ShowNext(ByVal s As Object, ByVal e As EventArgs)
        If CInt(intCurrIndex.Text) + 1 < CInt(intRecordCount.Text) Then
            intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) + CInt(intPageSize.Text))
        End If
        BindListView()
    End Sub

    Public Sub ShowLast(ByVal s As Object, ByVal e As EventArgs)
        Dim tmpInt As Integer

        tmpInt = CInt(intRecordCount.Text) Mod CInt(intPageSize.Text)
        If tmpInt > 0 Then
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - tmpInt)
        Else
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - CInt(intPageSize.Text))
        End If
        BindListView()
    End Sub

    Private Sub PrintStatus()
        lblStatus.Text = "Total Scenes: <strong>" & intRecordCount.Text

        If CInt(intRecordCount.Text) > CInt(intPageSize.Text) Then
            lblStatus.Text += "</strong> - Showing Page:<strong> "
            lblStatus.Text += CStr(CInt(CInt(intCurrIndex.Text) / CInt(intPageSize.Text) + 1))
            lblStatus.Text += "</strong> of <strong>"

            If (CInt(intRecordCount.Text) Mod CInt(intPageSize.Text)) > 0 Then
                lblStatus.Text += CStr(CInt(CInt(intRecordCount.Text) / CInt(intPageSize.Text) + 1))
            Else
                lblStatus.Text += CStr(CInt(intRecordCount.Text) / CInt(intPageSize.Text))
            End If
            lblStatus.Text += "</strong>"
        End If

    End Sub

    'Function GetNumOfCols() As Integer
    '    Dim intColMax As Integer = 4

    '    If CInt(intRecordCount.Text) < intColMax Then
    '        GetNumOfCols = CInt(intRecordCount.Text)
    '    Else
    '        GetNumOfCols = intColMax

    '    End If

    '    Return GetNumOfCols

    'End Function

    'Function ShowMultiplePages() As Boolean
    '    'Check the total number of scenes.  More than 20 (thumbs per page) then show multi page navigation
    '    '  On Error Resume Next
    '    ShowMultiplePages = False

    '    If CInt(intRecordCount.Text) > CInt(intPageSize.Text) Then
    '        ShowMultiplePages = true
    '    End If
    '    Return ShowMultiplePages
    'End Function

End Class