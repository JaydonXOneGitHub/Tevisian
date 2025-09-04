using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction;

public sealed unsafe partial class MADecoder : IMiniDisposable
{
    private bool _disposed = false;

    private bool initialized = false;

    private ma_decoder* decoder;
    private ma_decoder_config* config;

    public MADecoder()
    {
        config = null;
        decoder = Utils.Alloc<ma_decoder>();
    }

    public MADecoder(MADecoderConfig config)
    {
        this.config = config.config;
        decoder = Utils.Alloc<ma_decoder>();
    }

    public bool IsDisposed() => _disposed;

    public void ReadPCMFrames(void* pOutput, uint frameCount)
    {
        MA.decoder_read_pcm_frames(decoder, pOutput, frameCount, null);
    }

    public void InitFile(sbyte* file)
    {
        if (initialized)
        {
            return;
        }

        ma_result res = MA.decoder_init_file(file, config, decoder);

        if (res != ma_result.MA_SUCCESS)
        {
            throw new Exception($"MADecoder file init failed: {res}");
        }

        initialized = true;
    }

    public void Uninit()
    {
        if (!initialized)
        {
            return;
        }

        MA.decoder_uninit(decoder);

        initialized = false;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Uninit();

            NativeMemory.Free(decoder);

            _disposed = true;
        }
    }
}