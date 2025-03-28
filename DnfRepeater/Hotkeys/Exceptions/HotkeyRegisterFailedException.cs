using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys.Exceptions
{
    public class HotkeyRegisterFailedException : Exception
    {
        public HotkeyRegisterFailedException(HotkeyRegisterErrorCodes errorCode, string? msg, Exception? ex)
            : base(msg, ex)
        {
            ErrorCode = errorCode;
        }

        public HotkeyRegisterFailedException(HotkeyFormatErrorCodes errorCode, string? msg, Exception? ex)
            : base(msg, ex)
        {
            HotkeyRegisterErrorCodes code;
            switch (errorCode)
            {
                case HotkeyFormatErrorCodes.NoError:
                    code = HotkeyRegisterErrorCodes.Success;
                    break;
                case HotkeyFormatErrorCodes.NoModifier:
                    code = HotkeyRegisterErrorCodes.NoModifier;
                    break;
                case HotkeyFormatErrorCodes.TooManyModifiers:
                    code = HotkeyRegisterErrorCodes.TooManyModifiers;
                    break;
                case HotkeyFormatErrorCodes.NoKey:
                    code = HotkeyRegisterErrorCodes.NoKey;
                    break;
                case HotkeyFormatErrorCodes.UnknownKey:
                    code = HotkeyRegisterErrorCodes.UnknownKey;
                    break;
                case HotkeyFormatErrorCodes.TooManyKeys:
                    code = HotkeyRegisterErrorCodes.TooManyKeys;
                    break;
                default:
                    code = HotkeyRegisterErrorCodes.Unknown;
                    break;
            }
            ErrorCode = code;
        }

        public HotkeyRegisterErrorCodes ErrorCode { get; private set; }
        public override string Message => $"{base.Message}; ErrorCode={ErrorCode}";
    }

    public enum HotkeyRegisterErrorCodes
    {
        /// <summary>
        /// 注册成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 已经被这个进程注册过
        /// </summary>
        AlreadyRegisteredByThisProcess,
        /// <summary>
        /// 已经被其他进程注册过
        /// </summary>
        AlreadyRegisteredByOtherProcess,
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
