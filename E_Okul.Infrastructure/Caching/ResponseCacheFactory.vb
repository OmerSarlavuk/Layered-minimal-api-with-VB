Imports System.Text.Json
Imports Microsoft.Extensions.Caching.Distributed

Public Class ResponseCacheFactory
    Implements IResponseCacheFactory


    Private ReadOnly _distrubtedCache As IDistributedCache

    Public Sub New(distrubtedCache As IDistributedCache)

        _distrubtedCache = distrubtedCache

    End Sub

    Public Async Function CacheResponseAsync(cacheKey As String, response As Object, expireTimeSeconds As TimeSpan) As Task Implements IResponseCacheFactory.CacheResponseAsync

        If response IsNot Nothing Then
            Dim serializedResponse = JsonSerializer.Serialize(response)

            Await _distrubtedCache.SetStringAsync(cacheKey, serializedResponse, New DistributedCacheEntryOptions With {
                                                  .AbsoluteExpirationRelativeToNow = expireTimeSeconds})

        Else
            Return
        End If

    End Function

    Public Async Function GetCachedResponseAsync(cacheKey As String) As Task(Of String) Implements IResponseCacheFactory.GetCachedResponseAsync

        Dim cachedResponse = Await _distrubtedCache.GetStringAsync(cacheKey)

        Return cachedResponse

    End Function
End Class
