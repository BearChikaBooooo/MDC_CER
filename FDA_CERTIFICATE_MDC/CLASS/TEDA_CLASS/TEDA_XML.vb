Imports System.IO
Imports System.Xml.Serialization

Module TEDA_XML
#Region "LIST_CLASS_XML"

    Private _XML_CER_MDCs As XML_CER_MDC
    Public Property XML_CER_MDCs() As XML_CER_MDC
        Get
            Return _XML_CER_MDCs
        End Get
        Set(ByVal value As XML_CER_MDC)
            _XML_CER_MDCs = value
        End Set
    End Property

#End Region


    Public Sub CREATE_XML_MDC_CER(ByRef PATH As String)
        Dim objStreamWriter As New StreamWriter(PATH)
        Dim x As New XmlSerializer(_XML_CER_MDCs.GetType)
        x.Serialize(objStreamWriter, _XML_CER_MDCs)
        objStreamWriter.Close()
    End Sub
End Module

