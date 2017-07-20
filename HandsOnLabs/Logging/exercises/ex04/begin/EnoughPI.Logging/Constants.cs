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

namespace EnoughPI.Logging
{
    public static class Priority
    {
        public const int Lowest  = 0;
        public const int Low     = 1;
        public const int Normal  = 2;
        public const int High    = 3;
        public const int Highest = 4;
    }

    public static class Category
    {
        public const string General = "General";
        public const string Trace   = "Trace";
    }
}
