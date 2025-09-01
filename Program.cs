using Tev.Core;
using Tev.Services;
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
            tv.Run();
        }
    }
}