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

    public class SoundPcmRateParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmRateParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetRate(owner, out value, ref dir);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestRate(pcm.handle, owner, value, dir);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRate(pcm.handle, owner, value, dir);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateFirst(pcm.handle, owner, out value, ref dir);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateLast(pcm.handle, owner, out value, ref dir);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetRateMin(owner, out value, ref dir);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetRateMax(owner, out value, ref dir);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateMin(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateMax(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateMinMax(pcm.handle, owner, ref min, ref mindir, ref max, ref maxdir);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetRateNear(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            throw new NotSupportedException();
        }
    }

    public class SoundPcmPeriodTimeParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmPeriodTimeParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodTime(owner, out value, ref dir);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestPeriodTime(pcm.handle, owner, value, dir);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTime(pcm.handle, owner, value, dir);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeFirst(pcm.handle, owner, out value, ref dir);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeLast(pcm.handle, owner, out value, ref dir);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodTimeMin(owner, out value, ref dir);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodTimeMax(owner, out value, ref dir);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeMin(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeMax(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeMinMax(pcm.handle, owner, ref min, ref mindir, ref max, ref maxdir);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodTimeNear(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            throw new NotSupportedException();
        }
    }

    public class SoundPcmPeriodSizeParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmPeriodSizeParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodSize(owner, out value, ref dir);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestPeriodSize(pcm.handle, owner, value, dir);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSize(pcm.handle, owner, value, dir);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeFirst(pcm.handle, owner, out value, ref dir);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeLast(pcm.handle, owner, out value, ref dir);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodSizeMin(owner, out value, ref dir);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodSizeMax(owner, out value, ref dir);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeMin(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeMax(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeMinMax(pcm.handle, owner, ref min, ref mindir, ref max, ref maxdir);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeNear(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodSizeInteger(pcm.handle, owner);
        }
    }

    public class SoundPcmPeriodsParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmPeriodsParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriods(owner, out value, ref dir);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestPeriods(pcm.handle, owner, value, dir);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriods(pcm.handle, owner, value, dir);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsFirst(pcm.handle, owner, out value, ref dir);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsLast(pcm.handle, owner, out value, ref dir);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodsMin(owner, out value, ref dir);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetPeriodsMax(owner, out value, ref dir);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsMin(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsMax(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsMinMax(pcm.handle, owner, ref min, ref mindir, ref max, ref maxdir);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsNear(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetPeriodsInteger(pcm.handle, owner);
        }
    }

    public class SoundPcmBufferTimeParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmBufferTimeParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferTime(owner, out value, ref dir);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestBufferTime(pcm.handle, owner, value, dir);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTime(pcm.handle, owner, value, dir);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeFirst(pcm.handle, owner, out value, ref dir);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeLast(pcm.handle, owner, out value, ref dir);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferTimeMin(owner, out value, ref dir);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferTimeMax(owner, out value, ref dir);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeMin(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeMax(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeMinMax(pcm.handle, owner, ref min, ref mindir, ref max, ref maxdir);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferTimeNear(pcm.handle, owner, ref value, ref dir);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            throw new NotSupportedException();
        }
    }

    public class SoundPcmBufferSizeParam : SoundPcmHwIntervalParam
    {
        internal SoundPcmBufferSizeParam(IntPtr handle)
            : base(handle)
        {
        }

        public override int Get(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferSize(owner, out value);
        }

        public override int Test(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsTestBufferSize(pcm.handle, owner, value);
        }

        public override int Set(SoundPcm pcm, uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSize(pcm.handle, owner, value);
        }

        public override int SetFirst(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeFirst(pcm.handle, owner, out value);
        }

        public override int SetLast(SoundPcm pcm, out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeLast(pcm.handle, owner, out value);
        }

        public override int GetMin(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferSizeMin(owner, out value);
        }

        public override int GetMax(out uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetBufferSizeMax(owner, out value);
        }

        public override int SetMin(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeMin(pcm.handle, owner, ref value);
        }

        public override int SetMax(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeMax(pcm.handle, owner, ref value);
        }

        public override int SetMinMax(SoundPcm pcm, ref uint min, ref uint max, int mindir = 0, int maxdir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeMinMax(pcm.handle, owner, ref min, ref max);
        }

        public override int SetNear(SoundPcm pcm, ref uint value, int dir = 0)
        {
            return SoundNativeMethods.SoundPcmHwParamsSetBufferSizeNear(pcm.handle, owner, ref value);
        }

        public override int SetInteger(SoundPcm pcm)
        {
            throw new NotSupportedException();
        }
    }
}
