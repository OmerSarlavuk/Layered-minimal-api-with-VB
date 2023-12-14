Imports System.Linq.Expressions
Imports AutoMapper
Imports E_Okul.Infrastructure

Public Class BusinessRepository(Of TEntity As {Class, IEntity}, GetDto As {Class, IDto}, PostDto As {Class, IDto}, PutDto As {Class, IDto})
    Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto)

    Private ReadOnly _mapper As IMapper
    Private ReadOnly _unitWork As IUnitWork(Of E_OkulDataContext)

    Public Sub New(mapper As IMapper, unitWork As IUnitWork(Of E_OkulDataContext))

        _mapper = mapper
        _unitWork = unitWork

    End Sub


    Public Async Function GetAllAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of GetDto))) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).GetAllAsync

        Dim models = Await _unitWork.GetRepository(Of TEntity).GetAllAsync(includeList)

        If models.Count > 0 And models IsNot Nothing Then

            Try

                Dim dtoList = _mapper.Map(Of List(Of GetDto))(models)
                Return ApiResponse(Of List(Of GetDto)).Success(200, dtoList)

            Catch ex As Exception
                Return ApiResponse(Of List(Of GetDto)).Fail(400, "Mapleme işlemi yapılamadı")
            End Try

        End If

        Return ApiResponse(Of List(Of GetDto)).Fail(404, "Veriler bulunamadı")

    End Function


    Public Async Function GetAllFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of GetDto))) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).GetAllFilterAsync

        Dim models = Await _unitWork.GetRepository(Of TEntity).GetAllFilterAsync(predicate, includeList)

        If models.Count > 0 And models IsNot Nothing Then

            Try

                Dim dtoList = _mapper.Map(Of List(Of GetDto))(models)
                Return ApiResponse(Of List(Of GetDto)).Success(200, dtoList)

            Catch ex As Exception
                Return ApiResponse(Of List(Of GetDto)).Fail(400, "Mapleme işlemi yapılamadı")
            End Try

        End If

        Return ApiResponse(Of List(Of GetDto)).Fail(404, "Veriler bulunamadı")

    End Function


    Public Async Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of TEntity)) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).GetAsync

        Return IIf((Await _unitWork.GetRepository(Of TEntity).GetAsync(predicate)) IsNot Nothing, ApiResponse(Of TEntity).Success(200, Await _unitWork.GetRepository(Of TEntity).GetAsync(predicate)), ApiResponse(Of GetDto).Fail(404, "Veri bulunamadı"))

    End Function


    Public Async Function GetFilterAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of ApiResponse(Of GetDto)) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).GetFilterAsync

        Dim model = Await _unitWork.GetRepository(Of TEntity).GetFilterAsync(predicate, includeList)

        If model IsNot Nothing Then

            Try

                Dim dto = _mapper.Map(Of GetDto)(model)
                Return ApiResponse(Of GetDto).Success(200, dto)

            Catch ex As Exception
                Return ApiResponse(Of GetDto).Fail(404, "Mapleme işlemi yapılamadı")
            End Try

        End If

        Return ApiResponse(Of GetDto).Fail(404, "Veriler bulunamadı")

    End Function


    Public Async Function DeleteAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).DeleteAsync

        Dim deletedModel = Await _unitWork.GetRepository(Of TEntity).GetFilterAsync(predicate)

        Return IIf(deletedModel IsNot Nothing,
                IIf(Await _unitWork.GetRepository(Of TEntity).DeleteAsync(deletedModel),
                    ApiResponse(Of Boolean).Success(200, True),
                    ApiResponse(Of Boolean).Fail(200, "Silme işlemi başarısız.")),
                    ApiResponse(Of Boolean).Fail(400, "Silinecek veri bulunamadı, lütfen istek parametrelerini kontrol ederek tekrar giriniz"))

    End Function


    Public Async Function InsertAsync(postDto As PostDto, predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).InsertAsync

        Dim check = Await GetFilterAsync(predicate)

        If check.StatusCode = 200 Then
            Return ApiResponse(Of Boolean).Fail(400, "Eklenmek istenen veri zaten mevcut")
        End If

        Dim model = _mapper.Map(Of TEntity)(postDto)

        Return IIf(model IsNot Nothing,
                IIf(Await _unitWork.GetRepository(Of TEntity).InsertAsync(model),
                    ApiResponse(Of Boolean).Success(200, True),
                    ApiResponse(Of Boolean).Fail(200, "Kayıt işlemi başarısız")),
                    ApiResponse(Of Boolean).Fail(400, "Kaydedilmek istenen veri tipi hatalıdır."))

    End Function


    Public Async Function UpdateAsync(putDto As PutDto, predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of ApiResponse(Of Boolean)) Implements IBusinessRepository(Of TEntity, GetDto, PostDto, PutDto).UpdateAsync

        Dim check = Await GetFilterAsync(predicate)

        If check.StatusCode = 200 Then
            Return ApiResponse(Of Boolean).Fail(400, "Güncellenmek istenen veriler zaten mevcut!")
        End If

        Dim model = _mapper.Map(Of TEntity)(putDto)

        Return IIf(model IsNot Nothing,
                IIf(Await _unitWork.GetRepository(Of TEntity).UpdateAsync(model),
                ApiResponse(Of Boolean).Success(200, True),
                ApiResponse(Of Boolean).Fail(200, "Güncelleme işlemi başarısız")),
                ApiResponse(Of Boolean).Fail(400, "Güncellenmek istenen veri tipi hatalıdır."))

    End Function


End Class