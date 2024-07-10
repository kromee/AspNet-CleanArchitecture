using AspNet_CleanArchitecture.Application.Cursos.CursoCreate;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet_CleanArchitecture.Application;


public static class DependencyInjection
{
   public static IServiceCollection AddApplication(
        this IServiceCollection services
    )
    {
        try{

        

        //REISAR PORQUE EN ESTA LINEA GENERAR ERROR
        services.AddMediatR(configuration => {
            configuration
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        
         services.AddFluentValidationAutoValidation();
        
        services.AddValidatorsFromAssemblyContaining<CursoCreateCommand>();





        }catch (Exception ex) {
            string sERr = ex.Message;
            Console.WriteLine("ACÁ ES DONDE MARCA EL ERROR:  " + sERr);
        }
      

        return services;
    }
}