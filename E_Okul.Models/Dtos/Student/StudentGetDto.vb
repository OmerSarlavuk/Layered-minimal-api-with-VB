Imports E_Okul.Infrastructure

Public Class StudentGetDto
    Implements IDto

    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property SchoolNumber As Integer
    Public Property DateofBirth As Date?
End Class
