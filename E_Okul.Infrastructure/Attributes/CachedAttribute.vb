Imports System.Text
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.Filters
Imports Microsoft.Extensions.DependencyInjection
Imports ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
Imports ContentResult = Microsoft.AspNetCore.Mvc.ContentResult

<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method)>
Public Class CachedAttribute
    Inherits Attribute
    Implements IAsyncActionFilter

    Private ReadOnly _expireTimeSeconds As Integer

    Public Sub New(expireTimeSeconds As Integer)
        _expireTimeSeconds = expireTimeSeconds
    End Sub

    Public Async Function OnActionExecutionAsync(context As ActionExecutingContext, neext As ActionExecutionDelegate) As Task Implements IAsyncActionFilter.OnActionExecutionAsync

        Dim cacheFactory = context.HttpContext.RequestServices.GetRequiredService(Of IResponseCacheFactory)()
        Dim cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request)
        Dim cachedResponse = Await cacheFactory.GetCachedResponseAsync(cacheKey)

        If Not String.IsNullOrEmpty(cachedResponse) Then
            Dim contentResult = New ContentResult With {
                .Content = cachedResponse,
                .ContentType = "application/json",
                .StatusCode = StatusCodes.Status200OK ' 200 OK durumu
            }
            context.Result = contentResult
            Return
        End If

        Dim executedContext = Await neext()

        If TypeOf executedContext.Result Is ObjectResult Then
            Dim okObjectResult = DirectCast(executedContext.Result, ObjectResult)
            If okObjectResult.StatusCode = StatusCodes.Status200OK Then
                Await cacheFactory.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_expireTimeSeconds))
            End If
        End If
    End Function

    Private Shared Function GenerateCacheKeyFromRequest(httpContextRequest As HttpRequest) As String
        Dim keyBuilder = New StringBuilder()
        keyBuilder.Append($"{httpContextRequest.Path}")

        For Each pair In httpContextRequest.Query.OrderBy(Function(x) x.Key)
            keyBuilder.Append($"|{pair.Key}-{pair.Value}")
        Next

        Return keyBuilder.ToString()
    End Function
End Class
