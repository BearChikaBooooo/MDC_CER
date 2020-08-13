Public Class FRM_POPUP_STRFF_COMMENT_ADMIN
    Inherits System.Web.UI.Page

    Private _IDA As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _IDA = Request.QueryString("IDA")
    End Sub

    Private Sub btn_save_cancel_Click(sender As Object, e As EventArgs) Handles btn_save_cancel.Click
        Dim dao_cfs_head As New DAO.CFS.TB_CFS_FOOD_HEAD
        dao_cfs_head.GetDataby_IDA(_IDA)
        dao_cfs_head.fields.STATUS_ID = 7
        dao_cfs_head.fields.COMMENT_ADMIN = txt_comment_cancel.Text
        dao_cfs_head.update()
        alert("คืนคำขอคำขอสำเร็จ")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class