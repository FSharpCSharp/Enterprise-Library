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
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

namespace PuzzlerUI
{
    class Startup
    {
        [STAThread]
        static void Main()
        {
            BootstrapEnterpriseLibrary();

            Application.ThreadException += 
                Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += 
                CurrentDomain_UnhandledException;

            Puzzler f = new Puzzler();
            Application.Run(f);
        }

        static void CurrentDomain_UnhandledException(object sender,
                                             UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                HandleException(
                    (Exception)e.ExceptionObject,
                    "Unhandled Policy");
            }
        }

        static void Application_ThreadException(object sender,
                                        ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, "UI Policy");
        }

        public static void HandleException(Exception ex, string policy)
        {
            bool rethrow = false;
            try
            {
                rethrow = ExceptionPolicy.HandleException(ex, policy);
            }
            catch (Exception innerEx)
            {
                string errorMsg = "An unexpected exception occurred while " +
                  "calling HandleException with policy'" + policy + "'. ";
                errorMsg += Environment.NewLine + innerEx.ToString();

                MessageBox.Show(errorMsg, "Application Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw ex;
            }

            if (rethrow)
            {
                //WARNING: this will truncate the stack of the exception 
                throw ex;
            }
            else
            {
                MessageBox.Show("An unhandled exception occurred"
                    + " and has been logged. Please contact support.");
            }
        }

        private static void BootstrapEnterpriseLibrary()
        {
            Logger.SetLogWriter(new LogWriter(BuildLoggingConfig()));

            var uiPolicies = new List<ExceptionPolicyEntry>
            {
                new ExceptionPolicyEntry(
                    typeof(Exception),
                    PostHandlingAction.None,
                    new IExceptionHandler[]
                    {
	                    new LoggingExceptionHandler(
                            "General", 100,
 	                        TraceEventType.Error,
	                        "Enterprise Library Exception Handling", 0, 			    
                            typeof(TextExceptionFormatter), Logger.Writer)
                    })
            };
            var policies = new List<ExceptionPolicyDefinition>
                {
                    new ExceptionPolicyDefinition("UI Policy", 
                        uiPolicies),
                };

            ExceptionPolicy.SetExceptionManager(new ExceptionManager(policies));
        }

        private static LoggingConfiguration BuildLoggingConfig()
        {
            // Formatters
            TextFormatter formatter =
                new TextFormatter(
                    @"Timestamp: {timestamp}{newline}
Message: {message}{newline}Category: {category}{newline}
Priority: {priority}{newline}EventId: {eventid}{newline}
Severity: {severity}{newline}Title:{title}{newline}
Machine: {localMachine}{newline}
App Domain: {localAppDomain}{newline}
ProcessId: {localProcessId}{newline}
Process Name: {localProcessName}{newline}
Thread Name: {threadName}{newline}
Win32 ThreadId: {win32ThreadId}{newline}
Extended Properties: {dictionary({key} - {value}{newline})}");

            // Listeners
            var flatFileTraceListener =
                new FlatFileTraceListener(
                    @"C:\Temp\Puzzler.log",
                    "----------------------------------------",
                    "----------------------------------------",
                    formatter);
            var eventLog =
                new EventLog("Application", ".",
                    "Enterprise Library Logging");
            var eventLogTraceListener = new
              FormattedEventLogTraceListener(eventLog);

            // Build Configuration
            var config = new LoggingConfiguration();
            config.AddLogSource("General", SourceLevels.All, true)
                .AddTraceListener(eventLogTraceListener);
            config.LogSources["General"]
                .AddTraceListener(flatFileTraceListener);

            // Special Sources Configuration
            config.SpecialSources.LoggingErrorsAndWarnings
                .AddTraceListener(eventLogTraceListener);

            return config;
        }
    }
}
