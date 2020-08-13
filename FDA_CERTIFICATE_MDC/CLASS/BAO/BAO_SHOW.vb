Public Class BAO_SHOW

    Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString

    ''' <summary>
    ''' ใส่ค่าว่างใน DT
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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



    ''' <summary>
    ''' ดึงข้อมูล จังหวัด
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSCHNGWT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSCHNGWT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSCHNGWT"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ดึงข้อมูล อำเภอ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSAMPHR() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSAMPHR"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSAMPHR"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' ดึงข้อมูล ตำบล
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSTHMBL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSTHMBL"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSTHMBL"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' ดึงข้อมูล ประเทศ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSISOCNT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSISOCNT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSISOCNT"
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' ดึงข้อมูลจากเลขบัตรประชาชน
    ''' </summary>
    ''' <param name="CTZNO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MAINPERSON_CTZNO(ByVal CTZNO As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINPERSON_CTZNO @ctzno = '" & CTZNO & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_MAINPERSON_CTZNO"
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

    ''' <summary>
    ''' ที่อยู่ bsn ผู้ดำเนินกิจการ
    ''' </summary>
    ''' <param name="LOCATION_ADDRESS_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(ByVal LOCATION_ADDRESS_IDA As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA @LOCATION_ADDRESS_IDA = '" & LOCATION_ADDRESS_IDA & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
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

    Public Function SP_MAINCOMPANY_LCNSID(ByVal lcnsid As Integer, ByVal lctcd As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINCOMPANY_LCNSID @lcnsid = " & lcnsid & ",@lctcd = " & lctcd
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_MAINCOMPANY"
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

    Public Function SP_MAINCOMPANY_IDENTIFY(ByVal identify As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINCOMPANY_IDENTIFY @identify = '" & identify & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_MAINCOMPANY_IDENTIFY"
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

    Public Function SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY(ByVal THANM As String, ByVal IDENTIFY As String) As DataTable
        Dim clsds As New ClassDataset
        'Dim sql As String = "exec SP_MEMBER_THANM_THANM @THANM= '" & THANM & "' ,@IDENTIFY = '" & IDENTIFY & "' "
        Dim sql As String = "exec SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY @THANM= '" & THANM & "' ,@IDENTIFY = '" & IDENTIFY & "' "
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_MAINCOMPANY_IDENTIFY"
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

    ''' <summary>
    ''' คำนำหน้าชื่อของคน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>type 1 ,8 </remarks>
    Public Function SP_SYSPREFIX() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSPREFIX"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_SYSPREFIX"
        Return dt
    End Function

    ''' <summary>
    ''' คำลงท้ายชื่อ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSSUFFIX() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSSUFFIX"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_SYSSUFFIX"
        Return dt
    End Function


    ''' <summary>
    ''' สถานที่จำลองตามtype
    ''' </summary>
    ''' <param name="LOCATION_TYPE_CD"></param>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks>0 หลัก,1ที่อยู่,2เก็บ,3อื่นๆ</remarks>
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(ByVal LOCATION_TYPE_CD As Integer, ByVal LCNSID As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID @LOCATION_TYPE_CD= " & LOCATION_TYPE_CD & " ,@LCNSID= '" & LCNSID & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Return dt
    End Function


    ''' <summary>
    ''' ข้อมูลบริษัท
    ''' </summary>
    ''' <param name="identify"></param>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(ByVal identify As String, ByVal LCNSID As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid='" & LCNSID & "' ,@identify= '" & identify & "'"
        ' Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid=" & "0" & " ,@identify=" & "0"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY"
        Return dt
    End Function


    ''' <summary>
    ''' สถานที่จำลอง
    ''' </summary>
    ''' <param name="LOCATION_ADDRESS_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA"
        Return dt
    End Function


    ''' <summary>
    ''' สถานที่เก็บ
    ''' </summary>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LOCATION_ADDRESS_KEEP_BY_LCNSID(ByVal LCNSID As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_KEEP_BY_LCNSID @LCNSID = " & LCNSID
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_KEEP_BY_LCNSID"
        Return dt
    End Function

End Class
