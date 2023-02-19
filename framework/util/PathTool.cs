namespace ChatApp.Framework.Util;

public static class PathTool
{
    public static string GetModelsDirectory()
    {
        return Path.Join(Directory.GetCurrentDirectory(), "/Models");
    }

}