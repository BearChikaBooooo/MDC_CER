
Imports System.Threading
Imports System.Globalization
Imports System.Net.Mime.MediaTypeNames
Imports iTextSharp.text
Imports Telerik.Web.UI

Public Class FRM_POPUP_STAFF_CONFRIME_ATTACH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As Integer
    Private _TR_ID As String
    Private _TYPE As Integer
    Dim dao_MDC_CER As New DAO_MDC_CER.TB_MDC_CER



    Sub runQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _IDA = Request.QueryString("ida")
                _TR_ID = Request.QueryString("tr_id")

            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles Radgrid1.NeedDataSource
        Dim bao As New BAO_MASTER
        RadGrid1.DataSource = bao.SP_MDC_CER_PRODUCT_STAFF(_IDA)
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("../STAFF_MAIN_CER/FRM_POPUP_STAFF_CONFRIME.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "")
    End Sub
End Class