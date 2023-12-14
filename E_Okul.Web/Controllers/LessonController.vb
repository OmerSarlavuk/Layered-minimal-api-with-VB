Imports E_Okul.Business
Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc

<Route("api/Lesson")>
Public Class LessonController
    Inherits BaseController

    Private ReadOnly _lessonBs As ILessonBs

    Public Sub New(lessonBs As ILessonBs)
        _lessonBs = lessonBs
    End Sub

    <Cached(600)>
    <HttpGet("getAllLesson")>
    Public Async Function GetValues() As Task(Of IActionResult)
        Return SendResponse(Await _lessonBs.GetAllAsync())
    End Function

    <Cached(600)>
    <HttpGet("getLesson")>
    Public Async Function GetValue(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _lessonBs.GetFilterAsync(Function(x) x.Id = id))
    End Function

    <HttpPost("insertLesson")>
    Public Async Function PostValue(<FromBody()> postDto As LessonPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _lessonBs.InsertAsync(postDto))
    End Function

    <HttpPut("updateLesson")>
    Public Async Function PutValue(<FromBody()> putDto As LessonPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _lessonBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deleteLesson")>
    Public Async Function DeleteValue(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _lessonBs.DeleteAsync(Function(x) x.Id = id))
    End Function

End Class