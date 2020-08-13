Public Class FRM_CMT_SEARCH_UNSEC
    Inherits System.Web.UI.Page
    Private lcnsid As String
    Sub runQuery()
        lcnsid = Request.QueryString("lcnsid")
        'lcnsid = "1032"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RadGrid1.Rebind()
    End Sub
    Private Sub bindData()
        Dim sql As String = "exec dbo.SP_CMT_SEARCH @lcnsid = " & lcnsid & ",@regnos = '" & txt_regnos.Text & _
            "',@Productmain_tha = '" & txt_thai.Text & "',@Productmain_eng = '" & txt_eng.Text & "',@lctnmno =''"
        Dim clsds As New ClassDataset

        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, SqlDataSource1.ConnectionString).Tables(0)
        RadGrid1.DataSource = dt
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        bindData()
    End Sub
End Class