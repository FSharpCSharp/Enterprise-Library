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
using System.Diagnostics;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionHOL
{
    class TraceBehavior : IInterceptionBehavior, IDisposable
    {
        private TraceSource source;

        public TraceBehavior(TraceSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            this.source = source;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            this.source.TraceInformation(
                "Invoking {0}",
                input.MethodBase.ToString());

            IMethodReturn methodReturn = getNext().Invoke(input, getNext);

            if (methodReturn.Exception == null)
            {
                this.source.TraceInformation(
                    "Successfully finished {0}",
                    input.MethodBase.ToString());
            }
            else
            {
                this.source.TraceInformation(
                    "Finished {0} with exception {1}: {2}",
                    input.MethodBase.ToString(),
                    methodReturn.Exception.GetType().Name,
                    methodReturn.Exception.Message);
            }

            this.source.Flush();

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        public void Dispose()
        {
            this.source.Close();
        }
    }
}
