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

    }
}
