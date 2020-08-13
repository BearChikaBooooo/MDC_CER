'Imports System.IO
'Imports System.Xml.Serialization
'Imports System.Collections.Generic
'Imports System.Text
'Imports System.Globalization

'Public Class BIND_PDF_CFS_CER
'    Dim ThaiCulture As New CultureInfo("th-TH")
'    Dim UsaCulture As New CultureInfo("en-US")
'    Private _XML_PATH_PDF As String
'    Public Property XML_PATH_PDF() As String
'        Get
'            Return _XML_PATH_PDF
'        End Get
'        Set(ByVal value As String)
'            _XML_PATH_PDF = value
'        End Set
'    End Property


'    Private _XML_LCNSID As Integer
'    Public Property XML_LCNSID() As Integer
'        Get
'            Return _XML_LCNSID
'        End Get
'        Set(ByVal value As Integer)
'            _XML_LCNSID = value
'        End Set
'    End Property


'    Private _XML_CITIZEN_ID As String
'    Public Property XML_CITIZEN_ID() As String
'        Get
'            Return _XML_CITIZEN_ID
'        End Get
'        Set(ByVal value As String)
'            _XML_CITIZEN_ID = value
'        End Set
'    End Property


'    Private _XML_CITIZEN_ID_AUTHORIZE As String
'    Public Property XML_CITIZEN_ID_AUTHORIZE() As String
'        Get
'            Return _XML_CITIZEN_ID_AUTHORIZE
'        End Get
'        Set(ByVal value As String)
'            _XML_CITIZEN_ID_AUTHORIZE = value
'        End Set
'    End Property

'    Private _MAIN_IDA As Integer
'    Public Property MAIN_IDA() As Integer
'        Get
'            Return _MAIN_IDA
'        End Get
'        Set(ByVal value As Integer)
'            _MAIN_IDA = value
'        End Set
'    End Property



'    Private _XML_TYPE As String
'    Public Property XML_TYPE() As String
'        Get
'            Return _XML_TYPE
'        End Get
'        Set(ByVal value As String)
'            _XML_TYPE = value
'        End Set
'    End Property


'    Private _XML_STATUS_ID As Integer
'    Public Property XML_STATUS_ID() As Integer
'        Get
'            Return _XML_STATUS_ID
'        End Get
'        Set(ByVal value As Integer)
'            _XML_STATUS_ID = value
'        End Set
'    End Property

'    Private _XML_PROCESS_ID As String
'    Public Property XML_PROCESS_ID() As String
'        Get
'            Return _XML_PROCESS_ID
'        End Get
'        Set(ByVal value As String)
'            _XML_PROCESS_ID = value
'        End Set
'    End Property

'    Private _XML_LCNTYPECD As String
'    Public Property XML_LCNTYPECD() As String
'        Get
'            Return _XML_LCNTYPECD
'        End Get
'        Set(ByVal value As String)
'            _XML_LCNTYPECD = value
'        End Set
'    End Property

'    Private _XML_PREVIEW_PDF As Integer
'    Public Property XML_PREVIEW_PDF() As Integer
'        Get
'            Return _XML_PREVIEW_PDF
'        End Get
'        Set(ByVal value As Integer)
'            _XML_PREVIEW_PDF = value
'        End Set
'    End Property

'    Private _lcnno As String
'    Public Property lcnno() As String
'        Get
'            Return _lcnno
'        End Get
'        Set(ByVal value As String)
'            _lcnno = value
'        End Set
'    End Property


'    Public Sub DOWNLOAD_PDF()


'        Dim dao_pdftemplate As New DAO.CFS.TB_MAS_TEMPLATE_PROCESS
'        dao_pdftemplate.GetDATAby_PROCESS_ID(_XML_PROCESS_ID, _XML_STATUS_ID, _XML_PREVIEW_PDF)


'        Dim BAO_TRA As New TRANSECTION.TRANSECTION_DOWNLOAD
'        Dim Down_ID As Integer = 0
'        BAO_TRA.CITIZEN_ID = XML_CITIZEN_ID
'        BAO_TRA.CITIZEN_ID_AUTHORIZE = XML_CITIZEN_ID_AUTHORIZE
'        Down_ID = BAO_TRA.insert_transection(_XML_PROCESS_ID)


'        Dim paths As String = _PATH_FILE
'        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
'        Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_DOWNLOAD("CFS", _XML_PROCESS_ID, Date.Now.Year, Down_ID)
'        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_DOWNLOAD("CFS", _XML_PROCESS_ID, Date.Now.Year, Down_ID)

'        Dim MAIN_XML As New XML_CER_MDC
'        Dim GEN_XMLs As New GEN_XML.GEN_XML_CER_FOOD_HEAD

'        MAIN_XML = GEN_XMLs.GEN_XML()
'        'MAIN_XML.DATA_CER_FOOD.LCNNO = lcnno
'        With MAIN_XML.DATA_CER_FOOD
'            .CITIZEN_DOWNLOAD = XML_CITIZEN_ID
'            .FK_IDA = MAIN_IDA
'            .CITIZEN_AUTHORIZE = XML_CITIZEN_ID_AUTHORIZE
'            .STATUS_ID = XML_STATUS_ID
'            .DOWN_ID = Down_ID
'            .LCNNO = lcnno
'            .ATTACH_1 = 0
'            .ATTACH_2 = 0
'            'If _XML_PROCESS_ID = "930001" Then
'            '    .ATTACH_3 = 46
'            'Else
'            .ATTACH_3 = 0
'            'End If
'            'If _XML_PROCESS_ID = "930002" Then
'            '    .ATTACH_4 = 58
'            'Else
'            .ATTACH_4 = 0
'            'End If

'            .ATTACH_5 = 0
'            .ATTACH_6 = 0
'            .ATTACH_7 = 0
'            .ATTACH_8 = 0
'            .ATTACH_9 = 0
'            .ATTACH_10 = 0
'            .CERTIFIES_CHECK1 = 0
'            .CERTIFIES_CHECK2 = 0
'        End With
'        'MAIN_XML.DAY = Date.Now.Day
'        'MAIN_XML.MONTH = Date.Now.ToString("MMMM", ThaiCulture)
'        'MAIN_XML.YEAR = Date.Now.ToString("yyyy", ThaiCulture)
'        MAIN_XML.PROCESS = _XML_PROCESS_ID

'        Dim bao_show As New BAO_STOREPROCUDURE.CPN
'        Try

'            MAIN_XML.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_XML_CITIZEN_ID)

'        Catch ex As Exception

'        End Try

'        MAIN_XML.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_FK_IDA(MAIN_IDA)
'        MAIN_XML.DT_SHOW.DT6 = bao_show.SP_SYSISOCNT()
'        MAIN_XML.DT_SHOW.DT10 = bao_show.SP_SP_SYSAMPHR()
'        MAIN_XML.DT_SHOW.DT11 = bao_show.SP_SP_SYSCHNGWT()

'        Dim bao_cer As New BAO_STOREPROCUDURE.CFS
'        MAIN_XML.DT_SHOW.DT7 = bao_cer.SP_GET_MAS_DISTRICT()
'        MAIN_XML.DT_SHOW.DT8 = bao_cer.SP_GET_MAS_PROVINCES()

'        Dim bao_food As New BAO_STOREPROCUDURE.FOOD
'        Dim bao_food_xml As New BAO_STOREPROCUDURE.FOOD_XML
'        MAIN_XML.DT_SHOW.DT9 = bao_food_xml.SP_GET_PRODUCT_FOR_CER(_XML_LCNSID, _lcnno)

'        For i As Integer = 0 To 0

'            Dim cls_CFS_FOOD_COUNTRY As New CFS_FOOD_COUNTRY

'            cls_CFS_FOOD_COUNTRY = AddValue(cls_CFS_FOOD_COUNTRY)

'            MAIN_XML.CFS_FOOD_COUNTRY.Add(cls_CFS_FOOD_COUNTRY)
'        Next


'        For i As Integer = 0 To 0

'            Dim cls_CFS_FOOD_PRODUCT As New CFS_FOOD_PRODUCT

'            cls_CFS_FOOD_PRODUCT = AddValue(cls_CFS_FOOD_PRODUCT)

'            MAIN_XML.CFS_FOOD_PRODUCT.Add(cls_CFS_FOOD_PRODUCT)
'        Next

'        'For i As Integer = 0 To 0

'        '    Dim cls_CFS_FOOD_PRODUCT As New CFS_FOOD_PRODUCT

'        '    cls_CFS_FOOD_PRODUCT = AddValue(cls_CFS_FOOD_PRODUCT)

'        '    MAIN_XML.CFS_FOOD_PRODUCT_NO.Add(cls_CFS_FOOD_PRODUCT)
'        'Next

'        MAIN_XML.DT_MAS.DT12 = bao_food.SP_MASTER_CON_LCNNO(MAIN_IDA)


'        If _XML_PROCESS_ID = "930002" Then
'            For i As Integer = 0 To 0
'                Dim fda_extract As New XML_CFS_FOOD_CER.CFS_FOOD_PRODUCT_LIST
'                fda_extract = AddValue(fda_extract)

'                Dim fff As New List(Of CFS_FOOD_FML)
'                For ii As Integer = 0 To 0
'                    Dim fda_extract_active As New CFS_FOOD_FML
'                    fda_extract_active = AddValue(fda_extract_active)
'                    fda_extract_active.FML_QTY = 0
'                    fff.Add(fda_extract_active)


'                Next
'                fda_extract.CFS_FOOD_FML_LIST = fff

'                MAIN_XML.LIST_CFS_FOOD_PRODUCT_LIST.Add(fda_extract)
'            Next

'            For i As Integer = 0 To 0
'                Dim fda_extract As New XML_CFS_FOOD_CER.CFS_FOOD_PRODUCT_LIST
'                fda_extract = AddValue(fda_extract)

'                Dim fff As New List(Of CFS_FOOD_FML)
'                For ii As Integer = 0 To 0
'                    Dim fda_extract_active As New CFS_FOOD_FML
'                    fda_extract_active = AddValue(fda_extract_active)
'                    fda_extract_active.FML_QTY = 0
'                    fff.Add(fda_extract_active)


'                Next
'                fda_extract.CFS_FOOD_FML_LIST = fff

'                MAIN_XML.LIST_CFS_FOOD_PRODUCT_LIST_NO.Add(fda_extract)
'            Next

'        End If

'        If _XML_PROCESS_ID = "930001" Then
'            For i As Integer = 0 To 0
'                Dim fda_extract As New XML_CFS_FOOD_CER.CFS_FOOD_PRODUCT_LIST
'                fda_extract = AddValue(fda_extract)

'                Dim fff As New List(Of CFS_FOOD_FML)
'                For ii As Integer = 0 To 0
'                    Dim fda_extract_active As New CFS_FOOD_FML
'                    fda_extract_active = AddValue(fda_extract_active)
'                    fda_extract_active.FML_QTY = 0
'                    fff.Add(fda_extract_active)


'                Next
'                fda_extract.CFS_FOOD_FML_LIST = fff

'                MAIN_XML.LIST_CFS_FOOD_PRODUCT_LIST_NO.Add(fda_extract)
'            Next
'        End If

'        'End If

'        'ทำการ สร้าง XML
'        Dim objStreamWriter As New StreamWriter(Path_XML)
'        Dim x As New XmlSerializer(MAIN_XML.GetType)
'        x.Serialize(objStreamWriter, MAIN_XML)
'        objStreamWriter.Close()


'        convert_XML_To_PDF(Path_PDF, Path_XML, PDF_TEMPLATE)

'        XML_PATH_PDF = Path_PDF



'    End Sub

'    'Public Function GEN_XML_READ(ByVal IDA As Integer, ByVal newcode As String, ByVal rgtno As String, ByVal rgttpcd As String, ByVal pvncd As String)
'    '    'Dim TR_ID As Integer = 0
'    '    'Dim FAL_IDA As Integer = 0
'    '    Dim class_xml_read As New XML_CFS_DRUG_CER
'    '    Dim dao_h As New DAO.CFS.TB_CER_DURG_HEAD
'    '    dao_h.GetDataby_IDA(IDA)
'    '    class_xml_read.DATA_CER_DURG = dao_h.fields
'    '    Dim bao_sp As New BAO_STOREPROCUDURE.CPN

'    '    class_xml_read.DT_SHOW.DT1 = bao_sp.SP_SYSISOCNT()
'    '    class_xml_read.DT_SHOW.DT2 = bao_sp.SP_MAINPERSON_CTZNO(XML_CITIZEN_ID)
'    '    class_xml_read.DT_SHOW.DT3 = bao_sp.SP_MAINCOMPANY_LCNSID(XML_LCNSID)
'    '    class_xml_read.DATE_PERSENT = Date.Now.ToString("dd MMMM yyyy", ThaiCulture)
'    '    Dim dt As DataTable = bao_sp.SP_MAINCOMPANY_LCNSID(XML_LCNSID)
'    '    For Each dr As DataRow In dt.Rows
'    '        class_xml_read.ADDR_REGIS_ENG_NAME = dr("engnm")
'    '        class_xml_read.ADDR_REGIS_ENG = dr("engnm") & vbCrLf & dr("engaddr") & " " & dr("engsoi") & "  " & dr("engroad") & "  " & dr("engthmblnm") & "  " & dr("engamphrnm") & "  " & dr("engchngwtnm") & " Tel. " & dr("tel")
'    '        class_xml_read.ADDR_REGIS_ENG_NO_NAME = dr("engaddr") & " " & dr("engsoi") & "  " & dr("engroad") & "  " & dr("engthmblnm") & "  " & dr("engamphrnm") & "  " & dr("engchngwtnm") & " Tel. " & dr("tel")
'    '    Next
'    '    'If _XML_PROCESS_ID = "940002" Then
'    '    Dim bao_register As New BAO_STOREPROCUDURE.DRUG
'    '    class_xml_read.DT_SHOW.DT4 = bao_register.SP_GET_DRUG_drrgt_IDA(newcode)

'    '    'Dim bao_get_value_regis As New BAO_STOREPROCUDURE.DRUG
'    '    'Dim dt_regis As New DataTable
'    '    'Dim rgtptcd As String = ""
'    '    'Dim rgtno As Integer = 0
'    '    'dt_regis = bao_get_value_regis.SP_GET_DRUG_drrgt_IDA(_MAIN_IDA)
'    '    'For Each value2 As DataRow In dt_regis.Rows
'    '    '    rgtptcd = value2()
'    '    '    rgtno = value2()
'    '    'Next



'    '    'End If

'    '    Dim rcvno As String = ""
'    '    Dim drgtpcd As String = ""

'    '    Dim substance_con As String = ""
'    '    Dim unit_string As String = ""
'    '    Dim count_substance As Integer = 0
'    '    Dim dt_nrrgt As DataTable = bao_register.SP_GET_DRUG_drrgt_IDA(newcode)
'    '    For Each value As DataRow In dt_nrrgt.Rows
'    '        rcvno = value("rcvno")
'    '        drgtpcd = value("drgtpcd")
'    '    Next

'    '    Dim bao_get_EQ As New BAO_STOREPROCUDURE.DRUG
'    '    class_xml_read.DT_SHOW.DT5 = bao_get_EQ.SP_GET_EQ_TO(rgtno, rgttpcd)

'    '    class_xml_read.DT_SHOW.DT6 = bao_register.SP_GET_DRREXP_DROPDOWN(rgtno, rgttpcd, rcvno)
'    '    class_xml_read.DT_SHOW.DT7 = bao_register.SP_GET_FML_EACH_UNIT(rgtno, rgttpcd, drgtpcd, pvncd)
'    '    Dim unit_eq As Integer = class_xml_read.DT_SHOW.DT5.Rows.Count
'    '    class_xml_read.FML_UNIT = unit_eq
'    '    'ทำการ สร้าง XML



'    '    Return class_xml_read
'    'End Function

'    Public Sub BIND_PDF(ByVal IDA As Integer)
'        Dim TR_ID As Integer = 0
'        Dim FAL_IDA As Integer = 0
'        Dim GEN_XML As New GEN_XML.GEN_XML_CER_FOOD_HEAD

'        Dim MAIN_XML As New XML_CFS_FOOD_CER
'        MAIN_XML = GEN_XML.GEN_XML()

'        Dim dao_h As New DAO.CFS.TB_CFS_FOOD_HEAD
'        dao_h.GetDataby_IDA(IDA)

'        Dim bao_sp As New BAO_STOREPROCUDURE.CPN

'        MAIN_XML.DT_SHOW.DT1 = bao_sp.SP_SYSISOCNT()
'        MAIN_XML.DT_SHOW.DT2 = bao_sp.SP_MAINPERSON_CTZNO(dao_h.fields.CITIZEN_DOWNLOAD)
'        MAIN_XML.DT_SHOW.DT3 = bao_sp.SP_MAINCOMPANY_LCNSID(dao_h.fields.LCNSID)



'        'Dim bao_food As New BAO_STOREPROCUDURE.CMT
'        'MAIN_XML.DT_SHOW.DT4 = bao_food.SP_LOCATION_GETDATA(FAL_IDA)

'        XML_CFS_FOOD_HEADs = MAIN_XML

'        Dim dao_pdftemplate As New DAO.CFS.TB_MAS_TEMPLATE_PROCESS
'        dao_pdftemplate.GetDATAby_PROCESS_ID(_XML_PROCESS_ID, _XML_STATUS_ID, _XML_PREVIEW_PDF)

'        Dim paths As String = _PATH_FILE
'        Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
'        Dim PDF_OUTPUT As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("FA", _XML_PROCESS_ID, Date.Now.Year, TR_ID)
'        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("FA", _XML_PROCESS_ID, Date.Now.Year, TR_ID)

'        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _XML_PROCESS_ID, PDF_OUTPUT) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
'        'ทำการ สร้าง XML
'        'Dim objStreamWriter As New StreamWriter(Path_XML)
'        'Dim x As New XmlSerializer(class_xml.GetType)
'        'x.Serialize(objStreamWriter, class_xml)
'        'objStreamWriter.Close()


'        'convert_XML_To_PDF(PDF_OUTPUT, Path_XML, PDF_TEMPLATE)

'        XML_PATH_PDF = PDF_OUTPUT

'    End Sub


'End Class
