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
using Microsoft.Practices.Unity;
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

            using (IUnityContainer container = new UnityContainer())
            {
                container
                    .RegisterType<IStocksTickerView, StocksTickerForm>()
                    .RegisterType<IStockQuoteService, RandomStockQuoteService>(
                        new InjectionProperty("Logger"))
                    .RegisterType<ILogger, ConsoleLogger>()
                    .RegisterType<ILogger, TraceSourceLogger>(
                        "UI",
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor("UI"))
                    .RegisterType<StocksTickerPresenter>(
                        new InjectionProperty(
                            "Logger",
                            new ResolvedParameter<ILogger>("UI")));

                StocksTickerPresenter presenter
                    = container.Resolve<StocksTickerPresenter>();

                Application.Run((Form)presenter.View);
            }
        }
    }
}