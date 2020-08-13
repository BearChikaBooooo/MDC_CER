Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization
Public Class REPLACEMENT_STATION
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private subtype As String
    Private _ProcessID As Integer
    Private _MENU_GROUP As String = ""
    Sub RunSession() 'เป็น Function ไว้เช็คเงื่อนไขการเข้าหน้าเว็บ
        Try
            If Session("CLS") Is Nothing Then
                'ถ้า Session ไม่มีค่าหรือว่างก็จะ Response Redirect ไปหน้า Privus หลัก ถ้า Session มีค่าก็จะออกไปทำ Else
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _type = Request.QueryString("type")
                subtype = Request.QueryString("subtype")
                _ProcessID = "509000" 'ให้ _ProcessID เก็บเลข 509000, 509000 คือ หนังสือรับรองการส่งออกเครื่องมือแพทย์
                _MENU_GROUP = Request.QueryString("MENU_GROUP")
            End If
        Catch ex As Exception 'Catch นี้ ถ้า Try ผิดปกติ หรือ Error ก็จะมาทำต่อใน Catch นี้
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page_Load ตัวนี้จะทำงานต่อเมื่อหลังจากที่เรากรอกข้อมูลเลขนิติกับเลขบัตรประชาชนแล้วกดปุ่มค้นหาก็จะเข้า Function นี้ เพื่อทำการ Load Page
        'sender ก็จะรับหน้าของ REPLACEMENT_STATION หรือก็คือหน้า View Designer เข้ามาโหลด
        RunSession() 'หลังจากนั้นก็จะเข้าไปเช็คใน Function RunSession()
        If Not IsPostBack Then 'ถ้า IsPostBack เป็น True ก็จะเรียก Function set_process ที่สร้างด้านล่างมาใช้
            set_process()
        End If
    End Sub

    'Function นี้จะเอาไว้เซ็ตชื่อบริษัท (ปุ่มเลือกข้อมูล)
    Private Function set_name_bsn(ByVal identify As String) As String 'identify ที่รับเข้ามาจะรับในรูปแบบ String คือจะรับเลขบัตรประชาชนที่กรอกเข้ามา
        Dim fullname As String = String.Empty 'ประกาศ fullname เป็น String เพื่อที่จะเอาค่ามาใส่เป็นตัวอักษร
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid 'ประกาศ dao_syslcnsid ให้ New  DAO_CPN.clsDBsyslcnsid ขึ้นมาใหม่เพื่อที่จะให้ใช้ Function  GetDataby_identify ในนั้นได้
            dao_syslcnsid.GetDataby_identify(identify) 'ตัวนี้จะทำการไปเรียกเลข Indentify นี้ผ่านGetDataby_identify กด F12 ที่ GetDataby_identify ไปดูได้ว่าทำงานอย่างไร
            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid) 'ตัวนี้จะทำการไปเรียกเลข lcnsid นี้ผ่าน GetDataby_lcnsid กด F12 ที่ GetDataby_lcnsid ไปดูได้ว่าทำงานอย่างไร
            Dim ws2 As New WS_Taxno_TaxnoAuthorize_2.WebService1 'ตัวนี้สร้างเพื่อให้เข้าถึง Database
            Dim ws_taxno = ws2.getProfile_byidentify(identify) 'สร้าง ws_taxno เพื่อที่จะให้ไปดึง Field ใน identify มา
            fullname = ws_taxno.SYSLCNSNMs.prefixnm & ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            'ws_taxno.SYSLCNSNM ตัวนี้จะไปเรียก prefixnm(คือคำนำหน้า)บริษัท , thanm ชื่อเต็มบริษัท ,thalnm นามสกุล(ถ้าบริษัทไหนมีนามสกุลก็เอามาด้วย)
            Dim bao_iden As New BAO_SHOW
            Dim tr1 As New DataTable 'สร้าง tr1 เป็น DataTable
            tr1 = bao_iden.SP_MAINCOMPANY_IDENTIFY(identify)
            If tr1.Rows.Count < 1 Then 'If นี้เอาไว้เช็คเลขนิติกับเลขบัตรดูว่ามีข้อมูลหรือไม่
                Dim ws_bsn As New WS_TaxnoAuthorize_BSN.WebService1
                Dim ws_taxnos = ws_bsn.insert_taxnoauthorize(identify)
                dao_syslcnsid.GetDataby_identify(identify)
                dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)
                fullname = ws_taxno.SYSLCNSNMs.prefixnm & ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                Dim bao_iden2 As New BAO_SHOW
                Dim tr2 As New DataTable
                tr2 = bao_iden2.SP_MAINCOMPANY_IDENTIFY(identify)
                If tr2.Rows.Count < 1 Then
                    fullname = tr2.Rows(0).Item("thanm").ToString
                Else
                    fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
                End If
            Else
                fullname = tr1.Rows(0).Item("thanm").ToString
            End If
        Catch ex As Exception
            Try
                Dim ws_bsn As New WS_TaxnoAuthorize_BSN.WebService1
                Dim ws_taxnos = ws_bsn.insert_taxnoauthorize(identify)
                Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
                dao_syslcnsid.GetDataby_identify(identify)

                Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
                dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

                Dim ws2 As New WS_Taxno_TaxnoAuthorize_2.WebService1

                Dim ws_taxno = ws2.getProfile_byidentify(identify)
                fullname = ws_taxno.SYSLCNSNMs.prefixnm & ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch exp As Exception
                fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
            End Try

        End Try
        Return fullname
    End Function
    Private Sub set_process() 'เป็น Function กำหนด process ว่าจะกำหนดให้เป็นอะไร จะถูกเรียกตอน Page_Load ทำงาน

        Dim process As String = "" 'สร้าง process เป็น String เพื่อที่จะได้เอาตัวอักษรเข้ามาใส่ในนี้ได้
        If _ProcessID = "509000" Then 'มาเช็ค _ProcessID ถ้าเท่ากับ 509000 ให้ทำด้านล่างต่อ
            process = "หนังสือรับรองการส่งออกเครื่องมือแพทย์" 'เก็บคำว่า "หนังสือรับรองการส่งออกเครื่องมือแพทย์" เข้าไปใส่ใน process

        End If
        lbl_process.Text = process 'ให้ lbl_process.Text เก็บคำว่า "หนังสือรับรองการส่งออกเครื่องมือแพทย์" เหมือนกับ process
    End Sub


    'Function btn_SEARCH_Click เมื่อกดปุ่มค้นหา sender ที่รับข้อมูลเป็น Object จะรับคำว่า "ค้นหา" จากปุ่มค้นหาที่เรากำหนดText ตรงหน้าDesigner เข้ามาใส่ใน sender
    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        Try
            'ตรง if นี้หากไม่ได้ป้อนข้อมูลเข้าตรงเลขนิติกับเลขบัตรเข้ามา มันจะ Alert แจ้ง "กรุณากรอกข้อมูล"
            'IsNullOrEmpty คือหากช่อง กรอกเลขนิติบุคคล/เลขบัตรประชาชน ผู้รับอนุญาตเป็น Null หรือไม่มีข้อมูลเข้ามาเป็นจริง และ ช่องที่ให้กรอกเลขบัตรประชาชน ผู้ดำเนินกิจการ เป็นจริง ก็จะทำข้างล่างต่อ
            If String.IsNullOrEmpty(txt_search.Text) = True And String.IsNullOrEmpty(txt_bsn.Text) = True Then 'txt_bsn คือช่องที่ให้กรอกเลขบัตรประชาชน ผู้ดำเนินกิจการ
                alert("กรุณากรอกข้อมูล")
            Else
                set_name_bsn(txt_search.Text.Trim) 'txt_search คือช่องที่ให้กรอกเลขนิติบุคคล/เลขบัตรประชาชน ผู้รับอนุญาต
                Dim bao As New BAO_SHOW
                rg_name.DataSource = bao.SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY("", txt_search.Text)
                rg_name.Rebind()
                rg_local.Rebind()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub rg_name_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_name.ItemCommand
        Dim bao_infor As New BAO.information
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            If set_name_bsn(txt_bsn.Text.Trim) = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน" Then
                alert("ไม่พบข้อมูล กรุณาตรวจสอบเลขบัตรประชาชน ผู้ดำเนินกิจการ")
            Else
                _CLS.CITIZEN_ID_AUTHORIZE = item("IDENTIFY").Text

                ' Session("CLS") = _CLS
                _CLS.CITIZEN_ID_BSN = txt_bsn.Text.Trim
                _CLS = bao_infor.load_lcnsid_customer(_CLS)
                _CLS = bao_infor.load_name(_CLS)
                Session("CLS") = _CLS
            End If
        End If


        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                If set_name_bsn(txt_bsn.Text.Trim) = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน" Then
                    alert("ไม่พบข้อมูล กรุณาตรวจสอบเลขบัตรประชาชน ผู้ดำเนินกิจการ")
                Else
                    _CLS.STAFF_APM = 1
                    Session("CLS") = _CLS
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "window.open('../TRADER_STATION/FRM_MAIN_STATION.aspx','_blank')", True)
                    If _ProcessID = "509000" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../CUSTOM_MAIN_CER/FRM_MAIN_LIST_CER.aspx?STAFF_APM=" & 1 & "'); ", True)
                    Else
                        Dim bao As New BAO_MASTER
                        rg_local.DataSource = bao.SP_MDC_CER_SHOW(item("lcnsid").Text)
                        rg_local.DataBind()
                    End If
                End If
            End If
        End If
    End Sub

    'Function นี้เกี่ยวข้องกับหน้า View Designer ตรงตาราง RadGrid ชื่อผู้ประกอบการ เหมือนเอาไว้เรียกข้อมูลเพื่อเอามาโชว์
    Private Sub rg_name_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_name.ItemDataBound
        Dim bao_infor As New BAO.information
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item


            Dim H As Button = e.Item.FindControl("sel") 'เป็นปุ่มเลือก หากข้อมูลแสดงออกมาให้เลือก

            _CLS.CITIZEN_ID_AUTHORIZE = item("IDENTIFY").Text 'ให้ CITIZEN_ID_AUTHORIZE เท่ากับ เลข IDENTIFY
            ' Session("CLS") = _CLS
            _CLS.CITIZEN_ID_BSN = txt_bsn.Text.Trim
            _CLS = bao_infor.load_lcnsid_customer(_CLS)
            _CLS = bao_infor.load_name(_CLS)
            Session("CLS") = _CLS

        End If
    End Sub

    Private Sub rg_local_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_local.ItemCommand
        Dim bao_infor As New BAO.information
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            _CLS.IDA = IDA
            Dim dao As New DAO_MDC_CER.TB_MDC_CER
            dao.Getdata_byid(IDA)

            If item("IDENTIFY").Text.Trim = "" Or item("IDENTIFY").Text.Trim Is Nothing Or item("IDENTIFY").Text.Trim = "&nbsp;" Then
                dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                dao.update()
            End If

            Session("CLS") = _CLS

        End If


        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "Select" Then
                Dim type As String = item("rgttpcd").Text
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "window.open('../TRADER_STATION/FRM_MAIN_STATION.aspx','_blank')", True)
                If _ProcessID = "501002" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../TRADER_EXPORT/FRM_EXPORT_MAIN1.aspx?STAFF_APM=" & 1 & "&type=" & type & "&subtype=" & subtype & "'); ", True)
                ElseIf _ProcessID = "504001" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../TRADER_MN1/FRM_MN_MAIN.aspx?STAFF_APM=" & 1 & "&type=" & type & "'); ", True)
                ElseIf _ProcessID = "505001" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../TRADER_MR1/FRM_MR_MAIN.aspx?STAFF_APM=" & 1 & "&type=" & type & "'); ", True)
                ElseIf _ProcessID = "502005" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../TRADER_MC1/FRM_MC_MAIN.aspx?STAFF_APM=" & 1 & "&type=" & type & "'); ", True)

                End If

            End If
        End If
    End Sub
End Class