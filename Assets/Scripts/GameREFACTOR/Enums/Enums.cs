using System;

namespace GameREFACTOR.Enums
{
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