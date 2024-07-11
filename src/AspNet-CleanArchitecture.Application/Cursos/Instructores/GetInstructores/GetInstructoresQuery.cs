using System.Linq.Expressions;
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;


namespace AspNet_CleanArchitecture.Application.Instructores.GetInstructores;


public class GetInstructoresQuery
{

    public record GetInstructoresQueryRequest
    : IRequest<Result<PagedList<InstructorResponse>>>
    {
        public GetInstructoresRequest? InstructorRequest {get;set;}

    }


    internal class GetInstructoresQueryHandler
    : IRequestHandler<GetInstructoresQueryRequest, Result<PagedList<InstructorResponse>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetInstructoresQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<InstructorResponse>>> Handle(
            GetInstructoresQueryRequest request, 
            CancellationToken cancellationToken
        )
        {
           
            IQueryable<Instructor> queryable = _context.Instructores!;

            var predicate = ExpressionBuilder.New<Instructor>();
            if(!string.IsNullOrEmpty(request.InstructorRequest!.Nombre))
            {
                predicate = predicate
                .And(y => y.Nombre!.Contains(request.InstructorRequest!.Nombre));
            }

            if(!string.IsNullOrEmpty(request.InstructorRequest!.Apellido))
            {
                predicate = predicate
                .And(y => y.Apellidos!.Contains(request.InstructorRequest!.Apellido));
            }

            if(!string.IsNullOrEmpty(request.InstructorRequest.OrderBy))
            {
                Expression<Func<Instructor, object>>? orderBySelector = 
                request.InstructorRequest.OrderBy.ToLower() switch 
                {
                    "nombre" => instructor => instructor.Nombre!,
                    "apellido" => instructor => instructor.Apellidos!,
                    _ => instructor => instructor.Nombre!
                };

                bool orderBy = request.InstructorRequest.OrderAsc.HasValue 
                            ? request.InstructorRequest.OrderAsc.Value
                            : true;

                queryable = orderBy 
                            ? queryable.OrderBy(orderBySelector)
                            : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var instructoresQuery = queryable
                        .ProjectTo<InstructorResponse>(_mapper.ConfigurationProvider)
                        .AsQueryable();

            var pagination = await PagedList<InstructorResponse>
                .CreateAsync(instructoresQuery, 
                request.InstructorRequest.PageNumber,
                request.InstructorRequest.PageSize
                );

            return Result<PagedList<InstructorResponse>>.Success(pagination);
        }
    }
}

public record InstructorResponse(
    Guid? Id,
    string? Nombre,
    string? Apellido,
    string? Grado
)
{
    public InstructorResponse() : this(null, null, null, null)
    {
    }
}

