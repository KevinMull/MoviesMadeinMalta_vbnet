Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Partial Class _Comments

    Inherits Page


    'Dim strTitle As String



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            BindDataGrid()

        End If

    End Sub
    Sub AddComment(ByVal Sender As Object, ByVal e As EventArgs)


        If Page.IsValid Then

            'First do a sSPAM BOT ;honeypot' check on hidden input field 'email'.
            'Should be NULL if human, else a SPAM BOT!!
            If email.Text = String.Empty Then


                Dim strSQL As String
                Dim strIPAddress As String
                Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
                Dim objConn As New SqlConnection(strConn)
                strIPAddress = Request.ServerVariables("REMOTE_ADDR")

                strSQL = "INSERT INTO Comments (IPAddress,UserName,UserEmail,Comments,CommentDate) " & _
                "VALUES (@IPAddress, @UserName,@UserEmail,@Comments,@CommentDate)"

                'Today Date
                Dim dtNow As DateTime = DateTime.Now
                Dim strDate As DateTime = dtNow.Date
                Dim dbComm = New SqlCommand(strSQL, objConn)

                ' dbComm = New OleDbCommand(strSQL, objConn)

                dbComm.Parameters.AddWithValue("@IpAddress", OleDbType.VarWChar).Value = strIPAddress
                dbComm.Parameters.AddWithValue("@UserName", OleDbType.VarWChar).Value = txtUserName.Text
                dbComm.Parameters.AddWithValue("@UserEmail", OleDbType.VarWChar).Value = txtUserEmail.Text
                dbComm.Parameters.AddWithValue("@Comments", OleDbType.LongVarWChar).Value = txtComments.Text
                dbComm.Parameters.AddWithValue("@CommentDate", OleDbType.Date).Value = strDate

                objConn.Open()
                dbComm.ExecuteNonQuery()
                objConn.Close()

                SendEmail()

                lblThanks.Text = "Thank you for your comments"

                'Clear All Values
                txtUserName.Text = ""
                txtUserEmail.Text = ""
                txtComments.Text = ""
                'txtAnswer.Text = ""
                'chkHuman.Checked = False

                BindDataGrid()

            End If


        End If
    End Sub

    Private Sub BindDataGrid()

        Dim dtr
        Dim strSQL As String
        Dim strCriteria As String
        Dim strConn As String = ConfigurationManager.ConnectionStrings("MaltaMoviesConnectionString").ConnectionString
        Dim objConn As New SqlConnection(strConn)



        'GET THE USER HOST NAME & IP ADDRESS

        'eliminate all entries with URLs...
        'MS Access
        'strCriteria = "tblBlockedIPAddresses.IPAddress Is Null AND [Comments] Not Like '%http%' And [Comments] Not Like '%www%'"
        'strSQL = "SELECT UserName, UserEmail, Comments, CommentDate FROM qryComments WHERE " & strCriteria
        strSQL = "SELECT UserName, UserEmail, Comments, CommentDate FROM vw_Comments"

        Dim dbComm = New SqlCommand(strSQL, objConn)

        objConn.Open()
        dtr = dbComm.ExecuteReader()

        dgComments.DataSource = dtr
        dgComments.DataBind()
        dtr.Close()
        objConn.Close()
    End Sub

    Sub SendEmail()

        ' Google SMTP details
        'Dim strMyEmail As String = "kevmull65@gmail.com"
        'Dim strPassword As String = "qxxxxy"
        'Dim strSMTP As String = "smtp.gmail.com"
        '  smtp.google.com or smtp.gmail.com

        '' HostingUK.net SMTP Details
        Dim strMyEmail As String = "kevin@moviesmadeinmalta.com"
        Dim strPassword As String = "Lls095X9mb"
        Dim strSMTP As String = "mail.moviesmadeinmalta.com"



        ' Send an email after a new comment has been inserted...

        Using mm As New MailMessage(strMyEmail, strMyEmail)
            mm.Subject = "Movies Made in Malta - New Comment"
            Dim body As String = "A new comment has been added to www.moviesmadeinmalta.com/comments/index.aspx"
            ' body += "<br /><a href = 'www.moviesmadeinmalta.com.'>Movies Made in Malta.</a>"
            body += "<br /><br />"
            body += "User Name: " + txtUserName.Text
            body += "<br /><br />"
            body += "Email: " + txtUserEmail.Text
            body += "<br /><br />"
            body += "Comments: " + txtComments.Text

            mm.Body = body
            mm.IsBodyHtml = True
            Dim smtp As New Mail.SmtpClient()
            smtp.Host = strSMTP
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential(strMyEmail, strPassword)
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587
            ' Add this for hosting.net smtp...
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            smtp.Send(mm)
        End Using


    End Sub



End Class