using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction
{
    public sealed unsafe class MADevice : IMiniDisposable
    {
        private bool disposed;
        private bool initialized = false;

        private MADeviceConfig config;

        private ma_device* device;


        public MADevice(MADeviceConfig config)
        {
            device = Utils.Alloc<ma_device>();
            this.config = config;    
        }


        public bool IsDisposed() => disposed;


        public ma_result Start()
        {
            return MA.device_start(device);
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public ma_result Init()
        {
            if (initialized)
            {
                return ma_result.MA_DEVICE_ALREADY_INITIALIZED;
            }

            initialized = true;

            return MA.device_init(null, config.config, device);
        }

        public void Uninit()
        {
            if (!initialized)
            {
                return;
            }

            initialized = false;

            MA.device_uninit(device);
        }

        public void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (disposed)
            {
                return;
            }

            Uninit();

            NativeMemory.Free(device);

            disposed = true;
        }


        public ma_device* GetDevice() => device;
    }
}