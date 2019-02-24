using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundControlCardInfo
    {
        IntPtr handle;

        public static uint Size
        {
            get
            {
                return SoundNativeMethods.SoundControlCardInfoSizeOf();
            }
        }

        public SoundControlCardInfo(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundControlCardInfoMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundControlCardInfo()
            : this(IntPtr.Zero)
        {
        }

        public void Clear()
        {
            SoundNativeMethods.SoundControlCardInfoClear(handle);
        }

        public void Copy(ref SoundControlCardInfo obj)
        {
            SoundNativeMethods.SoundControlCardInfoCopy(handle, obj.handle);
        }

        public int GetCard()
        {
            return SoundNativeMethods.SoundControlCardInfoGetCard(handle);
        }

        public string GetId()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetId(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetName()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetName(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetMixername()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetMixername(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public string GetComponenets()
        {
            IntPtr ptr = SoundNativeMethods.SoundControlCardInfoGetComponents(handle);
            return Marshal.PtrToStringAnsi(ptr);
        }
    }
}
