// clase valida el conrenido del request
using FluentValidation;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoCreate;

public class CursoCreateValidator: AbstractValidator<CursoCreateRequest>{
    public CursoCreateValidator(){
        RuleFor(x=>x.Titulo).NotEmpty().WithMessage("El título es requerido");
        RuleFor(x=>x.Descripcion).NotEmpty().WithMessage("La descripción es requerida");;
        
    }
}
