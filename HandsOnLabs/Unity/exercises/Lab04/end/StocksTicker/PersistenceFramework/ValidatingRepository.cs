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
using System.Text;

namespace PersistenceFramework
{
    public class ValidatingRepository<T> : IRepository<T>
    {
        private IRepository<T> repository;
        private IValidator<T> validator;

        public ValidatingRepository(IRepository<T> repository, IValidator<T> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public void Save(T instance)
        {
            if (this.validator.IsValid(instance))
            {
                this.repository.Save(instance);
            }
            else
            {
                throw new RepositoryException("Invalid instance to save");
            }
        }
    }
}
