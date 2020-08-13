Public Class WebForm2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION


    Private _TOKEN As String
    Sub RunQuery()
        '    _TOKEN = Request("Token").ToString()
        _TOKEN = "PASS"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' session_clear()
            RunQuery()
            token()
            ' load_lcnsid_customer()
        End If
    End Sub
    Sub token()
        Dim token As String = _TOKEN

        Dim ws As New WS_AUTHEN3.Authentication
        Dim xml As String = ""


        'If token = "" Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
        '    Response.Redirect("http://privus.fda.moph.go.th")
        'End If
        'xml = ws.Authen_Login(token)
        'Dim cls_xml As New Cls_XML
        'cls_xml.ReadData(xml)

        Dim clsxml As New Cls_XML
        ''clsxml.ReadData(xml)
        ''_CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        ''_CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        ''_CLS.TOKEN = token
        ''_CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        ''_CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        ''_CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        ''_CLS.THANM = clsxml.Get_Value_XML("Name")
        ''_CLS.STAFF_CTZNO = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID = "1100201068017"
        _CLS.CITIZEN_ID_AUTHORIZE = "0000000000000"
        _CLS.TOKEN = token
        _CLS.Groups = "19978"
        _CLS.System_ID = "2082"
        _CLS.PVCODE = "19"
        _CLS.thanm = "กฤษดา เหมทิวากร"
        _CLS.IDA = 28462
        _CLS.LCNSID_CUSTOMER = "252565"
        Session("CLS") = _CLS
        'Response.Redirect("../CUSTOM_MAIN_CER/FRM_MAIN_LIST_CER.aspx")

        Response.Redirect("../STAFF_MAIN_CER/FRM_STAFF_MAIN_CER.aspx")
        ''   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")
        'Dim code As String = clsxml.Get_Value_XML("CODE")

        ''If code = "900" Then
        ''    Response.Redirect("STAFF_HOME/FRM_STAFF_HOME.aspx")
        ''ElseIf code = "100" Then
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ''ElseIf code = "101" Then
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ''ElseIf code = "102" Then
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ''Else
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ''End If

        '   Dim clsxml As New Cls_XML
        'clsxml.ReadData(xml)
        '_CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        '_CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        '_CLS.TOKEN = token
        '_CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        '_CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        '_CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        '_CLS.THANM = clsxml.Get_Value_XML("Name")
        '_CLS.STAFF_CTZNO = clsxml.Get_Value_XML("Citizen_ID")
        '_CLS.CITIZEN_ID = "1100400181875"
        '_CLS.CITIZEN_ID_AUTHORIZE = "1100400181875"
        '_CLS.TOKEN = token
        '_CLS.GROUPS = "63799"
        '_CLS.SYSTEM_ID = "5304"
        '_CLS.PVCODE = "10"
        '_CLS.THANM = "นายภูวดล ตีรณะชัยดีกุล"
        '_CLS.STAFF_CTZNO = "1100400181875"
        'Session("CLS") = _CLS
        'Response.Redirect("STAFF_HOME/FRM_STAFF_HOME_CUSTOM.aspx")
        ''   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")
        'Dim code As String = clsxml.Get_Value_XML("CODE")

    End Sub
    Sub load_home()
        'Session("TOKEN") = _TOKEN
        '  Response.Redirect("../MAIN/FRM_CHECK_TOKEN.aspx")
    End Sub
End Class
