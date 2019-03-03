using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    /// <summary>
    /// Contains stream information.
    /// </summary>
    public class SoundPcmInfo : ICloneable, IDisposable
    {
        public int Get(SoundControl ctl)
        {
            int err = SoundNativeMethods.SoundControlPcmInfo(ctl.handle, handle);
            return err;
        }

        public IntPtr handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundPcmInfo"/> class.
        /// </summary>
        public SoundPcmInfo()
        {
			int err = SoundNativeMethods.SoundPcmInfoMalloc(out handle);
            if (handle == IntPtr.Zero)
            {
                throw new OutOfMemoryException(string.Format("err: {0}", err));
            }
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundPcmInfo"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmInfoFree(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="T:ALSASHARP.SoundPcmInfo"/>.
        /// </summary>
        /// <returns>Shallow copy of this instance.</returns>
        public object Clone()
        {
            var other = new SoundPcmInfo();
            SoundNativeMethods.SoundPcmInfoCopy(other.handle, this.handle);

            return other;
        }

        /// <summary>
        /// Returns size of internal snd_pcm_info_t.
        /// </summary>
        /// <value>Size of internal snd_pcm_info_t.</value>
        public uint Size
        {
            get
            {
                return SoundNativeMethods.SoundPcmInfoSizeOf();
            }
        }

        public uint GetDevice()
        {
            return SoundNativeMethods.SoundPcmInfoGetDevice(handle);
        }

        public uint GetSubdevice()
        {
            uint subdev = SoundNativeMethods.SoundPcmInfoGetSubdevice(handle);
			return subdev;
        }

        public SoundPcmStream Stream
        {
            get
			{
				return SoundNativeMethods.SoundPcmInfoGetStream(handle);
			}
        }

        public string GetId()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetId(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetName()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetSubdeviceName()
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmInfoGetSubdeviceName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public SoundPcmClass Class
        {
            get
            {
                return SoundNativeMethods.SoundPcmInfoGetClass(handle);
            }
        }

        public SoundPcmSubclass Subclass
        {
            get
			{
				return SoundNativeMethods.SoundPcmInfoGetSubclass(handle);
			}
        }

        public uint SubdevicesCount
        {
            get
			{
				return SoundNativeMethods.SoundPcmInfoGetSubdevicesCount(handle);
			}
        }

        public uint SubdevicesAvail
        {
            get
			{
				return SoundNativeMethods.SoundPcmInfoGetSubdevicesAvail(handle);
			}
        }

        public SoundPcmSyncId SyncId
        {
            get
            {
				return SoundNativeMethods.SoundPcmInfoGetSync(handle);
            }
        }

        public void SetDevice(uint val)
        {
            SoundNativeMethods.SoundPcmInfoSetDevice(handle, val);
        }

        public void SetSubdevice(uint subdev)
        {
            SoundNativeMethods.SoundPcmInfoSetSubdevice(handle, subdev);
        }

        public void SetStream(SoundPcmStream stream)
        {
            SoundNativeMethods.SoundPcmInfoSetStream(handle, stream);
        }
    }
}
