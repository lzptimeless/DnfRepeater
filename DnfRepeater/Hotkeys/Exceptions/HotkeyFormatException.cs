using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys.Exceptions
{
    public class HotkeyFormatException : Exception
    {
        public HotkeyFormatException(string msg, HotkeyFormatErrorCodes errorCode)
            : base(msg)
        {
            ErrorCode = errorCode;
        }

        public HotkeyFormatException(string msg, HotkeyFormatErrorCodes errorCode, Exception innerEx)
            : base(msg, innerEx)
        {
            ErrorCode = errorCode;
        }

        public HotkeyFormatErrorCodes ErrorCode { get; private set; }
    }

    public enum HotkeyFormatErrorCodes
    {
        NoError,
        /// <summary>
        /// 没有修饰键
        /// </summary>
        NoModifier,
        /// <summary>
        /// 修饰键数量超过了3个
        /// </summary>
        TooManyModifiers,
        /// <summary>
        /// 没有普通按键
        /// </summary>
        NoKey,
        /// <summary>
        /// 普通按键无法识别
        /// </summary>
        UnknownKey,
        /// <summary>
        /// 普通按键超过了1个
        /// </summary>
        TooManyKeys,
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown
    }
}
