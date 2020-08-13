Imports System.IO
Imports Telerik.Web.UI

Public Class FRM_MAIN_LIST_CER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _type As Integer
    Dim bao As New BAO_MASTER
    Private _STAFF_APM As Integer = 0

    Sub runQuery() 'เป็น Function รอง เอาไว้เช็คการเข้าหน้าเว็บ ถ้าเข้ามาแบบไม่ถูกต้อง หรือมีข้อผิดพลาดอะไรก็จะเด้งกลับไปสู่หน้าหลักของ privus
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                '_CLS ถูกประกาศไว้ด้านบน
                _CLS = Session("CLS") 'เก็บ "CLS ที่รับเข้ามา"
                '_STAFF_APM ถูกประกาศไว้ด้านบน
                _STAFF_APM = Request.QueryString("STAFF_APM")

            End If
        Catch ex As Exception 'ถ้า try ด้านบนเกิดปัญหาหรือ error ก็จะเด้งกลับไปหน้าหลักของ Privus เหมือนกัน
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
        '_type ให้ Convert เป็น Int 32 เพื่อค่าที่รับเข้ามาเป็น String เอามาแปลงเป็นตัวเลข 
        _type = Convert.ToInt32(Request.QueryString("type"))
        _ProcessID = 509000 'กำหนดให้ _ProcessID = 509000 , 509000 คือรหัสของCer หนังสือรับรองการส่งออกเครื่องมือแพทย์/ผลิตเพื่อการส่งออก
    End Sub
    ' Page_Load รับ sender เป็น Object กับรับ e เป็น event                                      Handles Me.Lod คือ มันจะเรียกตัวมันเอง
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 'เป็น Function หลักที่เอาไว้โหลดเพจ 
        runQuery() 'เรียก Function ที่สร้างไว้ด้านบนมาทำงานในหน้า Page โหลดเพื่อทำการเช็คการเข้าหน้าเว็บ
        hid_token.Value = _CLS.TOKEN 'ซ่อนเลข TOKEN ไว้
        If Not IsPostBack Then 'ถ้าไม่ใช่ IsPostBack ก็ให้ทำด้านล่างต่อ 
            runQuery()
            RadGrid1.Rebind()
            load_HL() 'เรียก Function load_Hl ที่สร้างไว้ด้านล่างมาใช้
        End If
    End Sub

    Private Sub load_HL() 'HL ย่อมาจาก HyperLink เป็น function ที่กระทำเกี่ยวกับปุ่มชำระเงิน
        Dim bao As New BAO.AppSettings 'ให้ประกาศ New BAO ขึ้นมาใหม่เพื่อเรียกใช้ BAO ใน Function นี้ BAO.AppSetings คืออะไร ?

        If bao._STATUS_DEMO = "1" Then 'ถ้าStatus ของ bao ที่ _STATUS_DEMO ที่รับมา = 1 จะให้ทำต่อด้านล่าง 
            'สามารถกด F12 เพื่อดูว่า _STATUS_DEMO มาจากไหน        STATUS_DEMO รับค่าเข้ามาอย่างไร ที่ไหน??

            'hl_pay คือปุ่มชำระเงิน หากคลิกที่ปุ่มนี้ก็จะเด้งไปหน้าชำระเงิน
            hl_pay.NavigateUrl = "http://platba.FDA.MOPH.GO.TH/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&status_id=1&system=mdc"
            '.NavigaterURL เป็น Function ที่มีอยู่แล้ว เพื่อที่จะลิงค์ไปยังหน้าอื่น ๆ
            hl_pay.Target = "_blank"
        ElseIf bao._STATUS_DEMO = "0" Then
            hl_pay.NavigateUrl = "http://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "&status_id=1&system=mdc"
            hl_pay.Target = "_blank"
        End If
    End Sub


    Protected Sub BTN_DOWN_Click(sender As Object, e As EventArgs) Handles BTN_DOWN.Click 'ปุ่ม Function เอาไว้ Download คำขอ

        Dim cls_work As New cls_holiday
        If cls_work.CHK_HOLDATE(DateAdd(DateInterval.Day, 0, Date.Now)) = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ประชาสัมพันธ์ งดรับคำขอในวันหยุดราชการและวันหยุดนักขัตฤกษ์\n" &
                    "งดรับคำขอในวันหยุดราชการและวันหยุดนักขัตฤกษ์ เช่นกรณีวันหยุดราชการในวันศุกร์ระบบรับคำขอถึง 16:30 น. หลังจากนั้นระบบจะเริ่มรับคำขออีกครั้งในวันจันทร์หรือวันทำการถัดไปตั้งแต่ 8:30 น." & "');", True)
        Else
            Dim bind_pdf As New BIND_PDF_MDC_CER 'ประกาศ New BIND_PDF_MDC_CER เพื่อจะเอาสิ่งที่อยู่ใน Class นั้นมาเรียกใช้ใน Function นี้
            Dim citizen_bsn As String 'ประกาศ citizen_bsn เป็น string จะเอาไว้เก็บเลขบัตรประชาชน Token ที่เรา Login เข้ามา
            If _STAFF_APM = 1 Then '_STAFF_APM ประกาศไว้อยู่ด้านบน กำหนดให้เป็น Integer มีค่าเป็น 0 สร้างเป็นตัวแปร Private ไว้ใช้เฉพาะกับ Class นี้ 
                citizen_bsn = _CLS.CITIZEN_ID_BSN 'กำหนดให้ citizen_bsn เป็นเลขเดียวกับรหัสบัตรประชาชนที่ Login เข้ามา
                'มาจาก Private _CLS As New CLS_SESSION ที่เราประกาศไว้ด้านบน
            Else
                citizen_bsn = _CLS.CITIZEN_ID     'มาจาก Private _CLS As New CLS_SESSION ที่เราประกาศไว้ด้านบน
            End If
            'bind_pdf รับข้อมูลจาก Table เข้ามา สามารถเข้าไปดูใน Table CER ได้ว่าส่งอะไรเข้ามาบ้างตามชื่อที่รับเข้ามาด้านล่าง
            bind_pdf.Bind_PDF(_ProcessID, citizen_bsn, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, _type, _CLS.IDA)
            _CLS.PATH_PDF = bind_pdf.XML_PATH_PDF 'ตัวนี้จะไปดึง Templete ของไฟล์ PDE CER มาจาก Path
            _CLS.FILENAME_PDF = bind_pdf.PDF_NAME 'ตัวนี้จะเป็นตัวกำหนดชื่อของไฟล์ PDF 

            Session("CLS") = _CLS
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
        End If
    End Sub


    Protected Sub BTN_UP_Click(sender As Object, e As EventArgs) Handles BTN_UP.Click 'Function ปุ่มเอาไว้ Upload คำขอ
        Dim cls_work As New cls_holiday
        If cls_work.CHK_HOLDATE(DateAdd(DateInterval.Day, 0, Date.Now)) = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ประชาสัมพันธ์ งดรับคำขอในวันหยุดราชการและวันหยุดนักขัตฤกษ์\n" &
                    "งดรับคำขอในวันหยุดราชการและวันหยุดนักขัตฤกษ์ เช่นกรณีวันหยุดราชการในวันศุกร์ระบบรับคำขอถึง 16:30 น. หลังจากนั้นระบบจะเริ่มรับคำขออีกครั้งในวันจันทร์หรือวันทำการถัดไปตั้งแต่ 8:30 น." & "');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_POPUP_UPLOAD.aspx?type=" & _type & "&rgtida=" & _CLS.IDA & "&process_id=" & _ProcessID & "&STAFF_APM=" & _STAFF_APM & "');", True)

        End If
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click 'Function ปุ่ม Reload หน้าใหม่ 
        runQuery()
        'load_data()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_new_pay_Click(sender As Object, e As EventArgs) Handles btn_new_pay.Click ' Funtion อะไรไม่รู้เหมือนไม่ได้ใช้

        'load_data()
        RadGrid1.Rebind()

    End Sub


#Region "radgrid"
    'Function RadGrid1_NeedDataSource เอาไว้ Show ข้อมูลใน Grid
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bao.SP_MDC_CER_SHOW(_CLS.LCNSID_CUSTOMER) 'bao.SP_MDC_CER_SHOW เก็บ lcnsid เป็น Integer ที่เป็น DataTable 
    End Sub

    'Function RadGrid1_ItemCommand รับข้อมูลเข้ามาเป็น Object กับ GridCommandEvent เป็นตัวโชว์ POPUP เวลาเรากดดูข้อมูล
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "Sel" Then
                Dim ida As String = item("IDA").Text
                Dim tr_id As String = item("TR_ID").Text
                Dim urls As String = "FRM_POPUP_CONFRIM.aspx?IDA=" & ida & "&type=" & _type & "&process_id=" & _ProcessID & "&TR_ID=" & tr_id
                Session("CLS") = _CLS
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & urls & "');", True)

                'Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups2('" & urls & "')", True)

            End If
        End If

    End Sub


#End Region
    'Function เรียกใช้ปุ่ม Button
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear() 'Clear ข้อมูลของอันเก่าที่อยู่ใน Function นี้ก่อน
        Response.ContentType = "Application/pdf" 'กำหนด ContentType เป็น Application/pdf
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.PATH_PDF)) '"C:\path\PDF_XML_CLASS\" Path นี้มาจาก Web.config
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    'Function นี้เอาไว้เช็คว่าเลขนิติกับบัตรประชาชนนี้มีข้อมูลอะไรอยู่บ้างแล้วเอาออกมาแสดง
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

                Dim item As GridDataItem
                item = e.Item
                Dim IDA As Integer = item("IDA").Text
                Dim TR_ID As String = item("TR_ID").Text
                Dim STATUS As Integer = item("STATUS_ID").Text
                Dim pay As CheckBox = e.Item.FindControl("status_pay") 'เอาไว้เช็คสเตตัสถ้าจ่ายเงินแล้วมันจะติ๊กถูกให้
                Dim dao As New DAO_MDC_CER.TB_MDC_CER
                dao.Getdata_byid(IDA) 'ตัวนี้จะทำหน้าที่ไปดึงข้อมูลในตารางมา
                If dao.fields.STATUS_PAY = "1" Then
                    pay.Checked = True 'เช็คสเตตัสถ้าเป็นจรืงจะติ๊กถูก
                End If
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub BTN_EXCEL_Click(sender As Object, e As EventArgs) Handles BTN_EXCEL.Click
    '    Dim filePath As String = "C:\path\MDC\EXCEL_TEMPLATE\MDC_PRODUCT.xls"
    '    Dim file As FileInfo = New FileInfo(filePath)
    '    If (file.Exists) Then
    '        Response.ClearContent()
    '        Response.ClearHeaders()
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
    '        Response.AddHeader("Content-Length", file.Length.ToString())
    '        Response.ContentType = "text/plain"
    '        Response.Flush()
    '        Response.TransmitFile(file.FullName)
    '        Response.End()
    '    End If
    'End Sub
End Class