Public Class FRM_CHOOSE_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    'Private _P_ID As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("https://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                '_P_ID = Request.QueryString("P_ID")
            End If


        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub

    Private Sub btn_staff_1_Click(sender As Object, e As EventArgs) Handles btn_staff_1.Click
        If check_permis(1) = True Then
            _CLS.STAFF_TYPE = 1
            Session("CLS") = _CLS
            Response.Redirect("../STAFF_MIAN_CER/FRM_STAFF_MAIN_CER.aspx")
        Else
            alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
        End If
    End Sub

    Private Sub btn_staff_2_Click(sender As Object, e As EventArgs) Handles btn_staff_2.Click
        If check_permis(2) = True Then
            _CLS.STAFF_TYPE = 2
            Session("CLS") = _CLS
            Response.Redirect("../STAFF_MIAN_CER/FRM_STAFF_MAIN_CER.aspx")
        Else
            alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
        End If
    End Sub

    Private Sub btn_staff_3_Click(sender As Object, e As EventArgs) Handles btn_staff_3.Click
        If check_permis(3) = True Then
            _CLS.STAFF_TYPE = 3
            Session("CLS") = _CLS
            Response.Redirect("../STAFF_MIAN_CER/FRM_STAFF_MAIN_CER.aspx")
        Else
            alert1("ท่านไม่ได้รับสิทธิในการเข้าใช้งานระบบ ในขั้นนี้ !")
        End If
    End Sub
    Public Function check_permis(ByVal permis As Integer)
        Dim check As Boolean = True
        Dim dao_get_staff As New DAO.CFS.TB_CER_FOOD_STAFF
        dao_get_staff.GetDataby_CITIXEN_TYPE(_CLS.CITIZEN_ID, permis)
        If dao_get_staff.fieldes.IDA = 0 Then
            check = False
        End If
        Return check
    End Function
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
End Class