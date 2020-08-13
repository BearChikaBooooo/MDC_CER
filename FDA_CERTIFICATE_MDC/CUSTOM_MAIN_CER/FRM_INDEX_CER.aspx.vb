Public Class FRM_INDEX_CER
    Inherits System.Web.UI.Page
    Private re_alert As String
    Sub runQuery() 'เป็น Function รอง เอาไว้เช็คการเข้าหน้าเว็บ ถ้าเข้ามาแบบไม่ถูกต้อง หรือมีข้อผิดพลาดอะไรก็จะเด้งกลับไปสู่หน้าหลักของ privus
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                're_alert ตัวนี้ประกาศไว้ด้านบน'
                re_alert = Request.QueryString("xfd") 'ให้ re_alert นี้เก็บ"xfd" ไว้
            End If


        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If re_alert = "1" Then 'ถ้าค่า realert ที่ "xfd" รับเข้ามาจากด้านบนเป็น 1 ก็จะให้ Alert แจ้งตามด้านล่าง 
            alert("กรณี สถานที่เป็นนำเข้า ไม่อนูญาตให้ขอใบรับรอง CERTIFICATE OF MANUFACTURER.")
        End If
    End Sub

    Sub alert(ByVal text As String)
        'script ตัวนี้คือการสร้าง alert ให้เป็นแบบสวยๆแล้วใส่ข้อความ alert แจ้งออกมาจาก text
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
End Class