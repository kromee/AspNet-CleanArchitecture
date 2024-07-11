using AspNet_CleanArchitecture.Application.Precios.GetPrecios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Precios.GetPrecios.GetPreciosQuery;


namespace CleanArchitecture.WebApi.Controllers;


[ApiController]
[Route("api/precios")]
public class PreciosController: ControllerBase{
    private readonly ISender _sender;
    public PreciosController(ISender sender){
        _sender = sender;
    
    }
    [HttpGet]
    public async Task<IActionResult> PaginationPrecio ( [FromQuery] GetPreciosRequest request, CancellationToken cancellationToken){
        var query = new GetPreciosQueryRequest{
            PreciosRequest = request
        };
         var resultados = await _sender.Send(query, cancellationToken);

         return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();

    }

}