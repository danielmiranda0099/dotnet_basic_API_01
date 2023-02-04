using Microsoft.AspNetCore.Mvc;

namespace __platzi__dotnet_API_simple.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
    IHellowWorldService hellowWorldService;

    public HelloWorldController(IHellowWorldService hellowWorldService) {
        this.hellowWorldService = hellowWorldService;
    }

    [HttpGet]
    public IActionResult Get() {
        return Ok( hellowWorldService.GetHellowWorld() );
    }
}