using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public sealed unsafe partial class MADeviceConfig : IMiniDisposable
    {
        internal ma_device_config* config;

        private bool disposed;

        private MADataCallback? callback = null;

        public MADeviceConfig()
        {
            config = Utils.Alloc<ma_device_config>();
        }
        
        public bool IsDisposed() => disposed;

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
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

            NativeMemory.Free(config);

            disposed = true;
        }

        public ma_device_config* GetConfig() => config;
    }
}
