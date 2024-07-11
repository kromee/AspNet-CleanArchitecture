// command
//commandhamdler

using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using FluentValidation;
using MediatR;

using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Application.Interfaces;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoCreate;

public class CursoCreateCommand{
    public record CursoCreateCommandRequest(CursoCreateRequest   cursoCreateRequest)
    : IRequest<Guid>;
    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Guid>
    {
        private readonly AppDbContext _context;
        private readonly IPhotoService _photoService;

        public CursoCreateCommandHandler(AppDbContext context, IPhotoService photoService){
            _context = context;
            _photoService = photoService;
        }
        public async Task<Guid> Handle  (CursoCreateCommandRequest request, CancellationToken cancellationToken )
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

