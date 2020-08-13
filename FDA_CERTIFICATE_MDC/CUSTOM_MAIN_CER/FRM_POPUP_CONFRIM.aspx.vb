
Imports System.Threading
Imports System.Globalization
Imports System.Net.Mime.MediaTypeNames
Imports iTextSharp.text

Public Class FRM_POPUP_CONFRIM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As Integer
    Private _TR_ID As String
    Private _TYPE As Integer
    Private _STAFF_APM As Integer = 0

    Dim dao_MDC_CER As New DAO_MDC_CER.TB_MDC_CER

    Private _COUNTRY_KEEP As New List(Of MDC_CER_COUNTRY)
    Public Property COUNTRY_KEEP() As List(Of MDC_CER_COUNTRY)
        Get
            Return _COUNTRY_KEEP
        End Get
        Set(ByVal value As List(Of MDC_CER_COUNTRY))
            _COUNTRY_KEEP = value
        End Set
    End Property


    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _ProcessID = Request.QueryString("process_id")
                _IDA = Request.QueryString("ida")
                _TR_ID = Request.QueryString("tr_id")
                _TYPE = Request.QueryString("type")
                _STAFF_APM = Request.QueryString("STAFF_APM")

            End If


        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            Set_button_popup()
            BindData_PDF(0)
        End If

    End Sub
    Private Sub Set_button_popup()
        Try

            Dim bao As New BAO_STOREPROCUDURE.CPN


            Dim dao_la As New DAO_MDC_CER.TB_MDC_CER
            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD

            Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
            dao_la.Getdata_byid(_IDA)
            lbl_namecom.Text = dao_la.fields.company_name
            lbl_refno.Text = dao_la.fields.TR_ID
            dao_up.Getdata_byid(dao_la.fields.TR_ID)
            Dim bao_person As New BAO_SHOW
            Dim dt_p As DataTable = bao_person.SP_MAINPERSON_CTZNO(dao_up.fields.CITIEZEN_ID)
            For Each value As DataRow In dt_p.Rows
                lbl_nameperson.Text = value("thanm")
            Next
            Dim rcv = dao_la.fields.rcvno
            Dim rcvdate = dao_la.fields.rcvdate

            If dao_la.fields.rcvno.Equals("") And dao_la.fields.rcvdate.Equals(Nothing) Then
                lbl_rcvno.Text = "-"
                lbl_datercvno.Text = "-"
            Else
                lbl_datercvno.Text = dao_la.fields.rcvdate
                lbl_rcvno.Text = dao_la.fields.rcvno
            End If
            txt_remark.Visible = False
            lbl_remark_title.Visible = False
            btn_bill_pay.Visible = False

            Dim url As String = Request.Url.AbsoluteUri.ToUpper
            If dao_la.fields.STATUS_ID = 1 Then
                If url.Contains("LOCALHOST") Then
                    UC_GRID_ATTACH.Visible = True
                    UC_GRID_ATTACH.load_gv(_TR_ID)
                    lbl_datercvno.CssClass = "lbl-save"
                    lbl_rcvno.CssClass = "lbl-save"
                    lbl_refno.CssClass = "lbl-save"
                    lbl_datercvno.Text = "-"
                    lbl_rcvno.Text = "-"
                    lbl_status.Text = "<h3>บันทึกรอส่งเรื่อง<h3></br><h5 style='color:red;':>กรุณาพิมพ์ใบสั่งชำระ<h5>"
                    btn_confirm.Enabled = True
                    btn_confirm.CssClass = "btn-lg"
                    btn_bill_pay.Visible = False
                    lbl_status.Text = "<h3>บันทึกรอส่งเรื่อง<h3>"

                Else
                    UC_GRID_ATTACH.Visible = True
                    UC_GRID_ATTACH.load_gv(_TR_ID)
                    lbl_datercvno.CssClass = "lbl-save"
                    lbl_rcvno.CssClass = "lbl-save"
                    lbl_refno.CssClass = "lbl-save"
                    lbl_datercvno.Text = "-"
                    lbl_rcvno.Text = "-"
                    lbl_status.Text = "<h3>บันทึกรอส่งเรื่อง<h3></br><h5 style='color:red;':>กรุณาพิมพ์ใบสั่งชำระ<h5>"
                    btn_bill_pay.Visible = True
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"

                    If dao_la.fields.STATUS_PAY = 1 Then
                        UC_GRID_ATTACH.Visible = True
                        UC_GRID_ATTACH.load_gv(_TR_ID)
                        btn_confirm.Enabled = True
                        btn_confirm.CssClass = "btn-lg"
                        btn_bill_pay.Visible = False
                        lbl_status.Text = "<h3>บันทึกรอส่งเรื่อง<h3>"
                    End If
                    If dao_up.fields.CITIEZEN_ID <> _CLS.CITIZEN_ID Then
                        UC_GRID_ATTACH.Visible = True
                        UC_GRID_ATTACH.load_gv(_TR_ID)
                        btn_cancel.Enabled = False
                        btn_cancel.CssClass = "btn-lg btn-disable"
                        lbl_refno.CssClass = "lbl-send"
                        lbl_refno.Text = "-"
                    End If
                End If


            ElseIf dao_la.fields.STATUS_ID = 2 Then
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
                btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                lbl_refno.CssClass = "lbl-send"
                lbl_status.Text = "<h3>ส่งเรื่องและรอพิจารณา</h3>"
                btn_bill_pay.Visible = False
            ElseIf dao_la.fields.STATUS_ID = 3 Then
                    lbl_datercvno.CssClass = "lbl-save"
                    lbl_rcvno.CssClass = "lbl-save"
                    lbl_refno.CssClass = "lbl-save"
                    lbl_datercvno.Text = Format(dao_la.fields.rcvdate, "dd MMMM yyyy")
                    lbl_rcvno.Text = dao_la.fields.rcvno
                    lbl_status.Text = "<h3>รับคำขอ</h3>"
                    btn_bill_pay.Visible = False
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"
                lbl_status.Text = "<h3>รับคำขอ</h3>"
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)

                If dao_up.fields.CITIEZEN_ID <> _CLS.CITIZEN_ID Then
                        btn_confirm.Enabled = False
                        btn_confirm.CssClass = "btn-lg btn-disable"
                        btn_cancel.Enabled = False
                        btn_cancel.CssClass = "btn-lg btn-disable"
                        lbl_refno.CssClass = "lbl-send"
                    lbl_refno.Text = "-"
                    UC_GRID_ATTACH.Visible = True
                    UC_GRID_ATTACH.load_gv(_TR_ID)
                End If


                ElseIf dao_la.fields.STATUS_ID = 4 Then
                    lbl_datercvno.CssClass = "lbl-save"
                    lbl_refno.CssClass = "lbl-send"

                    lbl_datercvno.Text = Format(dao_la.fields.rcvdate, "dd MMMM yyyy")
                    lbl_rcvno.Text = dao_la.fields.rcvno
                    lbl_status.Visible = False
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    btn_bill_pay.Visible = False
                lbl_status.Text = "<h3>พิจารณา/จัดกลุ่ม</h3>"
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)

            ElseIf dao_la.fields.STATUS_ID = 5 Then
                    lbl_datercvno.CssClass = "lbl-save"
                    lbl_refno.CssClass = "lbl-send"

                    lbl_datercvno.Text = Format(dao_la.fields.rcvdate, "dd MMMM yyyy")
                    lbl_rcvno.Text = dao_la.fields.rcvno
                    lbl_status.Visible = False
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    btn_bill_pay.Visible = False
                lbl_status.Text = "<h3>เสนอลงนาม</h3>"
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)

            ElseIf dao_la.fields.STATUS_ID = 6 Then
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = " btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    lbl_datercvno.Text = "คืนคำขอ"
                    lbl_rcvno.Text = "คืนคำขอ"
                    lbl_refno.Text = "คืนคำขอ"
                    btn_bill_pay.Visible = False
                    txt_remark.Text = dao_la.fields.REMARK_CANCEL
                    txt_remark.Visible = True
                    lbl_remark_title.Visible = True
                txt_remark.Enabled = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 8 Then
                    lbl_status.Text = "</br><h5 style='color:red;':>สามารถติดต่อรับหนังสือการส่งออกเครื่องมือแพทย์ได้ที่ OSSC<h5>"
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = "btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                btn_bill_pay.Visible = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 7 Then
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = " btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    lbl_datercvno.Text = "ไม่อนุมัติ"
                    lbl_rcvno.Text = "ไม่อนุมัติ"
                    lbl_refno.Text = "ไม่อนุมัติ"
                    btn_bill_pay.Visible = False
                    txt_remark.Text = dao_la.fields.REMARK_CANCEL
                    txt_remark.Visible = True
                    lbl_remark_title.Visible = True
                txt_remark.Enabled = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 9 Then
                    btn_confirm.Enabled = False
                    btn_confirm.CssClass = " btn-lg btn-disable"
                    btn_cancel.Enabled = False
                    btn_cancel.CssClass = "btn-lg btn-disable"
                    lbl_datercvno.Text = "ยกเลิกคำขอ"
                    lbl_rcvno.Text = "ยกเลิกคำขอ"
                    lbl_refno.Text = "ยกเลิกคำขอ"
                btn_bill_pay.Visible = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 10 Then
                    btn_confirm.Enabled = False
                btn_confirm.CssClass = "btn-lg btn-disable"
                btn_cancel.Enabled = False
                btn_cancel.CssClass = "btn-lg btn-disable"
                lbl_datercvno.Text = dao_la.fields.rcvdate
                lbl_rcvno.Text = dao_la.fields.rcvno
                btn_bill_pay.Visible = True
                lbl_status.Text = "<h3>อนุมัติรอชำระเงิน</h3>"
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)

            End If

            'ltl_attach_name.Text = get_tag_attach()
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' ใช้ในการดึงค่ารายการ ไฟล์แนบจาก ฐานข้อมูล มาแสดง
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

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

            'HiddenField1.Value = BIND_PDF.XML_PATH_PDF

            'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & BIND_PDF.XML_PATH_PDF & "' ></iframe>"

        End If

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        dao_MDC_CER.Getdata_byid(_IDA)
        dao_MDC_CER.fields.STATUS_ID = 9
        dao_MDC_CER.update()
        Response.Write("<script type='text/javascript'>window.parent.alert('" + "ยกเลิกคำขอเรียบร้อยแล้ว" + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        'dao_MDC_CER.Getdata_byid(_IDA)
        'dao_MDC_CER.fields.STATUS_ID = 2
        'dao_MDC_CER.update()
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub btn_bill_pay_Click(sender As Object, e As EventArgs) Handles btn_bill_pay.Click
        Dim bao As New BAO.AppSettings
        If BAO._STATUS_DEMO = "1" Then
            Response.Redirect("http://164.115.28.127/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&status_id=1&system=mdc")

        ElseIf BAO._STATUS_DEMO = "0" Then
            Response.Redirect("http://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&status_id=1&system=mdc")

        End If
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        dao_MDC_CER.Getdata_byid(_IDA)
        dao_MDC_CER.fields.STATUS_ID = 2
        dao_MDC_CER.fields.condate = Date.Now
        BAO_COMMON.history_log(_ProcessID, 2, _CLS.CITIZEN_ID, _CLS.thanm, _IDA)
        dao_MDC_CER.update()
        Response.Write("<script type='text/javascript'>window.parent.alert('" + "ยื่นคำขอเรียบร้อยแล้ว" + "');parent.close_modal();</script> ")

    End Sub
    Private Sub alert(ByVal txt)
        Response.Write("<script type='text/javascript'>window.parent.alert('" & txt & "');parent.close_modal();</script> ")
    End Sub

    Protected Sub txt_remark_TextChanged(sender As Object, e As EventArgs) Handles txt_remark.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("../CUSTOM_MAIN_CER/FRM_POPUP_CONFRIM_ATTACH.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "")
    End Sub

    Private Sub btn_check_pay_Click(sender As Object, e As EventArgs) Handles btn_check_pay.Click
        Dim str As String
        Dim ws_chk As New SV_CHECK.SV_CHECK_PAYMENT
        str = ws_chk.CHECK_PAYMENT(txt_check_pay.Text.Trim, _CLS.CITIZEN_ID_AUTHORIZE, 5)
        If str = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            dao.Getdata_byid(_IDA)
            str = ws_chk.CHECK_PAYMENT(txt_check_pay.Text.Trim, _CLS.CITIZEN_ID_AUTHORIZE, 5)
            Dim ws As New WS_GETDATE_WORKING.Service1
            Dim datenumber As Integer
            Dim txt_date As String = Date.Now.ToShortDateString()
            Dim date_result As Date
            datenumber = 249 '250วัน
            ws.GETDATE_WORKING(CDate(txt_date), True, datenumber, True, date_result, True)

            If dao.fields.STATUS_PAY <> "1" Then
                dao.fields.PAYMENT_REF = txt_check_pay.Text.Trim
                dao.fields.STATUS_PAY = "1"
                'ElseIf dao.fields.STATUS_LAW_PAY <> "1" Then
                '    dao.fields.LAW44_REF = txt_check_pay.Text.Trim
                '    dao.fields.STATUS_LAW_PAY = "1"
                '    dao.fields.PAY_LAW_DATE = Date.Now
                '    dao.fields.COMPLETE_DATE = date_result
            End If
            dao.update()
            'alert("บันทึกข้อมูลการชำระเงินเรียบร้อยแล้ว")

            Response.Write("<script type='text/javascript'>window.parent.alert('" + "บันทึกข้อมูลการชำระเงินเรียบร้อยแล้ว" + "');parent.close_modal();</script> ")
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('" + str + "');parent.close_modal();</script> ")
            'alert(str)
        End If
    End Sub

    Function CHECK_TYPE_PDF()
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim Word_Templete As String = bao._PATH_WORD_TEMPLATE & "WORD_TEMPLATE\" 'WORD_TEMPLATE คือชื่อ Floder ที่เราตั้งไว้
        Dim PATH_License As String = Word_Templete & "License.lic" 'ไปเรียก Path ของ License มาใช้อยู่ที่เดียวกันกับ Template ของ Word

        Dim dao As New DAO_MDC_CER.TB_MDC_CER 'ประกาศไว้ใช้เพื่อที่จะเอา dao ไป . field เรียกใช้ field ใน Table ของ MDC_CER ได้ทั้งหมดเลย
        dao.Getdata_byid(_IDA)
        Dim dao_coun As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
        dao_coun.Getdata_byfk_ida(_IDA)
        Dim dao_subtype As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
        dao_subtype.Getdata_byfk_ida(_IDA)
        Dim dao_prod As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
        dao_prod.Getdata_byfk_ida(_IDA)



        Dim dao_lcnno As New DAO_MDC_CER.TB_MDC_CER_LCNNO
        dao_lcnno.Getdata_by_fk_ida(_IDA)

        Dim count_prod As Integer = 0
        Dim CER_TYPE As String = ""
        Dim TEMPLATE_PREVIEW As Integer
        Dim Count As Integer = 0

        Dim TEMPLATE_NAME As String = ""
        Dim Product_Name As String = ""
        Dim Product_List2 As String = ""
        Dim Product_List3 As String = ""
        Dim Product_List4 As String = ""
        Dim Product_List5 As String = ""
        Dim item As Integer = 0
        Dim Count_Product As Integer = 0

        For Each dao_prod.fields In dao_prod.datas 'ตัวนี้จะวนลูปเอาข้อมูลทั้งหมดของ Product ที่ IDA นั้นๆมี อยู่ออกมาโชว์ทั้งหมด
            Count += 1
        Next


        If dao.fields.cer_no = "1" Then
            CER_TYPE = "free_sale\"
            If dao.fields.distributor = "1" Then
                If dao.fields.country = "1" Then 'ระบุประเทศ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST1_DISTRIBUTOR"
                        TEMPLATE_PREVIEW = 2011
                    Else
                        'TEMPLATE_PREVIEW = "DISTRIBUTOR_CERTIFICATE_OF_FREE_SALE1"
                        TEMPLATE_PREVIEW = 2009
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST2_DISTRIBUTOR"
                        TEMPLATE_PREVIEW = 2012
                    Else
                        'TEMPLATE_PREVIEW = "DISTRIBUTOR_CERTIFICATE_OF_FREE_SALE2"
                        TEMPLATE_PREVIEW = 2010
                    End If
                End If
            Else
                Dim a As Boolean = False
                If dao.fields.group_glove_condom = 1 Then
                    a = True
                End If
                If a = True Then
                    If dao.fields.country = "1" Then  'ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                            TEMPLATE_PREVIEW = 2007
                        Else
                            'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                            TEMPLATE_PREVIEW = 2005
                        End If
                    ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                            TEMPLATE_PREVIEW = 2008
                        Else
                            'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                            TEMPLATE_PREVIEW = 2006
                        End If
                    End If
                ElseIf dao.fields.country = "1" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST1"
                        TEMPLATE_PREVIEW = 2003
                    Else
                        'TEMPLATE_PREVIEW = "CERTIFICATE_OF_FREE_SALE1"
                        TEMPLATE_PREVIEW = 2001
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST2"
                        TEMPLATE_PREVIEW = 2004
                    Else
                        'TEMPLATE_PREVIEW = "CERTIFICATE_OF_FREE_SALE2"
                        TEMPLATE_PREVIEW = 2002
                    End If
                End If
            End If

        ElseIf dao.fields.cer_no = "2" Then
            CER_TYPE = "export\"
            If dao.fields.distributor = "1" Then
                If dao.fields.country = "1" Then 'ระบุประเทศ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST1_DISTRIBUTOR"
                        TEMPLATE_PREVIEW = 1011
                    Else
                        'TEMPLATE_PREVIEW = "DISTRIBUTOR_CERTIFICATE_FOR_EXPORTATION1"
                        TEMPLATE_PREVIEW = 1009
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST2_DISTRIBUTOR"
                        TEMPLATE_PREVIEW = 1012
                    Else
                        'TEMPLATE_PREVIEW = "DISTRIBUTOR_CERTIFICATE_FOR_EXPORTATION2"
                        TEMPLATE_PREVIEW = 1010
                    End If
                End If
            Else
                Dim a As Boolean = False
                If dao.fields.group_glove_condom = 1 Then
                    a = True
                End If
                If a = True Then
                    If dao.fields.country = "1" Then  'ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                            TEMPLATE_PREVIEW = 1007
                        Else
                            'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                            TEMPLATE_PREVIEW = 1005
                        End If
                    ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                            TEMPLATE_PREVIEW = 1008
                        Else
                            'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                            TEMPLATE_PREVIEW = 1006
                        End If
                    End If
                ElseIf dao.fields.country = "1" Then  'ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST1"
                        TEMPLATE_PREVIEW = 1003
                    Else
                        'TEMPLATE_PREVIEW = "CERTIFICATE_FOR_EXPORTATION1"
                        TEMPLATE_PREVIEW = 1001
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "ATTACTED_LIST2"
                        TEMPLATE_PREVIEW = 1004
                    Else
                        'TEMPLATE_PREVIEW = "CERTIFICATE_FOR_EXPORTATION2"
                        TEMPLATE_PREVIEW = 1002
                    End If
                End If
            End If
        ElseIf dao.fields.cer_no = "3" Then
            CER_TYPE = "origin\"
            Dim a As Boolean = False
            If dao.fields.group_glove_condom = 1 Then
                a = True
            End If
            If a = True Then
                If dao.fields.country = "1" Then  'ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        TEMPLATE_PREVIEW = 4007
                    Else
                        'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        TEMPLATE_PREVIEW = 4005
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        TEMPLATE_PREVIEW = 4008
                    Else
                        'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        TEMPLATE_PREVIEW = 4006
                    End If
                End If
            ElseIf dao.fields.country = "1" Then  'ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    'TEMPLATE_PREVIEW = "ATTACTED_LIST1"
                    TEMPLATE_PREVIEW = 4003
                Else
                    'TEMPLATE_PREVIEW = "CERTIFICATE_OF_ORIGIN1"
                    TEMPLATE_PREVIEW = 4001
                End If
            ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    'TEMPLATE_PREVIEW = "ATTACTED_LIST2"
                    TEMPLATE_PREVIEW = 4004
                Else
                    'TEMPLATE_PREVIEW = "CERTIFICATE_OF_ORIGIN2"
                    TEMPLATE_PREVIEW = 4002
                End If
            End If
        ElseIf dao.fields.cer_no = "4" Then
            CER_TYPE = "manu\"
            Dim a As Boolean = False
            If dao.fields.group_glove_condom = "1" Then
                a = True
            End If
            If a = True Then
                If dao.fields.country = "1" Then  'ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        TEMPLATE_PREVIEW = 3007
                    Else
                        'TEMPLATE_PREVIEW = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        TEMPLATE_PREVIEW = 3005
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        TEMPLATE_PREVIEW = 3008
                    Else
                        'TEMPLATE_PREVIEW = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        TEMPLATE_PREVIEW = 3006
                    End If
                End If
            ElseIf dao.fields.country = "1" Then  'ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    'TEMPLATE_PREVIEW = "ATTACTED_LIST1"
                    TEMPLATE_PREVIEW = 3003
                Else
                    'TEMPLATE_PREVIEW = "CERTIFICATE_OF_MANUFACTURER1"
                    TEMPLATE_PREVIEW = 3001
                End If
            ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    'TEMPLATE_PREVIEW = "ATTACTED_LIST2"
                    TEMPLATE_PREVIEW = 3004
                Else
                    'TEMPLATE_PREVIEW = "CERTIFICATE_OF_MANUFACTURER2"
                    TEMPLATE_PREVIEW = 3002
                End If
            End If

        End If
        Return TEMPLATE_PREVIEW
    End Function

    Protected Sub Preview_Export_Click(sender As Object, e As EventArgs) Handles Preview_Export.Click
        BindData_PDF(CHECK_TYPE_PDF)
    End Sub

    Protected Sub Preview_Origi_Click(sender As Object, e As EventArgs) Handles Preview_Origi.Click
        BindData_PDF(0)
    End Sub
End Class