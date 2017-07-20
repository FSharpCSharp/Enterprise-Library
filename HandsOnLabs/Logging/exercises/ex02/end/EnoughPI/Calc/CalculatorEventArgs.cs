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
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EnoughPI.Calc
{
    
    #region CalculatedEventArgs

    public delegate void CalculatedEventHandler(object sender, CalculatedEventArgs args);
    
    public class CalculatedEventArgs : EventArgs
    {
        private string m_pi;
        private int m_digits;

        public CalculatedEventArgs() {}

        public CalculatedEventArgs(string result)
        {
            this.m_pi = result;
            this.m_digits = (result.Length > 1) ? result.Length - 2 : 0;
        }

        public string Pi
        {
            get { return this.m_pi; }
        }

        public int Digits
        {
            get { return this.m_digits; }
        }
    }

    #endregion

    #region CalculatingEventArgs
    
    public delegate void CalculatingEventHandler(object sender, CalculatingEventArgs args);

    public class CalculatingEventArgs : CancelEventArgs
    {
        private int m_startingAt;
        private string m_pi;

        public CalculatingEventArgs() {}

        public CalculatingEventArgs(string pi, int startAt)
            : base(false)
        {
            this.m_pi = pi;
            this.m_startingAt = startAt;
        }

        public int StartingAt
        {
            get { return this.m_startingAt; }
            set { this.m_startingAt = value; }
        }

        public string Pi
        {
            get { return this.m_pi; }
        }
    }
    
    #endregion

    #region CalculatorExceptionEventArgs

    public delegate void CalculatorExceptionEventHandler(object sender, CalculatorExceptionEventArgs args);

    public class CalculatorExceptionEventArgs : EventArgs
    {
        private Exception m_exception;

        public CalculatorExceptionEventArgs() {}

        public CalculatorExceptionEventArgs(Exception ex)
        {
            this.m_exception = ex;
        }

        public Exception Exception
        {
            get { return this.m_exception; }
        }
    }

    #endregion

}
