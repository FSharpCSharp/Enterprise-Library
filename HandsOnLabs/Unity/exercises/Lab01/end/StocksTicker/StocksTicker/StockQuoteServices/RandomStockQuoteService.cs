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
using StocksTicker.Loggers;
using Microsoft.Practices.Unity;

namespace StocksTicker.StockQuoteServices
{
    public class RandomStockQuoteService : IStockQuoteService
    {
        private IDictionary<string, StockQuote> quotes = new Dictionary<string, StockQuote>();
        private Random random = new Random();

        public RandomStockQuoteService()
        {
            this.logger = new NullLogger();
        }

        private ILogger logger;
        [Dependency]
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public IDictionary<string, StockQuote> GetQuotes(IEnumerable<string> symbols)
        {
            this.logger.Log("Generating random quotes", TraceEventType.Information);

            foreach (string symbol in symbols)
            {
                if (!quotes.ContainsKey(symbol) || random.Next(4) == 0)
                {
                    quotes[symbol] = GenerateRandomQuote(symbol);
                }
            }

            return new Dictionary<string, StockQuote>(quotes);
        }

        private StockQuote GenerateRandomQuote(string symbol)
        {
            int changeMultiplier = random.Next(2) == 0 ? 1 : -1;

            return new StockQuote(
                    symbol,
                    (double)random.Next(100000000),
                    (double)random.Next(1000) / 4d,
                    DateTime.Now,
                    (double)random.Next(200) / 10d * changeMultiplier,
                    (double)random.Next(40) / 100d * changeMultiplier);

        }
    }
}
