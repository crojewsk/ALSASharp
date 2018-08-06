using System;

namespace ALSASharp
{
    /// <summary>
    /// Sound pcm access mask.
    /// </summary>
    public class SoundPcmAccessMask : ICloneable, IDisposable
    {
        internal IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmAccessMask"/> class.
        /// </summary>
        public SoundPcmAccessMask()
        {
            SoundNativeMethods.SoundPcmAccessMaskMalloc(out handle);
            if (handle == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmAccessMask"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmAccessMaskFree(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmAccessMask"/>.
        /// </summary>
        /// <returns>Shallow copy of this instance.</returns>
        public object Clone()
        {
			var other = new SoundPcmAccessMask();
			SoundNativeMethods.SoundPcmAccessMaskCopy(other.handle, this.handle);

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
                return SoundNativeMethods.SoundPcmAccessMaskSizeOf();
            }
        }

        /// <summary>
        /// Resets all bits in a <see cref="SoundPcmAccessMask"/> instance.
        /// </summary>
        public void Reset()
        {
            SoundNativeMethods.SoundPcmAccessMaskNone(handle);
        }

        /// <summary>
        /// Sets all bits in a <see cref="SoundPcmAccessMask"/> instance.
        /// </summary>
        public void SetAll()
        {
            SoundNativeMethods.SoundPcmAccessMaskAny(handle);
        }

        /// <summary>
        /// Tests the presence of an access type in a <see cref="SoundPcmAccessMask"/> instance.
        /// </summary>
        /// <returns>Value indicating </returns>
        public bool IsSet(SoundPcmAccess val)
        {
			return SoundNativeMethods.SoundPcmAccessMaskTest(handle, val) == 0;
        }

        /// <summary>
        /// Tests, if given <see cref="SoundPcmAccessMask"/> instance is empty.
        /// </summary>
        /// <returns>Value indicating whether no bis are set.</returns>
        public bool IsEmpty()
        {
            return SoundNativeMethods.SoundPcmAccessMaskEmpty(handle) == 0;
        }

        /// <summary>
        /// Makes an access type present in a <see cref="SoundPcmAccessMask"/> instance.
        /// </summary>
        /// <param name="val">Access to set.</param>
        public void Set(SoundPcmAccess val)
        {
            SoundNativeMethods.SoundPcmAccessMaskSet(handle, val);
        }

        /// <summary>
        /// Makes an access type missing from a <see cref="SoundPcmAccessMask"/> instance.
        /// </summary>
        /// <param name="val">Access to unset.</param>
        public void Unset(SoundPcmAccess val)
        {
            SoundNativeMethods.SoundPcmAccessMaskSet(handle, val);
        }
    }
}
