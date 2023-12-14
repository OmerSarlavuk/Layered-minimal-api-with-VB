Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports System.Linq.Expressions

Public Interface ITeacherBs
    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of TeacherGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Teacher, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of TeacherGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Teacher, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of TeacherGetDto))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As TeacherPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As TeacherPutDto) As Task(Of ApiResponse(Of Boolean))
End Interface
