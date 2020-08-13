Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports Ionic.Zip
Imports System.Collections.Generic
Imports Spire.Doc
Imports Spire.Doc.Documents
Imports iTextSharp.text




Public Class FRM_POPUP_STAFF_CONFRIME
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _P_ID As String
    Private _IDA As String
    Private _TR_ID As String
    Private _TYPE As Integer
    Private _S_GROUP As String
    Private ddl_cnsdcd As Object

    Public Sub CALL_SMS(ByVal tel As String, ByVal msg As String)
        Dim ws_f As New FDA_SMS.FDA_SMS
        ws_f.SEND_SMS(tel, msg)

    End Sub
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
            btn_export.Enabled = False
            Panel2.Visible = False
            lbl_status.Visible = False
            btn_export.CssClass = "btn-lg btn-disable"

            If dao_la.fields.STATUS_ID = 1 Then
                lbl_datercvno.CssClass = "lbl-save"
                lbl_rcvno.CssClass = "lbl-save"
                lbl_refno.CssClass = "lbl-save"
                lbl_datercvno.Text = "-"
                lbl_rcvno.Text = "-"
                lbl_refno.Text = dao_la.fields.TR_ID

            ElseIf dao_la.fields.STATUS_ID = 2 Then
                lbl_refno.CssClass = "lbl-send"
                lbl_refno.Text = dao_la.fields.TR_ID
                tr_approve_name.Visible = False
                tr_approve_status.Visible = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 3 Then
                lbl_refno.CssClass = "lbl-send"
                lbl_refno.Text = dao_la.fields.TR_ID
                tr_approve_name.Visible = True
                tr_approve_status.Visible = True
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)

            ElseIf dao_la.fields.STATUS_ID = 5 Then
                lbl_refno.CssClass = "lbl-send"
                lbl_refno.Text = dao_la.fields.TR_ID
                btn_export.Enabled = True
                btn_export.CssClass = "btn-lg"
                Panel2.Visible = True
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 8 Then
                btn_confirm.Enabled = False
                btn_confirm.CssClass = "btn-lg btn-disable"
                lbl_status.Text = "อนุมัติ"
                lbl_status.Visible = True
                drp_status.Visible = False
                btn_export.Enabled = True
                btn_export.CssClass = "btn-lg"
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 10 Then
                lbl_status.Visible = True
                lbl_status.Text = "อนุมัติรอชำระเงิน"
                drp_status.Visible = False
                btn_confirm.Enabled = False
                btn_confirm.CssClass = "btn-lg btn-disable"
                btn_export.Enabled = True
                btn_export.CssClass = "btn-lg"
                tr_remark.Visible = False
                UC_GRID_ATTACH.Visible = True
                UC_GRID_ATTACH.load_gv(_TR_ID)
            ElseIf dao_la.fields.STATUS_ID = 6 Then
                btn_confirm.Enabled = False
                btn_confirm.CssClass = " btn-lg btn-disable"
                txt_remark.Text = dao_la.fields.REMARK
                lbl_datercvno.Text = "คืนคำขอ"
                lbl_rcvno.Text = "คืนคำขอ"
                lbl_refno.Text = "คืนคำขอ"
            ElseIf dao_la.fields.STATUS_ID = 7 Then
                btn_confirm.Enabled = False
                btn_confirm.CssClass = " btn-lg btn-disable"
                txt_remark.Text = dao_la.fields.REMARK
                lbl_datercvno.Text = "ไม่อนุมัติคำขอ"
                lbl_rcvno.Text = "ไม่อนุมัติคำขอ"
                lbl_refno.Text = "ไม่อนุมัติคำขอ"
            ElseIf dao_la.fields.STATUS_ID = 9 Then
                btn_confirm.Enabled = False
                btn_confirm.CssClass = " btn-lg btn-disable"
                lbl_datercvno.Text = "ยกเลิกคำขอ"
                lbl_rcvno.Text = "ยกเลิกคำขอ"
                lbl_refno.Text = "ยกเลิกคำขอ"
            End If

        Catch ex As Exception
            alert(ex.ToString)
        End Try
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

    Private Sub BindData_PDF2(ByVal pdf_type As Integer)
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
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")

    End Sub

    Sub alert_no(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim check = True
        Dim statusID As Integer = drp_status.SelectedValue
        Dim bao As New BAO.GenNumber
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        Dim gen_no As New BAO.gen_no
        dao.Getdata_byid(_IDA)
        Dim dao_citizen As New DAO_CPN.clsDBsyslcnsnm
        dao_citizen.GetDataby_identify(_CLS.CITIZEN_ID)
        Dim dao_ch As New DAO_CPN.clsDBsyschngwt
        dao_ch.GetData_by_chngwtcd(_CLS.pvncd)
        Dim dao_smail As New DAO_CPN.TB_sysemail
        Dim dao_saddr As New DAO_CPN.clsDBsyslctaddr
        Dim dao_irgt As New DAO_MDC_CER.GET_TB_IRGT
        dao_irgt.Getdata_byida(_IDA)
        dao_saddr.GetDataby_identify(dao.fields.CITIZEN_ID_UPLOAD)
        dao_smail.GetDataby_IDEN(dao.fields.CITIZEN_ID_UPLOAD)
        'statusID = dao.fields.STATUS_ID

        If statusID = "3" Then
            Try

                Dim ws As New WS_GETDATE_WORKING.Service1
                Dim txt_date As String = Date.Now.ToShortDateString()
                Dim rcvno As String = bao.GEN_RCVNO_NO01(con_year(), _CLS.PVCODE, dao.fields.process_id, _IDA, dao.fields.rgttpcd)

                dao.fields.STATUS_ID = drp_status.SelectedValue
                dao.fields.rcvno = rcvno
                dao.fields.RCVNO_DISPLAY = "CE" & rcvno
                dao.fields.rcvdate = Date.Now
                'dao.fields.expdate = dao.fields.rcvdate.Value.Year + 2 & "/12/" & dao.fields.rcvdate.Value.Day - 1
                Dim expdate As Date = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2)
                'If expdate.Month = 1 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(11)
                'ElseIf expdate.Month = 2 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(10)
                'ElseIf expdate.Month = 3 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(9)
                'ElseIf expdate.Month = 4 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(8)
                'ElseIf expdate.Month = 5 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(7)
                'ElseIf expdate.Month = 6 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(6)
                'ElseIf expdate.Month = 7 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(5)
                'ElseIf expdate.Month = 8 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(4)
                'ElseIf expdate.Month = 9 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(3)
                'ElseIf expdate.Month = 10 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(2)
                'ElseIf expdate.Month = 11 Then
                '    expdate = dao.fields.rcvdate.Value.AddDays(-1).AddYears(2).AddMonths(1)
                'End If
                dao.fields.expdate = expdate
                'dao.fields.expdate = 
                dao.fields.REMARK = txt_remark.Text

                dao.fields.ADMIN_RCVNM = dao_citizen.fields.prefixnm & dao_citizen.fields.thanm & " " & dao_citizen.fields.thalnm
                dao.fields.ADMIN_RCVCITIZEN = _CLS.CITIZEN_ID

                If dao_smail.fields.MOBILE <> "" Then
                    CALL_SMS(dao_smail.fields.MOBILE, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : เจ้าหน้าที่รับคำขอเรียบร้อยแล้ว โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.0-2590-7148")

                Else
                    CALL_SMS(dao_saddr.fields.Mobile, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : เจ้าหน้าที่รับคำขอเรียบร้อยแล้ว โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.  0-2590-7148")

                End If
            Catch ex As Exception
                check = False
            End Try
            If check = True Then
                BAO_COMMON.history_log(_P_ID, drp_status.SelectedValue, _CLS.CITIZEN_ID, _CLS.thanm, _IDA)
                dao.update()

                alert("ทำการบันทึกข้อมูลเรียบร้อยแล้ว")
            Else
                alert("ข้อมูลผิดพลาด")
            End If

        ElseIf statusID = "5" Then
            Try
                Dim lcnno As String
                dao.fields.CONSIDER_DATE = Date.Now
                Dim year = dao.fields.CONSIDER_DATE.Value.Year.ToString
                dao.fields.STATUS_ID = 5
                'dao.fields.ACADEMIC_STAFF = dao_citizen.fields.prefixnm & dao_citizen.fields.thanm & " " & dao_citizen.fields.thalnm
                Dim dao_lcnno2 As New DAO_MDC_CER.TB_MDC_CER_LCNNO
                dao_lcnno2.Getdata_by_fk_ida(_IDA)
                Dim dao_cty As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
                dao_cty.Getdata_byfk_ida(_IDA)
                If dao_lcnno2.fields.IDA = 0 Then
                    If dao.fields.country = 2 Then
                        For i = 1 To dao.fields.export_amount
                            lcnno = bao.GEN_LCNNO(CONVERT_THAI_YEAR(dao.fields.rcvdate.Value.Year), 10, dao.fields.cer_no, dao.fields.process_id, _IDA)
                            Dim dao_lcnno As New DAO_MDC_CER.TB_MDC_CER_LCNNO
                            dao_lcnno.fields.lcnno = "0" & lcnno
                            dao_lcnno.fields.lcnno_display = dao.fields.rgttype & " " & gen_no.FORMAT_NUMBER_MINI_YEAR_FULL(con_year(), lcnno - 1000)
                            If dao.fields.cer_no.Equals(1) Then
                                dao_lcnno.fields.lcnno_display_num = "1-1-03-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                            ElseIf dao.fields.cer_no.Equals(2) Then
                                dao_lcnno.fields.lcnno_display_num = "1-1-07-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                            ElseIf dao.fields.cer_no.Equals(3) Then
                                dao_lcnno.fields.lcnno_display_num = "1-1-08-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                            ElseIf dao.fields.cer_no.Equals(4) Then
                                dao_lcnno.fields.lcnno_display_num = "1-1-02-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                            End If
                            dao_lcnno.fields.FK_IDA = _IDA
                            dao_lcnno.fields.TYPE = 1
                            dao_lcnno.insert()
                        Next
                    End If
                    If dao.fields.country = 1 Then
                        For Each dao_cty.fields In dao_cty.datas
                            For i = 1 To dao_cty.fields.export_amount
                                lcnno = bao.GEN_LCNNO(CONVERT_THAI_YEAR(dao.fields.rcvdate.Value.Year), 10, dao.fields.cer_no, dao.fields.process_id, _IDA)
                                Dim dao_lcnno As New DAO_MDC_CER.TB_MDC_CER_LCNNO
                                dao_lcnno.fields.lcnno = "0" & lcnno
                                dao_lcnno.fields.lcnno_display = dao.fields.rgttype & " " & gen_no.FORMAT_NUMBER_MINI_YEAR_FULL(con_year(), lcnno - 1000)
                                If dao.fields.cer_no.Equals(1) Then
                                    dao_lcnno.fields.lcnno_display_num = "1-1-03-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                                ElseIf dao.fields.cer_no.Equals(2) Then
                                    dao_lcnno.fields.lcnno_display_num = "1-1-07-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                                ElseIf dao.fields.cer_no.Equals(3) Then
                                    dao_lcnno.fields.lcnno_display_num = "1-1-08-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                                ElseIf dao.fields.cer_no.Equals(4) Then
                                    dao_lcnno.fields.lcnno_display_num = "1-1-02-02-" & year.Substring(2, 2) & "-" & dao_lcnno.fields.lcnno
                                End If
                                dao_lcnno.fields.FK_IDA = _IDA
                                dao_lcnno.fields.TYPE = 2
                                dao_lcnno.fields.country_name = dao_cty.fields.country_name
                                dao_lcnno.insert()
                            Next
                        Next
                    End If
                End If
                dao.fields.lcnno = dao.fields.rcvno
                dao.fields.lcnno_display = dao.fields.RCVNO_DISPLAY
                dao.fields.ACADEMIC_STAFF = drp_staff_approve.SelectedItem.Text
                dao.fields.ACADEMIC_POSITION = drp_staff_status.SelectedItem.Text
                dao.fields.ACADEMIC_POSITION_ID = drp_staff_status.SelectedItem.Value


            Catch ex As Exception
                check = False
            End Try
            If check = True Then
                dao.update()
                BAO_COMMON.history_log(_P_ID, drp_status.SelectedValue, _CLS.CITIZEN_ID, _CLS.thanm, _IDA)
                alert("บันทึกข้อมูลเรียบร้อย")
            Else
                alert("ข้อมูลผิดพลาด")
            End If
        ElseIf statusID = "10" Then
            Try
                Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH
                dao.fields.STATUS_ID = drp_status.SelectedValue
                dao.fields.appvdate = Date.Now
                dao.fields.REMARK = txt_remark.Text
                If dao.fields.fappvdate.Equals(Nothing) Then
                    dao.fields.fappvdate = Date.Now
                End If
                dao.fields.appv_name = dao_citizen.fields.prefixnm & dao_citizen.fields.thanm & " " & dao_citizen.fields.thalnm
                'dao.fields.appv_position = drp_staff_status.SelectedItem.Text
                dao.fields.STATUS_PAYAPPV = 0
                Dim ext As String = GetExtension(FileUpload1.FileName)
                If FileUpload1.HasFile Then
                    If ext.Equals("pdf") Then
                        Dim cer_path = "MDC_CER" & "-" & "509000" & "-" & "0" & "-" & con_year() & "-" & _TR_ID & ".pdf"
                        Dim extension = GetExtension(FileUpload1.FileName)
                        FileUpload1.SaveAs(_PATH_FILE + "UPLOAD/" + cer_path)
                        dao.fields.cer_path = cer_path
                        dao_file.fields.NAME_FAKE = cer_path
                        dao_file.fields.NAME_REAL = FileUpload1.FileName
                        dao_file.fields.CREATE_DATE = Date.Now
                        dao_file.fields.Description = "PDF Certificate Export"
                        dao_file.fields.EXTENSION = extension
                        dao_file.fields.PATH = "upload"
                        dao_file.fields.UPDATE_DATE = Date.Now
                        dao_file.fields.TYPE = 1
                        dao_file.fields.LCNTPCD = 509000
                        dao_file.fields.TR_ID = _TR_ID
                        dao_file.fields.EXPLAIN = 0
                        dao_file.insert()
                    Else
                        alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
                        check = False
                        Exit Sub
                    End If
                Else
                    dao.fields.cer_path = ""
                End If

            Catch ex As Exception
                check = False
            End Try
            If check = True Then
                dao.update()
                BAO_COMMON.history_log(_P_ID, drp_status.SelectedValue, _CLS.CITIZEN_ID, _CLS.thanm, _IDA)
                alert("ทำการบันทึกข้อมูลเรียบร้อยแล้วเลขใบอนุญาต" & gen_no.FORMAT_NUMBER_MINI_YEAR_FULL(con_year(), dao.fields.lcnno))
            Else
                alert("ข้อมูลผิดพลาด")
            End If

            If dao_smail.fields.MOBILE <> "" Then
                CALL_SMS(dao_smail.fields.MOBILE, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : อนุมัติรอชำระเงิน โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.0-2590-7148")

            Else
                CALL_SMS(dao_saddr.fields.Mobile, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : อนุมัติรอชำระเงิน โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.  0-2590-7148")

            End If
        ElseIf statusID = "7" Then
            Response.Redirect("../STAFF_MAIN_CER/FRM_POPUP_REMARK_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&REMARK=" & txt_remark.Text & "&STATUS=" & statusID & "")
        ElseIf statusID = "6" Then
            Response.Redirect("../STAFF_MAIN_CER/FRM_POPUP_REMARK_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&REMARK=" & txt_remark.Text & "&STATUS=" & statusID & "")

            If dao_smail.fields.MOBILE <> "" Then
                CALL_SMS(dao_smail.fields.MOBILE, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : คืนคำขอ โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.0-2590-7148")

            Else
                CALL_SMS(dao_saddr.fields.Mobile, "แจ้งสถานะการติดต่อ ผ่านระบบ SKYNET หน่วยงานที่ติดต่อ (กองควบคุมเครื่องมือแพทย์) กระบวนงาน : หนังสือรับรองการส่งออกเครื่องมือแพทย์ รหัสอ้างอิง  :" & dao.fields.TR_ID & "สถานะ  : คืนคำขอ โปรดตรวจสอบในระบบ อีกครั้ง หากท่านมีข้อสงสัยเพิ่มเติมกรุณาติดต่อเจ้าหน้าที่  โทร.0-2590-7148")

            End If
        End If


    End Sub

    'Function Send_SMS()
    '    Dim ws_sms As New FDA_SMS.FDA_SMS
    '    Dim msg As String = "เจ้าหน้าที่ได้รับเรื่องรายการเรียบร้อยแล้ว"
    '    ws_sms.SEND_SMS(moblie, msg)
    'End Function

    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String)
        Dim mm As New WS_MAIL.FDA_MAIL
        Dim mcontent As New WS_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email

        mm.SendMail(mcontent)
    End Sub


    Private Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script>parent.close_modal();</script>")
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../STAFF_MAIN_CER/DOWNLOAD.aspx?IDA=" & _IDA & "&filename=1" & "'); ", True)
        'Dim stopwatch As Stopwatch = Stopwatch.StartNew
        'Thread.Sleep(5000)
        'stopwatch.Stop()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../STAFF_MAIN_CER/DOWNLOAD.aspx?IDA=" & _IDA & "&filename=2" & "'); ", True)
        'DOWNLOAD_WORD()

        'DOWNLOAD_WORD()
        Using zip As New ZipFile()
            zip.AlternateEncodingUsage = ZipOption.AsNecessary
            zip.AddDirectoryByName("Files")
            Dim dao As New DAO_MDC_CER.TB_MDC_CER 'ประกาศไว้ใช้เพื่อที่จะเอา dao ไป . field เรียกใช้ field ใน Table ของ MDC_CER ได้ทั้งหมดเลย
            dao.Getdata_byid(_IDA)
            Dim DAO_REF_CER As New DAO_MDC_CER.TB_MDC_CER_LCNNO
            DAO_REF_CER.Getdata_by_fk_ida(_IDA)


            If dao.fields.country = "1" Then  'ระบุ
                Dim dao_coun As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
                dao_coun.Getdata_byfk_ida(_IDA)
                For Each dao_coun.fields In dao_coun.datas
                    'For Count_Amount As Integer = 1 To dao_coun.fields.export_amount
                    For Each DAO_REF_CER.fields In DAO_REF_CER.datas
                        If dao_coun.fields.country_name = DAO_REF_CER.fields.country_name Then
                            Dim z As String = ""
                            z = DOWNLOAD_WORD2(dao_coun.fields.country_name & ".", DAO_REF_CER.fields.lcnno_display_num, DAO_REF_CER.fields.lcnno_display_num)
                            zip.AddFile(z, "File")
                        End If
                    Next

                    'Next
                Next
            ElseIf dao.fields.country = "2" Then  'ไม่ระบุ
                For Count_Amount As Integer = 1 To 1
                    For Each DAO_REF_CER.fields In DAO_REF_CER.datas
                        Dim z As String = ""
                        z = DOWNLOAD_WORD2("", DAO_REF_CER.fields.lcnno_display_num, DAO_REF_CER.fields.lcnno_display_num)
                        zip.AddFile(z, "File")
                    Next
                Next
            End If

        Response.Clear()
            Response.BufferOutput = False
            Dim zipName As String = [String].Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"))
            Response.ContentType = "application/zip"
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName)
            zip.Save(Response.OutputStream)
            Response.End()
        End Using

    End Sub

    Function DOWNLOAD_WORD2(ByVal country_name As String, ByVal Count_Number As String, ByVal Ref_Cer As String)

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim cls As New Utility_Aspose.CLS_ASPOSE_WORD 'Class นี้ไปเอามาจากของป๊อก
        Dim Word_Templete As String = bao._PATH_WORD_TEMPLATE & "WORD_TEMPLATE\" 'WORD_TEMPLATE คือชื่อ Floder ที่เราตั้งไว้
        Dim PATH_License As String = Word_Templete & "License.lic" 'ไปเรียก Path ของ License มาใช้อยู่ที่เดียวกันกับ Template ของ Word
        Dim namefile As String = "" 'ประกาศไว้เพื่อที่จะไปตั้งชื่อ File ของ Word ที่เราจะ Export ออกมา

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
        Dim TEMPLATE_NAME As String = ""
        Dim Country_List As String = country_name
        Dim Product_Name As String = ""
        Dim Product_List2 As String = ""
        Dim Product_List3 As String = ""
        Dim Product_List4 As String = ""
        Dim Product_List5 As String = ""
        Dim item As Integer = 0
        Dim Count As Integer = 0
        Dim Count_Product As Integer = 0


        '===================================================  ตรงนี้รายการมีการโชว์ตัวเลขรายการออกมา ============================================'
        'For Each คือการวนลูปทั้งหมดที่มีอยู่ในที่นั้นๆ

        For Each dao_prod.fields In dao_prod.datas 'ตัวนี้จะวนลูปเอาข้อมูลทั้งหมดของ Product ที่ IDA นั้นๆมี อยู่ออกมาโชว์ทั้งหมด
            Count += 1
            'Product_List3 += Count & ".) " & dao_prod.fields.Product_Name & vbCrLf & vbTab & dao_prod.fields.Product_Detail & vbCrLf
            Product_List3 += dao_prod.fields.Product_Name & vbCrLf & vbTab & dao_prod.fields.Product_Detail & vbCrLf
            Product_List2 += dao_prod.fields.Product_Name & vbCrLf & vbTab & dao_prod.fields.Product_Detail & vbCrLf

        Next

        'For Each dao_coun.fields In dao_coun.datas 'ตัวนี้จะวนลูปเอาข้อมูลทั้งหมดของ Country ที่ IDA นั้นๆมี อยู่ออกมาโชว์ทั้งหมด
        '    Country_List += dao_coun.fields.country_name & "."
        'Next


        If dao.fields.cer_no = "1" Then
            CER_TYPE = "free_sale\"
            If dao.fields.distributor = "1" Then
                If dao.fields.country = "1" Then 'ระบุประเทศ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST1_DISTRIBUTOR"
                    Else
                        TEMPLATE_NAME = "DISTRIBUTOR_CERTIFICATE_OF_FREE_SALE1"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST2_DISTRIBUTOR"
                    Else
                        TEMPLATE_NAME = "DISTRIBUTOR_CERTIFICATE_OF_FREE_SALE2"
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
                            TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        Else
                            TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        End If
                    ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        Else
                            TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        End If
                    End If
                ElseIf dao.fields.country = "1" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST1"
                    Else
                        TEMPLATE_NAME = "CERTIFICATE_OF_FREE_SALE1"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST2"
                    Else
                        TEMPLATE_NAME = "CERTIFICATE_OF_FREE_SALE2"
                    End If
                End If
            End If

        ElseIf dao.fields.cer_no = "2" Then
            CER_TYPE = "export\"
            If dao.fields.distributor = "1" Then
                If dao.fields.country = "1" Then 'ระบุประเทศ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST1_DISTRIBUTOR"
                    Else
                        TEMPLATE_NAME = "DISTRIBUTOR_CERTIFICATE_FOR_EXPORTATION1"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST2_DISTRIBUTOR"
                    Else
                        TEMPLATE_NAME = "DISTRIBUTOR_CERTIFICATE_FOR_EXPORTATION2"
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
                            TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        Else
                            TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        End If
                    ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                        If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                            TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                        Else
                            TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                        End If
                    End If
                ElseIf dao.fields.country = "1" Then  'ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST1"
                    Else
                        TEMPLATE_NAME = "CERTIFICATE_FOR_EXPORTATION1"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "ATTACTED_LIST2"
                    Else
                        TEMPLATE_NAME = "CERTIFICATE_FOR_EXPORTATION2"
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
                        TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                    Else
                        TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                    Else
                        TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                    End If
                End If
            ElseIf dao.fields.country = "1" Then  'ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    TEMPLATE_NAME = "ATTACTED_LIST1"
                Else
                    TEMPLATE_NAME = "CERTIFICATE_OF_ORIGIN1"
                End If
            ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    TEMPLATE_NAME = "ATTACTED_LIST2"
                Else
                    TEMPLATE_NAME = "CERTIFICATE_OF_ORIGIN2"
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
                        TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                    Else
                        TEMPLATE_NAME = "IDENTIFY_SURGICAL_GLOVE_CONDOM"
                    End If
                ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                    If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                        TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM_ATTACHED"
                    Else
                        TEMPLATE_NAME = "NO_IDENTIFY_SURGICAL_GLOVE_CONDOM"
                    End If
                End If
            ElseIf dao.fields.country = "1" Then  'ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    TEMPLATE_NAME = "ATTACTED_LIST1"
                Else
                    TEMPLATE_NAME = "CERTIFICATE_OF_MANUFACTURER1"
                End If
            ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    TEMPLATE_NAME = "ATTACTED_LIST2"
                Else
                    TEMPLATE_NAME = "CERTIFICATE_OF_MANUFACTURER2"
                End If
            End If
        End If
        cls.setLicense(PATH_License)
        Dim PATH_WORD_TEM As String = Word_Templete & CER_TYPE




        Dim Position_Set As String = dao.fields.ACADEMIC_POSITION.Replace("Pharmacist, Professional Level ", "Pharmacist, Professional Level " & vbCrLf)
        Position_Set = Position_Set.Replace("Pharmacist, Senoir Professional Level ", "Pharmacist, Senoir Professional Level " & vbCrLf)
        Position_Set = Position_Set.Replace("Person designated by the Secretary-General", "Person designated by the Secretary-General" & vbCrLf)
        Position_Set = Position_Set.Replace("Director of Medical Device Control Division", "Director of Medical Device Control Division" & vbCrLf)
        Position_Set = Position_Set.Replace("Senior Pharmacist Acting Director of Medical Device", "Senior Pharmacist Acting Director of Medical Device" & vbCrLf)
        Position_Set = Position_Set.Replace("Control Division For Secretary-General", "Control Division For Secretary-General" & vbCrLf)


        Dim Position_Set2 As String = dao.fields.producer_name.Replace("Road,", "Road," & vbCrLf)
        Position_Set2 = Position_Set2.Replace("RD.,", "RD.," & vbCrLf)
        Position_Set2 = Position_Set2.Replace("Rd.,", "Rd.," & vbCrLf)

        cls.docConnect(PATH_WORD_TEM & TEMPLATE_NAME & ".doc")

        If Country_List = "" Then
            namefile = dao.fields.recipient & Count_Number & ".docx"
        Else
            namefile = Country_List & Count_Number & ".docx"
        End If
        'namefile = "Name-" & CStr(Date.UtcNow.Millisecond) & ".docx"

        Dim Path As String = "C:\path\MDC\WORD_DOWNLOAD\"

        cls.rePlaceData("#Producer_nameaddress", dao.fields.producer_name & vbCrLf & dao.fields.producer_lct & ".") 'ชื่อบริษัทและที่อยู่ของบริษัท
        cls.rePlaceData("#Producer_name", dao.fields.producer_name) 'ชื่อบริษัท
        cls.rePlaceData("#Recipient_name", dao.fields.recipient) 'ชื่อผู้ขอ
        cls.rePlaceData("#Producer_Address", dao.fields.producer_lct) 'ที่อยู่ของบริษัท
        cls.rePlaceData("#Country", Country_List) 'ประเทศ


        cls.rePlaceData("#Product", Product_List3) 'ผลิตภัณฑ์แบบมีดีเทลด้วย ตั้งแต่ List ที่ 1-5
        cls.rePlaceData("#PD_withoutNum", Product_List2)

        cls.rePlaceData("#Date_App", Format(dao.fields.CONSIDER_DATE, "MMMM dd, yyyy")) 'วันที่ Approve
        cls.rePlaceData("#Date_Exp", Format(dao.fields.expdate, "dd MMMM yyyy")) 'วันหมดอายุ
        cls.rePlaceData("#Refno", Ref_Cer) 'Ref.No
        cls.rePlaceData("#ACADEMIC_STAFF", dao.fields.ACADEMIC_STAFF) 'ชื่อผู้อนุมัติ
        cls.rePlaceData("#ACADEMIC_POSITION", Position_Set) 'ตำแหน่งผู้อนุมัติ
        cls.rePlaceData("#Export", "Certificate of Exportation-Attachment")
        cls.rePlaceData("#Freesale", "Certificate of Free Sale-Attachment")
        cls.rePlaceData("#Manu", "Certificate of Manufacturer-Attachment")
        cls.rePlaceData("#Origin", "Certificate of Origin-Attachment")

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('www.google.co.th','_blank')", True)



        'cls.docSaveOpen(namefile)
        'Using zip As New ZipFile()
        '    zip.AlternateEncodingUsage = ZipOption.AsNecessary
        '    zip.AddDirectoryByName("Files")
        '    zip.AddFile("C:\Users\FA\Downloads\MDC_CER-509000-0-2563-141281.pdf", "File")
        '    Response.Clear()
        '    Response.BufferOutput = False
        '    Dim zipName As String = [String].Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"))
        '    Response.ContentType = "application/zip"
        '    Response.AddHeader("content-disposition", "attachment; filename=" + zipName)
        '    zip.Save(Response.OutputStream)
        '    Response.End()
        'End Using
        cls.docSave(Path & namefile)


        Return Path & namefile

    End Function

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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("../STAFF_MAIN_CER/FRM_POPUP_STAFF_CONFRIME_ATTACH.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "")
    End Sub

    Protected Sub Preview_Export_Click(sender As Object, e As EventArgs) Handles Preview_Export.Click
        BindData_PDF(CHECK_TYPE_PDF)
    End Sub

    Protected Sub Preview_Origi_Click(sender As Object, e As EventArgs) Handles Preview_Origi.Click
        BindData_PDF(0)
    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Response.Redirect("FRM_STAFF_SHOW_DATA2.aspx?TR_ID=" & _TR_ID)
    'End Sub
End Class