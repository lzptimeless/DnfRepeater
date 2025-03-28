using System;

namespace DnfRepeater.Hotkeys
{
    /// <summary>
    /// 热键管理接口
    /// </summary>
    public interface IHotkeyManager
    {
        /// <summary>
        /// 获取或设置启用触发热键事件，默认为 true，在用户修改快捷键时应该将这个属性设置为 false
        /// </summary>
        bool EnableHotkeyEvent { get; set; }
        /// <summary>
        /// 初始化热键管理，这个函数必须在调用<see cref="Register(ModifierKeys, int, EventHandler{HotkeyEventArgs}, ref int)"/>
        /// 之前调用
        /// </summary>
        /// <param name="hwnd">程序主窗口句柄</param>
        void Initialize(IntPtr hwnd);
        /// <summary>
        /// 处理程序主窗口消息中的热键信息，这个函数必须添加在程序消息处理函数中，这样热键管理才能收到热键消息
        /// </summary>
        /// <param name="msg">Windows 消息类型</param>
        /// <param name="wParam">Windows 消息参数 wParam</param>
        /// <param name="lParam">Windows 消息参数 lParam</param>
        /// <returns>这个消息是否被处理</returns>
        bool ProcessHotkeyMessage(int msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="modifiers">要注册的辅助按键，可以通过 | 符号组合多个辅助按键</param>
        /// <param name="vk">要注册的热键的虚拟键码</param>
        /// <param name="handler">热键触发事件的处理回调</param>
        /// <returns>如果注册成功就返回热键的注册 id</returns>
        /// <exception cref="HotkeyRegisterFailedException">热键已经注册返回异常，可以通过 ErrorCode 判断是本程序中已经注册还是被外部程序注册</exception>
        /// <exception cref="Win32Exception">未知原因注册失败返回异常</exception>
        int Register(ModifierKeys modifiers, int vk, EventHandler<HotkeyEventArgs> handler);
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hotkey">要注册的热键的字符串表示法，忽略大小写，例如：CONTROL + ALT + D</param>
        /// <param name="handler">热键触发事件的处理回调</param>
        /// <returns>如果注册成功就返回热键的注册 id</returns>
        /// <exception cref="HotkeyRegisterFailedException">热键已经注册返回异常，可以通过 ErrorCode 判断是本程序中已经注册还是被外部程序注册</exception>
        /// <exception cref="Win32Exception">未知原因注册失败返回异常</exception>
        /// <exception cref="HotkeyFormatException">hotkey 格式错误</exception>
        int Register(string hotkey, EventHandler<HotkeyEventArgs> handler);
        /// <summary>
        /// 获得已经注册的热键的 id
        /// </summary>
        /// <param name="modifiers">要查询 id 的辅助按键</param>
        /// <param name="vk">要查询 id 的虚拟键码</param>
        /// <returns>如果存在则返回热键的对应的 id，不存在则返回 0</returns>
        int GetRegisteredId(ModifierKeys modifiers, int vk);
        /// <summary>
        /// 获得已经注册的热键的 id
        /// </summary>
        /// <param name="hotkey">要查询热键的字符串表示形式，忽略大小写，例如：CONTROL + ALT + D</param>
        /// <returns>如果存在则返回热键的对应的 id，不存在则返回 0</returns>
        int GetRegisteredId(string hotkey);
        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="id">注册热键时返回的 id</param>
        /// <returns>注销成功返回 true，热键不存在返回 false</returns>
        bool Unregister(int id);
        /// <summary>
        /// 注销所有热键
        /// </summary>
        void UnregisterAll();
    }
}
