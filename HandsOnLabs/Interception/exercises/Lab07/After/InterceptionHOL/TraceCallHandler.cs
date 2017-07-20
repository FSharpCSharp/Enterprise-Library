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
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Utility;

namespace InterceptionHOL
{
    class TraceCallHandler : ICallHandler, IDisposable
    {
        private TraceSource source;

        public TraceCallHandler(TraceSource source)
        {
            Guard.ArgumentNotNull(source, "source");
            this.source = source;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
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

        private int order;
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }

        public void Dispose()
        {
            this.source.Close();
        }
    }

    class TraceCallHandlerAttribute : HandlerAttribute
    {
        private string sourceName;

        public TraceCallHandlerAttribute(string sourceName)
        {
            Guard.ArgumentNotNull(sourceName, "sourceName");
            this.sourceName = sourceName;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TraceCallHandler(new TraceSource(this.sourceName));
        }
    }
}
