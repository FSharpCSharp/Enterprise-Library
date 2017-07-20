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
using System.Windows.Forms;
using ValidationHOL.BusinessLogic;

namespace ValidationHOL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private void acceptButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                SSN = ssnTextBox.Text,
                Address = new Address
                {
                    StreetAddress = streetAddressTextBox.Text,
                    City = cityTextBox.Text,
                    State = stateComboBox.Text,
                    ZipCode = zipCodeTextBox.Text
                }
            };

            MessageBox.Show(
                this,
                "Processing customer '" + customer.FirstName + "'",
                "Working",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
