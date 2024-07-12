using FluentValidation;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoUpdate;


public  class  CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>{

    public CursoUpdateValidator(){
        RuleFor(x => x.Titulo).NotEmpty().WithMessage("El titulo no debe ser vacio");
        
        RuleFor(x => x.Descripcion).NotEmpty()
        .WithMessage("La descripcion no debe esta vacia");
        
        RuleFor(x => x.FechaPublicacion).NotEmpty()
        .WithMessage("La Fecha de publicacion no debe ser vacia");

    }


}