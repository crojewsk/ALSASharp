using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlElementList : IDisposable
    {
        internal IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlElementListSizeOf();
            }
        }

        public SoundControlElementList(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementListMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlElementList()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementListFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlElementListClear(handle);
        }

        public void Copy(ref SoundControlElementList obj)
        {
            SoundNativeMethods.SoundControlElementListCopy(handle, obj.handle);
        }

        public void SetOffset(uint val)
        {
            SoundNativeMethods.SoundControlElementListSetOffset(handle, val);
        }

        public uint Used
        {
            get
            {
                return SoundNativeMethods.SoundControlElementListGetUsed(handle);
            }
        }

        public uint Count
        {
            get
            {
                return SoundNativeMethods.SoundControlElementListGetCount(handle);
            }
        }

        public void GetId(uint idx, out SoundControlElementId elem)
        {
            IntPtr ptr;
            SoundNativeMethods.SoundControlElementListGetId(handle, idx, out ptr);
            elem = new SoundControlElementId(ptr);
        }

        public uint GetNumId(uint idx)
        {
            return SoundNativeMethods.SoundControlElementListGetNumId(handle, idx);
        }

        public SoundControlElementIface GetInterface(uint idx)
        {
            return SoundNativeMethods.SoundControlElementListGetInterface(handle, idx);
        }

        public uint GetDevice(uint idx)
        {
            return SoundNativeMethods.SoundControlElementListGetDevice(handle, idx);
        }

        public uint GetSubdevice(uint idx)
        {
            return SoundNativeMethods.SoundControlElementListGetSubdevice(handle, idx);
        }

        public string GetName(uint idx)
        {
            IntPtr ptr = SoundNativeMethods.SoundControlElementListGetName(handle, idx);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public uint GetIndex(uint idx)
        {
            return SoundNativeMethods.SoundControlElementListGetIndex(handle, idx);
        }
    }
}
