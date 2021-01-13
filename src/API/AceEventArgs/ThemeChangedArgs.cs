using System;

namespace tesstbigds.AceEventArgs
{
    public class ThemeChangedArgs : EventArgs
    {
        public string oldTheme { get; set; }
        public string newTheme { get; set; }
    }
}