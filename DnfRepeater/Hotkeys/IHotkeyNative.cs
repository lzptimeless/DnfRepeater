using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    /// <summary>
    /// Win32 api 接口，定义为接口是为了便于单元测试
    /// </summary>
    public interface IHotkeyNative
    {
        bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
