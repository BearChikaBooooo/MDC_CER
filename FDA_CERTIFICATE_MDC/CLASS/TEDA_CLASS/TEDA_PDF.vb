Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO

Module TEDA_PDF

#Region "TEDA FORM"

    Public Function Checkfile(ByVal Path As String) As Boolean
        Dim check As Boolean = System.IO.File.Exists(Path)
        Return check
    End Function

    ''' <summary>
    ''' สำหรับ ผปก  Upload Pdf แล้ว แปลงเป็น XML
    ''' </summary>
    ''' <param name="PATH_PDF_TRADER"></param>
    ''' <param name="PATH_XML_TRADER"></param>
    ''' <remarks></remarks>
    Public Sub convert_PDF_To_XML(ByVal PATH_PDF_TRADER As String, ByVal PATH_XML_TRADER As String)
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(PATH_PDF_TRADER)
        Dim doc As New XmlDocument
        Dim ob As String
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        doc.LoadXml(ob)
        doc.Save(PATH_XML_TRADER) '"C:\path\XML_TRADER\"
    End Sub

    ''' <summary>
    ''' นำข้อมูล XML เข้า PDFTEMPLATE แล้วทำการสร้าง PDF ขึ้นมาใหม่
    ''' </summary>
    ''' <param name="PATH_PDF_XML"></param>
    ''' <param name="PATH_XML_TRADER"></param>
    ''' <param name="PATH_PDF_TEMPLATE"></param>
    ''' <remarks></remarks>
    Public Sub convert_XML_To_PDF(ByVal PATH_PDF_XML As String, ByVal PATH_XML_TRADER As String, ByVal PATH_PDF_TEMPLATE As String)
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) '"C:\path\PDF_TEMPLATE\"
            Using outputStream = New FileStream(PATH_PDF_XML, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML_TRADER)
                End Using
            End Using
        End Using

    End Sub
#End Region

#Region "property report"

    ''' <summary>
    ''' xml ของใบขอต่ออายุ
    ''' </summary>
    ''' <remarks></remarks>
    'Private _xml_renew As New CLASS_PLEXPLCN
    'Public Property xml_renew() As CLASS_PLEXPLCN
    '    Get
    '        Return _xml_renew
    '    End Get
    '    Set(ByVal value As CLASS_PLEXPLCN)
    '        _xml_renew = value
    '    End Set
    'End Property

    '''' <summary>
    '''' xml ของใบสั่งชำระ
    '''' </summary>
    '''' <remarks></remarks>
    'Private _xml_fee As New CLS_REPORT_FEE
    'Public Property xml_fee() As CLS_REPORT_FEE
    '    Get
    '        Return _xml_fee
    '    End Get
    '    Set(ByVal value As CLS_REPORT_FEE)
    '        _xml_fee = value
    '    End Set
    'End Property

    '''' <summary>
    '''' xml ของใบอนุญาต
    '''' </summary>
    '''' <remarks></remarks>
    'Private _xml_appr As CLASS_PLEXPLCN
    'Public Property xml_appr() As CLASS_PLEXPLCN
    '    Get
    '        Return _xml_appr
    '    End Get
    '    Set(ByVal value As CLASS_PLEXPLCN)
    '        _xml_appr = value
    '    End Set
    'End Property

    '''' <summary>
    '''' xml 
    '''' </summary>
    '''' <remarks></remarks>
    'Private _p_igimps_mc As GEN_XML.GEN_XML_igimps
    'Public Property p_igimps_mc() As GEN_XML.GEN_XML_igimps
    '    Get
    '        Return _p_igimps_mc
    '    End Get
    '    Set(ByVal value As GEN_XML.GEN_XML_igimps)
    '        _p_igimps_mc = value
    '    End Set
    'End Property




#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="PATH_XML">ที่อยู่ XML ที่ต้องใช้</param>
    ''' <param name="PATH_PDF_TEMPLATE">ที่อยู่ PDF TEMPLATE ที่ต้องใช้</param>
    ''' <param name="PROSESS_ID">รหัส Process</param>
    ''' <param name="PATH_PDF_OUTPUT">PDF ที่ต้องออกมาใช้งาน</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LOAD_XML_PDF(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, ByVal PROSESS_ID As String, PATH_PDF_OUTPUT As String) As String
        If Checkfile(PATH_PDF_OUTPUT) = False Then
            'ตรวจสอบว่ามี XML มั้ย
            If Checkfile(PATH_XML) = False Then
                If PROSESS_ID = 509000 Then
                    CREATE_XML_MDC_CER(PATH_XML)
                End If

            End If
            'ตรวจสอบว่ามี PDF มั้ย
            If Checkfile(PATH_PDF_TEMPLATE) = False Then
                '
            End If
            Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\MDC_CER\PDF_TEMPLATE\
                Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\MDC_CER\PDF_XML_CLASS\"
                    Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                        stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                    End Using
                End Using
            End Using
        Else

        End If

        Return PATH_PDF_OUTPUT
    End Function

    Public Function LOAD_XML_PDF_PREVIEW(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, ByVal PROSESS_ID As String, PATH_PDF_OUTPUT As String) As String

        'ตรวจสอบว่ามี XML มั้ย
        If Checkfile(PATH_XML) = False Then
            If PROSESS_ID = 509000 Then
                CREATE_XML_MDC_CER(PATH_XML)
            End If

        End If


            'ตรวจสอบว่ามี PDF มั้ย
            If Checkfile(PATH_PDF_TEMPLATE) = False Then
            '
        End If
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                End Using
            End Using
        End Using


        Return PATH_PDF_OUTPUT
    End Function


End Module
