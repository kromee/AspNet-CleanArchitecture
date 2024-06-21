using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hola mundo desde LinQ");
using  var context = new AppDbContex();


var cursonuevo = new Curso{
    Id=Guid.NewGuid(),
    Titulo = "C# 9",
    Descripcion = "Net core 9.0",
    FechaPublicacion = DateTime.Now
};

context.Add(cursonuevo);
await context.SaveChangesAsync();


var cursos =  await context.Cursos!.ToListAsync();


foreach (var curso in cursos){
    Console.WriteLine(curso.Titulo);
}