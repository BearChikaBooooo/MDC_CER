Public Class XML_CFS_FOOD_CER

    Private _DATA_CER_FOOD As New CFS_FOOD_HEAD
    Public Property DATA_CER_FOOD() As CFS_FOOD_HEAD
        Get
            Return _DATA_CER_FOOD
        End Get
        Set(ByVal value As CFS_FOOD_HEAD)
            _DATA_CER_FOOD = value
        End Set
    End Property


    Private _DT_MAS As New XML_DT_MASTER
    Public Property DT_MAS() As XML_DT_MASTER
        Get
            Return _DT_MAS
        End Get
        Set(ByVal value As XML_DT_MASTER)
            _DT_MAS = value
        End Set
    End Property

    Private _DT_SHOW As New XML_DT_SHOW
    Public Property DT_SHOW() As XML_DT_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As XML_DT_SHOW)
            _DT_SHOW = value
        End Set
    End Property
    Private _FILE_ATTACH As New List(Of FILE_ATTACH)
    Public Property FILE_ATTACH() As List(Of FILE_ATTACH)
        Get
            Return _FILE_ATTACH
        End Get
        Set(ByVal value As List(Of FILE_ATTACH))
            _FILE_ATTACH = value
        End Set
    End Property

    Private _DAY As String
    Public Property DAY() As String
        Get
            Return _DAY
        End Get
        Set(ByVal value As String)
            _DAY = value
        End Set
    End Property
    Private _MONTH As String
    Public Property MONTH() As String
        Get
            Return _MONTH
        End Get
        Set(ByVal value As String)
            _MONTH = value
        End Set
    End Property
    Private _YEAR As String
    Public Property YEAR() As String
        Get
            Return _YEAR
        End Get
        Set(ByVal value As String)
            _YEAR = value
        End Set
    End Property
    Private _PROCESS As String
    Public Property PROCESS() As String
        Get
            Return _PROCESS
        End Get
        Set(ByVal value As String)
            _PROCESS = value
        End Set
    End Property
    Private _ADDR_REGIS_ENG As String
    Public Property ADDR_REGIS_ENG() As String
        Get
            Return _ADDR_REGIS_ENG
        End Get
        Set(ByVal value As String)
            _ADDR_REGIS_ENG = value
        End Set
    End Property

    Private _ADDR_REGIS_ENG_NAME As String
    Public Property ADDR_REGIS_ENG_NAME() As String
        Get
            Return _ADDR_REGIS_ENG_NAME
        End Get
        Set(ByVal value As String)
            _ADDR_REGIS_ENG_NAME = value
        End Set
    End Property

    Private _DATE_PERSENT As String
    Public Property DATE_PERSENT() As String
        Get
            Return _DATE_PERSENT
        End Get
        Set(ByVal value As String)
            _DATE_PERSENT = value
        End Set
    End Property

    Private _ADDR_IDA As String
    Public Property ADDR_IDA() As String
        Get
            Return _ADDR_IDA
        End Get
        Set(ByVal value As String)
            _ADDR_IDA = value
        End Set
    End Property
    Private _ADDR_REGIS_ENG_NO_NAME As String
    Public Property ADDR_REGIS_ENG_NO_NAME() As String
        Get
            Return _ADDR_REGIS_ENG_NO_NAME
        End Get
        Set(ByVal value As String)
            _ADDR_REGIS_ENG_NO_NAME = value
        End Set
    End Property
    Private _SUBSTANCE_CON_STRING As String
    Public Property SUBSTANCE_CON_STRING() As String
        Get
            Return _SUBSTANCE_CON_STRING
        End Get
        Set(ByVal value As String)
            _SUBSTANCE_CON_STRING = value
        End Set
    End Property
    Private _date_recvno As String
    Public Property date_recvno() As String
        Get
            Return _date_recvno
        End Get
        Set(ByVal value As String)
            _date_recvno = value
        End Set
    End Property

    Private _SUBSTANCE_UNIT_STRING As String
    Public Property SUBSTANCE_UNIT_STRING() As String
        Get
            Return _SUBSTANCE_UNIT_STRING
        End Get
        Set(ByVal value As String)
            _SUBSTANCE_UNIT_STRING = value
        End Set
    End Property

    Private _FML_UNIT As Integer
    Public Property FML_UNIT() As Integer
        Get
            Return _FML_UNIT
        End Get
        Set(ByVal value As Integer)
            _FML_UNIT = value
        End Set
    End Property
    Private _date_approve As String
    Public Property date_approve() As String
        Get
            Return _date_approve
        End Get
        Set(ByVal value As String)
            _date_approve = value
        End Set
    End Property

    Private _ADDR_REGIS_ENG_FOREIGN As String
    Public Property ADDR_REGIS_ENG_FOREIGN() As String
        Get
            Return _ADDR_REGIS_ENG_FOREIGN
        End Get
        Set(ByVal value As String)
            _ADDR_REGIS_ENG_FOREIGN = value
        End Set
    End Property

    Private _CFS_FOOD_COUNTRY As New List(Of CFS_FOOD_COUNTRY)
    Public Property CFS_FOOD_COUNTRY() As List(Of CFS_FOOD_COUNTRY)
        Get
            Return _CFS_FOOD_COUNTRY
        End Get
        Set(ByVal value As List(Of CFS_FOOD_COUNTRY))
            _CFS_FOOD_COUNTRY = value
        End Set
    End Property

    Private _CFS_FOOD_PRODUCT As New List(Of CFS_FOOD_PRODUCT)

    Public Property CFS_FOOD_PRODUCT() As List(Of CFS_FOOD_PRODUCT)
        Get
            Return _CFS_FOOD_PRODUCT
        End Get
        Set(ByVal value As List(Of CFS_FOOD_PRODUCT))
            _CFS_FOOD_PRODUCT = value
        End Set
    End Property

    Private _CFS_FOOD_PRODUCT_NO As New List(Of CFS_FOOD_PRODUCT)
    Public Property CFS_FOOD_PRODUCT_NO() As List(Of CFS_FOOD_PRODUCT)
        Get
            Return _CFS_FOOD_PRODUCT_NO
        End Get
        Set(ByVal value As List(Of CFS_FOOD_PRODUCT))
            _CFS_FOOD_PRODUCT_NO = value
        End Set
    End Property

    Private _DISTRINCE As String
    Public Property DISTRINCE() As String
        Get
            Return _DISTRINCE
        End Get
        Set(ByVal value As String)
            _DISTRINCE = value
        End Set
    End Property

    Private _PROVINCE As String
    Public Property PROVINCE() As String
        Get
            Return _PROVINCE
        End Get
        Set(ByVal value As String)
            _PROVINCE = value
        End Set
    End Property

    'jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj----
    Public Class CFS_FOOD_PRODUCT_LIST
        'Private _CFS_FOOD_PRODUCT As New CFS_FOOD_PRODUCT
        'Public Property CFS_FOOD_PRODUCT As CFS_FOOD_PRODUCT
        '    Get
        '        Return _CFS_FOOD_PRODUCT
        '    End Get
        '    Set(ByVal Value As CFS_FOOD_PRODUCT)
        '        _CFS_FOOD_PRODUCT = Value
        '    End Set

        'End Property
    
        Private _PRODUCT_MAIN_THA As String
        Public Property PRODUCT_MAIN_THA() As String
            Get
                Return _PRODUCT_MAIN_THA
            End Get
            Set(ByVal value As String)
                _PRODUCT_MAIN_THA = value
            End Set
        End Property
        Private _PRODUCT_MAIN_ENG As String
        Public Property PRODUCT_MAIN_ENG() As String
            Get
                Return _PRODUCT_MAIN_ENG
            End Get
            Set(ByVal value As String)
                _PRODUCT_MAIN_ENG = value
            End Set
        End Property
        Private _PRODUCT_THA As String
        Public Property PRODUCT_THA() As String
            Get
                Return _PRODUCT_THA
            End Get
            Set(ByVal value As String)
                _PRODUCT_THA = value
            End Set
        End Property
        Private _PRODUCT_ENG As String
        Public Property PRODUCT_ENG() As String
            Get
                Return _PRODUCT_ENG
            End Get
            Set(ByVal value As String)
                _PRODUCT_ENG = value
            End Set
        End Property
        Private _NEW_CODE As String
        Public Property NEW_CODE() As String
            Get
                Return _NEW_CODE
            End Get
            Set(ByVal value As String)
                _NEW_CODE = value
            End Set
        End Property
        Private _REGNOS As String
        Public Property REGNOS() As String
            Get
                Return _REGNOS
            End Get
            Set(ByVal value As String)
                _REGNOS = value
            End Set
        End Property
        Private _PRODUCT_SET_OUTPUT As String
        Public Property PRODUCT_SET_OUTPUT() As String
            Get
                Return _PRODUCT_SET_OUTPUT
            End Get
            Set(ByVal value As String)
                _PRODUCT_SET_OUTPUT = value
            End Set
        End Property
        Private _NAME_EXPORT As String
        Public Property NAME_EXPORT() As String
            Get
                Return _NAME_EXPORT
            End Get
            Set(ByVal value As String)
                _NAME_EXPORT = value
            End Set
        End Property

        Private _EXPORT_ONLY As Integer
        Public Property EXPORT_ONLY() As Integer
            Get
                Return _EXPORT_ONLY
            End Get
            Set(ByVal value As Integer)
                _EXPORT_ONLY = value
            End Set
        End Property

        Private _CFS_FOOD_FML_LIST As New List(Of CFS_FOOD_FML)
        Public Property CFS_FOOD_FML_LIST As List(Of CFS_FOOD_FML)
            Get
                Return _CFS_FOOD_FML_LIST
            End Get
            Set(ByVal Value As List(Of CFS_FOOD_FML))
                _CFS_FOOD_FML_LIST = Value
            End Set

        End Property
    End Class

    'Public Class CFS_FOOD_FML_LIST

    'End Class
    Private _LIST_CFS_FOOD_PRODUCT_LIST As New List(Of CFS_FOOD_PRODUCT_LIST)
    Public Property LIST_CFS_FOOD_PRODUCT_LIST() As List(Of CFS_FOOD_PRODUCT_LIST)
        Get
            Return _LIST_CFS_FOOD_PRODUCT_LIST
        End Get
        Set(ByVal value As List(Of CFS_FOOD_PRODUCT_LIST))
            _LIST_CFS_FOOD_PRODUCT_LIST = value
        End Set
    End Property

    Private _LIST_CFS_FOOD_PRODUCT_LIST_NO As New List(Of CFS_FOOD_PRODUCT_LIST)
    Public Property LIST_CFS_FOOD_PRODUCT_LIST_NO() As List(Of CFS_FOOD_PRODUCT_LIST)
        Get
            Return _LIST_CFS_FOOD_PRODUCT_LIST_NO
        End Get
        Set(ByVal value As List(Of CFS_FOOD_PRODUCT_LIST))
            _LIST_CFS_FOOD_PRODUCT_LIST_NO = value
        End Set
    End Property


End Class

