Public Class MAIN_STAFF
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
        'เป็น Function ตัวโหลด Page หลัก ในหน้า MAIN_STAFF ตัว sender จะรับหน้า View Designer ของ MAIN_STAFF มาใส่ไว้


        runQuery() 'เรียก Function runQuery() มาใช้
        BindData()

    End Sub

    Private Sub BindData()
        Try

            Dim bao As New BAO_STOREPROCUDURE.CPN 'ประกาศ bao ตัวนี้เพื่อไปผูกกับ STOREPROCUDURE ใน Database

            'Dim dt As New DataTable
            'dt = bao.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)
            'For Each dr As DataRow In dt.Rows
            '    hl_organization.Text = dr("COMPANY_NM")
            'Next

            Dim dt2 As New DataTable 'ประกาศ dt2 เป็น DataTable เพื่อที่จะเก็บเลข CITIZEN_ID ของผู้ Login เข้ามา
            dt2 = bao.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
            For Each dr2 As DataRow In dt2.Rows
                hl_name.Text = "เจ้าหน้าที่ : " + dr2("thanm_initials") ' hl_name ตัวนี้จะเก็บ Text "เจ้าหน้าที่" แล้วเอาไปโชว์หน้า View Designer

            Next

        Catch ex As Exception

        End Try

    End Sub

End Class