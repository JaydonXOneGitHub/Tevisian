using System;
using System.Diagnostics;
using Tev.Core;

namespace Tev.Services;

public sealed class ProcessService : TevisianService
{
    private Process? currentProcess;

    private void ProcessReset()
    {
        // Console.WriteLine("Exited process:");
        // Console.WriteLine(currentProcess.ProcessName);
        currentProcess = null;
    }

    private void OnNavigationDone(NavControl navControl)
    {
        Console.WriteLine($"Got NavControl.{navControl}");

        if (navControl == NavControl.Home)
        {
            Console.WriteLine("Kill Process thanks to home button!");
            KillProcess();
        }
    }

    public override void Initialize()
    {
        var navigator = Tevisian.Get()!.GetServiceManager().GetService<NavigatorService>();

        navigator!.OnNavigationDone += OnNavigationDone;
    }

    public override void Shutdown()
    {
        var navigator = Tevisian.Get()!.GetServiceManager().GetService<NavigatorService>();

        navigator!.OnNavigationDone -= OnNavigationDone;
    }

    private void ResetEH(object? o, EventArgs e)
    {
        ProcessReset();
    }

    public void StartProcess(string appPath, string arguments = "")
    {
        if (currentProcess == null)
        {
            currentProcess = Process.Start(appPath, arguments);

            currentProcess.Exited += ResetEH;
            currentProcess.Disposed += ResetEH;
        }
        else
        {
            // Add code to display a pop-up
        }
    }

    public void StartProcess(ProcessStartInfo psi)
    {
        if (currentProcess == null)
        {
            currentProcess = Process.Start(psi);

            currentProcess!.Exited += ResetEH;
            currentProcess!.Disposed += ResetEH;
        }
        else
        {
            // Add code to display a pop-up
        }
    }

    public Process? GetProcess() => currentProcess;

    public void KillProcess()
    {
        currentProcess?.Kill();
        Reset();
    }
}