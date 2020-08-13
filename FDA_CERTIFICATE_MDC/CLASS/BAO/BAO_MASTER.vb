Imports System.Data.SqlClient

Public Class BAO_MASTER
    Public conn2 As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_MDC_DEMOConnectionString").ConnectionString
    Public dt As New DataTable
    Public Function Queryds(ByVal Commands As String) As DataTable
        Dim dt As New DataTable
        Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_MDC_DEMOConnectionString").ConnectionString)
        Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
        mySqlDataAdapter.Fill(dt)
        MyConnection.Close()
        Return dt
    End Function

    Function AddDatatable(ByVal dt As DataTable) As DataTable
        Dim dr As DataRow = dt.NewRow
        For Each c As DataColumn In dt.Columns
            If c.DataType.Name.ToString() = "String" Then
                dr(c.ColumnName) = "-"
            ElseIf c.DataType.Name.ToString() = "Int32" Then
                dr(c.ColumnName) = 0
            ElseIf c.DataType.Name.ToString() = "DateTime" Then
                dr(c.ColumnName) = Date.Now 'Nothing 
            Else
                Try
                    dr(c.ColumnName) = Nothing
                Catch ex As Exception
                    dr(c.ColumnName) = 0
                End Try


            End If

        Next

        dt.Rows.Add(dr)
        Return dt
    End Function
    Public Function SP_MASTER_MDC_IRSCOPE() As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = " exec SP_MASTER_MDC_IRSCOPE"
        dt = Queryds(command)
        dt.TableName = "SP_MASTER_MDC_IRSCOPE"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' ดึงข้อมูลจาก SP_MASTER_MDC_IRSCOPELV1
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_MDC_IRSCPLVL1() As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = " exec SP_MASTER_MDC_IRSCPLVL1"
        dt = Queryds(command)
        dt.TableName = "SP_MASTER_MDC_IRSCPLVL1"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MASTER_MDC_IGIMUNULU(ByVal lcnsid As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MASTER_MDC_IGIMUNULU @lcnsid=" & lcnsid
        dt = Queryds(command)
        dt.TableName = "SP_MASTER_MDC_IGIMUNULU"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_COMMON_NAME_BY_LCNSID_IDA(ByVal lcnsid As Integer, ByVal IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_COMMON_NAME_BY_LCNSID_IDA @lcnsid=" & lcnsid & ",@IDA=" & IDA
        dt = Queryds(command)
        dt.TableName = "SP_MDC_COMMON_NAME_BY_LCNSID_IDA"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_LISTING_TEMPLATE(ByVal type As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_LISTING_TEMPLATE @type=" & type
        dt = Queryds(command)
        dt.TableName = "SP_LISTING_TEMPLATE"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_LISTING_RULE(ByVal type As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_LISTING_RULE @type=" & type
        dt = Queryds(command)
        dt.TableName = "SP_LISTING_RULE"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MASTER_MDC_DATABLANK_IGIMP(ByVal lcnsid As Integer, ByVal IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MASTER_MDC_DATABLANK_IGIMP @lcnsid=" & lcnsid & ",@IDA=" & IDA
        dt = Queryds(command)
        dt.TableName = "SP_MASTER_MDC_DATABLANK_IGIMP"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_DATABLANK_IGIMP(ByVal lcnsid As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_DATABLANK_IGIMP @lcnsid=" & lcnsid
        dt = Queryds(command)
        dt.TableName = "SP_MDC_DATABLANK_IGIMP"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_COMMON_NAME_BY_LCNSID(ByVal lcnsid As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_COMMON_NAME_BY_LCNSID @lcnsid=" & lcnsid
        dt = Queryds(command)
        dt.TableName = "SP_MDC_COMMON_NAME_BY_LCNSID"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' สถานที่เก็บ Dropdown
    ''' </summary>
    ''' <param name="lcnsid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function SP_MDC_LCN_KEEP_BY_LCNSID(ByVal lcnsid As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_LCN_KEEP_BY_LCNSID @lcnsid = '" & lcnsid & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_MDC_LCN_KEEP_BY_LCNSID"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    ''' <summary>
    ''' สถานที่ เอาแค่ตัวแรก
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function SP_LCN_KEEP_TOP1_BY_FK_IDA(ByVal FK_IDA As String, ByVal RESULT As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_LCN_KEEP_TOP1_BY_FK_IDA @FK_IDA = '" & FK_IDA & "',@RESUAL='" & RESULT & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_LCN_KEEP_TOP1_BY_FK_IDA"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    ''' <summary>
    ''' สถานที่เก็บ เอา row 2 ขึ้นไป
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function SP_LCN_KEEP_ROW2_BY_FK_IDA(ByVal FK_IDA As String, ByVal RESULT As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_LCN_KEEP_ROW2_BY_FK_IDA @FK_IDA = '" & FK_IDA & "',@RESULT='" & RESULT & "'"

    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_LCN_KEEP_ROW2_BY_FK_IDA"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function

    'Public Function SP_LCN_KEEP_BY_IDA(ByVal FK_IDA As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_LCN_KEEP_BY_IDA @FK_IDA = '" & FK_IDA & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_LCN_KEEP_BY_IDA"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    ''' <summary>
    ''' ข้อมูลสถานประกอบการ
    ''' </summary>
    ''' <param name="rgtno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function SP_MDC_IRGT_ADDR_BY_IDA_RGTTPCD(ByVal rgtno As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_IRGT_ADDR_BY_IDA_RGTTPCD @rgtno = '" & rgtno & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_MDC_IRGT_ADDR_BY_IDA_RGTTPCD"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function

    'Public Function SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(ByVal identify As String, ByVal LCNSID As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid='" & LCNSID & "' ,@identify= '" & identify & "'"
    '    ' Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid=" & "0" & " ,@identify=" & "0"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    dt.TableName = "SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY"
    '    Return dt
    'End Function
    '''' <summary>
    '''' ชื่อย่อประเทศ
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function SP_MDC_SYSISOCNT() As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_SYSISOCNT"
    '    Dim dt As New DataTable
    '    dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '    dt.TableName = "SP_MDC_SYSISOCNT"
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    '''' <summary>
    '''' ผู้ผลิตต่างประเทศ
    '''' </summary>
    '''' <param name="lcnsid"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function SP_MDC_IGIMANULU_BY_LCNSID(ByVal lcnsid As String) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_IGIMANULU_BY_LCNSID @lcnsid = '" & lcnsid & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        'dt = Queryds(sql)
    '        dt.TableName = "SP_MDC_IGIMANULU_BY_LCNSID"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    'Public Function SP_MDC_IRGT_BY_IDA(ByVal FK_IDA As Integer) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_IRGT_BY_IDA @FK_IDA = '" & FK_IDA & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        'dt = Queryds(sql)
    '        dt.TableName = "SP_MDC_IRGT_BY_IDA"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt


    'End Function
    'Public Function SP_BSN_ADDR_BY_BSNID(ByVal BSN_ID As Integer) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_BSN_ADDR_BY_BSNID @bsnid = '" & BSN_ID & "'"
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        'dt = Queryds(sql)
    '        dt.TableName = "SP_BSN_ADDR_BY_BSNID"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt
    'End Function
    Public Function SP_ADDR_KEEP_BY_RNO(ByVal rno As Integer, ByVal result As Integer, ByRef rgttpcd As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_ADDR_KEEP_BY_RNO @rno =" & rno & ",@RESULT=" & result & ",@RGTTPCD=" & rgttpcd
        Dim dt As New DataTable
        Try
            'dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt = Queryds(sql)
            dt.TableName = "SP_ADDR_KEEP_BY_RNO"
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_IRGT_SCOPE_TEMPLATE() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_IRGT_SCOPE_TEMPLATE"
        Dim dt As New DataTable
        Try
            'dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt = Queryds(sql)
            dt.TableName = "SP_MDC_IRGT_SCOPE_TEMPLATE"
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    Public Function SP_MDC_IRGT_DEVICE_TEMPLATE(ByVal device As String, ByVal result As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_IRGT_DEVICE_TEMPLATE @device =" & device & ",@result =" & result
        Dim dt As New DataTable
        Try
            'dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt = Queryds(sql)
            dt.TableName = "SP_MDC_IRGT_DEVICE_TEMPLATE"
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt


    End Function
    Public Function SP_IRGT_SCOPE_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_IRGT_SCOPE_BY_FK_IDA @FK_IDA =" & fk_ida
        Dim dt As New DataTable
        Try
            'dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt = Queryds(sql)
            dt.TableName = "SP_IRGT_SCOPE_BY_FK_IDA"
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt


    End Function
    'Public Function SP_MDC_MN_BY_IDA(ByVal IDA As Integer) As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_MDC_MN_BY_IDA @IDA =" & IDA
    '    Dim dt As New DataTable
    '    Try
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_MDC_MN_BY_IDA"
    '        If dt.Rows.Count() = 0 Then
    '            dt = AddDatatable(dt)
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If dt.Rows.Count() = 0 Then
    '        dt = AddDatatable(dt)
    '    End If
    '    Return dt


    'End Function

    Public Function SP_MDC_MN_BY_IDA(ByVal IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_MN_BY_IDA @IDA=" & IDA
        dt = Queryds(command)
        dt.TableName = "SP_MDC_MN_BY_IDA"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_MR_BY_IDA(ByVal IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_MR_BY_IDA @IDA=" & IDA
        dt = Queryds(command)
        dt.TableName = "SP_MDC_MR_BY_IDA"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    Public Function SP_MDC_CER_BY_IDA(ByVal IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim command As String = " "
        command = "exec SP_MDC_CER_BY_IDA @IDA=" & IDA
        dt = Queryds(command)
        dt.TableName = "SP_MDC_CER_BY_IDA"

        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_COUNTRY() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_COUNTRY"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_COUNTRY"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_SHOW(ByVal lcnsid As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_SHOW @lcnsid=" & lcnsid 'ไปเอาDataProcudure ที่ Field lcnsid มาเก็บไว้
        Dim dt As New DataTable 'ประกาศ dt ให้เป็น DataTable เก็บข้อมูลเป็นตาราง
        dt = clsds.dsQueryselect(sql, conn2).Tables(0) 'conn2 ถูกประกาศไว้เป็น String อยู่ที่หัวบนสุด
        dt.TableName = "SP_MDC_CER_SHOW"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_SHOW_STAFF() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_SHOW_STAFF"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_SHOW_STAFF"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_SHOW_STAFF_CHECK_LIST10() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_SHOW_STAFF_CHECK_LIST10"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_SHOW_STAFF_CHECK_LIST10"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_SHOW_BY_SEARCH_TR_ID(ByVal tr_id As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_SHOW_BY_SEARCH_TR_ID @TR_ID=" & tr_id
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_SHOW_BY_SEARCH_TR_ID"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_SHOW_BY_SEARCH_RCV(ByVal rcvno As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_SHOW_BY_SEARCH_RCV @rcvno=" & rcvno
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_SHOW_BY_SEARCH_RCV"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    Public Function SP_MAS_STATUS_STAFF_BY_GROUP_DDL(ByVal _stat_group As Integer, ByVal _group As Integer, ByVal _process_id As Integer)

        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL @stat_group=" & _stat_group & ",@group=" & _group & ",@process_id=" & _process_id
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MAS_STATUS_STAFF_BY_GROUP_DDL"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt

    End Function

    Public Function SP_MDC_CER_PRODUCT(ByVal lcnsid As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_PRODUCT @lcnsid=" & lcnsid
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_PRODUCT"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MDC_CER_PRODUCT_STAFF(ByVal ida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MDC_CER_PRODUCT_STAFF @ida=" & ida
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        dt.TableName = "SP_MDC_CER_PRODUCT_STAFF"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
End Class
