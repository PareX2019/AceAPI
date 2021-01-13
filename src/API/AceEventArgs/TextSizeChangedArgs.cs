using System;

namespace tesstbigds.AceEventArgs
{
    public class TextSizeChangedArgs : EventArgs
    {
        public string oldSize { get; set; }
        public string newSize { get; set; }
    }
}