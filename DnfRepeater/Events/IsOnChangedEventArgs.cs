using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Events
{
    public class IsOnChangedEventArgs : EventArgs
    {
        public bool IsOn { get; }
        public string? TargetWindowTitle { get; }
        public IsOnChangedEventArgs(bool isOn, string? targetWindowTitle)
        {
            IsOn = isOn;
            TargetWindowTitle = targetWindowTitle;
        }
    }
}
