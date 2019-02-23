using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlEvent : IDisposable
    {
        internal IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlEventSizeOf();
            }
        }

        public SoundControlEvent(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlEventMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlEvent()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlEventFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlEventClear(handle);
        }

        public void Copy(ref SoundControlEvent obj)
        {
            SoundNativeMethods.SoundControlElementIdCopy(handle, obj.handle);
        }

        public SoundControlEventType Type()
        {
            return SoundNativeMethods.SoundControlEventGetType(handle);
        }

        public uint GetMaskForElement()
        {
            return SoundNativeMethods.SoundControlEventElementGetMask(handle);
        }

        public uint NumId
        {
            get
            {
                return SoundNativeMethods.SoundControlEventElementGetNumId(handle);
            }
        }

        public void GetId(out SoundControlElementId elem)
        {
            IntPtr ptr;
            SoundNativeMethods.SoundControlEventElementGetId(handle, out ptr);
            elem = new SoundControlElementId(ptr);
        }

        public SoundControlElementIface Interface
        {
            get
            {
                return SoundNativeMethods.SoundControlEventElementGetInterface(handle);
            }
        }

        public uint Device
        {
            get
            {
                return SoundNativeMethods.SoundControlEventElementGetDevice(handle);
            }
        }

        public uint Subdevice
        {
            get
            {
                return SoundNativeMethods.SoundControlEventElementGetSubdevice(handle);
            }
        }

        public string Name
        {
            get
            {
                IntPtr ptr = SoundNativeMethods.SoundControlEventElementGetName(handle);
                return Marshal.PtrToStringAnsi(ptr);
            }
        }

        public uint Index
        {
            get
            {
                return SoundNativeMethods.SoundControlEventElementGetIndex(handle);
            }
        }
    }
}
