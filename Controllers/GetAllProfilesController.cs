namespace chatRestApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ChatApp.Framework.DataAccess;
using ChatApp.Database.Models;

[ApiController]
[Route("[controller]")]
public class GetAllProfilesController : ControllerBase
{
    private readonly ILogger<GetAllProfilesController> _logger;

    public GetAllProfilesController(ILogger<GetAllProfilesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllProfiles")]
    public IEnumerable<Profile> Get()
    {
        EntityProviderFactory providerFactory = new EntityProviderFactory();
        return providerFactory.Build<Profile>().GetAll().ToList();
    }
}