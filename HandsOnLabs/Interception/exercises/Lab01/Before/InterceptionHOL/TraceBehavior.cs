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
