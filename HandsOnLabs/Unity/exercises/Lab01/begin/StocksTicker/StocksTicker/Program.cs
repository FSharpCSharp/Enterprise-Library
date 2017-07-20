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
using System.Windows.Forms;

using StocksTicker.Loggers;
using StocksTicker.StockQuoteServices;
using StocksTicker.UI;

namespace StocksTicker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO use a container to create the objects here
            StocksTickerForm view = new StocksTickerForm();
            RandomStockQuoteService service = new RandomStockQuoteService();
            service.Logger = new ConsoleLogger();
            StocksTickerPresenter presenter
                = new StocksTickerPresenter(view, service);
            presenter.Logger = new TraceSourceLogger("UI");

            Application.Run((Form)presenter.View);
        }
    }
}