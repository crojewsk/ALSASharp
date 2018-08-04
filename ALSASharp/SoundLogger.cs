using System;

namespace ALSASharp
{
    /// <summary>
    /// Simple debug logger. Allows for writing to stdio or memory buffer.
    /// </summary>
    /// <remarks>snd_output_t wrapper.</remarks>
    public class SoundLogger : IDisposable
    {
        /// <summary>
        /// Output type. Determinates SoundLogger behavior.
        /// </summary>
        public enum OutputType
        {
            STDIO,
            BUFFER
        }

		internal IntPtr handle;

        /// <summary>
        /// The filename of file object for STDIO output type. Undefined otherwise.
        /// </summary>
        public readonly string Filename;

        /// <summary>
        /// The type of the logger. Determinates its behavior.
        /// </summary>
        public readonly OutputType LogType;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundLogger"/> class
        /// and opens file with specified filename for writing.
        /// </summary>
        /// <param name="filename">The name of the file to open.</param>
        /// <param name="openMode">The open mode, same as for fopen.</param>
        public SoundLogger(string filename, string openMode)
        {
			if (filename == null)
				throw new ArgumentNullException();

			int err = SoundNativeMethods.SoundOutputStdioOpen(out handle, filename, openMode);
			if (err < 0)
            {
				string message = string.Format("Failed to create new SoundLogger instance: {0}", err);
                throw new InvalidOperationException(message);
            }

			Filename = filename;
            LogType = OutputType.STDIO;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ALSASharp.SoundLogger"/> class
        /// with an auto-extending memory buffer.
        /// </summary>
        public SoundLogger()
        {
            int err = SoundNativeMethods.SoundOutputBufferOpen(out handle);
            if (err < 0)
            {
                string message = string.Format("Failed to create new SoundLogger instance: {0}", err);
                throw new InvalidOperationException(message);
            }

            LogType = OutputType.BUFFER;
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ALSASharp.SoundLogger"/> object.
        /// </summary>
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundOutputClose(handle);
                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Returns the address of the buffer of BUFFER type logger.
        /// </summary>
        /// <returns>The address of the underlying buffer.</returns>
        /// <param name="buf">Handle to store the address of the buffer.</param>
        public uint GetBuffer(out IntPtr buf)
        {
            if (LogType == OutputType.BUFFER)
                return SoundNativeMethods.SoundOutputBufferString(handle, out buf);

            throw new InvalidOperationException(string.Format("Invalid output type: {0}", LogType));
        }

        /// <summary>
        /// Flushes the underlying stream or memory buffer.
        /// Resets the write position of buffer for BUFFER logger type.
        /// </summary>
        /// <returns>Zero if successsful, otherwise EOF.</returns>
        public int Flush()
        {
            return SoundNativeMethods.SoundOutputFlush(handle);
        }

        /// <summary>
        /// Writes a character to logger output.
        /// </summary>
        /// <param name="c">Character to write.</param>
        /// <returns>0 or greater in case of success, EOF or negative error code otherwise.</returns>
        public int Write(char c)
        {
            // positive returns i.e. ret > 0 mark size written?
            return SoundNativeMethods.SoundOutputPutc(handle, c);
        }

        /// <summary>
        /// Writes a string to logger output.
        /// </summary>
        /// <param name="str">String to write.</param>
        /// <returns>0 or greater in case of success, EOF or negative error code otherwise.</returns>
        public int Write(string str)
        {
            // positive returns i.e. ret > 0 mark size written?
            return SoundNativeMethods.SoundOutputPuts(handle, str);
        }
    }
}
