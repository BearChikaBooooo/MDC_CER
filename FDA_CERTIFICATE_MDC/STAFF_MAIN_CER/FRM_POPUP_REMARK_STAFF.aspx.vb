Public Class FRM_POPUP_REMARK_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private IDA As Integer
    Private remark As String
    Private _STATUSID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IDA = Request.QueryString("IDA")
        remark = Request.QueryString("REMARK")
        _STATUSID = Request.QueryString("STATUS")
        If _STATUSID.Equals(6) Then
            lbl_title.Text = "คืนคำขอ"
        ElseIf _STATUSID.Equals(7) Then
            lbl_title.Text = "ไม่อนุมัติ"
        End If

        If Not IsPostBack Then
            txt_remark.Text = remark
        End If
    End Sub

    Private Sub btn_confirme_Click(sender As Object, e As EventArgs) Handles btn_confirme.Click
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_byid(IDA)
        dao.fields.STATUS_ID = _STATUSID
        dao.fields.REMARK = txt_remark.Text
        dao.fields.REMARK_CANCEL = txt_remark.Text
        dao.update()
        alert("บันทึกข้อมูลเรียบร้อยแล้ว")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub

End Class