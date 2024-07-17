using System.Net;
using System.Security.Claims;
using AspNet_CleanArchitecture.Application.Accounts;
using AspNet_CleanArchitecture.Application.Accounts.GetCurrentUser;
using AspNet_CleanArchitecture.Application.Accounts.Login;
using AspNet_CleanArchitecture.Application.Accounts.Register;
using AspNet_CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Accounts.GetCurrentUser.GetCurrentUserQuery;

using static AspNet_CleanArchitecture.Application.Accounts.Login.LoginCommand;
using static AspNet_CleanArchitecture.Application.Accounts.Register.RegisterCommand;

namespace AspNet_CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController: ControllerBase{

     private readonly ISender _sender;
     private readonly IUserAccessor _user;
    public AccountController(ISender sender, IUserAccessor user)
    {
        _sender = sender;
        _user = user;
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
    

    [AllowAnonymous]
    [HttpPost("register")]
   [ProducesResponseType((int)HttpStatusCode.OK)]
       public async Task<ActionResult<Profile>> Register(
        [FromForm] RegisterRequest request,
        CancellationToken cancelationToken
    ){

        var command = new RegisterCommandRequest (request);
        var resultado = await _sender.Send(command, cancelationToken);
        return resultado.IsSuccess ? Ok(resultado.Value): Unauthorized();

    }
    

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Me(CancellationToken cancellationToken)
    {
        var email = _user.GetEmail();
        
        var request = new GetCurrentUserRequest {Email = email};
        var query = new GetCurrentUserQueryRequest(request);
        var resultado =  await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }


}

