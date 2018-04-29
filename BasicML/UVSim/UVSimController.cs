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

    /// <summary>
    /// Controller implementation class
    /// </summary>
    public class UVSimController : IUVSimController
    {
        private RichEditControl _console;
        private RichEditControl _programEditor;

        /// <summary>
        /// Console Control
        /// </summary>
        public RichEditControl Console
        {
            get { return _console; }
        }

        /// <summary>
        /// Program Editor
        /// </summary>
        public RichEditControl ProgramEditor
        {
            get { return _programEditor; }
        }

        /// <summary>
        /// Console input
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Event for interthread control
        /// </summary>
        public ManualResetEvent ResetEvent { get; set; }

        /// <summary>
        /// Controller construction
        /// </summary>
        /// <param name="window">reference to view</param>
        public UVSimController(MainWindow window)
        {
            _console = window.Console;
            _programEditor = window.ProgramEditor;
        }

        /// <summary>
        /// Execution of BasicML Program
        /// </summary>
        public void StartExecution()
        {
            MemoryManager mm = new MemoryManager();
            Assembler prototype = new Assembler(this, mm);
            prototype.PrintIntroduction();
            prototype.ReadInstructions(ProgramEditor.Text.Split('\n'));
            VirtualMachine trial = new VirtualMachine(prototype.GetMemory(), prototype.GetProgramCount(), this);
            trial.Execute();
            trial.PrintFooter();
        }

        /// <summary>
        /// Load program from file
        /// </summary>
        /// <param name="fileName">File name</param>
        public void LoadFromFile(string fileName)
        {
            // Load text from file into text editor
            ProgramEditor.Document.Delete(ProgramEditor.Document.Range);
            ProgramEditor.Document.AppendText(File.ReadAllText(fileName));
        }

        /// <summary>
        /// Load multiple programs
        /// </summary>
        /// <param name="fileNames">File names</param>
        public void LoadMultiple(string[] fileNames)
        {
            // Clear editor
            ProgramEditor.Document.Delete(ProgramEditor.Document.Range);

            // Loop through all selected files
            int numPrograms = 0;
            foreach (string fileName in fileNames)
            {
                numPrograms++;

                // Check if we exceeded max programs
                if (numPrograms > Thread.MAX_THREAD)
                    break;

                // Zero Memory between programs
                if (!string.IsNullOrEmpty(ProgramEditor.Text))
                {
                    int numLines = ProgramEditor.Text.Split('\n').Length - 1;
                    for (int i = 0; i < (Thread.THREAD_OFFSET - (numLines % Thread.THREAD_OFFSET)); i++)
                    {
                        ProgramEditor.Document.AppendText("0000" + Environment.NewLine);
                    }
                }

                // Load text from file into editor
                ProgramEditor.Document.AppendText(File.ReadAllText(fileName) + Environment.NewLine);
            }
        }

        /// <summary>
        /// Save program to file
        /// </summary>
        /// <param name="filename">File name</param>
        public void SaveToFile(string filename)
        {
            // Save text from text editor into file
            File.WriteAllText(filename, ProgramEditor.Document.Text);
        }
    }
}
