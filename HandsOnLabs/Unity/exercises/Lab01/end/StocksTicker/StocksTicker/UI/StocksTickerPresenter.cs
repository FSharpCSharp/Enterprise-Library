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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Timers;
using Microsoft.Practices.Unity;
using StocksTicker.Loggers;
using StocksTicker.StockQuoteServices;

namespace StocksTicker.UI
{
    public class StocksTickerPresenter
    {
        public StocksTickerPresenter(
            IStocksTickerView view,
            IStockQuoteService stockQuoteService)
        {
            this.view = view;
            this.stockQuoteService = stockQuoteService;

            this.view.Subscribe += this.OnSubscribe;
            this.view.Unsubscribe += this.OnUnsubscribe;
            this.view.RefreshEnabledChanged += this.OnRefreshEnabledChanged;

            this.refreshTimer = new System.Timers.Timer();
            this.refreshTimer.AutoReset = false;
            this.refreshTimer.Elapsed += this.OnRefreshTimerElapsed;

            this.RefreshInterval = 5;   // default refresh interval

            this.logger = new NullLogger();
        }

        private ILogger logger;
        [Dependency("UI")]
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        private int refreshInterval;
        public int RefreshInterval
        {
            get { return refreshInterval; }
            set
            {
                refreshInterval = value;
                // workaround from doc to avoid firing the event
                this.refreshTimer.AutoReset = true;
                this.refreshTimer.Interval = 1000d * value;
                this.refreshTimer.AutoReset = false;
            }
        }

        public IStocksTickerView View
        {
            get { return view; }
        }

        private void OnSubscribe(object source, EventArgs args)
        {
            string symbol = this.view.Symbol.ToUpper(CultureInfo.CurrentCulture);

            if (!symbolValidationRegex.IsMatch(symbol))
            {
                this.view.NotifyInvalidSymbol();
                return;
            }

            lock (quotesLock)
            {
                if (!this.quotes.ContainsKey(symbol))
                {
                    this.view.AddSymbol(symbol);
                    this.quotes.Add(symbol, null);
                }
            }
        }

        private void OnUnsubscribe(object source, EventArgs args)
        {
            IEnumerable<string> symbolsToRemove = this.view.SelectedSymbols;

            lock (quotesLock)
            {
                foreach (string symbolToRemove in symbolsToRemove)
                {
                    if (this.quotes.ContainsKey(symbolToRemove))
                    {
                        this.quotes.Remove(symbolToRemove);
                        this.view.RemoveSymbol(symbolToRemove);
                    }
                }
            }
        }

        private void OnRefreshEnabledChanged(object source, EventArgs args)
        {
            this.refreshTimer.Enabled = this.view.RefreshEnabled;
        }

        private void OnRefreshTimerElapsed(object source, ElapsedEventArgs args)
        {
            logger.Log("Refresh timer elapsed", TraceEventType.Information);

            if (this.quotes.Count > 0)
            {
                this.RefreshQuotes(GetSymbols());
            }

            this.refreshTimer.Enabled = this.view.RefreshEnabled;
        }

        private void RefreshQuotes(List<string> symbols)
        {
            IDictionary<string, StockQuote> refreshedQuotes = null;

            try
            {
                refreshedQuotes = this.stockQuoteService.GetQuotes(symbols);
            }
            catch (StockQuoteServiceException)
            {
                logger.Log("Error invoking service", TraceEventType.Error);
                this.view.NotifyServiceStatus("Error invoking service");
                return;
            }
            catch (Exception)
            {
                logger.Log("Unknown error invoking service", TraceEventType.Error);
                this.view.NotifyServiceStatus("Unknown error invoking service");
                return;
            }

            List<StockQuote> updatedQuotes = new List<StockQuote>();
            lock (quotesLock)
            {
                foreach (KeyValuePair<string, StockQuote> kvp in refreshedQuotes)
                {
                    StockQuote currentQuote;
                    StockQuote updatedQuote = kvp.Value;

                    if (this.quotes.TryGetValue(kvp.Key, out currentQuote))
                    {
                        if ((currentQuote == null && updatedQuote != null)
                            || (currentQuote != null
                                    && updatedQuote != null
                                    && currentQuote.LastUpdate < updatedQuote.LastUpdate))
                        {
                            this.quotes[kvp.Key] = updatedQuote;
                            updatedQuotes.Add(updatedQuote);
                            logger.Log("StockQuote for " + kvp.Key + " was updated", TraceEventType.Information);
                        }
                        else
                        {
                            logger.Log("StockQuote for " + kvp.Key + " was not updated", TraceEventType.Information);
                        }
                    }
                    else
                    {
                        logger.Log("Received quote for unknown symbol " + kvp.Key, TraceEventType.Warning);
                    }
                }
            }

            if (updatedQuotes.Count > 0)
            {
                logger.Log("Updates received, updating view", TraceEventType.Information);
                this.view.UpdateQuotes(updatedQuotes);
            }
        }

        private List<string> GetSymbols()
        {
            List<string> symbols;

            lock (quotesLock)
            {
                symbols = new List<string>(this.quotes.Keys.Count);
                foreach (string symbol in this.quotes.Keys)
                {
                    symbols.Add(symbol);
                }
            }

            return symbols;
        }

        private static readonly Regex symbolValidationRegex = new Regex("^[a-zA-Z]+$");

        private readonly IStocksTickerView view;
        private readonly IStockQuoteService stockQuoteService;
        private readonly Dictionary<string, StockQuote> quotes = new Dictionary<string, StockQuote>();
        private readonly object quotesLock = new object();
        private readonly Timer refreshTimer;
    }
}
