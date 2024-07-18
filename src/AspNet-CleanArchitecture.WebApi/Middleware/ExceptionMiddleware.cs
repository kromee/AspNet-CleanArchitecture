

using System.Net;
using System.Text.Json;
using AspNet_CleanArchitecture.Application.Core;
using Newtonsoft.Json;

namespace CleanArchitecture.WebApi.Middleware;

public class ExceptionMiddleware{

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly  IHostEnvironment _env;



    public ExceptionMiddleware(RequestDelegate next, 
                                ILogger<ExceptionMiddleware> logger,
                                IHostEnvironment env){
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync (HttpContext context){
        try{
           await _next(context);

        }catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var response = ex switch
            {
                ValidationException validationException => new  AppException(
                   StatusCodes.Status400BadRequest,
                    "Error de validacion",
                    /*string.Join(
                        ",",
                        validationException.Errors.Select(er => er.ErrorMessage)
                    )*/
                     JsonConvert.SerializeObject(validationException.Errors.ToArray())
                ),
                 _ => new AppException(
                    context.Response.StatusCode,
                    ex.Message,
                    ex.StackTrace?.ToString()
                )
                
            };
             
            
            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(json);

          
        }

    }

}