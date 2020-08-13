Public Class UC_GRID_ATTACH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub load_gv(ByVal TR_ID As Integer)
        Dim dao As New DAO_MDC_CER.TB_FILE_ATTACH
        dao.GetDATAby_TR_ID_AND_TYPE(TR_ID, 99)
        gv.DataSource = dao.datas
        gv.DataBind()
    End Sub

    Public Sub load_data(ByVal TR_ID As Integer)
        Dim dao As New DAO_MDC_CER.GET_TB_IRGT
        dao.Getdata_byrgtno_display(TR_ID)
        gv.DataSource = dao.datas
        gv.DataBind()
    End Sub
    Public Sub load_gv_explain(ByVal TR_ID As Integer)
        'Dim dao As New DAO_MDC_CER.TB_FILE_ATTACH
        'dao.GetDataby_TR_ID_NO_EXPLAIN(TR_ID)
        'gv.DataSource = dao.datas
        'gv.DataBind()
    End Sub
    Public Sub set_Caption(ByVal Caption As String)
        gv.Caption = Caption
    End Sub
    Protected Sub gv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As HyperLink = DirectCast(e.Row.FindControl("btn_Select"), HyperLink)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = gv.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO_MDC_CER.TB_FILE_ATTACH
            '   Dim bao As New BAO.AppSettings
            dao.GetDATAby_IDA(str_ID)
            btn_Select.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao.fields.NAME_FAKE

        End If
    End Sub


End Class