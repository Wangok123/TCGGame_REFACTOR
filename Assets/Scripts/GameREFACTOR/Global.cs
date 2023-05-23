using System;
using GameREFACTOR.Events;
using UnityEngine;

namespace GameREFACTOR
{
    public static class Global
    {
        public static int GenerateId<T> () => GenerateId (typeof(T));
        public static int GenerateId(Type type) => Animator.StringToHash(type.Name);
    
        public static readonly EventAggregator Events = new EventAggregator();

        public static SaveManager SaveManager;
        public static OverlayModal OverlayModal;
        public static TooltipController Tooltip;
        public static CursorController Cursor;
    }
    
    public static class Notification
    {
        public static string Validate (Type t) => $"{t.Name}.ValidateNotification";
        public static string Prepare (Type t) => $"{t.Name}.PrepareNotification";
        public static string Perform (Type t) => $"{t.Name}.PerformNotification";
        public static string Cancel(Type t) => $"{t.Name}.CancelNotification";
        
        public static string Validate<T>() => Validate (typeof(T));
        public static string Prepare<T>() => Prepare (typeof(T));
        public static string Perform<T>() => Perform (typeof(T));
        public static string Cancel<T>() => Cancel(typeof(T));
    }
}