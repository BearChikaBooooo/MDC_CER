Imports System.Threading
Imports System.Globalization

Namespace GEN_XML

    Public Class GEN_XML_CER_MDC

#Region "field"
        Private _IDA As Integer
        Public Property IDA() As Integer
            Get
                Return _IDA
            End Get
            Set(ByVal value As Integer)
                _IDA = value
            End Set
        End Property

        Private _preview As String
        Public Property preview() As String
            Get
                Return _preview
            End Get
            Set(ByVal value As String)
                _preview = value
            End Set
        End Property

        Private _LCNSID As String
        Public Property LCNSID() As String
            Get
                Return _LCNSID
            End Get
            Set(ByVal value As String)
                _LCNSID = value
            End Set
        End Property


        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _LCNSID_CUSTOMER As String
        Public Property LCNSID_CUSTOMER() As String
            Get
                Return _LCNSID_CUSTOMER
            End Get
            Set(ByVal value As String)
                _LCNSID_CUSTOMER = value
            End Set
        End Property

        Private _CITIZEN_ID_AUTHORIZE As String
        Public Property CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property


        Private _rgttpcd As String
        Public Property rgttpcd() As String
            Get
                Return _rgttpcd
            End Get
            Set(ByVal value As String)
                _rgttpcd = value
            End Set
        End Property

        Private _PVNCD As String
        Public Property PVNCD() As String
            Get
                Return _PVNCD
            End Get
            Set(ByVal value As String)
                _PVNCD = value
            End Set
        End Property

        Private _lctida As Integer
        Public Property lctida() As Integer
            Get
                Return _lctida
            End Get
            Set(ByVal value As Integer)
                _lctida = value
            End Set
        End Property

        Private _status_id As Integer
        Public Property status_id() As Integer
            Get
                Return _status_id
            End Get
            Set(ByVal value As Integer)
                _status_id = value
            End Set
        End Property

        Private _cer_no As Integer
        Public Property cer_no() As Integer
            Get
                Return _cer_no
            End Get
            Set(ByVal value As Integer)
                _cer_no = value
            End Set
        End Property

        Private _product_name As String
        Public Property product_name() As String
            Get
                Return _product_name
            End Get
            Set(ByVal value As String)
                _product_name = value
            End Set
        End Property

        Private _product_detail As String
        Public Property product_detail() As String
            Get
                Return _product_detail
            End Get
            Set(ByVal value As String)
                _product_detail = value
            End Set
        End Property

        Private _country_name As String
        Public Property country_name() As String
            Get
                Return _country_name
            End Get
            Set(ByVal value As String)
                _country_name = value
            End Set
        End Property

#End Region

        Dim ThaiCulture As New CultureInfo("th-TH")
        Dim UsaCulture As New CultureInfo("en-US")
        Public Function GEN_XML(Optional rows As Integer = 0) As XML_CER_MDC

            Dim cls_xml As New XML_CER_MDC
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            dao.Getdata_byid(IDA)
            If dao.fields.IDA = 0 Then
                cls_xml.DT_CER_MDCs = AddValue(cls_xml.DT_CER_MDCs)

                cls_xml.DT_CER_MDCs.export_amount = 1
            Else
                cls_xml.DT_CER_MDCs = dao.fields

            End If

            Dim dao2 As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
            dao2.Getdata_byfk_ida(IDA)
            'Dim test = dao2.fields.FK_IDA
            If dao2.fields.IDA = 0 Then
                For i As Integer = 0 To rows
                    Dim dt As New MDC_CER_COUNTRY
                    dt = AddValue(dt)
                    dt.export_amount = 1
                    cls_xml.DT_CER_MDC_COUNTRies.Add(dt)
                Next
            Else
                For Each dao2.fields In dao2.datas
                    Dim dt As New MDC_CER_COUNTRY
                    dt = dao2.fields
                    cls_xml.DT_CER_MDC_COUNTRies.Add(dt)
                Next
            End If
            Dim dao4 As New DAO_MDC_CER.TB_MDC_CER_LCNNO
            dao4.Getdata_by_fk_ida(IDA)
            If dao4.fields.IDA = 0 Then
                For i As Integer = 0 To rows
                    Dim dt As New MDC_CER_LCNNO
                    dt = AddValue(dt)
                    cls_xml.DT_CER_MDC_LCNNOs.Add(dt)
                Next
            Else
                For Each dao4.fields In dao4.datas
                    Dim dt As New MDC_CER_LCNNO
                    dt = dao4.fields
                    cls_xml.DT_CER_MDC_LCNNOs.Add(dt)
                Next
            End If

            Dim dao3 As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
            dao3.Getdata_byfk_ida(IDA)
            'test = dao3.fields.FK_IDA
            If dao3.fields.IDA = 0 Then
                For i As Integer = 0 To rows
                    Dim dt As New MDC_CER_SUBTYPE
                    dt = AddValue(dt)
                    cls_xml.DT_CER_MDC_SUBTYPEs.Add(dt)
                Next
            Else
                For Each dao3.fields In dao3.datas
                    Dim dt As New MDC_CER_SUBTYPE
                    dt = dao3.fields
                    cls_xml.DT_CER_MDC_SUBTYPEs.Add(dt)
                Next
            End If

            Dim dao5 As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
            dao5.Getdata_byfk_ida(IDA)
            'test = dao3.fields.FK_IDA
            If dao5.fields.IDA = 0 Then
                For i As Integer = 0 To rows
                    Dim dt As New MDC_CER_PRODUCT
                    dt = AddValue(dt)
                    cls_xml.DT_CER_MDC_PRODUCTs.Add(dt)
                Next
            Else
                For Each dao5.fields In dao5.datas
                    Dim dt As New MDC_CER_PRODUCT
                    dt = dao5.fields
                    cls_xml.DT_CER_MDC_PRODUCTs.Add(dt)
                Next
            End If

            cls_xml.product_detail = product_detail
            cls_xml.product_name = product_name
            'Dim dao5 As New DAO_MDC_CER.GET_TB_IRGT
            'dao5.Getdata_byrgtno_display(IDA)
            'If dao5.fields.rgtno_display Is Nothing Or "" Then
            '    For i As Integer = 0 To rows
            '        Dim dt As New irgt
            '        dt = AddValue(dt)
            '        cls_xml.DT_IRGTs.Add(dt)
            '    Next
            'Else
            '    For Each dao5.fields In dao5.datas
            '        Dim dt As New irgt
            '        dt = dao5.fields
            '        cls_xml.DT_IRGTs.Add(dt)
            '    Next
            'End If

            'cls_xml.write_date = dao.fields.write_date.Value.Day & "/" & convert_month(dao.fields.write_date.Value.Month) & "/" & CONVERT_THAI_YEAR(dao.fields.write_date.Value.Year)
            If dao.fields.IDA <> 0 Then
                cls_xml.write_date = cls_xml.DT_CER_MDCs.write_date.Value.Day & " " & convert_month_thai(cls_xml.DT_CER_MDCs.write_date.Value.Month) & " " & CONVERT_THAI_YEAR(cls_xml.DT_CER_MDCs.write_date.Value.Year)

            End If




            '____________________MASTER__________________
            Dim bao_mas As New BAO_MASTER
            cls_xml.DT_MASTER.DT3 = bao_mas.SP_MDC_CER_COUNTRY()
            '____________________Show_ __________________

            Dim bao_show As New BAO_SHOW
            Try
                cls_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID)
                cls_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID, 1) 'สถานที่หลัก
            Catch ex As Exception
            End Try

            Return cls_xml

        End Function


    End Class

End Namespace
