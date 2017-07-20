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
using System.Text;

namespace EnoughPI.Calc
{
    public class Calculator
    {
        public event CalculatedEventHandler Calculated;
        public event CalculatingEventHandler Calculating;
        public event CalculatorExceptionEventHandler CalculatorException;
        
        private delegate string CalculateDelegate(int digits);
        private CalculateDelegate dlg;

        public Calculator()
        {

        }

        public IAsyncResult BeginCalculate(int digits, AsyncCallback callback) 
        {
            dlg = new CalculateDelegate(this.Calculate);
            return dlg.BeginInvoke(digits, callback, this);
        }
        
        public IAsyncResult BeginCalculate(int digits) 
        {
            dlg = new CalculateDelegate(this.Calculate);
            AsyncCallback callback = new AsyncCallback(this.CalculateCallback);
            return dlg.BeginInvoke(digits, callback, dlg);
        }

        private void CalculateCallback(IAsyncResult ar)
        {
            CalculateDelegate dlg = (CalculateDelegate) ar.AsyncState;
            dlg.EndInvoke(ar);
        }

        public string EndCalculate(IAsyncResult ar)
        {
            return dlg.EndInvoke(ar);
        }

        public string Calculate(int digits)
        {
            StringBuilder pi = new StringBuilder("3", digits + 2);
            string result = null;
 
            try
            {
                if (digits > 0)
                {
                    pi.Append(".");
                    for (int i = 0; i < digits; i += 9)
                    {
                        CalculatingEventArgs args;
                        args = new CalculatingEventArgs(pi.ToString(), i + 1);
                        OnCalculating(args);

                        // Break out if cancelled
                        if (args.Cancel == true) break;

                        // Calculate next 9 digits
                        int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                        int digitCount = Math.Min(digits - i, 9);
                        string ds = string.Format("{0:D9}", nineDigits);
                        pi.Append(ds.Substring(0, digitCount));
                    }
                }
                result = pi.ToString();
 
                // Tell the world I've finished!
                OnCalculated(new CalculatedEventArgs(result));
            }
            catch (Exception ex)
            {
                // Tell the world I've crashed!
                OnCalculatorException(new CalculatorExceptionEventArgs(ex));
            }
 
            return result;
        }

        protected void OnCalculated(CalculatedEventArgs args)
        {
            // TODO: Log final result
            CalculatorEventSource.Log.Calculated(args.Digits);

            if (Calculated != null)
                Calculated(this, args);
        }

        protected void OnCalculating(CalculatingEventArgs args)
        {
            // TODO: Log progress 
            CalculatorEventSource.Log.Calculating(args.StartingAt, args.Pi, args.Cancel);

            if (Calculating != null)
                Calculating(this, args);
 
            if (args.Cancel == true)
            {
              // TODO: Log cancellation
               CalculatorEventSource.Log.CalculationCanceled();
            }
        }

        protected void OnCalculatorException(CalculatorExceptionEventArgs args)
        {
            // TODO: Log exception
            CalculatorEventSource.Log.CalculatorException(CalculatorEventSource.FormatException(args.Exception));

            if (CalculatorException != null)
                CalculatorException(this, args);
        }


    }
}
