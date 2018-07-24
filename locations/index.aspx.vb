Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Partial Class Locations
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()


        End If

    End Sub
    Public Sub BindData()
        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        Dim objConn As New SqlConnection(strConn)
        objConn.Open()
        Dim strSQL As String = "SELECT * FROM vw_LocationPlaceSiteMovieCount ORDER BY LocationPlaceAndSiteName"
        Dim dbComm = New SqlCommand(strSQL, objConn)
        Dim dt = dbComm.ExecuteReader()

        DataList1.DataSource = dt
        DataList1.DataBind()
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