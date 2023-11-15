using System;
using System.Collections.Generic;
using BankAccountLab;

namespace BankAccountLab

{
        public class BankAccount
        {
            // Fields
            private string sortCode;
            private string accountNumber;
            private double overdraftLimit;
            private double balance;
            private List<double> transactionHistory;

            // Properties
            public string SortCode { get { return sortCode; } }
            public string AccountNumber { get { return accountNumber; } }
            public double OverdraftLimit { get { return overdraftLimit; } }
            public double Balance { get { return balance; } }
            public List<double> TransactionHistory { get { return transactionHistory; } }

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
                // No additional code needed
            }

            // Methods
            public void Deposit(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount to deposit must be positive.");
                }
                balance += amount;
                transactionHistory.Add(amount);
            }

            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount to withdraw must be positive.");
                }
                if (balance - amount < -overdraftLimit)
                {
                    throw new InvalidOperationException("Insufficient funds to withdraw.");
                }
                balance -= amount;
                transactionHistory.Add(-amount);
            }

            public override string ToString()
            {
                string result = $"Sort code: {sortCode}\n";
                result += $"Account number: {accountNumber}\n";
                result += $"Overdraft limit: {overdraftLimit}\n";
                result += $"Balance: {balance}\n";
                result += $"Transaction history: {string.Join(", ", transactionHistory)}\n";
                return result;
            }
        }
    }