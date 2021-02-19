using CefSharp;
using CefSharp.Wpf;
using System;
using System.Windows;

namespace tesstbigds
{
    public partial class AceEditor : ChromiumWebBrowser
    {
        public bool Ready = false;

        /* events */

        public event EventHandler<AceEventArgs.ThemeChangedArgs> AceThemeChanged;

        public event EventHandler<AceEventArgs.TextSizeChangedArgs> AceTextSizeChanged;

        public event EventHandler<AceEventArgs.ReadOnlyChangedArgs> AceReadOnlyChanged;

        public AceEditor()
        {
            Address = new Uri($"{AppDomain.CurrentDomain.BaseDirectory}\\ace\\ace.html").AbsoluteUri;
        }

        /* Events Start */

        protected virtual void OnReadOnlyChanged(AceEventArgs.ReadOnlyChangedArgs e)
        {
            EventHandler<AceEventArgs.ReadOnlyChangedArgs> handler = AceReadOnlyChanged;
            if (handler is not null)
                handler(this, e);
        }

        protected virtual void OnThemeChanged(AceEventArgs.ThemeChangedArgs e)
        {
            EventHandler<AceEventArgs.ThemeChangedArgs> handler = AceThemeChanged;
            if (handler is not null)
                handler(this, e);
        }

        protected virtual void OnTextSizeChanged(AceEventArgs.TextSizeChangedArgs e)
        {
            EventHandler<AceEventArgs.TextSizeChangedArgs> handler = AceTextSizeChanged;
            if (handler is not null)
                handler(this, e);
        }

        /* Events End */

        /* Methods Start */

        public void ClearText() => this.AceText = "";

        public void Redo() => this.Execute("Redo();");

        public void Undo() => this.Execute("Undo();");

        public void SetDefaults() => this.Execute("SetDefaults();");

        public void ClearSelection() => this.Execute("ClearSelection();");

        public void GoToLine(int line) => this.Execute($"editor.gotoLine({line})");

        public string GetLine(int line)
        {
            return (string)this.Execute($"editor.session.getLine({line});");
        }

        public object GetLines(int from, int to)
        {
            return this.Execute($"GetLines({from} , {to});");
        }

        public int GetEditorLength()
        {
            return (int)this.Execute("editor.session.getLength();");
        }

        public void Paste() => this.Execute($"editor.execCommand('paste','{Clipboard.GetText()}');");

        public string GetSelectedText()
        {
            return (string)this.Execute($"GetSelectedText();");
        }

        public void Copy()
        {
            if (GetSelectedText().Length > 0)
                Clipboard.SetText(GetSelectedText());
        }

        public string[] AllThemes()
        {
            string[] a = { "ambiance", "chaos", "chrome", "clouds", "clouds_midnight", "cobalt", "crimson_editor", "dawn", "dracula", "dreamweaver", "eclipse", "github", "gob", "gruvbox", "idle_fingers", "iplastic", "katzenmilch", "kr_theme", "kuroir", "merbivore", "merbivore_soft", "monokai", "mono_industrial", "nord_dark", "pastel_on_dark", "solarized_dark", "solarized_light", "sqlserver", "terminal", "textmate", "tomorrow", "tomorrow_night", "tomorrow_night_blue", "tomorrow_night_bright", "tomorrow_night_eighties", "twilight", "vibrant_ink", "xcode" };
            return a;
        }

        public object GetSelectedRowNumbers()
        {
            return this.Execute("editor.$getSelectedRows();");
        }

        public void Cut() => this.Execute("editor.execCommand('cut');");

        /*Search*/

        public int FindAll(string word)
        {
            return (int)this.Execute($"editor.findAll('{word}');");
        }

        public void FindNext(string word) => this.Execute($"findNext('{word}');");

        public void FindPrevious(string word) => this.Execute($"findPrevious('{word}');");

        /* Search End */

        /* Replace */

        public void ReplaceAll(string wordToReplace, string word) => this.Execute($"ReplaceAll('{wordToReplace}', '{word}');");

        public void Replace(string wordToReplace, string word) => this.Execute($"Replace('{wordToReplace}', '{word}');");

        /* Replace End */

        /* Methods End */

        private object Execute(string script)
        {
            var Object = this.EvaluateScriptAsync(script);
            Object.Wait();
            return Object.Result.Success ? Object.Result.Result ?? "" : Object.Result.Message;
        }

        /* Properties Start */

        public int TextLengnth()
        {
            return this.AceText.Length;
        }

        public string AceTheme
        {
            get
            {
                if (!this.IsLoading)
                {
                    return (string)this.Execute("GetTheme();");
                }
                throw new Exception("Editor not loaded!");
            }

            set
            {
                string oldTheme = (string)this.Execute("GetCurrentTheme();");
                AceEventArgs.ThemeChangedArgs changedArgs = new()
                {
                    newTheme = value,
                    oldTheme = oldTheme
                };
                this.EvaluateScriptAsync("SetTheme", value);
                OnThemeChanged(changedArgs);
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (!this.IsLoading)
                {
                    return bool.Parse((string)Execute("editor.$readOnly"));
                }
                throw new Exception("Editor not loaded!");
            }

            set
            {
                if (!this.IsLoading)
                {
                    bool oldValue = (bool)this.Execute("editor.$readOnly");
                    AceEventArgs.ReadOnlyChangedArgs changedArgs = new()
                    {
                        newValue = value,
                        oldValue = oldValue
                    };
                    this.Execute($"editor.$readOnly={value}");
                    OnReadOnlyChanged(changedArgs);
                }
            }
        }

        public string AceTextSize
        {
            get
            {
                if (!this.IsLoading)
                {
                    return (string)this.Execute("GetFontSize();");
                }
                throw new Exception("Editor not loaded!");
            }

            set
            {
                if (this.IsLoading) return;
                string oldSize = (string)this.Execute("GetFontSize();");
                AceEventArgs.TextSizeChangedArgs changedArgs = new()
                {
                    newSize = value,
                    oldSize = oldSize
                };
                this.EvaluateScriptAsync($"SetFontSize({value})");
                OnTextSizeChanged(changedArgs);
            }
        }

        public string AceText
        {
            get
            {
                if (!this.IsLoading)
                {
                    return (string)this.Execute("GetText();");
                }
                throw new Exception("Editor not loaded!");
            }

            set
            {
                if (!this.IsLoading)
                    this.EvaluateScriptAsync("SetText", value);
            }
        }

        /* Properties End */
    }
}
