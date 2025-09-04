using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaudio.Abstraction
{
    public interface IMiniDisposable : IDisposable
    {
        bool IsDisposed();
    }
}
