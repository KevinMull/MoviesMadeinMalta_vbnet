
Partial Class controls_Pager
    Inherits System.Web.UI.UserControl

    'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load



    '    If Not Page.IsPostBack() Then
    '        '    intPageSize.Text = "20"
    '        '   intCurrIndex.Text = "0"


    '    End If



    'End Sub


    Public Sub ShowFirst(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = "0"
        ' BindDataList()
    End Sub

    Public Sub ShowPrevious(ByVal s As Object, ByVal e As EventArgs)
        intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) - CInt(intPageSize.Text))
        If CInt(intCurrIndex.Text) < 0 Then
            intCurrIndex.Text = "0"
        End If
        ' BindDataList()
    End Sub

    Public Sub ShowNext(ByVal s As Object, ByVal e As EventArgs)
        If CInt(intCurrIndex.Text) + 1 < CInt(intRecordCount.Text) Then
            intCurrIndex.Text = CStr(CInt(intCurrIndex.Text) + CInt(intPageSize.Text))
        End If
        ' BindDataList()
    End Sub

    Public Sub ShowLast(ByVal s As Object, ByVal e As EventArgs)
        Dim tmpInt As Integer

        tmpInt = CInt(intRecordCount.Text) Mod CInt(intPageSize.Text)
        If tmpInt > 0 Then
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - tmpInt)
        Else
            intCurrIndex.Text = CStr(CInt(intRecordCount.Text) - CInt(intPageSize.Text))
        End If
        ' BindDataList()
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

End Class
