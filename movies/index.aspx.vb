Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Partial Class _Movies
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridView()


        End If

    End Sub
    Private Sub BindGridView()
        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        'MS Access
        ' Dim objConn As New OleDbConnection(strConn)
        'SQL
        Dim objConn As New SqlConnection(strConn)
        objConn.Open()
        Dim strSQL As String = "SELECT Title, TitleURL, TitleYear, SceneTitleId AS intScenesTitleId, imdbURL FROM vw_Movies ORDER BY ParsedTitle"
        Dim dbComm = New SqlCommand(strSQL, objConn)
        Dim dt = dbComm.ExecuteReader()

        GridView1.DataSource = dt
        GridView1.DataBind()
        dt.Close()
        objConn.Close()

    End Sub

    Function CheckNullVal(ByVal id As Object) As Integer
        'Check if title has stills.  If yes, show filmstrip img url, else hide
        On Error Resume Next
        Dim displayCheck As Boolean = True
        If IsDBNull(id) Then
            displayCheck = False
        End If
        Return displayCheck
    End Function

   
End Class