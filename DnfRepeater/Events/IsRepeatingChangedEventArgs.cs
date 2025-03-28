using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnfRepeater.Events
{
    public class IsRepeatingChangedEventArgs : EventArgs
    {
        public bool IsRepeating { get; }
        public IsRepeatingChangedEventArgs(bool isRepeating)
        {
            IsRepeating = isRepeating;
        }
    }
}
