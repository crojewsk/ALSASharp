using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    // snd_pcm_stream_t
    public enum SoundPcmStream
    {
        Playback,  // Playback stream
        Capture   // Capture stream
    }

    public static class DeviceNameHints
    {
        public const string NAME = "NAME";  // name of device
        public const string DESC = "DESC";  // description of device
        public const string IOID = "IOID";  // input / output identification ("Input" or "Output"), NULL means both
    }

    // snd_pcm_access_t
    public enum SoundPcmAccess
    {
        MMAP_INTERLEAVED,     // mmap access with simple interleaved channels
        MMAP_NONINTERLEAVED,  // mmap access with simple non interleaved channels
        MMAP_COMPLEX,         // mmap access with complex placement
        RW_INTERLEAVED,       // snd_pcm_readi/snd_pcm_writei access
        RW_NONINTERLEAVED     // snd_pcm_readn/snd_pcm_writen access
    }

    // snd_ctl_type_t
    public enum SoundControlType
    {
        Hardware,      // Kernel level CTL
        SharedMemory,  // Shared memory client CTL
        INET,          // INET client CTL (not yet implemented)
        External       // External control plugin
    }

    // snd_ctl_elem_iface_t
    public enum SoundControlElementIface
    {
        CARD = 0,   // Card level
        HWDEP,      // Hardware dependent device
        MIXER,      // Mixer
        PCM,        // PCM
        RAWMIDI,    // RawMidi
        TIMER,      // Timer
        SEQUENCER,  // Sequencer
    }

    // snd_pcm_format_t
    public enum SoundPcmFormat
    {
        UNKNOWN = -1,  // Unknown
        S8 = 0,   // Signed 8 bit
        U8,   // Unsigned 8 bit
        S16_LE,   // Signed 16 bit Little Endian
        S16_BE,   // Signed 16 bit Big Endian
        U16_LE,   // Unsigned 16 bit Little Endian
        U16_BE,   // Unsigned 16 bit Big Endian
        S24_LE,   // Signed 24 bit Little Endian using low three bytes in 32-bit word
        S24_BE,   // Signed 24 bit Big Endian using low three bytes in 32-bit word
        U24_LE,   // Unsigned 24 bit Little Endian using low three bytes in 32-bit word
        U24_BE,   // Unsigned 24 bit Big Endian using low three bytes in 32-bit word
        S32_LE,   // Signed 32 bit Little Endian
        S32_BE,   // Signed 32 bit Big Endian
        U32_LE,   // Unsigned 32 bit Little Endian
        U32_BE,   // Unsigned 32 bit Big Endian
        FLOAT_LE,     // Float 32 bit Little Endian, Range -1.0 to 1.0
        FLOAT_BE,     // Float 32 bit Big Endian, Range -1.0 to 1.0
        FLOAT64_LE,   // Float 64 bit Little Endian, Range -1.0 to 1.0
        FLOAT64_BE,   // Float 64 bit Big Endian, Range -1.0 to 1.0
        IEC958_SUBFRAME_LE,   // IEC-958 Little Endian
        IEC958_SUBFRAME_BE,   // IEC-958 Big Endian
        MU_LAW,   // Mu-Law
        A_LAW,    // A-Law
        IMA_ADPCM,    // Ima-ADPCM
        MPEG,     // MPEG
        GSM,  // GSM
        SPECIAL = 31,  // Special
        S24_3LE = 32,  // Signed 24bit Little Endian in 3bytes format
        S24_3BE,  // Signed 24bit Big Endian in 3bytes format
        U24_3LE,  // Unsigned 24bit Little Endian in 3bytes format
        U24_3BE,  // Unsigned 24bit Big Endian in 3bytes format
        S20_3LE,  // Signed 20bit Little Endian in 3bytes format
        S20_3BE,  // Signed 20bit Big Endian in 3bytes format
        U20_3LE,  // Unsigned 20bit Little Endian in 3bytes format
        U20_3BE,  // Unsigned 20bit Big Endian in 3bytes format
        S18_3LE,  // Signed 18bit Little Endian in 3bytes format
        S18_3BE,  // Signed 18bit Big Endian in 3bytes format
        U18_3LE,  // Unsigned 18bit Little Endian in 3bytes format
        U18_3BE,  // Unsigned 18bit Big Endian in 3bytes format
        G723_24, // G.723 (ADPCM) 24 kbit/s, 8 samples in 3 bytes
        G723_24_1B, // G.723 (ADPCM) 24 kbit/s, 1 sample in 1 byte
        G723_40, // G.723 (ADPCM) 40 kbit/s, 8 samples in 3 bytes
        G723_40_1B, // G.723 (ADPCM) 40 kbit/s, 1 sample in 1 byte
        DSD_U8, // Direct Stream Digital (DSD) in 1-byte samples (x8)
        DSD_U16_LE,// Direct Stream Digital (DSD) in 2-byte samples (x16)
        DSD_U32_LE, // Direct Stream Digital (DSD) in 4-byte samples (x32)
        DSD_U16_BE, // Direct Stream Digital (DSD) in 2-byte samples (x16)
        DSD_U32_BE // Direct Stream Digital (DSD) in 4-byte samples (x32)
    }

    /// <summary>
    /// Collection of convenient <see cref="SoundPcmFormat"/> enumeration constants.
    /// </summary>
    public static class SoundPcmFormats
    {
        public static readonly SoundPcmFormat S16; // Signed 16 bit CPU endian
        public static readonly SoundPcmFormat U16; // Unsigned 16 bit CPU endian
        public static readonly SoundPcmFormat S24; // Signed 24 bit CPU endian
        public static readonly SoundPcmFormat U24; // Unsigned 24 bit CPU endian
        public static readonly SoundPcmFormat S32; // Signed 32 bit CPU endian
        public static readonly SoundPcmFormat U32; // Unsigned 32 bit CPU endian
        public static readonly SoundPcmFormat FLOAT; // Float 32 bit CPU endian
        public static readonly SoundPcmFormat FLOAT64; // Float 64 bit CPU endian
        public static readonly SoundPcmFormat IEC958_SUBFRAME; // IEC-958 CPU Endian

        static SoundPcmFormats()
        {
            if (BitConverter.IsLittleEndian)
            {
                S16 = SoundPcmFormat.S16_LE;
                U16 = SoundPcmFormat.U16_LE;
                S24 = SoundPcmFormat.S24_LE;
                U24 = SoundPcmFormat.U24_LE;
                S32 = SoundPcmFormat.S32_LE;
                U32 = SoundPcmFormat.U32_LE;
                FLOAT = SoundPcmFormat.FLOAT_LE;
                FLOAT64 = SoundPcmFormat.FLOAT64_LE;
                IEC958_SUBFRAME = SoundPcmFormat.IEC958_SUBFRAME_LE;
            }
            else
            {
                S16 = SoundPcmFormat.S16_BE;
                U16 = SoundPcmFormat.U16_BE;
                S24 = SoundPcmFormat.S24_BE;
                U24 = SoundPcmFormat.U24_BE;
                S32 = SoundPcmFormat.S32_BE;
                U32 = SoundPcmFormat.U32_BE;
                FLOAT = SoundPcmFormat.FLOAT_BE;
                FLOAT64 = SoundPcmFormat.FLOAT64_BE;
                IEC958_SUBFRAME = SoundPcmFormat.IEC958_SUBFRAME_BE;
            }
        }
    }

    // snd_pcm_subformat_t
    public enum SoundPcmSubformat
    {
        STD // Standard
    }

    // snd_pcm_type_t
    public enum SoundPcmType
    {
        HW,     // Kernel level PCM
        HOOKS,  // Hooked PCM
        MULTI,  // One or more linked PCM with exclusive access to selected channels
        FILE,   // File writing plugin
        NULL,   // Null endpoint PCM
        SHM,    // Shared memory client PCM
        INET,   // INET client PCM (not yet implemented)
        COPY,   // Copying plugin
        LINEAR,     // Linear format conversion PCM
        ALAW,   // A-Law format conversion PCM
        MULAW,  // Mu-Law format conversion PCM
        ADPCM,  // IMA-ADPCM format conversion PCM
        RATE,   // Rate conversion PCM
        ROUTE,  // Attenuated static route PCM
        PLUG,   // Format adjusted PCM
        SHARE,  // Sharing PCM
        METER,  // Meter plugin
        MIX,    // Mixing PCM
        DROUTE,     // Attenuated dynamic route PCM (not yet implemented)
        LBSERVER,   // Loopback server plugin (not yet implemented)
        LINEAR_FLOAT,   // Linear Integer <-> Linear Float format conversion PCM
        LADSPA,     // LADSPA integration plugin
        DMIX,   // Direct Mixing plugin
        JACK,   // Jack Audio Connection Kit plugin
        DSNOOP,     // Direct Snooping plugin
        DSHARE,     // Direct Sharing plugin
        IEC958,     // IEC958 subframe plugin
        SOFTVOL,    // Soft volume plugin
        IOPLUG,     // External I/O plugin
        EXTPLUG,    // External filter plugin
        MMAP_EMUL   // Mmap-emulation plugin
    }

    // snd_pcm_tstamp_t
    public enum SoundPcmTStamp
    {
        NONE,  // No timestamp
        ENABLE,  // Update timestamp at every hardware position update
        MMAP  // Equivalent with SND_PCM_TSTAMP_ENABLE, just for compatibility with older versions
    }

    // snd_pcm_tstamp_type_t
    public enum SoundPcmTStampType
    {
        GETTIMEOFDAY,    // gettimeofday equivalent
        MONOTONIC,   // posix_clock_monotonic equivalent
        MONOTONIC_RAW   // monotonic_raw (no NTP)
    }

    // snd_pcm_state_t
    public enum SoundPcmState
    {
        OPEN,  // Open
        SETUP,     // Setup installed
        PREPARED,  // Ready to start
        RUNNING,   // Running
        XRUN,  // Stopped: underrun (playback) or overrun (capture) detected
        DRAINING,  // Draining: running (playback) or stopped (capture)
        PAUSED,    // Paused
        SUSPENDED,     // Hardware is suspended
        DISCONNECTED,  // Hardware is disconnected
        PRIVATE1  // Private - used internally in the library - do not use
    }

    // snd_pcm_class_t
    public enum SoundPcmClass
    {
        GENERIC,   // standard device
        MULTI,     // multichannel device
        MODEM,     // software modem device
        DIGITIZER     // digitizer device
    }

    // snd_pcm_subclass_t
    public enum SoundPcmSubclass
    {
        GENERIC_MIX,    // subdevices are mixed together
        MULTI_MIX  // multichannel subdevices are mixed together
    }

    // snd_pcm_sync_id_t
    [StructLayout(LayoutKind.Explicit)]
    public struct SoundPcmSyncId
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte[] id;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        ushort[] id16;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        uint[] id32;
    }

    // snd_timestamp_t aka timeval
    [StructLayout(LayoutKind.Sequential)]
    public struct SoundTimeStamp
    {
        public long tvSec;     /* seconds */
        public int tvUsec;    /* microseconds */
    }

    // snd_htimestamp_t aka timespec
    [StructLayout(LayoutKind.Sequential)]
    public struct SoundHTimeStamp
    {
        public long tvSec;     /* seconds */
        public int tvNsec;    /* nanoseconds */
    }

    // snd_pcm_audio_tstamp_report_t;
    [StructLayout(LayoutKind.Explicit)]
    public struct SoundPcmAudioTStampReport
    {
        [FieldOffset(0)]
        private uint valid;

        [FieldOffset(0)]
        private uint actualType;

        [FieldOffset(0)]
        private uint accuracyReport;

        [FieldOffset(4)]
        public uint Accuracy;

        public uint Valid
        {
            get
            {
                return valid & 0x1;
            }
        }

        public uint ActualType
        {
            get
            {
                return (actualType >> 1) & 0xF;
            }
        }

        public uint AccuracyReport
        {
            get
            {
                return (actualType >> 5) & 0x1;
            }
        }
    }

    // snd_pcm_audio_tstamp_config_t;
    [StructLayout(LayoutKind.Explicit)]
    public struct SoundPcmAudioTStampConfig
    {
        [FieldOffset(0)]
        private uint typeRequested;

        [FieldOffset(0)]
        private uint reportDelay;

        public uint TypeRequested
        {
            get
            {
                return typeRequested & 0xF;
            }
        }

        public uint ReportDelay
        {
            get
            {
                return (reportDelay >> 4) & 0x1;
            }
        }
    }
}
