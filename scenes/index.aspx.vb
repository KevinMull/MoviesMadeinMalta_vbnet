Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Scenes
    Inherits Page
   

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()

        End If

    End Sub


    Public Sub BindData()

        Dim intTitleID As Integer = Request.QueryString("TitleID")
        Dim intLocationPlaceID As Integer
        Dim strLocationPlace As String
        Dim intSceneID As Integer = Request.QueryString("SceneID")
        Dim intLocationSiteID As Integer
        Dim strTitle As String
        Dim strIndexURL As String
        Dim strIndexText As String
        Dim intIndexID As Integer = Request.QueryString("indexID") 'Which thumb index page...Title.aspx(1) or MoviesByLocationThumbs.aspx (2)
        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        Dim objConn As New SqlConnection(strConn)
        objConn.Open()
        Dim strSQL As String = "SELECT [LocationPlaceName],[LocationPlaceId], [SceneId], [CoverArtWebPath], [Title], [TitleAndYear],[LocationPlaceAndSiteName], [LocationAliasCountryAndPlace], [Notes] FROM vw_MoviesScenesLocationsPlacesSitesAliases  WHERE [SceneId] = " & intSceneID

        
        '--------------
        'intTitleID = 4 ' Black Eagle  TEST
        'intSceneID= 7 'Vall  TEST
        'indexID=1 ' TEST
        '--------
       
        'on error resume next ' NULLS in 'Notes'

        Dim dbComm = New SqlCommand(strSQL, objConn)
        Dim dt = dbComm.ExecuteReader()
        dt.Read()
        strTitle = dt("TitleAndYear")
        'For Unknown Locations (42) Only
        'To hide 'Show Map Location' button anc change lnkBack url
        intLocationSiteID = Request.QueryString("LocationSiteId")
        intLocationPlaceID = dt("LocationPlaceId")
        strLocationPlace = dt("LocationPlaceName")

        Select Case intIndexID

            Case Is = 1
                lblMapLink.Visible = True
                strIndexURL = "/Title/index.aspx?TitleId=" & intTitleID
                strIndexText = dt("Title") & " Index"
                'strIndexText=" Index"

            Case Is = 2
                lblMapLink.Visible = True
                strIndexURL = "/locations/thumbs/index.aspx?LocationSiteId=" & intLocationSiteID
                strIndexText = dt("LocationPlaceAndSiteName") & " Index"
                'strIndexText=" Index"

            Case Is = 3
                lblMapLink.Visible = False
                strIndexURL = "/unknowns/index.aspx"
                strIndexText = "Unknown Locations Index"
                'strIndexText=" Index"

        End Select

        '   lblMapLink.Text = ShowLocationPlace(strLocationPlace, intLocationPlaceID)

        lblHeader.Text = strTitle

        lnkBack.NavigateUrl = strIndexURL
        lnkBack.Text = strIndexText

        Response.Write("<title>" & strTitle & " | Movies Made in Malta</title>")
        imgScene.ImageUrl = "/images/scenes/large/" & intSceneID & ".jpg"
        imgScene.AlternateText = dt("LocationPlaceAndSiteName")
        imgScene.ToolTip = dt("LocationPlaceAndSiteName")
        ltLocationName.Text = dt("LocationPlaceAndSiteName")


        If IsDBNull(dt("LocationAliasCountryAndPlace")) = False Then
            ltLocationAlias.Text = dt("LocationAliasCountryAndPlace")
            lblLocationAlias.Visible = True
        Else
            ltLocationAlias.Text = ""
            lblLocationAlias.Visible = False
        End If

        If IsDBNull(dt("Notes")) = False Then
            ltNotes.Text = dt("Notes")
            lblNotes.Visible = True
        Else
            ltNotes.Text = ""
            lblNotes.Visible = False
        End If

        'ltNotes.Text=dt("Notes")
        'lblNotes.Visible=False CheckNullVal("Notes")
        'imgMap.ImageURL="/moviesmadeinmalta/images/maps/" & dt("LocationPlaceID") & ".jpg"
        dt.Close()

        objConn.Close()


    End Sub
    'Public Sub ShowLocationPlace(strLocationPlace As String, intLocationPlaceID As Integer)
    '    If strLocationPlace <> "" Then
    '        Return "<a language=""Javascript"" href=""#"" onClick=""window.showModalDialog('/maltamap.aspx?intLocationPlaceID=" & _
    'intLocationPlaceID & "&strLocationPlace=" & strLocationPlace & "','', ';dialogWidth:365px;dialogHeight:455px;help:no;status:no;scroll:no');return false;""><b>Malta Map Location</b></a>"
    '    End If
    'End Sub

End Class