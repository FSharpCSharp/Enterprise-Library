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
// TODO: Add Enterprise Library namespaces
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace EnoughPI.Logging.TraceListeners
{
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class ConsoleTraceListener : CustomTraceListener
    {
        public ConsoleTraceListener()
            : base()
        {
        }

        public ConsoleTraceListener(string del)
        {
            this.Attributes["delimiter"] = del;
        }

        public override void TraceData(TraceEventCache eventCache,
            string source, TraceEventType eventType, int id, object data)
        {
            if (data is LogEntry && this.Formatter != null)
            {
                this.WriteLine(this.Formatter.Format(data as LogEntry));
            }
            else
            {
                this.WriteLine(data.ToString());
            }
        }

        public override void Write(string message)
        {
            Console.Write((string)this.Attributes["delimiter"]);

            Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            // Delimit each message
            Console.WriteLine((string)this.Attributes["delimiter"]);

            // Write formatted message
            Console.WriteLine(message);
        }

    }
}
