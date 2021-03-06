﻿using System;
using System.Runtime.InteropServices;

namespace ALSASharp
{
    /// <summary>
    /// Exposes native alsa-lib methods.
    /// </summary>
    public static class SoundNativeMethods
    {
        [DllImport("asound", EntryPoint = "snd_ctl_elem_type_name")]
        internal static extern IntPtr SoundControlElementTypeName(SoundControlElementType val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_iface_name")]
        internal static extern IntPtr SoundControlElementIfaceName(SoundControlElementIface val);

        [DllImport("asound", EntryPoint = "snd_ctl_event_type_name")]
        internal static extern IntPtr SoundControlEventTypeName(SoundControlEventType val);

        // SoundCard

        [DllImport("asound", EntryPoint = "snd_card_load")]
        internal static extern bool SoundCardLoad(int card);

        [DllImport("asound", EntryPoint = "snd_card_next")]
        internal static extern int SoundCardNext(out int card);

        [DllImport("asound", EntryPoint = "snd_card_get_index")]
        internal static extern int SoundCardGetIndex(IntPtr name);

        [DllImport("asound", EntryPoint = "snd_card_get_name")]
        internal static extern int SoundCardGetName(int card, out IntPtr name);

        [DllImport("asound", EntryPoint = "snd_card_get_longname")]
        internal static extern int SoundCardGetLongname(int card, out IntPtr name);

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
        internal static extern int SoundControlCardInfo(IntPtr ctl, out IntPtr info);

        [DllImport("asound", EntryPoint = "snd_ctl_pcm_next_device")]
        internal static extern int SoundControlPcmNextDevice(IntPtr ctl, out int device);

        [DllImport("asound", EntryPoint = "snd_ctl_pcm_info")]
        internal static extern int SoundControlPcmInfo(IntPtr ctl, IntPtr info);

        [DllImport("asound", EntryPoint = "snd_ctl_nonblock")]
        internal static extern int SoundControlNonblock(IntPtr ctl, int nonblock);

        [DllImport("asound", EntryPoint = "snd_ctl_poll_descriptors_count")]
        internal static extern int SoundControlPollDescriptorsCount(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_ctl_subscribe_events")]
        internal static extern int SoundControlSubscribeEvents(IntPtr ctl, int subscribe);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list")]
        internal static extern int SoundControlElementList(IntPtr ctl, out IntPtr list);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info")]
        internal static extern int SoundControlElementInfo(IntPtr ctl, out IntPtr info);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_read")]
        internal static extern int SoundControlElementRead(IntPtr ctl, out IntPtr data);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_write")]
        internal static extern int SoundControlElementWrite(IntPtr ctl, out IntPtr data);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_lock")]
        internal static extern int SoundControlElementLock(IntPtr ctl, out IntPtr id);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_unlock")]
        internal static extern int SoundControlElementUnlock(IntPtr ctl, out IntPtr id);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_tlv_read")]
        internal static extern int SoundControlElementTLVRead(IntPtr ctl, IntPtr id, uint[] tlv, uint tlvSize);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_tlv_write")]
        internal static extern int SoundControlElementTLVWrite(IntPtr ctl, IntPtr id, uint[] tlv);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_tlv_command")]
        internal static extern int SoundControlElementTLVCommand(IntPtr ctl, IntPtr id, uint[] tlv);

        [DllImport("asound", EntryPoint = "snd_ctl_set_power_state")]
        internal static extern int SoundControlSetPowerState(IntPtr ctl, uint state);

        [DllImport("asound", EntryPoint = "snd_ctl_get_power_state")]
        internal static extern int SoundControlGetPowerState(IntPtr ctl, out uint state);

        [DllImport("asound", EntryPoint = "snd_ctl_read")]
        internal static extern int SoundControlRead(IntPtr ctl, IntPtr evt);

        [DllImport("asound", EntryPoint = "snd_ctl_wait")]
        internal static extern int SoundControlWait(IntPtr ctl, int timeout);

        [DllImport("asound", EntryPoint = "snd_ctl_name")]
        internal static extern IntPtr SoundControlName(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_ctl_type")]
        internal static extern SoundControlType SoundControlType(IntPtr ctl);

        [DllImport("asound", EntryPoint = "snd_ctl_get_dB_range")]
        internal static extern int SoundControlGetdBRange(IntPtr ctl, ref IntPtr id, out int min, out int max);

        [DllImport("asound", EntryPoint = "snd_ctl_convert_to_dB")]
        internal static extern int SoundControlConvertTodB(IntPtr ctl, ref IntPtr id, int volume, out int gain);

        [DllImport("asound", EntryPoint = "snd_ctl_convert_from_dB")]
        internal static extern int SoundControlConvertFromdB(IntPtr ctl, ref IntPtr id, int dBGain, out int value, int xdir);

        // SoundControlEvent

        [DllImport("asound", EntryPoint = "snd_ctl_event_sizeof")]
        internal static extern uint SoundControlEventSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_event_malloc")]
        internal static extern int SoundControlEventMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_event_free")]
        internal static extern void SoundControlEventFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_clear")]
        internal static extern void SoundControlEventClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_copy")]
        internal static extern void SoundControlEventCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_event_get_type")]
        internal static extern SoundControlEventType SoundControlEventGetType(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_mask")]
        internal static extern uint SoundControlEventElementGetMask(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_id")]
        internal static extern void SoundControlEventElementGetId(IntPtr obj, out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_numid")]
        internal static extern uint SoundControlEventElementGetNumId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_interface")]
        internal static extern SoundControlElementIface SoundControlEventElementGetInterface(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_device")]
        internal static extern uint SoundControlEventElementGetDevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_subdevice")]
        internal static extern uint SoundControlEventElementGetSubdevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_name")]
        internal static extern IntPtr SoundControlEventElementGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_event_elem_get_index")]
        internal static extern uint SoundControlEventElementGetIndex(IntPtr obj);

        // SoundControlElementId

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_sizeof")]
        internal static extern uint SoundControlElementIdSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_malloc")]
        internal static extern int SoundControlElementIdMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_free")]
        internal static extern void SoundControlElementIdFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_clear")]
        internal static extern void SoundControlElementIdClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_copy")]
        internal static extern void SoundControlElementIdCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_numid")]
        internal static extern uint SoundControlElementIdGetNumId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_numid")]
        internal static extern void SoundControlElementIdSetNumId(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_interface")]
        internal static extern SoundControlElementIface SoundControlElementIdGetInterface(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_interface")]
        internal static extern void SoundControlElementIdSetInterface(IntPtr obj, SoundControlElementIface val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_device")]
        internal static extern uint SoundControlElementIdGetDevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_device")]
        internal static extern void SoundControlElementIdSetDevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_subdevice")]
        internal static extern uint SoundControlElementIdGetSubdevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_subdevice")]
        internal static extern void SoundControlElementIdSetSubdevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_name")]
        internal static extern IntPtr SoundControlElementIdGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_name")]
        internal static extern void SoundControlElementIdSetName(IntPtr obj, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_get_index")]
        internal static extern uint SoundControlElementIdGetIndex(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_id_set_index")]
        internal static extern void SoundControlElementIdSetIndex(IntPtr obj, uint val);

        // SoundControlCardInfo

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_sizeof")]
        internal static extern uint SoundControlCardInfoSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_malloc")]
        internal static extern int SoundControlCardInfoMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_free")]
        internal static extern void SoundControlCardInfoFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_clear")]
        internal static extern void SoundControlCardInfoClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_copy")]
        internal static extern void SoundControlCardInfoCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_card")]
        internal static extern int SoundControlCardInfoGetCard(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_id")]
        internal static extern IntPtr SoundControlCardInfoGetId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_driver")]
        internal static extern IntPtr SoundControlCardInfoGetDriver(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_name")]
        internal static extern IntPtr SoundControlCardInfoGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_longname")]
        internal static extern IntPtr SoundControlCardInfoGetLongname(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_mixername")]
        internal static extern IntPtr SoundControlCardInfoGetMixername(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_card_info_get_components")]
        internal static extern IntPtr SoundControlCardInfoGetComponents(IntPtr obj);

        // SoundControlElementList

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_sizeof")]
        internal static extern uint SoundControlElementListSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_malloc")]
        internal static extern int SoundControlElementListMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_free")]
        internal static extern void SoundControlElementListFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_clear")]
        internal static extern void SoundControlElementListClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_copy")]
        internal static extern void SoundControlElementListCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_set_offset")]
        internal static extern void SoundControlElementListSetOffset(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_used")]
        internal static extern uint SoundControlElementListGetUsed(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_count")]
        internal static extern uint SoundControlElementListGetCount(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_id")]
        internal static extern void SoundControlElementListGetId(IntPtr obj, uint idx, out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_numid")]
        internal static extern uint SoundControlElementListGetNumId(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_interface")]
        internal static extern SoundControlElementIface SoundControlElementListGetInterface(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_device")]
        internal static extern uint SoundControlElementListGetDevice(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_subdevice")]
        internal static extern uint SoundControlElementListGetSubdevice(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_name")]
        internal static extern IntPtr SoundControlElementListGetName(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_list_get_index")]
        internal static extern uint SoundControlElementListGetIndex(IntPtr obj, uint idx);

        // SoundControlElementInfo

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_sizeof")]
        internal static extern uint SoundControlElementInfoSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_malloc")]
        internal static extern int SoundControlElementInfoMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_free")]
        internal static extern void SoundControlElementInfoFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_clear")]
        internal static extern void SoundControlElementInfoClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_copy")]
        internal static extern void SoundControlElementInfoCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_type")]
        internal static extern SoundControlElementType SoundControlElementInfoGetType(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_readable")]
        internal static extern bool SoundControlElementInfoIsReadable(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_writable")]
        internal static extern bool SoundControlElementInfoIsWritable(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_volatile")]
        internal static extern bool SoundControlElementInfoIsVolatile(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_inactive")]
        internal static extern bool SoundControlElementInfoIsInactive(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_locked")]
        internal static extern bool SoundControlElementInfoIsLocked(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_tlv_readable")]
        internal static extern bool SoundControlElementInfoIsTLVReadable(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_tlv_writable")]
        internal static extern bool SoundControlElementInfoIsTLVWritable(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_tlv_commandable")]
        internal static extern bool SoundControlElementInfoIsTLVCommandable(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_owner")]
        internal static extern bool SoundControlElementInfoIsOwner(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_is_user")]
        internal static extern bool SoundControlElementInfoIsUser(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_owner")]
        internal static extern int SoundControlElementInfoGetOwner(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_count")]
        internal static extern uint SoundControlElementInfoGetCount(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_min")]
        internal static extern int SoundControlElementInfoGetMin(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_max")]
        internal static extern int SoundControlElementInfoGetMax(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_step")]
        internal static extern int SoundControlElementInfoGetStep(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_min64")]
        internal static extern long SoundControlElementInfoGetMin64(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_max64")]
        internal static extern long SoundControlElementInfoGetMax64(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_step64")]
        internal static extern long SoundControlElementInfoGetStep64(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_items")]
        internal static extern uint SoundControlElementInfoGetItems(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_item")]
        internal static extern void SoundControlElementInfoSetItem(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_item_name")]
        internal static extern IntPtr SoundControlElementInfoGetItemName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_dimensions")]
        internal static extern int SoundControlElementInfoGetDimensions(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_dimension")]
        internal static extern int SoundControlElementInfoGetDimension(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_dimension")]
        internal static extern int SoundControlElementInfoSetDimension(IntPtr obj, uint[] dimension);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_id")]
        internal static extern void SoundControlElementInfoGetId(IntPtr obj, out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_id")]
        internal static extern void SoundControlElementInfoSetId(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_numid")]
        internal static extern uint SoundControlElementInfoGetNumId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_numid")]
        internal static extern void SoundControlElementInfoSetNumId(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_interface")]
        internal static extern SoundControlElementIface SoundControlElementInfoGetInterface(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_interface")]
        internal static extern void SoundControlElementInfoSetInterface(IntPtr obj, SoundControlElementIface val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_device")]
        internal static extern uint SoundControlElementInfoGetDevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_device")]
        internal static extern void SoundControlElementInfoSetDevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_subdevice")]
        internal static extern uint SoundControlElementInfoGetSubdevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_subdevice")]
        internal static extern void SoundControlElementInfoSetSubdevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_name")]
        internal static extern IntPtr SoundControlElementInfoGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_name")]
        internal static extern void SoundControlElementInfoSetName(IntPtr obj, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_get_index")]
        internal static extern uint SoundControlElementInfoGetIndex(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_info_set_index")]
        internal static extern void SoundControlElementInfoSetIndex(IntPtr obj, uint val);

        // SoundControlElementValue

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_sizeof")]
        internal static extern uint SoundControlElementValueSizeOf();

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_malloc")]
        internal static extern int SoundControlElementValueMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_free")]
        internal static extern void SoundControlElementValueFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_clear")]
        internal static extern void SoundControlElementValueClear(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_copy")]
        internal static extern void SoundControlElementValueCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_compare")]
        internal static extern int SoundControlElementValueCompare(IntPtr left, IntPtr right);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_id")]
        internal static extern void SoundControlElementValueGetId(IntPtr obj, out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_id")]
        internal static extern void SoundControlElementValueSetId(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_numid")]
        internal static extern uint SoundControlElementValueGetNumId(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_numid")]
        internal static extern void SoundControlElementValueSetNumId(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_interface")]
        internal static extern SoundControlElementIface SoundControlElementValueGetInterface(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_interface")]
        internal static extern void SoundControlElementValueSetInterface(IntPtr obj, SoundControlElementIface val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_device")]
        internal static extern uint SoundControlElementValueGetDevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_device")]
        internal static extern void SoundControlElementValueSetDevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_subdevice")]
        internal static extern uint SoundControlElementValueGetSubdevice(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_subdevice")]
        internal static extern void SoundControlElementValueSetSubdevice(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_name")]
        internal static extern IntPtr SoundControlElementValueGetName(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_name")]
        internal static extern void SoundControlElementValueSetName(IntPtr obj, IntPtr val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_index")]
        internal static extern uint SoundControlElementValueGetIndex(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_index")]
        internal static extern void SoundControlElementValueSetIndex(IntPtr obj, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_boolean")]
        internal static extern bool SoundControlElementValueGetBoolean(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_boolean")]
        internal static extern void SoundControlElementValueSetBoolean(IntPtr obj, uint idx, bool val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_integer")]
        internal static extern int SoundControlElementValueGetInteger(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_integer")]
        internal static extern void SoundControlElementValueSetInteger(IntPtr obj, uint idx, int val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_integer64")]
        internal static extern long SoundControlElementValueGetInteger64(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_integer64")]
        internal static extern void SoundControlElementValueSetInteger64(IntPtr obj, uint idx, long val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_enumerated")]
        internal static extern uint SoundControlElementValueGetEnumerated(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_enumerated")]
        internal static extern void SoundControlElementValueSetEnumerated(IntPtr obj, uint idx, uint val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_byte")]
        internal static extern byte SoundControlElementValueGetByte(IntPtr obj, uint idx);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_set_byte")]
        internal static extern void SoundControlElementValueSetByte(IntPtr obj, uint idx, byte val);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_value_get_bytes")]
        internal static extern IntPtr SoundControlElementValueGetBytes(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_ctl_elem_set_bytes")]
        internal static extern void SoundControlElementSetBytes(IntPtr obj, IntPtr data, uint size);

        // SoundPcm

        [DllImport("asound", EntryPoint = "snd_pcm_open")]
        internal static extern int SoundPcmOpen(out IntPtr pcm, string name, SoundPcmStream stream, SoundPcmOpenMode mode);

        [DllImport("asound", EntryPoint = "snd_pcm_open_lconf")]
        internal static extern int SoundPcmOpenLconf(out IntPtr pcm, string name, SoundPcmStream stream, SoundPcmOpenMode mode, IntPtr lconf);

        [DllImport("asound", EntryPoint = "snd_pcm_open_fallback")]
        internal static extern int SoundPcmOpenFallback(out IntPtr pcm, IntPtr root, string name, string origName, SoundPcmStream stream, SoundPcmOpenMode mode);

        [DllImport("asound", EntryPoint = "snd_pcm_close")]
        internal static extern int SoundPcmClose(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_name")]
        internal static extern IntPtr SoundPcmName(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_type")]
        internal static extern SoundPcmType SoundPcmType(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_stream")]
        internal static extern SoundPcmStream SoundPcmStream(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_nonblock")]
        internal static extern int SoundPcmNonblock(IntPtr pcm, int nonblock);

        [DllImport("asound", EntryPoint = "snd_pcm_info")]
        internal static extern int SoundPcmInfo(IntPtr pcm, IntPtr info);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_current")]
        internal static extern int SoundPcmHwParamsCurrent(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params")]
        internal static extern int SoundPcmHwParams(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_free")]
        internal static extern int SoundPcmHwFree(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_current")]
        internal static extern int SoundPcmSwParamsCurrent(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params")]
        internal static extern int SoundPcmSwParams(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_prepare")]
        internal static extern int SoundPcmPrepare(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_reset")]
        internal static extern int SoundPcmReset(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_status")]
        internal static extern int SoundPcmStatus(IntPtr pcm, IntPtr status);

        [DllImport("asound", EntryPoint = "snd_pcm_start")]
        internal static extern int SoundPcmStart(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_drop")]
        internal static extern int SoundPcmDrop(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_drain")]
        internal static extern int SoundPcmDrain(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_pause")]
        internal static extern int SoundPcmPause(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_state")]
        internal static extern SoundPcmState SoundPcmState(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_hwsync")]
        internal static extern int SoundPcmHwSync(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_delay")]
        internal static extern int SoundPcmDelay(IntPtr pcm, out int delayp);

        [DllImport("asound", EntryPoint = "snd_pcm_resume")]
        internal static extern int SoundPcmResume(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_htimestamp")]
        internal static extern int SoundPcmHTimestamp(IntPtr pcm, out int avail, IntPtr tstamp);

        [DllImport("asound", EntryPoint = "snd_pcm_avail")]
        internal static extern int SoundPcmAvail(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_avail_update")]
        internal static extern int SoundPcmAvailUpdate(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_avail_delay")]
        internal static extern int SoundPcmAvailDelay(IntPtr pcm, out int availp, out int delayp);

        [DllImport("asound", EntryPoint = "snd_pcm_rewindable")]
        internal static extern int SoundPcmRewindable(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_rewind")]
        internal static extern int SoundPcmRewind(IntPtr pcm, int frames);

        [DllImport("asound", EntryPoint = "snd_pcm_forwardable")]
        internal static extern int SoundPcmForwardable(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_forward")]
        internal static extern int SoundPcmForward(IntPtr pcm, int frames);

        [DllImport("asound", EntryPoint = "snd_pcm_writei")]
        internal static extern int SoundPcmWriteI(IntPtr pcm, IntPtr buffer, int size);

        [DllImport("asound", EntryPoint = "snd_pcm_readi")]
        internal static extern int SoundPcmReadI(IntPtr pcm, IntPtr buffer, int size);

        [DllImport("asound", EntryPoint = "snd_pcm_writen")]
        internal static extern int SoundPcmWriteN(IntPtr pcm, out IntPtr bufs, int size);

        [DllImport("asound", EntryPoint = "snd_pcm_readn")]
        internal static extern int SoundPcmReadN(IntPtr pcm, out IntPtr bufs, int size);

        [DllImport("asound", EntryPoint = "snd_pcm_wait")]
        internal static extern int SoundPcmWait(IntPtr pcm, int timeout);

        [DllImport("asound", EntryPoint = "snd_pcm_link")]
        internal static extern int SoundPcmLink(IntPtr pcm1, IntPtr pcm2);

        [DllImport("asound", EntryPoint = "snd_pcm_unlink")]
        internal static extern int SoundPcmUnlink(IntPtr pcm);

        [DllImport("asound", EntryPoint = "snd_pcm_recover")]
        internal static extern int SoundPcmRecover(IntPtr pcm, int err, int silent);

        [DllImport("asound", EntryPoint = "snd_pcm_set_params")]
        internal static extern int SoundPcmSetParams(IntPtr pcm, SoundPcmFormat format, SoundPcmAccess access, uint channels, uint rate, int softResample, uint latency);

        [DllImport("asound", EntryPoint = "snd_pcm_get_params")]
        internal static extern int SoundPcmGetParams(IntPtr pcm, out int bufferSize, out int periodSize);

        [DllImport("asound", EntryPoint = "snd_pcm_mmap_begin")]
        internal static extern int SoundPcmMmapBegin(IntPtr pcm, out IntPtr areas, out uint offset, ref uint frames);

        [DllImport("asound", EntryPoint = "snd_pcm_mmap_commit")]
        internal static extern int SoundPcmMmapCommit(IntPtr pcm, uint offset, uint frames);

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
        internal static extern SoundPcmStream SoundPcmInfoGetStream(IntPtr obj);

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
        internal static extern void SoundPcmInfoSetStream(IntPtr obj, SoundPcmStream val);

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
        internal static extern IntPtr SoundPcmStreamName(SoundPcmStream stream);

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
        internal static extern int SoundPcmSwParamsGetBoundary(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_tstamp_mode")]
        internal static extern int SoundPcmSwParamsSetTStampMode(IntPtr pcm, IntPtr @params, SoundPcmTStamp val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_tstamp_mode")]
        internal static extern int SoundPcmSwParamsGetTStampMode(IntPtr @params, out SoundPcmTStamp val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_tstamp_type")]
        internal static extern int SoundPcmSwParamsSetTStampType(IntPtr pcm, IntPtr @params, SoundPcmTStampType val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_tstamp_type")]
        internal static extern int SoundPcmSwParamsGetTStampType(IntPtr @params, out SoundPcmTStampType val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_avail_min")]
        internal static extern int SoundPcmSwParamsSetAvailMin(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_avail_min")]
        internal static extern int SoundPcmSwParamsGetAvailMin(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_period_event")]
        internal static extern int SoundPcmSwParamsSetPeriodEvent(IntPtr pcm, IntPtr @params, int val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_period_event")]
        internal static extern int SoundPcmSwParamsGetPeriodEvent(IntPtr @params, out int val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_start_threshold")]
        internal static extern int SoundPcmSwParamsSetStartThreshold(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_start_threshold")]
        internal static extern int SoundPcmSwParamsGetStartThreshold(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_stop_threshold")]
        internal static extern int SoundPcmSwParamsSetStopThreshold(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_stop_threshold")]
        internal static extern int SoundPcmSwParamsGetStopThreshold(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_silence_threshold")]
        internal static extern int SoundPcmSwParamsSetSilenceThreshold(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_silence_threshold")]
        internal static extern int SoundPcmSwParamsGetSilenceThreshold(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_set_silence_size")]
        internal static extern int SoundPcmSwParamsSetSilenceSize(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_sw_params_get_silence_size")]
        internal static extern int SoundPcmSwParamsGetSilenceSize(IntPtr @params, out uint val);

        // SoundPcmStatus

        [DllImport("asound", EntryPoint = "snd_pcm_status_sizeof")]
        internal static extern uint SoundPcmStatusSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_status_malloc")]
        internal static extern int SoundPcmStatusMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_free")]
        internal static extern void SoundPcmStatusFree(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_status_copy")]
        internal static extern void SoundPcmStatusCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_state")]
        internal static extern SoundPcmState SoundPcmStatusGetState(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_trigger_tstamp")]
        internal static extern void SoundPcmStatusGetTriggerTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_trigger_htstamp")]
        internal static extern void SoundPcmStatusGetTriggerHTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_tstamp")]
        internal static extern void SoundPcmStatusGetTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_htstamp")]
        internal static extern void SoundPcmStatusGetHTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_audio_htstamp")]
        internal static extern void SoundPcmStatusGetAudioHTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_driver_htstamp")]
        internal static extern void SoundPcmStatusGetDriverHTStamp(IntPtr obj, IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_audio_htstamp_report")]
        internal static extern void SoundPcmStatusGetAudioHTReport(IntPtr obj, IntPtr audioTStampReport);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_audio_htstamp_config")]
        internal static extern void SoundPcmStatusGetAudioHTConfig(IntPtr obj, IntPtr audioTStampConfig);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_delay")]
        internal static extern int SoundPcmStatusGetDelay(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_avail")]
        internal static extern int SoundPcmStatusGetAvail(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_avail_max")]
        internal static extern int SoundPcmStatusGetAvailMax(IntPtr obj);

        [DllImport("asound", EntryPoint = "snd_pcm_status_get_overrange")]
        internal static extern int SoundPcmStatusGetOverrange(IntPtr obj);

        // SoundPcmHwParams

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_dump")]
        internal static extern int SoundPcmHwParamsDump(IntPtr @params, IntPtr @out);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_any")]
        internal static extern int SoundPcmHwParamsAny(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_mmap_sample_resolution")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanMmapSampleResolution(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_double")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsDouble(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_batch")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsBatch(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_block_transfer")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsBlockTransfer(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_monotonic")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsMonotonic(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_overrange")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanOverrange(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_pause")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanPause(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_resume")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanResume(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_half_duplex")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsHalfDuplex(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_is_joint_duplex")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsIsJointDuplex(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_sync_start")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanSyncStart(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_can_disable_period_wakeup")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsCanDisablePeriodWakeup(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_supports_audio_wallclock_ts")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsSupportsAudioWallclockTs(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_SupportsAudioTsType")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SoundPcmHwParamsSupportsAudioTsType(IntPtr @params, int type);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_rate_numden")]
        internal static extern int SoundPcmHwParamsGetRateNumden(IntPtr @params, out uint rateNum, out uint rateDen);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_sbits")]
        internal static extern int SoundPcmHwParamsGetSbits(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_fifo_size")]
        internal static extern int SoundPcmHwParamsGetFifoSize(IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_sizeof")]
        internal static extern uint SoundPcmHwParamsSizeOf();

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_malloc")]
        internal static extern int SoundPcmHwParamsMalloc(out IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_free")]
        internal static extern void SoundPcmHwParamsFree(IntPtr ptr);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_copy")]
        internal static extern void SoundPcmHwParamsCopy(IntPtr dst, IntPtr src);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_access")]
        internal static extern int SoundPcmHwParamsGetAccess(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_access")]
        internal static extern int SoundPcmHwParamsTestAccess(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_access")]
        internal static extern int SoundPcmHwParamsSetAccess(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_access_first")]
        internal static extern int SoundPcmHwParamsSetAccessFirst(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_access_last")]
        internal static extern int SoundPcmHwParamsSetAccessLast(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_access_mask")]
        internal static extern int SoundPcmHwParamsSetAccessMask(IntPtr pcm, IntPtr @params, IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_access_mask")]
        internal static extern int SoundPcmHwParamsGetAccessMask(IntPtr @params, out IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_format")]
        internal static extern int SoundPcmHwParamsGetFormat(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_format")]
        internal static extern int SoundPcmHwParamsTestFormat(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_format")]
        internal static extern int SoundPcmHwParamsSetFormat(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_format_first")]
        internal static extern int SoundPcmHwParamsSetFormatFirst(IntPtr pcm, IntPtr @params, out uint format);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_format_last")]
        internal static extern int SoundPcmHwParamsSetFormatLast(IntPtr pcm, IntPtr @params, out uint format);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_format_mask")]
        internal static extern int SoundPcmHwParamsSetFormatMask(IntPtr pcm, IntPtr @params, IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_format_mask")]
        internal static extern void SoundPcmHwParamsGetFormatMask(IntPtr @params, out IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_subformat")]
        internal static extern int SoundPcmHwParamsGetSubformat(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_subformat")]
        internal static extern int SoundPcmHwParamsTestSubformat(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_subformat")]
        internal static extern int SoundPcmHwParamsSetSubformat(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_subformat_first")]
        internal static extern int SoundPcmHwParamsSetSubformatFirst(IntPtr pcm, IntPtr @params, out uint format);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_subformat_last")]
        internal static extern int SoundPcmHwParamsSetSubformatLast(IntPtr pcm, IntPtr @params, out uint format);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_subformat_mask")]
        internal static extern int SoundPcmHwParamsSetSubformatMask(IntPtr pcm, IntPtr @params, IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_subformat_mask")]
        internal static extern void SoundPcmHwParamsGetSubformatMask(IntPtr @params, out IntPtr mask);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_channels")]
        internal static extern int SoundPcmHwParamsGetChannels(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_channels_min")]
        internal static extern int SoundPcmHwParamsGetChannelsMin(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_channels_max")]
        internal static extern int SoundPcmHwParamsGetChannelsMax(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_channels")]
        internal static extern int SoundPcmHwParamsTestChannels(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels")]
        internal static extern int SoundPcmHwParamsSetChannels(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_min")]
        internal static extern int SoundPcmHwParamsSetChannelsMin(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_max")]
        internal static extern int SoundPcmHwParamsSetChannelsMax(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_minmax")]
        internal static extern int SoundPcmHwParamsSetChannelsMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref uint max);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_near")]
        internal static extern int SoundPcmHwParamsSetChannelsNear(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_first")]
        internal static extern int SoundPcmHwParamsSetChannelsFirst(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_channels_last")]
        internal static extern int SoundPcmHwParamsSetChannelsLast(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_rate")]
        internal static extern int SoundPcmHwParamsGetRate(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_rate_min")]
        internal static extern int SoundPcmHwParamsGetRateMin(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_rate_max")]
        internal static extern int SoundPcmHwParamsGetRateMax(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_rate")]
        internal static extern int SoundPcmHwParamsTestRate(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate")]
        internal static extern int SoundPcmHwParamsSetRate(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_min")]
        internal static extern int SoundPcmHwParamsSetRateMin(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_max")]
        internal static extern int SoundPcmHwParamsSetRateMax(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_minmax")]
        internal static extern int SoundPcmHwParamsSetRateMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref int mindir, ref uint max, ref int maxdir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_near")]
        internal static extern int SoundPcmHwParamsSetRateNear(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_first")]
        internal static extern int SoundPcmHwParamsSetRateFirst(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_last")]
        internal static extern int SoundPcmHwParamsSetRateLast(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_rate_resample")]
        internal static extern int SoundPcmHwParamsSetRateResample(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_rate_resample")]
        internal static extern int SoundPcmHwParamsGetRateResample(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_export_buffer")]
        internal static extern int SoundPcmHwParamsSetExportBuffer(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_export_buffer")]
        internal static extern int SoundPcmHwParamsGetExportBuffer(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_wakeup")]
        internal static extern int SoundPcmHwParamsSetPeriodWakeup(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_wakeup")]
        internal static extern int SoundPcmHwParamsGetPeriodWakeup(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_time")]
        internal static extern int SoundPcmHwParamsGetPeriodTime(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_time_min")]
        internal static extern int SoundPcmHwParamsGetPeriodTimeMin(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_time_max")]
        internal static extern int SoundPcmHwParamsGetPeriodTimeMax(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_period_time")]
        internal static extern int SoundPcmHwParamsTestPeriodTime(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time")]
        internal static extern int SoundPcmHwParamsSetPeriodTime(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_min")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeMin(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_max")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeMax(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_minmax")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref int mindir, ref uint max, ref int maxdir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_near")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeNear(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_first")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeFirst(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_time_last")]
        internal static extern int SoundPcmHwParamsSetPeriodTimeLast(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_size")]
        internal static extern int SoundPcmHwParamsGetPeriodSize(IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_size_min")]
        internal static extern int SoundPcmHwParamsGetPeriodSizeMin(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_period_size_max")]
        internal static extern int SoundPcmHwParamsGetPeriodSizeMax(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_period_size")]
        internal static extern int SoundPcmHwParamsTestPeriodSize(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size")]
        internal static extern int SoundPcmHwParamsSetPeriodSize(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_min")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeMin(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_max")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeMax(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_minmax")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref int mindir, ref uint max, ref int maxdir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_near")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeNear(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_first")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeFirst(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_last")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeLast(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_period_size_integer")]
        internal static extern int SoundPcmHwParamsSetPeriodSizeInteger(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_periods")]
        internal static extern int SoundPcmHwParamsGetPeriods(IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_periods_min")]
        internal static extern int SoundPcmHwParamsGetPeriodsMin(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_periods_max")]
        internal static extern int SoundPcmHwParamsGetPeriodsMax(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_periods")]
        internal static extern int SoundPcmHwParamsTestPeriods(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods")]
        internal static extern int SoundPcmHwParamsSetPeriods(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_min")]
        internal static extern int SoundPcmHwParamsSetPeriodsMin(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_max")]
        internal static extern int SoundPcmHwParamsSetPeriodsMax(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_minmax")]
        internal static extern int SoundPcmHwParamsSetPeriodsMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref int mindir, ref uint max, ref int maxdir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_near")]
        internal static extern int SoundPcmHwParamsSetPeriodsNear(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_first")]
        internal static extern int SoundPcmHwParamsSetPeriodsFirst(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_last")]
        internal static extern int SoundPcmHwParamsSetPeriodsLast(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_periods_integer")]
        internal static extern int SoundPcmHwParamsSetPeriodsInteger(IntPtr pcm, IntPtr @params);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_time")]
        internal static extern int SoundPcmHwParamsGetBufferTime(IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_time_min")]
        internal static extern int SoundPcmHwParamsGetBufferTimeMin(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_time_max")]
        internal static extern int SoundPcmHwParamsGetBufferTimeMax(IntPtr @params, out uint val,  ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_buffer_time")]
        internal static extern int SoundPcmHwParamsTestBufferTime(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time")]
        internal static extern int SoundPcmHwParamsSetBufferTime(IntPtr pcm, IntPtr @params, uint val, int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_min")]
        internal static extern int SoundPcmHwParamsSetBufferTimeMin(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_max")]
        internal static extern int SoundPcmHwParamsSetBufferTimeMax(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_minmax")]
        internal static extern int SoundPcmHwParamsSetBufferTimeMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref int mindir, ref uint max, ref int maxdir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_near")]
        internal static extern int SoundPcmHwParamsSetBufferTimeNear(IntPtr pcm, IntPtr @params, ref uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_first")]
        internal static extern int SoundPcmHwParamsSetBufferTimeFirst(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_time_last")]
        internal static extern int SoundPcmHwParamsSetBufferTimeLast(IntPtr pcm, IntPtr @params, out uint val, ref int dir);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_size")]
        internal static extern int SoundPcmHwParamsGetBufferSize(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_size_min")]
        internal static extern int SoundPcmHwParamsGetBufferSizeMin(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_buffer_size_max")]
        internal static extern int SoundPcmHwParamsGetBufferSizeMax(IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_test_buffer_size")]
        internal static extern int SoundPcmHwParamsTestBufferSize(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size")]
        internal static extern int SoundPcmHwParamsSetBufferSize(IntPtr pcm, IntPtr @params, uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_min")]
        internal static extern int SoundPcmHwParamsSetBufferSizeMin(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_max")]
        internal static extern int SoundPcmHwParamsSetBufferSizeMax(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_minmax")]
        internal static extern int SoundPcmHwParamsSetBufferSizeMinMax(IntPtr pcm, IntPtr @params, ref uint min, ref uint max);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_near")]
        internal static extern int SoundPcmHwParamsSetBufferSizeNear(IntPtr pcm, IntPtr @params, ref uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_first")]
        internal static extern int SoundPcmHwParamsSetBufferSizeFirst(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_set_buffer_size_last")]
        internal static extern int SoundPcmHwParamsSetBufferSizeLast(IntPtr pcm, IntPtr @params, out uint val);

        [DllImport("asound", EntryPoint = "snd_pcm_hw_params_get_min_align")]
        internal static extern int SoundPcmHwParamsGetMinAlign(IntPtr @params, out uint val);
    }
}
