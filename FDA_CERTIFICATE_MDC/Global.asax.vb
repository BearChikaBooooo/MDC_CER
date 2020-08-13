Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs) 'สั่งให้ Session_Start ทำงาน
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs) 'หลังจากกดกค้นหาข้อมูลจากเลขนิติ กับเลขบัตรก็จะเข้ามาทำตรงนี้ต่อ Step 1
        'sender จะรับ {ASP._Gobal_aspx}เข้ามา ปล.  .aspx คือ From ที่ Render ได้
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs) 'หลังจากกดกค้นหาข้อมูลจากเลขนิติ กับเลขบัตรก็จะเข้ามาทำตรงนี้ต่อ Step 2
        'sender จะรับ {ASP._Gobal_aspx}เข้ามา ปล.  .aspx คือ From ที่ Render ได้
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        Dim _cls As CLS_SESSION
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
        End If
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim err As String = "<b>Error Caught in Page_Error event</b><hr><br>" & "<br><b>Error in: </b>" + Request.Url.ToString() & "<br><b>Error Message: </b>" + objErr.Message.ToString() & "<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString()
        Dim ws As New WS_ERROR_CENTER2.WS_ERROR_CENTER
        ws.INSERT_ERROR_CENTER(Request.Url.ToString(), objErr.Message.ToString(), objErr.StackTrace.ToString(), 5, Date.Now, _CLS.CITIZEN_ID, _CLS.thanm)

        Response.Redirect("http://privus.fda.moph.go.th/")
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class