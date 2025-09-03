using System.Diagnostics.CodeAnalysis;
using MoonSharp.Interpreter;

namespace Tev.Services.Lua;

public sealed class LuaProviderService : TevisianService
{
    private readonly Script script;

    public LuaProviderService()
    {
        script = new Script();
    }
}