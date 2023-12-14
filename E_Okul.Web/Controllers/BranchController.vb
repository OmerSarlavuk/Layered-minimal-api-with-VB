Imports E_Okul.Business
Imports E_Okul.Models
Imports Microsoft.AspNetCore.Mvc

<Route("api/Branch")>
<ApiController>
Public Class BranchController
    Inherits BaseController

    Private ReadOnly _branchBs As IBranchBs

    Public Sub New(branchBs As IBranchBs)
        _branchBs = branchBs
    End Sub

    <HttpGet("getAllBranch")>
    Public Async Function GetAllBranch() As Task(Of IActionResult)
        Return SendResponse(Await _branchBs.GetAllAsync())
    End Function

    <HttpGet("getbyId")>
    Public Async Function GetbyId(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _branchBs.GetFilterAsync(Function(x) x.Id = id))
    End Function

    <HttpPost("insertBranch")>
    Public Async Function InsertBranch(<FromBody> postDto As BranchPostDto) As Task(Of IActionResult)
        Return SendResponse(Await _branchBs.InsertAsync(postDto))
    End Function

    <HttpPut("updateBranch")>
    Public Async Function UpdateBranch(<FromBody> putDto As BranchPutDto) As Task(Of IActionResult)
        Return SendResponse(Await _branchBs.UpdateAsync(putDto))
    End Function

    <HttpDelete("deleteBranch")>
    Public Async Function DeleteBranch(<FromQuery> id As Integer) As Task(Of IActionResult)
        Return SendResponse(Await _branchBs.DeleteAsync(id))
    End Function

End Class
