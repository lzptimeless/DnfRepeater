using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    /// <summary>
    /// 辅助按键
    /// </summary>
    [Flags]
    public enum ModifierKeys
    {
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008
    }
}
