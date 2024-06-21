using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("Demo")]
public class DemoController:ControllerBase
{
    [HttpGet("getNombre")]
    public string GetNombre (){
        return "DevEdum";
    }
}
