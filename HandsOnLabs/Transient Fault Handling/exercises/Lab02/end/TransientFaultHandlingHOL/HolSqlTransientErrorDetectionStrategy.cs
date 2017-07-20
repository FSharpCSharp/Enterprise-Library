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

namespace TransientFaultHandlingHOL
{
    using System;
    using System.Data.SqlClient;
    using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

    public class HolSqlTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            var sqlException = ex as SqlException;
            if (sqlException != null)
            {
                foreach (SqlError error in sqlException.Errors)
                {
                    if (error.Number == 50000)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
