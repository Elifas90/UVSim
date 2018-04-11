using System;
using System.Threading;
using DevExpress.Xpf.RichEdit;

namespace UVSim
{
    public static class ConsoleExtension
    {
        public static void ClearConsole(this RichEditControl console)
        {
            console.Dispatcher.Invoke(() =>
            {
                console.BeginUpdate();
                console.Document.Delete(console.Document.Range);
                console.EndUpdate();
            });
        }

        public static void Write(this RichEditControl console, string line)
        {
            console.Dispatcher.Invoke(() =>
            {
                console.BeginUpdate();
                console.Document.InsertText(console.Document.CaretPosition, line);
                console.EndUpdate();
            });
        }

        public static void WriteLine(this RichEditControl console, string line)
        {
            console.Dispatcher.Invoke(() =>
            {
                console.BeginUpdate();
                console.Document.InsertText(console.Document.CaretPosition, line + Environment.NewLine);
                console.EndUpdate();
            });
        }

        public static void Error(this IUVSimController window, int lineNumber, string error)
        {
            RichEditControl console = window.Console;
            //RichEditControl programEdit = window.ProgramEditor;
            console.Dispatcher.Invoke(() =>
            {
                console.BeginUpdate();
                var paragraph = console.Document.Paragraphs.Append();
                console.Document.InsertText(paragraph.Range.Start, $"Error in line {lineNumber + 1}: {error}.\r\n");
                var charProperties = console.Document.BeginUpdateCharacters(paragraph.Range);
                charProperties.ForeColor = System.Drawing.Color.Red;
                console.Document.EndUpdateCharacters(charProperties);
                console.EndUpdate();
            });
        }

        public static int Read(this IUVSimController window)
        {
            window.Input = string.Empty;
            window.ResetEvent = new ManualResetEvent(false);
            window.Console.Dispatcher.Invoke(() =>
            {
                window.Console.Focus();
            });
            window.ResetEvent.WaitOne();
            window.ResetEvent.Close();
            window.ResetEvent = null;
            int result = 0;
            int.TryParse(window.Input, out result);
            return result;
        }
    }
}
