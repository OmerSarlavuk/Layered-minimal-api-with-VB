Public Interface IResponseCacheFactory

    Function CacheResponseAsync(cacheKey As String, response As Object, expireTimeSeconds As TimeSpan) As Task
    Function GetCachedResponseAsync(cacheKey As String) As Task(Of String)

End Interface
