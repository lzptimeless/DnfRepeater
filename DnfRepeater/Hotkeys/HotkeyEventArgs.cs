using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    /// <summary>
    /// 热键事件参数
    /// </summary>
    public class HotkeyEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化热键事件参数
        /// </summary>
        /// <param name="modifiers">事件参数包含的辅助按键</param>
        /// <param name="vk">触发事件的虚拟键码</param>
        public HotkeyEventArgs(ModifierKeys modifiers, int vk)
        {
            Modifiers = modifiers;
            VirtualKey = vk;
        }

        /// <summary>
        /// 事件参数包含的辅助按键
        /// </summary>
        public ModifierKeys Modifiers { get; private set; }
        /// <summary>
        /// 触发事件的虚拟键码
        /// </summary>
        public int VirtualKey { get; private set; }
    }
}
