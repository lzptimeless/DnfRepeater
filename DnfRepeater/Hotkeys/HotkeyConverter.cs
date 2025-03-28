using DnfRepeater.Hotkeys.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    public static class HotkeyConverter
    {
        /// <summary>
        /// 小写键名与键值的映射,用于转换键名为键值,小写的键名方便比较
        /// </summary>
        private readonly static Dictionary<string, Key> _displayToKeyMapLower;
        /// <summary>
        /// 键值与键名的映射,用于转换键值为键名
        /// </summary>
        private readonly static Dictionary<Key, string> _keyToDisplayMap;

        static HotkeyConverter()
        {
            // ESC use Key.Esc
            // F1 to F12 use Key.F1 to Key.F12
            var displayToKeyMap = new Dictionary<string, Key>();
            displayToKeyMap.Add("`", Key.OemTilde);
            displayToKeyMap.Add("~", Key.OemTilde);
            displayToKeyMap.Add("Tilde", Key.OemTilde);
            displayToKeyMap.Add("1", Key.D1);
            displayToKeyMap.Add("!", Key.D1);
            displayToKeyMap.Add("2", Key.D2);
            displayToKeyMap.Add("@", Key.D2);
            displayToKeyMap.Add("3", Key.D3);
            displayToKeyMap.Add("#", Key.D3);
            displayToKeyMap.Add("4", Key.D4);
            displayToKeyMap.Add("$", Key.D4);
            displayToKeyMap.Add("5", Key.D5);
            displayToKeyMap.Add("%", Key.D5);
            displayToKeyMap.Add("6", Key.D6);
            displayToKeyMap.Add("^", Key.D6);
            displayToKeyMap.Add("7", Key.D7);
            displayToKeyMap.Add("&", Key.D7);
            displayToKeyMap.Add("8", Key.D8);
            displayToKeyMap.Add("*", Key.D8);
            displayToKeyMap.Add("9", Key.D9);
            displayToKeyMap.Add("(", Key.D9);
            displayToKeyMap.Add("0", Key.D0);
            displayToKeyMap.Add(")", Key.D0);
            displayToKeyMap.Add("-", Key.OemMinus);
            displayToKeyMap.Add("_", Key.OemMinus);
            displayToKeyMap.Add("Minus", Key.OemMinus);
            displayToKeyMap.Add("=", Key.OemPlus);
            displayToKeyMap.Add("+", Key.OemPlus);
            displayToKeyMap.Add("Plus", Key.OemPlus);
            displayToKeyMap.Add("Backspace", Key.Back);
            // Tab use Key.Tab
            // Q to P use Key
            displayToKeyMap.Add("[", Key.OemOpenBrackets);
            displayToKeyMap.Add("{", Key.OemOpenBrackets);
            displayToKeyMap.Add("]", Key.OemCloseBrackets);
            displayToKeyMap.Add("}", Key.OemCloseBrackets);
            displayToKeyMap.Add("CapsLock", Key.Capital);
            // A to L use Key
            displayToKeyMap.Add(";", Key.OemSemicolon);
            displayToKeyMap.Add(":", Key.OemSemicolon);
            displayToKeyMap.Add("'", Key.OemQuotes);
            displayToKeyMap.Add("\"", Key.OemQuotes);
            // Enter use Key.Enter
            // Z to M use Key
            displayToKeyMap.Add(",", Key.OemComma);
            displayToKeyMap.Add("<", Key.OemComma);
            displayToKeyMap.Add(".", Key.OemPeriod);
            displayToKeyMap.Add(">", Key.OemPeriod);
            displayToKeyMap.Add("/", Key.OemQuestion);
            displayToKeyMap.Add("?", Key.OemQuestion);
            // Space use Key.Space
            // Printscreen use Key.PrintScreen
            // Scroll Lock use Key.Scroll
            // Pause Break use Key.Pause
            displayToKeyMap.Add("Ins", Key.Insert);
            // Home use Key.Home
            displayToKeyMap.Add("PgUp", Key.PageUp);
            displayToKeyMap.Add("Del", Key.Delete);
            // End use Key.End
            displayToKeyMap.Add("PgDn", Key.PageDown);
            displayToKeyMap.Add("↑", Key.Up);
            displayToKeyMap.Add("←", Key.Left);
            displayToKeyMap.Add("↓", Key.Down);
            displayToKeyMap.Add("→", Key.Right);
            // NumLock use Key.NumLock
            displayToKeyMap.Add("NUM/", Key.Divide);
            displayToKeyMap.Add("NUM*", Key.Multiply);
            displayToKeyMap.Add("NUM-", Key.Subtract);
            displayToKeyMap.Add("NUM7", Key.NumPad7);
            displayToKeyMap.Add("NUM8", Key.NumPad8);
            displayToKeyMap.Add("NUM9", Key.NumPad9);
            displayToKeyMap.Add("NUM+", Key.Add);
            displayToKeyMap.Add("NUM4", Key.NumPad4);
            displayToKeyMap.Add("NUM5", Key.NumPad5);
            displayToKeyMap.Add("NUM6", Key.NumPad6);
            displayToKeyMap.Add("NUM1", Key.NumPad1);
            displayToKeyMap.Add("NUM2", Key.NumPad2);
            displayToKeyMap.Add("NUM3", Key.NumPad3);
            // Enter use Key.Enter
            displayToKeyMap.Add("NUM0", Key.NumPad0);
            displayToKeyMap.Add("NUM.", Key.Decimal);

            // Generate _displayToKeyMapLower
            _displayToKeyMapLower = displayToKeyMap.ToDictionary(kv => kv.Key.ToLowerInvariant(), kv => kv.Value);
            // Generate _keyToDisplayMap
            _keyToDisplayMap = new Dictionary<Key, string>();
            foreach (var kv in displayToKeyMap)
            {
                if (!_keyToDisplayMap.ContainsKey(kv.Value))
                    _keyToDisplayMap[kv.Value] = kv.Key;
            }
        }

        public static bool TryKeyNameToVirtualKey(string s, out int vk)
        {
            vk = 0;
            if (string.IsNullOrWhiteSpace(s))
                return false;

            s = s.Trim();
            Key k;
            if (!_displayToKeyMapLower.TryGetValue(s.ToLowerInvariant(), out k))
                k = Key.None;

            if (k != Key.None || Enum.TryParse(s, true, out k))
            {
                vk = KeyConverter.VirtualKeyFromKey(k);
                return true;
            }

            return false;
        }

        public static bool TryVirtualKeyToKeyName(int vk, out string? s)
        {
            s = null;
            var k = KeyConverter.KeyFromVirtualKey(vk);
            if (k == Key.None)
                return false;

            if (!_keyToDisplayMap.TryGetValue(k, out s))
                s = null;

            if (string.IsNullOrEmpty(s))
                s = k.ToString();

            return true;
        }

        public static bool TryStringToHotkey(string hotkey, out ModifierKeys modifiers, out int vk, out HotkeyFormatErrorCodes errorCode)
        {
            errorCode = HotkeyFormatErrorCodes.NoError;
            modifiers = 0;
            vk = 0;
            // "CONTROL + ALT + Space Key"
            // 先移除一些不好处理的空格，让之后的处理更容易些
            hotkey = Regex.Replace(hotkey, @"\s*\+\s*", "+").Trim();
            // 判断是否有修饰键
            var allModifiers = Regex.Match(hotkey, @"^((Alt|Ctrl|Control|Shift|Win)\+)+", RegexOptions.IgnoreCase);
            if (!allModifiers.Success)
            {
                if (Regex.IsMatch(hotkey, @"^(Alt|Ctrl|Control|Shift|Win)$", RegexOptions.IgnoreCase))
                    errorCode = HotkeyFormatErrorCodes.NoKey;
                else
                    errorCode = HotkeyFormatErrorCodes.NoModifier;

                return false;
            }
            // 判断是否有键值
            if (allModifiers.Length == hotkey.Length)
            {
                errorCode = HotkeyFormatErrorCodes.NoKey;
                return false;
            }
            // 解析修饰键
            var modifierMhs = Regex.Matches(allModifiers.Value, @"(?<modifier>(Alt|Ctrl|Control|Shift|Win))\+", RegexOptions.IgnoreCase);
            if (modifierMhs.Count > 3)
            {
                errorCode = HotkeyFormatErrorCodes.TooManyModifiers;
                return false;
            }
            for (int i = 0; i < modifierMhs.Count; i++)
            {
                string s = modifierMhs[i].Groups["modifier"].Value;
                ModifierKeys m;
                if (s.Equals("control", StringComparison.OrdinalIgnoreCase))
                    m = ModifierKeys.Ctrl;
                else if (!Enum.TryParse(s, true, out m))
                {
                    errorCode = HotkeyFormatErrorCodes.Unknown;
                    return false;
                }

                modifiers |= m;
            }
            // 解析按键
            string keyPart = hotkey.Substring(allModifiers.Length);
            if (!TryKeyNameToVirtualKey(keyPart, out vk))
            {
                if (Regex.IsMatch(keyPart, @"^(Alt|Ctrl|Control|Shift|Win)$", RegexOptions.IgnoreCase))
                    errorCode = HotkeyFormatErrorCodes.NoKey;
                else if (Regex.IsMatch(keyPart, @".+\+.+"))
                    errorCode = HotkeyFormatErrorCodes.TooManyKeys;
                else
                    errorCode = HotkeyFormatErrorCodes.UnknownKey;

                return false;
            }

            return true;
        }

        public static bool TryHotkeyToString(ModifierKeys modifiers, int vk, out string? s)
        {
            s = null;
            StringBuilder result = new StringBuilder();
            if (modifiers.HasFlag(ModifierKeys.Ctrl))
                result.Append("Ctrl+");

            if (modifiers.HasFlag(ModifierKeys.Alt))
                result.Append("Alt+");

            if (modifiers.HasFlag(ModifierKeys.Shift))
                result.Append("Shift+");

            if (modifiers.HasFlag(ModifierKeys.Win))
                result.Append("Win+");

            // 一个修饰键都没有则失败
            if (result.Length == 0)
                return false;

            if (!TryVirtualKeyToKeyName(vk, out string? vkStr))
                return false;

            result.Append(vkStr);
            s = result.ToString();
            return true;
        }
    }
}
