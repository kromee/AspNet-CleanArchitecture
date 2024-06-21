using AspNet_CleanArchitecture.Domain;
using Bogus;
using Microsoft.EntityFrameworkCore;



namespace AspNet_CleanArchitecture.Persistence;

public class AppDbContex  :  DbContext{

public DbSet<Curso>? Cursos { get; set; }
public DbSet<Instructor>?  Instructores { get; set; }

public DbSet<Precio>? Precios { get; set; }
public DbSet<Calificacion>? Calificaciones { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=LocalDatabase.db")
        .LogTo(Console.WriteLine,
        new [] {DbLoggerCategory.Database.Command.Name},
        Microsoft.Extensions.Logging.LogLevel.Information
        ).EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Curso>().ToTable("cursos");
        modelBuilder.Entity<Instructor>().ToTable("instructores");
        modelBuilder.Entity<CursoInstructor>().ToTable("curso_instructores");
        modelBuilder.Entity<Precio>().ToTable("precios");
        modelBuilder.Entity<CursoPrecio>().ToTable("cursos_precio");
        modelBuilder.Entity<Calificacion>().ToTable("calificaciones");
        modelBuilder.Entity<Photo>().ToTable("imagenes");

        modelBuilder.Entity<Precio>()
        .Property(b=>b.PrecioActual)
        .HasPrecision(10,2);

        modelBuilder.Entity<Precio>()
        .Property(b=>b.PrecioPromocion)
        .HasPrecision(10,2);

        modelBuilder.Entity<Precio>()
        .Property(b=>b.Nombre)
        .HasColumnType("VARCHAR")
        .HasMaxLength(250);


       modelBuilder.Entity<Curso>()
       .HasMany(b => b.Photos)
       .WithOne(b => b.Curso)
       .HasForeignKey(b=>b.CursoId)
       .IsRequired()
       .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Curso>()
        .HasMany(b => b.Calificaciones)
        .WithOne(b => b.Curso)
        .HasForeignKey(b=>b.CursoId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Curso>()
        .HasMany(b=>b.Precios)
        .WithMany(b=>b.Cursos)
        .UsingEntity<CursoPrecio>
        (
            j=>j
            .HasOne(b=>b.Precio)
            .WithMany (p=>p.CursoPrecios)
            .HasForeignKey (b=>b.PrecioId),
            j=>j
            .HasOne(p=>p.Curso)
            .WithMany(p=>p.CursoPrecios)
            .HasForeignKey(p=>p.CursoId),
            j=>
            {
                j.HasKey(t=>new {t.PrecioId, t.CursoId});

            }
        );


            modelBuilder.Entity<Curso>()
            .HasMany(m=>m.Instructores)
            .WithMany(m=>m.Cursos)
            .UsingEntity<CursoInstructor>(
                j=>j
                .HasOne(p=>p.Instructor)
                .WithMany(p=>p.CursoInstrutores)
                .HasForeignKey(p=>p.InstructorId),
                j=>j
                .HasOne(p=>p.Curso)
                .WithMany(p=>p.CursoInstructores)
                .HasForeignKey(p=>p.CursoId),
                j=>{
                    j.HasKey(t=>new {t.InstructorId, t.CursoId});
                }
            );



        modelBuilder.Entity<Curso>().HasData(DataMaster().Item1);
        modelBuilder.Entity<Precio>().HasData(DataMaster().Item2);
        modelBuilder.Entity<Instructor>().HasData(DataMaster().Item3);





    }

public Tuple<Curso[], Precio[], Instructor[]> DataMaster(){

var cursos = new List<Curso>();
var faker = new Faker();

for(int i = 1; i<10; i++)
{
    var cursoId = Guid.NewGuid();
    cursos.Add(new Curso{
        Id=cursoId,
        Descripcion = faker.Commerce.ProductDescription(),
        Titulo  = faker.Commerce.ProductName(),
        FechaPublicacion = DateTime.UtcNow
        
    });
}



    var precioId = Guid.NewGuid();
    var precio = new Precio{
        Id=precioId,
        PrecioActual = 10.0m,
        PrecioPromocion = 8.0m,
        Nombre = "Precio 1"
    };

    var precios = new List<Precio>{
        precio
    };

    var fakerIstructor = new Faker<Instructor>()
    .RuleFor(t=>t.Id, _=>Guid.NewGuid())
    .RuleFor(t=>t.Nombre, f=>f.Name.FirstName())
    .RuleFor(t=>t.Apellidos, f=>f.Name.LastName())
    .RuleFor(t=>t.Grado, f=>f.Name.JobTitle());

    var instructores =  fakerIstructor.Generate(10);


    
    return Tuple.Create(cursos.ToArray(),precios.ToArray(),instructores.ToArray());

}

}