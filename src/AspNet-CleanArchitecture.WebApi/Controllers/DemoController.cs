using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("Demo")]
public class DemoController:ControllerBase
{

private readonly IConfiguration _configiguration;
private readonly IWebHostEnvironment _environment;

public DemoController(IConfiguration configiguration, IWebHostEnvironment environment){
    _configiguration = configiguration;
    _environment = environment;

}

    [HttpGet("getNombre")]
    public string GetNombre (){
        return "DevEdum";
    }

    [HttpGet("ambiente")]
    public IActionResult GetAmbiente (){
        var mensaje =  _configiguration.GetValue<string>("MiVariable");
        var ambiente = _environment.EnvironmentName;

        return Ok(new {Ambiente= ambiente, Mensaje = mensaje});
        
    }
}
