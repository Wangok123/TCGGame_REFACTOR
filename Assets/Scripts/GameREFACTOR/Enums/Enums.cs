using System;

namespace GameREFACTOR.Enums
{
    [Flags]
    public enum Zones
    {
        None       = 0,
        Deck       = 1,
        Discard    = 1 << 1,
        Hand       = 1 << 2,
    }
    
    public enum ControlMode
    {
        Local    = 0,
        Computer = 1,
        Remote   = 2
    }
    
    /// <summary>
    /// 类比炉石下方
    /// </summary>
    [Flags]
    public enum Tag
    {
        None        = 0,
        Programmer  = 1,
        Productor   = 1 << 1
    }
}