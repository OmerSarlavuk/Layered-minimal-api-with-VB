Imports E_Okul.Business
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc

<Route("api/Teacher")>
<ApiController>
Public Class TeacherController
    Inherits BaseController

    Private ReadOnly _teacherBs As ITeacherBs

    Public Sub New(teacherBs As ITeacherBs)
        _teacherBs = teacherBs
    End Sub

    <HttpGet("getallTeacher")>
    Public Async Function GetAllTeacher() As Task(Of IActionResult)
        Return SendResponse(Await _teacherBs.GetAllAsync("Branch"))
    End Function

    <HttpGet("getbyId")>
    Public Async Function GetbyId(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _teacherBs.GetFilterAsync(Function(x) x.Id = id, "Branch"))
    End Function

    <HttpPost("insertTeacher")>
    Public Async Function InsertTeacher(<FromBody> postDto As TeacherPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _teacherBs.InsertAsync(postDto))
    End Function

    <HttpPut("updateTeacher")>
    Public Async Function UpdateTeacher(<FromBody> putDto As TeacherPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _teacherBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deleteTeacher")>
    Public Async Function DeleteTeacher(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _teacherBs.DeleteAsync(id))
    End Function

End Class
