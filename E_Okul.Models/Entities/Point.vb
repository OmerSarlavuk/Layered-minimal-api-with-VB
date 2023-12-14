Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure
Public Class Point
    Implements IEntity

    <Key> Public Property Id As Integer
    Public Property StudentId As Integer
    Public Property LessonId As Integer
    Public Property Exam1 As Byte
    Public Property Exam2 As Byte
    Public Property Performance1 As Byte
    Public Property Performance2 As Byte
    Public Property Average As Decimal
    Public Property Status As String

    Public Property Student As Student
    Public Property Lesson As Lesson

End Class
