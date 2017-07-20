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

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StocksTicker.StockQuoteServices;

namespace StocksTicker.Controllers
{
    public class StocksTickerController : Controller
    {
        private IStockQuoteService service;

        public StocksTickerController(IStockQuoteService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var quotes = this.service.GetQuotes(this.GetSymbols()).Values.ToList();

            return View(quotes);
        }

        public ActionResult AddStock(string symbol)
        {
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                var symbols = GetSymbols();

                symbols.Add(symbol.Trim().ToUpperInvariant());
            }

            return RedirectToAction("Index");
        }

        private IList<string> GetSymbols()
        {
            var symbols = (IList<string>)HttpContext.Session["symbols"];
            if (symbols == null)
            {
                symbols = new List<string>();
                HttpContext.Session["symbols"] = symbols;
            }
            return symbols;
        }
    }
}
