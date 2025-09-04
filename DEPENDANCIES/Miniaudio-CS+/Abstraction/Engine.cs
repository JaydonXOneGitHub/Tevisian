using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public sealed unsafe partial class MAEngine : IMiniDisposable
    {
        private bool initialized = false;

        private MAEngineConfig? config;

        public MAEngine(MAEngineConfig? config)
        : this()
        {
            this.config = config;
        }

        public MAEngine()
        {
            engine = Utils.Alloc<ma_engine>();
        }

        public void Init()
        {
            if (initialized)
            {
                return;
            }

            ma_result result;

            if (config == null)
            {
                result = MA.engine_init(null, engine);
            }
            else
            {
                result = MA.engine_init(config.config, engine);
            }

            if (result != ma_result.MA_SUCCESS)
            {
                throw new Exception($"Engine init failed: {result}");
            }

            initialized = true;
        }

        public void Uninit()
        {
            if (!initialized)
            {
                return;
            }

            initialized = false;

            MA.engine_uninit(engine);
        }

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
                Uninit();
                
                NativeMemory.Free(engine);

                disposed = true;
            }
        }

        public MASound MakeSound(string soundFilePath)
            => new(soundFilePath, this);

        public ma_log* GetLog() => MA.engine_get_log(engine);

        public ma_resource_manager* GetResourceManager()
            => MA.engine_get_resource_manager(engine);

        public ma_engine* GetEngine() => engine;
    }
}
