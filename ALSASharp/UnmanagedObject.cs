using System;

namespace ALSASharp
{
    public abstract class UnmanagedObject : IDisposable
    {
        internal IntPtr handle;

        public abstract void Dispose();
    }
}
