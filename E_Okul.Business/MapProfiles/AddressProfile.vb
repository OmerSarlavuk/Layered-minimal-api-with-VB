Imports AutoMapper
Imports E_Okul.Models

Public Class AddressProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Address, AddressGetDto)().
            ForMember(Function(dest) dest.FirstName,
                      Sub(opt)
                          opt.MapFrom(Function(src) src.Student.FirstName)
                      End Sub).
                       ForMember(Function(dest) dest.LastName,
                      Sub(opt)
                          opt.MapFrom(Function(src) src.Student.LastName)
                      End Sub)
        CreateMap(Of Address, AddressPostDto)().ReverseMap()
        CreateMap(Of Address, AddressPutDto)().ReverseMap()
    End Sub

End Class
