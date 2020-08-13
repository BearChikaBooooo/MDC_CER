Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports Spire.Doc

Imports Spire.Doc.Documents
Imports iTextSharp.text

Public Class FRM_POPUP_SEARCH
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _P_ID As String
    Private _IDA As String
    Private _TR_ID As String
    Private _TYPE As Integer
    Private _S_GROUP As String
    Private ddl_cnsdcd As Object

    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                Dim id = _CLS.CITIZEN_ID
                _P_ID = Request.QueryString("P_ID")
                _IDA = Request.QueryString("ida")
                _TR_ID = Request.QueryString("tr_id")

            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        Dim dao_cer As New DAO_MDC_CER.TB_MDC_CER
        dao_cer.Getdata_byid(_IDA) 'จะไปเรียกข้อมูลจาก Getdata_byid โดยอ้างอิงจาก IDA คือจะเรียกข้อมูลของIDAนั้นทั้งตารางออกมาใช้งาน
        If Not IsPostBack Then
            BindDDL()
            Set_button_popup()
            BindData_PDF(0)
        End If

    End Sub

    ''' <summary>
    ''' ใช้ในการดึงค่ารายการ ไฟล์แนบจาก ฐานข้อมูล มาแสดง
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub BindDDL()
        'Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_byid(_IDA)

        If dao.fields.STATUS_ID = 2 Then
            int_group_ddl = 1
        ElseIf dao.fields.STATUS_ID = 3 Then
            int_group_ddl = 7
        ElseIf dao.fields.STATUS_ID = 5 Then
            int_group_ddl = 2

        End If


        'If dao.fields.STATUS_ID = 5 Then
        '    drp_status.DataSource = bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        'Else
        drp_status.DataSource = bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl, 0)
        'End If

        'dt = bao.dt
        'drp_status.DataSource = dt
        drp_status.DataValueField = "STATUS_ID"
        drp_status.DataTextField = "STATUS_NAME"
        drp_status.DataBind()
        'hl_scope.NavigateUrl = "../TRADER_EXPORT/FRM_EXPORT_SCOPE.aspx?IDA=" & _IDA & "&chk_sta=" & 1
    End Sub

    Private Sub BindData_PDF(ByVal pdf_type As Integer)
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_byid(_IDA)
        Dim LCNSID As String = _CLS.LCNSID
        Dim BIND_PDF As New BIND_PDF_MDC_CER
        BIND_PDF.MAIN_IDA = _IDA
        BIND_PDF.XML_CITIZEN_ID_AUTHORIZE = LCNSID
        BIND_PDF.process_id = 509000
        If _TYPE = 0 Then
            BIND_PDF.XML_TYPE = 1
        Else
            BIND_PDF.XML_TYPE = _TYPE
        End If

        If dao.fields.STATUS_ID Is Nothing Then
            BIND_PDF.STATUS_ID = 1
        Else
            BIND_PDF.STATUS_ID = dao.fields.STATUS_ID
        End If

        BIND_PDF.Bind_PDF_PRINT2(_IDA, pdf_type)

        If BIND_PDF.XML_PATH_PDF = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ไม่สามารถเปิดเอกสารได้');", True)
        Else
            Literal1.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='..\PDF\PDF_PREVIEW2.aspx?filename=" & BIND_PDF.XML_PATH_PDF & "' ></iframe>"
        End If
    End Sub
    Private Sub Set_button_popup()
        Try

            Dim dao_la As New DAO_MDC_CER.TB_MDC_CER
            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD
            Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")  '

            dao_la.Getdata_byid(_IDA)
            Dim bao As New BAO_SHOW

            Dim bao_register As New BAO_STOREPROCUDURE.FOOD
            Dim dt2 As New DataTable


            If dao_la.fields.condate.Equals(Nothing) Then
                lbl_condate.Text = ""
            Else
                lbl_condate.Text = dao_la.fields.condate
            End If
            lbl_namecom.Text = dao_la.fields.company_name
            lbl_rcvno.Text = dao_la.fields.rcvno
            lbl_datercvno.Text = Format(dao_la.fields.rcvdate, "dd MMMM yyyy")
            lbl_refno.Text = dao_la.fields.TR_ID

            dao_up.Getdata_byid(dao_la.fields.TR_ID)
            Dim bao_person As New BAO_SHOW
            Dim dt_p As DataTable = bao_person.SP_MAINPERSON_CTZNO(dao_up.fields.CITIEZEN_ID)
            For Each value As DataRow In dt_p.Rows
                lbl_nameperson.Text = value("thanm")
            Next
            tr_approve_name.Visible = False
            tr_approve_status.Visible = False

            lbl_status.Visible = False


        Catch ex As Exception
            alert(ex.ToString)
        End Try
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")

    End Sub

    Sub alert_no(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script>parent.close_modal();</script>")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("../STAFF_MAIN_CER/FRM_POPUP_STAFF_CONFRIME_ATTACH.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "")
    End Sub
End Class