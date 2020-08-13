Public Class FRM_POPUP_REMARK_STAFF_REQUST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _P_ID As String
    Private _IDA As String
    Private _S_ID As String
    Private _S_GROUP As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _S_GROUP = Request.QueryString("S_GROUP")
                _IDA = Request.QueryString("IDA")
                _S_ID = Request.QueryString("S_ID")
                _P_ID = Request.QueryString("P_ID")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'runQuery()

        If Not IsPostBack Then
            Dim dao_get_status As New DAO.CFS.TABLE_MAS_STATUS
            dao_get_status.GetDataby_STATUS_ID(_S_ID, 48)
            lbl_title.Text = "หมายเหตุ : " & dao_get_status.fields.STATUS_NAME
        End If

    End Sub

    Private Sub btn_confirme_Click(sender As Object, e As EventArgs) Handles btn_confirme.Click
       
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ") 'Response.Show คือคำสั่ง เรียก Alert มาโชว์'
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Redirect("FRM_POPUP_STAFF_CONFRIME.aspx?ida=" & _IDA & "&P_ID=" & _P_ID)
    End Sub
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String)
        Dim mm As New WS_MAIL.FDA_MAIL
        Dim mcontent As New WS_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email

        mm.SendMail(mcontent)
    End Sub
End Class