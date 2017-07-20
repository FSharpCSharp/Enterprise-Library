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

namespace TransientFaultHandlingHOL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ExecuteQueryButton_Click(object sender, EventArgs e)
        {
            int productId, attempts;

            if (!int.TryParse(this.ProductId.Text, out productId))
            {
                this.Log("Invalid product id " + this.ProductId.Text);
            }

            if (!int.TryParse(this.Attempts.Text, out attempts))
            {
                this.Log("Invalid attempts " + this.Attempts.Text);
            }

            var sessionId = Guid.NewGuid().ToString();

            try
            {
                this.ExecuteQueryButton.Enabled = false;
                Application.UseWaitCursor = true;

                this.ClearLog();

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsSampleDB"].ConnectionString))
                {
                    connection.Open();

                    var command = new SqlCommand("dbo.GetProductDetails", connection) { CommandType = CommandType.StoredProcedure };

                    // Add the input parameters
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@SessionID", sessionId);
                    command.Parameters.AddWithValue("@NumberOfTriesBeforeSucceeding", attempts);

                    // Execute the command
                    using (var reader = command.ExecuteReader())
                    {
                        // For each record
                        while (reader.Read())
                        {
                            // Log the result
                            this.Log(string.Format("Product name : {0} ", reader["ProductName"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log(string.Format(CultureInfo.CurrentCulture, "Exception has occurred: {0}", ex.Message));
            }
            finally
            {
                this.ResetUi();
            }
        }

        private void ResetUi()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)this.ResetUi);
            }
            else
            {
                this.ExecuteQueryButton.Enabled = true;
                Application.UseWaitCursor = false;
            }
        }

        private void Log(string message)
        {
            if (this.LogTextBox.InvokeRequired)
            {
                this.LogTextBox.Invoke((Action<string>)this.Log, message);
            }
            else
            {
                this.LogTextBox.AppendText(message);
                this.LogTextBox.AppendText(Environment.NewLine);
            }
        }

        private void ClearLog()
        {
            if (this.LogTextBox.InvokeRequired)
            {
                this.LogTextBox.Invoke((Action)this.ClearLog);
            }
            else
            {
                this.LogTextBox.Clear();
            }
        }
    }
}
