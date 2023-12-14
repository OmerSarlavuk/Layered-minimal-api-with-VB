Imports System.Linq.Expressions
Imports Microsoft.EntityFrameworkCore

Public Class BaseRepository(Of TEntity As {Class, IEntity}, TContext As {DbContext, New})
    Implements IBaseRepository(Of TEntity)

    Public Async Function GetAllAsync(ParamArray includeList() As String) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity).GetAllAsync

        Using context = New TContext()

            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)

            If includeList.Count > 0 Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            Return Await dbSet.ToListAsync()

        End Using

    End Function


    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList() As String) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity).GetAllFilterAsync

        Using context = New TContext()

            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)

            If includeList.Count > 0 Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            Return Await dbSet.Where(predicate).ToListAsync()

        End Using

    End Function


    Public Async Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of TEntity) Implements IBaseRepository(Of TEntity).GetAsync

        Using context = New TContext()

            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)

            Return IIf(predicate IsNot Nothing, Await dbSet.Where(predicate).SingleOrDefaultAsync(), Await dbSet.SingleOrDefaultAsync())

        End Using

    End Function


    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList() As String) As Task(Of TEntity) Implements IBaseRepository(Of TEntity).GetFilterAsync

        Using context = New TContext()

            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)

            If includeList.Count > 0 Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            Return Await dbSet.Where(predicate).SingleOrDefaultAsync()

        End Using

    End Function


    Public Async Function DeleteAsync(entity As TEntity) As Task(Of Boolean) Implements IBaseRepository(Of TEntity).DeleteAsync

        Using context = New TContext()

            Dim dbSet = context.Set(Of TEntity)

            dbSet.Remove(entity)

            Await context.SaveChangesAsync()

            Return True

        End Using

    End Function


    Public Async Function InsertAsync(entity As TEntity) As Task(Of Boolean) Implements IBaseRepository(Of TEntity).InsertAsync

        Using context = New TContext()

            Dim dbSet = context.Set(Of TEntity)

            dbSet.Add(entity)

            Await context.SaveChangesAsync()

            Return True

        End Using

    End Function


    Public Async Function UpdateAsync(entity As TEntity) As Task(Of Boolean) Implements IBaseRepository(Of TEntity).UpdateAsync

        Using context = New TContext()

            Dim dbSet = context.Set(Of TEntity)

            dbSet.Update(entity)

            Await context.SaveChangesAsync()

            Return True

        End Using

    End Function


End Class