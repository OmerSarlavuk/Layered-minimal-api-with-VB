Imports System.Linq.Expressions
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Interface ILessonBs

    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of LessonGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Lesson, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of LessonGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Lesson, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of LessonGetDto))
    Function DeleteAsync(predicate As Expression(Of Func(Of Lesson, Boolean))) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As LessonPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As LessonPutDto) As Task(Of ApiResponse(Of Boolean))

End Interface