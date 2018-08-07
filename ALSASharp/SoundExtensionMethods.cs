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
