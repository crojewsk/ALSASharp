using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    /// <summary>
    /// Exposes native alsa-lib methods.
    /// </summary>
    public static class SoundNativeMethods
    {
        // SoundCard

        [DllImport("asound", EntryPoint = "snd_card_next")]
        internal static extern int SoundCardNext(out int card);

        [DllImport("asound", EntryPoint = "snd_device_name_hint")]
        internal static extern int SoundDeviceNameHint(int card, [MarshalAs(UnmanagedType.LPStr)]string iface, out IntPtr hints);

        [DllImport("asound", EntryPoint = "snd_device_name_get_hint")]
        internal static extern IntPtr SoundDeviceNameGetHint([MarshalAs(UnmanagedType.LPStr)]string hint, [MarshalAs(UnmanagedType.LPStr)]string id);

        [DllImport("asound", EntryPoint = "snd_device_name_free_hint")]
        internal static extern int SoundDeviceNameFreeHint(IntPtr hints);

        // SoundControl

        [DllImport("asound", EntryPoint = "snd_ctl_open")]
        internal static extern int SoundControlOpen(out IntPtr ctlp, [MarshalAs(UnmanagedType.LPStr)] string name, int mode);

        [DllImport("asound", EntryPoint = "snd_ctl_close")]
        internal static extern int SoundControlClose(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info")]
        internal static extern int SoundControlCardInfo(IntPtr ctl, IntPtr info);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_malloc")]
        internal static extern int SoundControlCardInfoMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_free")]
        internal static extern void SoundControlCardInfoFree(IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_id")]
        internal static extern IntPtr SoundControlCardInfoGetId(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_name")]
        internal static extern IntPtr SoundControlCardInfoGetName(IntPtr ctl);
      
        [DllImport("asound", EntryPoint = "snd_ctl_pcm_next_device")]
        internal static extern int SoundControlPcmNextDevice(IntPtr ctl, out int device);

        // SoundPcmInfo
      
        [DllImport("asound", EntryPoint = "snd_pcm_info_set_device")]
        internal static extern void SoundPcmInfoSetDevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_info_set_subdevice")]
        internal static extern void SoundPcmInfoSetSubdevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_info_set_stream")]
        internal static extern void SoundPcmInfoSetStream(IntPtr obj, SoundPcmStreamType val);
      
        [DllImport("asound", EntryPoint = "snd_ctl_pcm_info")]
        internal static extern int SoundControlPcmInfo(IntPtr ctl, IntPtr info);      

        [DllImport("asound", EntryPoint = "snd_pcm_info_malloc")]
        internal static extern int SoundPcmInfoMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_info_free")]
        internal static extern void SoundPcmInfoFree(IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_id")]
        internal static extern IntPtr SoundPcmInfoGetId(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_name")]
        internal static extern IntPtr SoundPcmInfoGetName(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevice_name")]
        internal static extern IntPtr SoundPcmInfoGetSubdeviceName(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevices_count")]
        internal static extern uint SoundPcmInfoGetSubdevicesCount(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevices_avail")]
        internal static extern uint SoundPcmInfoGetSubdevicesAvail(IntPtr ctl);

        // SoundExtensionMethods

        [DllImport("asound", EntryPoint = "snd_strerror")]
        internal static extern IntPtr SoundStringError(int error);

        [DllImport("asound", EntryPoint = "snd_pcm_stream_name")]
        internal static extern IntPtr SoundPcmStreamName(SoundPcmStreamType stream);

        // SoundLogger - output

        [DllImport("asound", EntryPoint = "snd_output_buffer_open")]
        internal static extern int SoundOutputBufferOpen(out IntPtr outputp);

        [DllImport("asound", EntryPoint = "snd_output_buffer_string")]
        internal static extern uint SoundOutputBufferString(IntPtr output, out IntPtr buf);

        [DllImport("asound", EntryPoint = "snd_output_close")]
        internal static extern int SoundOutputClose(IntPtr output);

        [DllImport("asound", EntryPoint = "snd_output_flush")]
        internal static extern int SoundOutputFlush(IntPtr output);

        [DllImport("asound", EntryPoint = "snd_output_putc")]
        internal static extern int SoundOutputPutc(IntPtr output, int c);

        [DllImport("asound", EntryPoint = "snd_output_puts")]
        internal static extern int SoundOutputPuts(IntPtr output, string str);

        [DllImport("asound", EntryPoint = "snd_output_stdio_open")]
        internal static extern int SoundOutputStdioOpen(out IntPtr outputp, string file, string mode);

        // SoundPcmAccessMask

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_sizeof")]
        internal static extern uint SoundPcmAccessMaskSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_malloc")]
        internal static extern int SoundPcmAccessMaskMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_free")]
        internal static extern void SoundPcmAccessMaskFree(IntPtr ptr);

		[DllImport("asound", EntryPoint = "snd_pcm_access_mask_copy")]
		internal static extern void SoundPcmAccessMaskCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_none")]
        internal static extern void SoundPcmAccessMaskNone(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_any")]
        internal static extern void SoundPcmAccessMaskAny(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_test")]
        internal static extern int SoundPcmAccessMaskTest(IntPtr mask, SoundPcmAccess val);

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_empty")]
        internal static extern int SoundPcmAccessMaskEmpty(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_access_mask_set")]
        internal static extern void SoundPcmAccessMaskSet(IntPtr mask, SoundPcmAccess val);

		[DllImport("asound", EntryPoint = "snd_pcm_access_mask_reset")]
		internal static extern void SoundPcmAccessMaskReset(IntPtr mask, SoundPcmAccess val);

        // SoundPcmFormatMask

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_sizeof")]
        internal static extern uint SoundPcmFormatMaskSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_malloc")]
        internal static extern int SoundPcmFormatMaskMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_free")]
        internal static extern void SoundPcmFormatMaskFree(IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_copy")]
        internal static extern void SoundPcmFormatMaskCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_none")]
        internal static extern void SoundPcmFormatMaskNone(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_any")]
        internal static extern void SoundPcmFormatMaskAny(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_test")]
        internal static extern int SoundPcmFormatMaskTest(IntPtr mask, SoundPcmFormat val);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_empty")]
        internal static extern int SoundPcmFormatMaskEmpty(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_set")]
        internal static extern void SoundPcmFormatMaskSet(IntPtr mask, SoundPcmFormat val);

        [DllImport("asound", EntryPoint = "snd_pcm_format_mask_reset")]
        internal static extern void SoundPcmFormatMaskReset(IntPtr mask, SoundPcmFormat val);
    }
}
