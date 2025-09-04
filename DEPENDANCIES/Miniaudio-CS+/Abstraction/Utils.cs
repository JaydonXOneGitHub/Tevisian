using System.Runtime.InteropServices;

namespace Miniaudio.Abstraction;

internal static unsafe class Utils
{
    public static T* Alloc<T>() where T : unmanaged
    {
        return (T*)NativeMemory.Alloc((nuint)sizeof(T));
    }
}