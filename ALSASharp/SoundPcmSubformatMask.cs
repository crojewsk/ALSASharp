using System;

namespace ALSASharp
{
    /// <summary>
    /// Sound pcm format mask.
    /// </summary>
    public class SoundPcmSubformatMask : ICloneable, IDisposable
    {
        internal IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmSubformatMask"/> class.
        /// </summary>
        public SoundPcmSubformatMask(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmSubformatMaskMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundPcmSubformatMask()
            : this(IntPtr.Zero)
        {
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmSubformatMask"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmSubformatMaskFree(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmSubformatMask"/>.
        /// </summary>
        /// <returns>Shallow copy of this instance.</returns>
        public object Clone()
        {
            var other = new SoundPcmSubformatMask();
            SoundNativeMethods.SoundPcmSubformatMaskCopy(other.handle, this.handle);

            return other;
        }

        /// <summary>
        /// Returns size of internal snd_pcm_subformat_mask_t.
        /// </summary>
        /// <value>Size of internal snd_pcm_subformat_mask_t.</value>
        public uint Size
        {
            get
            {
                return SoundNativeMethods.SoundPcmSubformatMaskSizeOf();
            }
        }

        /// <summary>
        /// Resets all bits in a <see cref="SoundPcmSubformatMask"/> instance.
        /// </summary>
        public void Reset()
        {
            SoundNativeMethods.SoundPcmSubformatMaskNone(handle);
        }

        /// <summary>
        /// Sets all bits in a <see cref="SoundPcmSubformatMask"/> instance.
        /// </summary>
        public void SetAll()
        {
            SoundNativeMethods.SoundPcmSubformatMaskAny(handle);
        }

        /// <summary>
        /// Tests the presence of an access type in a <see cref="SoundPcmSubformatMask"/> instance.
        /// </summary>
        /// <returns>Value indicating </returns>
        public bool IsSet(SoundPcmSubformat val)
        {
            return SoundNativeMethods.SoundPcmSubformatMaskTest(handle, val) == 0;
        }

        /// <summary>
        /// Tests, if given <see cref="SoundPcmSubformatMask"/> instance is empty.
        /// </summary>
        /// <returns>Value indicating whether no bis are set.</returns>
        public bool IsEmpty()
        {
            return SoundNativeMethods.SoundPcmSubformatMaskEmpty(handle) == 0;
        }

        /// <summary>
        /// Makes an access type present in a <see cref="SoundPcmSubformatMask"/> instance.
        /// </summary>
        /// <param name="val">Access to set.</param>
        public void Set(SoundPcmSubformat val)
        {
            SoundNativeMethods.SoundPcmSubformatMaskSet(handle, val);
        }

        /// <summary>
        /// Makes an access type missing from a <see cref="SoundPcmSubformatMask"/> instance.
        /// </summary>
        /// <param name="val">Access to unset.</param>
        public void Unset(SoundPcmSubformat val)
        {
            SoundNativeMethods.SoundPcmSubformatMaskSet(handle, val);
        }
    }
}
