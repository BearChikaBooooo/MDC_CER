Public Class FRM_CMT_SEARCH
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION

    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub bindData()
        Dim sql As String = "exec dbo.SP_CMT_SEARCH @lcnsid = " & _CLS.LCNSID & ",@regnos = '" & txt_regnos.Text & _
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