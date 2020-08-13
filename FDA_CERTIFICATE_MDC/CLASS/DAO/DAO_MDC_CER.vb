Namespace DAO_MDC_CER
    Public MustInherit Class MAINCONTEXT
        Public db As New Linq_CER_MDCDataContext


        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_MDC_HISTORY_LOG
        Inherits MAINCONTEXT
        Public fields As New MDC_HISTORY_LOG


        Public Sub insert()
            db.MDC_HISTORY_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MDC_HISTORY_LOGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

    End Class

    Public Class TB_MDC_CER_LCNNO
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New MDC_CER_LCNNO
        Private _Details As List(Of MDC_CER_LCNNO)
        Public Property Details() As List(Of MDC_CER_LCNNO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_CER_LCNNO))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MDC_CER_LCNNO
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MDC_CER_LCNNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MDC_CER_LCNNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.MDC_CER_LCNNOs Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_fk_ida(ByVal id As Integer)
            datas = (From q In db.MDC_CER_LCNNOs Where q.FK_IDA = id Select q Order By q.IDA)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Getdata_by_fk_ida_type(ByVal id As Integer, ByVal type As Integer)
            datas = (From q In db.MDC_CER_LCNNOs Where q.FK_IDA = id And q.TYPE = type Select q Order By q.IDA)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.MDC_CER_LCNNOs Select p Order By p.IDA Descending).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MDC_CER
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN
        Public fields As New MDC_CER
        Private _Details As List(Of MDC_CER)
        Public Property Details() As List(Of MDC_CER)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_CER))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MDC_CER
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MDC_CERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MDC_CERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer) 'รับข้อมูลทั้งหมดมาโดยการอ้างอิงจาก IDA เพื่อนโชว์ข้อมูลทั้ง Table ของ IDA นั้นๆ
            datas = (From q In db.MDC_CERs Where q.IDA = id Select q) 'จะไปดึงเลข IDA ใน Field IDA ของตาราง MDC_CERs มา 
            For Each Me.fields In datas


            Next
        End Sub

        Public Sub Getdata_bydate_app(ByVal DATE_APPROVE As Date) 'รับข้อมูลทั้งหมดมาโดยการอ้างอิงจาก IDA เพื่อนโชว์ข้อมูลทั้ง Table ของ IDA นั้นๆ
            datas = (From q In db.MDC_CERs Where q.DATE_APPROVE = DATE_APPROVE Select q) 'จะไปดึงเลข IDA ใน Field IDA ของตาราง MDC_CERs มา 
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_bylcnsid(ByVal lcnsid As Integer)
            datas = (From q In db.MDC_CERs Where q.lcnsid = lcnsid Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_bytrid(ByVal trid As Integer)
            datas = (From q In db.MDC_CERs Where q.TR_ID = trid Select q)
            For Each Me.fields In datas

            Next
        End Sub


        Public Sub GetDataAll()

            datas = (From p In db.MDC_CERs Select p Order By p.IDA Descending).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_MDC_CER_COUNTRY
        Inherits MAINCONTEXT
        Public fields As New MDC_CER_COUNTRY
        Private _Details As List(Of MDC_CER_COUNTRY)
        Public Property Details() As List(Of MDC_CER_COUNTRY)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_CER_COUNTRY))
                _Details = value
            End Set
        End Property
        Public Sub delete()
            db.MDC_CER_COUNTRies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.MDC_CER_COUNTRies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.MDC_CER_COUNTRies Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_byfk_ida(ByVal fk_ida As Integer)
            datas = (From q In db.MDC_CER_COUNTRies Where q.FK_IDA = fk_ida Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class


    Public Class TB_MDC_CER_SUBTYPE
        Inherits MAINCONTEXT
        Public fields As New MDC_CER_SUBTYPE
        Private _Details As List(Of MDC_CER_SUBTYPE)
        Public Property Details() As List(Of MDC_CER_SUBTYPE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_CER_SUBTYPE))
                _Details = value
            End Set
        End Property
        Public Sub delete()
            db.MDC_CER_SUBTYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.MDC_CER_SUBTYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.MDC_CER_SUBTYPEs Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_byfk_ida(ByVal fk_ida As Integer)
            datas = (From q In db.MDC_CER_SUBTYPEs Where q.FK_IDA = fk_ida Select q)
            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MDC_CER_PRODUCT
        Inherits MAINCONTEXT
        Public fields As New MDC_CER_PRODUCT
        Private _Details As List(Of MDC_CER_PRODUCT)
        Public Property Details() As List(Of MDC_CER_PRODUCT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_CER_PRODUCT))
                _Details = value
            End Set
        End Property
        Public Sub delete()
            db.MDC_CER_PRODUCTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.MDC_CER_PRODUCTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.MDC_CER_PRODUCTs Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_byfk_ida(ByVal fk_ida As Integer)
            datas = (From q In db.MDC_CER_PRODUCTs Where q.FK_IDA = fk_ida Select q)
            For Each Me.fields In datas

            Next
        End Sub



    End Class

    Public Class TB_MAS_TEMPLATE_PROCESS
        Inherits MAINCONTEXT

        Public fields As New MAS_TEMPLATE_PROCESS

        Public Sub GetDataby_TEMPLAETE(ByVal P_ID As Integer, ByVal lcntype As Integer, ByVal STATUS As Integer, ByVal GROUPS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
             And p.GROUPS = GROUPS And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_TRANSACTION_UPLOAD
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN
        Public fields As New TRANSACTION_UPLOAD
        Private _Details As List(Of TRANSACTION_UPLOAD)
        Public Property Details() As List(Of TRANSACTION_UPLOAD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TRANSACTION_UPLOAD))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TRANSACTION_UPLOAD
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.TRANSACTION_UPLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.TRANSACTION_UPLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.TRANSACTION_UPLOADs Where q.ID = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TRANSACTION_DOWNLOAD
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN
        Public fields As New TRANSACTION_DOWNLOAD
        Private _Details As List(Of TRANSACTION_DOWNLOAD)
        Public Property Details() As List(Of TRANSACTION_DOWNLOAD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TRANSACTION_DOWNLOAD))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TRANSACTION_DOWNLOAD
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.TRANSACTION_DOWNLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.TRANSACTION_DOWNLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.TRANSACTION_DOWNLOADs Where q.ID = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

    End Class



    Public Class TB_TEMPLATE_ATTACH
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New TEMPLATE_ATTACH

        Private _Details As New List(Of TEMPLATE_ATTACH)
        Public Property Details() As List(Of TEMPLATE_ATTACH)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TEMPLATE_ATTACH))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TEMPLATE_ATTACH
        End Sub


        Public Sub GetDataby_LCTNPCD(ByVal LCTNPCD As String, ByVal CONVENTPCD As String)
            datas = (From p In db.TEMPLATE_ATTACHes Where p.LCNTPCD = LCTNPCD And p.conventpcd = CONVENTPCD Order By p.TYPE Ascending Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub delete() Implements MAINCONTEXT.MAIN.delete

        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert

        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update

        End Sub
    End Class

    Public Class TB_FILE_ATTACH
        Inherits MAINCONTEXT

        Public fields As New FILE_ATTACH

        Public Sub GetDATAby_IDA(ByVal IDA As Integer)
            datas = (From p In db.FILE_ATTACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDATAby_EXPLAIN(ByVal IDA As Integer)
            datas = (From p In db.FILE_ATTACHes Where p.IDA = IDA And p.EXPLAIN = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDATAby_TR_ID(ByVal TR_ID As Integer, ByVal type As Integer)
            datas = (From p In db.FILE_ATTACHes Where p.TR_ID = TR_ID And p.TYPE = type Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDATAby_TR_ID2(ByVal TR_ID As Integer)
            datas = (From p In db.FILE_ATTACHes Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDATAby_TR_ID_AND_EXT(ByVal TR_ID As Integer, ByVal ext As String)
            datas = (From p In db.FILE_ATTACHes Where p.TR_ID = TR_ID And p.EXTENSION = ext Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDATAby_TR_ID_AND_TYPE(ByVal TR_ID As Integer, ByVal TYPE As String)
            datas = (From p In db.FILE_ATTACHes Where p.TR_ID = TR_ID And p.TYPE = TYPE Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.FILE_ATTACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

    End Class

    Public Class TB_MDC_CER_GEN_RCV_NO
        Inherits MAINCONTEXT
        Public fields As New MDC_CER_GEN_RCV_NO
        Public Sub insert()
            db.MDC_CER_GEN_RCV_NOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MDC_CER_GEN_RCV_NOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_ID(ByVal IDA As Integer)
            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_IDA(ByVal REF_IDA As Integer)
            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.REF_IDA = REF_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GENNO(ByVal GENNO As Integer)
            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.GENNO = GENNO Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String)

            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By p.IDA Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MDC_CER_GEN_RGT_NO
        Inherits MAINCONTEXT
        Public fields As New MDC_CER_GEN_RGT_NO
        Public Sub insert()
            db.MDC_CER_GEN_RGT_NOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MDC_CER_GEN_RGT_NOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_ID(ByVal IDA As Integer)
            datas = (From p In db.MDC_CER_GEN_RGT_NOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_IDA(ByVal REF_IDA As Integer)
            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.REF_IDA = REF_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GENNO(ByVal GENNO As Integer)
            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.GENNO = GENNO Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String)

            datas = (From p In db.MDC_CER_GEN_RCV_NOs Where p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By p.IDA Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

#Region "RENEW"


    Public Class clsTBGEN_RCVNO
        Inherits MAINCONTEXT
        Public fields As New GEN_RCVNO
        Public Sub insert()
            db.GEN_RCVNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_RCVNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PVNCD(ByVal PVNCD As Integer, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            'datas = (From p In db.feedtls Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetMax_GenNo()
            datas = (From p In db.GEN_RCVNOs Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer, ByVal type As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID And p.GEN_TYPE = type Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_NO_TYPE(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class clsTBGEN_NUMBER
        Inherits MAINCONTEXT
        Public fields As New GEN_NUMBER
        Public Sub insert()
            db.GEN_NUMBERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NUMBERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NUMBERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer)
            datas = (From p In db.GEN_NUMBERs Where p.PVNCD = PVNCD And p.YEARS = YEARS Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PVNCD(ByVal PVNCD As Integer, ByVal YEARS As Integer)
            datas = (From p In db.GEN_NUMBERs Where p.PVNCD = PVNCD And p.YEARS = YEARS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            'datas = (From p In db.feedtls Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetMax_GenNo()
            datas = (From p In db.GEN_NUMBERs Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer, ByVal type As Integer)
            datas = (From p In db.GEN_NUMBERs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID And p.GEN_TYPE = type Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_NO_TYPE(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_NUMBERs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GEN_RCV Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class


    Public Class TB_GEN_DOCNO
        Inherits MAINCONTEXT
        Public fields As New GEN_DOCNO
        Public Sub insert()
            db.GEN_DOCNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_DOCNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_DOCNOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer)
            datas = (From p In db.GEN_DOCNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS Order By p.GEN_DOC Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PVNCD(ByVal PVNCD As Integer, ByVal YEARS As Integer)
            datas = (From p In db.GEN_DOCNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            'datas = (From p In db.feedtls Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetMax_GenNo()
            datas = (From p In db.GEN_DOCNOs Order By p.GEN_DOC Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_DOCNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GEN_DOC Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_GEN_RefCerNo
        Inherits MAINCONTEXT
        Public fields As New GEN_RefCerNo
        Public Sub insert()
            db.GEN_RefCerNos.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_RefCerNos.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_RefCerNos Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RefCerNos Where p.PVNCD = PVNCD And p.YEARS = YEARS Order By p.GEN_RefCer Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PVNCD(ByVal PVNCD As Integer, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RefCerNos Where p.PVNCD = PVNCD And p.YEARS = YEARS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            'datas = (From p In db.feedtls Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetMax_GenNo()
            datas = (From p In db.GEN_RefCerNos Order By p.GEN_RefCer Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_RefCerNos Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GEN_RefCer Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_GEN_RefItemNo
        Inherits MAINCONTEXT
        Public fields As New GEN_RefItemNo
        Public Sub insert()
            db.GEN_RefItemNos.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_RefItemNos.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_RefItemNos Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RefItemNos Where p.PVNCD = PVNCD And p.YEARS = YEARS Order By p.GEN_RefItem Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PVNCD(ByVal PVNCD As Integer, ByVal YEARS As Integer)
            datas = (From p In db.GEN_RefItemNos Where p.PVNCD = PVNCD And p.YEARS = YEARS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()
            'datas = (From p In db.feedtls Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetMax_GenNo()
            datas = (From p In db.GEN_RefItemNos Order By p.GEN_RefItem Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_RefItemNos Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GEN_RefItem Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_manucd_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer, ByVal manucd As Integer)
            datas = (From p In db.GEN_RefItemNos Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID And p.MANU_CD = manucd Order By p.GEN_RefItem Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    ''' <summary>
    ''' gen เลขรับ
    ''' </summary>
    ''' <remarks></remarks>



    Public Class TB_GEN_RCVNO_CMNM
        Inherits MAINCONTEXT
        Public fields As New GEN_RCVNO_CMNM
        Public Sub insert()
            db.GEN_RCVNO_CMNMs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_RCVNO_CMNMs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_ID(ByVal IDA As Integer)
            datas = (From p In db.GEN_RCVNO_CMNMs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_IDA(ByVal REF_IDA As Integer)
            datas = (From p In db.GEN_RCVNO_CMNMs Where p.REF_IDA = REF_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GENNO(ByVal GENNO As Integer)
            datas = (From p In db.GEN_RCVNO_CMNMs Where p.GENNO = GENNO Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String)

            datas = (From p In db.GEN_RCVNO_CMNMs Where p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By p.IDA Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    ''' <summary>
    ''' gen เลขจดทะเบียนสถานประกอบการ
    ''' </summary>
    ''' <remarks></remarks>

#End Region

    Public Class clsGEN_LCNNO
        Inherits MAINCONTEXT
        Public fields As New GEN_LCNNO
        Public Sub insert()
            db.GEN_LCNNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_LCNNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_LCNNOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_LCNNOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_LCNNOs Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
            ByVal FORMAT As String, ByVal REF_IDA As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_LCNNOs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Year_PVNCD_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal TYPE As Integer, ByVal Process_ID As String)
            datas = (From p In db.GEN_LCNNOs Where p.PVCODE = PVNCD And p.YEAR = YEARS And p.TYPE = TYPE And p.GROUP_NO = Process_ID Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsGEN_COMMON_ID
        Inherits MAINCONTEXT
        Public fields As New GEN_COMMON_ID
        Public Sub insert()
            db.GEN_COMMON_IDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_COMMON_IDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_COMMON_IDs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_COMMON_IDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_COMMON_IDs Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                ByVal FORMAT As String, ByVal REF_IDA As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_COMMON_IDs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class GET_TB_IRGT
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New irgt
        Private _Details As List(Of irgt)
        Public Property Details() As List(Of irgt)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of irgt))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New irgt
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.irgts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.irgts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byrgtno_display(ByVal id As Integer)
            datas = (From q In db.irgts Where q.rgtno_display = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        'Public Sub Getdata_byrgtno_display2(ByVal id As Integer)
        '    datas = (From q In db.irgts Where q.rgtno_display = id And q.exSelect q)
        '    For Each Me.fields In datas

        '    Next
        'End Sub

        Public Sub Getdata_byida(ByVal ida As Integer)
            datas = (From q In db.irgts Where q.IDA = ida Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_bytrid(ByVal trid As Integer)
            datas = (From q In db.irgts Where q.TR_ID = trid Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class


    Public Class GET_TB_MN
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New MDC_MN
        Private _Details As List(Of MDC_MN)
        Public Property Details() As List(Of MDC_MN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_MN))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MDC_MN
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MDC_MNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MDC_MNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byrgtno_display(ByVal id As Integer)
            datas = (From q In db.MDC_MNs Where q.rgtno_display = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_bytrid(ByVal trid As Integer)
            datas = (From q In db.MDC_MNs Where q.TR_ID = trid Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class GET_TB_MC
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New MDC_MC
        Private _Details As List(Of MDC_MC)
        Public Property Details() As List(Of MDC_MC)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_MC))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MDC_MC
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MDC_MCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MDC_MCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byrgtno_display(ByVal id As Integer)
            datas = (From q In db.MDC_MCs Where q.rgtno_display = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_bytrid(ByVal trid As Integer)
            datas = (From q In db.MDC_MCs Where q.TR_ID = trid Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class



    Public Class GET_TB_MR
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New MDC_MR
        Private _Details As List(Of MDC_MR)
        Public Property Details() As List(Of MDC_MR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MDC_MR))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MDC_MR
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MDC_MRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MDC_MRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byrgtno_display(ByVal id As Integer)
            datas = (From q In db.MDC_MRs Where q.rgtno_display = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_bytrid(ByVal trid As Integer)
            datas = (From q In db.MDC_MRs Where q.TR_ID = trid Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class GET_TB_TAMPLATE_UPLOAD_LIST
        Inherits MAINCONTEXT : Implements MAINCONTEXT.MAIN

        Public fields As New MAS_TEMPLATE_UPLOAD_LIST
        Private _Details As List(Of MAS_TEMPLATE_UPLOAD_LIST)
        Public Property Details() As List(Of MAS_TEMPLATE_UPLOAD_LIST)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MAS_TEMPLATE_UPLOAD_LIST))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MAS_TEMPLATE_UPLOAD_LIST
        End Sub
        Public Sub delete() Implements MAINCONTEXT.MAIN.delete
            db.MAS_TEMPLATE_UPLOAD_LISTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert() Implements MAINCONTEXT.MAIN.insert
            db.MAS_TEMPLATE_UPLOAD_LISTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update() Implements MAINCONTEXT.MAIN.update
            db.SubmitChanges()
        End Sub

        Public Sub Getdata_byida(ByVal IDA As Integer)
            datas = (From q In db.MAS_TEMPLATE_UPLOAD_LISTs Where q.IDA = IDA Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetTemplate_ByGroup_type(ByVal grouptype As Integer, ByVal process_id As Integer)
            datas = (From q In db.MAS_TEMPLATE_UPLOAD_LISTs Where q.GROUP_TYPE = grouptype And q.PROCESS_ID = process_id Select q)
            For Each Me.fields In datas

            Next
        End Sub


    End Class


End Namespace



