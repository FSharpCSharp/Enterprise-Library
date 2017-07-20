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
using System.Diagnostics.Tracing;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Formatters;

namespace EnoughPI
{
    public class EntryPoint
    {
        private EntryPoint() { }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.ThreadException += 
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            //create formatter
            var formatter = new JsonEventTextFormatter(EventTextFormatting.Indented);

            //TODO: Set up and enable the event listener
            using (var listener = new ObservableEventListener())
            {
                listener.LogToConsole(formatter);
                listener.EnableEvents(CalculatorEventSource.Log, EventLevel.LogAlways, Keywords.All);

                Form entryForm = new MainForm();
                Application.EnableVisualStyles();
                Application.Run(entryForm);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string message;
            message = string.Format("Exception:\n\n{0}\n\nDo you want to Continue [Yes], or Quit [No]?", e.Exception);

            DialogResult dr;
            dr = MessageBox.Show(message, "Application Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No) 
                Application.Exit();
        }
    }
}
