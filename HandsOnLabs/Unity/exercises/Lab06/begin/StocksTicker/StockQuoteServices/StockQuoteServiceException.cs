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

namespace StocksTicker.StockQuoteServices
{
    public class StockQuoteServiceException : Exception
    {
        public StockQuoteServiceException()
            : base("Stock quote service error")
        {
        }

        public StockQuoteServiceException(string message)
            : base(message)
        {
        }

        protected StockQuoteServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public StockQuoteServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}