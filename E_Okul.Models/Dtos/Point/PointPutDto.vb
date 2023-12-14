Imports E_Okul.Infrastructure

Public Class PointPutDto
    Implements IDto

    Public Property Id As Integer
    Public Property StudentId As Integer
    Public Property LessonId As Integer
    Public Property Exam1 As Byte
    Public Property Exam2 As Byte
    Public Property Performance1 As Byte
    Public Property Performance2 As Byte
    Public Property Status As String
End Class
