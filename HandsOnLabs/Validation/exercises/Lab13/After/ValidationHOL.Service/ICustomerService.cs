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
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using ValidationHOL.BusinessLogic;

namespace ValidationHOL.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        string ProcessCustomer(
            Customer customer,
            [StringLengthValidator(1, 100,
                MessageTemplate = "The notes must be 1 to 100 characters long.")]
            string notes);
    }
}
