using Microsoft.AspNetCore.Mvc;
using API_task;

namespace API_task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreateDBController : ControllerBase {

    TareasContext DBContext;

    public CreateDBController( TareasContext DB ) {
        DBContext = DB;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase() {
        DBContext.Database.EnsureCreated();
        return Ok();
    }
}