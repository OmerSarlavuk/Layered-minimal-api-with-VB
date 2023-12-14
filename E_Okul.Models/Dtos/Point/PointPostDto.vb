Imports System.Text.Json.Serialization
Imports E_Okul.Infrastructure

Public Class PointPostDto
    Implements IDto

    Public Property StudentId As Integer
    Public Property LessonId As Integer
    Public Property Exam1 As Byte
    Public Property Exam2 As Byte
    Public Property Performance1 As Byte
    Public Property Performance2 As Byte
    <JsonIgnore>
    Public Property Average As Decimal
    <JsonIgnore>
    Public Property Status As String
End Class
