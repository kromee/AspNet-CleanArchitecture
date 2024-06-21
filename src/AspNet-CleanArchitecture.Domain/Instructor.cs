namespace AspNet_CleanArchitecture.Domain;


public class Instructor : BaseEntity{

public string? Apellidos {get;set;}
public string? Nombre {get;set;}
public string? Grado {get;set;}

public ICollection<Curso>? Cursos {get;set;}
public ICollection<CursoInstructor>? CursoInstrutores {get;set;} //


}
