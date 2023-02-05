using API_task.Models;
using API_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase {
    
    ITareaService tareaService;

    public TareaController(ITareaService service) {
        tareaService = service;
    }

    [HttpGet]
    public ActionResult Get() {
        return Ok( tareaService.Get() );
    }

    [HttpPost]
    public ActionResult Post( Tarea tarea) {
        tareaService.Save( tarea );
        return Ok();
    }

    [HttpPut]
    public ActionResult Put( Guid id, Tarea tarea ) {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete( Guid id ) {
        tareaService.Delete(id);
        return Ok();
    }
}