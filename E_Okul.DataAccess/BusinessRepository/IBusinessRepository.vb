Imports System.Linq.Expressions
Imports E_Okul.Infrastructure

Public Interface IBusinessRepository(Of TEntity As {Class, IEntity}, GetDto As {Class, IDto}, PostDto As {Class, IDto}, PutDto As {Class, IDto})

    Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of GetDto)))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of GetDto)))
    Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of TEntity))
    Function GetFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of GetDto))
    Function DeleteAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean))
    Function InsertAsync(postDto As PostDto, predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean))
    Function UpdateAsync(putDto As PutDto, predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean))

End Interface