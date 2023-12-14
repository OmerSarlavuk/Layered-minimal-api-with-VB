Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure

Public Class Branch
    Implements IEntity

    <Key> Public Property Id As Integer
    Public Property BranchName As String


    Public Overridable Property Teachers As ICollection(Of Teacher)
End Class
