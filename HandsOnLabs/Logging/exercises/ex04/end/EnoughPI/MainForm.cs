//===============================================================================
// Microsoft patterns & practices
// Enterprise Library 6 and Unity 3 Hands-on Labs
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using EnoughPI.Calc;

using EnoughPI.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

namespace EnoughPI
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private EnoughPI.Components.MarqueeProvider marqueeProvider1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCalculate;
        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuFileExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private Button button1;
        private System.Windows.Forms.Panel panel1;

        private int numUpdates = 0;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            Init();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }


        public void UpdateConfiguration()
        {
            numUpdates++;
            Logger.Writer.Configure(config =>
            {
                TextFormatter formatter = new TextFormatter("Timestamp: {timestamp(local)}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}ActivityId: {property(ActivityId)}{newline}Severity: {severity}{newline}Title:{title}{newline}");
                var newDest = new FlatFileTraceListener(@"C:\Temp\trace-" + numUpdates + @".log", "----------------------------------------", "----------------------------------------", formatter);
                config.SpecialSources.AllEvents.Listeners.Clear();
                config.SpecialSources.AllEvents.AddTraceListener(newDest);

            });
        }


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.marqueeProvider1 = new EnoughPI.Components.MarqueeProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 312);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(265, 22);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 98;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marqueeProvider1.SetAnimationWait(this.progressBar1, 50);
            this.marqueeProvider1.SetIsMarquee(this.progressBar1, true);
            this.progressBar1.Location = new System.Drawing.Point(157, 422);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(0, 14);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 56);
            this.panel2.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculate.Location = new System.Drawing.Point(165, 11);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(88, 32);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(104, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 26);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digits of PI";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 0;
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 312);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(265, 256);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(265, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Never Enough PI";
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region PI Calculation Stuff ...

        // Calculation of PI
        enum CalcState 
        {
            Pending,
            Calculating,
            Canceled,
        }

        private Calculator pi;
        private CalcState state;

        private void Init()
        {
            // Resize & locate the progress bar
            this.progressBar1.Width = this.statusBarPanel2.Width - 20;
            this.progressBar1.Height = this.statusBar1.Height - 6;

            this.progressBar1.Location =
                new Point(
                this.statusBar1.Location.X + this.statusBarPanel1.Width + 10,
                this.statusBar1.Location.Y + 4
                );

            this.MinimumSize = this.Size;

            this.pi = new Calculator();
            this.pi.Calculated += new CalculatedEventHandler(pi_Calculated);
            this.pi.Calculating += new CalculatingEventHandler(pi_Calculating);
            this.pi.CalculatorException += new CalculatorExceptionEventHandler(pi_CalculatorException);

            SetFormState(CalcState.Pending);        
        }

        private void btnCalculate_Click(object sender, System.EventArgs e)
        {
            int digits = (int) this.numericUpDown1.Value;

            switch (state)
            {
                case CalcState.Pending:
                    // Start a new calculation
                    SetFormState(CalcState.Calculating);

                    // Begin Async Calculation
                    this.pi.BeginCalculate(digits);

                    break;

                case CalcState.Calculating:
                    // Cancel a running calculation
                    SetFormState(CalcState.Canceled);
                    break;

                case CalcState.Canceled:
                    // Shouldn't be able to press button while it's canceling
                    Debug.Assert(false);
                    break;
            }
        }

        private void pi_Calculated(object sender, CalculatedEventArgs args)
        {
            if (this.InvokeRequired)
            {
                CalculatedEventHandler self;
                self = new CalculatedEventHandler(this.pi_Calculated);
                this.Invoke(self, new object[] {sender, args});
            }
            else
            {
                SetFormState(CalcState.Pending);

                this.textBox1.Text = args.Pi;
                this.statusBarPanel1.Text = string.Format("{0} digit(s)", args.Digits.ToString());
            }
        }

        private void pi_Calculating(object sender, CalculatingEventArgs args)
        {
            if (this.InvokeRequired)
            {
                CalculatingEventHandler self;
                self = new CalculatingEventHandler(this.pi_Calculating);
                this.Invoke(self, new object[] {sender, args});
            }
            else
            {
                args.Cancel = (this.state == CalcState.Canceled);

                this.textBox1.Text = args.Pi;
                this.statusBarPanel1.Text = string.Format("Completed {0}", (args.StartingAt - 1).ToString());
            }
        }

        private void pi_CalculatorException(object sender, CalculatorExceptionEventArgs args)
        {
            if (this.InvokeRequired)
            {
                CalculatorExceptionEventHandler self;
                self = new CalculatorExceptionEventHandler(this.pi_CalculatorException);
                this.Invoke(self, new object[] {sender, args});
            }
            else
            {
                string message;
                message = string.Format("Exception:\n\n{0}", args.Exception);
                MessageBox.Show(message, "Application Error");

                SetFormState(CalcState.Pending);
            }
        }

        private void SetFormState(CalcState newstate)
        {
            switch (newstate)
            {
                case CalcState.Calculating:
                    // Allow canceling
                    this.state = newstate;
                    this.btnCalculate.Text = "Cancel";
                    this.btnCalculate.Enabled = true;
                    this.progressBar1.Visible = true;
                    this.statusBarPanel1.Text = "Calculating ...";
                    break;

                case CalcState.Canceled:
                    this.state = newstate;
                    this.btnCalculate.Enabled = false;
                    break;

                case CalcState.Pending:
                default:
                    this.state = newstate;
                    this.btnCalculate.Text = "Calculate";
                    this.btnCalculate.Enabled = true;
                    this.progressBar1.Visible = false;
                    this.statusBarPanel1.Text = "";
                    break;
            }
        }

        #endregion

        #region Menu event handlers

        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateConfiguration();
        }
    }
}
