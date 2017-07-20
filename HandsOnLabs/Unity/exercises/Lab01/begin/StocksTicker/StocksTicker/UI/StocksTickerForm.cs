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
using System.Globalization;
using System.Windows.Forms;

namespace StocksTicker.UI
{
    public partial class StocksTickerForm : Form, IStocksTickerView
    {
        public StocksTickerForm()
        {
            InitializeComponent();

            // set defaults
            this.flashColor = Color.Crimson;
            this.flashInterval = 150;
        }

        public event EventHandler<EventArgs> Subscribe;
        public event EventHandler<EventArgs> Unsubscribe;
        public event EventHandler<EventArgs> RefreshEnabledChanged;

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = this.Subscribe;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = this.Unsubscribe;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void refreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = this.RefreshEnabledChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void stockNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.subscribeButton.Enabled = this.stockNameTextBox.Text.Length > 0;
            this.errorProvider.SetError(this.stockNameTextBox, null);
        }

        private void stocksView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.unsubscribeButton.Enabled = this.stocksView.SelectedIndices.Count > 0;
        }

        private ListViewItem CreateQuoteListViewItem(string symbol)
        {
            ListViewItem item = this.stocksView.Items.Add(symbol);
            item.Name = symbol;
            item.ForeColor = Color.Gray;

            item.SubItems.Add("--").Name = "Volume";
            item.SubItems.Add("--").Name = "Last";
            item.SubItems.Add("--").Name = "Change";
            item.SubItems.Add("--").Name = "PercentChange";
            item.SubItems.Add("--").Name = "LastUpdate";

            return item;
        }

        private void UpdateQuoteListViewItem(ListViewItem item, StockQuote quote)
        {
            item.Tag = quote;

            if (quote != null)
            {
                item.ForeColor = this.stocksView.ForeColor;

                item.SubItems["Volume"].Text = quote.Volume.ToString("N0", CultureInfo.CurrentCulture);
                item.SubItems["Last"].Text = quote.Last.ToString("N4", CultureInfo.CurrentCulture);
                item.SubItems["Change"].Text
                    = quote.Change.ToString("N2", CultureInfo.CurrentCulture);
                item.SubItems["Change"].ForeColor = quote.Change < 0d ? Color.Red : Color.Green;
                item.SubItems["PercentChange"].Text
                    = quote.PercentChange.ToString("P", CultureInfo.CurrentCulture);
                item.SubItems["PercentChange"].ForeColor = quote.PercentChange < 0d ? Color.Red : Color.Green;
                item.SubItems["LastUpdate"].Text = quote.LastUpdate.ToLongTimeString();
            }
            else
            {
                item.ForeColor = Color.Gray;
                item.SubItems["Volume"].Text = "--";
                item.SubItems["Last"].Text = "--";
                item.SubItems["Change"].Text = "--";
                item.SubItems["PercentChange"].Text = "--";
                item.SubItems["LastUpdate"].Text = "--";
            }

            StartFlash(item);
        }

        #region flash support

        private Color flashColor;
        public Color FlashColor
        {
            get { return flashColor; }
            set { flashColor = value; }
        }

        private int flashInterval;
        public int FlashInterval
        {
            get { return flashInterval; }
            set { flashInterval = value; }
        }

        private void StartFlash(ListViewItem item)
        {
            item.BackColor = flashColor;
            item.UseItemStyleForSubItems = true;
        }

        private void EndFlash(ListViewItem item)
        {
            Color backColor = this.stocksView.BackColor;

            if (item.BackColor != backColor)
            {
                item.BackColor = backColor;
                item.UseItemStyleForSubItems = item.Tag == null;
            }
        }

        private void flashTimer_Tick(object sender, EventArgs e)
        {
            this.flashTimer.Stop();

            this.stocksView.BeginUpdate();
            try
            {
                foreach (ListViewItem item in this.stocksView.Items)
                {
                    EndFlash(item);
                }
            }
            finally
            {
                this.stocksView.EndUpdate();
            }
        }

        #endregion flash support

        #region IStocksTickerView implementation

        public void NotifyInvalidSymbol()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { this.NotifyInvalidSymbol(); });
            }
            else
            {
                this.errorProvider.SetError(this.stockNameTextBox, "Invalid stock symbol");
            }
        }

        public void NotifyServiceStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { this.NotifyServiceStatus(status); });
            }
            else
            {
                this.statusLabel.Text = status;
            }
        }

        public void AddSymbol(string symbol)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { this.AddSymbol(symbol); });
            }
            else
            {
                CreateQuoteListViewItem(symbol);
                this.stockNameTextBox.Text = string.Empty;
            }
        }

        public void RemoveSymbol(string symbolToRemove)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { this.RemoveSymbol(symbolToRemove); });
            }
            else
            {
                this.stocksView.Items.RemoveByKey(symbolToRemove);
            }
        }

        public void UpdateQuotes(IEnumerable<StockQuote> quotesToUpdate)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { this.UpdateQuotes(quotesToUpdate); });
            }
            else
            {
                this.stocksView.BeginUpdate();

                try
                {
                    foreach (StockQuote quoteToUpdate in quotesToUpdate)
                    {
                        ListViewItem itemForQuote = this.stocksView.Items[quoteToUpdate.Symbol];
                        UpdateQuoteListViewItem(itemForQuote, quoteToUpdate);
                    }

                    // set up the timer to undo the flash initiated for updated items
                    this.flashTimer.Interval = flashInterval;
                    this.flashTimer.Start();
                }
                finally
                {
                    this.stocksView.EndUpdate();
                }
            }
        }

        public string Symbol
        {
            get
            {
                if (this.InvokeRequired)
                {
                    return (string)this.Invoke((Func<string>)delegate() { return this.Symbol; });
                }
                return stockNameTextBox.Text;
            }
        }

        public IEnumerable<string> SelectedSymbols
        {
            get
            {
                if (this.InvokeRequired)
                {
                    return (IEnumerable<string>)this.Invoke((Func<IEnumerable<string>>)
                        delegate() { return this.SelectedSymbols; });
                }

                ICollection selectedItems = this.stocksView.SelectedItems;
                List<string> symbols = new List<string>(selectedItems.Count);
                foreach (ListViewItem selectedItem in selectedItems)
                {
                    symbols.Add(selectedItem.Name);
                }

                return symbols;
            }
        }

        public bool RefreshEnabled
        {
            get
            {
                if (this.InvokeRequired)
                {
                    return (bool)this.Invoke((Func<bool>)delegate() { return this.RefreshEnabled; });
                }
                return this.refreshCheckBox.Checked;
            }
        }

        #endregion
    }

    public delegate TResult Func<TResult>();
    public delegate TResult Func<TResult, T1>(T1 arg1);
}