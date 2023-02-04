using API_task.Models;

namespace API_task.Services;
 public class TareaService : ITareaService{
    TareasContext context;

    public TareaService(TareasContext DBcontext) {
        context = DBcontext;
    }

    public IEnumerable<Tarea> Get(){
        return context.Tareas;
    }

    public async Task Save(Tarea tarea){
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Tarea tarea) {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null){
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;

            await context.SaveChangesAsync();
        }
    }
 }

public interface ITareaService {
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
}