﻿Public Class FRM_POPUP_REMARK_STAFF_LIST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _P_ID As String
    Private _IDA As String
    Private _S_ID As String
    Private _S_GROUP As String
    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _S_GROUP = Request.QueryString("S_GROUP")
                _IDA = Request.QueryString("IDA")
                _S_ID = Request.QueryString("S_ID")
                _P_ID = Request.QueryString("P_ID")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()

        If Not IsPostBack Then
            'Dim dao_get_status As New DAO.CFS.TABLE_MAS_STATUS
            'dao_get_status.GetDataby_STATUS_ID(_S_ID, 48)
            'lbl_title.Text = "หมายเหตุ : " & dao_get_status.fields.STATUS_NAME
        End If
        load_data()
    End Sub

    Private Sub load_data()

        'Dim bao As New BAO_STOREPROCUDURE.CFS
        'Dim dt As New DataTable
        'dt = bao.SP_GET_FOOD_STAFF_REMARK_VERSION(_IDA)
        'RadGrid1.DataSource = dt
    End Sub
    
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub


End Class