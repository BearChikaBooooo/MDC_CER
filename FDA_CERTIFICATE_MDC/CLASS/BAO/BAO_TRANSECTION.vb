Imports FDA_CERTIFICATE_MDC.DAO
Namespace BAO_TRANSCETION

    ''' <summary>
    ''' ใช้สำหรับ บันทึกเลข TRANSECTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TRANSECTION_UPLOAD

        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _CITIZEN_ID_AUTHORIZE As String
        Public Property CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property



        Public Function insert_transection(ByVal process_id As Integer) As Integer

            Dim dao_up As New DAO_MDC_CER.TB_TRANSACTION_UPLOAD
            dao_up.fields.CITIEZEN_ID = _CITIZEN_ID
            dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CITIZEN_ID_AUTHORIZE
            dao_up.fields.PROCESS_ID = process_id
            dao_up.fields.STATUS = 1
            dao_up.fields.UPLOAD_DATE = Date.Now()
            dao_up.fields.YEAR = con_year()
            dao_up.insert() 'ปรับเป็น update
            Return dao_up.fields.ID

        End Function
    End Class


    ''' <summary>
    ''' ใช้สำหรับ บันทึกเลข DOWNLOAD_TRANSECTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TRANSECTION_DOWNLOAD

        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _CITIZEN_ID_AUTHORIZE As String
        Public Property CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property



        'Public Function insert_transection(ByVal processid As Integer) As Integer

        '    Dim dao_down As New DAO_CPN.TB_TRANSECTION_DOWNLOAD
        '    dao_down.fields.PROCESS_ID = processid
        '    dao_down.fields.CITIEZEN_ID = _CITIZEN_ID
        '    dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CITIZEN_ID_AUTHORIZE
        '    dao_down.fields.STATUS = 0
        '    dao_down.fields.DOWNLOAD_DATE = Date.Now()
        '    dao_down.insert()

        '    Return dao_down.fields.ID
        'End Function
    End Class

End Namespace