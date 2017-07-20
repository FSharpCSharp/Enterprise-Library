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
    public class Address
    {
        [StringLengthValidator(1, 50)]
        public string StreetAddress { get; set; }
        [StringLengthValidator(1, 30)]
        public string City { get; set; }
        [StringLengthValidator(2, 2)]
        public string State { get; set; }
        [RegexValidator(@"^\d{5}$")]
        public string ZipCode { get; set; }
    }
}
