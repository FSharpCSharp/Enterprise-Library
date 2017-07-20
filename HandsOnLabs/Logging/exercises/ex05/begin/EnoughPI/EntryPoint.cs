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
using System.Windows.Forms;
using System.Diagnostics;
using EnoughPI.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace EnoughPI
{
    public class EntryPoint
    {
        private EntryPoint() {}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.ThreadException += 
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Logger.SetLogWriter(new LogWriter(BuildProgrammaticConfig()));

            Form entryForm = new MainForm();
            Application.EnableVisualStyles();
            Application.Run(entryForm);

            // shut down the logger to flush all buffers
            Logger.Reset();
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

        private static LoggingConfiguration BuildProgrammaticConfig()
        {
            // Formatter
            TextFormatter formatter = new TextFormatter("Timestamp: {timestamp(local)}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}ActivityId: {property(ActivityId)}{newline}Severity: {severity}{newline}Title:{title}{newline}");

            // Trace Listeners
            var eventLog = new EventLog("Application", ".", "EnoughPI");
            var eventLogTraceListener = new FormattedEventLogTraceListener(eventLog, formatter);
            var flatFileTraceListener = new FlatFileTraceListener(@"C:\Temp\trace.log", "----------------------------------------", "----------------------------------------", formatter);
            var customTraceListener = new EnoughPI.Logging.TraceListeners.ConsoleTraceListener("-----------------------");
            customTraceListener.Formatter = formatter;

            // Build Configuration
            var config = new LoggingConfiguration();
            config.AddLogSource(Category.General, SourceLevels.All, true).AddTraceListener(eventLogTraceListener);
            config.AddLogSource(Category.Trace, SourceLevels.ActivityTracing, true).AddTraceListener(flatFileTraceListener);
            config.LogSources[Category.General].AddTraceListener(customTraceListener);

            config.IsTracingEnabled = true;

            return config;
        }
    }
}
