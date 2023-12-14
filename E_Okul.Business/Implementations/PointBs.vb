Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class PointBs
    Implements IPointBs

    Private ReadOnly _businessRepository As IBusinessRepository(Of Point, PointGetDto, PointPostDto, PointPutDto)

    Public Sub New(businessRepository As IBusinessRepository(Of Point, PointGetDto, PointPostDto, PointPutDto))

        _businessRepository = businessRepository

    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of PointGetDto))) Implements IPointBs.GetAllAsync
        Return Await _businessRepository.GetAllAsync(includeList)
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Point, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of PointGetDto))) Implements IPointBs.GetAllFilterAsync
        Return Await _businessRepository.GetAllFilterAsync(predicate, includeList)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Point, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of PointGetDto)) Implements IPointBs.GetFilterAsync
        Return Await _businessRepository.GetFilterAsync(predicate, includeList)
    End Function

    Public Async Function DeleteAsync(predicate As Expression(Of Func(Of Point, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements IPointBs.DeleteAsync
        Return Await _businessRepository.DeleteAsync(predicate)
    End Function

    Public Async Function InsertAsync(postDto As PointPostDto) As Task(Of ApiResponse(Of Boolean)) Implements IPointBs.InsertAsync
        postDto.Average = postDto.Average.AverageAccounts(postDto.Exam1, postDto.Exam2, postDto.Performance1, postDto.Exam2)
        postDto.Status = postDto.Status.StatusCheck(postDto.Average)
        Return Await _businessRepository.InsertAsync(postDto, Function(x) x.Id = 0)
    End Function

    Public Async Function UpdateAsync(putDto As PointPutDto) As Task(Of ApiResponse(Of Boolean)) Implements IPointBs.UpdateAsync
        Return Await _businessRepository.UpdateAsync(putDto, Function(x) x.Id = 0)
    End Function
End Class
