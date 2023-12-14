Imports E_Okul.Infrastructure
Imports Microsoft.AspNetCore.Mvc

Public Class BaseController
    Inherits ControllerBase

    <NonAction>
    Public Function SendResponse(Of T)(response As ApiResponse(Of T))
        Return New ObjectResult(response) With {.StatusCode = response.StatusCode}
    End Function

End Class