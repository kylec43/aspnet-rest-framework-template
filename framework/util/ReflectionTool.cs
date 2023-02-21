
namespace ChatApp.Framework.Util;

using System.Reflection;
using System.Text.RegularExpressions;

public static class ReflectionTool
{
    private static List<Type> GetAssemblyTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes().ToList();
    }

    public static List<Type> GetTypesFromNameSpace(string nameSpace = "")
    {
        var types = ReflectionTool.GetAssemblyTypes();
        return types.Where(t => t.Namespace != null && Regex.Match(t.Namespace, nameSpace).Success).ToList();
    }

    public static List<Type> GetTypesImplementingInterface(Type interfaceType)
    {
        var types = ReflectionTool.GetAssemblyTypes();
        return types.Where(t => t.GetInterface(interfaceType.Name) != null).ToList();
    }

    public static List<Type> GetTypesImplementingGenericType(Type genericType)
    {
        // Get the types in the assembly
        var types = ReflectionTool.GetAssemblyTypes();

        if (types == null)
        {
            return new List<Type>();
        }

        // Get all types in the assembly that implement the generic type
        return types.Where(t => 
            t.BaseType != null && 
            t.BaseType.IsGenericType &&
            t.BaseType.GetGenericTypeDefinition() == genericType
        ).ToList();
    }
}