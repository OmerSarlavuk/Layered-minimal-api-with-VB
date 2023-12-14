Imports Microsoft.EntityFrameworkCore

Public Interface IUnitWork(Of DataContext As {DbContext, New})
    Inherits IDisposable

    Function GetRepository(Of TEntity As {Class, IEntity})() As IBaseRepository(Of TEntity)
    Function CommitAsync() As Task(Of Boolean)

End Interface