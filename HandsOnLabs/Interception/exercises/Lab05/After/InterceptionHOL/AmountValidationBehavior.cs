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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionHOL
{
    public class AmountValidationBehavior : IInterceptionBehavior
    {
        private decimal maxAmount;

        public AmountValidationBehavior(decimal maxAmount)
        {
            this.maxAmount = maxAmount;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if(input.Inputs.Count > 0)
            {
                foreach(var inputValue in input.Inputs)
                {
                    if(inputValue is Decimal)
                    {
                        if((Decimal)inputValue > maxAmount)
                        {
                            MessageBox.Show(
                                string.Format("Amount of {0} is beyond max limit of {1}",
                                    inputValue, maxAmount),
                                "Limit Exceeded");
                            return input.CreateExceptionMethodReturn(
                                new InvalidOperationException("Limit Exceeded"));
                        }
                    }
                }
            }
            return getNext()(input, getNext);
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Enumerable.Empty<Type>();
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
