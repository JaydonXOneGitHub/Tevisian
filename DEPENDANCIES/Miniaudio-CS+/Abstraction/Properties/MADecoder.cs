using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction;

public sealed unsafe partial class MADecoder : IMiniDisposable
{
    public ma_decoder* GetDecoder() => decoder;
}