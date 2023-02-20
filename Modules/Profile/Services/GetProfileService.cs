namespace ChatApp.Profile.Services;

using ChatApp.Framework.DataAccess;
using ChatApp.Database.Models;

public class GetProfileService
{
    private readonly EntityProvider<Profile> profileProvider;
    private readonly ProviderFactory providerFactory;

    public GetProfileService()
    {
        ProviderFactory providerFactory = new ProviderFactory();
        providerFactory = new ProviderFactory();
        profileProvider = providerFactory.Build<Profile>();
    }

    public Profile? GetProfileById(int id)
    {
        return this.profileProvider.Get(profile => profile.id == id);
    }

    public IEnumerable<Profile> GetAllProfiles()
    {
        return this.profileProvider.GetAll().ToList();
    }
}