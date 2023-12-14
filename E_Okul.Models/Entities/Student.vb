Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure

Public Class Student
    Implements IEntity

    <Key> Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property DateofBirth As Date?
    Public Property SchoolNumber As Integer

    Public Overridable Property Points As ICollection(Of Point)
    Public Overridable Property Address As ICollection(Of Address)

End Class