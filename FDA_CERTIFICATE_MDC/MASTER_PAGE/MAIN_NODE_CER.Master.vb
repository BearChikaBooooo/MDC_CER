Public Class MAIN_NODE_CER
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    'Private _P_ID As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                '_P_ID = Request.QueryString("P_ID")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        show_data_head()
    End Sub
    Private Sub show_data_head()
        'Dim dao_get_type As New DAO.CFS.TB_MAS_STAFF_TYPE
        'dao_get_type.GetDataby_IDA(_CLS.STAFF_TYPE)
        'hl_staff_type.Text = dao_get_type.fieldes.STAFF_NAME


        Dim bao_get_name As New BAO_STOREPROCUDURE.CPN
        Dim dt As DataTable
        dt = bao_get_name.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        For Each Val As DataRow In dt.Rows
            hl_name.Text = Val("thanm_initials")
        Next


        'Dim bao_sum_cer As New BAO_STOREPROCUDURE.CFS
        Dim pro_cfs As Integer = 930001
        Dim pro_COI As Integer = 930002
        Dim pro_COM As Integer = 930003

        Dim sum As DataTable

        'sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV(pro_cfs)
        'For Each value As DataRow In sum.Rows
        '    CFS_value.Value = value("count_cer")
        'Next
        '-------------------------------------------------
        'If _CLS.STAFF_TYPE = 1 Then
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV(pro_cfs, _CLS.CITIZEN_ID)
        '    For Each value As DataRow In sum.Rows
        '        CFS_value.Value = value("count_cer")
        '    Next
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV(pro_COI, _CLS.CITIZEN_ID)
        '    For Each value As DataRow In sum.Rows
        '        COI_value.Value = value("count_cer")
        '    Next
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV(pro_COM, _CLS.CITIZEN_ID)
        '    For Each value As DataRow In sum.Rows
        '        COM_value.Value = value("count_cer")
        '    Next
        'Else
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV_MASTER(pro_cfs)
        '    For Each value As DataRow In sum.Rows
        '        CFS_value.Value = value("count_cer")
        '    Next
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV_MASTER(pro_COI)
        '    For Each value As DataRow In sum.Rows
        '        COI_value.Value = value("count_cer")
        '    Next
        '    sum = bao_sum_cer.SP_GET_FOOD_ALL_RCV_MASTER(pro_COM)
        '    For Each value As DataRow In sum.Rows
        '        COM_value.Value = value("count_cer")
        '    Next

        'End If


    End Sub
End Class