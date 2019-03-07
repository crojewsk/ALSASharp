using System;

namespace ALSASharp
{
	public class SoundPcmSwParams
	{
		internal IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmSwParams"/> class.
        /// </summary>
        public SoundPcmSwParams(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmSwParamsMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundPcmSwParams()
            : this(IntPtr.Zero)
        {
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmSwParams"/> object.
        /// </summary>
		public void Dispose()
		{
			if (handle != IntPtr.Zero)
			{
				SoundNativeMethods.SoundPcmSwParamsFree(handle);
				handle = IntPtr.Zero;
			}
		}

		/// <summary>
		/// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmSwParams"/>.
		/// </summary>
		/// <returns>Shallow copy of this instance.</returns>
		public object Clone()
		{
			var other = new SoundPcmSwParams();
			SoundNativeMethods.SoundPcmSwParamsCopy(other.handle, this.handle);

			return other;
		}

		/// <summary>
		/// Returns size of internal snd_pcm_sw_params_t.
		/// </summary>
		/// <value>Size of internal snd_pcm_sw_params_t.</value>
		public uint Size
		{
			get
			{
				return SoundNativeMethods.SoundPcmFormatMaskSizeOf();
			}
		}

		public uint GetBoundary()
        {
			uint result;
			int err = SoundNativeMethods.SoundPcmSwParamsGetBoundary(handle, out result);
			if (err < 0)
				throw new InvalidOperationException();

			return result;
        }

        public void SetTStampMode(SoundPcm pcm, SoundPcmTStamp val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetTStampMode(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public SoundPcmTStamp GetTStampMode()
        {
            SoundPcmTStamp result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetTStampMode(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetTStampType(SoundPcm pcm, SoundPcmTStampType val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetTStampType(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public SoundPcmTStampType GetTStampType()
        {
            SoundPcmTStampType result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetTStampType(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetAvailableMin(SoundPcm pcm, uint val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetAvailMin(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public uint GetAvailableMin()
        {
            uint result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetAvailMin(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetPeriodEvent(SoundPcm pcm, int val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetPeriodEvent(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public int GetPeriodEvent()
        {
            int result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetPeriodEvent(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetStartThreshold(SoundPcm pcm, uint val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetStartThreshold(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public uint GetStartThreshold()
        {
            uint result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetStartThreshold(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetStopThreshold(SoundPcm pcm, uint val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetStopThreshold(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public uint GetStopThreshold()
        {
            uint result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetStopThreshold(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetSilenceThreshold(SoundPcm pcm, uint val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetSilenceThreshold(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public uint GetSilenceThreshold()
        {
            uint result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetSilenceThreshold(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }

        public void SetSilenceSize(SoundPcm pcm, uint val)
        {
            int err = SoundNativeMethods.SoundPcmSwParamsSetSilenceSize(pcm.handle, handle, val);
            if (err < 0)
                throw new InvalidOperationException();
        }

        public uint GetSilenceSize()
        {
            uint result;
            int err = SoundNativeMethods.SoundPcmSwParamsGetSilenceSize(handle, out result);
            if (err < 0)
                throw new InvalidOperationException();

            return result;
        }
    }
}
