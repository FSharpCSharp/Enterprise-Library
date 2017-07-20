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


namespace ValidationHOL.CustomValidators
{
    public class SSNValidator : Validator<string>
    {
        public SSNValidator(string tag)
            : this(tag, false)
        {
        }

        public SSNValidator(string tag, bool ignoreHypens)
            : base(string.Empty, tag)
        {
            this.ignoreHypens = ignoreHypens;
        }

        static Regex ssnCaptureRegex =
            new Regex(@"^(?<area>\d{3})-(?<group>\d{2})-(?<serial>\d{4})$");
        static Regex ssnCaptureNoHypensRegex =
            new Regex(@"^(?<area>\d{3})(?<group>\d{2})(?<serial>\d{4})$");
        private bool ignoreHypens;

        protected override string DefaultMessageTemplate
        {
            get { throw new NotImplementedException(); }
        }

        protected override void DoValidate(
            string objectToValidate,
            object currentTarget,
            string key,
            ValidationResults validationResults)
        {
            // validation logic according to 
            // http://ssa-custhelp.ssa.gov/cgi-bin/ssa.cfg/php/enduser/std_adp.php?p_faqid=425

            Match match =
                (ignoreHypens ? ssnCaptureNoHypensRegex : ssnCaptureRegex)
                    .Match(objectToValidate);
            if (match.Success)
            {
                string area = match.Groups["area"].Value;
                string group = match.Groups["group"].Value;
                string serial = match.Groups["serial"].Value;

                if (area == "666"
                    || string.Compare(area, "772", StringComparison.Ordinal) > 0)
                {
                    LogValidationResult(
                        validationResults,
                        "Invalid area",
                        currentTarget,
                        key);
                }
                else if (area == "000" || group == "00" || serial == "0000")
                {
                    LogValidationResult(
                        validationResults,
                        "SSN elements cannot be all '0'",
                        currentTarget,
                        key);
                }
            }
            else
            {
                LogValidationResult(
                    validationResults,
                    this.ignoreHypens
                        ? "Must be 9 digits"
                        : "Must match the pattern '###-##-####'",
                    currentTarget,
                    key);
            }
        }
    }
}
