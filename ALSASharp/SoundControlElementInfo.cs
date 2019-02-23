using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlElementInfo : IDisposable
    {
        internal IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoSizeOf();
            }
        }

        public SoundControlElementInfo(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementInfoMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlElementInfo()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlElementInfoFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlElementInfoClear(handle);
        }

        public void Copy(ref SoundControlElementInfo obj)
        {
            SoundNativeMethods.SoundControlElementInfoCopy(handle, obj.handle);
        }

        public SoundControlElementType Type()
        {
            return SoundNativeMethods.SoundControlElementInfoGetType(handle);
        }

        public bool IsReadable
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsReadable(handle);
            }
        }

        public bool IsWriteble
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsWritable(handle);
            }
        }

        public bool IsVolatile
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsVolatile(handle);
            }
        }

        public bool IsInactive
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsInactive(handle);
            }
        }

        public bool IsLocked
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsLocked(handle);
            }
        }

        public bool IsTLVReadable
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsTLVReadable(handle);
            }
        }

        public bool IsTLVWriteble
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsTLVWritable(handle);
            }
        }

        public bool IsTLVCommandable
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsTLVCommandable(handle);
            }
        }

        public bool IsOwner
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsOwner(handle);
            }
        }

        public bool IsUser
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoIsUser(handle);
            }
        }

        public int GetOwner
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetOwner(handle);
            }
        }

        public uint GetCount
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetCount(handle);
            }
        }

        public int GetMin
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetMin(handle);
            }
        }

        public int GetMax
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetMax(handle);
            }
        }

        public int GetStep
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetStep(handle);
            }
        }

        public long GetMin64
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetMin64(handle);
            }
        }

        public long GetMax64
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetMax64(handle);
            }
        }

        public long GetStep64
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetStep64(handle);
            }
        }

        public uint GetItems()
        {
            return SoundNativeMethods.SoundControlElementInfoGetItems(handle);
        }

        public void SetItem(uint val)
        {
            SoundNativeMethods.SoundControlElementInfoSetItem(handle, val);
        }

        public string GetItemName()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlElementInfoGetItemName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public int GetDimensions()
        {
            return SoundNativeMethods.SoundControlElementInfoGetDimensions(handle);
        }

        public int GetDimension(uint idx)
        {
            return SoundNativeMethods.SoundControlElementInfoGetDimension(handle, idx);
        }

        public int SetDimention(uint[] dimension)
        {
            return SoundNativeMethods.SoundControlElementInfoSetDimension(handle, dimension);
        }

        public void GetId(out SoundControlElementId elem)
        {
            IntPtr ptr;
            SoundNativeMethods.SoundControlElementInfoGetId(handle, out ptr);
            elem = new SoundControlElementId(ptr);
        }

        public void SetId(SoundControlElementId elem)
        {
            SoundNativeMethods.SoundControlElementInfoSetId(handle, elem.handle);
        }

        public uint NumId
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetNumId(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementInfoSetNumId(handle, value);
            }
        }

        public SoundControlElementIface Interface
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetInterface(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementInfoSetInterface(handle, value);
            }
        }

        public uint Device
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetDevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementInfoSetDevice(handle, value);
            }
        }

        public uint Subdevice
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetSubdevice(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementInfoSetSubdevice(handle, value);
            }
        }

        public string Name
        {
            get
            {
                IntPtr ptr = SoundNativeMethods.SoundControlElementInfoGetName(handle);
                return Marshal.PtrToStringAnsi(ptr);
            }

            set
            {
                IntPtr ptr = Marshal.StringToHGlobalAnsi(value);
                SoundNativeMethods.SoundControlElementInfoSetName(handle, ptr);
            }
        }

        public uint Index
        {
            get
            {
                return SoundNativeMethods.SoundControlElementInfoGetIndex(handle);
            }

            set
            {
                SoundNativeMethods.SoundControlElementInfoSetIndex(handle, value);
            }
        }
    }
}
