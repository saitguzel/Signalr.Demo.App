using Microsoft.AspNetCore.Mvc;

namespace Signalr.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ChatController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMessage()
    {
        return Ok("selam");
    }
}