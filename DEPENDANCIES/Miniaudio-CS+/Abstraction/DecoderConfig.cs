using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction;

public sealed unsafe partial class MADecoderConfig : IMiniDisposable
{
    private bool _disposed;

    internal ma_decoder_config* config;

    public MADecoderConfig()
    {
        config = Utils.Alloc<ma_decoder_config>();
    }

    public bool IsDisposed() => _disposed;

    public void Dispose()
    {
        if (!_disposed)
        {
            NativeMemory.Free(config);
            _disposed = true;
        }
    }
}