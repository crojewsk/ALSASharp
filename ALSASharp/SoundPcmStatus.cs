using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    /// <summary>
    /// PCM status container.
    /// </summary>
    public class SoundPcmStatus : ICloneable, IDisposable
    {
        internal IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmStatus"/> class.
        /// </summary>
        /// <remarks>Internally represented by snd_pcm_status32, sound/core/pcm_compat.c</remarks>
        public SoundPcmStatus(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmStatusMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundPcmStatus()
            : this(IntPtr.Zero)
        {
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmStatus"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmStatusFree(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmStatus"/>.
        /// </summary>
        /// <returns>Shallow copy of this instance.</returns>
        public object Clone()
        {
            var other = new SoundPcmStatus();
            SoundNativeMethods.SoundPcmStatusCopy(other.handle, this.handle);

            return other;
        }

        /// <summary>
        /// Returns size of internal snd_pcm_status_t.
        /// </summary>
        /// <value>Size of internal snd_pcm_status_t.</value>
        public uint Size
        {
            get
            {
                return SoundNativeMethods.SoundPcmAccessMaskSizeOf();
            }
        }

        /// <summary>
        /// Get state from a PCM status container.
        /// </summary>
        /// <returns>State from a PCM status container.</returns>
        public SoundPcmState State
        {
            get
			{
				return SoundNativeMethods.SoundPcmStatusGetState(handle);
			}
        }

        private static DateTime TStampPtrToDateTime(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException();

            var tstamp = (SoundTimeStamp)Marshal.PtrToStructure(ptr, typeof(SoundTimeStamp));
            return tstamp.ToDateTime();
        }

        private static DateTime HTStampPtrToDateTime(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException();

            var htstamp = (SoundHTimeStamp)Marshal.PtrToStructure(ptr, typeof(SoundHTimeStamp));
            return htstamp.ToDateTime();
        }

        public DateTime GetTriggerTStamp()
        {
			IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetTriggerTStamp(handle, ptr);
			return TStampPtrToDateTime(ptr);
        }

        public DateTime GetTriggerHTStamp()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetTriggerHTStamp(handle, ptr);
            return HTStampPtrToDateTime(ptr);
        }

        public DateTime GetTStamp()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetTStamp(handle, ptr);
            return TStampPtrToDateTime(ptr);
        }

        public DateTime GetHTStamp()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetHTStamp(handle, ptr);
            return HTStampPtrToDateTime(ptr);
        }

        public DateTime GetAudioHTStamp()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetAudioHTStamp(handle, ptr);
            return HTStampPtrToDateTime(ptr);
        }

        public DateTime GetDriverHTStamp()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetDriverHTStamp(handle, ptr);
            return HTStampPtrToDateTime(ptr);
        }

        public SoundPcmAudioTStampReport GetAudioHTStampReport()
        {
			IntPtr ptr = IntPtr.Zero;
			SoundNativeMethods.SoundPcmStatusGetAudioHTReport(handle, ptr);

            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException();

            var report = (SoundPcmAudioTStampReport)Marshal.PtrToStructure(ptr, typeof(SoundPcmAudioTStampReport));
			return report;
        }

        public SoundPcmAudioTStampConfig GetAudioHTStampConfig()
        {
            IntPtr ptr = IntPtr.Zero;
            SoundNativeMethods.SoundPcmStatusGetAudioHTConfig(handle, ptr);

            if (ptr == IntPtr.Zero)
                throw new InvalidOperationException();

            var config = (SoundPcmAudioTStampConfig)Marshal.PtrToStructure(ptr, typeof(SoundPcmAudioTStampConfig));
            return config;
        }

        /// <summary>
        /// Gets the delay from a PCM status container.
        /// </summary>
        public int Delay
        {
            get
            {
				return SoundNativeMethods.SoundPcmStatusGetDelay(handle);
            }
        }

        /// <summary>
        /// Gets the number of frames available from a PCM status container.
        /// </summary>
        public int Avail
        {
            get
            {
                return SoundNativeMethods.SoundPcmStatusGetAvail(handle);
            }
        }

        /// <summary>
        /// Gets the maximum number of frames available from a PCM status container.
        /// </summary>
        public int AvailMax
        {
            get
            {
                return SoundNativeMethods.SoundPcmStatusGetAvailMax(handle);
            }
        }

        /// <summary>
        /// Gets the count of ADC overrange detections since last call.
        /// </summary>
        public int Overrange
        {
            get
            {
                return SoundNativeMethods.SoundPcmStatusGetOverrange(handle);
            }
        }
    }
}
