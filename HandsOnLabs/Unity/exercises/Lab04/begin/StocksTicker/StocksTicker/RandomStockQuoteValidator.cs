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
using System.Text;
using PersistenceFramework;

namespace StocksTicker
{
    public class RandomStockQuoteValidator : IValidator<StockQuote>
    {
        private readonly Random random = new Random();

        public bool IsValid(StockQuote instance)
        {
            return random.Next(3) == 0; // one out of three will fail randomly
        }
    }
}