

using AspNet_CleanArchitecture.Application.Calificaciones.GetCalificaciones;
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Application.Instructores.GetInstructores;
using AspNet_CleanArchitecture.Application.Photos.GetPhoto;
using AspNet_CleanArchitecture.Application.Precios.GetPrecios;
using AspNet_CleanArchitecture.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNet_CleanArchitecture.Application.Cursos.GetCurso;

public class GetCursoQuery{
    public record GetCursoQueryRequest: IRequest<Result<CursoResponse>>{
        public Guid Id {get; set; }
        
    }

    internal class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, Result<CursoResponse>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetCursoQueryHandler(AppDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
            
        }

        public async Task<Result<CursoResponse>> Handle(
            GetCursoQueryRequest request, 
            CancellationToken cancellationToken)
        {
          var curso = await _dbContext.Cursos!.Where(x => x.Id == request.Id)
                            .Include(x=>x.Instructores)
                            .Include(x => x.Precios)
                            .Include(x => x.Calificaciones)
                            .ProjectTo<CursoResponse>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

            return Result<CursoResponse>.Success(curso!);
        }
    }



}


public record CursoResponse(
        Guid Id,
    string Titulo,
    string Descripcion,
    DateTime? FechaPublicacion,
    List<InstructorResponse> Instructores,
    List<CalificacionResponse> Calificaciones, 
    List<PrecioResponse> Precios,
    List<PhotoResponse> Photos
);
