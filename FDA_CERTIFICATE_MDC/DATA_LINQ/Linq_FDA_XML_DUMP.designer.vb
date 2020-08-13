﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_XML")>  _
Partial Public Class Linq_FDA_XML_DUMPDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertXML_FOOD(instance As XML_FOOD)
    End Sub
  Partial Private Sub UpdateXML_FOOD(instance As XML_FOOD)
    End Sub
  Partial Private Sub DeleteXML_FOOD(instance As XML_FOOD)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DUMP_DATAConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property XML_FOODs() As System.Data.Linq.Table(Of XML_FOOD)
		Get
			Return Me.GetTable(Of XML_FOOD)
		End Get
	End Property
	
	Public ReadOnly Property food_exports() As System.Data.Linq.Table(Of food_export)
		Get
			Return Me.GetTable(Of food_export)
		End Get
	End Property
	
	Public ReadOnly Property food_export_checks() As System.Data.Linq.Table(Of food_export_check)
		Get
			Return Me.GetTable(Of food_export_check)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.XML_FOOD")>  _
Partial Public Class XML_FOOD
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDA As Integer
	
	Private _pvncd As System.Nullable(Of Short)
	
	Private _lcnno As System.Nullable(Of Integer)
	
	Private _lcnsid As System.Nullable(Of Integer)
	
	Private _fdpdtno As String
	
	Private _lcntypecd As System.Nullable(Of Integer)
	
	Private _prdnmt As String
	
	Private _prdnme As String
	
	Private _Producer_Name As String
	
	Private _groupname As String
	
	Private _NewCode As String
	
	Private _Ranking As String
	
	Private _cntcd As String
	
	Private _appdate As System.Nullable(Of Date)
	
	Private _expdate As System.Nullable(Of Date)
	
	Private _CreateDate As System.Nullable(Of Date)
	
	Private _UpdateDate As System.Nullable(Of Date)
	
	Private _rid As System.Nullable(Of Integer)
	
	Private _Cer_expdate As System.Nullable(Of Date)
	
	Private _Brand As String
	
	Private _thanm As String
	
	Private _Status As System.Nullable(Of Integer)
	
	Private _Addr As String
	
	Private _fdtypecd As System.Nullable(Of Integer)
	
	Private _fdtypenm As String
	
	Private _thanmowner As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDAChanged()
    End Sub
    Partial Private Sub OnpvncdChanging(value As System.Nullable(Of Short))
    End Sub
    Partial Private Sub OnpvncdChanged()
    End Sub
    Partial Private Sub OnlcnnoChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnlcnnoChanged()
    End Sub
    Partial Private Sub OnlcnsidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnlcnsidChanged()
    End Sub
    Partial Private Sub OnfdpdtnoChanging(value As String)
    End Sub
    Partial Private Sub OnfdpdtnoChanged()
    End Sub
    Partial Private Sub OnlcntypecdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnlcntypecdChanged()
    End Sub
    Partial Private Sub OnprdnmtChanging(value As String)
    End Sub
    Partial Private Sub OnprdnmtChanged()
    End Sub
    Partial Private Sub OnprdnmeChanging(value As String)
    End Sub
    Partial Private Sub OnprdnmeChanged()
    End Sub
    Partial Private Sub OnProducer_NameChanging(value As String)
    End Sub
    Partial Private Sub OnProducer_NameChanged()
    End Sub
    Partial Private Sub OngroupnameChanging(value As String)
    End Sub
    Partial Private Sub OngroupnameChanged()
    End Sub
    Partial Private Sub OnNewCodeChanging(value As String)
    End Sub
    Partial Private Sub OnNewCodeChanged()
    End Sub
    Partial Private Sub OnRankingChanging(value As String)
    End Sub
    Partial Private Sub OnRankingChanged()
    End Sub
    Partial Private Sub OncntcdChanging(value As String)
    End Sub
    Partial Private Sub OncntcdChanged()
    End Sub
    Partial Private Sub OnappdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnappdateChanged()
    End Sub
    Partial Private Sub OnexpdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnexpdateChanged()
    End Sub
    Partial Private Sub OnCreateDateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnCreateDateChanged()
    End Sub
    Partial Private Sub OnUpdateDateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnUpdateDateChanged()
    End Sub
    Partial Private Sub OnridChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnridChanged()
    End Sub
    Partial Private Sub OnCer_expdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnCer_expdateChanged()
    End Sub
    Partial Private Sub OnBrandChanging(value As String)
    End Sub
    Partial Private Sub OnBrandChanged()
    End Sub
    Partial Private Sub OnthanmChanging(value As String)
    End Sub
    Partial Private Sub OnthanmChanged()
    End Sub
    Partial Private Sub OnStatusChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnStatusChanged()
    End Sub
    Partial Private Sub OnAddrChanging(value As String)
    End Sub
    Partial Private Sub OnAddrChanged()
    End Sub
    Partial Private Sub OnfdtypecdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnfdtypecdChanged()
    End Sub
    Partial Private Sub OnfdtypenmChanging(value As String)
    End Sub
    Partial Private Sub OnfdtypenmChanged()
    End Sub
    Partial Private Sub OnthanmownerChanging(value As String)
    End Sub
    Partial Private Sub OnthanmownerChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDA", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IDA() As Integer
		Get
			Return Me._IDA
		End Get
		Set
			If ((Me._IDA = value)  _
						= false) Then
				Me.OnIDAChanging(value)
				Me.SendPropertyChanging
				Me._IDA = value
				Me.SendPropertyChanged("IDA")
				Me.OnIDAChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pvncd", DbType:="SmallInt")>  _
	Public Property pvncd() As System.Nullable(Of Short)
		Get
			Return Me._pvncd
		End Get
		Set
			If (Me._pvncd.Equals(value) = false) Then
				Me.OnpvncdChanging(value)
				Me.SendPropertyChanging
				Me._pvncd = value
				Me.SendPropertyChanged("pvncd")
				Me.OnpvncdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno", DbType:="Int")>  _
	Public Property lcnno() As System.Nullable(Of Integer)
		Get
			Return Me._lcnno
		End Get
		Set
			If (Me._lcnno.Equals(value) = false) Then
				Me.OnlcnnoChanging(value)
				Me.SendPropertyChanging
				Me._lcnno = value
				Me.SendPropertyChanged("lcnno")
				Me.OnlcnnoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnsid", DbType:="Int")>  _
	Public Property lcnsid() As System.Nullable(Of Integer)
		Get
			Return Me._lcnsid
		End Get
		Set
			If (Me._lcnsid.Equals(value) = false) Then
				Me.OnlcnsidChanging(value)
				Me.SendPropertyChanging
				Me._lcnsid = value
				Me.SendPropertyChanged("lcnsid")
				Me.OnlcnsidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_fdpdtno", DbType:="NVarChar(255)")>  _
	Public Property fdpdtno() As String
		Get
			Return Me._fdpdtno
		End Get
		Set
			If (String.Equals(Me._fdpdtno, value) = false) Then
				Me.OnfdpdtnoChanging(value)
				Me.SendPropertyChanging
				Me._fdpdtno = value
				Me.SendPropertyChanged("fdpdtno")
				Me.OnfdpdtnoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcntypecd", DbType:="Int")>  _
	Public Property lcntypecd() As System.Nullable(Of Integer)
		Get
			Return Me._lcntypecd
		End Get
		Set
			If (Me._lcntypecd.Equals(value) = false) Then
				Me.OnlcntypecdChanging(value)
				Me.SendPropertyChanging
				Me._lcntypecd = value
				Me.SendPropertyChanged("lcntypecd")
				Me.OnlcntypecdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnmt", DbType:="NVarChar(MAX)")>  _
	Public Property prdnmt() As String
		Get
			Return Me._prdnmt
		End Get
		Set
			If (String.Equals(Me._prdnmt, value) = false) Then
				Me.OnprdnmtChanging(value)
				Me.SendPropertyChanging
				Me._prdnmt = value
				Me.SendPropertyChanged("prdnmt")
				Me.OnprdnmtChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnme", DbType:="NVarChar(MAX)")>  _
	Public Property prdnme() As String
		Get
			Return Me._prdnme
		End Get
		Set
			If (String.Equals(Me._prdnme, value) = false) Then
				Me.OnprdnmeChanging(value)
				Me.SendPropertyChanging
				Me._prdnme = value
				Me.SendPropertyChanged("prdnme")
				Me.OnprdnmeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Producer_Name", DbType:="NVarChar(MAX)")>  _
	Public Property Producer_Name() As String
		Get
			Return Me._Producer_Name
		End Get
		Set
			If (String.Equals(Me._Producer_Name, value) = false) Then
				Me.OnProducer_NameChanging(value)
				Me.SendPropertyChanging
				Me._Producer_Name = value
				Me.SendPropertyChanged("Producer_Name")
				Me.OnProducer_NameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_groupname", DbType:="NVarChar(50)")>  _
	Public Property groupname() As String
		Get
			Return Me._groupname
		End Get
		Set
			If (String.Equals(Me._groupname, value) = false) Then
				Me.OngroupnameChanging(value)
				Me.SendPropertyChanging
				Me._groupname = value
				Me.SendPropertyChanged("groupname")
				Me.OngroupnameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NewCode", DbType:="NVarChar(MAX)")>  _
	Public Property NewCode() As String
		Get
			Return Me._NewCode
		End Get
		Set
			If (String.Equals(Me._NewCode, value) = false) Then
				Me.OnNewCodeChanging(value)
				Me.SendPropertyChanging
				Me._NewCode = value
				Me.SendPropertyChanged("NewCode")
				Me.OnNewCodeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Ranking", DbType:="NVarChar(50)")>  _
	Public Property Ranking() As String
		Get
			Return Me._Ranking
		End Get
		Set
			If (String.Equals(Me._Ranking, value) = false) Then
				Me.OnRankingChanging(value)
				Me.SendPropertyChanging
				Me._Ranking = value
				Me.SendPropertyChanged("Ranking")
				Me.OnRankingChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_cntcd", DbType:="NVarChar(50)")>  _
	Public Property cntcd() As String
		Get
			Return Me._cntcd
		End Get
		Set
			If (String.Equals(Me._cntcd, value) = false) Then
				Me.OncntcdChanging(value)
				Me.SendPropertyChanging
				Me._cntcd = value
				Me.SendPropertyChanged("cntcd")
				Me.OncntcdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_appdate", DbType:="DateTime")>  _
	Public Property appdate() As System.Nullable(Of Date)
		Get
			Return Me._appdate
		End Get
		Set
			If (Me._appdate.Equals(value) = false) Then
				Me.OnappdateChanging(value)
				Me.SendPropertyChanging
				Me._appdate = value
				Me.SendPropertyChanged("appdate")
				Me.OnappdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_expdate", DbType:="DateTime")>  _
	Public Property expdate() As System.Nullable(Of Date)
		Get
			Return Me._expdate
		End Get
		Set
			If (Me._expdate.Equals(value) = false) Then
				Me.OnexpdateChanging(value)
				Me.SendPropertyChanging
				Me._expdate = value
				Me.SendPropertyChanged("expdate")
				Me.OnexpdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreateDate", DbType:="DateTime")>  _
	Public Property CreateDate() As System.Nullable(Of Date)
		Get
			Return Me._CreateDate
		End Get
		Set
			If (Me._CreateDate.Equals(value) = false) Then
				Me.OnCreateDateChanging(value)
				Me.SendPropertyChanging
				Me._CreateDate = value
				Me.SendPropertyChanged("CreateDate")
				Me.OnCreateDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UpdateDate", DbType:="DateTime")>  _
	Public Property UpdateDate() As System.Nullable(Of Date)
		Get
			Return Me._UpdateDate
		End Get
		Set
			If (Me._UpdateDate.Equals(value) = false) Then
				Me.OnUpdateDateChanging(value)
				Me.SendPropertyChanging
				Me._UpdateDate = value
				Me.SendPropertyChanged("UpdateDate")
				Me.OnUpdateDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_rid", DbType:="Int")>  _
	Public Property rid() As System.Nullable(Of Integer)
		Get
			Return Me._rid
		End Get
		Set
			If (Me._rid.Equals(value) = false) Then
				Me.OnridChanging(value)
				Me.SendPropertyChanging
				Me._rid = value
				Me.SendPropertyChanged("rid")
				Me.OnridChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Cer_expdate", DbType:="DateTime")>  _
	Public Property Cer_expdate() As System.Nullable(Of Date)
		Get
			Return Me._Cer_expdate
		End Get
		Set
			If (Me._Cer_expdate.Equals(value) = false) Then
				Me.OnCer_expdateChanging(value)
				Me.SendPropertyChanging
				Me._Cer_expdate = value
				Me.SendPropertyChanged("Cer_expdate")
				Me.OnCer_expdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Brand", DbType:="NVarChar(MAX)")>  _
	Public Property Brand() As String
		Get
			Return Me._Brand
		End Get
		Set
			If (String.Equals(Me._Brand, value) = false) Then
				Me.OnBrandChanging(value)
				Me.SendPropertyChanging
				Me._Brand = value
				Me.SendPropertyChanged("Brand")
				Me.OnBrandChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thanm", DbType:="NVarChar(MAX)")>  _
	Public Property thanm() As String
		Get
			Return Me._thanm
		End Get
		Set
			If (String.Equals(Me._thanm, value) = false) Then
				Me.OnthanmChanging(value)
				Me.SendPropertyChanging
				Me._thanm = value
				Me.SendPropertyChanged("thanm")
				Me.OnthanmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Status", DbType:="Int")>  _
	Public Property Status() As System.Nullable(Of Integer)
		Get
			Return Me._Status
		End Get
		Set
			If (Me._Status.Equals(value) = false) Then
				Me.OnStatusChanging(value)
				Me.SendPropertyChanging
				Me._Status = value
				Me.SendPropertyChanged("Status")
				Me.OnStatusChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Addr", DbType:="NVarChar(MAX)")>  _
	Public Property Addr() As String
		Get
			Return Me._Addr
		End Get
		Set
			If (String.Equals(Me._Addr, value) = false) Then
				Me.OnAddrChanging(value)
				Me.SendPropertyChanging
				Me._Addr = value
				Me.SendPropertyChanged("Addr")
				Me.OnAddrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_fdtypecd", DbType:="Int")>  _
	Public Property fdtypecd() As System.Nullable(Of Integer)
		Get
			Return Me._fdtypecd
		End Get
		Set
			If (Me._fdtypecd.Equals(value) = false) Then
				Me.OnfdtypecdChanging(value)
				Me.SendPropertyChanging
				Me._fdtypecd = value
				Me.SendPropertyChanged("fdtypecd")
				Me.OnfdtypecdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_fdtypenm", DbType:="NVarChar(MAX)")>  _
	Public Property fdtypenm() As String
		Get
			Return Me._fdtypenm
		End Get
		Set
			If (String.Equals(Me._fdtypenm, value) = false) Then
				Me.OnfdtypenmChanging(value)
				Me.SendPropertyChanging
				Me._fdtypenm = value
				Me.SendPropertyChanged("fdtypenm")
				Me.OnfdtypenmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_thanmowner", DbType:="NVarChar(MAX)")>  _
	Public Property thanmowner() As String
		Get
			Return Me._thanmowner
		End Get
		Set
			If (String.Equals(Me._thanmowner, value) = false) Then
				Me.OnthanmownerChanging(value)
				Me.SendPropertyChanging
				Me._thanmowner = value
				Me.SendPropertyChanged("thanmowner")
				Me.OnthanmownerChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.food_export")>  _
Partial Public Class food_export
	
	Private _lcnsid As Integer
	
	Private _fdpdtno As Decimal
	
	Private _prdnmt As String
	
	Private _prdnme As String
	
	Private _mthcd As Short
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnsid", DbType:="Int NOT NULL")>  _
	Public Property lcnsid() As Integer
		Get
			Return Me._lcnsid
		End Get
		Set
			If ((Me._lcnsid = value)  _
						= false) Then
				Me._lcnsid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_fdpdtno", DbType:="Decimal(13,0) NOT NULL")>  _
	Public Property fdpdtno() As Decimal
		Get
			Return Me._fdpdtno
		End Get
		Set
			If ((Me._fdpdtno = value)  _
						= false) Then
				Me._fdpdtno = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnmt", DbType:="VarChar(250)")>  _
	Public Property prdnmt() As String
		Get
			Return Me._prdnmt
		End Get
		Set
			If (String.Equals(Me._prdnmt, value) = false) Then
				Me._prdnmt = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnme", DbType:="VarChar(250)")>  _
	Public Property prdnme() As String
		Get
			Return Me._prdnme
		End Get
		Set
			If (String.Equals(Me._prdnme, value) = false) Then
				Me._prdnme = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_mthcd", DbType:="SmallInt NOT NULL")>  _
	Public Property mthcd() As Short
		Get
			Return Me._mthcd
		End Get
		Set
			If ((Me._mthcd = value)  _
						= false) Then
				Me._mthcd = value
			End If
		End Set
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.food_export_check")>  _
Partial Public Class food_export_check
	
	Private _lcnsid As Integer
	
	Private _fdpdtno As Decimal
	
	Private _prdnmt As String
	
	Private _prdnme As String
	
	Private _mthcd As Short
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnsid", DbType:="Int NOT NULL")>  _
	Public Property lcnsid() As Integer
		Get
			Return Me._lcnsid
		End Get
		Set
			If ((Me._lcnsid = value)  _
						= false) Then
				Me._lcnsid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_fdpdtno", DbType:="Decimal(13,0) NOT NULL")>  _
	Public Property fdpdtno() As Decimal
		Get
			Return Me._fdpdtno
		End Get
		Set
			If ((Me._fdpdtno = value)  _
						= false) Then
				Me._fdpdtno = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnmt", DbType:="VarChar(250)")>  _
	Public Property prdnmt() As String
		Get
			Return Me._prdnmt
		End Get
		Set
			If (String.Equals(Me._prdnmt, value) = false) Then
				Me._prdnmt = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prdnme", DbType:="VarChar(250)")>  _
	Public Property prdnme() As String
		Get
			Return Me._prdnme
		End Get
		Set
			If (String.Equals(Me._prdnme, value) = false) Then
				Me._prdnme = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_mthcd", DbType:="SmallInt NOT NULL")>  _
	Public Property mthcd() As Short
		Get
			Return Me._mthcd
		End Get
		Set
			If ((Me._mthcd = value)  _
						= false) Then
				Me._mthcd = value
			End If
		End Set
	End Property
End Class