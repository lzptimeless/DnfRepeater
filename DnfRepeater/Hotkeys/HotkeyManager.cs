using DnfRepeater.Hotkeys.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    public class HotkeyManager : IHotkeyManager
    {
        #region fields
        /// <summary>
        /// 空的热键 id
        /// </summary>
        private const int EmptyId = 0;
        /// <summary>
        /// 来自 Windows 的热键消息类型
        /// </summary>
        private const int WM_HOTKEY = 0x0312;

        /// <summary>
        /// Win32 api 接口，定义为接口是为了便于单元测试
        /// </summary>
        private readonly IHotkeyNative _hotkeyNative;
        /// <summary>
        /// 程序主窗口句柄
        /// </summary>
        private IntPtr _hwnd;
        /// <summary>
        /// 存储已经注册的热键的信息，key: 热键 id，value: 热键信息
        /// </summary>
        private readonly Dictionary<int, HotkeyEntry> _entries = new Dictionary<int, HotkeyEntry>();
        /// <summary>
        /// 当前已注册的热键的 id
        /// </summary>
        private int _currentMaxId = EmptyId;
        /// <summary>
        /// 线程同步锁
        /// </summary>
        private readonly object _lockObj = new object();
        #endregion

        #region properties
        #region Default
        public static IHotkeyManager Default { get; private set; } = new HotkeyManager();
        #endregion
        /// <summary>
        /// 获取或设置启用触发热键事件，默认为 true，在用户修改快捷键时应该将这个属性设置为 false
        /// </summary>
        public bool EnableHotkeyEvent { get; set; } = true;
        #endregion

        #region constructor
        public HotkeyManager()
            : this(new HotkeyNative())
        { }

        /// <summary>
        /// 创建热键管理
        /// </summary>
        /// <param name="hotkeyNative">Win32 api 接口，定义为接口是为了便于单元测试</param>
        public HotkeyManager(IHotkeyNative hotkeyNative)
        {
            _hotkeyNative = hotkeyNative;
        }
        #endregion

        #region methods
        public void Initialize(IntPtr hwnd)
        {
            // 在 WPF 中 hwnd 可以为 IntPtr.Zero
            _hwnd = hwnd;
        }

        public bool ProcessHotkeyMessage(int msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg != WM_HOTKEY)
                return false;

            HotkeyEntry entry;
            lock (_lockObj)
            {
                int id = (int)wParam;
                if (!_entries.ContainsKey(id))
                    return false;

                entry = _entries[id];
            }

            if (EnableHotkeyEvent)
                entry.Handler(this, new HotkeyEventArgs(entry.Modifiers, entry.VirtualKey));

            return true;
        }

        public int Register(ModifierKeys modifiers, int vk, EventHandler<HotkeyEventArgs> handler)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");

            HotkeyEntry entry;
            lock (_lockObj)
            {
                // 如果这个热键已经被注册直接返回
                int oldId = GetRegisteredIdInner(modifiers, vk);
                if (oldId != EmptyId)
                    throw new HotkeyRegisterFailedException(HotkeyRegisterErrorCodes.AlreadyRegisteredByThisProcess, $"Register hotkey failed: modifiers={modifiers}, vk={vk}", null);

                entry = new HotkeyEntry(GenerateId(), modifiers, vk, handler);
                bool res = _hotkeyNative.RegisterHotKey(_hwnd, entry.Id, (int)modifiers, vk);
                if (!res)
                {
                    var ex = new Win32Exception();
                    if (ex.NativeErrorCode == 1409)
                        throw new HotkeyRegisterFailedException(HotkeyRegisterErrorCodes.AlreadyRegisteredByOtherProcess, $"Register hotkey failed: modifiers={modifiers}, vk={vk}", ex);
                    else
                        throw ex;
                }

                _entries.Add(entry.Id, entry);
            }

            return entry.Id;
        }

        public int Register(string hotkey, EventHandler<HotkeyEventArgs> handler)
        {
            if (string.IsNullOrWhiteSpace(hotkey))
                throw new ArgumentException("hotkey can not be empty.", "hotkey");

            if (!HotkeyConverter.TryStringToHotkey(hotkey, out ModifierKeys modifiers, out int vk, out HotkeyFormatErrorCodes errorCode))
                throw new HotkeyRegisterFailedException(errorCode, $"hotkey format error: {hotkey}", null);

            return Register(modifiers, vk, handler);
        }

        public int GetRegisteredId(ModifierKeys modifiers, int vk)
        {
            lock (_lockObj)
            {
                return GetRegisteredIdInner(modifiers, vk);
            }
        }

        public int GetRegisteredId(string hotkey)
        {
            if (string.IsNullOrWhiteSpace(hotkey))
                throw new ArgumentException("hotkey can not be empty.", "hotkey");

            if (!HotkeyConverter.TryStringToHotkey(hotkey, out ModifierKeys modifiers, out int vk, out HotkeyFormatErrorCodes errorCode))
                throw new HotkeyFormatException($"hotkey format error: {hotkey}", errorCode);

            return GetRegisteredId(modifiers, vk);
        }

        public bool Unregister(int id)
        {
            lock (_lockObj)
            {
                if (!_entries.ContainsKey(id))
                    return false;

                _entries.Remove(id);
                _hotkeyNative.UnregisterHotKey(_hwnd, id);
            }
            return true;
        }

        public void UnregisterAll()
        {
            lock (_lockObj)
            {
                foreach (var id in _entries.Keys)
                {
                    _hotkeyNative.UnregisterHotKey(_hwnd, id);
                }
                _entries.Clear();
            }
        }
        #endregion

        #region private

        private int GenerateId()
        {
            if (_currentMaxId == int.MaxValue)
                throw new HotkeyIdExceedTheCapException($"Hotkey count exceed the cap: {int.MaxValue}");

            ++_currentMaxId;
            return _currentMaxId;
        }

        private int GetRegisteredIdInner(ModifierKeys modifiers, int vk)
        {
            foreach (var kv in _entries)
            {
                if (kv.Value.Modifiers == modifiers && kv.Value.VirtualKey == vk)
                    return kv.Key;
            }

            return EmptyId;
        }
        #endregion

        #region inner class
        private class HotkeyEntry
        {
            public HotkeyEntry(int id, ModifierKeys modifiers, int virtualKey, EventHandler<HotkeyEventArgs> handler)
            {
                Id = id;
                Modifiers = modifiers;
                VirtualKey = virtualKey;
                Handler = handler;
            }

            public int Id { get; set; }
            public ModifierKeys Modifiers { get; set; }
            public int VirtualKey { get; set; }
            public EventHandler<HotkeyEventArgs> Handler { get; set; }
        }
        #endregion
    }
}
