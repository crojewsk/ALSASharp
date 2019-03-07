using System;

namespace ALSASharp
{
    public class SoundPcmHwParams
    {
        internal IntPtr handle;

        public SoundPcmHwParams(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmHwParamsMalloc(out handle);
                if (handle == IntPtr.Zero)
                    throw new OutOfMemoryException();
            }
            else
            {
                handle = ptr;
            }
        }

        public SoundPcmHwParams()
            : this(IntPtr.Zero)
        {
        }

        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                SoundNativeMethods.SoundPcmHwParamsFree(handle);
                handle = IntPtr.Zero;
            }
        }

        public int FillAny(SoundPcm pcm)
        {
            return SoundNativeMethods.SoundPcmHwParamsAny(pcm.handle, handle);
        }

        public int Dump(SoundLogger logger)
        {
            return SoundNativeMethods.SoundPcmHwParamsDump(handle, logger.handle);
        }

        public bool CanMmapSampleResulution()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanMmapSampleResolution(handle);
        }

        public bool IsDouble()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsMonotonic(handle);
        }

        public bool IsBatch()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsBatch(handle);
        }

        public bool IsBlockTransfer()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsBlockTransfer(handle);
        }

        public bool IsMonotonic()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsMonotonic(handle);
        }

        public bool CanOverrange()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanOverrange(handle);
        }

        public bool CanPause()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanPause(handle);
        }

        public bool CanResume()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanResume(handle);
        }

        public bool IsHalfDuplex()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsHalfDuplex(handle);
        }

        public bool IsJointDuplex()
        {
            return SoundNativeMethods.SoundPcmHwParamsIsJointDuplex(handle);
        }

        public bool CanSyncStart()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanSyncStart(handle);
        }

        public bool CanDisablePeriodWakeup()
        {
            return SoundNativeMethods.SoundPcmHwParamsCanDisablePeriodWakeup(handle);
        }

        public bool SupportsAudioWallclockTs()
        {
            return SoundNativeMethods.SoundPcmHwParamsSupportsAudioWallclockTs(handle);
        }

        public bool SupportsAudioTsType(int type)
        {
            return SoundNativeMethods.SoundPcmHwParamsSupportsAudioTsType(handle, type);
        }

        public int GetRateNumden(out uint numerator, out uint denominator)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetRateNumden(handle, out numerator, out denominator);
        }

        public int GetSbits()
        {
            return SoundNativeMethods.SoundPcmHwParamsGetSbits(handle);
        }

        public int GetFifoSize()
        {
            return SoundNativeMethods.SoundPcmHwParamsGetFifoSize(handle);
        }

        public readonly SoundPcmAccessParam Access;
        public readonly SoundPcmFormatParam Format;
        public readonly SoundPcmSubformatParam Subformat;

        public readonly SoundPcmChannelsParam Channels;
        public readonly SoundPcmRateParam Rate;

        public int SetFlag(SoundPcm pcm, SoundPcmHwParamsFlag flag, uint val)
        {
            switch (flag)
            {
            case SoundPcmHwParamsFlag.NORESAMPLE:
                return SoundNativeMethods.SoundPcmHwParamsSetRateResample(pcm.handle, handle, val);

            case SoundPcmHwParamsFlag.EXPORT_BUFFER:
                return SoundNativeMethods.SoundPcmHwParamsSetExportBuffer(pcm.handle, handle, val);

            case SoundPcmHwParamsFlag.NO_PERIOD_WAKEUP:
                return SoundNativeMethods.SoundPcmHwParamsSetPeriodWakeup(pcm.handle, handle, val);

            default:
                throw new NotSupportedException("unknown flag");
            }
        }

        public int GetFlag(SoundPcm pcm, SoundPcmHwParamsFlag flag, out uint val)
        {
            switch (flag)
            {
            case SoundPcmHwParamsFlag.NORESAMPLE:
                return SoundNativeMethods.SoundPcmHwParamsGetRateResample(pcm.handle, handle, out val);

            case SoundPcmHwParamsFlag.EXPORT_BUFFER:
                return SoundNativeMethods.SoundPcmHwParamsGetExportBuffer(pcm.handle, handle, out val);

            case SoundPcmHwParamsFlag.NO_PERIOD_WAKEUP:
                return SoundNativeMethods.SoundPcmHwParamsGetPeriodWakeup(pcm.handle, handle, out val);

            default:
                throw new NotSupportedException("unknown flag");
            }
        }

        public readonly SoundPcmPeriodTimeParam PeriodTime;
        public readonly SoundPcmPeriodSizeParam PeriodSize;
        public readonly SoundPcmPeriodsParam Periods;
        public readonly SoundPcmBufferTimeParam BufferTime;
        public readonly SoundPcmBufferSizeParam BufferSize;

        public int GetMinAlign(out uint value)
        {
            return SoundNativeMethods.SoundPcmHwParamsGetMinAlign(handle, out value);
        }
    }
}
