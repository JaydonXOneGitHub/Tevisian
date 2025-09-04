using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public sealed unsafe partial class MADeviceConfig
    {
        public ma_format PlaybackFormat
        {
            get => config->playback.format;
            set => config->playback.format = value;
        }

        public uint PlaybackChannels
        {
            get => config->playback.channels;
            set => config->playback.channels = value;
        }

        public uint SampleRate
        {
            get => config->sampleRate;
            set => config->sampleRate = value;
        }

        public void* MyUserData
        {
            get => config->pUserData;
            set => config->pUserData = value;
        }

        public MADataCallback? DataCallback
        {
            get => callback;
            set
            {
                if (value == null)
                {
                    return;
                }

                callback = value;

                nint funcPtr = Marshal.GetFunctionPointerForDelegate(callback);

                config->dataCallback =
                (delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void>)funcPtr;
            }
        }
    }
}
