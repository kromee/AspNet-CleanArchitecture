using System.Threading.Tasks.Dataflow;
using AspNet_CleanArchitecture.Application.Cursos.CursoCreate;
using AspNet_CleanArchitecture.Application.Cursos.CursoReporteExcel;
using AspNet_CleanArchitecture.Application.Cursos.GetCursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Cursos.CursoCreate.CursoCreateCommand;
using static AspNet_CleanArchitecture.Application.Cursos.CursoReporteExcel.CursoReporteExcelQuery;
using static AspNet_CleanArchitecture.Application.Cursos.GetCurso.GetCursoQuery;
using static AspNet_CleanArchitecture.Application.Cursos.GetCursos.GetCursosQuery;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/cursos")]
public class CursoController : ControllerBase {
    private readonly ISender  _sender;
    public CursoController (ISender sender){
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task< ActionResult<Guid>> CursoCreate ([FromForm]
     CursoCreateRequest request, 
    CancellationToken cancellationToken)
    {
        //throw new Exception("Excepcion es forzada solo para pruebas");
        Console.WriteLine(request);
        var command = new CursoCreateCommandRequest(request);
       var resultado = await  _sender.Send(command);
       return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CursoGet(Guid id, CancellationToken cancellationToken) { 
        var query = new GetCursoQueryRequest{Id=id};
        var resultado  = await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> PaginationCursos([FromQuery] GetCursosRequest request, CancellationToken cancellationToken){
                var query = new GetCursosQueryRequest{CursosRequest = request};
              var resultado  = await _sender.Send(query, cancellationToken);
                return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpGet("reporte")]
    public async Task<ActionResult> ReporteCsv(CancellationToken cancellationToken){
        var query = new CursoReporteExcelQueryRequest();
        var resultado = await _sender.Send(query, cancellationToken);
        byte[] excelBytes =  resultado.ToArray();
        return File(excelBytes, "text/csv", "cursos.csv");

        



    }

    


}