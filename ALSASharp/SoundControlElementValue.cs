using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlElementValue : IDisposable
    {
        internal IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueSizeOf();
            }
        }

        public SoundControlElementValue(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementValueMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlElementValue()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementValueFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlElementValueClear(handle);
        }

        public void Copy(ref SoundControlElementValue obj)
        {
            SoundNativeMethods.SoundControlElementValueCopy(handle, obj.handle);
        }

        public int Compare(SoundControlElementValue other)
        {
            return SoundNativeMethods.SoundControlElementValueCompare(handle, other.handle);
        }

        public void GetId(out SoundControlElementId elem)
        {
            IntPtr ptr;
            SoundNativeMethods.SoundControlElementValueGetId(handle, out ptr);
            elem = new SoundControlElementId(ptr);
        }

        public void SetId(SoundControlElementId elem)
        {
            SoundNativeMethods.SoundControlElementValueSetId(handle, elem.handle);
        }

        public uint NumId
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueGetNumId(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementValueSetNumId(handle, value);
            }
        }

        public SoundControlElementIface Interface
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueGetInterface(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementValueSetInterface(handle, value);
            }
        }

        public uint Device
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueGetDevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementValueSetDevice(handle, value);
            }
        }

        public uint Subdevice
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueGetSubdevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementValueSetSubdevice(handle, value);
            }
        }

        public string Name
        {
            get
            {
                IntPtr ptr = SoundNativeMethods.SoundControlElementValueGetName(handle);
                return Marshal.PtrToStringAnsi(ptr);
            }

            set
            {
                IntPtr ptr = Marshal.StringToHGlobalAnsi(value);
                SoundNativeMethods.SoundControlElementValueSetName(handle, ptr);
            }
        }

        public uint Index
        {
            get
            {
                return SoundNativeMethods.SoundControlElementValueGetIndex(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementValueSetIndex(handle, value);
            }
        }

        public bool GetBoolean(uint idx)
        {
            return SoundNativeMethods.SoundControlElementValueGetBoolean(handle, idx);
        }

        public int GetInteger(uint idx)
        {
            return SoundNativeMethods.SoundControlElementValueGetInteger(handle, idx);
        }

        public long GetInteger64(uint idx)
        {
            return SoundNativeMethods.SoundControlElementValueGetInteger64(handle, idx);
        }

        public uint GetEnumerated(uint idx)
        {
            return SoundNativeMethods.SoundControlElementValueGetEnumerated(handle, idx);
        }

        public byte GetByte(uint idx)
        {
            return SoundNativeMethods.SoundControlElementValueGetByte(handle, idx);
        }

        public void SetBoolean(uint idx, bool val)
        {
            SoundNativeMethods.SoundControlElementValueSetBoolean(handle, idx, val);
        }

        public void SetInteger(uint idx, int val)
        {
            SoundNativeMethods.SoundControlElementValueSetInteger(handle, idx, val);
        }

        public void SetInteger64(uint idx, long val)
        {
            SoundNativeMethods.SoundControlElementValueSetInteger64(handle, idx, val);
        }

        public void SetEnumerated(uint idx, uint val)
        {
            SoundNativeMethods.SoundControlElementValueSetEnumerated(handle, idx, val);
        }

        public void SetByte(uint idx, byte val)
        {
            SoundNativeMethods.SoundControlElementValueSetByte(handle, idx, val);
        }

        public void SetBytes(byte[] data, uint size)
        {
            //SoundNativeMethods.SoundControlElementValueSetBytes(handle, data, size);
        }

        public byte[] GetBytes()
        {
            //return SoundNativeMethods.SoundControlElementValueGetBytes(handle);
            return null;
        }

        // missing set/ get iec958 methods
    }
}
