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
using System.Runtime.Serialization;

namespace PersistenceFramework
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
            : base("Stock quote service error")
        {
        }

        public RepositoryException(string message)
            : base(message)
        {
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}