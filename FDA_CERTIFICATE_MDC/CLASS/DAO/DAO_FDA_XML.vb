Namespace DAO_FDA_XML

    Public MustInherit Class MAINCONTEXT

        Public db As New Linq_FDA_XML_DUMPDataContext
        Public datas
    End Class


    Public Class TB_XML_FOOD
        Inherits MAINCONTEXT

        Public fields As New XML_FOOD

        Public Sub GetDataby_fdpdtno(ByVal fdpdtno As String)
            datas = (From p In db.XML_FOODs Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_FOOD_EXPORT
        Inherits MAINCONTEXT

        Public fields As New food_export

        Public Sub GetDataby_fdpdtno(ByVal fdpdtno As String)
            datas = (From p In db.food_exports Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_FOOD_EXPORT_CHECK
        Inherits MAINCONTEXT

        Public fields As New food_export_check

        Public Sub GetDataby_fdpdtno(ByVal fdpdtno As String)
            datas = (From p In db.food_export_checks Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
End Namespace

