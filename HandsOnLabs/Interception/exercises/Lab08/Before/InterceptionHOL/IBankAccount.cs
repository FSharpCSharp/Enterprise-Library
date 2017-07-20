using System;

namespace InterceptionHOL.BusinessLogic
{
    public interface IBankAccount
    {
        void Deposit(decimal depositAmount);
        decimal GetCurrentBalance();
        void Withdraw(decimal withdrawAmount);
    }
}
