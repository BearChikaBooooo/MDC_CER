Public Class XML_CER_MDC
    Inherits Class_Center
#Region "DB"
    Private _DT_CER_MDCs As New MDC_CER
    Public Property DT_CER_MDCs() As MDC_CER
        Get
            Return _DT_CER_MDCs
        End Get
        Set(ByVal value As MDC_CER)
            _DT_CER_MDCs = value
        End Set
    End Property

    Private _DT_CER_MDC_COUNTRies As New List(Of MDC_CER_COUNTRY)
    Public Property DT_CER_MDC_COUNTRies() As List(Of MDC_CER_COUNTRY)
        Get
            Return _DT_CER_MDC_COUNTRies
        End Get
        Set(ByVal value As List(Of MDC_CER_COUNTRY))
            _DT_CER_MDC_COUNTRies = value
        End Set
    End Property
    Private _DT_CER_MDC_LCNNOs As New List(Of MDC_CER_LCNNO)
    Public Property DT_CER_MDC_LCNNOs() As List(Of MDC_CER_LCNNO)
        Get
            Return _DT_CER_MDC_LCNNOs
        End Get
        Set(ByVal value As List(Of MDC_CER_LCNNO))
            _DT_CER_MDC_LCNNOs = value
        End Set
    End Property

    Private _DT_CER_MDC_SUBTYPEs As New List(Of MDC_CER_SUBTYPE)
    Public Property DT_CER_MDC_SUBTYPEs() As List(Of MDC_CER_SUBTYPE)
        Get
            Return _DT_CER_MDC_SUBTYPEs
        End Get
        Set(ByVal value As List(Of MDC_CER_SUBTYPE))
            _DT_CER_MDC_SUBTYPEs = value
        End Set
    End Property

    Private _DT_CER_MDC_PRODUCTs As New List(Of MDC_CER_PRODUCT)
    Public Property DT_CER_MDC_PRODUCTs() As List(Of MDC_CER_PRODUCT)
        Get
            Return _DT_CER_MDC_PRODUCTs
        End Get
        Set(ByVal value As List(Of MDC_CER_PRODUCT))
            _DT_CER_MDC_PRODUCTs = value
        End Set
    End Property

    'Private _DT_COUNTRY As New sysisocnt
    'Public Property DT_COUNTRY() As sysisocnt
    '    Get
    '        Return _DT_COUNTRY
    '    End Get
    '    Set(ByVal value As sysisocnt)
    '        _DT_COUNTRY = value
    '    End Set
    'End Property
#End Region

    Private _DT_MASTER As New XML_DT_MASTER
    Public Property DT_MASTER() As XML_DT_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As XML_DT_MASTER)
            _DT_MASTER = value
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

    Private _DT_IRGTs As New irgt
    Public Property DT_IRGTs() As irgt
        Get
            Return _DT_IRGTs
        End Get
        Set(ByVal value As irgt)
            _DT_IRGTs = value
        End Set
    End Property

    Private _product_name As String
    Public Property product_name() As String
        Get
            Return _product_name
        End Get
        Set(ByVal value As String)
            _product_name = value
        End Set
    End Property

    Private _product_detail As String
    Public Property product_detail() As String
        Get
            Return _product_detail
        End Get
        Set(ByVal value As String)
            _product_detail = value
        End Set
    End Property

End Class
