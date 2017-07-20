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

namespace InterceptionHOL.BusinessLogic
{
    public class BankAccount : IBankAccount
    {
        private decimal balance;

        public virtual decimal GetCurrentBalance()
        {
            return balance;
        }

        public virtual void Deposit(decimal depositAmount)
        {
            balance += depositAmount;
        }

        public virtual void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount > balance)
            {
                throw new ArithmeticException();
            }
            balance -= withdrawAmount;
        }
    }
}
