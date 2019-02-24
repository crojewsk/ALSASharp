using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControl
    {
        public IntPtr handle;

        public SoundControl()
        {
            handle = IntPtr.Zero;
        }

        public int Open(string name, int mode)
        {
            return SoundNativeMethods.SoundControlOpen(out handle, name, mode);
        }

        public int Close()
        {
            int err = 0;
            if (handle != IntPtr.Zero)
            {
                err = SoundNativeMethods.SoundControlClose(handle);
                handle = IntPtr.Zero;
            }
         
            return err;
        }      
    }

    public class SoundControlPcmCollection
    {
        public int Next(SoundControl ctl, out int dev)
        {
            return SoundNativeMethods.SoundControlPcmNextDevice(ctl.handle, out dev);
        }
    }
}
