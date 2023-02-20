
namespace ChatApp.Framework.Util;

using System.Reflection;
using System.Text.RegularExpressions;

public static class ReflectionTool
{
    public static List<Type> GetTypesFromNameSpace(string nameSpace = "")
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        return types.Where(t => t.Namespace != null && Regex.Match(t.Namespace, nameSpace).Success).ToList();
    }
}