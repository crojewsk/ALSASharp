using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public class SoundCard
    {
        public int Id;
    }

    public class SoundCardCollection
    {
        /// <summary>
        /// Try to determine the next card.
        /// </summary>
        /// <param name="card">Card.</param>
        /// <returns>Zero if success, otherwise a negative error code.</returns>
        public int Next(out int card)
        {
            return SoundNativeMethods.SoundCardNext(out card);
        }
    }

    public class SoundDeviceNameHint
    {
        IntPtr handle;
        public string[] Hints;

        public SoundDeviceNameHint(int card, string iface)
        {
            List<string> hints = new List<string>();
            IntPtr buffer, ptr;
            int n = 0, size;
            int err = SoundNativeMethods.SoundDeviceNameHint(card, iface, out buffer);
            if (err < 0)
            {
                throw new InvalidOperationException("SoundDeviceNameHint failed");
            }

            //int stringLength = ((int)1) / Marshal.SizeOf(typeof(short));
            // pointer to an array of IntPtr, each denoting separate string hint
            if (buffer != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof(IntPtr));
                while (true)
                {
                    ptr = Marshal.ReadIntPtr(buffer + (n * size));
                    if (ptr == IntPtr.Zero)
                    {
                        break;
                    }
                    hints.Add(Marshal.PtrToStringAnsi(ptr));
                    n++;
                }
                Hints = hints.ToArray();
                handle = buffer;
            }
            else
            {
                Hints = null;
            }
        }

        public static string GetHint(string hint, string id)
        {
            IntPtr ptr = SoundNativeMethods.SoundDeviceNameGetHint(hint, id);
            if (ptr != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(ptr);
            }

            return null;
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundDeviceNameFreeHint(handle);
                handle = IntPtr.Zero;
                Hints = null;
            }
        }
    }
}
