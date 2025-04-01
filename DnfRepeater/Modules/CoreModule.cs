using DnfRepeater.Events;
using DnfRepeater.Hotkeys;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Modules
{
    internal class CoreModule : IDisposable
    {
        #region fields
        private readonly UserConfig _userConfig;
        private IntPtr _targetHWnd;
        private int _repeatVk;
        private int _triggerVk;
        private int _registeredOnOffHotkeyId;
        /// <summary>
        /// 用以监控前台窗口变化
        /// </summary>
        private WinEventDelegate _winEventDelegate;
        private IntPtr _winEventHook;
        private readonly ManualResetEvent _repeatEvent;
        private readonly Thread _repeatThread;
        private bool _isDisposed;
        #endregion

        public CoreModule()
        {
            _userConfig = UserConfig.Load();
            _winEventDelegate = new WinEventDelegate(WinEventProc);
            _winEventHook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, _winEventDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
            _repeatEvent = new ManualResetEvent(false);
            _repeatThread = new Thread(RepeatThreadProcess);
            _repeatThread.Start();
        }

        #region properties
        /// <summary>
        /// 开关快捷键，格式：Ctrl+Shift+Alt+Key
        /// </summary>
        public string? OnOffHotkey { get; private set; }
        /// <summary>
        /// 连发键
        /// </summary>
        public string? RepeatKey { get; private set; }
        /// <summary>
        /// 触发键
        /// </summary>
        public string? TriggerKey { get; private set; }
        /// <summary>
        /// 连发频率（次/秒），取值范围：<see cref="UserConfig.RepeatFrequencyMin"/>-<see cref="UserConfig.RepeatFrequencyMax"/>
        /// </summary>
        public int RepeatFrequency { get; private set; }
        /// <summary>
        /// 监听的目标窗口标题
        /// </summary>
        public string? TargetWindowTitle { get; private set; }
        /// <summary>
        /// 是否正在监听目标窗口
        /// </summary>
        public bool IsOn => _targetHWnd != IntPtr.Zero;
        /// <summary>
        /// 是否正在连发
        /// </summary>
        public bool IsRepeating { get; private set; }
        #endregion

        #region events
        /// <summary>
        /// 启用|关闭状态改变事件
        /// </summary>
        public event EventHandler<IsOnChangedEventArgs>? IsOnChanged;
        /// <summary>
        /// 连发状态改变事件
        /// </summary>
        public event EventHandler<IsRepeatingChangedEventArgs>? IsRepeatingChanged;
        #endregion

        #region public methods
        /// <summary>
        /// 应用用户配置
        /// </summary>
        public void ApplyUserConfig()
        {
            Log.Information("Applying user config...");
            try
            {
                SetOnOffHotkey(_userConfig.OnOffHotkey);
                SetRepeatKey(_userConfig.RepeatKey);
                SetTriggerKey(_userConfig.TriggerKey);
                SetRepeatFrequency(_userConfig.RepeatFrequency);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Failed to apply user config.");
            }
            finally
            {
                // 就算配置文件中的配置有误，也要将设置赋值到属性中，以便在界面上显示
                OnOffHotkey = _userConfig.OnOffHotkey;
                RepeatKey = _userConfig.RepeatKey;
                TriggerKey = _userConfig.TriggerKey;
                RepeatFrequency = _userConfig.RepeatFrequency;
            }
        }

        /// <summary>
        /// 设置启用|关闭快捷键
        /// </summary>
        /// <param name="hotkey">快捷键，格式：Ctrl+Shift+Alt+Key</param>
        public void SetOnOffHotkey(string? hotkey)
        {
            Log.Information("Setting OnOff hotkey to {hotkey}...", hotkey);
            if (hotkey == OnOffHotkey)
            {
                Log.Information("OnOff hotkey is not changed.");
                return;
            }
            // 先注销旧的快捷键
            if (_registeredOnOffHotkeyId != 0)
            {
                if (HotkeyManager.Default.Unregister(_registeredOnOffHotkeyId))
                {
                    _registeredOnOffHotkeyId = 0;
                    Log.Information("Unregistered old OnOff hotkey.");
                }
                else
                {
                    Log.Warning("Failed to unregister old OnOff hotkey.");
                }
            }

            if (!string.IsNullOrEmpty(hotkey))
            {
                // 注册新的快捷键
                _registeredOnOffHotkeyId = HotkeyManager.Default.Register(hotkey, OnOffHotkeyHandler);
                if (_registeredOnOffHotkeyId != 0)
                {
                    Log.Information("Registered new OnOff hotkey.");
                }
                else
                {
                    Log.Error("Failed to register new OnOff hotkey.");
                }
            }
            else
            {
                Log.Information("OnOff hotkey is empty.");
                // 如果快捷键为空，用户已经没有办法手动关闭连发，所以自动停止监听
                if (IsOn)
                {
                    Log.Information("Turn off repeat because OnOff hotkey is empty.");
                    StopRepeat();
                    _targetHWnd = IntPtr.Zero;
                    TargetWindowTitle = null;
                    IsOnChanged?.Invoke(this, new IsOnChangedEventArgs(false, null));
                }
            }

            // 保存配置
            OnOffHotkey = hotkey;
            _userConfig.OnOffHotkey = OnOffHotkey;
            _userConfig.Save();
        }

        public void SetRepeatKey(string? key)
        {
            Log.Information("Setting repeat key to {key}...", key);
            int vk;
            if (string.IsNullOrEmpty(key))
            {
                vk = 0;
            }
            else
            {
                if (!HotkeyConverter.TryKeyNameToVirtualKey(key, out vk))
                {
                    throw new ArgumentException($"The key '{key}' is not a valid key name.");
                }
            }

            RepeatKey = key;
            _repeatVk = vk;
            _userConfig.RepeatKey = RepeatKey;
            _userConfig.Save();
        }

        public void SetTriggerKey(string? key)
        {
            Log.Information("Setting trigger key to {key}...", key);
            int vk;
            if (string.IsNullOrEmpty(key))
            {
                vk = 0;
            }
            else
            {
                if (!HotkeyConverter.TryKeyNameToVirtualKey(key, out vk))
                {
                    throw new ArgumentException($"The key '{key}' is not a valid key name.");
                }
            }
            TriggerKey = key;
            _triggerVk = vk;
            _userConfig.TriggerKey = TriggerKey;
            _userConfig.Save();
        }

        public void SetRepeatFrequency(int frequency)
        {
            Log.Information("Setting repeat frequency to {frequency}...", frequency);
            if (frequency < UserConfig.RepeatFrequencyMin || frequency > UserConfig.RepeatFrequencyMax)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency), $"The value of {nameof(frequency)} must be between {UserConfig.RepeatFrequencyMin} and {UserConfig.RepeatFrequencyMax}.");
            }

            RepeatFrequency = frequency;
            _userConfig.RepeatFrequency = RepeatFrequency;
            _userConfig.Save();
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;
            try
            {
                HotkeyManager.Default.UnregisterAll();
                StopRepeat();
                UnhookWinEvent(_winEventHook);
                _repeatEvent.Set();
                _repeatThread.Join(1000);
                _repeatEvent.Dispose();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during Dispose.");
            }
        }
        #endregion

        #region private methods
        private void WinEventProc(nint hWinEventHook, uint eventType, nint hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (eventType == EVENT_SYSTEM_FOREGROUND)
            {
                if (_targetHWnd != IntPtr.Zero)
                {
                    var currentForegroundHWnd = GetForegroundWindow();
                    if (currentForegroundHWnd != _targetHWnd)
                    {
                        // 当前台窗口不是_targetHWnd时，停止连发
                        Log.Information("Stopping repeat because the foreground window is changed.");
                        StopRepeat();
                        // 如果_targetHWnd已经不存在则关闭连发
                        if (IsWindowClosed(_targetHWnd))
                        {
                            Log.Information("Turn off repeat because the target window is closed.");
                            _targetHWnd = IntPtr.Zero;
                            TargetWindowTitle = null;
                            IsOnChanged?.Invoke(this, new IsOnChangedEventArgs(false, null));
                        }
                    }
                    else
                    {
                        // 当前台窗口变为_targetHWnd时开始连发
                        Log.Information("Starting repeat because the foreground window is changed to the target window.");
                        StartRepeat();
                    }
                }
            }
        }

        private void OnOffHotkeyHandler(object? sender, HotkeyEventArgs e)
        {
            var currentForegroundHWnd = GetForegroundWindow();
            var oldTargetHWnd = _targetHWnd;
            if (_targetHWnd == currentForegroundHWnd)
            {
                _targetHWnd = IntPtr.Zero;
            }
            else
            {
                _targetHWnd = currentForegroundHWnd;
            }

            if (_targetHWnd != IntPtr.Zero)
            {
                StartRepeat();
                TargetWindowTitle = GetWindowTitle(_targetHWnd);
                Log.Information("Turn on repeat for window '{windowTitle}' by hotkey.", TargetWindowTitle);
            }
            else
            {
                StopRepeat();
                TargetWindowTitle = null;
                Log.Information("Turn off repeat by hotkey.");
            }

            if (oldTargetHWnd != _targetHWnd)
            {
                IsOnChanged?.Invoke(this, new IsOnChangedEventArgs(_targetHWnd != IntPtr.Zero, TargetWindowTitle));
            }
        }

        /// <summary>
        /// 先暂停连发，然后使用RepeatFrequency设置Timer，再开始连发，可重复调用
        /// </summary>
        private void StartRepeat()
        {
            _repeatEvent.Set();
        }

        private void StopRepeat()
        {
            _repeatEvent.Reset();
        }

        private void RepeatThreadProcess(object? state)
        {
            while (true)
            {
                _repeatEvent.WaitOne();
                // 计算连发延迟
                var frequency = Math.Max(UserConfig.RepeatFrequencyMin, Math.Min(UserConfig.RepeatFrequencyMax, RepeatFrequency));
                var delay = 1000 / frequency;
                // 检测当前是否需要连发
                var currentIsRepeating = false;
                if (_targetHWnd != IntPtr.Zero && _repeatVk != 0 && _triggerVk != 0)
                {
                    var currentForegroundHWnd = GetForegroundWindow();
                    if (currentForegroundHWnd == _targetHWnd)
                    {
                        var vkState = GetAsyncKeyState(_triggerVk);
                        if ((vkState & 0x8000) != 0)
                        {
                            currentIsRepeating = true;
                        }
                    }
                }

                if (currentIsRepeating)
                {
                    // 发送一次按键事件
                    SendKeyDown(_targetHWnd, _repeatVk);
                    Thread.Sleep(10);
                    SendKeyUp(_targetHWnd, _repeatVk);
                }

                // 更新连发状态
                if (currentIsRepeating != IsRepeating)
                {
                    IsRepeating = currentIsRepeating;
                    IsRepeatingChanged?.Invoke(this, new IsRepeatingChangedEventArgs(currentIsRepeating));
                }

                if (_isDisposed) break;
                Thread.Sleep(delay);
                if (_isDisposed) break;
            }
        }
        #endregion

        #region native
        [DllImport("user32.dll", SetLastError = true)]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint MAPVK_VK_TO_VSC = 0;
        private const uint KEYEVENTF_SCANCODE = 0x0008;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const uint INPUT_KEYBOARD = 1;

        private string GetWindowTitle(IntPtr hWnd)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            if (GetWindowText(hWnd, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return string.Empty;
        }

        private void SendKeyDown(IntPtr hWnd, int vk)
        {
            ushort scanCode = (ushort)MapVirtualKey((uint)vk, MAPVK_VK_TO_VSC);
            INPUT input = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)vk,
                        wScan = scanCode,
                        dwFlags = KEYEVENTF_SCANCODE
                    }
                }
            };
            SendInput(1, new INPUT[] { input }, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendKeyUp(IntPtr hWnd, int vk)
        {
            ushort scanCode = (ushort)MapVirtualKey((uint)vk, MAPVK_VK_TO_VSC);
            INPUT input = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = (ushort)vk,
                        wScan = scanCode,
                        dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP
                    }
                }
            };
            SendInput(1, new INPUT[] { input }, Marshal.SizeOf(typeof(INPUT)));
        }

        private bool IsWindowClosed(IntPtr hWnd)
        {
            return !IsWindow(hWnd);
        }
        #endregion
    }
}
