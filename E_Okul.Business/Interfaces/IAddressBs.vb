Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports System.Linq.Expressions

Public Interface IAddressBs

    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of AddressGetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of Address, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of AddressGetDto)))
    Function GetFilterAsync(predicate As Expression(Of Func(Of Address, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of AddressGetDto))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As AddressPostDto) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As AddressPutDto) As Task(Of ApiResponse(Of Boolean))

End Interface
