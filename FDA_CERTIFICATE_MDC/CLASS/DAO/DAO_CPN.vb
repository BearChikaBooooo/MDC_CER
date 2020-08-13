Namespace DAO_CPN


    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New Linq_CPNDataContext

        Public datas

        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

#Region "CPN"



    Public Class clsDBsyslcnsid
        Inherits MAINCONTEXT1
        Public fields As New syslcnsid
        Public Sub insert()
            db_cpn.syslcnsids.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslcnsids.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslcnsids Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslcnsids Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_taxno(ByVal taxno As String)
            datas = (From p In db_cpn.syslcnsids Where p.taxno = taxno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_identify(ByVal identify As String)
            'GetDataby_identify ตัวนี้จะทำการไปดึงเลข Identify ที่อยู่ใน Database ขึ้นอยู่กับเงื่อนไขว่าจะไปเรียกเลข Identify ไหนในตาราง
            datas = (From p In db_cpn.syslcnsids Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_sysemail
        Inherits MAINCONTEXT1
        Public fields As New sysemail
        Public Sub insert()
            db_cpn.sysemails.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.sysemails.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysemails Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDEN(ByVal IDEN As String)
            datas = (From p In db_cpn.sysemails Where p.CITIZEN_ID = IDEN Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class clsDBsyslctnm
        Inherits MAINCONTEXT1
        Public fields As New syslctnm
        Public Sub insert()
            db_cpn.syslctnms.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslctnms.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslctnms Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            'GetDataby_lcnsid ตัวนี้จะทำการไปดึงเลข lcnsid ที่อยู่ใน Database ขึ้นอยู่กับเงื่อนไขว่าจะไปเรียกเลข lcnsid ไหนในตาราง
            datas = (From p In db_cpn.syslctnms Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class clsDBsyslcnsnm
        Inherits MAINCONTEXT1
        Public fields As New syslcnsnm
        Public Sub insert()
            db_cpn.syslcnsnms.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslcnsnms.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslcnsnms Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslcnsnms Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_thanm(ByVal thanm As String)
            datas = (From p In db_cpn.syslcnsnms Where p.thanm = thanm Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.syslcnsnms Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class

    Public Class clsDBsyslctaddr
        Inherits MAINCONTEXT1
        Public fields As New syslctaddr
        Public Sub insert()
            db_cpn.syslctaddrs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syslctaddrs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.syslctaddrs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_identify(ByVal identify As String)
            datas = (From p In db_cpn.syslctaddrs Where p.identify = identify Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.syslctaddrs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lctcd(ByVal lcnsid As Integer, ByVal lctcd As Integer)
            datas = (From p In db_cpn.syslctaddrs Where p.lcnsid = lcnsid And p.lctcd = lctcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class clsDBsyschngwt
        Inherits MAINCONTEXT1
        Public fields As New syschngwt
        Public Sub insert()
            db_cpn.syschngwts.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.syschngwts.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.syschngwts Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_chngwtcd(ByVal chngwtcd As Integer)
            datas = (From p In db_cpn.syschngwts Where p.chngwtcd = chngwtcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_name(ByVal name As Integer)
            datas = (From p In db_cpn.syschngwts Where p.thachngwtnm = name Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBsysamphr
        Inherits MAINCONTEXT1
        Public fields As New sysamphr
        Public Sub insert()
            db_cpn.sysamphrs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.sysamphrs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysamphrs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_chngwtcd_amphrcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)
            datas = (From p In db_cpn.sysamphrs Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_(ByVal chngwtcd As Integer)
            datas = (From p In db_cpn.sysamphrs Where p.chngwtcd = chngwtcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_amphrs_name(ByVal name As Integer)
            datas = (From p In db_cpn.sysamphrs Where p.thaamphrnm = name Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBsysthmbl
        Inherits MAINCONTEXT1
        Public fields As New systhmbl
        Public Sub insert()
            db_cpn.systhmbls.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.systhmbls.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.systhmbls Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_amphrcd_thmblcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer, ByVal thmblcd As Integer)
            datas = (From p In db_cpn.systhmbls Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd And p.thmblcd = thmblcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_chngwtcd_amphrcd(ByVal chngwtcd As Integer, ByVal amphrcd As Integer)
            datas = (From p In db_cpn.systhmbls Where p.chngwtcd = chngwtcd And p.amphrcd = amphrcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_thmbls_name(ByVal name As Integer)
            datas = (From p In db_cpn.systhmbls Where p.thathmblnm = name Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class clsDBsysnmperson
        Inherits MAINCONTEXT1
        Public fields As New sysnmperson
        Public Sub insert()
            db_cpn.sysnmpersons.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.sysnmpersons.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.sysnmpersons Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.sysnmpersons Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class tb_workday
        Inherits MAINCONTEXT1
        Public fields As New WORK_HOLIDAY

        Public Sub GetDataby_holiday(ByVal c_date As Date)
            datas = (From p In db_cpn.WORK_HOLIDAYs Where p.holdate = c_date Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class




#End Region

End Namespace

