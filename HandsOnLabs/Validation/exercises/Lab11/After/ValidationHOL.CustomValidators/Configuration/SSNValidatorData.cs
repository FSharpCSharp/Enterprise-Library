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
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using ValidationHOL.CustomValidators.Properties;

namespace ValidationHOL.CustomValidators.Configuration
{
    [ResourceDescription(typeof(Resources), "SSNValidatorDescription")]
    [ResourceDisplayName(typeof(Resources), "SSNValidatorName")]
    public class SSNValidatorData : ValueValidatorData
    {
        public SSNValidatorData()
        {
        }

        public SSNValidatorData(string name)
            : base(name, typeof(SSNValidator))
        {
        }

        [ConfigurationProperty("ignoreHyphens")]
        [ResourceDescription(typeof(Resources), "IgnoreHyphensDescription")]
        [ResourceDisplayName(typeof(Resources), "IgnoreHyphensName")]
        public bool IgnoreHyphens
        {
            get
            {
                return (bool)this["ignoreHyphens"];
            }
            set
            {
                this["ignoreHyphens"] = value;
            }
        }

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new SSNValidator(this.Tag, this.IgnoreHyphens);
        }
    }
}
