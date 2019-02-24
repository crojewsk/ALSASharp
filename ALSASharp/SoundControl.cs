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

        // opens missing

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

        // handlers + descriptors missing

        public int SetNonblock(int nonblock)
        {
            return SoundNativeMethods.SoundControlNonblock(handle, nonblock);
        }

        public int PollDescriptorsCount()
        {
            return SoundNativeMethods.SoundControlPollDescriptorsCount(handle);
        }

        public int SubscribeEvents(int subscribe)
        {
            return SoundNativeMethods.SoundControlSubscribeEvents(handle, subscribe);
        }

        public int CardInfo(out SoundControlCardInfo info)
        {
            int ret = SoundNativeMethods.SoundControlCardInfo(handle, out IntPtr ptr);
            info = new SoundControlCardInfo(ptr);
            return ret;
        }

        public int ElementList(out SoundControlElementList list)
        {
            int ret = SoundNativeMethods.SoundControlElementList(handle, out IntPtr ptr);
            list = new SoundControlElementList(ptr);
            return ret;
        }

        public int ElementInfo(out SoundControlElementInfo info)
        {
            int ret = SoundNativeMethods.SoundControlElementInfo(handle, out IntPtr ptr);
            info = new SoundControlElementInfo(ptr);
            return ret;
        }

        public int ElementRead(out SoundControlElementValue data)
        {
            int ret = SoundNativeMethods.SoundControlElementRead(handle, out IntPtr ptr);
            data = new SoundControlElementValue(ptr);
            return ret;
        }

        public int ElementWrite(out SoundControlElementValue data)
        {
            int ret = SoundNativeMethods.SoundControlElementWrite(handle, out IntPtr ptr);
            data = new SoundControlElementValue(ptr);
            return ret;
        }

        public int ElementLock(out SoundControlElementId id)
        {
            int ret = SoundNativeMethods.SoundControlElementLock(handle, out IntPtr ptr);
            id = new SoundControlElementId(ptr);
            return ret;
        }

        public int ElementUnlock(out SoundControlElementId id)
        {
            int ret = SoundNativeMethods.SoundControlElementUnlock(handle, out IntPtr ptr);
            id = new SoundControlElementId(ptr);
            return ret;
        }

        public int ReadTLVFromElement(SoundControlElementId id, uint[] tlv, uint tlvSize)
        {
            return SoundNativeMethods.SoundControlElementTLVRead(handle, id.handle, tlv, tlvSize);
        }

        public int WriteTLVToElement(SoundControlElementId id, uint[] tlv)
        {
            return SoundNativeMethods.SoundControlElementTLVWrite(handle, id.handle, tlv);
        }

        public int CommandTLVForElement(SoundControlElementId id, uint[] tlv)
        {
            return SoundNativeMethods.SoundControlElementTLVCommand(handle, id.handle, tlv);
        }

        public int SetPowerState(uint state)
        {
            return SoundNativeMethods.SoundControlSetPowerState(handle, state);
        }

        public int GetPowerState(out uint state)
        {
            return SoundNativeMethods.SoundControlGetPowerState(handle, out state);
        }

        public int Read(SoundControlEvent evt)
        {
            return SoundNativeMethods.SoundControlRead(handle, evt.handle);
        }

        public int Wait(int timeout)
        {
            return SoundNativeMethods.SoundControlWait(handle, timeout);
        }

        public string GetName()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public SoundControlType Type
        {
            get
            {
                return SoundNativeMethods.SoundControlType(handle);
            }
        }

        public int GetdBRange(ref SoundControlElementId id, out int min, out int max)
        {
            return SoundNativeMethods.SoundControlGetdBRange(handle, ref id.handle, out min, out max);
        }

        public int ConvertTodB(ref SoundControlElementId id, int volume, out int gain)
        {
            return SoundNativeMethods.SoundControlConvertTodB(handle, ref id.handle, volume, out gain);
        }

        public int ConvertFromdB(ref SoundControlElementId id, int dBGain, out int value, int xdir)
        {
            return SoundNativeMethods.SoundControlConvertFromdB(handle, ref id.handle, dBGain, out value, xdir);
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
