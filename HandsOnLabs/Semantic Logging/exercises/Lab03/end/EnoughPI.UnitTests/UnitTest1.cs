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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnoughPI;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;

namespace EnoughPI.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyCalculatorEventSourceIsCorrect()
        {
            EventSourceAnalyzer.InspectAll(CalculatorEventSource.Log);
        }
    }
}
