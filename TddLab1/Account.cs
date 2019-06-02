using System;
using System.Collections.Generic;
using System.Text;

namespace TddLab1
{
    public class Account
    {
       public double Balance { get; private set; }
       public double Interest { get; private set; }

        public Account()
        {
            Balance = 5346.67;
            Interest = 0.65;
        }

        public static IEnumerable<object[]> GetAccountFromDataGenerator()
        {

            yield return new object[]

            {
            new Account {Balance = 1333.44, Interest = 0.56}

            };
        }

            public Account(double initialBalance, double interest)
        {
            Balance = initialBalance;
            Interest = interest;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void Deposit(double amount)
        {
            //amount must be over 0.001
            //Double.Epsilon is 4.94065645841247e-324

            //amount over 1 billjon is not allowed
            //Max value for double is 1.7 × 10^308

            //bool check = Double.IsPositiveInfinity(4.0 / 0); -> check true

            if (amount < 0.001 || amount > 1000000000000 || Double.IsNaN(amount) == true || Double.IsPositiveInfinity(amount) == true) //amount <= Double.Epsilon)
                throw new Exception("Not a valid amount!");

           
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0.001 || Double.IsNaN(amount) == true || Double.IsPositiveInfinity(amount) == true) //amount <= Double.Epsilon)
                throw new Exception("Not a valid amount!");

            if (amount > GetBalance())
                throw new Exception("Wiithdraw is grather than existing balance!");

            Balance -= amount;
        }

        public bool Transfer(Account target, double amount)
        {
            if (amount < 0.001 || Double.IsNaN(amount) == true || Double.IsPositiveInfinity(amount) == true)
                throw new Exception("Not a valid amount!");

            if (amount > GetBalance())
                throw new Exception("Wiithdraw is grather than existing balance!");

            double expectedBalance = target.GetBalance();

            return (target.Balance == expectedBalance);
        }

        public double CalculateInterrest()
        {
            Account account = new Account();

            double interest = account.Balance * account.Interest / 100;

            account.Balance += interest;

            return interest;
        }
    }
}
