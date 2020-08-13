Namespace BAO_STOREPROCUDURE
    Public MustInherit Class SP_CENTER
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
                    dr(c.ColumnName) = ""
                ElseIf c.DataType.Name.ToString() = "Int32" Then
                    dr(c.ColumnName) = 0
                ElseIf c.DataType.Name.ToString() = "DateTime" Then
                    'dr(c.ColumnName) = Nothing 'Date.Now
                    dr(c.ColumnName) = DBNull.Value 'Date.Now
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
    End Class



    Public Class CER
        Inherits SP_CENTER
        Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_MDC_DEMOConnectionString").ConnectionString

        Public Function SP_SearchProduct(ByVal productname As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_SearchProduct @Productname ='" & productname & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            dt.TableName = "SP_SearchProduct"

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)

            End If
            Return dt
        End Function
    End Class

    Public Class CPN
        Inherits SP_CENTER

        Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString
        Private _conn_xml As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DUMP_DATAConnectionString").ConnectionString
        Public conn2 As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString



        Public Function SP_SYSISOCNT()
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
        ''' ดึงข้อมูลจากเลขบัตรประชาชน
        ''' </summary>
        ''' <param name="CTZNO"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_MAINPERSON_CTZNO_SEARCH(ByVal CTZNO As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAINPERSON_CTZNO @ctzno = '" & CTZNO & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, conn).Tables(0)
                dt.TableName = "SP_MAINPERSON_CTZNO"
            Catch ex As Exception

            End Try
            Return dt
        End Function



        Public Function SP_MAINCOMPANY_LCNSID(ByVal lcnsid As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAINCOMPANY_LCNSID @lcnsid = " & lcnsid & ",@lctcd=1"
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

        'Public Function SP_MAINCOMPANY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_MAINCOMPANY_FOOD @FK_IDA = " & FK_IDA
        '    Dim dt As New DataTable
        '    Try
        '        dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        '        dt.TableName = "SP_MAINCOMPANY"
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


    End Class

    'Public Class CFS
    '    Inherits SP_CENTER

    '    Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_CFS_CENTERConnectionString").ConnectionString



    '    Public Function SP_LIST_CER_FOOD_ALL_LCNSID(ByVal process_id As String, ByVal lcnsid As Integer, ByVal ida As Integer, ByVal idetify As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_LIST_CER_FOOD_ALL_LCNSID @FK_PROCESS_ID=" & process_id & ",@LCNSID =" & lcnsid & ",@FK_IDA=" & ida & ",@CITIZEN_ID ='" & idetify & "'"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_LIST_CER_FOOD_ALL_LCNSID"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_MAS_PROVINCES()
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_MAS_PROVINCES"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_MAS_PROVINCES"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_FOOD_STAFF_REMARK_VERSION(ByVal IDA As Integer)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_FOOD_STAFF_REMARK_VERSION @IDA=" & IDA
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_FOOD_STAFF_REMARK_VERSION"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_CFS_FOOD_HEAD_OUTPUT(ByVal ida As Integer)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_CFS_FOOD_HEAD_OUTPUT @IDA=" & ida
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_CFS_HEAD_OUTPUT"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_MAS_DISTRICT()
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_MAS_DISTRICT"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_MAS_DISTRICT"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_FOOD_ALL_RCV(ByVal process_id As String, ByVal citizen_id As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_FOOD_ALL_RCV @process_id='" & process_id & "',@citizen_id='" & citizen_id & "'"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_FOOD_ALL_RCV"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_FOOD_ALL_RCV_MASTER(ByVal process_id As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_FOOD_ALL_RCV_MASTER @process_id='" & process_id & "'"

    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_FOOD_ALL_RCV_MASTER"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_CER_FOOD_APPROVED_PROCESS(ByVal process_id As String, ByVal citizen_id As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_CER_FOOD_APPROVED_PROCESS @process='" & process_id & "',@citizen_id='" & citizen_id & "'"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(Sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_CER_FOOD_APPROVED_PROCESS"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_CER_FOOD_APPROVED_PROCESS_MASTER(ByVal process_id As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_CER_FOOD_APPROVED_PROCESS_MASTER @process='" & process_id & "'"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_CER_FOOD_APPROVED_PROCESS_MASTER"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_CER_FOOD_APPROVED(ByVal rcvno As String, ByVal ref_code As String)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_CER_FOOD_APPROVED @rcvno ='" & rcvno & "',@ref_code = '" & ref_code & "'"
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_CER_FOOD_APPROVED"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_FOOD_PRODUCT(ByVal ida As Integer)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_FOOD_PRODUCT @FK_IDA_CER_NO =" & ida
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_FOOD_PRODUCT"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function

    '    Public Function SP_GET_CER_FOOD_COUNTRY(ByVal ida As Integer)
    '        Dim clsds As New ClassDataset
    '        Dim sql As String = "exec SP_GET_CER_FOOD_COUNTRY @IDA =" & ida
    '        Dim dt As New DataTable
    '        dt = clsds.dsQueryselect(sql, conn).Tables(0)
    '        dt.TableName = "SP_GET_CER_FOOD_COUNTRY"
    '        'If dt.Rows.Count() = 0 Then
    '        '    dt = AddDatatable(dt)
    '        'End If
    '        Return dt
    '    End Function
    'End Class

    Public Class FOOD
        Inherits SP_CENTER
        Public conn2 As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString

        'Public Function SP_GET_PRODUCT_FOR_CER(ByVal lcnsid As Integer, ByVal lcnno As String)
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_GET_PRODUCT_FOR_CER @lcnsid=" & lcnsid & ",@lcnno ='" & lcnno & "'"
        '    Dim dt As New DataTable
        '    dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        '    dt.TableName = "SP_GET_PRODUCT_FOR_CER"
        '    If dt.Rows.Count() = 0 Then
        '        dt = AddDatatable(dt)
        '    End If
        '    Return dt
        'End Function 

        Public Function SP_GET_CER_FOOD_FDTYPECD_BY_LCNNO(ByVal ida As Integer, ByVal lcnno As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_CER_FOOD_FDTYPECD_BY_LCNNO @ida=" & ida & ",@lcnno ='" & lcnno & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, conn2).Tables(0)
            dt.TableName = "SP_GET_CER_FOOD_FDTYPECD_BY_LCNNO"
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
            Return dt
        End Function

        'Public Function SP_LIST_CER_FOOD_ALL_LCNSID(ByVal process_id As String, ByVal lcnsid As Integer, ByVal ida As Integer, ByVal idetify As String)
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_LIST_CER_FOOD_ALL_LCNSID @FK_PROCESS_ID=" & process_id & ",@LCNSID =" & lcnsid & ",@FK_IDA=" & ida & ",@CITIZEN_ID ='" & idetify & "'"
        '    Dim dt As New DataTable
        '    dt = clsds.dsQueryselect(sql, conn2).Tables(0)
        '    dt.TableName = "SP_LIST_CER_FOOD_ALL_LCNSID"
        '    'If dt.Rows.Count() = 0 Then
        '    '    dt = AddDatatable(dt)
        '    'End If
        '    Return dt
        'End Function

        ''' <summary>
        ''' ดึงข้อมูล SP_MASTER_CON_LCNNO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_MASTER_CON_LCNNO(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MASTER_CON_LCNNO @ID=" & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, conn2).Tables(0)
                dt.TableName = "SP_MASTER_CON_LCNNO"
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            'If dt.Rows.Count() = 0 Then
            '    dt = AddDatatable(dt)
            'End If
            Return dt
        End Function
    End Class


    Public Class FOOD_XML
        Inherits SP_CENTER
        Public conn2 As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DUMP_DATAConnectionString").ConnectionString

        Public Function SP_GET_PRODUCT_FOR_CER(ByVal lcnsid As Integer, ByVal lcnno As String)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_PRODUCT_FOR_CER @lcnsid=" & lcnsid & ",@lcnno ='" & lcnno & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, conn2).Tables(0)
            dt.TableName = "SP_GET_PRODUCT_FOR_CER"

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)

            End If
            Return dt
        End Function
    End Class


End Namespace


