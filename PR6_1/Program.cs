using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6_1
{
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountExceedsBalanceMessage = "Credit amount exceeds balance";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double initialBalance)
        {
            m_customerName = customerName;
            m_balance = initialBalance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountExceedsBalanceMessage);
            }

            m_balance += amount;
        }

        static void Main(string[] args)
        {
            var account1 = new BankAccount("John Doe", 1000.00);

            account1.Credit(5.77);
            account1.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", account1.Balance);
            Console.ReadLine();
        }
    }
}
