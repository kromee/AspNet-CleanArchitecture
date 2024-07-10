using AspNet_CleanArchitecture.Application.Calificaciones.GetCalificaciones;
using AspNet_CleanArchitecture.Application.Cursos.GetCurso;
using AspNet_CleanArchitecture.Application.Instructores.GetInstructores;
using AspNet_CleanArchitecture.Application.Photos.GetPhoto;
using AspNet_CleanArchitecture.Application.Precios.GetPrecios;
using AspNet_CleanArchitecture.Domain;
using AutoMapper;

namespace AspNet_CleanArchitecture.Application.Core;

public class MappingProfile : Profile{

    public MappingProfile(){
        CreateMap<Curso, CursoResponse>();
        CreateMap<Photo, PhotoResponse>();
        CreateMap<Precio, PrecioResponse>();

         CreateMap<Instructor, InstructorResponse>()
            .ForMember(dest=> dest.Apellido, src=>src.MapFrom(doc => doc.Apellidos));
        
        CreateMap<Calificacion, CalificacionResponse>()
            .ForMember(dest=> dest.NombreCurso, src=>src.MapFrom(doc => doc.Curso!.Titulo));

        

    }

}