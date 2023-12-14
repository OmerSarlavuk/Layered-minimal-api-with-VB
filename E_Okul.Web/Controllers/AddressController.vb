Imports E_Okul.Business
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc

<Route("api/Address")>
<ApiController>
Public Class AddressController
    Inherits BaseController

    Private ReadOnly _addressBs As IAddressBs

    Public Sub New(addressBs As IAddressBs)
        _addressBs = addressBs
    End Sub

    <HttpGet("getAllAddress")>
    Public Async Function GetAllAddress() As Task(Of IActionResult)
        Return SendResponse(Await _addressBs.GetAllAsync("Student"))
    End Function

    <HttpGet("getbyId")>
    Public Async Function GetbyId(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _addressBs.GetFilterAsync(Function(x) x.Id = id, "Student"))
    End Function

    <HttpPost("insertAddress")>
    Public Async Function InsertAddress(<FromBody> postDto As AddressPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _addressBs.InsertAsync(postDto))
    End Function

    <HttpPut("updateAddress")>
    Public Async Function UpdateAddress(<FromBody> putDto As AddressPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _addressBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deleteAdress")>
    Public Async Function DeleteAddress(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _addressBs.DeleteAsync(id))
    End Function

End Class
