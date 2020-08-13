Imports Telerik.Web.UI

Public Class FRM_STAFF_MAIN_CER
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Dim bao As New BAO_MASTER
    'Private _P_ID As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                '_P_ID = Request.QueryString("P_ID")
                Dim id = _CLS.CITIZEN_ID
                _CLS.STAFF_APM = 0
            End If


        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        'lbl_tltle_head_table.Text = "แสดงรายการ Certificate ที่ผ่านการอนุมัติแล้ว"
        lbl_text_rcvno.Text = "เลขที่รับ :"
        lbl_text_ref_code.Text = "เลขที่อ้างอิง :"
        If Not IsPostBack Then
            runQuery()
            RadGrid1.Rebind()
            Dim rcvno = txt_rcvno.Text
            Dim ref_code = txt_ref_code.Text
        End If
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Sel" Then
                Dim ida_sel As String = item("IDA").Text
                Dim tr_id As String = item("TR_ID").Text
                Dim _P_ID As String = item("process_id").Text
                Session("CLS") = _CLS

                Dim urls As String = "FRM_POPUP_STAFF_CONFRIME.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & urls & "');", True)

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups('FRM_POPUP_STAFF_CONFRIME.aspx?ida=" & ida_sel & "&P_ID=" & _P_ID & "&TR_ID=" & tr_id & "');", True)
                'RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        runQuery()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_sreach_Click(sender As Object, e As EventArgs) Handles btn_sreach.Click
        Dim bao As New BAO_MASTER

        Dim db As New Linq_CER_MDCDataContext
        Try
            If txt_namecom.Text.Length > 0 And txt_rcvno.Text.Length > 0 And txt_ref_code.Text.Length > 0 Then
                Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                 Where cer.TR_ID.ToString.Contains(txt_ref_code.Text.ToString) And
                                     cer.rcvno.ToString.Contains(txt_rcvno.Text) And
                                     cer.company_name.ToString.Contains(txt_namecom.Text.ToString) And
                                     s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                 Order By s.rid Ascending, cer.IDA Descending
                                 Select cer.IDA, cer.rcvno,
                                 cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                 cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                 cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                RadGrid1.DataSource = dataSource
            Else
                If txt_rcvno.Text.Length > 0 And txt_ref_code.Text.Length > 0 Then
                    Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                     Where cer.TR_ID.ToString.Contains(txt_ref_code.Text.ToString) And
                                         cer.rcvno.ToString.Contains(txt_rcvno.Text) And s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                     Order By s.rid Ascending, cer.IDA Descending
                                     Select cer.IDA, cer.rcvno,
                                     cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                     cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                     cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                    RadGrid1.DataSource = dataSource
                ElseIf txt_namecom.Text.Length > 0 And txt_ref_code.Text.Length > 0 Then
                    Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                     Where cer.TR_ID.ToString.Contains(txt_ref_code.Text.ToString) And
                                         cer.company_name.ToString.Contains(txt_namecom.Text) And
                                         s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                     Order By s.rid Ascending, cer.IDA Descending
                                     Select cer.IDA, cer.rcvno,
                                     cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                     cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                     cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                    RadGrid1.DataSource = dataSource
                ElseIf txt_namecom.Text.Length > 0 And txt_rcvno.Text.Length > 0 Then
                    Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                     Where cer.company_name.ToString.Contains(txt_namecom.Text.ToString) And
                                     cer.rcvno.ToString.Contains(txt_rcvno.Text) And s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                     Order By s.rid Ascending, cer.IDA Descending
                                     Select cer.IDA, cer.rcvno,
                                     cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                     cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                     cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                    RadGrid1.DataSource = dataSource
                Else
                    If txt_rcvno.Text.Length > 0 Then
                        Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                         Where cer.rcvno.ToString.Contains(txt_rcvno.Text) And s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                         Order By s.rid Ascending, cer.IDA Descending
                                         Select cer.IDA, cer.rcvno,
                                         cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                         cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                         cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                        RadGrid1.DataSource = dataSource
                    ElseIf txt_ref_code.Text.Length > 0 Then
                        Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                         Where cer.TR_ID.ToString.Contains(txt_ref_code.Text.ToString) And s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                         Order By s.rid Ascending, cer.IDA Descending
                                         Select cer.IDA, cer.rcvno,
                                         cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                         cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                         cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                        RadGrid1.DataSource = dataSource
                    ElseIf txt_namecom.Text.Length > 0 Then
                        Dim dataSource = From cer In db.MDC_CERs Join s In db.MAS_STATUS On cer.STATUS_ID Equals s.STATUS_ID
                                         Where cer.company_name.ToString.Contains(txt_namecom.Text.ToString) And s.STATUS_GROUP = 1 And cer.STATUS_PAY = 1
                                         Order By s.rid Ascending, cer.IDA Descending
                                         Select cer.IDA, cer.rcvno,
                                         cer.rcvdate, cer.expdate, cer.cer_type, cer.for_type, cer.TR_ID,
                                         cer.country, cer.CITIZEN_ID, cer.CITIZEN_ID_UPLOAD,
                                         cer.lcnsid, cer.XMLNAME, cer.company_name, s.STATUS_NAME
                        RadGrid1.DataSource = dataSource
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        RadGrid1.DataBind()


    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'RadGrid1.DataSource = dataSource
        RadGrid1.DataSource = bao.SP_MDC_CER_SHOW_STAFF()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound

        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

                Dim item As GridDataItem
                item = e.Item
                Dim IDA As Integer = item("IDA").Text
                Dim TR_ID As String = item("TR_ID").Text
            Dim STATUS As String = item("STATUS_ID").Text
            Dim pay As CheckBox = e.Item.FindControl("status_pay")
                Dim dao As New DAO_MDC_CER.TB_MDC_CER
                dao.Getdata_byid(IDA)
            If dao.fields.STATUS_PAY = 1 Then
                pay.Checked = True
            End If
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("./SERCH_STAFF_MAIN.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("./CHECK_LIST10.aspx")
    End Sub
End Class