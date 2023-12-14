Imports E_Okul.Infrastructure

Public Class PointGetDto
    Implements IDto

    Public Property Id As Integer

    'Nav. Prop
    Public Property FirstName As String
    Public Property LastName As String
    Public Property SchoolNumber As String
    Public Property LessonCode As String
    Public Property LessonName As String


    Public Property Exam1 As Byte
    Public Property Exam2 As Byte
    Public Property Performance1 As Byte
    Public Property Performance2 As Byte
    Public Property Average As Decimal
    Public Property Status As String
End Class
