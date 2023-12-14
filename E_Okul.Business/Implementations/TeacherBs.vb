Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class TeacherBs
    Implements ITeacherBs

    Private ReadOnly _businessRepository As IBusinessRepository(Of Teacher, TeacherGetDto, TeacherPostDto, TeacherPutDto)
    Private ReadOnly _unitWork As IUnitWork(Of E_OkulDataContext)
    Public Sub New(businessRepository As IBusinessRepository(Of Teacher, TeacherGetDto, TeacherPostDto, TeacherPutDto), unitWork As IUnitWork(Of E_OkulDataContext))
        _businessRepository = businessRepository
        _unitWork = unitWork
    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of TeacherGetDto))) Implements ITeacherBs.GetAllAsync
        Return Await _businessRepository.GetAllAsync(includeList)
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Teacher, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of TeacherGetDto))) Implements ITeacherBs.GetAllFilterAsync
        Return Await _businessRepository.GetAllFilterAsync(predicate, includeList)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Teacher, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of TeacherGetDto)) Implements ITeacherBs.GetFilterAsync
        Return Await _businessRepository.GetFilterAsync(predicate, includeList)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean)) Implements ITeacherBs.DeleteAsync
        Return Await _businessRepository.DeleteAsync(Function(prd) prd.Id = id)
    End Function

    Public Async Function InsertAsync(postDto As TeacherPostDto) As Task(Of ApiResponse(Of Boolean)) Implements ITeacherBs.InsertAsync
        Return Await _businessRepository.InsertAsync(postDto, Function(x) x.FirstName = postDto.FirstName And x.LastName = postDto.LastName And x.Phone = postDto.Phone)
    End Function

    Public Async Function UpdateAsync(putDto As TeacherPutDto) As Task(Of ApiResponse(Of Boolean)) Implements ITeacherBs.UpdateAsync
        Return Await _businessRepository.UpdateAsync(putDto, Function(x) x.Phone = putDto.Phone)
    End Function

End Class