// command
//commandhamdler

using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using MediatR;
namespace AspNet_CleanArchitecture.Application.Cursos.CursoCreate;

public class CursoCreateCommand{
    public record CursoCreateCommandRequest(CursoCreateRequest  CursoCreateRequest): IRequest <Guid>;
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
            Titulo = request.CursoCreateRequest.Titulo,
            Descripcion  = request.CursoCreateRequest.Descripcion,
            FechaPublicacion = request.CursoCreateRequest.FechaPublicacion
           };

           _context.Add(curso);
          await _context.SaveChangesAsync(cancellationToken);

          return curso.Id;

        }
    }

}

