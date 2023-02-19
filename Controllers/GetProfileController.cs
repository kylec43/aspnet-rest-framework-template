namespace chatRestApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ChatApp.Framework.DataAccess;
using ChatApp.Database.Models;

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