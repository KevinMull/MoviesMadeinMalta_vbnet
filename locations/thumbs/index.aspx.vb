Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class _Thumbs
    Inherits Page
    Public Shared intIndexId As Integer 'Flag thumb index page to remember where to go back to (Main list (1) or by location list (2))
    Public Shared strTitle As String
    Dim strSQL As String ' = "SELECT * FROM qryTitlesAndScenes WHERE LocationSiteID=" & intLocationSiteID
    Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
    Dim objConn As New SqlConnection(strConn)
    Dim dbComm As New SqlCommand(strSQL, objConn)
    Dim dt As Object
    Public Shared intLocationSiteID As Integer
    Dim strImgPath As String
    Dim strImagePathDefault As String

    Public Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        intLocationSiteID = Request.QueryString("LocationSiteID")
        intIndexId = 2 ' Page 'By Location'
        strSQL = "SELECT * FROM vw_MoviesScenesLocationsPlacesSitesAliases WHERE LocationSiteId=" & intLocationSiteID

        If Not Page.IsPostBack() Then
            ' intPageSize.Text = "15"
            '  intCurrIndex.Text = "0"
            BindDataList()

        End If

        If Not IsPostBack Then

            objConn.Open()
            'Title Only
            dbComm = New SqlCommand(strSQL, objConn)

            dt = dbComm.ExecuteReader()
            dt.Read()

            'Set Google map values
            strLatLong.Value = dt("Latitude") & "," & dt("Longitude")
            If strLatLong.Value Is DBNull.Value Then
                strLatLong.Value = "35.93749, 14.37541" ' Default full Malta map if no lat, long
                intZoomLevel.Value = 10
            Else
                strLatLong.Value = strLatLong.Value
                intZoomLevel.Value = 14
            End If

            strTitle = dt("LocationPlaceAndSiteName")
            lblHeader.Text = "Location - " & strTitle
            Response.Write("<title>" & strTitle & " | Movies Made in Malta</title>")
            'Don't show an imgae placement if locations is 'UNKNOWN'
            'Check if image file exits first
            strImgPath = Server.MapPath("/images/locations/" & intLocationSiteID & ".jpg")
            If File.Exists(strImgPath) Then
                imgLocationSite.ImageUrl = "/images/locations/" & intLocationSiteID & ".jpg"
                hrImgLocationHiRes.NavigateUrl = "/images/locations/hires/" & intLocationSiteID & ".jpg"

            Else ' Default image
                imgLocationSite.ImageUrl = "/images/locations/image_unavailable.jpg"
            End If



            imgLocationSite.AlternateText = strTitle
            imgLocationSite.ToolTip = strTitle 'FF & Chrome
            dt.Close()
            objConn.Close()


        End If

    End Sub

    Public Sub BindDataList()

        Dim ds As DataSet

        intLocationSiteID = Request.QueryString("LocationSiteID")
        intIndexId = 2 ' By Location
        'intLocationSiteID = 2  'test
        strSQL = "SELECT * FROM vw_MoviesScenesLocationsPlacesSitesAliases WHERE LocationSiteId=" & intLocationSiteID


        'SCENES ..paging dataset
        ds = New DataSet
        dt = New SqlDataAdapter(strSQL, objConn)

        If Not Page.IsPostBack() Then
            intPageSize.Text = "15"
            intCurrIndex.Text = "0"

            dt.Fill(ds)

            intRecordCount.Text = CStr(ds.Tables(0).Rows.Count)
            ds = Nothing
            ds = New DataSet()
        End If

        'lblHeader.Text=ds.Tables("qryHolidayPhotos").Rows(1)("LocationSiteAndPlaceName")

        dt.Fill(ds, CInt(intCurrIndex.Text), CInt(intPageSize.Text), "qryTitlesAndScenes")

        DataList1.DataSource = ds.Tables(0).DefaultView
        DataList1.DataBind()
        objConn.Close()
        PrintStatus()


    End Sub
    '-------------PAGE NAVIGATION ROUTINES ------------------

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
    Function IsUnknown() As Boolean
        ' Check if location is of type 'UNKNOWN'
        If strTitle = "UNKNOWN" Then
            IsUnknown = True
        Else
            IsUnknown = False

        End If

        Return IsUnknown
    End Function

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