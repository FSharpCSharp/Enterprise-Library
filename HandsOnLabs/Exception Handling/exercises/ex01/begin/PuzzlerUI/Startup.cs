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
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

// TODO: Use Enterpise Library Exception Handling

namespace PuzzlerUI
{
    class Startup
    {
        [STAThread]
        static void Main()
        {
            // TODO: Handle unhandled exceptions

            Puzzler f = new Puzzler();
            Application.Run(f);
        }
    }
}
