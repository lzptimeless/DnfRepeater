using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Hotkeys
{
    /// <summary>Provides static methods to convert between Win32 Virtual-Keys and the WPF <see cref="T:System.Windows.Input.Key" /> enumeration. </summary>
    internal static class KeyConverter
    {
        /// <summary>Converts a Win32 Virtual-Key into WPF <see cref="T:System.Windows.Input.Key" />.</summary>
        /// <returns>The WPF key.</returns>
        /// <param name="virtualKey">The virtual key to convert.</param>
        public static Key KeyFromVirtualKey(int virtualKey)
        {
            Key result;
            switch (virtualKey)
            {
                case 3:
                    result = Key.Cancel;
                    return result;
                case 8:
                    result = Key.Back;
                    return result;
                case 9:
                    result = Key.Tab;
                    return result;
                case 12:
                    result = Key.Clear;
                    return result;
                case 13:
                    result = Key.Return;
                    return result;
                case 16:
                case 160:
                    result = Key.LeftShift;
                    return result;
                case 17:
                case 162:
                    result = Key.LeftCtrl;
                    return result;
                case 18:
                case 164:
                    result = Key.LeftAlt;
                    return result;
                case 19:
                    result = Key.Pause;
                    return result;
                case 20:
                    result = Key.Capital;
                    return result;
                case 21:
                    result = Key.KanaMode;
                    return result;
                case 23:
                    result = Key.JunjaMode;
                    return result;
                case 24:
                    result = Key.FinalMode;
                    return result;
                case 25:
                    result = Key.HanjaMode;
                    return result;
                case 27:
                    result = Key.Escape;
                    return result;
                case 28:
                    result = Key.ImeConvert;
                    return result;
                case 29:
                    result = Key.ImeNonConvert;
                    return result;
                case 30:
                    result = Key.ImeAccept;
                    return result;
                case 31:
                    result = Key.ImeModeChange;
                    return result;
                case 32:
                    result = Key.Space;
                    return result;
                case 33:
                    result = Key.Prior;
                    return result;
                case 34:
                    result = Key.Next;
                    return result;
                case 35:
                    result = Key.End;
                    return result;
                case 36:
                    result = Key.Home;
                    return result;
                case 37:
                    result = Key.Left;
                    return result;
                case 38:
                    result = Key.Up;
                    return result;
                case 39:
                    result = Key.Right;
                    return result;
                case 40:
                    result = Key.Down;
                    return result;
                case 41:
                    result = Key.Select;
                    return result;
                case 42:
                    result = Key.Print;
                    return result;
                case 43:
                    result = Key.Execute;
                    return result;
                case 44:
                    result = Key.Snapshot;
                    return result;
                case 45:
                    result = Key.Insert;
                    return result;
                case 46:
                    result = Key.Delete;
                    return result;
                case 47:
                    result = Key.Help;
                    return result;
                case 48:
                    result = Key.D0;
                    return result;
                case 49:
                    result = Key.D1;
                    return result;
                case 50:
                    result = Key.D2;
                    return result;
                case 51:
                    result = Key.D3;
                    return result;
                case 52:
                    result = Key.D4;
                    return result;
                case 53:
                    result = Key.D5;
                    return result;
                case 54:
                    result = Key.D6;
                    return result;
                case 55:
                    result = Key.D7;
                    return result;
                case 56:
                    result = Key.D8;
                    return result;
                case 57:
                    result = Key.D9;
                    return result;
                case 65:
                    result = Key.A;
                    return result;
                case 66:
                    result = Key.B;
                    return result;
                case 67:
                    result = Key.C;
                    return result;
                case 68:
                    result = Key.D;
                    return result;
                case 69:
                    result = Key.E;
                    return result;
                case 70:
                    result = Key.F;
                    return result;
                case 71:
                    result = Key.G;
                    return result;
                case 72:
                    result = Key.H;
                    return result;
                case 73:
                    result = Key.I;
                    return result;
                case 74:
                    result = Key.J;
                    return result;
                case 75:
                    result = Key.K;
                    return result;
                case 76:
                    result = Key.L;
                    return result;
                case 77:
                    result = Key.M;
                    return result;
                case 78:
                    result = Key.N;
                    return result;
                case 79:
                    result = Key.O;
                    return result;
                case 80:
                    result = Key.P;
                    return result;
                case 81:
                    result = Key.Q;
                    return result;
                case 82:
                    result = Key.R;
                    return result;
                case 83:
                    result = Key.S;
                    return result;
                case 84:
                    result = Key.T;
                    return result;
                case 85:
                    result = Key.U;
                    return result;
                case 86:
                    result = Key.V;
                    return result;
                case 87:
                    result = Key.W;
                    return result;
                case 88:
                    result = Key.X;
                    return result;
                case 89:
                    result = Key.Y;
                    return result;
                case 90:
                    result = Key.Z;
                    return result;
                case 91:
                    result = Key.LWin;
                    return result;
                case 92:
                    result = Key.RWin;
                    return result;
                case 93:
                    result = Key.Apps;
                    return result;
                case 95:
                    result = Key.Sleep;
                    return result;
                case 96:
                    result = Key.NumPad0;
                    return result;
                case 97:
                    result = Key.NumPad1;
                    return result;
                case 98:
                    result = Key.NumPad2;
                    return result;
                case 99:
                    result = Key.NumPad3;
                    return result;
                case 100:
                    result = Key.NumPad4;
                    return result;
                case 101:
                    result = Key.NumPad5;
                    return result;
                case 102:
                    result = Key.NumPad6;
                    return result;
                case 103:
                    result = Key.NumPad7;
                    return result;
                case 104:
                    result = Key.NumPad8;
                    return result;
                case 105:
                    result = Key.NumPad9;
                    return result;
                case 106:
                    result = Key.Multiply;
                    return result;
                case 107:
                    result = Key.Add;
                    return result;
                case 108:
                    result = Key.Separator;
                    return result;
                case 109:
                    result = Key.Subtract;
                    return result;
                case 110:
                    result = Key.Decimal;
                    return result;
                case 111:
                    result = Key.Divide;
                    return result;
                case 112:
                    result = Key.F1;
                    return result;
                case 113:
                    result = Key.F2;
                    return result;
                case 114:
                    result = Key.F3;
                    return result;
                case 115:
                    result = Key.F4;
                    return result;
                case 116:
                    result = Key.F5;
                    return result;
                case 117:
                    result = Key.F6;
                    return result;
                case 118:
                    result = Key.F7;
                    return result;
                case 119:
                    result = Key.F8;
                    return result;
                case 120:
                    result = Key.F9;
                    return result;
                case 121:
                    result = Key.F10;
                    return result;
                case 122:
                    result = Key.F11;
                    return result;
                case 123:
                    result = Key.F12;
                    return result;
                case 124:
                    result = Key.F13;
                    return result;
                case 125:
                    result = Key.F14;
                    return result;
                case 126:
                    result = Key.F15;
                    return result;
                case 127:
                    result = Key.F16;
                    return result;
                case 128:
                    result = Key.F17;
                    return result;
                case 129:
                    result = Key.F18;
                    return result;
                case 130:
                    result = Key.F19;
                    return result;
                case 131:
                    result = Key.F20;
                    return result;
                case 132:
                    result = Key.F21;
                    return result;
                case 133:
                    result = Key.F22;
                    return result;
                case 134:
                    result = Key.F23;
                    return result;
                case 135:
                    result = Key.F24;
                    return result;
                case 144:
                    result = Key.NumLock;
                    return result;
                case 145:
                    result = Key.Scroll;
                    return result;
                case 161:
                    result = Key.RightShift;
                    return result;
                case 163:
                    result = Key.RightCtrl;
                    return result;
                case 165:
                    result = Key.RightAlt;
                    return result;
                case 166:
                    result = Key.BrowserBack;
                    return result;
                case 167:
                    result = Key.BrowserForward;
                    return result;
                case 168:
                    result = Key.BrowserRefresh;
                    return result;
                case 169:
                    result = Key.BrowserStop;
                    return result;
                case 170:
                    result = Key.BrowserSearch;
                    return result;
                case 171:
                    result = Key.BrowserFavorites;
                    return result;
                case 172:
                    result = Key.BrowserHome;
                    return result;
                case 173:
                    result = Key.VolumeMute;
                    return result;
                case 174:
                    result = Key.VolumeDown;
                    return result;
                case 175:
                    result = Key.VolumeUp;
                    return result;
                case 176:
                    result = Key.MediaNextTrack;
                    return result;
                case 177:
                    result = Key.MediaPreviousTrack;
                    return result;
                case 178:
                    result = Key.MediaStop;
                    return result;
                case 179:
                    result = Key.MediaPlayPause;
                    return result;
                case 180:
                    result = Key.LaunchMail;
                    return result;
                case 181:
                    result = Key.SelectMedia;
                    return result;
                case 182:
                    result = Key.LaunchApplication1;
                    return result;
                case 183:
                    result = Key.LaunchApplication2;
                    return result;
                case 186:
                    result = Key.Oem1;
                    return result;
                case 187:
                    result = Key.OemPlus;
                    return result;
                case 188:
                    result = Key.OemComma;
                    return result;
                case 189:
                    result = Key.OemMinus;
                    return result;
                case 190:
                    result = Key.OemPeriod;
                    return result;
                case 191:
                    result = Key.Oem2;
                    return result;
                case 192:
                    result = Key.Oem3;
                    return result;
                case 193:
                    result = Key.AbntC1;
                    return result;
                case 194:
                    result = Key.AbntC2;
                    return result;
                case 219:
                    result = Key.Oem4;
                    return result;
                case 220:
                    result = Key.Oem5;
                    return result;
                case 221:
                    result = Key.Oem6;
                    return result;
                case 222:
                    result = Key.Oem7;
                    return result;
                case 223:
                    result = Key.Oem8;
                    return result;
                case 226:
                    result = Key.Oem102;
                    return result;
                case 229:
                    result = Key.ImeProcessed;
                    return result;
                case 240:
                    result = Key.OemAttn;
                    return result;
                case 241:
                    result = Key.OemFinish;
                    return result;
                case 242:
                    result = Key.OemCopy;
                    return result;
                case 243:
                    result = Key.OemAuto;
                    return result;
                case 244:
                    result = Key.OemEnlw;
                    return result;
                case 245:
                    result = Key.OemBackTab;
                    return result;
                case 246:
                    result = Key.Attn;
                    return result;
                case 247:
                    result = Key.CrSel;
                    return result;
                case 248:
                    result = Key.ExSel;
                    return result;
                case 249:
                    result = Key.EraseEof;
                    return result;
                case 250:
                    result = Key.Play;
                    return result;
                case 251:
                    result = Key.Zoom;
                    return result;
                case 252:
                    result = Key.NoName;
                    return result;
                case 253:
                    result = Key.Pa1;
                    return result;
                case 254:
                    result = Key.OemClear;
                    return result;
            }
            result = Key.None;
            return result;
        }

        /// <summary>Converts a WPF <see cref="T:System.Windows.Input.Key" /> into a Win32 Virtual-Key.</summary>
        /// <returns>The Win32 Virtual-Key.</returns>
        /// <param name="key">The WPF to convert.</param>
        public static int VirtualKeyFromKey(Key key)
        {
            int result;
            switch (key)
            {
                case Key.Cancel:
                    result = 3;
                    return result;
                case Key.Back:
                    result = 8;
                    return result;
                case Key.Tab:
                    result = 9;
                    return result;
                case Key.Clear:
                    result = 12;
                    return result;
                case Key.Return:
                    result = 13;
                    return result;
                case Key.Pause:
                    result = 19;
                    return result;
                case Key.Capital:
                    result = 20;
                    return result;
                case Key.KanaMode:
                    result = 21;
                    return result;
                case Key.JunjaMode:
                    result = 23;
                    return result;
                case Key.FinalMode:
                    result = 24;
                    return result;
                case Key.HanjaMode:
                    result = 25;
                    return result;
                case Key.Escape:
                    result = 27;
                    return result;
                case Key.ImeConvert:
                    result = 28;
                    return result;
                case Key.ImeNonConvert:
                    result = 29;
                    return result;
                case Key.ImeAccept:
                    result = 30;
                    return result;
                case Key.ImeModeChange:
                    result = 31;
                    return result;
                case Key.Space:
                    result = 32;
                    return result;
                case Key.Prior:
                    result = 33;
                    return result;
                case Key.Next:
                    result = 34;
                    return result;
                case Key.End:
                    result = 35;
                    return result;
                case Key.Home:
                    result = 36;
                    return result;
                case Key.Left:
                    result = 37;
                    return result;
                case Key.Up:
                    result = 38;
                    return result;
                case Key.Right:
                    result = 39;
                    return result;
                case Key.Down:
                    result = 40;
                    return result;
                case Key.Select:
                    result = 41;
                    return result;
                case Key.Print:
                    result = 42;
                    return result;
                case Key.Execute:
                    result = 43;
                    return result;
                case Key.Snapshot:
                    result = 44;
                    return result;
                case Key.Insert:
                    result = 45;
                    return result;
                case Key.Delete:
                    result = 46;
                    return result;
                case Key.Help:
                    result = 47;
                    return result;
                case Key.D0:
                    result = 48;
                    return result;
                case Key.D1:
                    result = 49;
                    return result;
                case Key.D2:
                    result = 50;
                    return result;
                case Key.D3:
                    result = 51;
                    return result;
                case Key.D4:
                    result = 52;
                    return result;
                case Key.D5:
                    result = 53;
                    return result;
                case Key.D6:
                    result = 54;
                    return result;
                case Key.D7:
                    result = 55;
                    return result;
                case Key.D8:
                    result = 56;
                    return result;
                case Key.D9:
                    result = 57;
                    return result;
                case Key.A:
                    result = 65;
                    return result;
                case Key.B:
                    result = 66;
                    return result;
                case Key.C:
                    result = 67;
                    return result;
                case Key.D:
                    result = 68;
                    return result;
                case Key.E:
                    result = 69;
                    return result;
                case Key.F:
                    result = 70;
                    return result;
                case Key.G:
                    result = 71;
                    return result;
                case Key.H:
                    result = 72;
                    return result;
                case Key.I:
                    result = 73;
                    return result;
                case Key.J:
                    result = 74;
                    return result;
                case Key.K:
                    result = 75;
                    return result;
                case Key.L:
                    result = 76;
                    return result;
                case Key.M:
                    result = 77;
                    return result;
                case Key.N:
                    result = 78;
                    return result;
                case Key.O:
                    result = 79;
                    return result;
                case Key.P:
                    result = 80;
                    return result;
                case Key.Q:
                    result = 81;
                    return result;
                case Key.R:
                    result = 82;
                    return result;
                case Key.S:
                    result = 83;
                    return result;
                case Key.T:
                    result = 84;
                    return result;
                case Key.U:
                    result = 85;
                    return result;
                case Key.V:
                    result = 86;
                    return result;
                case Key.W:
                    result = 87;
                    return result;
                case Key.X:
                    result = 88;
                    return result;
                case Key.Y:
                    result = 89;
                    return result;
                case Key.Z:
                    result = 90;
                    return result;
                case Key.LWin:
                    result = 91;
                    return result;
                case Key.RWin:
                    result = 92;
                    return result;
                case Key.Apps:
                    result = 93;
                    return result;
                case Key.Sleep:
                    result = 95;
                    return result;
                case Key.NumPad0:
                    result = 96;
                    return result;
                case Key.NumPad1:
                    result = 97;
                    return result;
                case Key.NumPad2:
                    result = 98;
                    return result;
                case Key.NumPad3:
                    result = 99;
                    return result;
                case Key.NumPad4:
                    result = 100;
                    return result;
                case Key.NumPad5:
                    result = 101;
                    return result;
                case Key.NumPad6:
                    result = 102;
                    return result;
                case Key.NumPad7:
                    result = 103;
                    return result;
                case Key.NumPad8:
                    result = 104;
                    return result;
                case Key.NumPad9:
                    result = 105;
                    return result;
                case Key.Multiply:
                    result = 106;
                    return result;
                case Key.Add:
                    result = 107;
                    return result;
                case Key.Separator:
                    result = 108;
                    return result;
                case Key.Subtract:
                    result = 109;
                    return result;
                case Key.Decimal:
                    result = 110;
                    return result;
                case Key.Divide:
                    result = 111;
                    return result;
                case Key.F1:
                    result = 112;
                    return result;
                case Key.F2:
                    result = 113;
                    return result;
                case Key.F3:
                    result = 114;
                    return result;
                case Key.F4:
                    result = 115;
                    return result;
                case Key.F5:
                    result = 116;
                    return result;
                case Key.F6:
                    result = 117;
                    return result;
                case Key.F7:
                    result = 118;
                    return result;
                case Key.F8:
                    result = 119;
                    return result;
                case Key.F9:
                    result = 120;
                    return result;
                case Key.F10:
                    result = 121;
                    return result;
                case Key.F11:
                    result = 122;
                    return result;
                case Key.F12:
                    result = 123;
                    return result;
                case Key.F13:
                    result = 124;
                    return result;
                case Key.F14:
                    result = 125;
                    return result;
                case Key.F15:
                    result = 126;
                    return result;
                case Key.F16:
                    result = 127;
                    return result;
                case Key.F17:
                    result = 128;
                    return result;
                case Key.F18:
                    result = 129;
                    return result;
                case Key.F19:
                    result = 130;
                    return result;
                case Key.F20:
                    result = 131;
                    return result;
                case Key.F21:
                    result = 132;
                    return result;
                case Key.F22:
                    result = 133;
                    return result;
                case Key.F23:
                    result = 134;
                    return result;
                case Key.F24:
                    result = 135;
                    return result;
                case Key.NumLock:
                    result = 144;
                    return result;
                case Key.Scroll:
                    result = 145;
                    return result;
                case Key.LeftShift:
                    result = 160;
                    return result;
                case Key.RightShift:
                    result = 161;
                    return result;
                case Key.LeftCtrl:
                    result = 162;
                    return result;
                case Key.RightCtrl:
                    result = 163;
                    return result;
                case Key.LeftAlt:
                    result = 164;
                    return result;
                case Key.RightAlt:
                    result = 165;
                    return result;
                case Key.BrowserBack:
                    result = 166;
                    return result;
                case Key.BrowserForward:
                    result = 167;
                    return result;
                case Key.BrowserRefresh:
                    result = 168;
                    return result;
                case Key.BrowserStop:
                    result = 169;
                    return result;
                case Key.BrowserSearch:
                    result = 170;
                    return result;
                case Key.BrowserFavorites:
                    result = 171;
                    return result;
                case Key.BrowserHome:
                    result = 172;
                    return result;
                case Key.VolumeMute:
                    result = 173;
                    return result;
                case Key.VolumeDown:
                    result = 174;
                    return result;
                case Key.VolumeUp:
                    result = 175;
                    return result;
                case Key.MediaNextTrack:
                    result = 176;
                    return result;
                case Key.MediaPreviousTrack:
                    result = 177;
                    return result;
                case Key.MediaStop:
                    result = 178;
                    return result;
                case Key.MediaPlayPause:
                    result = 179;
                    return result;
                case Key.LaunchMail:
                    result = 180;
                    return result;
                case Key.SelectMedia:
                    result = 181;
                    return result;
                case Key.LaunchApplication1:
                    result = 182;
                    return result;
                case Key.LaunchApplication2:
                    result = 183;
                    return result;
                case Key.Oem1:
                    result = 186;
                    return result;
                case Key.OemPlus:
                    result = 187;
                    return result;
                case Key.OemComma:
                    result = 188;
                    return result;
                case Key.OemMinus:
                    result = 189;
                    return result;
                case Key.OemPeriod:
                    result = 190;
                    return result;
                case Key.Oem2:
                    result = 191;
                    return result;
                case Key.Oem3:
                    result = 192;
                    return result;
                case Key.AbntC1:
                    result = 193;
                    return result;
                case Key.AbntC2:
                    result = 194;
                    return result;
                case Key.Oem4:
                    result = 219;
                    return result;
                case Key.Oem5:
                    result = 220;
                    return result;
                case Key.Oem6:
                    result = 221;
                    return result;
                case Key.Oem7:
                    result = 222;
                    return result;
                case Key.Oem8:
                    result = 223;
                    return result;
                case Key.Oem102:
                    result = 226;
                    return result;
                case Key.ImeProcessed:
                    result = 229;
                    return result;
                case Key.OemAttn:
                    result = 240;
                    return result;
                case Key.OemFinish:
                    result = 241;
                    return result;
                case Key.OemCopy:
                    result = 242;
                    return result;
                case Key.OemAuto:
                    result = 243;
                    return result;
                case Key.OemEnlw:
                    result = 244;
                    return result;
                case Key.OemBackTab:
                    result = 245;
                    return result;
                case Key.Attn:
                    result = 246;
                    return result;
                case Key.CrSel:
                    result = 247;
                    return result;
                case Key.ExSel:
                    result = 248;
                    return result;
                case Key.EraseEof:
                    result = 249;
                    return result;
                case Key.Play:
                    result = 250;
                    return result;
                case Key.Zoom:
                    result = 251;
                    return result;
                case Key.NoName:
                    result = 252;
                    return result;
                case Key.Pa1:
                    result = 253;
                    return result;
                case Key.OemClear:
                    result = 254;
                    return result;
                case Key.DeadCharProcessed:
                    result = 0;
                    return result;
            }
            result = 0;
            return result;
        }
    }
}
