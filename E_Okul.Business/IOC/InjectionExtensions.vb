Imports System.Runtime.CompilerServices
Imports E_Okul.DataAccess
Imports E_Okul.Infrastructure
Imports E_Okul.Models
Imports Microsoft.Extensions.DependencyInjection

Public Module InjectionExtensions
    <Extension()>
    Public Sub AddServicesCollections(services As IServiceCollection)

        services.AddAutoMapper(GetType(LessonProfile).Assembly)
        services.AddScoped(Of IResponseCacheFactory, ResponseCacheFactory)()

        services.AddScoped(Of IUnitWork(Of E_OkulDataContext), UnitWork(Of E_OkulDataContext))()
        services.AddScoped(Of E_OkulDataContext)()

        services.AddScoped(Of ILessonBs, LessonBs)()
        services.AddScoped(Of IStudentBs, StudentBs)()
        services.AddScoped(Of IPointBs, PointBs)()
        services.AddScoped(Of ITeacherBs, TeacherBs)()
        services.AddScoped(Of IBranchBs, BranchBs)()
        services.AddScoped(Of IAddressBs, AddressBs)()

        services.AddScoped(Of IBusinessRepository(Of Lesson, LessonGetDto, LessonPostDto, LessonPutDto), BusinessRepository(Of Lesson, LessonGetDto, LessonPostDto, LessonPutDto))
        services.AddScoped(Of IBusinessRepository(Of Student, StudentGetDto, StudentPostDto, StudentPutDto), BusinessRepository(Of Student, StudentGetDto, StudentPostDto, StudentPutDto))
        services.AddScoped(Of IBusinessRepository(Of Point, PointGetDto, PointPostDto, PointPutDto), BusinessRepository(Of Point, PointGetDto, PointPostDto, PointPutDto))
        services.AddScoped(Of IBusinessRepository(Of Teacher, TeacherGetDto, TeacherPostDto, TeacherPutDto), BusinessRepository(Of Teacher, TeacherGetDto, TeacherPostDto, TeacherPutDto))
        services.AddScoped(Of IBusinessRepository(Of Address, AddressGetDto, AddressPostDto, AddressPutDto), BusinessRepository(Of Address, AddressGetDto, AddressPostDto, AddressPutDto))
        services.AddScoped(Of IBusinessRepository(Of Branch, BranchGetDto, BranchPostDto, BranchPutDto), BusinessRepository(Of Branch, BranchGetDto, BranchPostDto, BranchPutDto))

    End Sub
End Module