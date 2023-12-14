Imports E_Okul.Infrastructure

Public Class AddressGetDto
    Implements IDto
    Public Property Id As Integer
    Public Property AddressInformation As String
    Public Property City As String

    'Student
    Public Property FirstName As String
    Public Property LastName As String
End Class
