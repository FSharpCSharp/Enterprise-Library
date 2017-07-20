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

namespace StocksTicker.StockQuoteServices
{
    public class StockQuote
    {
        public StockQuote(
            string symbol,
            double volume,
            double last,
            DateTime lastUpdate,
            double change,
            double percentChange)
        {
            this.symbol = symbol;
            this.volume = volume;
            this.last = last;
            this.lastUpdate = lastUpdate;
            this.change = change;
            this.percentChange = percentChange;
        }

        public override string ToString()
        {
            return string.Format("Quote for '{0}' for {1} in {2}", this.symbol, this.last, this.lastUpdate);
        }

        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        private double volume;
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        private double last;
        public double Last
        {
            get { return last; }
            set { last = value; }
        }

        private DateTime lastUpdate;
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        private double change;
        public double Change
        {
            get { return change; }
            set { change = value; }
        }

        private double percentChange;
        public double PercentChange
        {
            get { return percentChange; }
            set { percentChange = value; }
        }
    }
}