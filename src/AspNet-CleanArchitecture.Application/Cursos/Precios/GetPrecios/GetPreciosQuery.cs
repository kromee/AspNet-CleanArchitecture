using AspNet_CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore.Query.Internal;
using AspNet_CleanArchitecture.Application.Core;
using System.Linq.Expressions;
using AspNet_CleanArchitecture.Domain;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace AspNet_CleanArchitecture.Application.Precios.GetPrecios;


public class GetPreciosQuery
{

    public record GetPreciosQueryRequest 
    : IRequest<Result<PagedList<PrecioResponse>>>
    {
        public GetPreciosRequest? PreciosRequest {get;set;} 
    }

    internal class GetPreciosQueryHandler :
    IRequestHandler<GetPreciosQueryRequest, Result<PagedList<PrecioResponse>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPreciosQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<PrecioResponse>>> Handle(
            GetPreciosQueryRequest request, 
            CancellationToken cancellationToken
        )
        {
        
            IQueryable<Precio> queryable = _context.Precios!;

            var predicate = ExpressionBuilder.New<Precio>();

            if(!string.IsNullOrEmpty(request.PreciosRequest!.Nombre))
            {   
                predicate  = predicate
                .And(y => y.Nombre!.Contains(request.PreciosRequest!.Nombre));
            }

            if(!string.IsNullOrEmpty(request.PreciosRequest!.OrderBy))
            {
                Expression<Func<Precio, object>>? orderSelector = 
                    request.PreciosRequest.OrderBy.ToLower() switch
                    {
                        "nombre" => x => x.Nombre!,
                        "precio" => x => x.PrecioActual,
                        _ =>x => x.Nombre!
                    };

                    bool orderBy = request.PreciosRequest.OrderAsc.HasValue
                        ? request.PreciosRequest.OrderAsc.Value
                        : true;
                    
                    queryable = orderBy
                                ? queryable.OrderBy(orderSelector)
                                : queryable.OrderByDescending(orderSelector);
            }

            queryable = queryable.Where(predicate);

            var preciosQuery = queryable
                    .ProjectTo<PrecioResponse>(_mapper.ConfigurationProvider)
                    .AsQueryable();
           

           var pagination = await PagedList<PrecioResponse>
            .CreateAsync(preciosQuery, 
                request.PreciosRequest.PageNumber, 
                request.PreciosRequest.PageSize
           );

           return Result<PagedList<PrecioResponse>>.Success(pagination);
        }
    }
}


public record PrecioResponse(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion
)
{
    public PrecioResponse(): this(null, null, null, null)
    {
    }
}