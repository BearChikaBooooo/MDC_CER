

Imports iTextSharp.text.Font

Public Class TEDA_WORD
    Public Property strBuilder As StringBuilder = New StringBuilder()


    Public Sub set_data_report(ByVal _IDA)
        'Dim _IDA As Integer = 375 'test
        'Dim _type As String = "100001" 'test
        Dim dt_report As New DataTable
        Dim dr_report As DataRow
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_byid(_IDA)
        Dim dao_coun As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
        dao_coun.Getdata_byfk_ida(_IDA)
        Dim dao_subtype As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
        dao_subtype.Getdata_byfk_ida(_IDA)
        Dim dao_prod As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
        dao_prod.Getdata_byfk_ida(_IDA)
        Dim count_prod As Integer = 0
        Dim dao_lcnno As New DAO_MDC_CER.TB_MDC_CER_LCNNO
        dao_lcnno.Getdata_by_fk_ida(_IDA)
        '-----------------------------------------
        dt_report.Columns.Add("cer_type")
        dt_report.Columns.Add("cer_no")
        dt_report.Columns.Add("for_type")
        dt_report.Columns.Add("lcnno_display_num")
        dt_report.Columns.Add("rcvdate")
        dt_report.Columns.Add("expapprove")
        dt_report.Columns.Add("country")
        dt_report.Columns.Add("country_no")
        dt_report.Columns.Add("producer")
        dt_report.Columns.Add("product")
        dt_report.Columns.Add("text1")
        dt_report.Columns.Add("text2")
        dt_report.Columns.Add("text3")
        dt_report.Columns.Add("text4")
        dt_report.Columns.Add("academic_staff")
        dt_report.Columns.Add("academic_position")
        dt_report.Columns.Add("position1")
        dt_report.Columns.Add("position2")
        dt_report.Columns.Add("position3")
        'dt_report.Columns.Add("edit_date")

        Dim column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "item"
        dt_report.Columns.Add(column)


        dt_report.Rows.Add()
        dr_report = dt_report.Rows(dt_report.Rows.Count - 1)
        dr_report("cer_type") = dao.fields.cer_type
        dr_report("cer_no") = dao.fields.cer_no
        dr_report("for_type") = dao.fields.for_type
        'For Each dao_lcnno.fields In dao_lcnno.datas
        ''    For i = 0 To dao.fields.export_amount
        'dr_report("lcnno_display_num") = dao.fields.lcnno_display_num
        '    Next
        'Next
        dr_report("rcvdate") = convert_date_tostr(dao.fields.rcvdate)
        dr_report("expapprove") = convert_date_tostr_d_m_y(dao.fields.expdate)
        dr_report("country") = dao.fields.country
        dr_report("country_no") = dao.fields.country_no
        dr_report("producer") = dao.fields.producer_name & ", " & dao.fields.producer_lct
        dr_report("academic_position") = dao.fields.ACADEMIC_POSITION_ID
        dr_report("academic_staff") = dao.fields.ACADEMIC_STAFF

        If dr_report("academic_position").Equals("1") Then
            dr_report("position1") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Pharmacist, Senior Professional Level"
            dr_report("position2") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "     Person designated by the Secretary-General"
            dr_report("position3") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "of the Food and Drug Administration"
        ElseIf dr_report("academic_position").Equals("2") Then
            dr_report("position1") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & " Director of Medical Device Control Division"
            dr_report("position2") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & "   For Secretary-General of Food and Drug Administration"
            dr_report("position3") = ""
        ElseIf dr_report("academic_position").Equals("3") Then
            dr_report("position1") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Pharmacist, Professional Level"
            dr_report("position2") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "     Person designated by the Secretary-General"
            dr_report("position3") = vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "of the Food and Drug Administration"

            dr_report("position3") = ""
        End If

        If dr_report("cer_no").Equals("1") Then
            dr_report("text1") = "It is hereby certified that " 'first paragraph
            dr_report("text2") = " does manufacture medical device in Thailand pursuant to the Medical Devices Act 2008."
            dr_report("text3") = "The following product may be sold in Thailand and exported without restriction." 'second paragraph
        ElseIf dr_report("cer_no").Equals("2") Then
            dr_report("text1") = "It is hereby certified that "
            dr_report("text2") = " does manufacture medical device in Thailand pursuant to the Medical Devices Act 2008."
            dr_report("text3") = "This following product which is manufactured in Thailand may be exported without restriction."

        ElseIf dr_report("cer_no").Equals("3") Then
            dr_report("text1") = "It is hereby certified that "
            dr_report("text2") = " does manufacture medical device in Thailand pursuant to the Medical Devices Act 2008."
            dr_report("text3") = "This following product which is manufactured in Thailand may be exported without restriction."
        ElseIf dr_report("cer_no").Equals("4") Then
            dr_report("text1") = "It is hereby certified that "
            dr_report("text2") = " does manufacture medical device in Thailand pursuant to the Medical Devices Act 2008."
            dr_report("text3") = "This following product which is manufactured in Thailand may be exported without restriction."
        End If



        For Each dao_prod.fields In dao_prod.datas
            count_prod += 1
        Next

        Dim dao_lcnno_no_cty As New DAO_MDC_CER.TB_MDC_CER_LCNNO
        dao_lcnno_no_cty.Getdata_by_fk_ida_type(_IDA, 1)
        If dr_report("country_no").Equals("1") Then
            For Each dao_lcnno_no_cty.fields In dao_lcnno_no_cty.datas
                dr_report("text4") = "This certificate is issued upon the request of " & dao.fields.producer_name & ", " & "Thailand."
                dr_report("lcnno_display_num") = dao_lcnno_no_cty.fields.lcnno_display_num
                'If count_prod > 3 Then
                '    dr_report("product") = "See Attached List"
                'Else
                '    For Each dao_prod.fields In dao_prod.datas
                '        dr_report("product") = dao_prod.fields.NO & " " & dao_prod.fields.Product_Name
                '    Next
                'End If
                Export_to_Word(dt_report, _IDA)
            Next
        End If


        Dim dao_lcnno_cty As New DAO_MDC_CER.TB_MDC_CER_LCNNO
        dao_lcnno_cty.Getdata_by_fk_ida_type(_IDA, 2)
        If dr_report("country").Equals("1") Then
            'For Each dao_coun.fields In dao_coun.datas
            For Each dao_lcnno_cty.fields In dao_lcnno_cty.datas
                'For i = 1 To dao_coun.fields.export_amount
                dr_report("text4") = "This certificate is only destined to the governmental authority of " & dao_lcnno_cty.fields.country_name & "."
                dr_report("lcnno_display_num") = dao_lcnno_cty.fields.lcnno_display_num

                'If count_prod > 3 Then
                '    dr_report("product") = "See Attached List"

                'Else
                '    For Each dao_prod.fields In dao_prod.datas
                '        dr_report("product") = dao_prod.fields.NO & " " & dao_prod.fields.Product_Name
                '    Next
                'End If

                Export_to_Word(dt_report, _IDA)
                'Next
            Next
            'Next

        End If

    End Sub

    Public Sub Export_to_Word(ByVal dt As DataTable, ByVal ida As String)
        Dim dao As New DAO_MDC_CER.TB_MDC_CER
        dao.Getdata_byid(ida)
        Dim dao_coun As New DAO_MDC_CER.TB_MDC_CER_COUNTRY
        dao_coun.Getdata_byfk_ida(ida)
        Dim dao_subtype As New DAO_MDC_CER.TB_MDC_CER_SUBTYPE
        dao_subtype.Getdata_byfk_ida(ida)
        Dim dao_prod As New DAO_MDC_CER.TB_MDC_CER_PRODUCT
        dao_prod.Getdata_byfk_ida(ida)
        Dim dao_lcnno As New DAO_MDC_CER.TB_MDC_CER_LCNNO
        dao_lcnno.Getdata_by_fk_ida(ida)
        Dim txt As String = ""
        Dim count As Integer = 0
        Dim count_sub As Integer = 0
        Dim count_sub2 As Integer = 0
        Dim owner As String = ""
        Dim distributor As String = ""
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbTab & vbTab & vbTab & vbTab & "   " & dt(i)("cer_type").ToString.ToUpper
                txt &= vbCrLf & vbCrLf & "Ref.No " & dt(i)("lcnno_display_num")
                txt &= vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & dt(i)("rcvdate")
                txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbTab & dt(i)("text1") & dt(i)("producer") & dt(i)("text2") 'first paragraph
                txt &= vbCrLf & vbCrLf & vbTab & dt(i)("text3") 'Second paragraph
                txt &= vbCrLf & vbCrLf & vbTab & "Name of Products" & vbCrLf
                For Each dao_prod.fields In dao_prod.datas
                    count += 1
                Next
                If count > 3 Then
                    txt &= vbCrLf & vbTab & "See Attached List (  Page)"
                Else
                    For Each dao_prod.fields In dao_prod.datas
                        txt &= vbCrLf & vbTab & dao_prod.fields.NO & " " & dao_prod.fields.Product_Name & " Detail: " & dao_prod.fields.Product_Detail 'product
                    Next
                End If
                'count = 0
                'txt &= vbCrLf & vbTab & "Name of Manufacturer"
                'txt &= vbCrLf & vbTab & dt(i)("producer")
                For Each dao_subtype.fields In dao_subtype.datas
                    If dao_subtype.fields.subtype_title.Equals("ผู้นำเข้า") Then
                        distributor &= vbCrLf & vbTab & dao_subtype.fields.subtype_name & ", " & dao_subtype.fields.subtype_location
                        count_sub += 1
                    ElseIf dao_subtype.fields.subtype_title.Equals("เจ้าของผลิตภัณฑ์") Then
                        owner &= vbCrLf & vbTab & dao_subtype.fields.subtype_name & ", " & dao_subtype.fields.subtype_location
                        count_sub2 += 1
                    End If

                Next
                If count_sub <> 0 Then
                    txt &= vbCrLf & vbTab & "Name of Distributor"
                    txt &= distributor

                End If
                If count_sub2 <> 0 Then
                    txt &= vbCrLf & vbTab & "Name of Product Owner"
                    txt &= owner
                End If

                txt &= vbCrLf & vbCrLf & vbTab & dt(i)("text4") 'Third paragraph
                txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
                txt &= vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Valid until " & dt(i)("expapprove")
                txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "   (" & dt(i)("academic_staff") & ")"
                txt &= dt(i)("position1")
                txt &= dt(i)("position2")
                txt &= dt(i)("position3")
                'txt &= vbCrLf & vbCrLf & vbCrLf
                'txt &= vbTab & vbTab & "Division of Medical Device Control, Food and Drug Administration"
                'txt &= vbCrLf & vbTab & vbTab & vbTab & "88/24 Tiwanon Road, Nonthaburi 11000, Thailand"
                'txt &= vbCrLf & vbTab & vbTab & vbTab & "      Tel. (662) 590-7148, Fax. (662) 591-8445"
                'txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf
                'For j As Integer = 0 To 

                'Next
                If count > 3 Then
                    txt &= vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Ref.No. " & dt(i)("lcnno_display_num")
                    txt &= vbCrLf & dt(i)("cer_type") & "-Attachment (Page  of )"
                    txt &= vbCrLf & vbCrLf & vbCrLf & vbTab & "Name of Products"
                    For Each dao_prod.fields In dao_prod.datas
                        txt &= vbCrLf & dao_prod.fields.NO & " " & dao_prod.fields.Product_Name & vbTab & dao_prod.fields.Product_Detail & ""
                    Next
                    txt &= vbCrLf & vbCrLf & vbCrLf & vbCrLf & "End of Product List"
                    txt &= vbCrLf & vbCrLf
                End If
            Next
        End If

        If txt <> "" Then
            strBuilder.Append(txt)

        End If
    End Sub



End Class
