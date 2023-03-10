using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_task.Models;

public class Tarea {
    //[Key]//indica llave principal de la tabla
    public Guid TareaId {get; set;}

    //[ForeignKey("CategoriaId")]//Hacemos la relacion entre el modelo Categoria ----> Tarea (clave foranea)
    public Guid CategoriaId {get; set;} 

    //[Required]
    //[MaxLength(200)]
    public string Titulo {get; set;}

    public string Descripcion {get; set;}

    public Prioridad PrioridadTarea {get; set;}

    public DateTime FechaCreacion {get; set;}

    public virtual Categoria Categoria {get; set;}

    //[NotMapped]//esta propiedad sale de descripcion, por lo cual se calcula y genera en memoria, y no se manda a BD
    public string Resumen {get; set;}
}

public enum Prioridad {
    Baja,
    Media,
    Alta
}