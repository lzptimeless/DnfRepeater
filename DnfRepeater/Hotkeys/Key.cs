using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    internal enum Key
    {
        /// <summary>No key pressed. </summary>
        None,
        /// <summary>The Cancel key. </summary>
        Cancel,
        /// <summary>The Backspace key. </summary>
        Back,
        /// <summary>The Tab key. </summary>
        Tab,
        /// <summary>The Linefeed key. </summary>
        LineFeed,
        /// <summary>The Clear key. </summary>
        Clear,
        /// <summary>The Return key. </summary>
        Return,
        /// <summary>The Enter key. </summary>
        Enter = 6,
        /// <summary>The Pause key. </summary>
        Pause,
        /// <summary>The Caps Lock key. </summary>
        Capital,
        /// <summary>The Caps Lock key. </summary>
        CapsLock = 8,
        /// <summary>The IME Kana mode key. </summary>
        KanaMode,
        /// <summary>The IME Hangul mode key. </summary>
        HangulMode = 9,
        /// <summary>The IME Junja mode key. </summary>
        JunjaMode,
        /// <summary>The IME Final mode key. </summary>
        FinalMode,
        /// <summary>The IME Hanja mode key. </summary>
        HanjaMode,
        /// <summary>The IME Kanji mode key. </summary>
        KanjiMode = 12,
        /// <summary>The ESC key. </summary>
        Escape,
        /// <summary>The IME Convert key. </summary>
        ImeConvert,
        /// <summary>The IME NonConvert key. </summary>
        ImeNonConvert,
        /// <summary>The IME Accept key. </summary>
        ImeAccept,
        /// <summary>The IME Mode change request. </summary>
        ImeModeChange,
        /// <summary>The Spacebar key. </summary>
        Space,
        /// <summary>The Page Up key. </summary>
        Prior,
        /// <summary>The Page Up key. </summary>
        PageUp = 19,
        /// <summary>The Page Down key. </summary>
        Next,
        /// <summary>The Page Down key. </summary>
        PageDown = 20,
        /// <summary>The End key. </summary>
        End,
        /// <summary>The Home key. </summary>
        Home,
        /// <summary>The Left Arrow key. </summary>
        Left,
        /// <summary>The Up Arrow key. </summary>
        Up,
        /// <summary>The Right Arrow key. </summary>
        Right,
        /// <summary>The Down Arrow key. </summary>
        Down,
        /// <summary>The Select key. </summary>
        Select,
        /// <summary>The Print key. </summary>
        Print,
        /// <summary>The Execute key. </summary>
        Execute,
        /// <summary>The Print Screen key. </summary>
        Snapshot,
        /// <summary>The Print Screen key. </summary>
        PrintScreen = 30,
        /// <summary>The Insert key. </summary>
        Insert,
        /// <summary>The Delete key. </summary>
        Delete,
        /// <summary>The Help key. </summary>
        Help,
        /// <summary>The 0 (zero) key. </summary>
        D0,
        /// <summary>The 1 (one) key. </summary>
        D1,
        /// <summary>The 2 key. </summary>
        D2,
        /// <summary>The 3 key. </summary>
        D3,
        /// <summary>The 4 key. </summary>
        D4,
        /// <summary>The 5 key. </summary>
        D5,
        /// <summary>The 6 key. </summary>
        D6,
        /// <summary>The 7 key. </summary>
        D7,
        /// <summary>The 8 key. </summary>
        D8,
        /// <summary>The 9 key. </summary>
        D9,
        /// <summary>The A key. </summary>
        A,
        /// <summary>The B key. </summary>
        B,
        /// <summary>The C key. </summary>
        C,
        /// <summary>The D key. </summary>
        D,
        /// <summary>The E key. </summary>
        E,
        /// <summary>The F key. </summary>
        F,
        /// <summary>The G key. </summary>
        G,
        /// <summary>The H key. </summary>
        H,
        /// <summary>The I key. </summary>
        I,
        /// <summary>The J key. </summary>
        J,
        /// <summary>The K key. </summary>
        K,
        /// <summary>The L key. </summary>
        L,
        /// <summary>The M key. </summary>
        M,
        /// <summary>The N key. </summary>
        N,
        /// <summary>The O key. </summary>
        O,
        /// <summary>The P key. </summary>
        P,
        /// <summary>The Q key. </summary>
        Q,
        /// <summary>The R key. </summary>
        R,
        /// <summary>The S key. </summary>
        S,
        /// <summary>The T key. </summary>
        T,
        /// <summary>The U key. </summary>
        U,
        /// <summary>The V key. </summary>
        V,
        /// <summary>The W key. </summary>
        W,
        /// <summary>The X key. </summary>
        X,
        /// <summary>The Y key. </summary>
        Y,
        /// <summary>The Z key. </summary>
        Z,
        /// <summary>The left Windows logo key (Microsoft Natural Keyboard). </summary>
        LWin,
        /// <summary>The right Windows logo key (Microsoft Natural Keyboard). </summary>
        RWin,
        /// <summary>The Application key (Microsoft Natural Keyboard). </summary>
        Apps,
        /// <summary>The Computer Sleep key. </summary>
        Sleep,
        /// <summary>The 0 key on the numeric keypad. </summary>
        NumPad0,
        /// <summary>The 1 key on the numeric keypad. </summary>
        NumPad1,
        /// <summary>The 2 key on the numeric keypad. </summary>
        NumPad2,
        /// <summary>The 3 key on the numeric keypad. </summary>
        NumPad3,
        /// <summary>The 4 key on the numeric keypad. </summary>
        NumPad4,
        /// <summary>The 5 key on the numeric keypad. </summary>
        NumPad5,
        /// <summary>The 6 key on the numeric keypad. </summary>
        NumPad6,
        /// <summary>The 7 key on the numeric keypad. </summary>
        NumPad7,
        /// <summary>The 8 key on the numeric keypad. </summary>
        NumPad8,
        /// <summary>The 9 key on the numeric keypad. </summary>
        NumPad9,
        /// <summary>The Multiply key. </summary>
        Multiply,
        /// <summary>The Add key. </summary>
        Add,
        /// <summary>The Separator key. </summary>
        Separator,
        /// <summary>The Subtract key. </summary>
        Subtract,
        /// <summary>The Decimal key. </summary>
        Decimal,
        /// <summary>The Divide key. </summary>
        Divide,
        /// <summary>The F1 key. </summary>
        F1,
        /// <summary>The F2 key. </summary>
        F2,
        /// <summary>The F3 key. </summary>
        F3,
        /// <summary>The F4 key. </summary>
        F4,
        /// <summary>The F5 key. </summary>
        F5,
        /// <summary>The F6 key. </summary>
        F6,
        /// <summary>The F7 key. </summary>
        F7,
        /// <summary>The F8 key. </summary>
        F8,
        /// <summary>The F9 key. </summary>
        F9,
        /// <summary>The F10 key. </summary>
        F10,
        /// <summary>The F11 key. </summary>
        F11,
        /// <summary>The F12 key. </summary>
        F12,
        /// <summary>The F13 key. </summary>
        F13,
        /// <summary>The F14 key. </summary>
        F14,
        /// <summary>The F15 key. </summary>
        F15,
        /// <summary>The F16 key. </summary>
        F16,
        /// <summary>The F17 key. </summary>
        F17,
        /// <summary>The F18 key. </summary>
        F18,
        /// <summary>The F19 key. </summary>
        F19,
        /// <summary>The F20 key. </summary>
        F20,
        /// <summary>The F21 key. </summary>
        F21,
        /// <summary>The F22 key. </summary>
        F22,
        /// <summary>The F23 key. </summary>
        F23,
        /// <summary>The F24 key. </summary>
        F24,
        /// <summary>The Num Lock key. </summary>
        NumLock,
        /// <summary>The Scroll Lock key. </summary>
        Scroll,
        /// <summary>The left Shift key. </summary>
        LeftShift,
        /// <summary>The right Shift key. </summary>
        RightShift,
        /// <summary>The left CTRL key. </summary>
        LeftCtrl,
        /// <summary>The right CTRL key. </summary>
        RightCtrl,
        /// <summary>The left ALT key. </summary>
        LeftAlt,
        /// <summary>The right ALT key. </summary>
        RightAlt,
        /// <summary>The Browser Back key. </summary>
        BrowserBack,
        /// <summary>The Browser Forward key. </summary>
        BrowserForward,
        /// <summary>The Browser Refresh key. </summary>
        BrowserRefresh,
        /// <summary>The Browser Stop key. </summary>
        BrowserStop,
        /// <summary>The Browser Search key. </summary>
        BrowserSearch,
        /// <summary>The Browser Favorites key. </summary>
        BrowserFavorites,
        /// <summary>The Browser Home key. </summary>
        BrowserHome,
        /// <summary>The Volume Mute key. </summary>
        VolumeMute,
        /// <summary>The Volume Down key. </summary>
        VolumeDown,
        /// <summary>The Volume Up key. </summary>
        VolumeUp,
        /// <summary>The Media Next Track key. </summary>
        MediaNextTrack,
        /// <summary>The Media Previous Track key. </summary>
        MediaPreviousTrack,
        /// <summary>The Media Stop key. </summary>
        MediaStop,
        /// <summary>The Media Play Pause key. </summary>
        MediaPlayPause,
        /// <summary>The Launch Mail key. </summary>
        LaunchMail,
        /// <summary>The Select Media key. </summary>
        SelectMedia,
        /// <summary>The Launch Application1 key. </summary>
        LaunchApplication1,
        /// <summary>The Launch Application2 key. </summary>
        LaunchApplication2,
        /// <summary>The OEM 1 key. </summary>
        Oem1,
        /// <summary>The OEM Semicolon key. </summary>
        OemSemicolon = 140,
        /// <summary>The OEM Addition key. </summary>
        OemPlus,
        /// <summary>The OEM Comma key. </summary>
        OemComma,
        /// <summary>The OEM Minus key. </summary>
        OemMinus,
        /// <summary>The OEM Period key. </summary>
        OemPeriod,
        /// <summary>The OEM 2 key. </summary>
        Oem2,
        /// <summary>The OEM Question key. </summary>
        OemQuestion = 145,
        /// <summary>The OEM 3 key. </summary>
        Oem3,
        /// <summary>The OEM Tilde key. </summary>
        OemTilde = 146,
        /// <summary>The ABNT_C1 (Brazilian) key. </summary>
        AbntC1,
        /// <summary>The ABNT_C2 (Brazilian) key. </summary>
        AbntC2,
        /// <summary>The OEM 4 key. </summary>
        Oem4,
        /// <summary>The OEM Open Brackets key. </summary>
        OemOpenBrackets = 149,
        /// <summary>The OEM 5 key. </summary>
        Oem5,
        /// <summary>The OEM Pipe key. </summary>
        OemPipe = 150,
        /// <summary>The OEM 6 key. </summary>
        Oem6,
        /// <summary>The OEM Close Brackets key. </summary>
        OemCloseBrackets = 151,
        /// <summary>The OEM 7 key. </summary>
        Oem7,
        /// <summary>The OEM Quotes key. </summary>
        OemQuotes = 152,
        /// <summary>The OEM 8 key. </summary>
        Oem8,
        /// <summary>The OEM 102 key. </summary>
        Oem102,
        /// <summary>The OEM Backslash key. </summary>
        OemBackslash = 154,
        /// <summary>A special key masking the real key being processed by an IME. </summary>
        ImeProcessed,
        /// <summary>A special key masking the real key being processed as a system key. </summary>
        System,
        /// <summary>The OEM ATTN key. </summary>
        OemAttn,
        /// <summary>The DBE_ALPHANUMERIC key. </summary>
        DbeAlphanumeric = 157,
        /// <summary>The OEM FINISH key. </summary>
        OemFinish,
        /// <summary>The DBE_KATAKANA key. </summary>
        DbeKatakana = 158,
        /// <summary>The OEM COPY key. </summary>
        OemCopy,
        /// <summary>The DBE_HIRAGANA key. </summary>
        DbeHiragana = 159,
        /// <summary>The OEM AUTO key. </summary>
        OemAuto,
        /// <summary>The DBE_SBCSCHAR key. </summary>
        DbeSbcsChar = 160,
        /// <summary>The OEM ENLW key. </summary>
        OemEnlw,
        /// <summary>The DBE_DBCSCHAR key. </summary>
        DbeDbcsChar = 161,
        /// <summary>The OEM BACKTAB key. </summary>
        OemBackTab,
        /// <summary>The DBE_ROMAN key. </summary>
        DbeRoman = 162,
        /// <summary>The ATTN key. </summary>
        Attn,
        /// <summary>The DBE_NOROMAN key. </summary>
        DbeNoRoman = 163,
        /// <summary>The CRSEL key. </summary>
        CrSel,
        /// <summary>The DBE_ENTERWORDREGISTERMODE key. </summary>
        DbeEnterWordRegisterMode = 164,
        /// <summary>The EXSEL key. </summary>
        ExSel,
        /// <summary>The DBE_ENTERIMECONFIGMODE key. </summary>
        DbeEnterImeConfigureMode = 165,
        /// <summary>The ERASE EOF key. </summary>
        EraseEof,
        /// <summary>The DBE_FLUSHSTRING key. </summary>
        DbeFlushString = 166,
        /// <summary>The PLAY key. </summary>
        Play,
        /// <summary>The DBE_CODEINPUT key. </summary>
        DbeCodeInput = 167,
        /// <summary>The ZOOM key. </summary>
        Zoom,
        /// <summary>The DBE_NOCODEINPUT key. </summary>
        DbeNoCodeInput = 168,
        /// <summary>A constant reserved for future use. </summary>
        NoName,
        /// <summary>The DBE_DETERMINESTRING key. </summary>
        DbeDetermineString = 169,
        /// <summary>The PA1 key. </summary>
        Pa1,
        /// <summary>The DBE_ENTERDLGCONVERSIONMODE key. </summary>
        DbeEnterDialogConversionMode = 170,
        /// <summary>The OEM Clear key. </summary>
        OemClear,
        /// <summary>The key is used with another key to create a single combined character.</summary>
        DeadCharProcessed
    }
}
