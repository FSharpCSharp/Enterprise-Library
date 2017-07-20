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
using ValidationHOL.BusinessLogic;

namespace ValidationHOL.Service
{
    public class CustomerService : ICustomerService
    {
        public string ProcessCustomer(Customer customer, string notes)
        {
            return "Processed customer " + customer.FirstName + ". Notes: " + notes;
        }
    }
}
