using System.Threading.Tasks.Dataflow;
using AspNet_CleanArchitecture.Application.Cursos.CursoCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Cursos.CursoCreate.CursoCreateCommand;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/Cursos")]
public class CursoController : ControllerBase {
    private readonly ISender  _sender;
    public CursoController (ISender sender){
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task< ActionResult<Guid>> CursoCreate ([FromForm] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);
       var resultado = await  _sender.Send(command);
       return Ok(resultado);
    }



}