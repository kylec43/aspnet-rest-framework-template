namespace ChatApp.Profile.Controllers;

using Microsoft.AspNetCore.Mvc;
using ChatApp.Profile.Inputs;
using ChatApp.Profile.Services;
using ChatApp.Database.Models;

[ApiController]
[Route("api/profile")]
public class GetProfileController : ControllerBase
{
    private readonly ILogger<GetProfileController> _logger;
    private readonly GetProfileService getProfileService;

    public GetProfileController(ILogger<GetProfileController> logger, GetProfileService getProfileService)
    {
        _logger = logger;
        this.getProfileService = getProfileService;
    }

    [HttpGet("{id}")]
    public IActionResult GetProfile([FromRoute] ProfileIdInput input)
    {
        Profile? result = this.getProfileService.GetProfileById(input.id);
        if (result == null)
        {
            return BadRequest("Unable to get profile");
        }

        return Ok(result);
    }

    [HttpGet("all")]
    public IActionResult Get()
    {
        return Ok(this.getProfileService.GetAllProfiles());
    }
}