
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoDelete;


public class CursoDeleteCommand{
    public record CursoDeleteCommandRequest (Guid? CursoId): IRequest<Result<Unit>>, ICommandBase;

    internal class CursoDeleteCommandHandler : IRequestHandler<CursoDeleteCommandRequest, Result<Unit>>
    {
        private readonly AppDbContext _context;

        public CursoDeleteCommandHandler (AppDbContext context)
        {
            _context = context;

        }
        public async Task<Result<Unit>> Handle(CursoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
         var curso = await _context.Cursos!
            .Include(x => x.Instructores)
            .Include(x => x.Precios)
            .Include(x => x.Calificaciones)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Id == request.CursoId);

            if (curso is null)
            {
                return Result<Unit>.Failure("El curso no existe");
            }

            _context.Cursos!.Remove(curso);

            var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

            return resultado 
                            ? Result<Unit>.Success(Unit.Value) 
                            : Result<Unit>.Failure("Error en la transaccion");
        }
    }


    public class CursoDeleteCommandRequestValidator : AbstractValidator<CursoDeleteCommandRequest>
    {
        public CursoDeleteCommandRequestValidator()
            {
                RuleFor(x => x.CursoId).NotNull().WithMessage("No tiene curso id");
            }
    }


}