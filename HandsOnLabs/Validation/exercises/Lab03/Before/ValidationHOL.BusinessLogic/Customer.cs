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
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace ValidationHOL.BusinessLogic
{
    public class Customer
    {
        [StringLengthValidator(1, 25)]
        public string FirstName { get; set; }
        [StringLengthValidator(1, 25)]
        public string LastName { get; set; }
        [RegexValidator(@"^\d\d\d-\d\d-\d\d\d\d$")]
        public string SSN { get; set; }
        public Address Address { get; set; }
    }
}
