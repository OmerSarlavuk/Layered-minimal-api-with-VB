Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class BranchBs
    Implements IBranchBs

    Private ReadOnly _businessRepository As IBusinessRepository(Of Branch, BranchGetDto, BranchPostDto, BranchPutDto)

    Public Sub New(businessRepository As IBusinessRepository(Of Branch, BranchGetDto, BranchPostDto, BranchPutDto))
        _businessRepository = businessRepository
    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of BranchGetDto))) Implements IBranchBs.GetAllAsync
        Return Await _businessRepository.GetAllAsync(includeList)
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Branch, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of BranchGetDto))) Implements IBranchBs.GetAllFilterAsync
        Return Await _businessRepository.GetAllFilterAsync(predicate, includeList)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Branch, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of BranchGetDto)) Implements IBranchBs.GetFilterAsync
        Return Await _businessRepository.GetFilterAsync(predicate, includeList)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean)) Implements IBranchBs.DeleteAsync
        Return Await _businessRepository.DeleteAsync(Function(x) x.Id = id)
    End Function

    Public Async Function InsertAsync(postDto As BranchPostDto) As Task(Of ApiResponse(Of Boolean)) Implements IBranchBs.InsertAsync
        Return Await _businessRepository.InsertAsync(postDto, Function(x) x.BranchName = postDto.BranchName)
    End Function

    Public Async Function UpdateAsync(putDto As BranchPutDto) As Task(Of ApiResponse(Of Boolean)) Implements IBranchBs.UpdateAsync
        Return Await _businessRepository.UpdateAsync(putDto, Function(x) x.BranchName = putDto.BranchName)
    End Function
End Class
