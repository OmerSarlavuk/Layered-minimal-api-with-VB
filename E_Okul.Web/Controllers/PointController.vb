Imports E_Okul.Business
Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc

<Route("api/Point")>
<ApiController>
Public Class PointController
    Inherits BaseController

    Private ReadOnly _pointBs As IPointBs

    Public Sub New(pointBs As IPointBs)
        _pointBs = pointBs
    End Sub

    <Cached(600)>
    <HttpGet("getAllPoint")>
    Public Async Function GetAllPoint() As Task(Of IActionResult)
        Return SendResponse(Await _pointBs.GetAllAsync("Lesson", "Student"))
    End Function

    <Cached(600)>
    <HttpGet("getbyId")>
    Public Async Function GetbyId(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _pointBs.GetFilterAsync(Function(x) x.Id = id, "Lesson", "Student"))
    End Function

    <HttpPost("insertPoint")>
    Public Async Function InsertPoint(<FromBody> postDto As PointPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _pointBs.InsertAsync(postDto))
    End Function

    <HttpPut("updatePoint")>
    Public Async Function UpdatePoint(<FromBody> putDto As PointPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _pointBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deletePoint")>
    Public Async Function DeletePoint(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _pointBs.DeleteAsync(Function(x) x.Id = id))
    End Function

End Class
