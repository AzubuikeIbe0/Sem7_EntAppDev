using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

    class BankAccount
    {
        // Fields
        private string sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> transactionHistory;

        // Read-only properties
        public string SortCode => sortCode;
        public string AccountNumber => accountNumber;
        public double OverdraftLimit => overdraftLimit;
        public double Balance => balance;
        public List<double> TransactionHistory => transactionHistory;

        // Constructors
        public BankAccount(string sortCode, string accountNumber, double overdraftLimit)
        {
            this.sortCode = sortCode;
            this.accountNumber = accountNumber;
            this.overdraftLimit = overdraftLimit;
            this.balance = 0;
            this.transactionHistory = new List<double>();
        }

        public BankAccount(string sortCode, string accountNumber) : this(sortCode, accountNumber, 0)
        {
            // Default constructor with overdraft limit set to zero
        }

        // Methods
        public void Deposit(double amount)
        {
            balance += amount;
            transactionHistory.Add(amount);
        }

        public void Withdraw(double amount)
        {
            if (balance - amount < -overdraftLimit)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }

            balance -= amount;
            transactionHistory.Add(-amount);
        }

        // Override ToString to include transaction history
        public override string ToString()
        {
            string history = string.Join(", ", transactionHistory);
            return $"Sort Code: {sortCode}, Account Number: {accountNumber}, Overdraft Limit: {overdraftLimit}, Balance: {balance}, Transaction History: [{history}]";
        }
    }

}