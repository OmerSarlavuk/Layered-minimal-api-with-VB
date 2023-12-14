Imports System.Threading
Imports E_Okul.Business
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddSwaggerGen()
        builder.Services.AddControllers()
        builder.Services.AddServicesCollections()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddStackExchangeRedisCache(Sub(options)
                                                        options.Configuration = "localhost:6379"
                                                    End Sub)
        Dim app = builder.Build()


        app.UseSwagger()
        app.UseSwaggerUI(Sub(c)
                             c.SwaggerEndpoint("/swagger/v1/swagger.json", "E_Okul.Web")
                             c.RoutePrefix = String.Empty
                         End Sub)

        app.UseHttpsRedirection()
        app.UseRouting()
        app.UseAuthentication()
        app.UseAuthorization()
        app.MapControllers()
        'app.UseMiddleware(Of GlobalExceptionHandlingMiddleware)()
        app.Run()

    End Sub
End Module