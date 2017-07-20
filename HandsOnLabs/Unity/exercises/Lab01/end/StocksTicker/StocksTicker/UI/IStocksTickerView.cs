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

namespace StocksTicker.UI
{
    public interface IStocksTickerView
    {
        void AddSymbol(string symbol);
        void NotifyInvalidSymbol();
        void NotifyServiceStatus(string status);
        void RemoveSymbol(string symbol);
        void UpdateQuotes(IEnumerable<StockQuote> quotesToUpdate);

        bool RefreshEnabled { get; }
        IEnumerable<string> SelectedSymbols { get; }
        string Symbol { get; }

        event EventHandler<EventArgs> RefreshEnabledChanged;
        event EventHandler<EventArgs> Subscribe;
        event EventHandler<EventArgs> Unsubscribe;
    }
}
