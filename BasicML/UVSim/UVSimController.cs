using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DevExpress.Xpf.RichEdit;

namespace UVSim
{
    //-----------------------------------------------------------------------------------------------------------------------
    //  File Designed by: Josh Cooley

    // Implementation file for the "UVSimController" class.
    public class UVSimController : IUVSimController
    {
        private RichEditControl _console;
        private RichEditControl _programEditor;

        public RichEditControl Console
        {
            get { return _console; }
        }

        public RichEditControl ProgramEditor
        {
            get { return _programEditor; }
        }

        public string Input { get; set; }
        public ManualResetEvent ResetEvent { get; set; }

        public UVSimController(MainWindow window)
        {
            _console = window.Console;
            _programEditor = window.ProgramEditor;
        }

        public void StartExecution()
        {
            MemoryManager mm = new MemoryManager();
            Assembler prototype = new Assembler(this, mm);
            prototype.PrintIntroduction();
            prototype.ReadInstructions(ProgramEditor.Text.Split('\n'));
            VirtualMachine trial = new VirtualMachine(prototype.GetMemory(), this);
            trial.Execute();
            trial.PrintFooter();
        }

        public void LoadFromFile(string fileName)
        {
            ProgramEditor.Document.AppendText(File.ReadAllText(fileName));
        }
    }
}
