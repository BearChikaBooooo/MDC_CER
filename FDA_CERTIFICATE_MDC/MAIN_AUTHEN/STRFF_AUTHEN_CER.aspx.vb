Public Class STRFF_AUTHEN_CER
    Inherits System.Web.UI.Page
    Private _TOKEN As String
    Private _CLS As New CLS_SESSION  'เกี่ยวเนื่องกับ บรรทัดที่ 30 _CLS ตัวนี้มันจะไปดึงที่เก็บข้อมูลมาจาก CLASS CLS_SESSION

    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        '_TOKEN = "yORAj5mMYr0OTLOYaauEygUU"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            RunQuery()
            token()
        End If
    End Sub
    Sub token()

        Dim token As String = _TOKEN

        Dim ws As New WS_AUTHEN.Authentication
        Dim xml As String = ""
        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
            Response.Redirect("https://privus.fda.moph.go.th")
        End If
        xml = ws.Authen_Login(token)
        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = token
        _CLS.Groups = clsxml.Get_Value_XML("Groups") 'GET_Value_XML มันไปเกี่ยวเนื่องกับ Class CLS_XML จะไปดึงตัว GET_Value_XML มาใช้
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        '  _CLS.LCNSID = GET_LCNSID(_CLS.CITIZEN_ID_AUTHORIZE)
        '_CLS.LCNSID = 1032

        Session("CLS") = _CLS
        '   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")
        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            ' Response.Redirect("FRM_CHOOSE.aspx")

            _CLS.STAFF_TYPE = 1
            Session("CLS") = _CLS
            If _CLS.Groups = "265184" Then 'เจ้าหน้าที่พิจารณา
                Response.Redirect("../STAFF_MAIN_CER/FRM_STAFF_MAIN_CER.aspx")

            Else
                Response.Redirect("../CUSTOM_MAIN_CER/FRM_MAIN_LIST_CER.aspx")
            End If



            'If _CLS.Groups = "265184" Then 'เจ้าหน้าที่พิจารณา
            '    If check_permis(1) = True Then
            '        _CLS.STAFF_TYPE = 1
            '        Session("CLS") = _CLS
            '        Response.Redirect("../STAFF_MIAN_CER/FRM_MAIN_LIST_CER.aspx")
            '    Else
            '        alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
            '    End If
            'ElseIf _CLS.Groups = "75281" Then 'เจ้าหน้าที่ทวนสอบ
            '    If check_permis(2) = True Then
            '        _CLS.STAFF_TYPE = 2
            '        Session("CLS") = _CLS
            '        Response.Redirect("../STAFF_MIAN_CER/FRM_STAFF_MAIN_CER.aspx")
            '    Else
            '        alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
            '    End If
            'ElseIf _CLS.Groups = "65628" Then 'หัวหน้าอนุมัติ
            '    If check_permis(3) = True Then
            '        _CLS.STAFF_TYPE = 3
            '        Session("CLS") = _CLS
            '        Response.Redirect("../STAFF_MIAN_CER/FRM_STAFF_MAIN_CER.aspx")
            '    Else
            '        alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
            '    End If

            'ElseIf _CLS.Groups = "230108" Then
            '    '_CLS = bao_info.load_name(_CLS)
            '    Session("CLS") = _CLS
            '    Response.Redirect("../REPLACEMENT/REPLACEMENT_STATION.aspx")
            'Else

            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ท่านไม่มีสิทธ์ในการใช้งานระบบนี้');window.location.href = 'http://privus.fda.moph.go.th';", True)
            '    Response.Redirect("http://privus.fda.moph.go.th")
            'End If


            'Response.Redirect("FRM_CHOOSE_STAFF.aspx")
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

    End Sub

    Private Function GET_LCNSID(ByVal IDENTIFY As String) As Integer
        Dim dao_cpn As New DAO_CPN.clsDBsyslcnsid
        dao_cpn.GetDataby_IDENTIFY(IDENTIFY)
        Dim lcnsid As Integer = dao_cpn.fields.ID_main
        Return lcnsid

    End Function
    Public Function check_permis(ByVal permis As Integer)
        Dim check As Boolean = True
        Dim dao_get_staff As New DAO.CFS.TB_CER_FOOD_STAFF
        dao_get_staff.GetDataby_CITIXEN_TYPE(_CLS.CITIZEN_ID, permis)
        If dao_get_staff.fieldes.IDA = 0 Then
            check = False
        End If
        Return check
    End Function
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

End Class