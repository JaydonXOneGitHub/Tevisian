using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public unsafe partial class MAEngine
    {
        internal ma_engine* engine;

        private bool disposed = false;

        public uint SampleRate => MA.engine_get_sample_rate(engine);
        
        public uint Channels => MA.engine_get_channels(engine);

        public ulong Time
        {
            get => MA.engine_get_time(engine);
            set => MA.engine_set_time(engine, value);
        }

        public ulong TimeInMS
        {
            get => MA.engine_get_time_in_milliseconds(engine);
            set => MA.engine_set_time_in_milliseconds(engine, value);
        }

        public ulong TimeInPCMFrames
        {
            get => MA.engine_get_time_in_pcm_frames(engine);
            set => MA.engine_set_time_in_pcm_frames(engine, value);
        }

        public float GainDB
        {
            get => MA.engine_get_gain_db(engine);
            set => MA.engine_set_gain_db(engine, value);
        }

        public float Volume
        {
            get => MA.engine_get_volume(engine);
            set => MA.engine_set_volume(engine, value);
        }

        public void* Endpoint => MA.engine_get_endpoint(engine);

        public uint ListenerCount => MA.engine_get_listener_count(engine);
    }
}
