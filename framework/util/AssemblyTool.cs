using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace ChatApp.Framework.Util;

public static class AssemblyTool
{
    public static CSharpCompilation CompileCode(string code)
    {
        return CSharpCompilation.Create(
            Path.GetRandomFileName(),
            new[] { CSharpSyntaxTree.ParseText(code) },
            new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );
    }
}