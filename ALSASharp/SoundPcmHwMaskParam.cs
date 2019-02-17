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
}
