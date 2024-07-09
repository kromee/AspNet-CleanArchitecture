using System.Threading.Tasks.Dataflow;
using AspNet_CleanArchitecture.Application.Cursos.CursoCreate;
using AspNet_CleanArchitecture.Application.Cursos.CursoReporteExcel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static AspNet_CleanArchitecture.Application.Cursos.CursoCreate.CursoCreateCommand;
using static AspNet_CleanArchitecture.Application.Cursos.CursoReporteExcel.CursoReporteExcelQuery;

namespace CleanArchitecture.WebApi.Controllers;

[ApiController]
[Route("api/Cursos")]
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
        var command = new CursoCreateCommandRequest(request);
       var resultado = await  _sender.Send(command);
       return Ok(resultado);
    }

    [HttpGet("reporte")]
    public async Task<ActionResult> ReporteCsv(CancellationToken cancellationToken){
        var query = new CursoReporteExcelQueryRequest();
        var resultado = await _sender.Send(query, cancellationToken);
        byte[] excelBytes =  resultado.ToArray();
        return File(excelBytes, "text/csv", "cursos.csv");

        



    }

    


}