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
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace StocksTicker.Loggers
{
    public class CompositeLogger : ILogger
    {
        private IEnumerable<ILogger> loggers;

        public CompositeLogger(ILogger[] loggers)
        {
            this.loggers = (IEnumerable<ILogger>)loggers.Clone();
        }

        public void Log(string message, TraceEventType eventType)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Log(message, eventType);
            }
        }
    }
}