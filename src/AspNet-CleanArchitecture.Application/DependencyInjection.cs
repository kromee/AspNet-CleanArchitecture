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
              services.AddMediatR(configuration => {
            configuration
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        }catch (Exception ex) {
            string sERr = ex.Message;
        }
      

        return services;
    }
}