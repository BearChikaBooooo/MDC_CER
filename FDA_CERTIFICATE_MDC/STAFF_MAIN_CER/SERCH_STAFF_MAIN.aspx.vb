Imports Telerik.Web.UI
Public Class SERCH_STAFF_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Dim bao As New BAO_MASTER
    'Private _P_ID As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                '_P_ID = Request.QueryString("P_ID")
                Dim id = _CLS.CITIZEN_ID
                _CLS.STAFF_APM = 0
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub

    Protected Sub btn_sreach_Click(sender As Object, e As EventArgs) Handles btn_sreach.Click

        Bind_Search()

    End Sub
    Sub Bind_Search()
        Dim db As New Linq_CER_MDCDataContext
        Try
            If txt_Product.Text <> "" Then

                Dim BAO_SEARCH As New BAO_STOREPROCUDURE.CER
                Dim dataSource As DataTable = BAO_SEARCH.SP_SearchProduct(txt_Product.Text)

                'Dim dataSource = From cer In db.MDC_CERs Join s In db.MDC_CER_PRODUCTs On cer.FK_IDA Equals s.FK_IDA
                '                 Where s.Product_Name.ToString.Contains(txt_Product.Text.ToString)
                '                 Order By s.NO Ascending, cer.IDA Descending
                '                 Select s.IDA, s.Product_Name, cer.producer_name
                RadGrid1.DataSource = dataSource
                RadGrid1.DataBind()

            End If
        Catch ex As Exception
        End Try

    End Sub
    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
    '    If TypeOf e.Item Is GridDataItem Then
    '        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '        Dim items As GridDataItem = e.Item
    '        Dim str As String = "<span style='background-color:yellow;'>" & txt_Product.Text & "</span>"

    '        item("Product_Name").Text.Replace(txt_Product.Text, str)

    '    End If
    'End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'RadGrid1.DataSource = dataSource
        Bind_Search()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Sel" Then
                Dim ida_sel As String = item("IDA").Text
                Dim tr_id As String = item("TR_ID").Text
                Dim _P_ID As String = item("process_id").Text
                Session("CLS") = _CLS

                Dim urls As String = "FRM_POPUP_SEARCH.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id

                'Dim urls As String = "FRM_POPUP_STAFF_CONFRIME.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & urls & "');", True)
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups('FRM_POPUP_SEARCH.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id & "');", True)
                'Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups('FRM_POPUP_STAFF_CONFRIME.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id & "');", True)
                'RadGrid1.Rebind()
            End If
        End If
    End Sub



End Class