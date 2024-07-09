using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoReporteExcel;

public class CursoReporteExcelQuery{
    public record CursoReporteExcelQueryRequest 
        : IRequest<MemoryStream>;

    internal class CursoReporteExcelQueryHandler
    : IRequestHandler<CursoReporteExcelQueryRequest, MemoryStream>
    {
        private readonly AppDbContext _context;
        private readonly IReportService<Curso> _reporteService;

        public CursoReporteExcelQueryHandler(
            AppDbContext context, 
            IReportService<Curso> reporteService
        )
        {
            _context = context;
            _reporteService = reporteService;
        }

        public async Task<MemoryStream> Handle(
            CursoReporteExcelQueryRequest request, 
            CancellationToken cancellationToken
        )
        {
            var cursos = await _context.Cursos!.Take(10).Skip(0).ToListAsync();

            return await _reporteService.GetCsvReport(cursos);
        }
    }
}