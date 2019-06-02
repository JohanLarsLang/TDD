using System;
using System.Collections.Generic;
using System.IO;
using TddLab1;
using Xunit;

namespace XUnitTestBank
{
    public class UnitTestBankkonto
    {
        internal static TextWriter _stdOut = Console.Out;

        [Fact]
        public void AccountCheckBalance()
        {

            Account account = new Account();
            double actualBalance = account.Balance;
         
            double expectedBalance = 5346.67;
            
            Assert.Equal(actualBalance, expectedBalance);
          

        }

        [Fact]
        public void AccountCheckInterest()
        {
            Account account = new Account();
            double actualInterest = account.Interest;
            double expectedInterest = 0.65;

            Assert.Equal(actualInterest, expectedInterest);

        }

        [Theory]
        [InlineData(3003.33)]
        [InlineData(0.001)]
        public void TestDeposit(double amount)
        {
            Account account = new Account();

            account.Deposit(amount);
            double actualBalance = account.GetBalance();
            double expectedBalance = 5346.67 + amount;

            Assert.Equal(actualBalance, expectedBalance);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        [InlineData(1000000000000.01)] //instead of Double.MaxValue
        [InlineData(0.0)]
        [InlineData(Double.NaN)]
        [InlineData(0.0001)]            //instead of Double.Epsilon
        //[InlineData(Double.Epsilon)]  //the smallest positive Double value that is greater than zero
        public void TestDepositNotValid(double amount)
        {
            Account account = new Account();
            Assert.Throws<Exception>(() =>
            {
                account.Deposit(amount);
            });

        }

        [Theory]
        [InlineData(102.66)]
        public void TestWithdraw(double amount)
        {
            Account account = new Account();

            account.Withdraw(amount);
            double actualBalance = account.GetBalance();
            double expectedBalance = 5346.67 - amount;

            Assert.Equal(actualBalance, expectedBalance);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        [InlineData(5346.68)]
        //[InlineData(1000000000000.01)] //instead of Double.MaxValue
        [InlineData(0.0)]
        [InlineData(Double.NaN)]
        [InlineData(0.0001)]            //instead of Double.Epsilon
        //[InlineData(Double.Epsilon)]  //the smallest positive Double value that is greater than zero
        public void TestWithdrawNotValid(double amount)
        {
            Account account = new Account();
            Assert.Throws<Exception>(() =>
            {
                account.Withdraw(amount);
            });

        }

        List<object[]> AddTrueData()
        {
            return new List<object[]>
        {
                new object[] { new Account(), 133.33 }

       };
           
        }

        [Theory]
        //[Fact]
        //[MemberData(nameof(Account.GetAccountFromDataGenerator), MemberType = typeof(Account)), amount = 103.66)]
        //[MemberData(AddTrueData)]
        [InlineData(1033.33)]
        [InlineData(0.001)]
        public void TestTransferIsTrue(double amount)
        {
            Account account = new Account();
            account.Withdraw(amount);
            double balance = account.GetBalance();

            Account target = new Account();
          
            target.Deposit(amount);

            double expectedTargetBalance = target.GetBalance();

            Assert.True(account.Transfer(target, amount));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        [InlineData(5346.68)]
        [InlineData(0.0)]
        [InlineData(Double.NaN)]
        [InlineData(0.0001)]            
        public void TestTransferwNotValid(double amount)
        {
            Account account = new Account();
            Account target = new Account();

            Assert.Throws<Exception>(() =>
            {
                Assert.True(account.Transfer(target, amount));
            });

        }

        [Fact]
        public void CalculateInterest()
        {
            Account account = new Account();

            double actualInterest = account.CalculateInterrest();
            double expectedInterest = 5346.67 * 0.65 / 100;

            Assert.Equal(actualInterest, expectedInterest);

        }

    }



}
