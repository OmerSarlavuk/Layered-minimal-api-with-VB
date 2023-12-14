Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure

Public Class Address
    Implements IEntity

    <Key> Public Property Id As Integer
    Public Property AddressInformation As String
    Public Property City As String
    Public Property StudentId As Integer

    Public Property Student As Student

End Class
