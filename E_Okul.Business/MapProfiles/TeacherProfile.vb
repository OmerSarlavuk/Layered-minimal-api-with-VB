Imports AutoMapper
Imports E_Okul.Models

Public Class TeacherProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Teacher, TeacherGetDto)().
                       ForMember(Function(dest) dest.BranchName,
                           Sub(opt)
                               opt.MapFrom(Function(src) src.Branch.BranchName)
                           End Sub)
        CreateMap(Of Teacher, TeacherPostDto)().ReverseMap()
        CreateMap(Of Teacher, TeacherPutDto)().ReverseMap()
    End Sub

End Class
