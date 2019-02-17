using System;

namespace ALSASharp
{
    public abstract class SoundPcmHwBaseParam
    {
        protected IntPtr owner;

        protected SoundPcmHwBaseParam(IntPtr handle)
        {
            owner = handle;
        }

        public abstract int Get(out uint value, int dir = 0);

        public abstract int Test(SoundPcm pcm, uint value, int dir = 0);

        public abstract int Set(SoundPcm pcm, uint value, int dir = 0);

        public abstract int SetFirst(SoundPcm pcm, out uint value, int dir = 0);

        public abstract int SetLast(SoundPcm pcm, out uint value, int dir = 0);
    }
}