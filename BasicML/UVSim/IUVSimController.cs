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
    public interface IUVSimController
    {
        RichEditControl Console { get; }
        RichEditControl ProgramEditor { get; }
        string Input { get; set; }
        ManualResetEvent ResetEvent { get; set; }

        void StartExecution();
        void LoadFromFile(string fileName);
    }
}
