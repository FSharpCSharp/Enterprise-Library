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
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ProductMaintenance
{
    class GetProductsByIdParameterMapper : IParameterMapper
    {
        private readonly Database db;

        public GetProductsByIdParameterMapper(Database db)
        {
            this.db = db;
        }

        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            InitializeParameters(command);
            db.SetParameterValue(command, "@CategoryID", parameterValues[0]);
        }

        private void InitializeParameters(DbCommand command)
        {
            if(!command.Parameters.Contains("@CategoryID"))
            {
                db.AddInParameter(command, "@CategoryID", DbType.Int32);
            }
        }
    }
}
