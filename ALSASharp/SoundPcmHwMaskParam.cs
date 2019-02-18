using System;

namespace ALSASharp
{
    public abstract class SoundPcmHwMaskParam : SoundPcmHwBaseParam
    {
        protected SoundPcmHwMaskParam(IntPtr handle)
            : base(handle)
        {
        }

        public abstract int SetMask(SoundPcm pcm, UnmanagedObject mask);

        public abstract UnmanagedObject GetMask();
    }

    public class SoundPcmAccessParam : SoundPcmHwMaskParam
    {
        internal SoundPcmAccessParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetAccess(owner, out value);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestAccess(pcm.handle, owner, value);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetAccess(pcm.handle, owner, value);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetAccessFirst(pcm.handle, owner, out value);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetAccessLast(pcm.handle, owner, out value);
        }

        public override int SetMask(SoundPcm pcm, UnmanagedObject mask)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetAccessMask(pcm.handle, owner, mask.handle);
        }

        public override UnmanagedObject GetMask()
        {
            IntPtr handle;
            int ret = SoundNativeMethods.SoundPcmHwParamsGetAccessMask(owner, out handle);
            return new SoundPcmAccessMask(handle);
        }
    }

    public class SoundPcmFormatParam : SoundPcmHwMaskParam
    {
        internal SoundPcmFormatParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetFormat(owner, out value);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestFormat(pcm.handle, owner, value);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetFormat(pcm.handle, owner, value);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetFormatFirst(pcm.handle, owner, out value);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetFormatLast(pcm.handle, owner, out value);
        }

        public override int SetMask(SoundPcm pcm, UnmanagedObject mask)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetFormatMask(pcm.handle, owner, mask.handle);
        }

        public override UnmanagedObject GetMask()
        {
            IntPtr ptr;
            SoundNativeMethods.SoundPcmHwParamsGetFormatMask(owner, out ptr);
            return new SoundPcmFormatMask(ptr);
        }
    }
}
