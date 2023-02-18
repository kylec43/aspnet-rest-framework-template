using Microsoft.AspNetCore.Mvc;
using ChatApp.DataAccess;
using ChatApp.Database.Models;

namespace chatRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetProfileController : ControllerBase
{
    private readonly ILogger<GetProfileController> _logger;

    public GetProfileController(ILogger<GetProfileController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProfiles")]
    public IEnumerable<Profile> Get()
    {
        EntityProviderFactory providerFactory = new EntityProviderFactory();
        return providerFactory.Build<Profile>().GetEntities().ToArray();
    }
}