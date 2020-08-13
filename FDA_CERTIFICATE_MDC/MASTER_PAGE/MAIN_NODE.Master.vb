Public Class MAIN_NODE
    Inherits System.Web.UI.MasterPage
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
        BindData()
    End Sub

    Private Sub BindData()
        Dim bao As New BAO_STOREPROCUDURE.CPN
        Dim dt As New DataTable
        dt = bao.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID)
        For Each dr As DataRow In dt.Rows
            hl_organization.Text = dr("thanm")
        Next

        Dim dt2 As New DataTable
        dt2 = bao.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        For Each dr2 As DataRow In dt2.Rows
            hl_name.Text = dr2("thanm_initials")
        Next


    End Sub

    Protected Sub RadTreeView1_NodeClick(sender As Object, e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeView1.NodeClick

    End Sub
End Class