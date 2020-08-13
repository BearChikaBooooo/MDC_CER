Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO






    Public Class ClsDBSqlCommand    'Class นี้ เอาไว้สร้าง Function เพื่อเอาไปเรียกใช้
        Public dt As New DataTable
        Dim rdr As SqlDataReader
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString)
        Dim conn_SIP As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGT_SIPConnectionString").ConnectionString)
        Dim conn_CPN As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString)
        Dim conn_PER As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTPERMISSIONConnectionString1").ConnectionString)


        Dim SqlCmd As SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim objds As New DataSet
        Dim strSQL As String = String.Empty

#Region "MEMBER"

        ''' <summary>
        ''' ทำการส่ง Query เพื่อตรวจสอบงานทั้งหมดที่อยู่ในช่วงเวลานั้นออกมา
        ''' </summary>
        ''' <param name="rcvdate"></param>
        ''' <param name="fdtypecd"></param>
        ''' <param name="P_ID"></param>
        ''' <remarks></remarks>
        Public Sub SP_GET_FREGNTF_RCVDATE(ByVal rcvdate As Integer, ByVal fdtypecd As Integer, ByVal P_ID As Integer)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_FREGNTF_RCVDATE @rcvdate = '" & rcvdate & "',@FDTYPECD=" & fdtypecd & ",@P_ID=" & P_ID
            dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
        End Sub

        Public Sub SP_FOOD_FALCN_LCNSID(ByVal lcnsid As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FALCN_LCNSID @lcnsid = '" & lcnsid & "'"
            dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
        End Sub



        Public Sub SP_FOOD_FALCN_MONITOR(ByVal lcnsid As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FALCN_MONITOR @lcnsid = '" & lcnsid & "'"
            dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
        End Sub


        Public Sub SP_FOOD_FALCN_LCNSID_STAFF(ByVal lcnsid As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FALCN_LCNSID_STAFF @lcnsid = '" & lcnsid & "'"
            dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
        End Sub

        Public Function SP_FOOD_FREGNTF_EDIT(ByVal lcnno As Integer, ByVal lcnsid As Integer, ByVal fdtypecd As Integer) As DataTable

            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FREGNTF_EDIT @lcnno =" & lcnno & ",@lcnsid =" & lcnsid & ",@fdtypecd=" & fdtypecd
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function


        Public Function SP_FOOD_FREGNTF(ByVal lcnno As Integer, ByVal lcnsid As Integer, ByVal fdtypecd As Integer) As DataTable

            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FREGNTF @lcnno =" & lcnno & ",@lcnsid =" & lcnsid & ",@fdtypecd=" & fdtypecd
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        ''' <summary>
        ''' ดึงรายการของ ส่งออก แบ่งบรรจ อ้างอิงสูตร 
        ''' </summary>
        ''' <param name="type"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_FOOD_FREGNTF_BY_TYPE(ByVal lcnno As Integer, ByVal lcnsid As Integer, ByVal fdtypecd As Integer, ByVal type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_FOOD_FREGNTF_BY_TYPE @lcnno=" & lcnno & " ,@lcnsid= " & lcnsid & " ,@fdtypecd=" & fdtypecd & ",@type =" & type
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function


        ''' <summary>
        ''' ดึงรายการของ สบ 3 อ 14 17 สบ 5 reprocess
        ''' </summary>
        ''' <param name="type"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_FOOD_FREG_PRODUCT_BY_TYPE(ByVal lcnno As Integer, ByVal lcnsid As Integer, ByVal fdtypecd As Integer, ByVal type As Integer, ByVal process_id As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_FOOD_FREG_PRODUCT_BY_TYPE @lcnno=" & lcnno & " ,@lcnsid= " & lcnsid & " ,@fdtypecd=" & fdtypecd & ",@type =" & type & ",@process_id='" & process_id & "'"
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        Public Function SP_GET_FREG_PRODUCT_SORBOR3(ByVal process_id As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_FREG_PRODUCT_SORBOR3 @process_id=" & process_id
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        Public Function SP_STAFF_FREG_PRODUCT_SORBOR3(ByVal process_id As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_FREG_PRODUCT_SORBOR3 @process_id=" & process_id
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function



        Public Function SP_GET_SHOW_SORBOR3_CUS(ByVal lcnno As Integer, ByVal lcnsid As Integer, ByVal fdtypecd As Integer) As DataTable

            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_SHOW_SORBOR3_CUS @lcnno =" & lcnno & ",@lcnsid =" & lcnsid & ",@fdtypecd=" & fdtypecd
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function


        Public Function SP_FOOD_FALCN_STAFF_APPROVE_XML(ByVal xmlnm As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FALCN_STAFF_APPROVE_XML @xmlname = '" & xmlnm & "'"
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_FOOD_FALCN_STAFF_APPROVE(ByVal rcvno As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_FALCN_STAFF_APPROVE @rcvno = '" & rcvno & "'"
            Try
                dt = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        'Public Sub SP_MASTER_FAFMTCD()

        '    strSQL = "SP_MASTER_FAFMTCD"
        '    SqlCmd = New SqlCommand(strSQL, conn)
        '    If (conn.State = ConnectionState.Open) Then
        '        conn.Close()
        '    End If
        '    conn.Open()
        '    SqlCmd.CommandType = CommandType.StoredProcedure



        '    dtAdapter = New SqlDataAdapter(SqlCmd)
        '    dtAdapter.Fill(dt)
        '    conn.Close()

        'End Sub


        Public Sub SP_MASTER_fafdtype()

            strSQL = "SP_MASTER_fafdtype"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure



            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_FULLADDR_LCNSNM(ByVal lcnsid As Integer, ByVal lctcd As Integer)

            strSQL = "SP_FULLADDR_LCNSNM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.Int).Value = lcnsid
            SqlCmd.Parameters.Add("@lctcd", SqlDbType.Int).Value = lctcd



            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_MASTER_sysisocnt()

            strSQL = "SP_MASTER_sysisocnt"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_MASTER_syspdcfrgn()

            strSQL = "SP_MASTER_syspdcfrgn"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_MASTER_impcertp()

            strSQL = "SP_MASTER_impcertp"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub



        Public Sub SP_NODE_by_lcnno_pvncd_grpt(ByVal lcnno As Integer, ByVal pvncd As Integer, ByVal grpt As String)

            strSQL = "SP_NODE_by_lcnno_pvncd_grpt"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@lcnno", SqlDbType.Int).Value = lcnno
            SqlCmd.Parameters.Add("@pvncd", SqlDbType.Int).Value = pvncd
            SqlCmd.Parameters.Add("@grpt", SqlDbType.Int).Value = grpt


            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
#End Region


    End Class

    Public Class StoreProcudure
        Private _conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString
        Private _conn_xml As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DUMP_DATAConnectionString").ConnectionString
        Private _conn_Per As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTPERMISSIONConnectionString1").ConnectionString

        Public Sub New()

        End Sub



        Public Function SP_FALCN_EXPLAIN_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec [dbo].[SP_FALCN_EXPLAIN_FK_IDA] @FK_IDA='" & FK_IDA & "'"
            Dim dts As New DataTable
            Try
                dts = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dts
        End Function

        Public Function SP_CPN_GET_LOCATION(ByVal IDENTIFY As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec [dbo].[SP_CPN_GET_LOCATION] @IDENTIFY='" & IDENTIFY & "'"
            Dim dts As New DataTable
            Try
                dts = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dts
        End Function


        Public Function SP_SEARCH_FALCN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_SEARCH_FALCN"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        Public Function SP_GET_RUN_JOB(ByVal staffmax As Integer, ByVal FR_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec [dbo].[SP_GET_RUN_JOB] @staffmax=" & staffmax & ",@IDA=" & FR_IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function





        Public Sub SP_FOOD_INDEXING(ByVal FREG_IDA As Integer)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec [dbo].[SP_FOOD_INDEXING] @IDA=" & FREG_IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn_xml).Tables(0)
            Catch ex As Exception

            End Try
        End Sub

        Public Function SP_FOOD_PERMISSION_BRANCH(ByVal CITIZEN_ID As String, ByVal CITIZEN_AUTHORIZE As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_PERMISSION_BRANCH @citizen_id  = '" & CITIZEN_ID & "',@taxno_authorize = '" & CITIZEN_AUTHORIZE & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn_Per).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_FOOD_PERMISSION_BRANCH_DEMO(ByVal CITIZEN_ID As String, ByVal CITIZEN_AUTHORIZE As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FOOD_PERMISSION_BRANCH_DEMO @citizen_id  = '" & CITIZEN_ID & "',@taxno_authorize = '" & CITIZEN_AUTHORIZE & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn_Per).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function


        Public Function SP_SEARCH_FML_ACTIVE(ByVal FML_NAME As String, ByVal GENUS As String,
                                              ByVal SPECIE As String, ByVal PART_USED As String,
                                               ByVal SOLVEN_GROUP As String, ByVal ACTIVE As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_SEARCH_FML_ACTIVE " &
                "@FML_NAME  = '" & FML_NAME & "'" &
                ",@GENUS = '" & GENUS & "'" &
                ",@SPECIE = '" & SPECIE & "'" &
                ",@PART_USED = '" & PART_USED & "'" &
                ",@SOLVEN_GROUP = '" & SOLVEN_GROUP & "'" &
                ",@ACTIVE = '" & ACTIVE & "'"


            '        	@FML_NAME as nvarchar(255),
            '@GENUS as nvarchar(255),
            '@SPECIE as nvarchar(255),
            '@PART_USED as nvarchar(255),
            '@SOLVEN_GROUP as nvarchar(255),
            '@ACTIVE 

            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_PRODUCT_THAI_DUPLICATE(ByVal FK_ID As Integer, ByVal PRDNMT As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_PRODUCT_THAI_DUPLICATE @prdnmt  = '" & PRDNMT & "',@FK_IDA = " & FK_ID
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function





        Public Function SP_PRODUCT_ENG_DUPLICATE(ByVal FK_ID As Integer, ByVal PRDNME As String, ByVal CER_NUMBER As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_PRODUCT_ENG_DUPLICATE @prdnme  = '" & PRDNME & "',@FK_IDA = " & FK_ID & ",@CER_NUMBER='" & CER_NUMBER & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function


        'Public Function SP_GET_FML(ByVal FDANUMBER As String) As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_GET_FML @FDANUMBER = '" & FDANUMBER & "'"
        '    Dim dt As New DataTable
        '    Try
        '        dt = clsds.dsQueryselect(sql, _conn).Tables(0)
        '    Catch ex As Exception

        '    End Try

        '    Return dt
        'End Function


        Public Function SP_GET_FML_INACTIVE(ByVal FDANUMBER As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_FML_INACTIVE @FDANUMBER = '" & FDANUMBER & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function


        Public Function SP_NODE_FDSUBTP(ByVal fdtypecd As Integer, ByVal falcn_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NODE_FDSUBTP @fdtypecd = " & fdtypecd & ",@falcn_ida=" & falcn_ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        ''' <summary>
        ''' ดึงรายการคำขอ สบ3 หน้าเจ้าหน้าที่
        ''' </summary>
        ''' <param name="type"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_LIST_STAFF_SORBOR3(ByVal type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_LIST_STAFF_SORBOR3 @type = " & type
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function

        Public Function SP_NODE_FALCN_MTH(ByVal FK_IDA As Integer, ByVal fdtypecd As Integer, ByVal subpdt As Integer)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NODE_FALCN_MTH @FK_IDA = " & FK_IDA & ",@fdtypecd=" & fdtypecd & ",@subpdt=" & subpdt
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function


        Public Function SP_NODE_FDTYPE(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NODE_FDTYPE @FK_IDA = " & FK_IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_NODE_FDTYPE_REPROCESS(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NODE_FDTYPE_REPROCESS @FK_IDA = " & FK_IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function


        Public Function SP_NODE_FDTYPE_AOR17(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NODE_FDTYPE_AOR17 @FK_IDA = " & FK_IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_REPORT_ALL_JOB() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_REPORT_ALL_JOB"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function

        Public Function SP_MASTER_FML_GRID(ByVal CHEM_MAIN_TYPE As Integer, ByVal CITIZEN_AUTHORIZE As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MASTER_FML_GRID @CHEM_MAIN_TYPE = " & CHEM_MAIN_TYPE & ",@CITIZEN_AUTHORIZE ='" & CITIZEN_AUTHORIZE & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        'Public Function SP_MASTER_FML_SECRET_GRID(ByVal lcnsid As Integer) As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_MASTER_FML_SECRET_GRID @LCNSID = " & lcnsid
        '    Dim dt As New DataTable
        '    Try
        '        dt = clsds.dsQueryselect(sql, _conn).Tables(0)
        '    Catch ex As Exception

        '    End Try

        '    Return dt

        'End Function


        Public Function SP_STAFF_MASTER_FML_GRID(ByVal lcnsid As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_MASTER_FML_GRID @LCNSID = " & lcnsid
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        ''' <summary>
        ''' ดึง SPECIE หน้าเพิ่มสารสกัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_SPECIE_DROPDOWN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_SPECIE_DROPDOWN"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        ''' <summary>
        ''' ดึง PART_USED หน้าเพิ่มสารสกัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_PART_USED_DROPDOWN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_PART_USED_DROPDOWN"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        ''' <summary>
        ''' ดึง GENUS หน้าเพิ่มสารสกัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_GENUS_DROPDOWN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_GENUS_DROPDOWN"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

        ''' <summary>
        ''' ดึง SOLVEN หน้าเพิ่มสารสกัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_SOLVEN_DROPDOWN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_SOLVEN_DROPDOWN"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try
            Return dt

        End Function

        ''' <summary>
        ''' ดึง SOLVEN หน้าเพิ่มสารสกัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_GET_MAS_ACTIVE() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_MAS_ACTIVE"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, _conn).Tables(0)
            Catch ex As Exception

            End Try

            Return dt

        End Function

    End Class



    Public Class GenNumber

        'CODE แปลงเลข 5900001
        Public Function FORMAT_NUMBER_FULL(ByVal YEAR As String, ByVal int_no As Integer) As String
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            Return str_no
        End Function

        ''' <summary>
        '''  GENNO_NO_01
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GEN_NO_01(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal REF_IDA As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsGEN_LCNNO
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, REF_IDA)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no

            dao = New DAO_MDC_CER.clsGEN_LCNNO
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()

            Return str_no
        End Function

        Function GEN_NO_COMMON_ID(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                       ByVal FORMAT As String, ByVal REF_IDA As String, ByVal RCVNO As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsGEN_COMMON_ID
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, REF_IDA)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:000}", int_no.ToString("000"))
            str_no = PVCODE & TYPE & RCVNO & str_no

            dao = New DAO_MDC_CER.clsGEN_COMMON_ID
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()

            Return str_no
        End Function
        'CODE แปลงเลข ให้รองรับแบบ 1/59
        Public Function FORMAT_NUMBER_MINI(ByVal YEAR As String, ByVal int_no As Integer) As String
            Dim str_no As String = int_no & "/" & YEAR.Substring(2, 2)
            Return str_no
        End Function

        'ควรแบ่ง CODE ออกเป็น 2 ส่วน Code ที่ 1 เป็น CODE ดึงเลข
        Public Function GEN_RCVNO_NO(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer, ByVal type As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID, type)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_RCV = int_no
            dao.fields.GEN_TYPE = type
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function

        Public Function GEN_NUMBERs(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer, ByVal type As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsTBGEN_NUMBER
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID, type)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1
            dao = New DAO_MDC_CER.clsTBGEN_NUMBER
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_TYPE = type
            dao.fields.GEN_RCV = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = "" & str_no
            dao.insert()
            Return str_no
        End Function

        Public Function GEN_RCVNO_NO01(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer, ByVal type As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID, type)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1
            dao = New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_TYPE = type
            dao.fields.GEN_RCV = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            If type = 1 And PROCESS_ID = 501000 Then
                dao.fields.DESCRIPTION = "ELM " & str_no
            ElseIf type = 2 And PROCESS_ID = 501000 Then
                dao.fields.DESCRIPTION = "ELI " & str_no
            ElseIf type = 3 And PROCESS_ID = 501000 Then
                dao.fields.DESCRIPTION = "SI " & str_no
            ElseIf type = 1 And PROCESS_ID = 504001 Then
                dao.fields.DESCRIPTION = "MN " & str_no
            ElseIf type = 2 And PROCESS_ID = 504001 Then
                dao.fields.DESCRIPTION = "NI " & str_no
            ElseIf type = 1 And PROCESS_ID = 505001 Then
                dao.fields.DESCRIPTION = "M1 " & str_no
            ElseIf type = 2 And PROCESS_ID = 505001 Then
                dao.fields.DESCRIPTION = "I1 " & str_no
            ElseIf type = 1 And PROCESS_ID = 501002 Then
                dao.fields.DESCRIPTION = "ME " & str_no
            ElseIf type = 2 And PROCESS_ID = 501002 Then
                dao.fields.DESCRIPTION = "NE " & str_no
            ElseIf type = 1 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "10EXM " & str_no
            ElseIf type = 2 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "10EXI " & str_no
            ElseIf type = 3 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "S2 " & str_no
            ElseIf type = 4 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "MX " & str_no
            ElseIf type = 5 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "IX " & str_no
            ElseIf type = 6 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "M2 " & str_no
            ElseIf type = 7 And PROCESS_ID = 501020 Then
                dao.fields.DESCRIPTION = "I2 " & str_no
            End If
            dao.insert()
            Return str_no
        End Function
        Public Function GEN_PAYMENTCD(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String,
                                      ByVal FK_IDA As Integer, ByVal type As Integer) As String
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_NO_TYPE(PVNCD, YEAR, PROCESS_ID)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1
            dao = New DAO_MDC_CER.clsTBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_TYPE = type
            dao.fields.GEN_RCV = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & PVNCD & type & str_no
            Return str_no
        End Function
        Public Function GEN_LCNNO(ByVal YEAR As String, ByVal PVNCD As String, ByVal TYPE As Integer, ByVal PROCESS_ID As Integer, ByVal FK_IDA As Integer) As Integer
            Dim int_no As Integer = 1000

            Dim dao As New DAO_MDC_CER.clsGEN_LCNNO
            dao.GetDataby_Year_PVNCD_MAX(PVNCD, YEAR, TYPE, PROCESS_ID)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1

            dao = New DAO_MDC_CER.clsGEN_LCNNO
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.TYPE = TYPE
            dao.fields.GENNO = int_no
            dao.fields.GROUP_NO = PROCESS_ID
            dao.fields.REF_IDA = FK_IDA
            'Dim dao_ch As New DAO_CPN.clsDBsyschngwt
            'dao_ch.GetData_by_chngwtcd(PVNCD)
            Dim bao As New gen_no
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{00:000}", int_no.ToString("000"))
         
            str_no = "01" & str_no
            dao.fields.LCNNO = str_no
            If PROCESS_ID = "509000" Then
                dao.fields.DESCRIPTION = "CER " & str_no

            Else
                dao.fields.DESCRIPTION = str_no

            End If

            dao.insert()
            Return str_no
        End Function
        'ควรแบ่ง CODE ออกเป็น 2 ส่วน Code ที่ 1 เป็น CODE ดึงเลข
        Public Function GEN_DOCNO(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.TB_GEN_DOCNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID)
            If IsNothing(dao.fields.GEN_DOC) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_DOC
            End If
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_MDC_CER.TB_GEN_DOCNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_DOC = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function

        'ควรแบ่ง CODE ออกเป็น 2 ส่วน Code ที่ 1 เป็น CODE ดึงเลข
        Public Function GEN_RefCerNo(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.TB_GEN_RefCerNo
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID)
            If IsNothing(dao.fields.GEN_RefCer) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RefCer
            End If
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_MDC_CER.TB_GEN_RefCerNo
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_RefCer = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function

        Public Function GEN_RefItemNo(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal manucd As Integer, ByVal FK_IDA As Integer) As String
            Dim int_no As Integer
            Dim dao As New DAO_MDC_CER.TB_GEN_RefItemNo
            dao.GetDataby_Year_PVNCD_PROCESS_ID_manucd_MAX(PVNCD, YEAR, PROCESS_ID, manucd)
            If IsNothing(dao.fields.GEN_RefItem) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RefItem
            End If
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:000000}", int_no.ToString("000000"))
            Dim manu_no As String = manucd.ToString()
            manu_no = String.Format("{0:00000}", manucd.ToString("00000"))
            Dim str_manu_no As String = "5" & manu_no & str_no
            dao = New DAO_MDC_CER.TB_GEN_RefItemNo
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.MANU_CD = manucd
            dao.fields.GEN_RefItem = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.DESCRIPTION = str_manu_no
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_manu_no
        End Function

        Function GEN_RCVNO_NO(p1 As String, p2 As String, p3 As String, p4 As String, nullable As Integer?) As String
            Throw New NotImplementedException
        End Function


    End Class

    Class gen_no
        ''' <summary>
        ''' gen เลขรับ
        ''' </summary>
        ''' <param name="YEAR">ปี</param>
        ''' <param name="PVCODE">จังหวัด</param>
        ''' <param name="TYPE">ประเภทใบอนุญาต</param>
        ''' <param name="LCNNO">เลขใบอนุญาต</param>
        ''' <param name="FORMAT">รูปแบบการแปลง</param>
        ''' <param name="GROUP_NO"></param>
        ''' <param name="REF_IDA"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GEN_RCVNO(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String) As String
            Dim num As Integer

            Dim dao As New DAO_MDC_CER.TB_MDC_CER_GEN_RCV_NO
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA)

            If IsNothing(dao.fields.GENNO) = True Then
                num = 0
            Else
                num = dao.fields.GENNO
            End If

            num = num + 1

            dao = New DAO_MDC_CER.TB_MDC_CER_GEN_RCV_NO

            Dim str_no As String = num.ToString()
            str_no = String.Format("{0:00000}", num.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            If TYPE = 1 Then
                dao.fields.DESCRIPTION = "ELM " & str_no
            ElseIf TYPE = 2 Then
                dao.fields.DESCRIPTION = "ELI " & str_no
            End If

            dao.fields.GENNO = num
            dao.insert()
            Return str_no
        End Function

        Public Function FORMAT_NUMBER_MINI_YEAR_FULL(ByVal YEAR As String, ByVal int_no As Integer) As String
            Dim str_no As String = int_no

            'str_no = str_no.Substring(2, 5)
            'int_no = CDec(str_no)

            str_no = int_no & "/" & YEAR
            Return str_no
        End Function
    End Class

    Public Class ClsDBSqlCommand2                                         'Class นี้สร้างเอาไว้รับหรือเก็บข้อมูล
        Public dt As New DataTable
        Dim rdr As SqlDataReader
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString)
        Dim conn_CPN As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString1").ConnectionString)
        Dim SqlCmd As SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim objds As New DataSet
        Dim strSQL As String = String.Empty




        Public Sub GetDataby_lcnsid_thanm(ByVal lcnsid As Integer)

            strSQL = "SP_MEMBER_LCNSID_THANM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_lcnsid_type_status(ByVal lcnsid As Integer, ByVal type As Integer)

            strSQL = "SP_MEMBER_LCNSID_TYPE_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid
            SqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type
            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_thanm_thanm(ByVal thanm As String)

            strSQL = "SP_MEMBER_THANM_THANM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@thanm", SqlDbType.VarChar).Value = thanm

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub



        Public Sub GetDataby_lcnsid_addr(ByVal lcnsid As Integer)

            strSQL = "SP_MEMBER_LCNSID_ADDR"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        Public Sub SP_MEMBER_LCNSID_FULLADDR(ByVal lcnsid As Integer)

            strSQL = "SP_MEMBER_LCNSID_FULLADDR"
            SqlCmd = New SqlCommand(strSQL, conn_CPN)
            If (conn_CPN.State = ConnectionState.Open) Then
                conn_CPN.Close()
            End If
            conn_CPN.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn_CPN.Close()

        End Sub

        Public Sub GetDataby_lcnsid_falcn(ByVal lcnsid As Integer)

            strSQL = "SP_FOOD_FALCN_LCNSID"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub GetDataby_lcnno_falcn(ByVal lcnno As Integer)

            strSQL = "SP_FOOD_FALCN_LCNNO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@lcnno", SqlDbType.VarChar).Value = lcnno


            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_lcnsid_freg(ByVal lcnsid As Integer)

            strSQL = "SP_FOOD_FREG_LCNSID"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid



            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub








    End Class


    Public Class AppSettings 'Path พวกนี้ไปเรียกมาจาก Web.Config อีกที
        Public _PATH_PDF_TEMPLATE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
        Public _PATH_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
        Public _PATH_PDF_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
        Public _PATH_PDF_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
        Public _PATH_XML_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
        Public _PATH_UPLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_UPLOAD")
        Public _PATH_PDF_UPLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_DOWNLOAD")
        Public _PATH_XML_UPLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_DOWNLOAD")
        Public _PATH_DEFAULT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT")
        Public _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_FILE")
        Public _PATH_WORD_TEMPLATE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_FILE")
        Public _STATUS_DEMO As String = System.Configuration.ConfigurationManager.AppSettings("STATUS_DEMO")


        Public _DOMAIN As String = System.Configuration.ConfigurationManager.AppSettings("DOMAIN_PERMISSION")

        Sub RunAppSettings()
            _PATH_PDF_TEMPLATE = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
            _PATH_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
            _PATH_PDF_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
            _PATH_PDF_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
            _PATH_XML_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
            _PATH_UPLOAD = System.Configuration.ConfigurationManager.AppSettings("PATH_UPLOAD")
            _PATH_DEFAULT = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT")
            _DOMAIN = System.Configuration.ConfigurationManager.AppSettings("DOMAIN_PERMISSION")
        End Sub
    End Class

    Public Class convert_num
        Function con_lcnno(ByVal ID As String)
            Dim str_lcnno As String = " "
            Dim dao_falcn As New DAO.clsDBfalcn
            dao_falcn.GetDataby_ID(ID)
            If dao_falcn.fields.lcnno <> 0 Then
                str_lcnno = dao_falcn.fields.pvncd.ToString() & "-" & dao_falcn.fields.lcntypecd.ToString().Substring(1, 1) & "-" & dao_falcn.fields.lcnno.ToString().Substring(0, 2) & dao_falcn.fields.lcnno.ToString().Substring(4, 3)
            End If

            Return str_lcnno
        End Function
        Function con_lcntype(ByVal ID As String)
            Dim str_lcntype As String
            Dim dao_falcn As New DAO.clsDBfalcn
            Dim dao_falcntype As New DAO.clsDBfalcntype
            dao_falcn.GetDataby_ID(ID)
            dao_falcntype.GetDataby_lcntypecd(dao_falcn.fields.lcntypecd)
            str_lcntype = dao_falcntype.fields.lcntypenm
            Return str_lcntype
        End Function
    End Class

    Public Class calculate_working
        Private _rcvdatew As Date
        Public Property rcvdatew() As Date
            Get
                Return _rcvdatew
            End Get
            Set(ByVal value As Date)
                _rcvdatew = value
            End Set
        End Property
        Private _findatew As Date
        Public Property findatew() As Date
            Get
                Return _findatew
            End Get
            Set(ByVal value As Date)
                _findatew = value
            End Set
        End Property
        Public Sub work_custom(ByVal Process_ID As Integer, ByVal TR_ID As Integer, ByVal days As Integer)
            Dim bao_work As New BAO.working_date

            Dim rcvdate As Date = Date.Now
            Dim hour As Integer = Date.Now.Hour
            Dim minute As Integer = Date.Now.Minute

            ' For i As Integer = 0 To days
            bao_work.working_schedule(rcvdate, Process_ID, 1, hour, minute)
            rcvdate = bao_work.rcdate 'คำนวนวันที่ต้องรับงาน
            '   Next
            Dim dao_SCHEDULE As New DAO.CFS.clsDBWORK_SCHEDULE
            dao_SCHEDULE.fields.RECEIVE_DATE = Date.Now
            dao_SCHEDULE.fields.CONSIDER_DATE = rcvdate



            bao_work.finishdate = rcvdate
            Dim temp As String = ""
            '   bao_work.working_Holiday(rcvdate.AddDays(1))
            For i As Integer = 0 To days - 1        'คำนวนวันที่ต้องเสร็จ
                bao_work.working_Holiday(bao_work.finishdate.AddDays(1))


            Next

            dao_SCHEDULE.fields.COMPLETE_DATE = bao_work.finishdate
            dao_SCHEDULE.fields.TRANSECTION_ID = TR_ID
            dao_SCHEDULE.fields.PROCESS_ID = Process_ID
            dao_SCHEDULE.insert()
            'bao_work.working_Holiday(bao_work.finishdate.AddDays(1))

            _findatew = bao_work.finishdate
            _rcvdatew = rcvdate
        End Sub


    End Class
    Public Class working_date
        Private _rcdate As Date
        Public Property rcdate() As Date
            Get
                Return _rcdate
            End Get
            Set(ByVal value As Date)
                _rcdate = value
            End Set
        End Property


        Private _finishdate As Date
        Public Property finishdate() As Date
            Get
                Return _finishdate
            End Get
            Set(ByVal value As Date)
                _finishdate = value
            End Set
        End Property


        ''' <summary>
        ''' ตรวจสอบวันหยุด
        ''' </summary>
        ''' <param name="finishdate"></param>
        ''' <remarks></remarks>
        Public Sub working_Holiday(ByVal finishdate As Date)
            Dim dao_work_holiday As New DAO_CPN.tb_workday
            dao_work_holiday.GetDataby_holiday(finishdate)
            If finishdate.DayOfWeek = DayOfWeek.Saturday Or finishdate.DayOfWeek = DayOfWeek.Sunday Then
                working_Holiday(DateAdd(DateInterval.Day, 1, finishdate))
            Else
                If dao_work_holiday.fields.IDA = 0 Then
                    _finishdate = finishdate

                Else
                    working_Holiday(DateAdd(DateInterval.Day, 1, finishdate))
                End If
            End If

        End Sub

        Public Sub working_schedule(ByRef rcvdate As Date, ByVal PROCESS_ID As String, ByVal SYSTEM_ID As String, ByVal hour As Integer, ByVal minute As Integer)
            rcvdate = CDate(rcvdate).ToShortDateString()
            _rcdate = rcvdate
            'ขั้นตอนการคำนวนวัน
            '1 ทำการดึงจำนวน Limit ออกมาก่อน
            '2 ทำการค้นหาวัน ณ ปัจจุบันออกมาแล้วทำการ นับจำนวนว่าเกิน limit หรือป่าว

            '   Dim work_date As Date = Date.Now() 'วัน ณ ปัจจุบัน

            'Dim hour As Integer = Date.Now.Hour
            'Dim minute As Integer = Date.Now.Minute


            Dim dao_LIMIT As New DAO.CFS.clsDBWORK_LIMIT
            dao_LIMIT.GetDataby_PROCESS_ID_and_SYSTEM_ID(PROCESS_ID, SYSTEM_ID) 'Process รวม 3 อัน 36 ต่อวัน

            Dim limit_day As Integer = 0
            limit_day = dao_LIMIT.fields.WORK_LIMIT
            ' limit_day = 1

            Dim dao_SCHEDULE As New DAO.CFS.clsDBWORK_SCHEDULE
            dao_SCHEDULE.Getdataby_CONSIDER_DATE(CDate(rcvdate).ToShortDateString(), PROCESS_ID)

            Dim total_job As Integer = dao_SCHEDULE.Details.Count



            'ตรวจสอบ เสาร์ อาทิตย์
            If rcvdate.DayOfWeek = DayOfWeek.Saturday Then
                working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
            ElseIf rcvdate.DayOfWeek = DayOfWeek.Sunday Then
                working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
            Else
                'ตรวจสอบ วันหยุด
                Dim dao_work_holiday As New DAO_CPN.tb_workday
                dao_work_holiday.GetDataby_holiday(rcvdate)
                If dao_work_holiday.fields.IDA = 0 Then ' ในกรณีไม่มีวันหยุด
                    If total_job > limit_day Then ' ตรวจสอบจำนวนงานถ้าเกิน
                        working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
                    Else 'ในกรณีไม่เกิน
                        If hour = 15 Then 'ตรวจสอบ ชม. ว่ามากกว่า บ่าย 3 หรือป่าว
                            If minute > 30 Then
                                working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
                            End If
                        ElseIf hour > 15 Then
                            working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
                        End If
                    End If
                Else 'ในกรณีมีวันหยุด
                    working_schedule(DateAdd(DateInterval.Day, 1, rcvdate), PROCESS_ID, SYSTEM_ID, 0, 0)
                End If
            End If

        End Sub
    End Class


    Public Class information
        Public Function load_name(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm

            dao_syslcnsid.GetDataby_identify(_CLS.CITIZEN_ID)
            dao_sysnmperson.GetDataby_identify(_CLS.CITIZEN_ID)
            _CLS.LCNSID = dao_syslcnsid.fields.lcnsid

            If String.IsNullOrEmpty(dao_sysnmperson.fields.thalnm) = True Or dao_sysnmperson.fields.thalnm = Nothing Then
                _CLS.thanm = dao_sysnmperson.fields.thanm
            Else
                _CLS.thanm = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
            End If
            Return _CLS
            '     Session("CLS") = _CLS
        End Function


        Public Function load_lcnsid_customer(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            _CLS.LCNSID_CUSTOMER = dao_syslcnsid.fields.ID_main


            If String.IsNullOrEmpty(dao_sysnmperson.fields.thalnm) = True Or dao_sysnmperson.fields.thalnm = Nothing Then
                '    Session("thanm_customer") = dao_sysnmperson.fields.thanm
                _CLS.THANM_CUSTOMER = dao_sysnmperson.fields.thanm
            Else
                '     Session("thanm_customer") = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
                _CLS.THANM_CUSTOMER = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
            End If
            Return _CLS
        End Function
    End Class




End Namespace