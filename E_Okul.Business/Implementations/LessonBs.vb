Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class LessonBs
    Implements ILessonBs

    Private ReadOnly _businessRepo As IBusinessRepository(Of Lesson, LessonGetDto, LessonPostDto, LessonPutDto)

    Public Sub New(businessRepo As IBusinessRepository(Of Lesson, LessonGetDto, LessonPostDto, LessonPutDto))
        _businessRepo = businessRepo
    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of LessonGetDto))) Implements ILessonBs.GetAllAsync
        Return Await _businessRepo.GetAllAsync()
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Lesson, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of LessonGetDto))) Implements ILessonBs.GetAllFilterAsync
        Return Await _businessRepo.GetAllFilterAsync(predicate)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Lesson, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of LessonGetDto)) Implements ILessonBs.GetFilterAsync
        Return Await _businessRepo.GetFilterAsync(predicate)
    End Function

    Public Async Function DeleteAsync(predicate As Expression(Of Func(Of Lesson, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements ILessonBs.DeleteAsync
        Return Await _businessRepo.DeleteAsync(predicate)
    End Function

    Public Async Function InsertAsync(postDto As LessonPostDto) As Task(Of ApiResponse(Of Boolean)) Implements ILessonBs.InsertAsync
        Return Await _businessRepo.InsertAsync(postDto, Function(x) x.LessonCode = postDto.LessonCode Or x.LessonName = postDto.LessonName)
    End Function


    Public Async Function UpdateAsync(putDto As LessonPutDto) As Task(Of ApiResponse(Of Boolean)) Implements ILessonBs.UpdateAsync
        Return Await _businessRepo.UpdateAsync(putDto, Function(x) x.LessonCode = putDto.LessonCode Or x.LessonName = putDto.LessonName)
    End Function

End Class