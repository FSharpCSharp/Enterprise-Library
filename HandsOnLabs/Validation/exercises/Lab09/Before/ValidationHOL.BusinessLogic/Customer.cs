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
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ValidationHOL.BusinessLogic
{
    [HasSelfValidation]
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public Address Address { get; set; }

        static Regex ssnCaptureRegex =
            new Regex(@"^(?<area>\d{3})-(?<group>\d{2})-(?<serial>\d{4})$");

        [SelfValidation]
        public void ValidateSSN(ValidationResults validationResults)
        {
            // validation logic according to 
            // http://ssa-custhelp.ssa.gov/cgi-bin/ssa.cfg/php/enduser/std_adp.php?p_faqid=425

            Match match = ssnCaptureRegex.Match(this.SSN);
            if (match.Success)
            {
                string area = match.Groups["area"].Value;
                string group = match.Groups["group"].Value;
                string serial = match.Groups["serial"].Value;

                if (area == "666"
                    || string.Compare(area, "772", StringComparison.Ordinal) > 0)
                {
                    validationResults.AddResult(
                        new ValidationResult(
                            "Invalid area",
                            this,
                            "SSN",
                            null,
                            null));
                }
                else if (area == "000" || group == "00" || serial == "0000")
                {
                    validationResults.AddResult(
                        new ValidationResult(
                            "SSN elements cannot be all '0'",
                            this,
                            "SSN",
                            null,
                            null));
                }
            }
            else
            {
                validationResults.AddResult(
                    new ValidationResult(
                        "Must match the pattern '###-##-####'",
                        this,
                        "SSN",
                        null,
                        null));
            }
        }
    }
}
