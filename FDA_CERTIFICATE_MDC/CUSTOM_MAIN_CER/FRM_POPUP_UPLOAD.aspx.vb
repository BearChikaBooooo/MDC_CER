
Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_POPUP_UPLOAD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _type As String
    Private _YEAR As Integer
    Private _chk_sta As String
    Private _IDA As String
    Private _TR_ID As String
    Private _STAFF_APM As Integer
    Private _GET_TYPE As Integer

    Private _COUNTRY_KEEP As New List(Of MDC_CER_COUNTRY)
    Public Property COUNTRY_KEEP() As List(Of MDC_CER_COUNTRY)
        Get
            Return _COUNTRY_KEEP
        End Get
        Set(ByVal value As List(Of MDC_CER_COUNTRY))
            _COUNTRY_KEEP = value
        End Set
    End Property

    Private _SUBTYPE_KEEP As New List(Of MDC_CER_SUBTYPE)
    Public Property SUBTYPE_KEEP() As List(Of MDC_CER_SUBTYPE)
        Get
            Return _SUBTYPE_KEEP
        End Get
        Set(ByVal value As List(Of MDC_CER_SUBTYPE))
            _SUBTYPE_KEEP = value
        End Set
    End Property
    Private _PRODUCT_KEEP As New List(Of MDC_CER_PRODUCT)
    Public Property PRODUCT_KEEP() As List(Of MDC_CER_PRODUCT)
        Get
            Return _PRODUCT_KEEP
        End Get
        Set(ByVal value As List(Of MDC_CER_PRODUCT))
            _PRODUCT_KEEP = value
        End Set
    End Property
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _type = Request.QueryString("type")
                '_ProcessID = Request.QueryString("process_id")
                _ProcessID = 509000
                _chk_sta = Request.QueryString("chk_sta")
                _STAFF_APM = Request.QueryString("STAFF_APM")
            End If
            _YEAR = con_year()
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If (_chk_sta = 1) Or (_ProcessID = 509000) Then
            bind_attach()
        End If
    End Sub

    Sub bind_attach()
        'Dim dao As New DAO_MDC_CER.TB_TEMPLATE_ATTACH
        'dao.GetDataby_LCTNPCD(_ProcessID, "00")
        'For Each dao.fields In dao.Details
        '    Dim uc As New UC_ATTACH
        '    Dim CC As UserControl = Page.LoadControl("../UC/UC_ATTACH.ascx")
        '    uc = CC
        '    uc.ID = dao.fields.IDA
        '    uc.BindData(dao.fields.ATTACH_NAME, dao.fields.ATTACH_PIORITY, dao.fields.ATTACH_FILE_EXTENSION, dao.fields.LCNTPCD, dao.fields.TYPE)
        '    PlaceHolder1.Controls.Add(uc)
        'Next
        'Dim dao2 As New DAO_MDC_CER.TB_EXPORT
        'dao2.Getdata_byida(_IDA)
        'lbl_cm.Text = dao2.fields.REMARK
        'If _chk_sta = 1 Then
        '    FileUpload1.Visible = False
        '    Label1.Visible = False
        'End If

    End Sub



    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Dim check = True
        Dim citizen_bsn As String
        Dim Get_Result As String


        If _chk_sta <> 1 Then
        End If
        Dim TR_ID As Integer = 0
        Dim bao_tran As New BAO_TRANSCETION.TRANSECTION_UPLOAD
        If _STAFF_APM = 1 Then
            citizen_bsn = _CLS.CITIZEN_ID_BSN
        Else
            citizen_bsn = _CLS.CITIZEN_ID
        End If
        bao_tran.CITIZEN_ID = citizen_bsn
        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID
        _TR_ID = TR_ID
        Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH
        If FileUpload1.HasFile Then
            Dim file1ext As String = GetExtension(FileUpload1.FileName)
            If file1ext.Equals("pdf") Then
                Dim XML_ATTACH As String = _PATH_FILE & "UPLOAD\" & TR_ID & "_" & 509000 & "." & dao_file.fields.EXTENSION
                Dim PDF_TRADER As String = _PATH_FILE & "PDF_TRADER_UPLOAD\" & NAME_PDF("MDC_CER_EXPORT", _ProcessID, "0", _YEAR, TR_ID)   'ทำการกำหนดไฟล์  PDF ที่ทำการ Upload เข้ามาเพื่อดูว่าจะ Save ลงไปที่ไหน
                Dim XML_TRADER As String = _PATH_FILE & "XML_TRADER_UPLOAD\" & NAME_XML("MDC_CER_EXPORT", _ProcessID, "0", _YEAR, TR_ID) 'ทำการกำหนดไฟล์ XML ว่าจะทำการบันทึกลงที่ไหน

                If FileUpload2.HasFile Then 'File Attach
                    Try
                        Dim extensionname As String = GetExtension(FileUpload2.FileName)
                        If extensionname.Equals("xml") Then
                            dao_file.fields.NAME_FAKE = FileUpload2.FileName
                            dao_file.fields.NAME_REAL = TR_ID & "_" & 509000 & ".xml"
                            dao_file.fields.CREATE_DATE = Date.Now
                            dao_file.fields.Description = "XML Product Export"
                            dao_file.fields.EXTENSION = extensionname
                            dao_file.fields.PATH = "upload"
                            dao_file.fields.UPDATE_DATE = Date.Now
                            dao_file.fields.TYPE = 1
                            dao_file.fields.LCNTPCD = 509000
                            dao_file.fields.TR_ID = TR_ID
                            dao_file.fields.EXPLAIN = 0

                        Else
                            check = False
                            alert("ไฟล์ที่อัพโหลดไม่ใช่ XML")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        check = False
                    End Try
                Else

                    check = False
                    alert("คุณไม่ได้อัพโหลดไฟล์ Product")
                    Exit Sub
                End If


                FileUpload1.SaveAs(PDF_TRADER) 'ทำการ Save File ลงไป
                FileUpload2.SaveAs(XML_ATTACH)

                convert_PDF_To_XML(PDF_TRADER, XML_TRADER) 'ทำการ แยกไฟล์ XML ออกจาก PDF แล้วทำการ Save ลงตามจุดที่กำหนด
                If check = True Then
                    If insrt_to_database(XML_TRADER, TR_ID) = True And attach_to_database(XML_ATTACH, TR_ID) Then 'ทำการส่ง XML เข้าไปเพื่อทำการ Insert เข้า DATABASE และ ส่ง TR_ID เข้าไปเพื่อเชื่อมโยง
                        dao_file.insert()
                        BIND_DATA_LIST()
                        Response.Redirect("./FRM_POPUP_CHECKUPLOAD.aspx?IDA=" & _GET_TYPE & "&TR_ID=" & TR_ID)
                        'alert("คุณได้รับรหัสดำเนินการ " & NAME_TRANCESTION("MDC_CER", _ProcessID, _YEAR, TR_ID))
                    Else
                        alert("ข้อมูลไม่ถูกต้อง")
                    End If
                End If

                Exit Sub


            Else
                alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
                Exit Sub
            End If
        Else
            alert("คุณไม่ได้อัพโหลดไฟล์ PDF")
            Exit Sub
        End If
    End Sub





    'Private Function SAVE_FILE_ATTCH(ByVal PDF_FILE As String, ByVal TR_ID1 As String)
    '    Dim check = True
    '    Dim citizen_bsn As String

    '    If _chk_sta <> 1 Then
    '    End If
    '    Dim TR_ID As Integer = 0
    '    Dim bao_tran As New BAO_TRANSCETION.TRANSECTION_UPLOAD
    '    If _STAFF_APM = 1 Then
    '        citizen_bsn = _CLS.CITIZEN_ID_BSN
    '    Else
    '        citizen_bsn = _CLS.CITIZEN_ID
    '    End If
    '    bao_tran.CITIZEN_ID = citizen_bsn
    '    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '    TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID
    '    Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH
    '    If FileUpload1.HasFile Then
    '        Dim file1ext As String = GetExtension(FileUpload1.FileName)
    '        If file1ext.Equals("pdf") Then
    '            Dim PDF_TRADER2 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH5", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER3 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH6", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER4 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH7", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER5 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH8", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER6 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH9", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER7 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH", _ProcessID, "0", _YEAR, TR_ID)
    '            Dim PDF_TRADER8 As String = _PATH_FILE & "PDF_ATTACH\" & NAME_PDF("MDC_CER_ATTACH", _ProcessID, "0", _YEAR, TR_ID)

    '            If FileUpload2.HasFile Then 'File Attach
    '                Try
    '                    Dim extensionname As String = GetExtension(FileUpload2.FileName)

    '                    If extensionname.Equals("pdf") Then
    '                        dao_file.fields.NAME_FAKE = FileUpload2.FileName
    '                        dao_file.fields.NAME_REAL = TR_ID & "_" & 509000 & ".pdf"
    '                        dao_file.fields.CREATE_DATE = Date.Now
    '                        dao_file.fields.Description = "PDF Product Export"
    '                        dao_file.fields.EXTENSION = extensionname
    '                        dao_file.fields.PATH = "upload"
    '                        dao_file.fields.UPDATE_DATE = Date.Now
    '                        dao_file.fields.TYPE = 1
    '                        dao_file.fields.LCNTPCD = 509000
    '                        dao_file.fields.TR_ID = TR_ID
    '                        dao_file.fields.EXPLAIN = 0
    '                    Else
    '                        check = False
    '                        alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
    '                        Exit Sub
    '                    End If
    '                Catch ex As Exception
    '                    check = False
    '                End Try
    '            Else
    '                check = False
    '                alert("คุณไม่ได้อัพโหลดไฟล์ Product")
    '                Exit Sub
    '            End If
    '            FileUpload3.SaveAs(PDF_TRADER)
    '            FileUpload4.SaveAs(PDF_TRADER)
    '            FileUpload5.SaveAs(PDF_TRADER)
    '            FileUpload6.SaveAs(PDF_TRADER)
    '            FileUpload7.SaveAs(PDF_TRADER)
    '            FileUpload8.SaveAs(PDF_TRADER)

    '            convert_PDF_To_XML(PDF_TRADER, XML_TRADER) 'ทำการ แยกไฟล์ XML ออกจาก PDF แล้วทำการ Save ลงตามจุดที่กำหนด
    '            If check = True Then
    '                If insrt_to_database(XML_TRADER, TR_ID) = True And attach_to_database(XML_ATTACH, TR_ID) Then 'ทำการส่ง XML เข้าไปเพื่อทำการ Insert เข้า DATABASE และ ส่ง TR_ID เข้าไปเพื่อเชื่อมโยง
    '                    dao_file.insert()
    '                    alert("คุณได้รับรหัสดำเนินการ " & NAME_TRANCESTION("MDC_CER", _ProcessID, _YEAR, TR_ID))
    '                Else
    '                    alert("ข้อมูลไม่ถูกต้อง")
    '                End If
    '            End If
    '        Else
    '            alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
    '            Exit Sub
    '        End If
    '    Else
    '        alert("คุณไม่ได้อัพโหลดไฟล์ PDF")
    '        Exit Sub
    '    End If
    'End Function
    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal XML_FILE As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True
        Dim amount As Integer = 0
        'Dim addDate_now As Date = CHECK_DATE_LIST10(Date.Now)

        Dim objStreamReader As New StreamReader(XML_FILE)
        Dim bao_show As New BAO_SHOW
        Try
            Dim p2 As New XML_CER_MDC
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            Dim thai_year = CONVERT_THAI_YEAR(Integer.Parse(p2.DT_CER_MDCs.write_date.Value.Year))
            Dim write_date = p2.DT_CER_MDCs.write_date.Value.Day & "-" & p2.DT_CER_MDCs.write_date.Value.Month & "-" & thai_year
            Try
                Dim citizen_bsn As String
                If _STAFF_APM = 1 Then
                    citizen_bsn = _CLS.CITIZEN_ID_BSN
                Else
                    citizen_bsn = _CLS.CITIZEN_ID
                End If
                dao.fields = p2.DT_CER_MDCs
                dao.fields.CITIZEN_ID = citizen_bsn
                dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                dao.fields.TR_ID = TR_ID
                dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
                dao.fields.FK_IDA = _CLS.IDA
                dao.fields.XMLNAME = NAME_TRANCESTION("MDC_CER", _ProcessID, _YEAR, TR_ID)
                dao.fields.STATUS_ID = 1
                dao.fields.DATE_APPROVE = CHECK_DATE_LIST10()

                dao.fields.lmdfdate = Date.Now
                dao.fields.process_id = _ProcessID
                dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.pvncd = _CLS.PVCODE
                dao.fields.TYPE_DB = "1"
                If _STAFF_APM = 1 Then
                    dao.fields.STAFF_REPLACEMENTCD = 1
                    dao.fields.STAFF_REPLACEMENTNM = _CLS.CITIZEN_ID
                Else
                    dao.fields.STAFF_REPLACEMENTCD = 0
                End If
                Dim d2 As DataTable
                d2 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
                For Each dr As DataRow In d2.Rows
                    dao.fields.petitioner_name = dr("thanm")

                Next
                Dim bao As New BAO_SHOW
                Dim dt As DataTable
                dt = bao.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER, 1)
                For Each dr As DataRow In dt.Rows
                    dao.fields.company_name = dr("COMPANY_NM")
                Next

                dao.fields.distributor = p2.DT_CER_MDCs.distributor

                dao.fields.rcvno = ""
                If p2.DT_CER_MDCs.cer_no = 1 Then
                    dao.fields.cer_type = "Certificate Of Free Sale"
                ElseIf p2.DT_CER_MDCs.cer_no = 2 Then
                    dao.fields.cer_type = "Certificate Of Exportation"
                ElseIf p2.DT_CER_MDCs.cer_no = 3 Then
                    dao.fields.cer_type = "Certificate Of Origin"
                ElseIf p2.DT_CER_MDCs.cer_no = 4 Then
                    dao.fields.cer_type = "Certificate Of Manufactory"
                End If

                If p2.DT_CER_MDCs.for_no = 1 Then
                    dao.fields.for_type = "เครื่องมือแพทย์ที่มีใบอนุญาต"
                ElseIf p2.DT_CER_MDCs.for_no = 2 Then
                    dao.fields.for_type = "เครื่องมือแพทย์ที่แจ้งรายละเอียด"
                ElseIf p2.DT_CER_MDCs.for_no = 3 Then
                    dao.fields.for_type = "เครื่องมือแพทย์จดแจ้ง"
                End If
                dao.fields.STATUS_LAW_PAY = "0"
                '-------------- ถ้าเอาขึ้นตัวจริงห้ามลืมลบออก ------------------------------------------------------------'
                'dao.fields.STATUS_PAY = "1"
                '------------------------------------------------------------------------------------------------'
                dao.fields.STATUS_PAYAPPV = "0"
                If p2.DT_CER_MDCs.group_glove_condom = "1" Then
                    dao.fields.group_glove_condom = "1"
                Else
                    dao.fields.group_glove_condom = "0"
                End If

            Catch ex As Exception
                check = False
            End Try
            'เก็บข้อมูล
            Try
                If p2.DT_CER_MDCs.country = 2 Then
                    amount = p2.DT_CER_MDCs.export_amount
                End If

                If p2.DT_CER_MDCs.country = 1 Then
                    For Each dt In p2.DT_CER_MDC_COUNTRies
                        If dt.country_name = "" Or dt.country_name = Nothing Then
                        Else
                            Dim dao2_keep As New MDC_CER_COUNTRY
                            Dim dao2 As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
                            'dao2.Getdata_byid(IDA)
                            amount += dt.export_amount
                            dao2_keep = dt
                            dao2_keep.FK_IDA = dao.fields.IDA
                            COUNTRY_KEEP.Add(dao2_keep)
                        End If
                    Next
                End If
                'For Each cc As MDC_CER_COUNTRY In p2.DT_CER_MDC_COUNTRies
                '    If cc.country_name = "" Or cc.country_name = Nothing Then
                '    Else
                '        Dim dao2_keep As New MDC_CER_COUNTRY
                '        Dim dao2 As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
                '        'dao2.Getdata_byid(IDA)
                '        If dao.fields.country = 1 Then
                '            amount += cc.export_amount
                '        Else
                '            amount = dao.fields.export_amount
                '        End If
                '        dao2_keep = cc
                '        dao2_keep.FK_IDA = dao.fields.IDA

                '        COUNTRY_KEEP.Add(dao2_keep)
                '    End If

                'Next



            Catch ex As Exception
                check = False
            End Try

            Try
                For Each cc As MDC_CER_SUBTYPE In p2.DT_CER_MDC_SUBTYPEs
                    If dao.fields.subtype_no = 0 Then
                    Else
                        If cc.subtype_title = "" Or cc.subtype_title = Nothing And
                        cc.subtype_name = "" Or cc.subtype_name = Nothing Then
                        Else
                            Dim dao3_keep As New MDC_CER_SUBTYPE
                            Dim dao3 As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
                            'dao3.Getdata_byid(cc.IDA)
                            dao3_keep = cc
                            dao3_keep.FK_IDA = dao.fields.IDA
                            SUBTYPE_KEEP.Add(dao3_keep)
                        End If
                    End If
                Next
            Catch ex As Exception
                check = False
            End Try

            'insert
            If check = True Then
                dao.fields.export_amount = p2.DT_CER_MDCs.export_amount
                dao.fields.EXPORT_AMONT_TOTAL = amount
                dao.insert()
                _GET_TYPE = dao.fields.IDA



                For Each cc As MDC_CER_COUNTRY In COUNTRY_KEEP
                    Dim keep As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
                    keep.fields = cc
                    keep.fields.FK_IDA = dao.fields.IDA
                    keep.insert()
                Next

                For Each cc As MDC_CER_SUBTYPE In SUBTYPE_KEEP
                    Dim keep As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
                    keep.fields = cc
                    keep.fields.FK_IDA = dao.fields.IDA
                    keep.insert()
                Next

            End If

            'Dim IDA_GEN As New DAO_MDC.TB_MDC_GEN_RCVNO_IRGT
            'IDA_GEN.GetDataby_REF_IDA(dao_irgt.fields.IDA)
            'dao_irgt.fields.rcvno = IDA_GEN.fields.DESCRIPTION
            'dao_cmnm.update()
            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD
            dao_up.Getdata_byid(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            BAO_COMMON.history_log(_ProcessID, 1, _CLS.CITIZEN_ID, _CLS.thanm, dao.fields.IDA)
            dao_up.update()
        Catch ex As Exception
            alert(ex.ToString)
            check = False
        End Try

        Return check
    End Function


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Private Function attach_to_database(ByVal XML_FILE As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True
        Dim objStreamReader As New StreamReader(XML_FILE)
        Dim p2 As New XML_CER_MDC
        Dim x As New XmlSerializer(p2.GetType)
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_bytrid(TR_ID)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Try
            For Each cc As MDC_CER_PRODUCT In p2.DT_CER_MDC_PRODUCTs
                Dim dao3_keep As New MDC_CER_PRODUCT
                Dim dao3 As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
                'dao3.Getdata_byid(cc.IDA)
                dao3_keep = cc
                PRODUCT_KEEP.Add(dao3_keep)
            Next
        Catch ex As Exception
            check = False
        End Try

        If check = True Then
            For Each cc As MDC_CER_PRODUCT In PRODUCT_KEEP
                Dim keep As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
                keep.fields = cc
                keep.fields.FK_IDA = dao.fields.IDA
                keep.insert()
            Next
        End If

        'Dim dao_tem As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST
        'Dim dao_att As New DAO_MDC_CER.TB_FILE_ATTACH
        'For Each dao_tem.fields In dao_tem.datas
        '    dao_att.fields.TR_ID = TR_ID
        '    dao_att.fields.Description = dao_tem.fields.TEMPLATE_NAME
        '    dao_att.fields.CREATE_DATE = Date.Now
        '    dao_att.insert()

        'Next

        Return check

    End Function

    Private Function CHECK_DATE_LIST10()
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        Dim Date_List As Date = Date.Now
        Dim A As Integer = 0
        dao.Getdata_bydate_app(Date_List.ToShortDateString)

        For Each dao.fields In dao.datas
            A = A + 1
        Next

        If A >= 10 Then
            Date_List = DateAdd(DateInterval.Day, 1, Date_List)
        Else
            Date_List = Date_List
        End If
        Return Date_List
    End Function

    Function CHECK_GROUP_TYPE()

        Dim dao As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST
        Dim dao_cer As New DAO_MDC_CER.TB_MDC_CER
        Dim Cer_type As Integer
        Dim For_no As Integer
        Dim Have_country As Integer
        Dim Distributor As Integer
        Dim Group_type As Integer
        Dim Group_glove As Integer
        dao_cer.Getdata_byid(_GET_TYPE)
        Cer_type = dao_cer.fields.cer_no
        Group_glove = dao_cer.fields.group_glove_condom
        For_no = dao_cer.fields.for_no
        Have_country = dao_cer.fields.country
        Distributor = dao_cer.fields.distributor

        If Cer_type = 1 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_FREE_SALE/ปกติ/เครื่องมือแพทย์จดแจ้ง/ระบุประเทศ
            Group_type = 1
        ElseIf Cer_type = 1 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_FREE_SALE/ปกติ/เครื่องมือแพทย์จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 2
        ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_FREE_SALE/ปกติ/ใบอนุญาต,แจ้งรายการละเอียด/ระบุประเทศ
            Group_type = 3
        ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_FREE_SALE/ปกติ/ใบอนุญาต,แจ้งรายการละเอียด/ไม่ระบุประเทศ
            Group_type = 4
        ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 1 And Have_country = 1 Then 'CER_FREE_SALE/ปกติ/คมพ.ที่มีใบอนุญาต บ.ผ.อ.(กลุ่มถุงมื/ถุงยาง)/ระบุประเทศ
            Group_type = 5
        ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 1 And Have_country = 2 Then 'CER_FREE_SALE/ปกติ/คมพ.ที่มีใบอนุญาต บ.ผ.อ.(กลุ่มถุงมื/ถุงยาง)/ไม่ระบุประเทศ
            Group_type = 6
        ElseIf Cer_type = 1 And Distributor = 1 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_FREE_SALE/แบบImporter/คมพ. จดแจ้ง/ระบุประเทศ
            Group_type = 7
        ElseIf Cer_type = 1 And Distributor = 1 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_FREE_SALE/แบบImporter/คมพ. จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 8
        ElseIf Cer_type = 1 And Distributor = 1 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_FREE_SALE/แบบImporter/คมพ. ใบอนุญาต,แจ้งรายการละเอียด/ระบุประเทศ
            Group_type = 9
        ElseIf Cer_type = 1 And Distributor = 1 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_FREE_SALE/แบบImporter/คมพ. ใบอนุญาต,แจ้งรายการละเอียด/ไม่ระบุประเทศ
            Group_type = 10
        ElseIf Cer_type = 2 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_EXPORT/ปกติ/จดแจ้ง/ระบุประเทศ
            Group_type = 11
        ElseIf Cer_type = 2 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_EXPORT/ปกติ/จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 12
        ElseIf Cer_type = 2 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_EXPORT/ปกติ/คมพ มีใบอนุญาต,แจ้งรายการละเอียด/ระบุประเทศ
            Group_type = 13
        ElseIf Cer_type = 2 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_EXPORT/ปกติ/คมพ มีใบอนุญาต,แจ้งรายการละเอียด/ไม่ระบุประเทศ
            Group_type = 14
        ElseIf Cer_type = 2 And Distributor = 1 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_EXPORT/แบบ Importer/จดแจ้ง/ระบุประเทศ
            Group_type = 15
        ElseIf Cer_type = 2 And Distributor = 1 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_EXPORT/แบบ Importer/จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 16
        ElseIf Cer_type = 2 And Distributor = 1 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_EXPORT/แบบ Importer/คมพ ที่มีใบอนุญาต , แจ้งรายการละเอียด/ระบุประเทศ
            Group_type = 17
        ElseIf Cer_type = 2 And Distributor = 1 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_EXPORT/แบบ Importer/จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 18
        ElseIf Cer_type = 4 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_MENU/แบบปกติ/คมพ จดแจ้ง/ระบุประเทศ
            Group_type = 19
        ElseIf Cer_type = 4 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_MENU/แบบปกติ/คมพ จดแจ้ง/ไม่ระบุประเทศ
            Group_type = 20
        ElseIf Cer_type = 4 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_MENU/แบบปกติ/คมพ แจ้งรายการละเอียด,คมพ ที่มีใบอนุญาต/ระบุประเทศ
            Group_type = 21
        ElseIf Cer_type = 4 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_MENU/แบบปกติ/คมพ แจ้งรายการละเอียด,คมพ ที่มีใบอนุญาต/ไม่ระบุประเทศ
            Group_type = 22
        ElseIf Cer_type = 3 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 1 Then 'CER_ORIGIN/แบบปกติ/คมพ จดแจ้ง/ระบุประเทศ
            Group_type = 23
        ElseIf Cer_type = 3 And Distributor = 0 And For_no = 3 And Group_glove = 0 And Have_country = 2 Then 'CER_ORIGIN/แบบปกติ/คมพ จดแจ้ง/ระบุประเทศ
            Group_type = 24
        ElseIf Cer_type = 3 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 1 Then 'CER_ORIGIN/แบบปกติ/คมพ แจ้งรายการละเอียด,คมพ ที่มีใบอนุญาต/ระบุประเทศ
            Group_type = 25
        ElseIf Cer_type = 3 And Distributor = 0 And (For_no = 1 Or For_no = 2) And Group_glove = 0 And Have_country = 2 Then 'CER_ORIGIN/แบบปกติ/คมพ แจ้งรายการละเอียด,คมพ ที่มีใบอนุญาต/ไม่ระบุประเทศ
            Group_type = 26
        End If

        Return Group_type
    End Function
    Sub BIND_DATA_LIST()
        Dim dao_cer As New DAO_MDC_CER.TB_MDC_CER
        Dim dao_tem_up_list As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST

        Dim bind_group_type = dao_tem_up_list.fields.GROUP_TYPE
        Dim bind_process_id = dao_tem_up_list.fields.PROCESS_ID
        Dim bind_Data = CHECK_GROUP_TYPE()
        dao_cer.Getdata_byid(_GET_TYPE)
        dao_tem_up_list.GetTemplate_ByGroup_type(bind_Data, dao_cer.fields.process_id)

        Dim Loop_List_Template_name As String
        Dim Template_List As String
        Loop_List_Template_name = dao_tem_up_list.fields.TEMPLATE_NAME


        For Each dao_tem_up_list.fields In dao_tem_up_list.datas
            Dim dao_Att As New DAO_MDC_CER.TB_FILE_ATTACH
            dao_Att.fields.CREATE_DATE = Date.Now
            dao_Att.fields.Description = dao_tem_up_list.fields.TEMPLATE_NAME
            dao_Att.fields.TR_ID = _TR_ID
            dao_Att.fields.TYPE = 10001
            dao_Att.insert()
            Template_List = dao_tem_up_list.fields.TEMPLATE_NAME
        Next

    End Sub
End Class