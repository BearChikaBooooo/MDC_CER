Namespace DAO.CFS

    Public MustInherit Class MAINCONTEXT
        Public db As New Linq_CERDataContext
        Public datas
    End Class


    Public Class TB_PROCESS
        Inherits MAINCONTEXT

        Public fields As New MAS_PROCESS

        Public Sub GetDataby_PROCESS_ID(ByVal PROCESS_ID As String)
            datas = (From p In db.MAS_PROCESSes Where p.PROCESS_ID = PROCESS_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_CFS_FOOD_HEAD
        Inherits MAINCONTEXT

        Public fields As New CFS_FOOD_HEAD
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_HEADs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)
            datas = (From p In db.CFS_FOOD_HEADs Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_rcvno_last()
            datas = (From p In db.CFS_FOOD_HEADs Where p.STATUS_ID = 2 Order By p.RCVNO Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_rcvno_last_type(ByVal process_id As Integer)
            datas = (From p In db.CFS_FOOD_HEADs Where p.FK_PROCESS_ID = process_id And p.STATUS_ID = 8 And Not p.REF_CODE Is Nothing Order By p.REF_CODE.Substring(14, 18) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_rcvno_last_type(ByVal process_id As Integer, ByVal year As String)
        '    If process_id = "910003" Then
        '        datas = (From p In db.CFS_FOOD_HEADs Where p.FK_PROCESS_ID = process_id And p.STATUS_ID = 8 And Not p.REF_CODE Is Nothing And p.APPROVE_DATE.Value.Year = year And Not (p.REF_CODE.Substring(14, 18) >= 22 And p.REF_CODE.Substring(14, 18) <= 24) Order By p.REF_CODE.Substring(14, 18) Descending Select p).Take(1)
        '    ElseIf process_id = "910002" Then
        '        datas = (From p In db.CFS_FOOD_HEADs Where p.FK_PROCESS_ID = process_id And p.STATUS_ID = 8 And Not p.REF_CODE Is Nothing And p.APPROVE_DATE.Value.Year = year And Not (p.REF_CODE.Substring(14, 18) >= 42 And p.REF_CODE.Substring(14, 18) <= 46) Order By p.REF_CODE.Substring(14, 18) Descending Select p).Take(1)
        '    Else
        '        datas = (From p In db.CFS_FOOD_HEADs Where p.FK_PROCESS_ID = process_id And p.STATUS_ID = 8 And Not p.REF_CODE Is Nothing And p.APPROVE_DATE.Value.Year = year Order By p.REF_CODE.Substring(14, 18) Descending Select p).Take(1)
        '    End If

        '    For Each Me.fields In datas

        '    Next
        'End Sub

        Public Sub GetDataby_rcvno_last_type_CFS(ByVal process_id As Integer, ByVal process_id2 As Integer, ByVal process_id3 As Integer, ByVal process_id4 As Integer, ByVal year As String)
            datas = (From p In db.CFS_FOOD_HEADs Where (p.FK_PROCESS_ID = process_id Or p.FK_PROCESS_ID = process_id2 Or p.FK_PROCESS_ID = process_id3 Or p.FK_PROCESS_ID = process_id4) And p.STATUS_ID = 8 And Not p.REF_CODE Is Nothing And p.APPROVE_DATE.Value.Year = year And Not (p.REF_CODE.Substring(14, 18) >= 185 And p.REF_CODE.Substring(14, 18) <= 214) Order By p.REF_CODE.Substring(14, 18) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub insert()
            db.CFS_FOOD_HEADs.InsertOnSubmit(fields)
            db.SubmitChanges()

        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class


    'Public Class TB_NODE_TEMPLATE
    '    Inherits MAINCONTEXT
    '    Private _Details As New List(Of NODE_TEMPLATE)
    '    Public Property Details() As List(Of NODE_TEMPLATE)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of NODE_TEMPLATE))
    '            _Details = value
    '        End Set
    '    End Property

    '    Private Sub AddDetails()
    '        Details.Add(fields)
    '        fields = New NODE_TEMPLATE
    '    End Sub
    '    Public fields As New NODE_TEMPLATE
    '    Public Sub GetDataby_IDA(ByVal NODEGROUP As Integer)
    '        datas = (From p In db.NODE_TEMPLATEs Where p.NODEGROUP = NODEGROUP Order By p.SEQ)
    '        For Each Me.fields In datas
    '            AddDetails()
    '        Next
    '    End Sub
    'End Class


    'Public Class TB_MAS_TEMPLATE_PROCESS
    '    Inherits MAINCONTEXT

    '    Public fields As New MAS_TEMPLATE_PROCESS

    '    Public Sub GetDATAby_PROCESS_ID(ByVal PROCESS_ID As String, ByVal STATUS_ID As Integer, ByVal PREVIEW As Integer)
    '        datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = PROCESS_ID And p.STATUS_ID = STATUS_ID And p.PREVIEW = PREVIEW Select p)
    '        For Each Me.fields In datas

    '        Next
    '    End Sub


    'End Class


    Public Class TB_CER_FOOD_WORD_OUT_PUT_TEMPLATE
        Inherits MAINCONTEXT

        Public fields As New CER_FOOD_WORD_OUT_PUT_TEMPLATE

        Public Sub GetDATAby_PROCESS_ID(ByVal PROCESS_ID As String, ByVal type As Integer, ByVal cer_case As Integer)
            datas = (From p In db.CER_FOOD_WORD_OUT_PUT_TEMPLATEs Where p.PROCESS_ID = PROCESS_ID And p.TYPE = type And p.CASE_CER = cer_case Select p)
            For Each Me.fields In datas

            Next
        End Sub


    End Class


    Public Class Table_GEN_RCV_NUMBER
        Inherits MAINCONTEXT
        Public fields As New GEN_RCV_NUMBER


        Public Sub insert()
            db.GEN_RCV_NUMBERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_RCV_NUMBERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_RCV_NUMBERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_RCV_NUMBERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_IDA(ByVal REF_IDA As Integer)
            datas = (From p In db.GEN_RCV_NUMBERs Where p.REF_IDA = REF_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Number_last(ByVal year As String)
            datas = (From p In db.GEN_RCV_NUMBERs Where p.GROUP_NO = "4" And p.YEAR = year And p.GENNO IsNot Nothing Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String, _
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            datas = (From p In db.GEN_RCV_NUMBERs Where p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' ดึงข้อมูลเลข Gen ตาม ปี จังหวัด
        ''' </summary>
        ''' <param name="YEAR"></param>
        ''' <param name="PVCODE"></param>
        ''' <param name="GROUP_NO"></param>
        ''' <remarks></remarks>
        Public Sub GetDataby_GEN_YEAR_PVCODE(ByVal YEAR As String, ByVal PVCODE As String, ByVal GROUP_NO As String)
            datas = (From p In db.GEN_RCV_NUMBERs Where p.YEAR = YEAR And p.PVCODE = PVCODE And p.GROUP_NO = GROUP_NO Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_CFS_COUNTRY
        Inherits MAINCONTEXT
        Public fieldes As New CFS_FOOD_COUNTRY
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_COUNTRies Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_COUNTRies Where p.FK_IDA_CER_NO = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub insert()
            db.CFS_FOOD_COUNTRies.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_CER_FOOD_SELECT_ATTACH
        Inherits MAINCONTEXT
        Public fieldes As New CER_FOOD_SELECT_ATTACH
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_SELECT_ATTACHes Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_IDA_HEAD(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_SELECT_ATTACHes Where p.FK_IDA_HEAD = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub insert()
            db.CER_FOOD_SELECT_ATTACHes.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_CFS_PRODUCT
        Inherits MAINCONTEXT
        Public fieldes As New CFS_FOOD_PRODUCT
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_PRODUCTs Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_PRODUCTs Where p.FK_IDA_CER_NO = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub insert()
            db.CFS_FOOD_PRODUCTs.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class
    'Public Class TB_TEMPLATE_ATTACH
    '    Inherits MAINCONTEXT
    '    Public fieldes As New TEMPLATE_ATTACH
    '    Public Sub GetDataby_processID(ByVal PROCESS_ID As Integer)
    '        datas = (From p In db.TEMPLATE_ATTACHes Where p.LCNTPCD = PROCESS_ID Select p)
    '        For Each Me.fieldes In datas
    '            AddDetails()
    '        Next
    '    End Sub

    '    Public Sub GetDataby_IDA(ByVal IDA As Integer)
    '        datas = (From p In db.TEMPLATE_ATTACHes Where p.IDA = IDA Select p)
    '        For Each Me.fieldes In datas

    '        Next
    '    End Sub

    '    Private Sub AddDetails()
    '        Details.Add(fieldes)
    '        fieldes = New TEMPLATE_ATTACH
    '    End Sub
    '    Private _Details As New List(Of TEMPLATE_ATTACH)
    '    Public Property Details() As List(Of TEMPLATE_ATTACH)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of TEMPLATE_ATTACH))
    '            _Details = value
    '        End Set
    '    End Property
    'End Class
    'Public Class TB_CER_LOG
    '    Inherits MAINCONTEXT

    '    Public fields As New CER_LOG


    '    Public Sub insert()
    '        db.CER_LOGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()

    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub
    'End Class
    'Public Class TB_TEMPLATE_TOPIC_TITLE_OUTPUT
    '    Inherits MAINCONTEXT
    '    Public fieldes As New TEMPLATE_TOPIC_TITLE_OUTPUT
    '    Public Sub GetDataby_processID(ByVal PROCESS_ID As Integer)
    '        datas = (From p In db.TEMPLATE_TOPIC_TITLE_OUTPUTs Where p.PROCESS_ID = PROCESS_ID Select p)
    '        For Each Me.fieldes In datas

    '        Next
    '    End Sub
    '    Private Sub AddDetails()
    '        Details.Add(fieldes)
    '        fieldes = New TEMPLATE_TOPIC_TITLE_OUTPUT
    '    End Sub
    '    Private _Details As New List(Of TEMPLATE_TOPIC_TITLE_OUTPUT)
    '    Public Property Details() As List(Of TEMPLATE_TOPIC_TITLE_OUTPUT)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of TEMPLATE_TOPIC_TITLE_OUTPUT))
    '            _Details = value
    '        End Set
    '    End Property
    'End Class

    Public Class TB_CFS_FOOD_FML
        Inherits MAINCONTEXT
        Public fieldes As New CFS_FOOD_FML
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_FMLs Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.CFS_FOOD_FMLs Where p.FK_IDA_PRODUCT = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub insert()
            db.CFS_FOOD_FMLs.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_CER_FOOD_STAFF
        Inherits MAINCONTEXT
        Public fieldes As New CER_FOOD_STAFF
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_STAFFs Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_CITIXEN_TYPE(ByVal citizen As String, ByVal type As Integer)
            datas = (From p In db.CER_FOOD_STAFFs Where p.STAFF_CITIZEN_ID = citizen And p.FK_STAFF_TYPE = type Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_STAFFs Where p.FK_STAFF_TYPE = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

        Public Sub insert()
            db.CER_FOOD_STAFFs.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_STAFF_TYPE
        Inherits MAINCONTEXT
        Public fieldes As New MAS_STAFF_TYPE
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_STAFF_TYPEs Where p.IDA = IDA Select p)
            For Each Me.fieldes In datas

            Next
        End Sub


        Public Sub insert()
            db.MAS_STAFF_TYPEs.InsertOnSubmit(fieldes)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TABLE_MAS_STATUS
        Inherits MAINCONTEXT

        Public fields As New MAS_STATUS1

        Public Sub GetDataby_STATUS_ID(ByVal STATUS_ID As Integer, ByVal STATUS_GROUP As String)
            datas = (From p In db.MAS_STATUS1s Where p.STATUS_ID = STATUS_ID And p.STATUS_GROUP = STATUS_GROUP Select p)
            For Each Me.fields In datas

            Next
        End Sub


        Public Sub GetDataby_STATUS_GROUP(ByVal STATUS_GROUP As String)
            datas = (From p In db.MAS_STATUS1s Where p.STATUS_GROUP = STATUS_GROUP Select p)
            'For Each Me.fields In datas

            'Next
        End Sub
    End Class

    Public Class TABLE_CFS_STAFF_REMARK_VERSION
        Inherits MAINCONTEXT

        Public fields As New CFS_FOOD_STAFF_REMARK_VERSION

        'Public Sub GetDataby_STATUS_ID(ByVal STATUS_ID As Integer, ByVal STATUS_GROUP As String)
        '    datas = (From p In db.CFS_FOOD_STAFF_REMARK_VERSIONs Where p.STATUS_ID = STATUS_ID And p.STATUS_GROUP = STATUS_GROUP Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub


        'Public Sub GetDataby_STATUS_GROUP(ByVal STATUS_GROUP As String)
        '    datas = (From p In db.CFS_FOOD_STAFF_REMARK_VERSIONs Where p.STATUS_GROUP = STATUS_GROUP Select p)
        '    'For Each Me.fields In datas

        '    'Next
        'End Sub
        Public Sub insert()
            db.CFS_FOOD_STAFF_REMARK_VERSIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_CER_FOOD_MAS_FDTYPE_ENG
        Inherits MAINCONTEXT
        Public fieldes As New CER_FOOD_MAS_FDTYPE_ENG
        Public Sub GetDataby_IDA(ByVal fdtypecd As Integer)
            datas = (From p In db.CER_FOOD_MAS_FDTYPE_ENGs Where p.fdtypecd = fdtypecd Select p)
            For Each Me.fieldes In datas

            Next
        End Sub

    
    End Class
    Public Class clsDBWORK_LIMIT
        Inherits MAINCONTEXT
        Public fields As New CER_FOOD_WORK_LIMIT
        Public Sub insert()
            db.CER_FOOD_WORK_LIMITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.CER_FOOD_WORK_LIMITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_FOOD_WORK_LIMITs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_WORK_LIMITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROCESS_ID_and_SYSTEM_ID(ByVal PROCESS_ID As String, ByVal SYSTEM_ID As String)
            datas = (From p In db.CER_FOOD_WORK_LIMITs Where p.PROCESS_ID = PROCESS_ID And p.SYSTEM_ID = SYSTEM_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBWORK_SCHEDULE
        Inherits MAINCONTEXT

        Public fields As New CER_FOOD_WORK_SCHEDULE

        Private _Details As New List(Of CER_FOOD_WORK_SCHEDULE)
        Public Property Details() As List(Of CER_FOOD_WORK_SCHEDULE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of CER_FOOD_WORK_SCHEDULE))
                _Details = value
            End Set
        End Property


        Public Sub AddDetails()
            _Details.Add(fields)
            fields = New CER_FOOD_WORK_SCHEDULE
        End Sub

        Public Sub insert()
            db.CER_FOOD_WORK_SCHEDULEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.CER_FOOD_WORK_SCHEDULEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.TRANSECTION_ID = TR_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID_PROCESS(ByVal TR_ID As Integer, ByVal process As String)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.TRANSECTION_ID = TR_ID And p.PROCESS_ID = process Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROCESS_ID(ByVal PROCESS_ID As Integer)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.PROCESS_ID = PROCESS_ID Order By p.IDA Descending Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub Getdataby_RECEIVE_DATE(ByVal rcvdate As Date, ByVal ProcessID As Integer)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.RECEIVE_DATE = rcvdate And p.PROCESS_ID = ProcessID Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub Getdataby_CONSIDER_DATE(ByVal CONSIDER As Date, ByVal ProcessID As Integer)
            datas = (From p In db.CER_FOOD_WORK_SCHEDULEs Where p.CONSIDER_DATE = CONSIDER And p.PROCESS_ID = ProcessID Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
End Namespace


