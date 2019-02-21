using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlElementId : IDisposable
    {
        internal IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdSizeOf();
            }
        }

        public SoundControlElementId(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementIdMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlElementId()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementIdFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlElementIdClear(handle);
        }

        public void Copy(ref SoundControlElementId obj)
        {
            SoundNativeMethods.SoundControlElementIdCopy(handle, obj.handle);
        }

        public uint NumId
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdGetNumId(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementIdSetNumId(handle, value);
            }
        }

        public SoundControlElementIface Interface
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdGetInterface(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementIdSetInterface(handle, value);
            }
        }

        public uint Device
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdGetDevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementIdSetDevice(handle, value);
            }
        }

        public uint Subdevice
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdGetSubdevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementIdSetSubdevice(handle, value);
            }
        }

        public string Name
        {
            get
            {
                IntPtr ptr = SoundNativeMethods.SoundControlElementIdGetName(handle);
                return Marshal.PtrToStringAnsi(ptr);
            }

            set
            {
                IntPtr ptr = Marshal.StringToHGlobalAnsi(value);
                SoundNativeMethods.SoundControlElementIdSetName(handle, ptr);
            }
        }

        public uint Index
        {
            get
            {
                return SoundNativeMethods.SoundControlElementIdGetIndex(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementIdSetIndex(handle, value);
            }
        }
    }
}
