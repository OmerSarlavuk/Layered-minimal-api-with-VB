Imports AutoMapper
Imports E_Okul.Models

Public Class PointProfile
    Inherits Profile

    Public Sub New()

        CreateMap(Of Point, PointGetDto)().
                        ForMember(Function(dest) dest.FirstName,
                        Sub(opt)
                            opt.MapFrom(Function(src) src.Student.FirstName)
                        End Sub).
                        ForMember(Function(dest) dest.LastName,
                        Sub(opt)
                            opt.MapFrom(Function(src) src.Student.LastName)
                        End Sub).
                         ForMember(Function(dest) dest.SchoolNumber,
                        Sub(opt)
                            opt.MapFrom(Function(src) src.Student.SchoolNumber)
                        End Sub).
                        ForMember(Function(dest) dest.LessonCode,
                        Sub(opt)
                            opt.MapFrom(Function(src) src.Lesson.LessonCode)
                        End Sub).
                        ForMember(Function(dest) dest.LessonName,
                        Sub(opt)
                            opt.MapFrom(Function(src) src.Lesson.LessonName)
                        End Sub)

        CreateMap(Of Point, PointPostDto)().ReverseMap()
        CreateMap(Of Point, PointPutDto)().ReverseMap()

    End Sub

End Class