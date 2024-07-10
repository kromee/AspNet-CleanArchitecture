// command
//commandhamdler

using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using FluentValidation;
using MediatR;

using AspNet_CleanArchitecture.Application.Core;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoCreate;

public class CursoCreateCommand{
    public record CursoCreateCommandRequest(CursoCreateRequest   cursoCreateRequest)
    : IRequest<Guid>;
    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Guid>
    {
        private readonly AppDbContext _context;

        public CursoCreateCommandHandler(AppDbContext context){
            _context = context;
        }
        public async Task<Guid> Handle  (CursoCreateCommandRequest request, CancellationToken cancellationToken )
            {
            var curso = new Curso{
                Id=Guid.NewGuid(),
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion  = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion
            };

            _context.Add(curso);
            await _context.SaveChangesAsync(cancellationToken);

            return curso.Id;

            }
        }
    
public class CursoCreateCommandRequestValidator
    : AbstractValidator<CursoCreateCommandRequest>
    {
        public CursoCreateCommandRequestValidator()
        {
            RuleFor(x => x.cursoCreateRequest).SetValidator(new CursoCreateValidator());
        }

    }

}

