using System;

namespace tesstbigds.AceEventArgs
{
    public class ReadOnlyChangedArgs : EventArgs
    {
        public bool oldValue { get; set; }
        public bool newValue { get; set; }
    }
}