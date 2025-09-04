using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void MADataCallback(ma_device* pDevice, void* pOutput, void* pInput, uint frameCount);
}
