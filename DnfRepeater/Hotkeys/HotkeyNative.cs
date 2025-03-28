using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    internal class HotkeyNative : IHotkeyNative
    {
        private const string User32Dll = "user32.dll";

        [DllImport(User32Dll, EntryPoint = "RegisterHotKey", SetLastError = true)]
        private static extern bool RegisterHotKeyInner(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport(User32Dll, EntryPoint = "UnregisterHotKey", SetLastError = true)]
        private static extern bool UnregisterHotKeyInner(IntPtr hWnd, int id);

        public bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk)
        {
            return RegisterHotKeyInner(hWnd, id, fsModifiers, vk);
        }

        public bool UnregisterHotKey(IntPtr hWnd, int id)
        {
            return UnregisterHotKeyInner(hWnd, id);
        }
    }
}
