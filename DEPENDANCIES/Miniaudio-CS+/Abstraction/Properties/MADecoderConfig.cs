using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction;

public sealed unsafe partial class MADecoderConfig : IMiniDisposable
{
    public ma_format Format
    {
        get => config->format;
        set => config->format = value;
    }

    public uint Channels
    {
        get => config->channels;
        set => config->channels = value;
    }

    public uint SampleRate
    {
        get => config->sampleRate;
        set => config->sampleRate = value;
    }

    public byte* PChannelMap
    {
        get => config->pChannelMap;
        set => config->pChannelMap = value;
    }

    public ma_channel_mix_mode ChannelMixMode
    {
        get => config->channelMixMode;
        set => config->channelMixMode = value;
    }

    public ma_dither_mode DitherMode
    {
        get => config->ditherMode;
        set => config->ditherMode = value;
    }

    public ma_resampler_config Resampling
    {
        get => config->resampling;
        set => config->resampling = value;
    }

    public ma_allocation_callbacks AllocationCallbacks
    {
        get => config->allocationCallbacks;
        set => config->allocationCallbacks = value;
    }

    public ma_encoding_format EncodingFormat
    {
        get => config->encodingFormat;
    }

    public uint SeekPointCount
    {
        get => config->seekPointCount;
        set => config->seekPointCount = value;
    }

    public ma_decoding_backend_vtable** PPCustomBackendVTables
    {
        get => config->ppCustomBackendVTables;
        set => config->ppCustomBackendVTables = value;
    }

    public uint CustomBackendCount
    {
        get => config->customBackendCount;
        set => config->customBackendCount = value;
    }

    public void* PCustomBackendUserData
    {
        get => config->pCustomBackendUserData;
        set => config->pCustomBackendUserData = value;
    }
}