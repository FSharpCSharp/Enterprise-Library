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

namespace ProductMaintenance
{
	public class Category
	{
        int _categoryId;
        string _name;
        string _description;

	    public int CategoryId
	    {
	        get { return _categoryId; }
	    }

	    public string Name
	    {
	        get { return _name; }
	    }

	    public string Description
	    {
	        get { return _description; }
	    }

	    public Category(int categoryId, string name, string description)
		{
            _categoryId = categoryId;
            _name = name;
            _description = description;
		}

        public override string ToString()
        {
            return _name;
        }

	}
}
