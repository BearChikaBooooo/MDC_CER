Imports System.IO

Public Class FRM_EXCEL
    Inherits System.Web.UI.Page
    'เป็นการสร้างหน้าเปล่า ๆ มาไว้เพื่อทำการโหลดไฟล์ Excel
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim filePath As String = "C:\path\MDC\EXCEL_TEMPLATE\MDC_PRODUCT.xls" 'ที่อยู่ของ File
        Dim file As FileInfo = New FileInfo(filePath) ' FileInfo คืออะไร เอาไว้ทำอะไร?
        'ทำไมถึงต้องสร้าง file มาใหม่ ทำไมไม่เรียกใช้ filePath ไปเลย
        If (file.Exists) Then
            Response.ClearContent()
            Response.ClearHeaders()
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name) 'เอามาใส่หัวแล้วก็ใส่ข้อความ
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "text/plain"
            Response.Flush()
            Response.TransmitFile(file.FullName)
            Response.End()
        End If
    End Sub

End Class

