using System;
using System.Diagnostics;

namespace Tev.Services;

public sealed class ProcessService : TevisianService
{
    private Process currentProcess;

    private void Reset()
    {
        // Console.WriteLine("Exited process:");
        // Console.WriteLine(currentProcess.ProcessName);
        currentProcess = null;
    }

    private void ResetEH(object o, EventArgs e)
    {
        Reset();
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

    public Process GetProcess() => currentProcess;

    public void KillProcess()
    {
        currentProcess?.Kill();
        Reset();
    }
}