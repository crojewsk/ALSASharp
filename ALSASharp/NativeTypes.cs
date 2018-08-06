using System;

namespace ALSASharp
{
    // snd_pcm_stream_t
    public enum SoundPcmStreamType
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
        SND_PCM_ACCESS_MMAP_INTERLEAVED,     // mmap access with simple interleaved channels
        SND_PCM_ACCESS_MMAP_NONINTERLEAVED,  // mmap access with simple non interleaved channels
        SND_PCM_ACCESS_MMAP_COMPLEX,         // mmap access with complex placement
        SND_PCM_ACCESS_RW_INTERLEAVED,       // snd_pcm_readi/snd_pcm_writei access
        SND_PCM_ACCESS_RW_NONINTERLEAVED     // snd_pcm_readn/snd_pcm_writen access
    }
}
