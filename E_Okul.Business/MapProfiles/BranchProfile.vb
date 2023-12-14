Imports AutoMapper
Imports E_Okul.Models

Public Class BranchProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Branch, BranchGetDto)()
        CreateMap(Of Branch, BranchPostDto)().ReverseMap()
        CreateMap(Of Branch, BranchPutDto)().ReverseMap()
    End Sub

End Class
