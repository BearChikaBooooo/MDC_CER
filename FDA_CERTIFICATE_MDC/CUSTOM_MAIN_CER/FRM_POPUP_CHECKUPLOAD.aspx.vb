Public Class FRM_POPUP_CHECKUPLOAD
    Inherits System.Web.UI.Page
    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
    '    Dim Get_Result As String


    '    Dim TR_ID As Integer = 0
    '    Dim bao_tran As New BAO_TRANSCETION.TRANSECTION_UPLOAD


    '    Get_Result = Add_att(FileUpload4, TR_ID, "สำเนาใบอนุญาต/แจ้งรายการละเอียด/แบบ บ.ผ.อ.")
    '            Get_Result = Get_Result + Add_att(FileUpload5, TR_ID, "สำเนาหนังสือรับรองการส่งออกฉบับเดิมที่เคยได้รับ (ถ้ามี)")
    '            Get_Result = Get_Result + Add_att(FileUpload6, TR_ID, "รายละเอียดเกี่ยวกับการผลิตเครื่องมือแพทย์ (กรณีเครื่องมือแพทย์อื่น ๆ)")
    '            Get_Result = Get_Result + Add_att(FileUpload7, TR_ID, "สำเนาใบจดทะเบียนสถานประกอบการผลิต/นำเข้าเครื่องมือแพทย์หรือสำเนา")
    '            Get_Result = Get_Result + Add_att(FileUpload8, TR_ID, "เอกสารแสดงการขายเครื่องมือแพทย์ในประเทศไทย")
    '            Get_Result = Get_Result + Add_att2(FileUpload9, TR_ID, "อื่น ๆ (ระบุ)")



    '            If Get_Result = "" Then
    '                convert_PDF_To_XML(PDF_TRADER, XML_TRADER) 'ทำการ แยกไฟล์ XML ออกจาก PDF แล้วทำการ Save ลงตามจุดที่กำหนด
    '                If check = True Then
    '                    If insrt_to_database(XML_TRADER, TR_ID) = True And attach_to_database(XML_ATTACH, TR_ID) Then 'ทำการส่ง XML เข้าไปเพื่อทำการ Insert เข้า DATABASE และ ส่ง TR_ID เข้าไปเพื่อเชื่อมโยง
    '                        dao_file.insert()

    '                        alert("คุณได้รับรหัสดำเนินการ " & NAME_TRANCESTION("MDC_CER", _ProcessID, _YEAR, TR_ID))
    '                    Else
    '                        alert("ข้อมูลไม่ถูกต้อง")
    '                    End If
    '                End If
    '            Else
    '                Exit Sub
    '            End If

    '        Else
    '            alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
    '            Exit Sub
    '        End If
    '    Else
    '        alert("คุณไม่ได้อัพโหลดไฟล์ PDF")
    '        Exit Sub
    '    End If


    'End Sub

    '''' <summary>
    '''' ฟังก์ชั่นสำหรับแนบไฟล์
    '''' </summary>
    '''' <param name="file_att"></param>
    '''' <param name="TR_ID"></param>
    'Private Function Add_att(ByVal file_att As FileUpload, ByVal TR_ID As Integer, ByVal Text1 As String) As String

    '    Dim result As String = ""

    '    If file_att.HasFile Then
    '        Try
    '            Dim extensionname As String = GetExtension(file_att.FileName)
    '            If extensionname.Equals("pdf") Then
    '                Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH

    '                dao_file.fields.CREATE_DATE = Date.Now
    '                dao_file.fields.Description = Text1
    '                dao_file.fields.EXTENSION = extensionname
    '                dao_file.fields.PATH = "upload"
    '                dao_file.fields.UPDATE_DATE = Date.Now
    '                dao_file.fields.TYPE = 1
    '                dao_file.fields.LCNTPCD = 509000
    '                dao_file.fields.TR_ID = TR_ID
    '                dao_file.fields.EXPLAIN = 0
    '                dao_file.insert()


    '                Dim dao_file_update As New DAO_MDC_CER.TB_FILE_ATTACH
    '                dao_file_update.GetDATAby_IDA(dao_file.fields.IDA)
    '                dao_file_update.fields.NAME_FAKE = TR_ID & "_" & dao_file.fields.IDA & ".pdf"
    '                dao_file_update.fields.NAME_REAL = file_att.FileName
    '                dao_file_update.update()

    '                Dim pdf_att As String = _PATH_FILE & "upload\" & TR_ID & "_" & dao_file.fields.IDA & ".pdf"

    '                file_att.SaveAs(pdf_att)

    '            Else

    '                result = "ไฟล์ที่อัพโหลดไม่ใช่ PDF"

    '                alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
    '                Exit Function

    '            End If
    '        Catch ex As Exception

    '            result = "ไฟล์ที่อัพโหลดมีปัญหา กรุณาลองใหม่อีกครั้ง"

    '        End Try
    '    Else

    '        result = ""
    '    End If

    '    Return result
    'End Function

    'Private Function Add_att2(ByVal file_att As FileUpload, ByVal TR_ID As Integer, ByVal Text1 As String) As String

    '    Dim result As String = ""

    '    If file_att.HasFile Then
    '        Try
    '            Dim extensionname As String = GetExtension(file_att.FileName)
    '            If extensionname.Equals("pdf") Then
    '                Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH

    '                dao_file.fields.CREATE_DATE = Date.Now
    '                dao_file.fields.Description = Text1
    '                dao_file.fields.EXTENSION = extensionname
    '                dao_file.fields.PATH = "upload"
    '                dao_file.fields.UPDATE_DATE = Date.Now
    '                dao_file.fields.TYPE = 1
    '                dao_file.fields.LCNTPCD = 509000
    '                dao_file.fields.TR_ID = TR_ID
    '                dao_file.fields.EXPLAIN = 0
    '                dao_file.insert()


    '                Dim dao_file_update As New DAO_MDC_CER.TB_FILE_ATTACH
    '                dao_file_update.GetDATAby_IDA(dao_file.fields.IDA)
    '                dao_file_update.fields.NAME_FAKE = TR_ID & "_" & dao_file.fields.IDA & ".pdf"
    '                dao_file_update.fields.NAME_REAL = file_att.FileName
    '                dao_file_update.update()

    '                Dim pdf_att As String = _PATH_FILE & "upload\" & TR_ID & "_" & dao_file.fields.IDA & ".pdf"

    '                file_att.SaveAs(pdf_att)

    '            Else

    '                result = "ไฟล์ที่อัพโหลดไม่ใช่ PDF"

    '                alert("ไฟล์ที่อัพโหลดไม่ใช่ PDF")
    '                Exit Function

    '            End If
    '        Catch ex As Exception

    '            result = "ไฟล์ที่อัพโหลดมีปัญหา กรุณาลองใหม่อีกครั้ง"

    '        End Try
    '    Else

    '        result = ""
    '    End If

    '    Return result
    'End Function



    Private _TR_ID As String
    Private _IDA As String
    Private _GET_TYPE As String
    Private _ProcessID As Integer
    Private _YEAR As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Get_DATA_INTABLE()

        'If Not IsPostBack Then
        '    Get_DATA_INTABLE()
        'End If

        BindTable()
    End Sub
    Sub Get_DATA_INTABLE()
        _TR_ID = Request.QueryString("TR_ID")
        _IDA = Request.QueryString("IDA")
        _GET_TYPE = Request.QueryString("_GET_TYPE")
        _ProcessID = 509000
        _YEAR = con_year()
    End Sub
    'Function CHECK_GROUP_TYPE()
    '    Dim check As Boolean
    '    Dim dao As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST
    '    Dim dao_cer As New DAO_MDC_CER.TB_MDC_CER
    '    Dim Cer_type As Integer
    '    Dim For_no As Integer
    '    Dim Have_country As Integer
    '    Dim Distributor As Integer
    '    Dim Group_type As Integer
    '    Dim Group_glove As Integer
    '    dao_cer.Getdata_byid(_IDA)
    '    Cer_type = dao_cer.fields.cer_no
    '    Group_glove = dao_cer.fields.group_glove_condom
    '    For_no = dao_cer.fields.for_no
    '    Have_country = dao_cer.fields.country
    '    Distributor = dao_cer.fields.distributor

    '    If Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 1
    '    ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 2
    '    ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Group_glove = 1 And Have_country = 1 Then
    '        Group_type = 3
    '    ElseIf Cer_type = 1 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Group_glove = 1 And Have_country = 0 Then
    '        Group_type = 4
    '    ElseIf Cer_type = 1 And Distributor = 1 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 5
    '    ElseIf Cer_type = 1 And Distributor = 1 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 6
    '    ElseIf Cer_type = 2 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 7
    '    ElseIf Cer_type = 2 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 8
    '    ElseIf Cer_type = 2 And Distributor = 1 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 9
    '    ElseIf Cer_type = 2 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 10
    '    ElseIf Cer_type = 3 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 11
    '    ElseIf Cer_type = 3 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 12
    '    ElseIf Cer_type = 4 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 1 Then
    '        Group_type = 13
    '    ElseIf Cer_type = 3 And Distributor = 0 And (For_no = 1 Or For_no = 2 Or For_no = 3) And Have_country = 0 Then
    '        Group_type = 14
    '    End If

    '    Return Group_type
    'End Function
    'Sub BIND_DATA_LIST()
    '    Dim dao_cer As New DAO_MDC_CER.TB_MDC_CER
    '    Dim dao_tem_up_list As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST

    '    Dim bind_group_type = dao_tem_up_list.fields.GROUP_TYPE
    '    Dim bind_process_id = dao_tem_up_list.fields.PROCESS_ID
    '    Dim bind_Data = CHECK_GROUP_TYPE()
    '    dao_cer.Getdata_byid(_IDA)
    '    dao_tem_up_list.GetTemplate_ByGroup_type(bind_Data, dao_cer.fields.process_id)

    '    Dim Loop_List_Template_name As String
    '    Dim Template_List As String
    '    Loop_List_Template_name = dao_tem_up_list.fields.TEMPLATE_NAME


    '    For Each dao_tem_up_list.fields In dao_tem_up_list.datas
    '        Dim dao_Att As New DAO_MDC_CER.TB_FILE_ATTACH
    '        dao_Att.fields.CREATE_DATE = Date.Now
    '        dao_Att.fields.Description = dao_tem_up_list.fields.TEMPLATE_NAME
    '        dao_Att.fields.TR_ID = _TR_ID
    '        dao_Att.fields.TYPE = 99
    '        dao_Att.insert()
    '        Template_List = dao_tem_up_list.fields.TEMPLATE_NAME
    '    Next

    'End Sub
    Private Sub BindTable()

        Dim dao_f As New DAO_MDC_CER.TB_FILE_ATTACH
        Dim dao_att As New DAO_MDC_CER.GET_TB_TAMPLATE_UPLOAD_LIST

        dao_f.GetDATAby_TR_ID(_TR_ID, 10001)

        Dim rows As Integer = 1
        For Each dao_f.fields In dao_f.datas
            Try

            Catch ex As Exception

            End Try

            Dim tr As New TableRow
            tr.CssClass = "rows"
            Dim tc As New TableCell

            tc = New TableCell
            tc.Text = rows
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.IDA

            tc.Style.Add("display", "none")
            tr.Cells.Add(tc)

            tc = New TableCell
            Try
                tc.Text = Replace(dao_f.fields.Description, "\n", "<br/>")
            Catch ex As Exception
                tc.Text = dao_f.fields.Description
            End Try
            tc.Width = 700
            tr.Cells.Add(tc)

            tc = New TableCell
            tc.Text = dao_f.fields.NAME_REAL
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim img As New Image
            If dao_f.fields.NAME_REAL Is Nothing OrElse dao_f.fields.NAME_REAL = "" Then
                img.ImageUrl = "../Images/cancel.png"
                img.Width = 35
                img.Height = 35
            Else
                img.ImageUrl = "../Images/correct.png"
                img.Width = 35
                img.Height = 35
            End If
            tc.Controls.Add(img)
            tr.Cells.Add(tc)

            tc = New TableCell
            Dim f As New FileUpload
            f.ID = "F" & dao_f.fields.IDA
            tc.Controls.Add(f)
            tr.Cells.Add(tc)

            myTable.Rows.Add(tr)
            rows = rows + 1
        Next

    End Sub

    Private Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        alert("คุณได้รับรหัสดำเนินการ " & NAME_TRANCESTION("MDC_CER", _ProcessID, _YEAR, _TR_ID))

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Sub alert2(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_att_Click(sender As Object, e As EventArgs) Handles btn_att.Click
        Dim topic As String = ""
        For Each tr As TableRow In myTable.Rows
            Dim IDA As Integer = tr.Cells(1).Text
            Dim topic_name As String = tr.Cells(2).Text
            Dim dao_att As New DAO_MDC_CER.TB_FILE_ATTACH
            Dim f As New FileUpload
            f = tr.FindControl("F" & IDA)
            If topic_name.Contains("(เช่น หนังสือยินยอมให้ใช้เอกสาร)") Or topic_name.Contains("(ถ้ามี)") Then
                If f.HasFile Then
                    If dao_att.fields.NAME_FAKE = "" Then
                        Dim name_real As String = f.FileName
                        Dim Array_NAME_REAL() As String = Split(name_real, ".")
                        Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                        Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                        If exten.ToUpper = "PDF" Then
                            Dim dao_f As New DAO_MDC_CER.TB_FILE_ATTACH
                            dao_f.GetDATAby_IDA(IDA)
                            Dim Path As String = _PATH_FILE
                            Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH
                            dao_file.GetDATAby_IDA(IDA)
                            Dim Name_fake As String = _TR_ID & "_" & dao_file.fields.IDA & ".pdf"
                            Dim pa As String = Path & "PDF_ATTACH/"
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.PATH = Path
                            dao_f.fields.CREATE_DATE = Date.Now
                            dao_f.fields.TYPE = 99
                            dao_f.update()
                            f.SaveAs(pa & Name_fake)
                        Else
                            alert2(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                        End If
                    Else

                    End If
                End If

            Else

                If f.HasFile Then
                    If dao_att.fields.NAME_FAKE = "" Then
                        Dim name_real As String = f.FileName
                        Dim Array_NAME_REAL() As String = Split(name_real, ".")
                        Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
                        Dim exten As String = Array_NAME_REAL(Last_Length).ToString()
                        If exten.ToUpper = "PDF" Then
                            Dim dao_f As New DAO_MDC_CER.TB_FILE_ATTACH
                            dao_f.GetDATAby_IDA(IDA)
                            Dim Path As String = _PATH_FILE
                            Dim dao_file As New DAO_MDC_CER.TB_FILE_ATTACH
                            dao_file.GetDATAby_IDA(IDA)
                            Dim Name_fake As String = _TR_ID & "_" & dao_file.fields.IDA & ".pdf"
                            Dim pa As String = Path & "PDF_ATTACH/"
                            dao_f.fields.NAME_FAKE = Name_fake
                            dao_f.fields.NAME_REAL = f.FileName
                            dao_f.fields.PATH = Path
                            dao_f.fields.CREATE_DATE = Date.Now
                            dao_f.fields.TYPE = 99
                            dao_f.update()
                            f.SaveAs(pa & Name_fake)
                        Else
                            alert(name_real & " กรุณาแนบเป็นไฟล์ PDF")
                        End If
                    Else
                        alert("กรุณาแนบไฟล์ให้ครบ")

                    End If
                Else
                    alert("กรุณาแนบไฟล์ให้ครบ")
                    Exit Sub
                End If
            End If
        Next
        alert2("บันทึกไฟล์แนบเรียบร้อยแล้ว")
        'Response.Redirect(Request.Url.AbsoluteUri)
        'alert("EIEIEIEIEIEIE")
    End Sub
End Class