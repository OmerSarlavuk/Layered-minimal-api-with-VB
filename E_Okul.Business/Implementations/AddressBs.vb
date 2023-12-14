Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class AddressBs
    Implements IAddressBs

    Private ReadOnly _businessRepository As IBusinessRepository(Of Address, AddressGetDto, AddressPostDto, AddressPutDto)

    Public Sub New(businessRepository As IBusinessRepository(Of Address, AddressGetDto, AddressPostDto, AddressPutDto))
        _businessRepository = businessRepository
    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of AddressGetDto))) Implements IAddressBs.GetAllAsync
        Return Await _businessRepository.GetAllAsync(includeList)
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Address, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of AddressGetDto))) Implements IAddressBs.GetAllFilterAsync
        Return Await _businessRepository.GetAllFilterAsync(predicate, includeList)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Address, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of AddressGetDto)) Implements IAddressBs.GetFilterAsync
        Return Await _businessRepository.GetFilterAsync(predicate, includeList)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean)) Implements IAddressBs.DeleteAsync
        Return Await _businessRepository.DeleteAsync(Function(x) x.Id = id)
    End Function

    Public Async Function InsertAsync(postDto As AddressPostDto) As Task(Of ApiResponse(Of Boolean)) Implements IAddressBs.InsertAsync
        Return Await _businessRepository.InsertAsync(postDto, Function(x) x.AddressInformation = postDto.AddressInformation)
    End Function

    Public Async Function UpdateAsync(putDto As AddressPutDto) As Task(Of ApiResponse(Of Boolean)) Implements IAddressBs.UpdateAsync
        Dim k = Await _businessRepository.GetAsync(Function(x) x.Id = putDto.Id)
        putDto.StudentId = k.Data.StudentId
        Return Await _businessRepository.UpdateAsync(putDto, Function(x) x.AddressInformation = putDto.AddressInformation)
    End Function

End Class