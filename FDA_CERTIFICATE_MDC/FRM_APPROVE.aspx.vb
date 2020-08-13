Public Class FRM_APPROVE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao_set As New DAO.CFS.TB_CFS_FOOD_HEAD
        dao_set.GetDataby_TR_ID(TextBox1.Text)
        Dim _P_ID As String = "930001"
        Dim dao_CER_DURG_head As New DAO.CFS.TB_CFS_FOOD_HEAD
        dao_CER_DURG_head.fields.STATUS_ID = 8

        dao_CER_DURG_head.update()
        'alert("อนุมัติเรียบร้อย")
        Dim dao_cer_head As New DAO.CFS.TB_CFS_FOOD_HEAD
        Dim dao_ref_last As New DAO.CFS.TB_CFS_FOOD_HEAD
        Dim rcvno_last1 As Integer = 0
        dao_cer_head.GetDataby_IDA(dao_set.fields.IDA)
        Dim dao_masprocess As New DAO.CFS.TB_PROCESS
        Dim ref_code As String
        Dim type_cer As String = ""
        Dim gen_1 As String = ""
        'Dim bao_regis As New BAO_STOREPROCUDURE.DRUG
        'Dim dt As DataTable
        'dt = bao_regis.SP_GET_DRUG_drrgt_IDA(_CLS.Newcode)
        Dim type_regis As String = ""
        Dim type_regir_gen As String = ""
        'For Each value As DataRow In dt.Rows
        type_regis = 1 'value("type_register")
        'Next
        dao_masprocess.GetDataby_PROCESS_ID(_P_ID)
        If _P_ID = 930001 Then
            type_cer = "03"
            gen_1 = "1"
        ElseIf _P_ID = 930002 Then
            type_cer = "10"
            gen_1 = "2"
        ElseIf _P_ID = 930003 Then
            type_cer = "10"
            gen_1 = "4"
        End If
        If type_regis = "1" Then
            type_regir_gen = "3"
        ElseIf type_regis = "2" Then
            type_regir_gen = "7"
        End If
        Dim str As String = ""
        Dim run_no As String = "00000"
        str = Date.Now.Year.ToString
        dao_ref_last.GetDataby_rcvno_last_type(_P_ID)
        If dao_ref_last.fields.REF_CODE Is Nothing Or dao_ref_last.fields.REF_CODE = "" Then
            rcvno_last1 = "0"
        Else
            rcvno_last1 = dao_ref_last.fields.REF_CODE.ToString.Substring(13)
        End If
        rcvno_last1 = rcvno_last1 + 1
        ref_code = gen_1 & "-" & type_regir_gen & "-" & type_cer & "-04-" & str.Substring(2) & "-" & run_no.Substring(rcvno_last1.ToString.Length) & rcvno_last1
        dao_cer_head.fields.STATUS_ID = 8
        dao_cer_head.fields.APPROVE_DATE = Date.Now

        dao_cer_head.fields.UNTIL_DATE = Convert.ToDateTime(Date.Now).AddYears(2).AddDays(-1)

        dao_cer_head.fields.REF_CODE = ref_code



        dao_cer_head.update()
        alert("อนุมัติเรียบร้อย")


    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
End Class