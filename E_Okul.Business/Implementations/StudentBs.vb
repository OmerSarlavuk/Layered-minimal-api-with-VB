Imports System.Linq.Expressions
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models

Public Class StudentBs
    Implements IStudentBs

    Private ReadOnly _businessRepository As IBusinessRepository(Of Student, StudentGetDto, StudentPostDto, StudentPutDto)

    Public Sub New(businessRepository As IBusinessRepository(Of Student, StudentGetDto, StudentPostDto, StudentPutDto))

        _businessRepository = businessRepository

    End Sub

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of StudentGetDto))) Implements IStudentBs.GetAllAsync
        Return Await _businessRepository.GetAllAsync(includeList)
    End Function

    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of Student, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of StudentGetDto))) Implements IStudentBs.GetAllFilterAsync
        Return Await _businessRepository.GetAllFilterAsync(predicate, includeList)
    End Function

    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of Student, Boolean)), ParamArray includeList() As String) As Task(Of ApiResponse(Of StudentGetDto)) Implements IStudentBs.GetFilterAsync
        Return Await _businessRepository.GetFilterAsync(predicate, includeList)
    End Function

    Public Async Function DeleteAsync(predicate As Expression(Of Func(Of Student, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements IStudentBs.DeleteAsync
        Return Await _businessRepository.DeleteAsync(predicate)
    End Function

    Public Async Function InsertAsync(postDto As StudentPostDto) As Task(Of ApiResponse(Of Boolean)) Implements IStudentBs.InsertAsync
        Return Await _businessRepository.InsertAsync(postDto, Function(x) x.SchoolNumber = postDto.SchoolNumber)
    End Function

    Public Async Function UpdateAsync(putDto As StudentPutDto) As Task(Of ApiResponse(Of Boolean)) Implements IStudentBs.UpdateAsync
        Return Await _businessRepository.UpdateAsync(putDto, Function(x) x.SchoolNumber = putDto.SchoolNumber)
    End Function

    Public Async Function GetbyNameAsync(studentName As String) As Task(Of ApiResponse(Of List(Of StudentGetDto))) Implements IStudentBs.GetbyNameAsync
        Return Await _businessRepository.GetAllFilterAsync(Function(x) x.FirstName = studentName)
    End Function
End Class