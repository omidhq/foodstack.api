using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Foodstack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  [HttpGet(Name = "GetHelloWorld")]
  public string Get() => JsonSerializer.Serialize("Hello World");
}
