Imports Microsoft.EntityFrameworkCore

Public Class UnitWork(Of DataContext As {DbContext, New})
    Implements IUnitWork(Of DataContext)


    Private ReadOnly _repositories As Dictionary(Of Type, Object)
    Private ReadOnly _context As DataContext

    Public Sub New(context As DataContext)
        _repositories = New Dictionary(Of Type, Object)()
        _context = context
    End Sub

    Public Async Function CommitAsync() As Task(Of Boolean) Implements IUnitWork(Of DataContext).CommitAsync
        Dim result As Boolean = False

        Using transaction = _context.Database.BeginTransaction()
            Try
                Await _context.SaveChangesAsync()
                Await transaction.CommitAsync()
                result = True
            Catch
                transaction.RollbackAsync()
                Throw
            End Try
        End Using

        Return result
    End Function

    Public Function GetRepository(Of TEntity As {Class, IEntity})() As IBaseRepository(Of TEntity) Implements IUnitWork(Of DataContext).GetRepository
        If _repositories.ContainsKey(GetType(IBaseRepository(Of TEntity))) Then
            Return CType(_repositories(GetType(IBaseRepository(Of TEntity))), IBaseRepository(Of TEntity))
        End If

        Dim repository = New BaseRepository(Of TEntity, DataContext)
        _repositories.Add(GetType(IBaseRepository(Of TEntity)), repository)
        Return repository
    End Function

    Private _disposed As Boolean = False
    Protected Overridable Sub Dispose(disposing As Boolean)
        If _disposed Then
            Return
        End If

        If disposing Then
            _context.Dispose()
        End If
        _disposed = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class