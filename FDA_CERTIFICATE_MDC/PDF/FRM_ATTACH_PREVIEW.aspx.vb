Public Class FRM_ATTACH_PREVIEW
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Check_pdf()
    End Sub
    Private Sub Check_pdf()
        Dim imageUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim url() As String = imageUrl.Split("/")
        Dim filename As String = url(url.Length - 1)
        Dim saveLocation As String = _PATH_FILE & "/PDF_ATTACH/" & filename
        Dim extensionname As String = GetExtension(filename)

        If extensionname = "pdf" Then
            load_pdf(saveLocation)
        ElseIf extensionname = "jpg" Then
            load_file(saveLocation)
        End If

    End Sub
    Private Sub load_pdf(ByVal FilePath As String)
        Response.ContentType = "Application/pdf"
        Response.WriteFile(FilePath)
        Response.End()
    End Sub
    Private Sub load_file(ByVal FilePath As String)
        Response.ContentType = "Application/jpg"
        Response.WriteFile(FilePath)
        Response.End()
    End Sub
End Class