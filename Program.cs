using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Serialization;
using Tev.Core;
using Tev.Services;
using Tev.Services.Lua;
using Tev.UI;

public static class Program
{
    public static void Main()
    {
        using (var tv = new Tevisian())
        {
            var sm = tv.GetServiceManager();

            sm.Register<InputService>();
            sm.Register<UITreeService>();
            sm.Register<TheatreRenderer>();
            sm.Register<ProcessService>();
            sm.Register<LuaProviderService>();
            sm.Register<NavigatorService>();
            
            tv.Run();
        }
    }
}