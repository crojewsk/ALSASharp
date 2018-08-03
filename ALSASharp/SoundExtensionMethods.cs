using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
	public static class SoundExtensionMethods
    {
        public static string GetName(this SoundPcmStreamType stream)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmStreamName(stream);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetErrorMessage(int error)
        {
            IntPtr ptr = SoundNativeMethods.SoundStringError(error);
            return Marshal.PtrToStringAnsi(ptr);
        }     
    }
}
