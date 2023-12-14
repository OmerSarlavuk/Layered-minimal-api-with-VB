Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports System.Linq.Expressions

Public Interface IPointBs
    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of PointGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Point, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of PointGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Point, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of PointGetDto))
    Function DeleteAsync(predicate As Expression(Of Func(Of Point, Boolean))) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As PointPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As PointPutDto) As Task(Of ApiResponse(Of Boolean))
End Interface
