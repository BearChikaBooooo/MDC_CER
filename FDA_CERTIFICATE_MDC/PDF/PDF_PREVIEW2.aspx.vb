Public Class PDF_PREVIEW2
    Inherits System.Web.UI.Page

    Private _FileName As String


    Sub runQuery()
        _FileName = Request.QueryString("filename")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            load_pdf(_FileName)
        End If

    End Sub

    Private Sub load_pdf(ByVal FilePath As String)
        Response.ContentType = "Application/pdf"
        Response.WriteFile(FilePath)
        Response.End()
    End Sub

End Class