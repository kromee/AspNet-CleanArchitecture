using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoUpdate;


public class CursoUpdateCommand(){
    public record CursoUpdateCommandRequest (CursoUpdateRequest CursoUpdateRequest,  Guid? CursoId): 
    IRequest<Result<Guid>>, ICommandBase;


    internal class CursoUpdateCommandHandler : IRequestHandler<CursoUpdateCommandRequest, Result<Guid>>
    {
        private readonly AppDbContext _dbContext;
        public CursoUpdateCommandHandler(AppDbContext dbContext){
            _dbContext = dbContext;
        }
      public async Task<Result<Guid>> Handle(CursoUpdateCommandRequest request, CancellationToken cancellationToken)
        {
                   var cursoId = request.CursoId;

            var curso = await _dbContext.Cursos!
            .FirstOrDefaultAsync(x => x.Id == cursoId);
            
            if (curso is null)
            {
                return Result<Guid>.Failure("El curso no existe");
            }

            curso.Descripcion = request.CursoUpdateRequest.Descripcion;
            curso.Titulo = request.CursoUpdateRequest.Titulo;
            curso.FechaPublicacion = request.CursoUpdateRequest.FechaPublicacion;

            _dbContext.Entry(curso).State = EntityState.Modified;
            var resultado = await _dbContext.SaveChangesAsync() > 0;

            return resultado 
                        ? Result<Guid>.Success(curso.Id)
                        : Result<Guid>.Failure("Errores en el update del curso");

        }
        
    }
      

        public class CursoUpdateCommandRequestValidator: AbstractValidator<CursoUpdateCommandRequest>{
            public CursoUpdateCommandRequestValidator(){
                RuleFor(x => x.CursoUpdateRequest).SetValidator(new CursoUpdateValidator());
                RuleFor(x => x.CursoId).NotNull();
            }
        }


}
