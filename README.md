# AceAPI

AceAPI is a library that helps you use Ace Editor in a WPF application

## Installation

Import the [files](https://github.com/PareX2019/AceAPI/tree/main/src) in your project and your good to go.

## Usage

Getting Started:
Once you have imported all the files to your project and replaced all the names to your project 
you can now start programming. 

Setting up the editor:
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri,
 
};
 editor.SetDefaults();
 /* Defaults:
 Text Size: 13
 Theme: tomorrow_night_eighties */
```

Read Only: GET/SET(bool)
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri,
  isReadOnly = true
};
  MessageBox.Show(editor.IsReadOnly.ToString()); //expected output: true
```

Ace Theme: GET/SET(string) , There are many [Themes](https://github.com/ajaxorg/ace/tree/master/lib/ace/theme) and you can create your own theme.
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri,
  AceTheme = "github"
};
  MessageBox.Show(editor.AceTheme);//expected output: github

```

Ace Text Size: GET/SET(int)
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri,
  AceTextSize= "13px"
};
  MessageBox.Show(editor.AceTextSize.ToString());//expected output: 13

```
Ace Text: GET/SET(string)
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri,
  AceText= "Hello World!"
};
  MessageBox.Show(editor.AceTextSize.ToString());//expected output: Hello World!
```

## Events
Ace TextSize Changed:
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri
};
  editor.SetDefaults();
  editor.AceTextSizeChanged += Editor_AceTextSizeChanged;

private void Editor_AceTextSizeChanged(object sender, AceEventArgs.TextSizeChangedArgs e)
{
   int oldSize = e.oldSize;
   int newSize = e.newSize;
};  

```

Ace Them Changed:
```csharp
AceEditor editor = new()
{
  Address = new Uri($"{Environment.CurrentDirectory}\\ace\\ace.html").AbsoluteUri
};
  editor.SetDefaults();
  editor.AceTextSizeChanged += Editor_AceThemeChanged;

private void Editor_AceThemeChanged(object sender, AceEventArgs.ThemeChangedArgs e)
{
  string oldTheme = e.oldTheme;
  string newTheme = e.newTheme;
} 

```

## Functions

```csharp
new AceEditor().AllThemes();// returns all the themes in an array.
```

```csharp
new AceEditor().GetSelectedRowNumbers();//returns an object of the first and last selected lines.
```

```csharp
new AceEditor().Cut();//cut's.
```
```csharp
new AceEditor().Copy();//copy's.
```
```csharp
new AceEditor().Cut();//Pastes.
```
```csharp
new AceEditor().GetLines(0,2);//will return all the text between these two lines.
```
```csharp
new AceEditor().GetLine(2);//will return all the text in the selected line.
```
```csharp
new AceEditor().GoToLine(2);//goes to the selected line.
```
```csharp
new AceEditor().GetLines(0,2);//will return all the text between these two lines.
```
```csharp
new AceEditor().ClearSelection();//clears all the selected text.
```
```csharp
new AceEditor().Undo();//undo.
```
```csharp
new AceEditor().Redo();//redo.
```
```csharp
new AceEditor().SetDefaults();//sets the editor to default settings.
```
```csharp
new AceEditor().ClearText();//clears the editors text.
```
```csharp
new AceEditor().ClearText();//clears the editors text.
```
```csharp
new AceEditor().GetEditorLength();//returns the total line count.
```
## Search Functions
```csharp
new AceEditor().FindAll(word);//finds all the words given by the value and returns the total matches in a number.
```
```csharp
new AceEditor().FindNext(word);//finds the next word given by the value.
```
```csharp
new AceEditor().FindPrevious(word);//finds the previous word given by the value.
```
## Replace Functions
```csharp
new AceEditor().ReplaceAll(wordToReplace,word);//replaces all the words according to the value.
```
```csharp
new AceEditor().Replace(wordToReplace,word);//replaces the closests word according to the value.
```
