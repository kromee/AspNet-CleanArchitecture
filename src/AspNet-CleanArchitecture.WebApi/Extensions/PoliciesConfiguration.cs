using AspNet_CleanArchitecture.Domain;

namespace CleanArchitecture.WebApi.Extensions;


public  static class PoliciesConfiguration{
    public static IServiceCollection  AddPoliciesServices ( this IServiceCollection services){

        services.AddAuthorization(opt=>{
            opt.AddPolicy(
                PolicyMaster.CURSO_READ, policy => 
                policy.RequireAssertion(
                    context=> context.User.HasClaim(c=>c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.CURSO_READ)
                )
            );
            opt.AddPolicy(
                PolicyMaster.CURSO_WRITE, policy =>
                   policy.RequireAssertion(
                    context => context.User.HasClaim(
                    c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.CURSO_WRITE
                    )
                   )
            );

            opt.AddPolicy(
                PolicyMaster.CURSO_UPDATE, policy =>
                   policy.RequireAssertion(
                    context => context.User.HasClaim(
                    c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.CURSO_UPDATE
                    )
                   )
            );


            opt.AddPolicy(
              PolicyMaster.CURSO_DELETE, policy =>
                 policy.RequireAssertion(
                  context => context.User.HasClaim(
                  c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.CURSO_DELETE
                  )
                 )
          );


            opt.AddPolicy(
             PolicyMaster.INSTRUCTOR_CREATE, policy =>
                policy.RequireAssertion(
                 context => context.User.HasClaim(
                 c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.INSTRUCTOR_CREATE
                 )
                )
         );

            opt.AddPolicy(
                       PolicyMaster.INSTRUCTOR_UPDATE, policy =>
                          policy.RequireAssertion(
                           context => context.User.HasClaim(
                           c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.INSTRUCTOR_UPDATE
                           )
                          )
                   );

            opt.AddPolicy(
                       PolicyMaster.INSTRUCTOR_READ, policy =>
                          policy.RequireAssertion(
                           context => context.User.HasClaim(
                           c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.INSTRUCTOR_READ
                           )
                          )
                   );

            opt.AddPolicy(
                      PolicyMaster.COMENTARIO_READ, policy =>
                         policy.RequireAssertion(
                          context => context.User.HasClaim(
                          c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.COMENTARIO_READ
                          )
                         )
                  );

            opt.AddPolicy(
                       PolicyMaster.COMENTARIO_CREATE, policy =>
                          policy.RequireAssertion(
                           context => context.User.HasClaim(
                           c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.COMENTARIO_CREATE
                           )
                          )
                   );

            opt.AddPolicy(
                       PolicyMaster.COMENTARIO_DELETE, policy =>
                          policy.RequireAssertion(
                           context => context.User.HasClaim(
                           c => c.Type == CustomClaims.POLICIES && c.Value == PolicyMaster.COMENTARIO_DELETE
                           )
                          )
                   );

        });
    return services;
    }

}
