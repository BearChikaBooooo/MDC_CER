Imports System.Globalization
Imports System.Threading

Public Class DOWNLOAD
    Inherits System.Web.UI.Page
    Private _ida As String
    Private _filename As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ida = Request.QueryString("IDA")
        _filename = Request.QueryString("filename")
        DOWNLOAD_WORD(_filename)
    End Sub

    Private Sub DOWNLOAD_WORD(ByVal Country As String) 'ByVal Country As String
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
        Dim Country_Lirst As String = "" 'Country
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
            Product_List3 += Count & ".) " & dao_prod.fields.Product_Name & vbCrLf & vbTab & dao_prod.fields.Product_Detail & vbCrLf
            Product_List2 += dao_prod.fields.Product_Name & vbCrLf & vbTab & dao_prod.fields.Product_Detail & vbCrLf

        Next

        For Each dao_coun.fields In dao_coun.datas 'ตัวนี้จะวนลูปเอาข้อมูลทั้งหมดของ Country ที่ IDA นั้นๆมี อยู่ออกมาโชว์ทั้งหมด
            Country_Lirst += dao_coun.fields.country_name & "."
        Next


        If dao.fields.cer_no = "1" Then
            CER_TYPE = "free_sale\"
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
            ElseIf dao.fields.country = "1" Then 'ระบุ
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
        ElseIf dao.fields.cer_no = "2" Then
            CER_TYPE = "manu\"
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
                    TEMPLATE_NAME = "CERTIFICATE_OF_MANUFACTURER1"
                End If
            ElseIf dao.fields.country = "2" Then 'ไม่ระบุ
                If Count > 5 Then 'ระบุประเทศแบบProductมากกว่า5รายการขึ้นไป
                    TEMPLATE_NAME = "ATTACTED_LIST2"
                Else
                    TEMPLATE_NAME = "CERTIFICATE_OF_MANUFACTURER2"
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
            CER_TYPE = "export\"
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
        cls.setLicense(PATH_License)
        Dim PATH_WORD_TEM As String = Word_Templete & CER_TYPE




        Dim Position_Set As String = dao.fields.ACADEMIC_POSITION.Replace("Pharmacist, Professional Level ", "Pharmacist, Professional Level " & vbCrLf)
        Position_Set = Position_Set.Replace("Person designated by the Secretary-General", "Person designated by the Secretary-General" & vbCrLf)
        Position_Set = Position_Set.Replace("Director of Medical Device Control Division", "Director of Medical Device Control Division" & vbCrLf)
        Position_Set = Position_Set.Replace("Senior Pharmacist Acting Director of Medical Device", "Senior Pharmacist Acting Director of Medical Device" & vbCrLf)
        Position_Set = Position_Set.Replace("Control Division For Secretary-General", "Control Division For Secretary-General" & vbCrLf)

        Dim Position_Set2 As String = dao.fields.producer_name.Replace("Road,", "Road," & vbCrLf)
        Position_Set2 = Position_Set2.Replace("RD.,", "RD.," & vbCrLf)
        Position_Set2 = Position_Set2.Replace("Rd.,", "Rd.," & vbCrLf)

        cls.docConnect(PATH_WORD_TEM & TEMPLATE_NAME & ".doc")
        namefile = "Test" & Country & ".docx"
        'namefile = "Name-" & CStr(Date.UtcNow.Millisecond) & ".docx"

        cls.rePlaceData("#Producer_nameaddress", dao.fields.producer_name & vbCrLf & dao.fields.producer_lct) 'ชื่อบริษัทและที่อยู่ของบริษัท
        cls.rePlaceData("#Producer_name", dao.fields.producer_name) 'ชื่อบริษัท
        cls.rePlaceData("#Recipient_name", dao.fields.recipient) 'ชื่อผู้ขอ
        cls.rePlaceData("#Producer_Address", dao.fields.producer_lct) 'ที่อยู่ของบริษัท
        cls.rePlaceData("#Country", Country_Lirst) 'ประเทศ


        cls.rePlaceData("#Product", Product_List3) 'ผลิตภัณฑ์แบบมีดีเทลด้วย ตั้งแต่ List ที่ 1-5
        cls.rePlaceData("#PD_withoutNum", Product_List2)

        cls.rePlaceData("#Date_App", Format(dao.fields.CONSIDER_DATE, "MMMM dd, yyyy")) 'วันที่ Approve
        cls.rePlaceData("#Date_Exp", Format(dao.fields.expdate, "dd MMMM yyyy")) 'วันหมดอายุ
        cls.rePlaceData("#Refno", dao_lcnno.fields.lcnno_display_num) 'Ref.No
        cls.rePlaceData("#ACADEMIC_STAFF", dao.fields.ACADEMIC_STAFF) 'ชื่อผู้อนุมัติ
        cls.rePlaceData("#ACADEMIC_POSITION", Position_Set) 'ตำแหน่งผู้อนุมัติ
        cls.rePlaceData("#Export", "Certificate of Exportation-Attachment")
        cls.rePlaceData("#Freesale", "Certificate of Free Sale-Attachment")
        cls.rePlaceData("#Manu", "Certificate of Manufacturer-Attachment")
        cls.rePlaceData("#Origin", "Certificate of Origin -Attachment")



        cls.docSaveOpen(namefile)

    End Sub


End Class