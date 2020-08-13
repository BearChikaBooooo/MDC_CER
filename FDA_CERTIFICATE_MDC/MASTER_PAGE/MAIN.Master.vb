Public Class MAIN
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

        'If _CLS.Groups = "24300" Then
        '    replacment.Visible = True
        'Else
        '    replacment.Visible = False
        'End If
        runQuery()
        BindData()
        
    End Sub

    Private Sub BindData()
        Try

            Dim bao As New BAO_STOREPROCUDURE.CPN

            Dim dt As New DataTable
            dt = bao.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)
            For Each dr As DataRow In dt.Rows
                hl_organization.Text = dr("COMPANY_NM")
            Next
            Dim citizen_id As String
            If _CLS.STAFF_APM = 1 Then
                citizen_id = _CLS.CITIZEN_ID_BSN
            Else
                citizen_id = _CLS.CITIZEN_ID
            End If
            Dim dt2 As New DataTable
            dt2 = bao.SP_MAINPERSON_CTZNO(citizen_id)
            For Each dr2 As DataRow In dt2.Rows
                hl_name.Text = dr2("thanm_initials")
            Next

        Catch ex As Exception

        End Try

    End Sub

End Class