Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports System.Linq.Expressions

Public Interface IBranchBs
    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BranchGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Branch, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BranchGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Branch, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of BranchGetDto))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As BranchPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As BranchPutDto) As Task(Of ApiResponse(Of Boolean))
End Interface
