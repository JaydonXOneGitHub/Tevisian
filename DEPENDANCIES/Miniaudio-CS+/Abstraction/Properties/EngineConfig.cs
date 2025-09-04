namespace Miniaudio.Abstraction;

public sealed unsafe partial class MAEngineConfig
{
    public ma_resource_manager* PResourceManager
    {
        get => config->pResourceManager;
        set => config->pResourceManager = value;
    }

    public ma_context* PContext
    {
        get => config->pContext;
        set => config->pContext = value;
    }

    public ma_device* PDevice
    {
        get => config->pDevice;
        set => config->pDevice = value;
    }

    public ma_device_id* PPlaybackDeviceID
    {
        get => config->pPlaybackDeviceID;
        set => config->pPlaybackDeviceID = value;
    }

    public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> DataCallback
    {
        get => config->dataCallback;
        set => config->dataCallback = value;
    }

    public delegate* unmanaged[Cdecl]<ma_device_notification*, void> NotificationCallback
    {
        get => config->notificationCallback;
        set => config->notificationCallback = value;
    }

    public ma_log* PLog
    {
        get => config->pLog;
        set => config->pLog = value;
    }

    public uint ListenerCount
    {
        get => config->listenerCount;
        set => config->listenerCount = value;
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

    public uint PeriodSizeInFrames
    {
        get => config->periodSizeInFrames;
        set => config->periodSizeInFrames = value;
    }

    public uint PeriodSizeInMilliseconds
    {
        get => config->periodSizeInMilliseconds;
        set => config->periodSizeInMilliseconds = value;
    }

    public uint GainSmoothTimeInFrames
    {
        get => config->gainSmoothTimeInFrames;
        set => config->gainSmoothTimeInFrames = value;
    }

    public uint GainSmoothTimeInMilliseconds
    {
        get => config->gainSmoothTimeInMilliseconds;
        set => config->gainSmoothTimeInMilliseconds = value;
    }

    public uint DefaultVolumeSmoothTimeInPCMFrames
    {
        get => config->defaultVolumeSmoothTimeInPCMFrames;
        set => config->defaultVolumeSmoothTimeInPCMFrames = value;
    }

    public uint PreMixStackSizeInBytes
    {
        get => config->preMixStackSizeInBytes;
        set => config->preMixStackSizeInBytes = value;
    }

    public ma_allocation_callbacks AllocationCallbacks
    {
        get => config->allocationCallbacks;
        set => config->allocationCallbacks = value;
    }

    public uint NoAutoStart
    {
        get => config->noAutoStart;
        set => config->noAutoStart = value;
    }

    public uint NoDevice
    {
        get => config->noDevice;
        set => config->noDevice = value;
    }

    public ma_mono_expansion_mode MonoExpansionMode
    {
        get => config->monoExpansionMode;
        set => config->monoExpansionMode = value;
    }

    public void* PResourceManagerVFS
    {
        get => config->pResourceManagerVFS;
        set => config->pResourceManagerVFS = value;
    }

    public delegate* unmanaged[Cdecl]<void*, float*, ulong, void> OnProcess
    {
        get => config->onProcess;
        set => config->onProcess = value;
    }

    public void* PProcessUserData
    {
        get => config->pProcessUserData;
        set => config->pProcessUserData = value;
    }
}