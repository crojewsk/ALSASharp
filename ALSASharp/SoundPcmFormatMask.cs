using System;

namespace ALSASharp
{
    /// <summary>
    /// Sound pcm format mask.
    /// </summary>
    public class SoundPcmFormatMask : ICloneable, IDisposable
    {
        internal IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmFormatMask"/> class.
        /// </summary>
        public SoundPcmFormatMask()
        {
            SoundNativeMethods.SoundPcmFormatMaskMalloc(out handle);
            if (handle == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmFormatMask"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmFormatMaskFree(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmFormatMask"/>.
        /// </summary>
        /// <returns>Shallow copy of this instance.</returns>
        public object Clone()
        {
            var other = new SoundPcmFormatMask();
            SoundNativeMethods.SoundPcmFormatMaskCopy(other.handle, this.handle);

            return other;
        }

        /// <summary>
        /// Returns size of internal snd_pcm_access_mask_t.
        /// </summary>
        /// <value>Size of internal snd_pcm_access_mask_t.</value>
        public uint Size
        {
            get
            {
                return SoundNativeMethods.SoundPcmFormatMaskSizeOf();
            }
        }

        /// <summary>
        /// Resets all bits in a <see cref="SoundPcmFormatMask"/> instance.
        /// </summary>
        public void Reset()
        {
            SoundNativeMethods.SoundPcmFormatMaskNone(handle);
        }

        /// <summary>
        /// Sets all bits in a <see cref="SoundPcmFormatMask"/> instance.
        /// </summary>
        public void SetAll()
        {
            SoundNativeMethods.SoundPcmFormatMaskAny(handle);
        }

        /// <summary>
        /// Tests the presence of an access type in a <see cref="SoundPcmFormatMask"/> instance.
        /// </summary>
        /// <returns>Value indicating </returns>
        public bool IsSet(SoundPcmFormat val)
        {
            return SoundNativeMethods.SoundPcmFormatMaskTest(handle, val) == 0;
        }

        /// <summary>
        /// Tests, if given <see cref="SoundPcmFormatMask"/> instance is empty.
        /// </summary>
        /// <returns>Value indicating whether no bis are set.</returns>
        public bool IsEmpty()
        {
            return SoundNativeMethods.SoundPcmFormatMaskEmpty(handle) == 0;
        }

        /// <summary>
        /// Makes an access type present in a <see cref="SoundPcmFormatMask"/> instance.
        /// </summary>
        /// <param name="val">Access to set.</param>
        public void Set(SoundPcmFormat val)
        {
            SoundNativeMethods.SoundPcmFormatMaskSet(handle, val);
        }

        /// <summary>
        /// Makes an access type missing from a <see cref="SoundPcmFormatMask"/> instance.
        /// </summary>
        /// <param name="val">Access to unset.</param>
        public void Unset(SoundPcmFormat val)
        {
            SoundNativeMethods.SoundPcmFormatMaskSet(handle, val);
        }
    }
}
