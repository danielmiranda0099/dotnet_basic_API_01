using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_task.Models;

/*
NOTA: FLUENT API predomina sobre Data Anotation (fluent api siobre escribe la configuracion por Atributos)
*/
public class Categoria {
    //[Key]//indica llave principal de la tabla
    public Guid CategoriaId {get; set;}

    //[Required]
    //[MaxLength(150)]
    public string Nombre {get; set;}

    public string Descripcion {get; set;}

    public int Peso {get; set;}

    [JsonIgnore]
    public virtual ICollection<Tarea> ? Tareas {get; set;}
}   