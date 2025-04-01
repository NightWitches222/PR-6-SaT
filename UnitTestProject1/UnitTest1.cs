using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PR6_1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            double beginningBalance = 11.99;
            double debitBalace = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            account.Debit(debitBalace);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.0;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The excepted exception was not thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmiuntIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The excepted exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdateBalance()
        {
            double beginningBalance = 11.99;
            double debitBalace = 4.00;
            double expected = 15.99;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            account.Credit(debitBalace);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly.");
        }

        [TestMethod]
        public void Credit_WhenAmiuntIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("John Doe", beginningBalance);

            try
            {
                account.Credit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The excepted exception was not thrown.");
        }
    }
}
