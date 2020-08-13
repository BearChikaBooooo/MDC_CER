Public Class BIND_PDF_MDC_CER

#Region "attribute"
    Private _XML_PATH_PDF As String
        Public Property XML_PATH_PDF() As String
            Get
                Return _XML_PATH_PDF
            End Get
            Set(ByVal value As String)
                _XML_PATH_PDF = value
            End Set
        End Property

        Private _PDF_NAME As String
        Public Property PDF_NAME() As String
            Get
                Return _PDF_NAME
            End Get
            Set(ByVal value As String)
                _PDF_NAME = value
            End Set
        End Property

        Private _XML_CITIZEN_ID_AUTHORIZE As String
        Public Property XML_CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _XML_CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _XML_CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property

        Private _XML_CITIZEN_ID As String
        Public Property XML_CITIZEN_ID() As String
            Get
                Return _XML_CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _XML_CITIZEN_ID = value
            End Set
        End Property

        Private _MAIN_IDA As Integer
        Public Property MAIN_IDA() As Integer
            Get
                Return _MAIN_IDA
            End Get
            Set(ByVal value As Integer)
                _MAIN_IDA = value
            End Set
        End Property

    Private _process_id As Integer
    Public Property process_id() As Integer
        Get
            Return _process_id
        End Get
        Set(ByVal value As Integer)
            _process_id = value
        End Set
    End Property

    Private _STATUS_ID As String
        Public Property STATUS_ID() As String
            Get
                Return _STATUS_ID
            End Get
            Set(ByVal value As String)
                _STATUS_ID = value
            End Set
        End Property

        Private _preview As Integer
        Public Property preview() As Integer
            Get
                Return _preview
            End Get
            Set(ByVal value As Integer)
                _preview = value
            End Set
        End Property

    Private _XML_TYPE As Integer
    Public Property XML_TYPE() As Integer
        Get
            Return _XML_TYPE
        End Get
        Set(ByVal value As Integer)
            _XML_TYPE = value
        End Set
    End Property

    Private _RESUAL As String
        Public Property RESUAL() As String
            Get
                Return _RESUAL
            End Get
            Set(ByVal value As String)
                _RESUAL = value
            End Set
        End Property

        Private _RESULT As String
        Public Property RESULT() As String
            Get
                Return _RESULT
            End Get
            Set(ByVal value As String)
                _RESULT = value
            End Set
        End Property
#End Region



    Sub Bind_PDF(ByVal process_id As Integer, ByVal CITIZEN_ID As String, ByVal CITIEZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal type As Integer, ByVal LCTIDA As Integer)

        Dim bao_app As New BAO.AppSettings

        Dim GEN_XML_CER_MDC As New GEN_XML.GEN_XML_CER_MDC
        Dim dao_temp As New DAO_MDC_CER.TB_MAS_TEMPLATE_PROCESS
        Dim dao_down As New DAO_MDC_CER.TB_TRANSACTION_DOWNLOAD

        Dim down_id As Integer = 0
        '_________________หาชื่อ_________________________
        'Dim CITIZEN_AUTHORIZE_lcnsid As String
        'Dim CITIEZEN_ID_lcnsid As String
        'Dim CITIEZEN_ID_name As String
        'Dim CITIZEN_AUTHORIZE_name As String
        'Dim get_data As New BAO_COMMON.
        'CITIZEN_AUTHORIZE_lcnsid = get_data.get_lcnsid(CITIEZEN_ID_AUTHORIZE)
        'CITIEZEN_ID_lcnsid = get_data.get_lcnsid(CITIZEN_ID)
        'CITIEZEN_ID_name = get_data.get_name(CITIEZEN_ID_lcnsid)
        'CITIZEN_AUTHORIZE_name = get_data.get_name(CITIZEN_AUTHORIZE_lcnsid)
        '_________________จบหาชื่อ_________________________

        '____________________insert ข้อมูลการ DOWNLOAD______________________
        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = process_id
        dao_down.fields.CITIEZEN_ID = CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = CITIEZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_id = dao_down.fields.ID
        '____________________จบ insert ข้อมูลการ DOWNLOAD______________________

        '____________________GETข้อมูลและที่อยู่ของ TEMPLAETE PDF______________________
        dao_temp.GetDataby_TEMPLAETE(process_id, 1, 99, 0, 0)

        Dim path_template As String = bao_app._PATH_FILE & "PDF_TEMPLATE\" & dao_temp.fields.PDF_TEMPLATE
        'Dim path_template As String = bao_app._PATH_FILE & "PDF_TEMPLATE\CER_MDC.pdf"
        Dim path_xml As String = bao_app._PATH_FILE & dao_temp.fields.XML_PATH & "\" & NAME_XML_DOWNLOAD("MDC_CER", process_id, type, con_year(), down_id)

        'Dim path_xml As String = bao_app._PATH_FILE & "XML_TRADER_DOWNLOAD\" & NAME_XML_DOWNLOAD("MDC_CER", process_id, type, con_year(), down_id)

        Dim path_PDF As String = bao_app._PATH_FILE & dao_temp.fields.PDF_OUTPUT & "\" & NAME_PDF_DOWNLOAD("MDC_CER", process_id, type, con_year(), down_id)
        '____________________จบ GETข้อมูลและที่อยู่ของ TEMPLAETE PDF______________________

        '____________________GEN XML______________________

        GEN_XML_CER_MDC.CITIZEN_ID = CITIZEN_ID
        GEN_XML_CER_MDC.CITIZEN_ID_AUTHORIZE = CITIEZEN_ID_AUTHORIZE
        GEN_XML_CER_MDC.LCNSID = LCNSID_CUSTOMER
        GEN_XML_CER_MDC.lctida = LCTIDA
        XML_CER_MDCs = GEN_XML_CER_MDC.GEN_XML()


        'hid_filename.Value = file_PDF
        _PDF_NAME = NAME_PDF_DOWNLOAD("MDC_CER", process_id, type, con_year(), down_id)
        _XML_PATH_PDF = path_PDF 'ที่อยู่ไฟล์ PDF เพื่อดาวโหลด
        '_CLS.FILENAME_PDF_DOWNLOAD = NAME_PDF_DOWNLOAD("MDC_LCT", process_id, Date.Now, down_id) 'ชื่อที่ตั้งให้ PDF

        '____________________จบ GEN XML______________________



        '____________________รวม XML เข้ากับ PDF______________________
        LOAD_XML_PDF(path_xml, path_template, process_id, path_PDF)
        '____________________จบรวม XML เข้ากับ PDF______________________
    End Sub

    Sub Bind_PDF_PRINT(ByVal IDA As Integer)
        Try
            'Dim statusID As Integer = 0
            Dim grouptype As Integer = 0
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            dao.Getdata_byid(IDA)
            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD
            dao_up.Getdata_byid(dao.fields.TR_ID)

            '     Dim IDA As Integer = dao_la.fields.IDA
            Dim TR_ID As Integer = dao.fields.TR_ID
            Dim LCNSID As String = dao.fields.lcnsid
            'Dim CITIZEN_ID_AUTHORIZE As String = _XML_CITIZEN_ID_AUTHORIZE
            Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID
            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
            Dim statusID = dao.fields.STATUS_ID


            Dim cls_gen_xml As New GEN_XML.GEN_XML_CER_MDC

            cls_gen_xml.CITIZEN_ID = dao.fields.CITIZEN_ID
            cls_gen_xml.CITIZEN_ID_AUTHORIZE = _XML_CITIZEN_ID_AUTHORIZE
            cls_gen_xml.LCNSID = LCNSID
            cls_gen_xml.IDA = IDA
            cls_gen_xml.preview = preview
            cls_gen_xml.lctida = dao.fields.FK_IDA
            cls_gen_xml.status_id = dao.fields.STATUS_ID
            XML_CER_MDCs = cls_gen_xml.GEN_XML


            Dim dao_pdftemplate As New DAO_MDC_CER.TB_MAS_TEMPLATE_PROCESS

            If preview = 2 Or preview = 1 Then
                dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, 8, grouptype, preview)
                'ElseIf preview = 1 Then
                '    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, preview)

            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, 0)
            End If


            Dim paths As String = _PATH_FILE
            Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)

            If preview = 1 Or STATUS_ID = 1 Or STATUS_ID = 5 Then
                LOAD_XML_PDF_PREVIEW(Path_XML, PDF_TEMPLATE, _process_id, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO (ใช้ในการPREVIEW ข้อมูล)
            Else
                LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process_id, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

            End If

            _PDF_NAME = NAME_PDF("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)
            _XML_PATH_PDF = Path_PDF


        Catch ex As Exception

        End Try
    End Sub



    Sub Bind_PDF_PRINT2(ByVal IDA As Integer, ByVal pdf_type As Integer)
        Try
            'Dim statusID As Integer = 0
            Dim grouptype As Integer = 0
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            dao.Getdata_byid(IDA)
            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD
            dao_up.Getdata_byid(dao.fields.TR_ID)

            Dim dao_product_name As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
            dao_product_name.Getdata_byfk_ida(dao.fields.IDA)

            Dim dao_product_detail As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
            dao_product_detail.Getdata_byfk_ida(dao.fields.IDA)

            Dim dao_country As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
            dao_country.Getdata_byfk_ida(IDA)



            '     Dim IDA As Integer = dao_la.fields.IDA
            Dim TR_ID As Integer = dao.fields.TR_ID
            Dim LCNSID As String = dao.fields.lcnsid
            'Dim CITIZEN_ID_AUTHORIZE As String = _XML_CITIZEN_ID_AUTHORIZE
            Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID
            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
            Dim statusID = dao.fields.STATUS_ID


            Dim cls_gen_xml As New GEN_XML.GEN_XML_CER_MDC

            cls_gen_xml.CITIZEN_ID = dao.fields.CITIZEN_ID
            cls_gen_xml.CITIZEN_ID_AUTHORIZE = _XML_CITIZEN_ID_AUTHORIZE
            cls_gen_xml.LCNSID = LCNSID
            cls_gen_xml.IDA = IDA
            cls_gen_xml.preview = preview
            cls_gen_xml.lctida = dao.fields.FK_IDA
            cls_gen_xml.status_id = dao.fields.STATUS_ID
            cls_gen_xml.product_name = dao_product_name.fields.Product_Name
            cls_gen_xml.product_detail = dao_product_detail.fields.Product_Detail
            cls_gen_xml.country_name = dao_country.fields.country_name

            XML_CER_MDCs = cls_gen_xml.GEN_XML


            Dim dao_pdftemplate As New DAO_MDC_CER.TB_MAS_TEMPLATE_PROCESS

            'If preview = 2 Or preview = 1 Then
            '    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, 8, grouptype, preview)
            '    'ElseIf preview = 1 Then
            '    '    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, preview)

            'Else
            '    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, 0)
            'End If
            If pdf_type.ToString.Length = 4 Then
                dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, 1, grouptype, pdf_type)
            Else
                If pdf_type = 0 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, pdf_type)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE(_process_id, 1, statusID, grouptype, pdf_type)
                End If

            End If




            Dim paths As String = _PATH_FILE
            Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)

            'If preview = 1 Or STATUS_ID = 1 Or STATUS_ID = 5 Then
            '    LOAD_XML_PDF_PREVIEW(Path_XML, PDF_TEMPLATE, _process_id, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO (ใช้ในการPREVIEW ข้อมูล)
            'Else
            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process_id, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

            'End If

            _PDF_NAME = NAME_PDF("MDC_CER", _process_id, _XML_TYPE, con_year, TR_ID)
            _XML_PATH_PDF = Path_PDF


        Catch ex As Exception

        End Try
    End Sub

End Class
