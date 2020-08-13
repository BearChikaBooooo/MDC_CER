Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_CER_FOOD_UPDATE_PAYMENT
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Sub CER_FOOD_SERVICE(ByVal PROCESS_ID As String, ByVal FR_IDA As Integer)
        If PROCESS_ID = "930001" Then
            UPDATE_STATUS_PAYMENT(PROCESS_ID, FR_IDA)
        ElseIf PROCESS_ID = "930002" Then
            UPDATE_STATUS_PAYMENT(PROCESS_ID, FR_IDA)
        ElseIf PROCESS_ID = "930003" Then
            UPDATE_STATUS_PAYMENT(PROCESS_ID, FR_IDA)
        End If

    End Sub

    Public Sub UPDATE_STATUS_PAYMENT(ByVal P_ID As String, ByVal fk_ida As Integer)
        Thread.CurrentThread.CurrentCulture = New CultureInfo("th-TH")
        Dim group_no As String = "4"
        Dim run_number As String = "000000"
        Dim rcvno_last As String = ""
        Dim rcvno_last_int As Integer = 0
        Dim dao_CER_DURG_head As New DAO.CFS.TB_CFS_FOOD_HEAD
        Dim dao_gen_rcvno As New DAO.CFS.Table_GEN_RCV_NUMBER
        Dim dao_last_process As New DAO.CFS.Table_GEN_RCV_NUMBER

        dao_last_process.GetDataby_Number_last(Date.Now.ToString("yyyy"))
        If dao_last_process.fields.GENNO Is Nothing Then
            rcvno_last = "00000000"
        Else
            rcvno_last = dao_last_process.fields.GENNO
        End If
        rcvno_last_int = rcvno_last.ToString.Substring(2)
        rcvno_last_int = rcvno_last_int + 1
        dao_gen_rcvno.fields.YEAR = Date.Now.ToString("yyyy")

        dao_gen_rcvno.fields.FORMAT = "YY000000"
        dao_gen_rcvno.fields.GROUP_NO = group_no
        dao_gen_rcvno.fields.REF_IDA = fk_ida
        dao_gen_rcvno.fields.DESCRIPTION = "อาหาร YY=Year,000000=Running Number 6 digits,YY000000 = 8 digits"
        dao_gen_rcvno.insert()
        dao_gen_rcvno.GetDataby_REF_IDA(fk_ida)

        dao_gen_rcvno.fields.GENNO = dao_gen_rcvno.fields.YEAR.Substring(2) & run_number.Substring(rcvno_last_int.ToString.Length) & rcvno_last_int

        dao_gen_rcvno.update()
        '---------------------------------'
        dao_gen_rcvno.GetDataby_REF_IDA(fk_ida)


        Dim dao_head As New DAO.CFS.TB_CFS_FOOD_HEAD
        dao_head.GetDataby_IDA(fk_ida)
        dao_head.fields.STATUS_ID = 3
        Dim bao_work As New BAO.calculate_working
        bao_work.work_custom(P_ID, dao_head.fields.TR_ID, 3)
        dao_head.fields.RCVDATE = bao_work.rcvdatew

        dao_head.fields.FINISH_DATE = bao_work.findatew
        dao_head.fields.RCVNO = dao_gen_rcvno.fields.GENNO
        dao_head.update()

        Dim dao_get_process As New DAO.CFS.TB_PROCESS
        dao_get_process.GetDataby_PROCESS_ID(P_ID) 'dao_cpn.fields.EMAIL_EGA

        'Dim dao_cpn As New DAO_CPN.TB_SYSEMAIL
        'DAO_CPN.GetDataby_CITIZEN_ID(dao_head.fields.CITIZEN_UPLOAD)
        'SendMail("ท่านได้เลขรับที่  " & dao_gen_rcvno.fields.GENNO, dao_cpn.fields.EMAIL_EGA, "ท่านได้ทำการชำระเงินค่าคำขอ " & dao_get_process.fields.PROCESS_DESCRIPTION & " รหัสดำเนินการที่ " & dao_head.fields.XML_NAME & " เรียบร้อยแล้ว ")
    End Sub
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
End Class