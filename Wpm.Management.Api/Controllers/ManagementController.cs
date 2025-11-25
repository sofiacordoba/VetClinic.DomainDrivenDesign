using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService _applicationService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreatePetCommand command)
    {
        await _applicationService.Handle(command);
        return Ok();
    }
}
