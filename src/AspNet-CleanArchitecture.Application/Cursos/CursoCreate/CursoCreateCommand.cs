// command
//commandhamdler

using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using FluentValidation;
using MediatR;

using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoCreate;

public class CursoCreateCommand{
    public record CursoCreateCommandRequest(CursoCreateRequest   cursoCreateRequest)
    : IRequest<Result<Guid>>, ICommandBase;
    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest,Result< Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IPhotoService _photoService;

        public CursoCreateCommandHandler(AppDbContext context, IPhotoService photoService){
            _context = context;
            _photoService = photoService;
        }
        public async Task<Result<Guid>> Handle  (CursoCreateCommandRequest request, CancellationToken cancellationToken )
            {
                var curso = new Curso{
                Id=Guid.NewGuid(),
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion  = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion
            };

                if(request.cursoCreateRequest.Foto is not null)
            {
                var photoUploadResult = 
                await _photoService.AddPhoto(request.cursoCreateRequest.Foto);

                var cursoId = Guid.NewGuid();
                var photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    Url = photoUploadResult.Url,
                    PublicId = photoUploadResult.PublicId,
                    CursoId = cursoId
                };

                curso.Photos = new List<Photo>{ photo};
            }


            if(request.cursoCreateRequest.InstructorId is not null)
            {
                var instructor =   _context.Instructores!
                .FirstOrDefault(x => x.Id == request.cursoCreateRequest.InstructorId);

                if(instructor is null)
                {
                    return Result<Guid>.Failure("No se encontró el instructor");
                }

                curso.Instructores = new List<Instructor> {instructor};
            }

            if(request.cursoCreateRequest.PrecioId is not null)    
            {
                var precio = await _context.Precios!
                .FirstOrDefaultAsync(x => x.Id == request.cursoCreateRequest.PrecioId);
                
                if(precio is null)
                {
                    return Result<Guid>.Failure("No se encontro el precio");
                }

                curso.Precios = new List<Precio> {precio};
            }
            _context.Add(curso);
            var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;
            return resultado 
                        ? Result<Guid>.Success(curso.Id)
                        : Result<Guid>.Failure("No se pudo insertar el curso");

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

