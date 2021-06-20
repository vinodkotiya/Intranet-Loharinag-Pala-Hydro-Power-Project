﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4927
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


<System.Data.Linq.Mapping.DatabaseAttribute(Name:="intradb")>  _
Partial Public Class circularsDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, mappingSource)
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
	
	Public ReadOnly Property circulars() As System.Data.Linq.Table(Of circular)
		Get
			Return Me.GetTable(Of circular)
		End Get
	End Property
End Class

<Table(Name:="dbo.circulars")>  _
Partial Public Class circular
	
	Private _cno As String
	
	Private _sub As String
	
	Private _dept As String
	
	Private _name As String
	
	Private _cdate As Date
	
	Private _cdatetext As String
	
	Private _filename As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Column(Storage:="_cno", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property cno() As String
		Get
			Return Me._cno
		End Get
		Set
			If (String.Equals(Me._cno, value) = false) Then
				Me._cno = value
			End If
		End Set
	End Property
	
	<Column(Name:="sub", Storage:="_sub", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property [sub]() As String
		Get
			Return Me._sub
		End Get
		Set
			If (String.Equals(Me._sub, value) = false) Then
				Me._sub = value
			End If
		End Set
	End Property
	
	<Column(Storage:="_dept", DbType:="NChar(10) NOT NULL", CanBeNull:=false)>  _
	Public Property dept() As String
		Get
			Return Me._dept
		End Get
		Set
			If (String.Equals(Me._dept, value) = false) Then
				Me._dept = value
			End If
		End Set
	End Property
	
	<Column(Storage:="_name", DbType:="NText NOT NULL", CanBeNull:=false, UpdateCheck:=UpdateCheck.Never)>  _
	Public Property name() As String
		Get
			Return Me._name
		End Get
		Set
			If (String.Equals(Me._name, value) = false) Then
				Me._name = value
			End If
		End Set
	End Property
	
	<Column(Name:="cdate", Storage:="_cdate", DbType:="Date NOT NULL")>  _
	Public Property [cdate]() As Date
		Get
			Return Me._cdate
		End Get
		Set
			If ((Me._cdate = value)  _
						= false) Then
				Me._cdate = value
			End If
		End Set
	End Property
	
	<Column(Storage:="_cdatetext", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property cdatetext() As String
		Get
			Return Me._cdatetext
		End Get
		Set
			If (String.Equals(Me._cdatetext, value) = false) Then
				Me._cdatetext = value
			End If
		End Set
	End Property
	
	<Column(Storage:="_filename", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property filename() As String
		Get
			Return Me._filename
		End Get
		Set
			If (String.Equals(Me._filename, value) = false) Then
				Me._filename = value
			End If
		End Set
	End Property
End Class