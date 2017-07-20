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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using StocksTicker.StockQuoteServices;

namespace StocksTicker
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UpdateQuotes();
            }
        }

        private void UpdateQuotes()
        {
            string[] symbols = GetSymbols();

            if (symbols.Length > 0)
            {
                try
                {
                    ICollection<StockQuote> quotes = GetQuotes(symbols);
                    StockQuotesGridView.DataSource = quotes;
                    this.StatusLabel.Text = null;
                }
                catch (Exception)
                {
                    this.StatusLabel.Text = "Error retrieving quotes";
                }
            }

            StockQuotesGridView.DataBind();
        }

        private ICollection<StockQuote> GetQuotes(string[] symbols)
        {
            List<StockQuote> result = new List<StockQuote>();

            if (this.StockQuoteService != null)
            {
                IDictionary<string, StockQuote> quotes = this.StockQuoteService.GetQuotes(symbols);

                foreach (KeyValuePair<string, StockQuote> kvp in quotes)
                {
                    if (kvp.Value != null)
                    {
                        result.Add(kvp.Value);
                    }
                    else
                    {
                        result.Add(new StockQuote(kvp.Key, 0d, 0d, DateTime.MinValue, 0d, 0d));
                    }
                }

                result.Sort(
                    delegate(StockQuote x, StockQuote y)
                    {
                        return string.Compare(x.Symbol, y.Symbol, StringComparison.CurrentCulture);
                    });
            }

            return result;
        }

        private string[] GetSymbols()
        {
            string[] symbols = (Session["symbols"] as string[]) ?? new string[0];
            return symbols;
        }

        private void SetSymbols(string[] symbols)
        {
            Session["symbols"] = symbols;
        }

        protected void SubscribeSymbolButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<string> symbols = new List<string>(GetSymbols());
                symbols.Add(this.StockSymbolText.Text.ToUpper());
                this.SetSymbols(symbols.ToArray());
                this.UpdateQuotes();

                this.StockSymbolText.Text = null;
            }
        }

        protected void QuoteUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.UpdateQuotes();
        }

        #region dynamic row coloring support

        protected void StockQuotesGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                StockQuote quote = (StockQuote)e.Row.DataItem;

                ((Label)e.Row.FindControl("ChangeLabel")).ForeColor = ColorForValue(quote.Change);
                ((Label)e.Row.FindControl("PercentChangeLabel")).ForeColor = ColorForValue(quote.Change);
            }
        }

        private Color ColorForValue(double p)
        {
            if (p >= 0d)
            {
                return Color.Green;
            }
            else
            {
                return Color.Red;
            }
        }

        #endregion

        private IStockQuoteService stockQuoteService;
        [Dependency]
        public IStockQuoteService StockQuoteService
        {
            get { return stockQuoteService; }
            set { stockQuoteService = value; }
        }
    }
}
