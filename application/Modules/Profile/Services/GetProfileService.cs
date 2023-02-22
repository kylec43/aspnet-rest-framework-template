namespace ChatApp.Profile.Services;

using ChatApp.Framework.DataAccess;
using ChatApp.Database.Models;
using ChatApp.Framework.Interfaces;

public class GetProfileService : IService
{
    private readonly EntityProvider<Profile> profileProvider;
    private readonly ProviderFactory providerFactory;

    public GetProfileService(ProviderFactory providerFactory)
    {
        this.providerFactory = providerFactory;
        this.profileProvider = providerFactory.Build<Profile>();
    }

    public Profile? GetProfileById(int id)
    {
        return this.profileProvider.Get(profile => profile.Id == id);
    }

    public IEnumerable<Profile> GetAllProfiles()
    {
        return this.profileProvider.GetAll().ToList();
    }
}