Imports E_Okul.Business
Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc


<Route("api/Student")>
<ApiController>
Public Class StudentController
    Inherits BaseController


    Private ReadOnly _studentBs As IStudentBs

    Public Sub New(studentBs As IStudentBs)
        _studentBs = studentBs
    End Sub

    <Cached(600)>
    <HttpGet("getAllStudent")>
    Public Async Function GetAllStudent() As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.GetAllAsync())
    End Function

    <Cached(600)>
    <HttpGet("getbyId")>
    Public Async Function GetbyId(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.GetFilterAsync(Function(x) x.Id = id))
    End Function

    <HttpPost("getbystudentName")>
    Public Async Function GetbyName(<FromBody> studentName As String) As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.GetbyNameAsync(studentName))
    End Function

    <HttpPost("insertStudent")>
    Public Async Function InsertStudent(<FromBody> postDto As StudentPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.InsertAsync(postDto))
    End Function

    <HttpPut("updateStudent")>
    Public Async Function UpdateStudent(<FromBody> putDto As StudentPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deleteStudent")>
    Public Async Function DeleteStudent(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _studentBs.DeleteAsync(Function(x) x.Id = id))
    End Function

End Class
