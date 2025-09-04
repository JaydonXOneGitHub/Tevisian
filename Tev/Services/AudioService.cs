using Miniaudio.Abstraction;

namespace Tev.Services;

public sealed class AudioService : TevisianService
{
    private readonly MAEngine audioEngine;
    private readonly MAEngineConfig audioEngineConfig;

    public AudioService()
    {
        audioEngine = new MAEngine();
    }

    public override void Initialize()
    {
        audioEngine.Init();
    }

    public override void Shutdown()
    {
        audioEngine.Dispose();
    }
}