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
}
