using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using DevExpress.Xpf.RichEdit;

namespace UVSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MAX_LINES = 1000;

        private IUVSimController controller;

        /// <summary>
        /// Console Control
        /// </summary>
        public RichEditControl Console
        {
            get { return reConsole; }
        }

        /// <summary>
        /// Program Editor Control
        /// </summary>
        public RichEditControl ProgramEditor
        {
            get { return reProgram; }
        }

        /// <summary>
        /// Window constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            controller = new UVSimController(this);
        }

        /// <summary>
        /// Handling line formatting in Program Editor
        /// </summary>
        /// <param name="sender">Program editor</param>
        /// <param name="e">Args</param>
        private void reProgram_Loaded(object sender, RoutedEventArgs e)
        {
            RichEditControl re = sender as RichEditControl;
            if (re == null)
                return;

            // Show line numbers
            re.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            re.Views.SimpleView.AllowDisplayLineNumbers = true;
            re.Views.SimpleView.Padding = new System.Windows.Forms.Padding(80, 4, 0, 0);

            re.Document.Sections[0].LineNumbering.RestartType = DevExpress.XtraRichEdit.API.Native.LineNumberingRestart.Continuous;
            re.Document.Sections[0].LineNumbering.Start = 0;
            re.Document.Sections[0].LineNumbering.CountBy = 1;
            re.Document.Sections[0].LineNumbering.Distance = 0.1f;

            // Set text color
            re.Document.DefaultCharacterProperties.ForeColor = System.Drawing.Color.Blue;

        }

        /// <summary>
        /// Checking for max lines
        /// </summary>
        /// <param name="sender">Program editor</param>
        /// <param name="e">Args</param>
        private void reProgram_ContentChanged(object sender, EventArgs e)
        {
            string text = ((RichEditControl)sender).Text;
            string[] lines = text.Split('\n');

            // Check that number of lines does't exceed the limit
            if (lines.Length > MAX_LINES)
            {
                StringBuilder builder = new StringBuilder();
                for (int i=0; i<MAX_LINES; i++)
                {
                    builder.Append(lines[i] + '\n');
                }
                ((RichEditControl)sender).Text = builder.ToString();
            }
        }

        /// <summary>
        /// Set console line formatting
        /// </summary>
        /// <param name="sender">Console</param>
        /// <param name="e">Args</param>
        private void reConsole_Loaded(object sender, RoutedEventArgs e)
        {
            RichEditControl re = sender as RichEditControl;
            if (re == null)
                return;

            // Set font to monospace
            re.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            re.Document.DefaultCharacterProperties.FontName = "PT Serif";
        }

        /// <summary>
        /// Execute button handler
        /// </summary>
        /// <param name="sender">Execute button</param>
        /// <param name="e">Args</param>
        private async void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            // Start task in another thread
            await Task.Run(() => StartExecution());
        }

        /// <summary>
        /// Start execution of a BasicML program
        /// </summary>
        private void StartExecution()
        {
            // Block controls
            this.Dispatcher.Invoke(() =>
            {
                reProgram.ReadOnly = true;
                btnExecute.IsEnabled = false;
            });

            // Execute
            controller.StartExecution();

            // Release control
            this.Dispatcher.Invoke(() =>
            {
                btnExecute.IsEnabled = true;
                reProgram.ReadOnly = false;
            });
        }

        /// <summary>
        /// Start compilation of a BasicML program
        /// </summary>
        /// <param name="fileName">File name</param>
        private void StartCompilation(string fileName)
        {
            // Block controls
            this.Dispatcher.Invoke(() =>
            {
                reProgram.ReadOnly = true;
                btnExecute.IsEnabled = false;
            });

            // Compile
            controller.StartCompilation(fileName);

            // Release control
            this.Dispatcher.Invoke(() =>
            {
                btnExecute.IsEnabled = true;
                reProgram.ReadOnly = false;
            });
        }

        /// <summary>
        /// "Compile" button handler
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Args</param>
        private async void btnCompile_Click(object sender, RoutedEventArgs e)
        {
            // Get file name from dialogue window
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "C# source file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Start compilation task in another thread
                await Task.Run(() => StartCompilation(saveFileDialog.FileName));
            }
        }

        /// <summary>
        /// Capture keyboard key pressings in console window
        /// </summary>
        /// <param name="sender">Console</param>
        /// <param name="e">Args</param>
        private void reConsole_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (controller.ResetEvent != null)
            {
                switch (e.Key)
                {
                    case Key.D0:
                        controller.Input += "0";
                        reConsole.Write("0");
                        break;
                    case Key.D1:
                        controller.Input += "1";
                        reConsole.Write("1");
                        break;
                    case Key.D2:
                        controller.Input += "2";
                        reConsole.Write("2");
                        break;
                    case Key.D3:
                        controller.Input += "3";
                        reConsole.Write("3");
                        break;
                    case Key.D4:
                        controller.Input += "4";
                        reConsole.Write("4");
                        break;
                    case Key.D5:
                        controller.Input += "5";
                        reConsole.Write("5");
                        break;
                    case Key.D6:
                        controller.Input += "6";
                        reConsole.Write("6");
                        break;
                    case Key.D7:
                        controller.Input += "7";
                        reConsole.Write("7");
                        break;
                    case Key.D8:
                        controller.Input += "8";
                        reConsole.Write("8");
                        break;
                    case Key.D9:
                        controller.Input += "9";
                        reConsole.Write("9");
                        break;
                    case Key.Enter:
                        reConsole.Write("\n");
                        if (controller.ResetEvent != null)
                        {
                            controller.ResetEvent.Set();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// "Load from file" button handler
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Args</param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Get file name from dialog window
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Load content from file
                controller.LoadFromFile(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// "Load Multiple Programs" button handler
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Args</param>
        private void btnLoadMultiple_Click(object sender, RoutedEventArgs e)
        {
            // Get file names from dialog window
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                // Load contents from file
                controller.LoadMultiple(openFileDialog.FileNames);
            }
        }

        /// <summary>
        /// "Save to file" button handler
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Args</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Get file name from dialog window
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                // Save content to file
                controller.SaveToFile(saveFileDialog.FileName);
            }
        }
    }
}
