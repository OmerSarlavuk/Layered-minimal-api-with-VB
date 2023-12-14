Imports System.Linq.Expressions

Public Interface IBaseRepository(Of TEntity As {Class, IEntity})

    Function GetAllAsync(ParamArray includeList As String()) As Task(Of List(Of TEntity))
    Function GetAllFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of List(Of TEntity))
    Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of TEntity)
    Function GetFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of TEntity)
    Function DeleteAsync(entity As TEntity) As Task(Of Boolean)
    Function InsertAsync(entity As TEntity) As Task(Of Boolean)
    Function UpdateAsync(entity As TEntity) As Task(Of Boolean)

End Interface