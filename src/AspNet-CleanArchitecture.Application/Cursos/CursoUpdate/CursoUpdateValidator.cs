using FluentValidation;

namespace AspNet_CleanArchitecture.Application.Cursos.CursoUpdate;


public  class  CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>{

    public CursoUpdateValidator(){
        RuleFor(x => x.Titulo).NotEmpty().WithMessage("El titulo no debe ser vacío");
        
        RuleFor(x => x.Descripcion).NotEmpty()
        .WithMessage("La descripcion no debe esta vacía");
        
        RuleFor(x => x.FechaPublicacion).Must(ValidateDateTime)
        .WithMessage("Error en la fecha de publicación");

    }

    private bool ValidateDateTime(DateTime? date)
    {
        if (date == null) return false;
        if (date == default(DateTime))
            return false;
        return true;
    }



}