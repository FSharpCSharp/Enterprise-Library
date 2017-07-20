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
using System.ServiceModel;
using System.Text;
//using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using ValidationHOL.BusinessLogic;
using www.microsoft.com.practices.EnterpriseLibrary._2007._01.wcf.validation;

namespace ValidationHOL.Web
{
    public partial class FollowUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (CustomerServiceClient client = new CustomerServiceClient())
            {
                try
                {
                    this.StatusLabel.Text =
                        client.ProcessCustomer(
                            (Customer)Context.Items["customer"],
                            (string)Context.Items["notes"]);
                }
                catch (FaultException<ValidationFault> fex)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("Validation error invoking service:<br/>");
                    foreach (var result in fex.Detail.Details)
                    {
                        builder.AppendLine(
                            string.Format("{0}: {1}<br/>", result.Key, result.Message));
                    }
                    this.StatusLabel.Text = builder.ToString();

                }
                catch (Exception ex)
                {
                    this.StatusLabel.Text = "Unknown error invoking service: " + ex.ToString() + "<br/>";
                }
            }
        }
    }
}
