using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundConfig
    {
        internal IntPtr handle;
    }

    public class SoundPcm : IDisposable
    {
        internal IntPtr handle;

        public SoundPcm()
        {
            handle = IntPtr.Zero;
        }

        public int Open(string name, SoundPcmStream stream, SoundPcmOpenMode mode)
        {
            return SoundNativeMethods.SoundPcmOpen(out handle, name, stream, mode);
        }

        public int OpenLconf(string name, SoundPcmStream stream, SoundPcmOpenMode mode, SoundConfig lconf)
        {
            return SoundNativeMethods.SoundPcmOpenLconf(out handle, name, stream, mode, lconf.handle);
        }

        public int OpenFallback(SoundConfig root, string name, string origName, SoundPcmStream stream, SoundPcmOpenMode mode)
        {
            return SoundNativeMethods.SoundPcmOpenFallback(out handle, root.handle, name, origName, stream, mode);
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmClose(handle);
                handle = IntPtr.Zero;
            }
        }

        public string Name
        {
            get
            {
                IntPtr ptr = SoundNativeMethods.SoundPcmName(handle);
                return Marshal.PtrToStringAnsi(ptr);
            }
        }

        public SoundPcmType Type
        {
            get
            {
                return SoundNativeMethods.SoundPcmType(handle);
            }
        }

        public SoundPcmStream GetStream()
        {
            return SoundNativeMethods.SoundPcmStream(handle);
        }

        public int SetNonBlock(int nonblock)
        {
            return SoundNativeMethods.SoundPcmNonblock(handle, nonblock);
        }

        public int GetInfo(out SoundPcmInfo info)
        {
            IntPtr ptr = IntPtr.Zero;
            int ret = SoundNativeMethods.SoundPcmInfo(handle, ptr);
            info = new SoundPcmInfo(ptr);
            return ret;
        }

        public int GetHwParams(out SoundPcmHwParams hwParams)
        {
            IntPtr ptr = IntPtr.Zero;
            int ret = SoundNativeMethods.SoundPcmHwParamsCurrent(handle, ptr);
            hwParams = new SoundPcmHwParams(ptr);
            return ret;
        }

        public int SetHwParams(SoundPcmHwParams hwParams)
        {
            return SoundNativeMethods.SoundPcmHwParams(handle, hwParams.handle);
        }

        public int FreeHw()
        {
            return SoundNativeMethods.SoundPcmHwFree(handle);
        }

        public int GetSwParams(out SoundPcmSwParams swParams)
        {
            IntPtr ptr = IntPtr.Zero;
            int ret = SoundNativeMethods.SoundPcmSwParamsCurrent(handle, ptr);
            swParams = new SoundPcmSwParams(ptr);
            return ret;
        }

        public int SetSwParams(SoundPcmSwParams swParams)
        {
            return SoundNativeMethods.SoundPcmSwParams(handle, swParams.handle);
        }

        public int Prepare()
        {
            return SoundNativeMethods.SoundPcmPrepare(handle);
        }

        public int Reset()
        {
            return SoundNativeMethods.SoundPcmReset(handle);
        }

        public int Status(out SoundPcmStatus status)
        {
            IntPtr ptr = IntPtr.Zero;
            int ret = SoundNativeMethods.SoundPcmStatus(handle, ptr);
            status = new SoundPcmStatus(ptr);
            return ret;
        }

        public int Start()
        {
            return SoundNativeMethods.SoundPcmStart(handle);
        }

        public int Drop()
        {
            return SoundNativeMethods.SoundPcmDrop(handle);
        }

        public int Drain()
        {
            return SoundNativeMethods.SoundPcmDrain(handle);
        }

        public int Pause()
        {
            return SoundNativeMethods.SoundPcmPause(handle);
        }

        public SoundPcmState State()
        {
            return SoundNativeMethods.SoundPcmState(handle);
        }

        public int Delay(out int delay)
        {
            return SoundNativeMethods.SoundPcmDelay(handle, out delay);
        }

        public int Resume()
        {
            return SoundNativeMethods.SoundPcmResume(handle);
        }

        // missing htimestamp

        public int GetAvailableFrames()
        {
            return SoundNativeMethods.SoundPcmAvail(handle);
        }

        public int UpdateAvailableFrames()
        {
            return SoundNativeMethods.SoundPcmAvailUpdate(handle);
        }

        public int GetAvailFramesAndDelay(out int avail, out int delay)
        {
            return SoundNativeMethods.SoundPcmAvailDelay(handle, out avail, out delay);
        }

        public int GetRewindable()
        {
            return SoundNativeMethods.SoundPcmRewindable(handle);
        }

        public int Rewind(int frames)
        {
            return SoundNativeMethods.SoundPcmRewind(handle, frames);
        }

        public int GetForwardable()
        {
            return SoundNativeMethods.SoundPcmForwardable(handle);
        }

        public int Forward(int frames)
        {
            return SoundNativeMethods.SoundPcmForward(handle, frames);
        }

        public int WriteI(IntPtr buffer, int size)
        {
            return SoundNativeMethods.SoundPcmWriteI(handle, buffer, size);
        }

        public int ReadI(IntPtr buffer, int size)
        {
            return SoundNativeMethods.SoundPcmReadI(handle, buffer, size);
        }

        public int WriteN(out IntPtr bufs, int size)
        {
            return SoundNativeMethods.SoundPcmWriteN(handle, out bufs, size);
        }

        public int ReadN(out IntPtr bufs, int size)
        {
            return SoundNativeMethods.SoundPcmReadN(handle, out bufs, size);
        }

        public int Wait(int timeout)
        {
            return SoundNativeMethods.SoundPcmWait(handle, timeout);
        }

        public int Link(SoundPcm pcm)
        {
            return SoundNativeMethods.SoundPcmLink(handle, pcm.handle);
        }

        public int Unlink()
        {
            return SoundNativeMethods.SoundPcmUnlink(handle);
        }
    }
}
