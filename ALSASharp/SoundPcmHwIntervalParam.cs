using System;

namespace ALSASharp
{
    public abstract class SoundPcmHwIntervalParam : SoundPcmHwBaseParam
    {
        protected SoundPcmHwIntervalParam(IntPtr handle)
            : base(handle)
        {
        }

        public abstract int GetMin(out uint value, int dir = 0);

        public abstract int GetMax(out uint value, int dir = 0);

        public abstract int SetMin(SoundPcm pcm, ref uint value, int dir = 0);

        public abstract int SetMax(SoundPcm pcm, ref uint value, int dir = 0);

        public abstract int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0);

        public abstract int SetNear(SoundPcm pcm, ref uint value, int dir = 0);

        public abstract int SetInteger(SoundPcm pcm);
    }

    public class SoundPcmChannelsParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmChannelsParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetChannels(owner, out value);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestChannels(pcm.handle, owner, value);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannels(pcm.handle, owner, value);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsFirst(pcm.handle, owner, out value);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsLast(pcm.handle, owner, out value);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetChannelsMin(owner, out value);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetChannelsMax(owner, out value);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsMin(pcm.handle, owner, ref value);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsMax(pcm.handle, owner, ref value);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsMinMax(pcm.handle, owner, ref min, ref max);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetChannelsNear(pcm.handle, owner, ref value);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            throw new NotSupportedException();
        }
    }
}
