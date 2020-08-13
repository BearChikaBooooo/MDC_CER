Namespace DAO


    Public MustInherit Class MAINCONTEXT
        Public db As New Linq_FoodDataContext

        Public datas


        Public Sub Convert_TO_XML(ByVal filename As String, ByVal type As String, ByVal obj As Object)

        End Sub
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

    Public Class clsDBfalcn
        Inherits MAINCONTEXT
        Public fields As New falcn
        Public Sub insert()
            db.falcns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.falcns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_pvncd(ByVal pvncd As Integer)
            datas = (From p In db.falcns Where p.pvncd = pvncd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
            datas = (From p In db.falcns Where p.lcnno = lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_chngwtcd(ByVal chngwtcd As Integer)
            datas = (From p In db.falcns Where p.chngwtcd = chngwtcd And p.pvncd = chngwtcd Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid_lcntypecd(ByVal lcnsid As Integer, ByVal lcntypecd As Integer)
            datas = (From p In db.falcns Where p.lcntypecd = lcntypecd And p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.falcns Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_rcvno(ByVal lcnsid As Integer, ByVal rcvno As Integer)
            datas = (From p In db.falcns Where p.lcnsid = lcnsid)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid_lcnno(ByVal lcnsid As Integer, ByVal lcnno As Integer)
            datas = (From p In db.falcns Where p.lcnsid = lcnsid And p.lcnno = lcnno Select p Order By p.ID Descending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcntypecd(ByVal lcntypecd As Integer)
            datas = (From p In db.falcns Where p.lcntypecd = lcntypecd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID(ByVal ID As Integer)
            datas = (From p In db.falcns Where p.ID = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.falcns Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



#Region "ทั่วไป"

    'Public Class TB_SYSPLACE
    '    Inherits MAINCONTEXT

    '    Public fields As New sysplace

    '    Private _Details As New List(Of sysplace)
    '    Public Property Details() As List(Of sysplace)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of sysplace))
    '            _Details = value
    '        End Set
    '    End Property

    '    Private Sub AddDetails()
    '        Details.Add(fields)
    '        fields = New sysplace
    '    End Sub

    '    Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
    '        datas = (From p In db.sysplaces Where p.FR_IDA = FK_IDA Select p)
    '        For Each Me.fields In datas
    '            AddDetails()
    '        Next
    '    End Sub

    '    Public Sub insert()
    '        db.sysplaces.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub delete()
    '        db.sysplaces.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()
    '        datas = (From p In db.sysplaces Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
    '        datas = (From p In db.sysplaces Where p.rcvno Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class

#End Region

    Public Class clsDBfalcntype
        Inherits MAINCONTEXT
        Public fields As New falcntype
        Public Sub insert()
            db.falcntypes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.falcntypes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_lcntypecd(ByVal lcntypecd As Integer)
            datas = (From p In db.falcntypes Where p.lcntypecd = lcntypecd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnabbr(ByVal lcnabbr As String)
            datas = (From p In db.falcntypes Where p.lcnabbr = lcnabbr Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.falcntypes Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    'Public Class clsDBWORK_HOLIDAY
    '    Inherits MAINCONTEXT
    '    Public fields As New WORK_HOLIDAY

    '    Private _Details As New List(Of WORK_HOLIDAY)
    '    Public Property Details() As List(Of WORK_HOLIDAY)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of WORK_HOLIDAY))
    '            _Details = value
    '        End Set
    '    End Property

    '    Private Sub AddDetails()
    '        Details.Add(fields)
    '        fields = New WORK_HOLIDAY
    '    End Sub


    '    Public Sub insert()
    '        db.WORK_HOLIDAYs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub delete()
    '        db.WORK_HOLIDAYs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataby_holiday(ByVal holidaydate As Date)
    '        datas = (From p In db.WORK_HOLIDAYs Where p.holdate = holidaydate Select p)
    '        For Each Me.fields In datas
    '            AddDetails()
    '        Next
    '    End Sub

    '    Public Sub GetDataAll()
    '        datas = (From p In db.WORK_HOLIDAYs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_IDA(ByVal IDA As Integer)
    '        datas = (From p In db.WORK_HOLIDAYs Where p.IDA = IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class

End Namespace
