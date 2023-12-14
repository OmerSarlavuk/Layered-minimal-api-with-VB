Imports AutoMapper
Imports E_Okul.Models

Public Class StudentProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Student, StudentGetDto)()
        CreateMap(Of Student, StudentPostDto)().ReverseMap()
        CreateMap(Of Student, StudentPutDto)().ReverseMap()
    End Sub

End Class
