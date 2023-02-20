namespace ChatApp.Profile.Controllers;

using Microsoft.AspNetCore.Mvc;
using ChatApp.Framework.DataAccess;
using ChatApp.Database.Models;
using ChatApp.Framework.Input;
using ChatApp.Profile.Inputs;
using ChatApp.Profile.Services;

[ApiController]
[Route("api/profile")]
public class GetProfileController : ControllerBase
{
    private readonly ILogger<GetProfileController> _logger;
    private readonly IValidationMediator _validator;
    private readonly GetProfileService getProfileService;

    public GetProfileController(ILogger<GetProfileController> logger, IValidationMediator validator)
    {
        _logger = logger;
        _validator = validator;
        getProfileService = new GetProfileService();
    }

    [HttpGet("{id}")]
    public ActionResult<Profile?> GetProfile([FromRoute] ProfileIdInput input)
    {
        var validationResult = _validator.Validate<ProfileIdInput>(input);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        return Ok(getProfileService.GetProfileById(input.id));
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Profile>> Get()
    {
        return Ok(getProfileService.GetAllProfiles());
    }
}