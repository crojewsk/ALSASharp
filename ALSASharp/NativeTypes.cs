
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
}