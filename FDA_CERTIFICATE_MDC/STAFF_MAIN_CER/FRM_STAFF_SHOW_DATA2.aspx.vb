Public Class FRM_STAFF_SHOW_DATA2
    Inherits System.Web.UI.Page
    Private TR_ID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TR_ID = Request.QueryString("tr_id")
        Dim dao As New DAO_MDC_CER.GET_TB_IRGT
        Dim dao2 As New DAO_MDC_CER.GET_TB_MN
        Dim dao3 As New DAO_MDC_CER.GET_TB_MC
        Dim dao4 As New DAO_MDC_CER.GET_TB_MR
        dao.Getdata_bytrid(TR_ID)
        dao2.Getdata_bytrid(TR_ID)
        dao3.Getdata_bytrid(TR_ID)
        dao4.Getdata_bytrid(TR_ID)

        Label1.Text = dao.fields.rgtno_display
        Label2.Text = dao2.fields.rgtno_display
        Label3.Text = dao3.fields.rgtno_display
        Label4.Text = dao4.fields.rgtno_display
    End Sub

End Class