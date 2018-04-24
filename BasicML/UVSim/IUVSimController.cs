using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using DevExpress.Xpf.RichEdit;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Nikita Pestin

// Implementation file for the "IUVSimController" interface.

namespace UVSim
{
    /// <summary>
    /// Controller interface
    /// </summary>
    public interface IUVSimController
    {
        /// <summary>
        /// Console Control
        /// </summary>
        RichEditControl Console { get; }

        /// <summary>
        /// Program Editor Control
        /// </summary>
        RichEditControl ProgramEditor { get; }

        /// <summary>
        /// Input from console
        /// </summary>
        string Input { get; set; }

        /// <summary>
        /// Reset event for interthread control
        /// </summary>
        ManualResetEvent ResetEvent { get; set; }

        /// <summary>
        /// Start execution of BasicML program
        /// </summary>
        void StartExecution();

        /// <summary>
        /// Load program from file
        /// </summary>
        /// <param name="fileName">File name</param>
        void LoadFromFile(string fileName);

        /// <summary>
        /// Save program to file
        /// </summary>
        /// <param name="fileName">File name</param>
        void SaveToFile(string fileName);
    }
}
