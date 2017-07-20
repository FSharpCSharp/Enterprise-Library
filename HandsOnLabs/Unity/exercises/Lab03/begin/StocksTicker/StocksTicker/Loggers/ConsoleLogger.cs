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

namespace StocksTicker.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, TraceEventType eventType)
        {
            Console.WriteLine("{0:G} - {1}: {2}", DateTime.Now, eventType, message);
        }
    }
}
