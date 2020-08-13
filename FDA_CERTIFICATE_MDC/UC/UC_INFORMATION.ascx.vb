Public Class UC_INFORMATION
    Inherits System.Web.UI.UserControl
    ' Page Load คือของส่วนตัวเลยประกาศเป็น Protected คนอื่นห้ามยุ่ง
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub BindData(ByVal IDA As Integer, ByVal citizen_id As String)
        'Dim bao As New BAO.ClsDBSqlCommand
        'Dim clsds As New ClassDataset
        'bao.SP_FOOD_FALCN_LCNSID(citizen_id)
        'bao.dt = clsds.DatatableWhere(bao.dt, "ID=" & IDA)
        'For Each value As DataRow In bao.dt.Rows

        '    lbl_lct.Text = "เลขสถานที่ : " & Format_fdpdtno_lcnno(value("chngwtcd"), value("pvncd"), value("lcntypecd"), value("lcnno"))
        '    lbl_company.Text = "ชื่อสถานที่ : " & value("nameplace")
        '    lbl_addr.Text = "ที่อยู่ : " & value("fulladdr")
        'Next


    End Sub
End Class