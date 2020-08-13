Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml

Module BAO_COMMON

    Public _PATH_XML_UPLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_UPLOAD")
    Public _PATH_PDF_UPLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_UPLOAD")
    Public _PATH_XML_DOWNLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_DOWNLOAD")
    Public _PATH_PDF_DOWNLOAD As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_DOWNLOAD")
    Public _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_FILE")
    Public _PATH_XML_BASE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_BASE")


    ''' <summary>
    ''' ดึงสกุลไฟล์แนบ
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetExtension(ByVal filename As String) As String
        Dim extension As String() = filename.Split(".")
        Dim extension_name As String = extension(extension.Length - 1)
        Return extension_name
    End Function

    ''' <summary>
    ''' ใช้สำหรับสร้างชื่อ TRANCESTION
    ''' </summary>
    ''' <param name="SYS"></param>
    ''' <param name="PROSESS_ID"></param>
    ''' <param name="YEAR"></param>
    ''' <param name="ID_TRANSECTION_UPLOAD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NAME_TRANCESTION(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
    '    Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD
    '    Return filename
    'End Function


    'Public Function NAME_XML(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
    '    Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".xml"

    '    Return filename
    'End Function
    Public Function NAME_TRANCESTION(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD
        Return filename
    End Function


    Public Function NAME_XML(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal TYPE As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & TYPE & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".xml"

        Return filename
    End Function

    ''' <summary>
    ''' ใช้สำหรับการสร้างชื่อ File PDF
    ''' </summary>
    ''' <param name="SYS"></param>
    ''' <param name="PROSESS_ID"></param>
    ''' <param name="YEAR"></param>
    ''' <param name="ID_TRANSECTION_UPLOAD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NAME_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
    '    Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
    '    Return filename
    'End Function

    '''' <summary>
    '''' ใช้สำหรับการสร้างชื่อ File PDF
    '''' </summary>
    '''' <param name="SYS"></param>
    '''' <param name="PROSESS_ID"></param>
    '''' <param name="YEAR"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    Public Function NAME_PDF_DOWNLOAD(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal TYPE As String, ByVal YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & TYPE & "-" & YEAR & "-" & DOWNLOAD_ID & ".pdf"
        Return filename
    End Function


    Public Function NAME_XML_DOWNLOAD(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal TYPE As String, YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & TYPE & "-" & YEAR & "-" & DOWNLOAD_ID & ".xml"

        Return filename
    End Function

    Public Function NAME_PDF_DOWNLOAD2(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal group As String, ByVal YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & group & "-" & YEAR & "-" & DOWNLOAD_ID & ".pdf"
        Return filename
    End Function


    Public Function NAME_XML_DOWNLOAD2(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal group As String, ByVal YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & group & "-" & YEAR & "-" & DOWNLOAD_ID & ".xml"

        Return filename
    End Function

    Public Function NAME_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal TYPE As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & TYPE & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
        Return filename
    End Function
    Public Function NAME_PDFSTEMP(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal TYPE As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & TYPE & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
        Return filename
    End Function
    Public Function NAME_XML2(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal group As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & group & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".xml"

        Return filename
    End Function

    Public Function NAME_PDF2(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal group As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & group & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
        Return filename
    End Function

    Public Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, "", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then

                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    Try
                        props.SetValue(ob, 0, Nothing)
                    Catch ex As Exception
                        props.SetValue(ob, Nothing, Nothing)
                    End Try


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Public Function AddValue2(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, "", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then

                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else

                    props.SetValue(ob, Nothing, Nothing)


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function
    Function AddValue_Datatable(ByVal dt As DataTable) As DataTable
        Dim dr As DataRow = dt.NewRow
        For Each c As DataColumn In dt.Columns
            If c.DataType.ToString() = "System.String" Then
                dr(c.ColumnName) = "-"
            Else

            End If

        Next

        dt.Rows.Add(dr)
        Return dt
    End Function


    'สร้าง Format สถานที่ ระบบอาหาร
    Public Function Format_fdpdtno_lcnno(ByVal pvncd As String, ByVal pvtype As String, ByVal lcntype As String, ByVal lcnno As String) As String
        Dim fdpdtno As String = ""
        Try

            Dim type As String = String.Empty

            Dim lcnno_year As String = ""
            Dim lcnno_number As String = ""

            lcnno_year = lcnno.ToString().Trim().Substring(0, 2)
            lcnno_number = lcnno.ToString().Trim().Substring(4, 3)
            If pvtype = "10" Then
                If lcntype = "11" Then
                    type = "1"
                ElseIf lcntype = "12" Then
                    type = "3"
                End If
            Else
                If lcntype = "11" Then
                    type = "2"
                ElseIf lcntype = "12" Then
                    type = "4"
                End If
            End If
            fdpdtno = pvncd & "-" & type & "-" & lcnno_number & lcnno_year
        Catch ex As Exception

        End Try


        Return fdpdtno
    End Function

    'Class CITIZEN
    '    ''' <summary>
    '    ''' แปลง CITIZEN_ID และ CITIZEN_AUTHORIZE เป็น lcnsid
    '    ''' </summary>
    '    ''' <param name="CITIZEN_ID"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function get_lcnsid(ByVal CITIZEN_ID As String) As String
    '        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
    '        dao_syslcnsid.GetDataby_identify(CITIZEN_ID)
    '        Return dao_syslcnsid.fields.lcnsid
    '    End Function
    '    ''' <summary>
    '    ''' แปลง lcnsid ของ CITIZEN_ID เป็น ชื่อผู้ประกอบการ
    '    ''' </summary>
    '    ''' <param name="lcnsid"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function get_name(ByVal lcnsid As String) As String
    '        Dim name As String
    '        Dim prefix As String = ""
    '        Dim suffix As String = ""
    '        'Dim dao_sysnmperson As New DAO.TB_sysnmperson
    '        Dim dao_syslcnid As New DAO_CPN.clsDBsyslcnsid
    '        Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
    '        Dim dao_prefix As New DAO_CPN.tb_lcnprefix
    '        Dim dao_suffix As New DAO_CPN.tb_lcnsuffix

    '        dao_syslcnid.GetDataby_lcnsid(lcnsid)
    '        dao_sysnmperson.GetDataby_identify(dao_syslcnid.fields.identify)
    '        Try
    '            dao_prefix.GetDataby_prefixcd(dao_sysnmperson.fields.prefixcd)
    '            prefix = dao_prefix.fields.thanm
    '        Catch ex As Exception

    '        End Try

    '        Try
    '            dao_suffix.GetDataby_suffixcd(dao_sysnmperson.fields.suffixcd)
    '            suffix = dao_suffix.fields.thanm
    '        Catch ex As Exception

    '        End Try

    '        If String.IsNullOrEmpty(dao_sysnmperson.fields.thalnm) = True Or dao_sysnmperson.fields.thalnm = Nothing Then
    '            name = prefix & " " & dao_sysnmperson.fields.thanm & " " & suffix
    '        Else
    '            name = prefix & " " & dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm & " " & suffix
    '        End If
    '        Return name
    '    End Function
    'End Class

    Function con_year() As String
        Dim int_year As Integer = Integer.Parse(Date.Now.Year)
        If int_year <= 2500 Then
            int_year += 543
        End If
        Return int_year.ToString()
    End Function

    Function CONVERT_THAI_YEAR(ByVal YEAR As Integer) As String

        If YEAR <= 2500 Then
            YEAR += 543
        End If
        Return YEAR.ToString()
    End Function

    Function CONVERT_ENG_YEAR(ByVal YEAR As Integer) As Integer

        If YEAR >= 2500 Then
            YEAR -= 543
        End If
        Return YEAR
    End Function

    Function Convert_Year(ByVal date1 As Date) As Date
        Dim int_year As Integer = Integer.Parse(date1)
        If int_year <= 2500 Then
            int_year += 543
        End If
        Return DateTime.Parse(int_year)
    End Function


    Function convert_date_tostr(ByVal str As String)
        Dim date1 = Convert.ToDateTime(str)
        Dim day = date1.Day
        Dim month = date1.Month
        Dim year = date1.Year
        Dim m
        If month = 1 Then
            m = "January"
        ElseIf month = 2 Then
            m = "Febuary"
        ElseIf month = 3 Then
            m = "March"
        ElseIf month = 4 Then
            m = "April"
        ElseIf month = 5 Then
            m = "May"
        ElseIf month = 6 Then
            m = "June"
        ElseIf month = 7 Then
            m = "July"
        ElseIf month = 8 Then
            m = "August"
        ElseIf month = 9 Then
            m = "September"
        ElseIf month = 10 Then
            m = "October"
        ElseIf month = 11 Then
            m = "November"
        ElseIf month = 12 Then
            m = "December"
        End If

        Return m & " " & day & ", " & year

    End Function

    Function convert_date_tostr_d_m_y(ByVal str As String)
        Dim date1 = CDate(str)
        Dim day = date1.Day
        Dim month = date1.Month
        Dim year = date1.Year
        Dim m
        If month = 1 Then
            m = "January"
        ElseIf month = 2 Then
            m = "Febuary"
        ElseIf month = 3 Then
            m = "March"
        ElseIf month = 4 Then
            m = "April"
        ElseIf month = 5 Then
            m = "May"
        ElseIf month = 6 Then
            m = "June"
        ElseIf month = 7 Then
            m = "July"
        ElseIf month = 8 Then
            m = "August"
        ElseIf month = 9 Then
            m = "September"
        ElseIf month = 10 Then
            m = "October"
        ElseIf month = 11 Then
            m = "November"
        ElseIf month = 12 Then
            m = "December"
        End If

        Return day & " " & m & ", " & year

    End Function

    Function convert_month(ByVal month As Integer)

        Dim m As String
        If month = 1 Then
            m = "January"
        ElseIf month = 2 Then
            m = "Febuary"
        ElseIf month = 3 Then
            m = "March"
        ElseIf month = 4 Then
            m = "April"
        ElseIf month = 5 Then
            m = "May"
        ElseIf month = 6 Then
            m = "June"
        ElseIf month = 7 Then
            m = "July"
        ElseIf month = 8 Then
            m = "August"
        ElseIf month = 9 Then
            m = "September"
        ElseIf month = 10 Then
            m = "October"
        ElseIf month = 11 Then
            m = "November"
        ElseIf month = 12 Then
            m = "December"
        End If

        Return m.ToString

    End Function

    Function convert_month_thai(ByVal month As Integer)

        Dim m As String
        If month = 1 Then
            m = "มกราคม"
        ElseIf month = 2 Then
            m = "กุมภาพันธ์"
        ElseIf month = 3 Then
            m = "มีนาคม"
        ElseIf month = 4 Then
            m = "เมษายน"
        ElseIf month = 5 Then
            m = "พฤษภาคม"
        ElseIf month = 6 Then
            m = "มิถุนายน"
        ElseIf month = 7 Then
            m = "กรกฏาคม"
        ElseIf month = 8 Then
            m = "สิงหาคม"
        ElseIf month = 9 Then
            m = "กันยายน"
        ElseIf month = 10 Then
            m = "ตุลาคม"
        ElseIf month = 11 Then
            m = "พฤศจิกายน"
        ElseIf month = 12 Then
            m = "ธันวาคม"
        End If

        Return m.ToString

    End Function

    Public Sub history_log(ByVal PROCESS_ID As Integer, ByVal STATUS_ID As Integer,
                           ByVal CITIZEN_MODIFY As String, ByVal NAME_MODIFY As String, ByVal IDA As Integer)
        Dim dao As New DAO_MDC_CER.TB_MDC_HISTORY_LOG
        dao.fields.PROCESS_ID = PROCESS_ID
        dao.fields.STATUS_ID = STATUS_ID
        dao.fields.CITIZEN_MODIFY = CITIZEN_MODIFY
        dao.fields.NAME_MODIFY = NAME_MODIFY
        dao.fields.FK_IDA = IDA
        dao.fields.DATE_MODIFY = Date.Now
        dao.insert()
    End Sub

End Module

