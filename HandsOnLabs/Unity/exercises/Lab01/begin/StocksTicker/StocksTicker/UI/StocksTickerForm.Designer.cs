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
namespace StocksTicker.UI
{
    partial class StocksTickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stocksView = new System.Windows.Forms.ListView();
            this.SymbolColumn = new System.Windows.Forms.ColumnHeader();
            this.Volume = new System.Windows.Forms.ColumnHeader();
            this.Last = new System.Windows.Forms.ColumnHeader();
            this.Change = new System.Windows.Forms.ColumnHeader();
            this.PercentChange = new System.Windows.Forms.ColumnHeader();
            this.LastUpdate = new System.Windows.Forms.ColumnHeader();
            this.stockNameTextBox = new System.Windows.Forms.TextBox();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.unsubscribeButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.flashTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stocksView
            // 
            this.stocksView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stocksView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SymbolColumn,
            this.Volume,
            this.Last,
            this.Change,
            this.PercentChange,
            this.LastUpdate});
            this.stocksView.FullRowSelect = true;
            this.stocksView.Location = new System.Drawing.Point(13, 13);
            this.stocksView.Name = "stocksView";
            this.stocksView.ShowGroups = false;
            this.stocksView.Size = new System.Drawing.Size(529, 232);
            this.stocksView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.stocksView.TabIndex = 3;
            this.stocksView.UseCompatibleStateImageBehavior = false;
            this.stocksView.View = System.Windows.Forms.View.Details;
            this.stocksView.SelectedIndexChanged += new System.EventHandler(this.stocksView_SelectedIndexChanged);
            // 
            // SymbolColumn
            // 
            this.SymbolColumn.Text = "Symbol";
            // 
            // Volume
            // 
            this.Volume.Text = "Volume";
            this.Volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Volume.Width = 80;
            // 
            // Last
            // 
            this.Last.Text = "Last";
            this.Last.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Last.Width = 80;
            // 
            // Change
            // 
            this.Change.Text = "Change";
            this.Change.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Change.Width = 80;
            // 
            // PercentChange
            // 
            this.PercentChange.Text = "Change %";
            this.PercentChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PercentChange.Width = 80;
            // 
            // LastUpdate
            // 
            this.LastUpdate.Text = "Update";
            this.LastUpdate.Width = 100;
            // 
            // stockNameTextBox
            // 
            this.stockNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockNameTextBox.Location = new System.Drawing.Point(13, 253);
            this.stockNameTextBox.Name = "stockNameTextBox";
            this.stockNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.stockNameTextBox.TabIndex = 0;
            this.stockNameTextBox.TextChanged += new System.EventHandler(this.stockNameTextBox_TextChanged);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subscribeButton.Enabled = false;
            this.subscribeButton.Location = new System.Drawing.Point(268, 251);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(91, 23);
            this.subscribeButton.TabIndex = 1;
            this.subscribeButton.Text = "&Subscribe";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // unsubscribeButton
            // 
            this.unsubscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unsubscribeButton.Enabled = false;
            this.unsubscribeButton.Location = new System.Drawing.Point(365, 251);
            this.unsubscribeButton.Name = "unsubscribeButton";
            this.unsubscribeButton.Size = new System.Drawing.Size(91, 23);
            this.unsubscribeButton.TabIndex = 2;
            this.unsubscribeButton.Text = "&Unsubscribe";
            this.unsubscribeButton.UseVisualStyleBackColor = true;
            this.unsubscribeButton.Click += new System.EventHandler(this.unsubscribeButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // flashTimer
            // 
            this.flashTimer.Tick += new System.EventHandler(this.flashTimer_Tick);
            // 
            // refreshCheckBox
            // 
            this.refreshCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshCheckBox.AutoSize = true;
            this.refreshCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshCheckBox.Location = new System.Drawing.Point(479, 255);
            this.refreshCheckBox.Name = "refreshCheckBox";
            this.refreshCheckBox.Size = new System.Drawing.Size(63, 17);
            this.refreshCheckBox.TabIndex = 4;
            this.refreshCheckBox.Text = "&Refresh";
            this.refreshCheckBox.UseVisualStyleBackColor = true;
            this.refreshCheckBox.CheckedChanged += new System.EventHandler(this.refreshCheckBox_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 285);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(554, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // StocksTickerForm
            // 
            this.AcceptButton = this.subscribeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 307);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.refreshCheckBox);
            this.Controls.Add(this.stockNameTextBox);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.unsubscribeButton);
            this.Controls.Add(this.stocksView);
            this.Name = "StocksTickerForm";
            this.Text = "Stocks ticker";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView stocksView;
        private System.Windows.Forms.TextBox stockNameTextBox;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.Button unsubscribeButton;
        private System.Windows.Forms.ColumnHeader SymbolColumn;
        private System.Windows.Forms.ColumnHeader Last;
        private System.Windows.Forms.ColumnHeader Change;
        private System.Windows.Forms.ColumnHeader LastUpdate;
        private System.Windows.Forms.ColumnHeader PercentChange;
        private System.Windows.Forms.ColumnHeader Volume;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer flashTimer;
        private System.Windows.Forms.CheckBox refreshCheckBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

