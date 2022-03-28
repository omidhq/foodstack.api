using Microsoft.AspNetCore.Mvc;

namespace Foodstack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet(Name = "GetHelloWorld")]
    public string Get() =>"Hello World";
}
