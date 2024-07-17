using System.Net;
using AspNet_CleanArchitecture.Application.Accounts;
using AspNet_CleanArchitecture.Application.Accounts.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static AspNet_CleanArchitecture.Application.Accounts.Login.LoginCommand;

namespace AspNet_CleanArchitecture.WebApi.Controllers;
[ApiController]
[Route("api/account")]
public class AccountController: ControllerBase{

     private readonly ISender _sender;

    public AccountController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Login( [FromBody] LoginRequest request, CancellationToken cancellationToken
    )
    {
        var command = new LoginCommandRequest(request);
        var resultado =  await _sender.Send(command, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }
    
    
}

