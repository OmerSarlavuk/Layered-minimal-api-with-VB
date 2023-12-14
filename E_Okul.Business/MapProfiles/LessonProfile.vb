Imports AutoMapper
Imports E_Okul.Models

Public Class LessonProfile
        Inherits Profile
        Public Sub New()

            CreateMap(Of Lesson, LessonGetDto)()
            CreateMap(Of Lesson, LessonPostDto)().ReverseMap()
            CreateMap(Of Lesson, LessonPutDto)().ReverseMap()

        End Sub

End Class