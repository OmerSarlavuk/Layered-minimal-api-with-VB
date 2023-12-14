Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure

Public Class Teacher
    Implements IEntity

    <Key> Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Phone As String
    Public Property Age As Integer
    Public Property BranchId As Integer

    Public Property Branch As Branch

End Class
