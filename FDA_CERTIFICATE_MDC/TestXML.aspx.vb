Imports System.Xml.Serialization
Imports System.IO

Public Class WebForm1

    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _Process_ID As Integer
    Private _Year As String
    Private _lcnida As Integer
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        '_Process_ID = Request.QueryString("subtype")
        _type = Request.QueryString("type")
        '_lcnida = Request.QueryString("rgtno")
        _Process_ID = 509000


    End Sub
    Protected Friend Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()
            'MsgBox(props.Name & " " & props.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, "", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.Decimal".ToUpper Then
                    props.SetValue(ob, 0.0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    props.SetValue(ob, Nothing, Nothing)


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_cmnm_Click(sender As Object, e As EventArgs)
        Dim filename As String = "MDC_CER_TEST.xml"
        Dim citizen_id As String = "1100201068017"
        Dim lcnsid As String = "123123"
        Dim CITIZEN_ID_AUTHORIZE As String = "123412341"


        Dim cls_xml As New XML_CER_MDC

        'cls_xml.DT_CER_MDCs = AddValue(cls_xml.DT_CER_MDCs)

        For i As Integer = 0 To 1
            Dim dt As New MDC_CER_COUNTRY
            dt = AddValue(dt)
            cls_xml.DT_CER_MDC_COUNTRies.Add(dt)
        Next



        For i As Integer = 0 To 1
            Dim dt As New MDC_CER_SUBTYPE
            dt = AddValue(dt)
            cls_xml.DT_CER_MDC_SUBTYPEs.Add(dt)
        Next

        'Dim dt2 As New MDC_CER_SUBTYPE

        'dt2 = AddValue(dt2)

        'cls_xml.DT_CER_MDC_SUBTYPEs.Add(dt2)



        '____________________MASTER__________________
        Dim bao_mas As New BAO_MASTER
        cls_xml.DT_MASTER.DT1 = bao_mas.SP_MASTER_MDC_IRSCOPE()
        cls_xml.DT_MASTER.DT2 = bao_mas.SP_MASTER_MDC_IRSCPLVL1()
        cls_xml.DT_MASTER.DT10 = bao_mas.SP_MDC_CER_BY_IDA(123123)
        '____________________Show_ __________________

        Dim bao_show As New BAO_SHOW
        Try
            cls_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(citizen_id)
            cls_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(lcnsid, 1) 'สถานที่หลัก
        Catch ex As Exception
        End Try
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, lcnsid) 'ชื่อและข้อมูลผู้ประกอบการ

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_FILE & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Unnamed2_Click(sender As Object, e As EventArgs)
        Dim bind_pdf As New BIND_PDF_MDC_CER
        bind_pdf.Bind_PDF(_Process_ID, _CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, _type, _CLS.IDA)
        _CLS.PATH_PDF = bind_pdf.XML_PATH_PDF
        _CLS.FILENAME_PDF = bind_pdf.PDF_NAME
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "closespinner();", True)
    End Sub
End Class