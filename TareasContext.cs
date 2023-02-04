using Microsoft.EntityFrameworkCore;
using API.Models;

namespace proyectoef;

/****   se genera las tablas y sus relaciones de acurdo a los modelos y se
        cargan en memoria ******/
public class TareasContext: DbContext {
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Tarea> Tareas {get; set;}

    //Construstor()
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

    //FLUEN API
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add( new Categoria() { CategoriaId = Guid.Parse("1683bb23-0234-43cf-b1cb-3337a021b49e"),
                                                Nombre = "Actividad Pendiente",
                                                Peso = 20
        });

        categoriasInit.Add( new Categoria() { CategoriaId = Guid.Parse("1683bb23-0234-43cf-b1cb-3337a027350f"),
                                                Nombre = "Actividad Personales",
                                                Peso = 50
        });

        /**************************************************************************************************************/

        modelBuilder.Entity<Categoria>( categoria => {
            categoria.ToTable("Categoria");

            categoria.HasKey( p => p.CategoriaId);

            categoria.Property( p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property( p => p.Descripcion).IsRequired(false);
            categoria.Property( p => p.Peso);

            //categoria.Property( p => p.Tareas); //HERE NO!! se debe usar en el modelo TAREA como una referencia

            //Guardar los primeros DATOS en la TABLA
            categoria.HasData(categoriasInit);
        });

        /**************************************************************************************************************/

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add( new Tarea() { TareaId = Guid.Parse("1683bb23-0234-43cf-bdfb-3337a0123456"),
                                        CategoriaId = Guid.Parse("1683bb23-0234-43cf-b1cb-3337a021b49e"),
                                        PrioridadTarea = Prioridad.Media,
                                        Titulo = "Pago de Servicios Publicos",
                                        FechaCreacion = DateTime.Now
        });

        tareasInit.Add( new Tarea() { TareaId = Guid.Parse("c3d4c5b0-6803-4c61-9d0e-f25cba751492"),
                                        CategoriaId = Guid.Parse("1683bb23-0234-43cf-b1cb-3337a027350f"),
                                        PrioridadTarea = Prioridad.Baja,
                                        Titulo = "Terminar Pelicual Netflix",
                                        FechaCreacion = DateTime.Now
        });

        modelBuilder.Entity<Tarea>( tarea => {
            tarea.ToTable("Tarea");

            tarea.HasKey( p => p.TareaId);

            tarea.Property( p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property( p => p.Descripcion).IsRequired(false);
            tarea.Property( p => p.PrioridadTarea);
            tarea.Property( p => p.FechaCreacion);

            //configuracion de relacion 1:N
            tarea.HasOne( p => p.Categoria).WithMany( p => p.Tareas).HasForeignKey( p => p.CategoriaId);

            tarea.Ignore( p => p.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}