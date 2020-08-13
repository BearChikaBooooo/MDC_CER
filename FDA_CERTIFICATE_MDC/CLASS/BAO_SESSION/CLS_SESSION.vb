Public Class CLS_SESSION
    Private _IDA As Integer
    ''' <summary>
    ''' เก็บ ไอดีหลัก ของสถานที่ห้ามเก็บอย่างอื่น
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDA() As Integer
        Get
            Return _IDA
        End Get
        Set(ByVal value As Integer)
            _IDA = value
        End Set
    End Property

    Private _lct_ida As Integer
    Public Property lct_ida() As Integer
        Get
            Return _lct_ida
        End Get
        Set(ByVal value As Integer)
            _lct_ida = value
        End Set
    End Property

    Private _rqttpcd As Integer
    ''' <summary>
    ''' เก็บประเภทสถานที่ห้ามเก็บอย่างอื่น
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property rqttpcd() As Integer
        Get
            Return _rqttpcd
        End Get
        Set(ByVal value As Integer)
            _rqttpcd = value
        End Set
    End Property

    Private _rgtno As Integer
    Public Property rgtno() As Integer
        Get
            Return _rgtno
        End Get
        Set(ByVal value As Integer)
            _rgtno = value
        End Set
    End Property


    'Private _lcnsid As String

    ' ''' <summary>
    ' ''' เก็บ lcnsid ของ บริษัท
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Property lcnsid() As String
    '    Get
    '        Return _LCNSID
    '    End Get
    '    Set(ByVal value As String)
    '        _LCNSID = value
    '    End Set
    'End Property

    'Private _lcnsnm As String
    'Public Property lcnsnm() As String
    '    Get
    '        Return _lcnsnm
    '    End Get
    '    Set(ByVal value As String)
    '        _lcnsnm = value
    '    End Set
    'End Property

    Private _lcnno As String
    Public Property lcnno() As String
        Get
            Return _lcnno
        End Get
        Set(ByVal value As String)
            _lcnno = value
        End Set
    End Property

    Private _thanm As String
    Public Property thanm() As String
        Get
            Return _thanm
        End Get
        Set(ByVal value As String)
            _thanm = value
        End Set
    End Property

    'Private _lctnmcd As String
    'Public Property lctnmcd() As String
    '    Get
    '        Return _lctnmcd
    '    End Get
    '    Set(ByVal value As String)
    '        _lctnmcd = value
    '    End Set
    'End Property

    Private _CITIZEN_ID As String
    Public Property CITIZEN_ID() As String
        Get
            Return _CITIZEN_ID
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID = value
        End Set
    End Property

    Private _CITIZEN_ID_BSN As String
    Public Property CITIZEN_ID_BSN() As String
        Get
            Return _CITIZEN_ID_BSN
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID_BSN = value
        End Set
    End Property

    Private _STAFF_APM As Integer
    Public Property STAFF_APM() As Integer
        Get
            Return _STAFF_APM
        End Get
        Set(ByVal value As Integer)
            _STAFF_APM = value
        End Set
    End Property


    Private _TOKEN As String
    Public Property TOKEN() As String
        Get
            Return _TOKEN
        End Get
        Set(ByVal value As String)
            _TOKEN = value
        End Set
    End Property

    Private _Groups As String
    Public Property Groups() As String
        Get
            Return _Groups
        End Get
        Set(ByVal value As String)
            _Groups = value
        End Set
    End Property

    Private _System_ID As String
    Public Property System_ID() As String
        Get
            Return _System_ID
        End Get
        Set(ByVal value As String)
            _System_ID = value
        End Set
    End Property


    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Private _pvncd As String
    Public Property pvncd() As String
        Get
            Return _pvncd
        End Get
        Set(ByVal value As String)
            _pvncd = value
        End Set
    End Property

    'Private _TypeDoc As String
    'Public Property TypeDoc() As String
    '    Get
    '        Return _TypeDoc
    '    End Get
    '    Set(ByVal value As String)
    '        _TypeDoc = value
    '    End Set
    'End Property

    Private _feeno As String
    Public Property feeno() As String
        Get
            Return _feeno
        End Get
        Set(ByVal value As String)
            _feeno = value
        End Set
    End Property

    'Private _rcvno As String
    'Public Property rcvno() As String
    '    Get
    '        Return _rcvno
    '    End Get
    '    Set(ByVal value As String)
    '        _rcvno = value
    '    End Set
    'End Property

    Private _feetpcd As String
    Public Property feetpcd() As String
        Get
            Return _feetpcd
        End Get
        Set(ByVal value As String)
            _feetpcd = value
        End Set
    End Property

    Private _feeabbr As String
    Public Property feeabbr() As String
        Get
            Return _feeabbr
        End Get
        Set(ByVal value As String)
            _feeabbr = value
        End Set
    End Property

    'Private _dt_rcvno As DataTable
    'Public Property dt_rcvno() As DataTable
    '    Get
    '        Return _dt_rcvno
    '    End Get
    '    Set(ByVal value As DataTable)
    '        _dt_rcvno = value
    '    End Set
    'End Property

    'Private _CITIEZEN_ID_AUTHORIZE As String
    'Public Property CITIEZEN_ID_AUTHORIZE() As String
    '    Get
    '        Return _CITIEZEN_ID_AUTHORIZE
    '    End Get
    '    Set(ByVal value As String)
    '        _CITIEZEN_ID_AUTHORIZE = value
    '    End Set
    'End Property

    Private _LCNSID_CUSTOMER As String
    Public Property LCNSID_CUSTOMER() As String
        Get
            Return _LCNSID_CUSTOMER
        End Get
        Set(ByVal value As String)
            _LCNSID_CUSTOMER = value
        End Set
    End Property

    Private _THANM_CUSTOMER As String
    ''' <summary>
    ''' เก็บชื่อ บริษัท
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property THANM_CUSTOMER() As String
        Get
            Return _THANM_CUSTOMER
        End Get
        Set(ByVal value As String)
            _THANM_CUSTOMER = value
        End Set
    End Property


    Private _CITIZEN_ID_AUTHORIZE As String
    ''' <summary>
    ''' เก็บรหัสบัตรประชาชนหรือนิติบุคคล
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CITIZEN_ID_AUTHORIZE() As String
        Get
            Return _CITIZEN_ID_AUTHORIZE
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID_AUTHORIZE = value
        End Set
    End Property
    'Private _taxno As String
    'Public Property taxno() As String
    '    Get
    '        Return _taxno
    '    End Get
    '    Set(ByVal value As String)
    '        _taxno = value
    '    End Set
    'End Property

    Private _FullAddr As String
    ''' <summary>
    ''' เก็บที่อยู่ของบริษัท
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FullAddr() As String
        Get
            Return _FullAddr
        End Get
        Set(ByVal value As String)
            _FullAddr = value
        End Set
    End Property

    Private _PATH_PDF As String
    Public Property PATH_PDF() As String  'เอาไว้เก็บ Path ที่อยู่ของ File PDF
        Get
            Return _PATH_PDF
        End Get
        Set(ByVal value As String)
            _PATH_PDF = value
        End Set
    End Property

    Private _FILENAME_PDF As String
    Public Property FILENAME_PDF() As String
        Get
            Return _FILENAME_PDF
        End Get
        Set(ByVal value As String)
            _FILENAME_PDF = value
        End Set
    End Property

    Private _LCNSID As String
    Public Property LCNSID() As String
        Get
            Return _LCNSID
        End Get
        Set(ByVal value As String)
            _LCNSID = value
        End Set
    End Property

    Private _PVCODE As String
    Public Property PVCODE() As String
        Get
            Return _PVCODE
        End Get
        Set(ByVal value As String)
            _PVCODE = value
        End Set
    End Property

    Private _STAFF_TYPE As String
    Public Property STAFF_TYPE() As String
        Get
            Return _STAFF_TYPE
        End Get
        Set(ByVal value As String)
            _STAFF_TYPE = value
        End Set
    End Property

    Private _LCNTYPE_CD As String
    Public Property LCNTYPE_CD() As String
        Get
            Return _LCNTYPE_CD
        End Get
        Set(ByVal value As String)
            _LCNTYPE_CD = value
        End Set
    End Property


End Class
