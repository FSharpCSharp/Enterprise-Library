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
using System.Runtime.InteropServices;

namespace InterceptionHOL
{
    /// <summary>
    /// Contains InterOp method calls used by the application.
    /// </summary>
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern
            bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        internal static extern
            bool IsIconic(IntPtr hWnd);

        internal static int SW_RESTORE = 9;
    }
}
