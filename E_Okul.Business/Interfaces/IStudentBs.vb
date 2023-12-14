Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports System.Linq.Expressions

Public Interface IStudentBs

    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of StudentGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Student, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of StudentGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Student, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of StudentGetDto))
    Function DeleteAsync(predicate As Expression(Of Func(Of Student, Boolean))) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As StudentPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As StudentPutDto) As Task(Of ApiResponse(Of Boolean))
    Function GetbyNameAsync(studentName As String) As Task(Of ApiResponse(Of List(Of StudentGetDto)))

End Interface