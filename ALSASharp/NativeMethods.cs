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

        [DllImport("asound", EntryPoint = "snd_ctl_pcm_info")]
        internal static extern int SoundControlPcmInfo(IntPtr ctl, IntPtr info);

        // SoundPcmInfo

        [DllImport("asound", EntryPoint = "snd_pcm_info_sizeof")]
        internal static extern uint SoundPcmInfoSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_info_malloc")]
        internal static extern int SoundPcmInfoMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_info_free")]
        internal static extern void SoundPcmInfoFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_copy")]
        internal static extern void SoundPcmInfoCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_device")]
        internal static extern uint SoundPcmInfoGetDevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevice")]
        internal static extern uint SoundPcmInfoGetSubdevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_stream")]
        internal static extern SoundPcmStreamType SoundPcmInfoGetStream(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_card")]
        internal static extern int SoundPcmInfoGetCard(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_id")]
        internal static extern IntPtr SoundPcmInfoGetId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_name")]
        internal static extern IntPtr SoundPcmInfoGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevice_name")]
        internal static extern IntPtr SoundPcmInfoGetSubdeviceName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_class")]
        internal static extern SoundPcmClass SoundPcmInfoGetClass(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subclass")]
        internal static extern SoundPcmSubclass SoundPcmInfoGetSubclass(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevices_count")]
        internal static extern uint SoundPcmInfoGetSubdevicesCount(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_subdevices_avail")]
        internal static extern uint SoundPcmInfoGetSubdevicesAvail(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_get_sync")]
        internal static extern SoundPcmSyncId SoundPcmInfoGetSync(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_info_set_device")]
        internal static extern void SoundPcmInfoSetDevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_info_set_subdevice")]
        internal static extern void SoundPcmInfoSetSubdevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_info_set_stream")]
        internal static extern void SoundPcmInfoSetStream(IntPtr obj, SoundPcmStreamType val);

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

        // SoundPcmSubformatMask

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_sizeof")]
        internal static extern uint SoundPcmSubformatMaskSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_malloc")]
        internal static extern int SoundPcmSubformatMaskMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_free")]
        internal static extern void SoundPcmSubformatMaskFree(IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_copy")]
        internal static extern void SoundPcmSubformatMaskCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_none")]
        internal static extern void SoundPcmSubformatMaskNone(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_any")]
        internal static extern void SoundPcmSubformatMaskAny(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_test")]
        internal static extern int SoundPcmSubformatMaskTest(IntPtr mask, SoundPcmSubformat val);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_empty")]
        internal static extern int SoundPcmSubformatMaskEmpty(IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_set")]
        internal static extern void SoundPcmSubformatMaskSet(IntPtr mask, SoundPcmSubformat val);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_mask_reset")]
        internal static extern void SoundPcmSubformatMaskReset(IntPtr mask, SoundPcmSubformat val);

        // SoundHelper

        [DllImport("asound", EntryPoint = "snd_strerror")]
        internal static extern IntPtr SoundStringError(int error);

        [DllImport("asound", EntryPoint = "snd_pcm_type_name")]
        internal static extern IntPtr SoundPcmTypeName(SoundPcmType type);

        [DllImport("asound", EntryPoint = "snd_pcm_stream_name")]
        internal static extern IntPtr SoundPcmStreamName(SoundPcmStreamType stream);

        [DllImport("asound", EntryPoint = "snd_pcm_access_name")]
        internal static extern IntPtr SoundPcmAccessName(SoundPcmAccess access);

        [DllImport("asound", EntryPoint = "snd_pcm_format_name")]
        internal static extern IntPtr SoundPcmFormatName(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_description")]
        internal static extern IntPtr SoundPcmFormatDescription(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_name")]
        internal static extern IntPtr SoundPcmSubformatName(SoundPcmSubformat format);

        [DllImport("asound", EntryPoint = "snd_pcm_subformat_description")]
        internal static extern IntPtr SoundPcmSubformatDescription(SoundPcmSubformat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_value")]
        internal static extern SoundPcmFormat SoundPcmFormatValue(IntPtr name);

        [DllImport("asound", EntryPoint = "snd_pcm_tstamp_mode_name")]
        internal static extern IntPtr SoundPcmTStampModeName(SoundPcmTStamp mode);

        [DllImport("asound", EntryPoint = "snd_pcm_state_name")]
        internal static extern IntPtr SoundPcmStateName(SoundPcmState state);

        [DllImport("asound", EntryPoint = "snd_pcm_format_signed")]
        internal static extern int SoundPcmFormatSigned(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_unsigned")]
        internal static extern int SoundPcmFormatUnsigned(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_linear")]
        internal static extern int SoundPcmFormatLinear(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_float")]
        internal static extern int SoundPcmFormatFloat(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_little_endian")]
        internal static extern int SoundPcmFormatLittleEndian(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_big_endian")]
        internal static extern int SoundPcmFormatBigEndian(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_cpu_endian")]
        internal static extern int SoundPcmFormatCpuEndian(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_width")]
        internal static extern int SoundPcmFormatWidth(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_physical_width")]
        internal static extern int SoundPcmFormatPhysicalWidth(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_build_linear_format")]
        internal static extern SoundPcmFormat SoundPcmBuildLinearFormat(int width, int pwidth,
            [MarshalAs(UnmanagedType.I1)]bool unsigned, [MarshalAs(UnmanagedType.I1)]bool bigEndian);

        [DllImport("asound", EntryPoint = "snd_pcm_format_size")]
        internal static extern uint SoundPcmFormatSize(SoundPcmFormat format, uint samples);

        [DllImport("asound", EntryPoint = "snd_pcm_format_silence")]
        internal static extern byte SoundPcmFormatSilence(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_silence_16")]
        internal static extern ushort SoundPcmFormatSilence16(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_silence_32")]
        internal static extern uint SoundPcmFormatSilence32(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_silence_64")]
        internal static extern ulong SoundPcmFormatSilence64(SoundPcmFormat format);

        [DllImport("asound", EntryPoint = "snd_pcm_format_set_silence")]
        internal static extern byte SoundPcmFormatSetSilence(SoundPcmFormat format, IntPtr buf, uint samples);

        [DllImport("asound", EntryPoint = "snd_pcm_bytes_to_frames")]
        internal static extern byte SoundPcmBytesToFrames(IntPtr pcm, uint bytes);

        [DllImport("asound", EntryPoint = "snd_pcm_frames_to_bytes")]
        internal static extern byte SoundPcmFramesToBytes(IntPtr pcm, uint frames);

        [DllImport("asound", EntryPoint = "snd_pcm_bytes_to_samples")]
        internal static extern byte SoundPcmBytesToSamples(IntPtr pcm, uint bytes);

        [DllImport("asound", EntryPoint = "snd_pcm_samples_to_bytes")]
        internal static extern byte SoundPcmSamplesToBytes(IntPtr pcm, uint samples);

        // SoundPcmSwParams

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_sizeof")]
        internal static extern uint SoundPcmSwParamsSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_malloc")]
        internal static extern int SoundPcmSwParamsMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_free")]
        internal static extern void SoundPcmSwParamsFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_copy")]
        internal static extern void SoundPcmSwParamsCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_boundary")]
        internal static extern int SoundPcmSwParamsGetBoundary(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_tstamp_mode")]
        internal static extern int SoundPcmSwParamsSetTStampMode(IntPtr pcm, IntPtr @params, SoundPcmTStamp val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_tstamp_mode")]
        internal static extern int SoundPcmSwParamsGetTStampMode(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_tstamp_type")]
        internal static extern int SoundPcmSwParamsSetTStampType(IntPtr pcm, IntPtr @params, SoundPcmTStampType val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_tstamp_type")]
        internal static extern int SoundPcmSwParamsGetTStampType(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_avail_min")]
        internal static extern int SoundPcmSwParamsSetAvailMin(IntPtr pcm, IntPtr @params, ulong val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_avail_min")]
        internal static extern int SoundPcmSwParamsGetAvailMin(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_period_event")]
        internal static extern int SoundPcmSwParamsSetPeriodEvent(IntPtr pcm, IntPtr @params, int val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_period_event")]
        internal static extern int SoundPcmSwParamsGetPeriodEvent(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_start_threshold")]
        internal static extern int SoundPcmSwParamsSetStartThreshold(IntPtr pcm, IntPtr @params, ulong val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_start_threshold")]
        internal static extern int SoundPcmSwParamsGetStartThreshold(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_stop_threshold")]
        internal static extern int SoundPcmSwParamsSetStopThreshold(IntPtr pcm, IntPtr @params, ulong val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_stop_threshold")]
        internal static extern int SoundPcmSwParamsGetStopThreshold(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_silence_threshold")]
        internal static extern int SoundPcmSwParamsSetSilenceThreshold(IntPtr pcm, IntPtr @params, ulong val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_silence_threshold")]
        internal static extern int SoundPcmSwParamsGetSilenceThreshold(IntPtr @params, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_silence_size")]
        internal static extern int SoundPcmSwParamsSetSilenceSize(IntPtr pcm, IntPtr @params, ulong val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_silence_size")]
        internal static extern int SoundPcmSwParamsGetSilenceSize(IntPtr @params, IntPtr val);
    }
}
