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
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using ValidationHOL.BusinessLogic.Properties;
using ValidationHOL.CustomValidators;

namespace ValidationHOL.BusinessLogic
{
    [DataContract]
    public class Customer
    {
        [StringLengthValidator(1, 25,
            MessageTemplateResourceType = typeof(Resources),
            MessageTemplateResourceName = "FirstNameMessage")]
        [DataMember]
        public string FirstName { get; set; }
        [StringLengthValidator(1, 25,
            MessageTemplateResourceType = typeof(Resources),
            MessageTemplateResourceName = "LastNameMessage")]
        [DataMember]
        public string LastName { get; set; }
        [SSNValidator]
        [DataMember]
        public string SSN { get; set; }
        [ObjectValidator]
        [DataMember]
        public Address Address { get; set; }
    }
}
