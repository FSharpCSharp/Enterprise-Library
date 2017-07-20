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
using System.Security.Principal;
using System.Threading;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Utility;

namespace InterceptionHOL
{
    public class AccessCheckCallHandler : ICallHandler
    {
        private string[] allowedRoles;

        public AccessCheckCallHandler(params string[] allowedRoles)
        {
            Guard.ArgumentNotNull(allowedRoles, "allowedRoles");
            this.allowedRoles = allowedRoles;
        }

        public IMethodReturn Invoke(
            IMethodInvocation input, 
            GetNextHandlerDelegate getNext)
        {
            if (this.allowedRoles.Length > 0)
            {
                IPrincipal currentPrincipal = Thread.CurrentPrincipal;

                if (currentPrincipal != null)
                {
                    bool allowed = false;
                    foreach (string role in this.allowedRoles)
                    {
                        if (allowed = currentPrincipal.IsInRole(role))
                        {
                            break;
                        }
                    }

                    if (!allowed)
                    {
                        // short circuit the call
                        return input.CreateExceptionMethodReturn(
                            new UnauthorizedAccessException(
                                "User not allowed to invoke the method"));
                    }
                }
            }

            return getNext()(input, getNext);
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
                this.order = value;
            }
        }
    }
}
