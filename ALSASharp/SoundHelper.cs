using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    public static class SoundHelper
    {
        public static DateTime ToDateTime(this SoundTimeStamp tstamp)
        {
            var dateTime = new DateTime(1970, 1, 1).ToLocalTime()
                .AddSeconds(tstamp.tvSec)
                .AddMilliseconds(tstamp.tvUsec);

            return dateTime;
        }

        public static DateTime ToDateTime(this SoundHTimeStamp htstamp)
        {
            var dateTime = new DateTime(1970, 1, 1).ToLocalTime()
                .AddSeconds(htstamp.tvSec)
                .AddMilliseconds(htstamp.tvNsec);

            return dateTime;
        }

        public static string GetErrorMessage(int error)
        {
            IntPtr ptr = SoundNativeMethods.SoundStringError(error);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmType type)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmTypeName(type);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmStream stream)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmStreamName(stream);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmAccess access)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmAccessName(access);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmFormat format)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmFormatName(format);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetDescription(this SoundPcmFormat format)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmFormatDescription(format);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmSubformat format)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmSubformatName(format);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetDescription(this SoundPcmSubformat format)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmSubformatDescription(format);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static SoundPcmFormat StringToFormat(string name)
        {
            IntPtr ptr = Marshal.StringToHGlobalAuto(name);
            return SoundNativeMethods.SoundPcmFormatValue(ptr);
        }

        public static string GetName(this SoundPcmTStamp mode)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmTStampModeName(mode);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundPcmState state)
        {
            IntPtr ptr = SoundNativeMethods.SoundPcmStateName(state);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundControlElementType type)
        {
            IntPtr ptr = SoundNativeMethods.SoundControlElementTypeName(type);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundControlElementIface iface)
        {
            IntPtr ptr = SoundNativeMethods.SoundControlElementIfaceName(iface);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string GetName(this SoundControlEventType type)
        {
            IntPtr ptr = SoundNativeMethods.SoundControlEventTypeName(type);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static bool IsSigned(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatSigned(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("{0} is not a linear format: {1}", format, ret));

            return ret == 1;
        }

        public static bool IsUnsigned(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatUnsigned(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("{0} is not a linear format: {1}", format, ret));

            return ret == 1;
        }

        public static bool IsLinear(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatLinear(format) == 1;
        }

        public static bool IsFloat(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatFloat(format) == 1;
        }

        public static bool IsLittleEndian(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatLittleEndian(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("{0} format is endianess independent: {1}", format, ret));

            return ret == 1;
        }

        public static bool IsBigEndian(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatBigEndian(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("{0} format is endianess independent: {1}", format, ret));

            return ret == 1;
        }

        public static bool IsCpuEndian(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatCpuEndian(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("{0} format is endianess independent: {1}", format, ret));

            return ret == 1;
        }

        public static int GetWidth(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatWidth(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("Cannot retrieve width for {0}, {1}", format, ret));

            return ret;
        }

        public static int GetPhysicalWidth(this SoundPcmFormat format)
        {
            int ret = SoundNativeMethods.SoundPcmFormatPhysicalWidth(format);
            if (ret < 0)
                throw new InvalidOperationException(
                    string.Format("Cannot retrieve physical width for {0}, {1}", format, ret));

            return ret;
        }

        public static SoundPcmFormat BuildLinearPcmFormat(int width, int pwidth, bool unsigned, bool bigEndian)
        {
            return SoundNativeMethods.SoundPcmBuildLinearFormat(width, pwidth, unsigned, bigEndian);
        }

        public static uint GetSize(this SoundPcmFormat format, uint samples)
        {
            return SoundNativeMethods.SoundPcmFormatSize(format, samples);
        }

        public static byte GetSilence(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatSilence(format);
        }

        public static ushort GetSilence16(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatSilence16(format);
        }

        public static uint GetSilence32(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatSilence32(format);
        }

        public static ulong GetSilence64(this SoundPcmFormat format)
        {
            return SoundNativeMethods.SoundPcmFormatSilence64(format);
        }

        public static int SetSilence(this SoundPcmFormat format, IntPtr buf, uint samples)
        {
            return SoundNativeMethods.SoundPcmFormatSetSilence(format, buf, samples);
        }

        public static uint BytesToFrames(this SoundPcm pcm, uint bytes)
        {
            return SoundNativeMethods.SoundPcmBytesToFrames(pcm.handle, bytes);
        }

        public static uint FramesToBytes(this SoundPcm pcm, uint frames)
        {
            return SoundNativeMethods.SoundPcmFramesToBytes(pcm.handle, frames);
        }

        public static uint BytesToSamples(this SoundPcm pcm, uint bytes)
        {
            return SoundNativeMethods.SoundPcmBytesToSamples(pcm.handle, bytes);
        }

        public static uint SamplesToBytes(this SoundPcm pcm, uint samples)
        {
            return SoundNativeMethods.SoundPcmSamplesToBytes(pcm.handle, samples);
        }
    }
}
