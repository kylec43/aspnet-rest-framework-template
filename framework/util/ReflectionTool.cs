
namespace ChatApp.Framework.Util;

using System.Reflection;

public static class ReflectionTool
{
    public static List<Type> GetTypesFromNameSpace(string nameSpace = "")
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        return types.Where(t => t.Namespace == nameSpace).ToList();
    }
}