using System.Net;
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Application.Instructores.GetInstructores;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Instructores.GetInstructores.GetInstructoresQuery;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/instructores")]
public class InstructoresController : ControllerBase{

    private readonly ISender _sender;
    public InstructoresController(ISender sender){
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<InstructorResponse>>>PaginationInstructor([FromQuery] GetInstructoresRequest request, CancellationToken cancellationToken){
       var query = new GetInstructoresQueryRequest {
            InstructorRequest = request
        };
        var resultados =  await _sender.Send(query, cancellationToken);
        return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();

    }

}