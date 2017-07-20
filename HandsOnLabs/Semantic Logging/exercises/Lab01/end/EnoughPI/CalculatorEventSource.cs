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

namespace EnoughPI
{
    public class CalculatorEventSource : EventSource
    {
        private static readonly Lazy<CalculatorEventSource> Instance = new Lazy<CalculatorEventSource>(() => new CalculatorEventSource());

        private CalculatorEventSource() { }
        public static CalculatorEventSource Log
        {
            get { return Instance.Value; }
        }

        [Event(100, Message="PI was calculated to {0} digits", Level=EventLevel.Informational)]
        internal void Calculated(int digits)
        {
            this.WriteEvent(100, digits);
        }

        [Event(101, Message="Calculating PI from {0} digits. Current value is {1}.", Level = EventLevel.Informational)]
        internal void Calculating(int digit, string pi, bool cancelled)
        {
            this.WriteEvent(101, digit, pi, cancelled);
        }

        [Event(102, Message="Calculation canceled!", Level = EventLevel.Warning)]
        internal void CalculationCanceled()
        {
            this.WriteEvent(102);
        }

        [Event(103, Message="Calculator Exception Thrown!", Level = EventLevel.Error)]
        internal void CalculatorException(string exception)
        {
            this.WriteEvent(103, exception);
        }

        public static string FormatException(Exception exception)
        {
            return exception.GetType().ToString() + Environment.NewLine + exception.Message;
        }


    }
}
