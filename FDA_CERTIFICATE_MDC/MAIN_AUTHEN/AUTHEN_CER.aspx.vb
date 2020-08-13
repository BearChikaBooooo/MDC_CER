Imports FDA_CERTIFICATE_MDC.WS_AUTHEN

Public Class AUTHEN_CER
    Inherits System.Web.UI.Page
    Private _TOKEN As String
    Private _CLS As New CLS_SESSION

    Private Sub RunQuery()
        '_TOKEN = Request("Token").ToString()
        _TOKEN = "Z1Vd8qLp4T7HxjocJOTIPQUU"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then

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
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")

        Dim bao As New BAO_STOREPROCUDURE.CPN
        Dim bao_info As New BAO.information
        Dim dt As New DataTable
        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then

            If _CLS.Groups = "24300" Then
                _CLS = bao_info.load_name(_CLS)
                Session("CLS") = _CLS
                Response.Redirect("../STAFF_MAIN_CER/FRM_STAFF_MAIN_CER.aspx")
            ElseIf _CLS.Groups = "230108" Then
                _CLS = bao_info.load_name(_CLS)
                Session("CLS") = _CLS
                Response.Redirect("../REPLACEMENT/REPLACEMENT_STATION.aspx")
            Else
                _CLS = bao_info.load_lcnsid_customer(_CLS)
                _CLS = bao_info.load_name(_CLS)
                Session("CLS") = _CLS
                Response.Redirect("../CUSTOM_MAIN_CER/FRM_MAIN_LIST_CER.aspx")
            End If


        ElseIf code = "100" Then 'ถ้ามันเข้ารหัสนี้ก็จะให้ขึ้น Alert แจ้งเตือนว่า Token หมดอายุแล้วก็เด้งกลับไปที่หน้าหลัก
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then 'ถ้ามันเข้ารหัสนี้ก็จะให้ขึ้น Alert แจ้งเตือนว่า Token หมดอายุแล้วก็เด้งกลับไปที่หน้าหลัก
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
End Class