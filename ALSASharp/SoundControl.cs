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

    public class SoundControlCardInfo
    {
        IntPtr handle;

        public SoundControlCardInfo()
        {
            handle = IntPtr.Zero;
        }

        public int Get(SoundControl ctl)
        {
            int err = SoundNativeMethods.SoundControlCardInfo(ctl.handle, handle);
            return err;
        }

        public int Allocate()
        {
            return SoundNativeMethods.SoundControlCardInfoMalloc(out handle);
        }

        public void Deallocate()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlCardInfoFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public string GetId()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetId(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetName()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetName(handle);
            return Marshal.PtrToStringAnsi(ptr);
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
