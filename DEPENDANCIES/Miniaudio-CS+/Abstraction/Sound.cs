using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public sealed unsafe class MASound : IDisposable
    {
        private bool disposed = false;

        private bool initialized = false;

        private ma_sound* sound;

        internal MASound()
        {
            sound = Utils.Alloc<ma_sound>();
        }

        internal MASound(string soundFilePath, MAEngine engine, MASound? soundGroup = null)
        {
            sound = Utils.Alloc<ma_sound>();

            sbyte* ansiSoundFilePath = null;

            byte[] ansiBytes = Encoding.Default.GetBytes(soundFilePath + '\0');

            fixed (byte* ptr = ansiBytes)
            {
                ansiSoundFilePath = (sbyte*)ptr;
            }

            ma_sound* sound_group;

            if (soundGroup == null)
            {
                sound_group = null;
            }
            else
            {
                sound_group = soundGroup.sound;
            }

            MA.sound_init_from_file(
                engine.engine,
                ansiSoundFilePath, 0,
                sound_group, null, sound);

            initialized = true;
        }

        public float Pitch
        {
            get => MA.sound_get_pitch(sound);
            set => MA.sound_set_pitch(sound, value);
        }

        public float Volume
        {
            get => MA.sound_get_volume(sound);
            set => MA.sound_set_volume(sound, value);
        }

        public void Play() => MA.sound_start(sound);

        public void Pause() => MA.sound_stop(sound);

        public void Stop()
        {
            Pause();
            Seek(0.00f);
        }

        public bool IsPlaying() => MA.sound_is_playing(sound) != 0;

        public void Seek(float secondValue)
            => MA.sound_seek_to_second(sound, secondValue);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public bool IsDisposed() => disposed;

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Stop();

                if (initialized)
                {
                    MA.sound_uninit(sound);
                }

                NativeMemory.Free(sound);

                disposed = true;
            }
        }

        public ma_sound* GetSound() => sound;

        public static MASound CreateGroup() => new();
    }
}
