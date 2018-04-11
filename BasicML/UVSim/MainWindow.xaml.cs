﻿using System;
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

        public RichEditControl Console
        {
            get { return reConsole; }
        }

        public RichEditControl ProgramEditor
        {
            get { return reProgram; }
        }

        public MainWindow()
        {
            InitializeComponent();

            controller = new UVSimController(this);
        }

        private void reProgram_Loaded(object sender, RoutedEventArgs e)
        {
            RichEditControl re = sender as RichEditControl;
            if (re == null)
                return;

            re.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            re.Views.SimpleView.AllowDisplayLineNumbers = true;
            re.Views.SimpleView.Padding = new System.Windows.Forms.Padding(80, 4, 0, 0);

            re.Document.Sections[0].LineNumbering.RestartType = DevExpress.XtraRichEdit.API.Native.LineNumberingRestart.Continuous;
            re.Document.Sections[0].LineNumbering.Start = 1;
            re.Document.Sections[0].LineNumbering.CountBy = 1;
            re.Document.Sections[0].LineNumbering.Distance = 0.1f;
            re.Document.DefaultCharacterProperties.ForeColor = System.Drawing.Color.Blue;

        }

        private void reProgram_ContentChanged(object sender, EventArgs e)
        {
            string text = ((RichEditControl)sender).Text;
            string[] lines = text.Split('\n');
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

        private void reConsole_Loaded(object sender, RoutedEventArgs e)
        {
            RichEditControl re = sender as RichEditControl;
            if (re == null)
                return;

            re.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            re.Document.DefaultCharacterProperties.FontName = "PT Serif";
        }

        private async void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => StartExecution());
        }

        private void StartExecution()
        {
            this.Dispatcher.Invoke(() =>
            {
                reProgram.ReadOnly = true;
                btnExecute.IsEnabled = false;
            });

            controller.StartExecution();

            this.Dispatcher.Invoke(() =>
            {
                btnExecute.IsEnabled = true;
                reProgram.ReadOnly = false;
            });
        }

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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                controller.LoadFromFile(openFileDialog.FileName);
            }
        }
    }
}