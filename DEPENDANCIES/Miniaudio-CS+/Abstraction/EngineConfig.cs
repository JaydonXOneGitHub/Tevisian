namespace Miniaudio.Abstraction;

public sealed unsafe partial class MAEngineConfig : IMiniDisposable
{
    private bool disposed;
    internal ma_engine_config* config;

    public MAEngineConfig()
    {
        config = Utils.Alloc<ma_engine_config>();
    }

    public bool IsDisposed() => disposed;

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        disposed = true;
    }
}