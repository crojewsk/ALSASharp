using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundPcmInfo
    {
        public IntPtr handle;

        public SoundPcmInfo()
        {
            handle = IntPtr.Zero;
        }

        public void SetDevice(uint dev)
        {
            SoundNativeMethods.SoundPcmInfoSetDevice(handle, dev);
        }

        public void SetSubdevice(uint subdev)
        {
            SoundNativeMethods.SoundPcmInfoSetSubdevice(handle, subdev);
        }

        public void SetStream(SoundPcmStreamType stream)
        {
            SoundNativeMethods.SoundPcmInfoSetStream(handle, stream);
        }

        public int Get(SoundControl ctl)
        {
            int err = SoundNativeMethods.SoundControlPcmInfo(ctl.handle, handle);
            return err;
        }

        public string GetId()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetId(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetName()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public uint GetSubdevicesCount()
        {
            return SoundNativeMethods.SoundPcmInfoGetSubdevicesCount(handle);
        }

        public uint GetSubdevicesAvail()
        {
            return SoundNativeMethods.SoundPcmInfoGetSubdevicesAvail(handle);
        }

        public string GetSubdeviceName()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetSubdeviceName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public int Allocate()
        {
            return SoundNativeMethods.SoundPcmInfoMalloc(out handle);
        }

        public void Deallocate()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmInfoFree(handle);
                handle = IntPtr.Zero;
            }
        }
    }

}
