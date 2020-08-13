Imports System.Threading
Imports System.Globalization

Namespace GEN_XML

    Public Class GEN_XML_CER_FOOD_HEAD_READ
        Dim ThaiCulture As New CultureInfo("th-TH")
        Dim UsaCulture As New CultureInfo("en-US")
        Public Function GEN_XML(Optional rows As Integer = 0) As XML_CFS_FOOD_CER

            Dim class_xml As New XML_CFS_FOOD_CER

            class_xml.DATA_CER_FOOD = AddValue(class_xml.DATA_CER_FOOD)

            Return class_xml


        End Function
        Public Function GEN_XML_READ(ByVal IDA As Integer, ByVal rgtno As String, ByVal rgttpcd As String, ByVal pvncd As String)
            'Dim TR_ID As Integer = 0
            'Dim FAL_IDA As Integer = 0
            Dim class_xml_read As New XML_CFS_FOOD_CER
            Dim dao_h As New DAO.CFS.TB_CFS_FOOD_HEAD
            dao_h.GetDataby_IDA(IDA)

            class_xml_read.DATA_CER_FOOD = dao_h.fields
            'class_xml_read.DATA_CER_DURG.APPROVED_DATE = Convert.ToDateTime(dao_h.fields.APPROVED_DATE).ToString("dd MMMM yyyy", UsaCulture)
            Dim bao_sp As New BAO_STOREPROCUDURE.CPN

            class_xml_read.DT_SHOW.DT1 = bao_sp.SP_SYSISOCNT()
            class_xml_read.DT_SHOW.DT2 = bao_sp.SP_MAINPERSON_CTZNO(dao_h.fields.CITIZEN_UPLOAD)
            class_xml_read.DT_SHOW.DT3 = bao_sp.SP_MAINCOMPANY_LCNSID(dao_h.fields.LCNSID)
            class_xml_read.DATE_PERSENT = Date.Now.ToString("dd MMMM yyyy", ThaiCulture)
            Dim dt As DataTable = bao_sp.SP_MAINCOMPANY_LCNSID(dao_h.fields.LCNSID)
            For Each dr As DataRow In dt.Rows
                class_xml_read.ADDR_REGIS_ENG_NAME = dr("engnm")
                class_xml_read.ADDR_REGIS_ENG = dr("engnm") & vbCrLf & dr("engaddr") & " " & dr("engsoi") & "  " & dr("engroad") & "  " & dr("engthmblnm") & "  " & dr("engamphrnm") & "  " & dr("engchngwtnm") & " Tel. " & dr("tel")
                class_xml_read.ADDR_REGIS_ENG_NO_NAME = dr("engaddr") & " " & dr("engsoi") & "  " & dr("engroad") & "  " & dr("engthmblnm") & "  " & dr("engamphrnm") & "  " & dr("engchngwtnm") & " Tel. " & dr("tel")
            Next
           

            Return class_xml_read
        End Function
    End Class
    Public Class GEN_XML_CER_FOOD_HEAD

        Public Function GEN_XML(Optional rows As Integer = 0) As XML_CFS_FOOD_CER

            Dim class_xml As New XML_CFS_FOOD_CER

            class_xml.DATA_CER_FOOD = AddValue(class_xml.DATA_CER_FOOD)


            Return class_xml
        End Function
    End Class
End Namespace
