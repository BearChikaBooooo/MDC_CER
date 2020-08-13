Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Xml
Public Class WebForm22
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'load_GV_lcnno()
            check_group()
            '    OpenPopupName("../MAIN/FRM_NOTICE.aspx")
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups3('../MAIN/FRM_NOTICE.aspx');", True)
        End If
    End Sub
#Region "GRIDVIEW"
    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim lbl_lcnno As Label = DirectCast(e.Row.FindControl("lbl_lcnno"), Label)
            Dim lbl_lcntype As Label = DirectCast(e.Row.FindControl("lbl_lcntype"), Label)
            Dim btn_lcn As Button = DirectCast(e.Row.FindControl("btn_lcn"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO.clsDBfalcn
            dao.GetDataby_ID(Integer.Parse(str_ID))

            'Dim dao_status As New DAO.TABLE_MAS_STATUS
            'dao_status.GetDataby_STATUS_ID(dao.fields.cnsdcd, 2)

            'lbl_status.Text = dao_status.fields.STATUS_NAME

            If dao.fields.cnsdcd = 8 Then
                btn_lcn.Visible = True
            Else
                btn_lcn.Visible = False

            End If

            Dim dao_falcn As New DAO.clsDBfalcn
            dao_falcn.GetDataby_ID(str_ID)

            'เลขใบอนุญาต
            Dim bao_convert_num As New BAO.convert_num

            'Dim dao_falcnaddr As New DAO.clsDBfalcnaddrs
            'dao_falcnaddr.GetDataby_FK_IDA(dao_falcn.fields.ID)

            Try
                lbl_lcnno.Text = Format_fdpdtno_lcnno(dao.fields.chngwtcd, dao.fields.pvncd, dao_falcn.fields.lcntypecd, dao_falcn.fields.lcnno)
            Catch ex As Exception

            End Try


            'เลขประเภทใบอนุญาต
            lbl_lcntype.Text = bao_convert_num.con_lcntype(str_ID)

        End If




    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand

        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("ID").ToString()
        Dim dao As New DAO.clsDBfalcn
        dao.GetDataby_ID(Integer.Parse(str_ID))
        Dim tr_id As Integer = 0
        'Dim dao_up As New DAO_CPN.clsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_REF_NO(str_ID)

        If e.CommandName = "lcno" Then

            _CLS.LCNNO = dao.fields.lcnno.ToString()
            _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            '_CLS.PVCODE = dao.fields.pvncd.ToString()
            _CLS.LCNTYPE_CD = dao.fields.lcntypecd
            _CLS.IDA = str_ID 'ไอดีหลักของ สถานที่ผลิต
            Session("CLS") = _CLS

            ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            Response.Redirect("../CUSTOM_MAIN_CER/FRM_INDEX_CER.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())



        End If
    End Sub

    Private Function GET_BRANCH() As String

        Dim bao_sp As New BAO.StoreProcudure
        Dim dt_br As New DataTable
        If _CLS.SYSTEM_ID <> "67" Then
            dt_br = bao_sp.SP_FOOD_PERMISSION_BRANCH_DEMO(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)
        Else
            dt_br = bao_sp.SP_FOOD_PERMISSION_BRANCH(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)
        End If

        Dim branch_temp As String = ""
        For Each dr_b As DataRow In dt_br.Rows
            If branch_temp = "" Then
                branch_temp = "'" & dr_b("eight_digit") & "'"
            Else
                branch_temp = branch_temp & "," & "'" & dr_b("eight_digit") & "'"
            End If
        Next
        Return branch_temp
    End Function

    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        'GV_lcnno.PageIndex = e.NewPageIndex
        'load_GV_lcnno()
    End Sub
#End Region


    Protected Sub check_group()
        Dim bao_info As New BAO.information
        If _CLS.Groups = "24300" Then
            Response.Redirect("../STAFF_MAIN_CER/FRM_STAFF_MAIN_CER.aspx")
        Else
            Response.Redirect("../CUSTOM_MAIN_CER/FRM_MAIN_LIST_CER.aspx")
        End If
    End Sub
End Class