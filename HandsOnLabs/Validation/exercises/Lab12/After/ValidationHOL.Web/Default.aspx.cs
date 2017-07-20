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
using ValidationHOL.BusinessLogic;

namespace ValidationHOL.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
                return;

            Customer customer = new Customer
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                SSN = SSNTextBox.Text,
                Address = new Address
                {
                    StreetAddress = StreetAddressTextBox.Text,
                    City = CityTextBox.Text,
                    State = StateDropDownList.Text,
                    ZipCode = ZipCodeTextBox.Text
                }
            };

            Context.Items.Add("customer", customer);

            Server.Transfer(@"~/FollowUp.aspx", true);
        }
    }
}
