Public Class cls_holiday
    ''' <summary>
    ''' FUNCTION สำหรับตรวจสอบว่าเป็นวันหยุดหรือป่าว
    ''' </summary>
    ''' <param name="C_DATE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CHK_HOLDATE(ByVal C_DATE As Date)
        Dim ALLOW_UPLOAD As Boolean = True


        Dim chk_minus_date As Date = DateAdd(DateInterval.Day, -1, CDate(C_DATE.ToShortDateString()))  'ถอยหลังเป็น 1 วันเพื่อตรวจสอบเมื่อวานเป็นวันหยุดหรือไม่
        Dim chk_plus_date As Date = DateAdd(DateInterval.Day, +1, CDate(C_DATE.ToShortDateString()))  'ถอยหลังเป็น 1 วันเพื่อตรวจสอบเมื่อวานเป็นวันหยุดหรือไม่
        Dim hours As Integer = DatePart(DateInterval.Hour, C_DATE)
        Dim minutes As Integer = DatePart(DateInterval.Minute, C_DATE)
        'ขั้นตอนที่ 1 ตรวจสอบว่าเป็นวันหยุดหรือไม่
        If GET_HOLDATE(C_DATE) = True Then 'กรณีเป็น TRUE คือเป็นวันหยุดจบการทำงาน
            ALLOW_UPLOAD = False
        Else 'กรณีเป็น False
            If GET_HOLDATE(chk_minus_date) = True Then
                If hours = 8 Then
                    If minutes > 30 Then
                        ALLOW_UPLOAD = True
                    Else
                        ALLOW_UPLOAD = False
                    End If
                ElseIf hours > 8 Then
                    If GET_HOLDATE(chk_plus_date) = True Then 'กรณีเป็นวันหยุด
                        If hours = 16 Then 'กรณีเป็น 4 โมงเย็น
                            If minutes > 30 Then 'กรณีมากกว่า 4 โมง 30 นาที
                                ALLOW_UPLOAD = False
                            Else
                                ALLOW_UPLOAD = True
                            End If
                        ElseIf hours > 16 Then 'กรณีมากกว่า 4 โมงเย็น
                            ALLOW_UPLOAD = False
                        Else
                            ALLOW_UPLOAD = True
                        End If
                    Else
                        ALLOW_UPLOAD = True
                    End If
                ElseIf hours < 8 Then
                    ALLOW_UPLOAD = False
                    'จบการทำงาน
                End If

            Else 'กรณีเมื่อวานไม่ใช่วันหยุด
                If GET_HOLDATE(chk_plus_date) = True Then 'กรณีเป็นวันหยุด
                    If hours = 16 Then 'กรณีเป็น 4 โมงเย็น
                        If minutes > 30 Then 'กรณีมากกว่า 4 โมง 30 นาที
                            ALLOW_UPLOAD = False
                        Else
                            ALLOW_UPLOAD = True
                        End If
                    ElseIf hours > 16 Then 'กรณีมากกว่า 4 โมงเย็น
                        ALLOW_UPLOAD = False
                    Else
                        ALLOW_UPLOAD = True
                    End If
                Else
                    ALLOW_UPLOAD = True
                End If
            End If
        End If

        'ALLOW_UPLOAD = True

        Return ALLOW_UPLOAD
    End Function

    ''' <summary>
    ''' ตรวจสอบวันหยุด
    ''' </summary>
    ''' <param name="C_DATE"></param>
    ''' <returns>กรณี กลับมาเป็น TRUE หมายถึงเป็นวันหยุด ถ้า False คือไม่ใช่วันหยุด</returns>
    ''' <remarks></remarks>
    Private Function GET_HOLDATE(ByVal C_DATE As Date) As Boolean
        C_DATE = CDate(C_DATE.ToShortDateString()) 'เอาเวลาออก
        Dim chk_hol As Boolean = False
        Dim dao_hol As New DAO_CPN.tb_workday
        dao_hol.GetDataby_holiday(C_DATE)
        If dao_hol.fields.IDA > 0 Then
            chk_hol = True
        End If
        Return chk_hol
    End Function
End Class
