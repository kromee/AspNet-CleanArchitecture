


using System.Linq.Expressions;
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace AspNet_CleanArchitecture.Application.Calificaciones.GetCalificaciones;

public class GetCalificacionesQuery
{

    public record GetCalificacionesQueryRequest 
    :IRequest<Result<PagedList<CalificacionResponse>>>
    {
        public GetCalificacionesRequest? CalificacionesRequest {get;set;}
    }

    internal class GetCalificacionesQueryHandler
    : IRequestHandler<GetCalificacionesQueryRequest, Result<PagedList<CalificacionResponse>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCalificacionesQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<CalificacionResponse>>> Handle(GetCalificacionesQueryRequest request, CancellationToken cancellationToken)
        {
            
            IQueryable<Calificacion> queryable = _context.Calificaciones!;
            

            var predicate = ExpressionBuilder.New<Calificacion>();
            if(!string.IsNullOrEmpty(request.CalificacionesRequest!.Alumno))
            {
                predicate = predicate
                .And(y => y.Alumno!.Contains(request.CalificacionesRequest.Alumno));
            }

            if(request.CalificacionesRequest.CursoId is not null)
            {
                predicate = predicate
                .And(y => y.CursoId== request.CalificacionesRequest.CursoId);
            }

            if(!string.IsNullOrEmpty(request.CalificacionesRequest.OrderBy))
            {
                Expression<Func<Calificacion, object>>? orderBySelector =
                    request.CalificacionesRequest.OrderBy.ToLower() switch
                    {
                        "alumno" => x => x.Alumno!,
                        "curso" => x => x.CursoId!,
                        _ => x => x.Alumno!
                    };

                    bool orderBy = request.CalificacionesRequest.OrderAsc.HasValue
                                    ? request.CalificacionesRequest.OrderAsc.Value
                                    : true;

                    queryable = orderBy 
                                ? queryable.OrderBy(orderBySelector)
                                : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var calificacionQuery = queryable
                                    .ProjectTo<CalificacionResponse>(_mapper.ConfigurationProvider)
                                    .AsQueryable();

            var pagination = await PagedList<CalificacionResponse>
                    .CreateAsync(
                        calificacionQuery,
                        request.CalificacionesRequest.PageNumber,
                        request.CalificacionesRequest.PageSize
                    );


            return Result<PagedList<CalificacionResponse>>.Success(pagination);
        }
    }

}


public record CalificacionResponse(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso
)
{
    public CalificacionResponse(): this(null, null, null, null)
    {
    }
}