using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BankAccountLab;


namespace BankAccountLab
{

        [TestFixture]
        public class BankAccountTests
        {
            // Test data
            private string sortCode = "12-34-56";
            private string accountNumber = "12345678";
            private double overdraftLimit = 500;
            private double initialBalance = 0;
            private double depositAmount = 100;
            private double withdrawAmount = 50;

            // Test object
            private BankAccount account;

            [SetUp]
            public void SetUp()
            {
                // Create a new BankAccount object before each test
                account = new BankAccount(sortCode, accountNumber, overdraftLimit);
            }

            [Test]
            public void Constructor_WithThreeParameters_ShouldSetFieldsCorrectly()
            {
                // Assert that the fields are set correctly by the constructor
                Assert.AreEqual(sortCode, account.SortCode);
                Assert.AreEqual(accountNumber, account.AccountNumber);
                Assert.AreEqual(overdraftLimit, account.OverdraftLimit);
                Assert.AreEqual(initialBalance, account.Balance);
                Assert.IsNotNull(account.TransactionHistory);
                Assert.IsEmpty(account.TransactionHistory);
            }

            [Test]
            public void Constructor_WithTwoParameters_ShouldSetOverdraftLimitToZero()
            {
                // Create a new BankAccount object with two parameters
                account = new BankAccount(sortCode, accountNumber);

                // Assert that the overdraft limit is set to zero
                Assert.AreEqual(0, account.OverdraftLimit);
            }

            [Test]
            public void Deposit_WithPositiveAmount_ShouldIncreaseBalanceAndAddToHistory()
            {
                // Act
                account.Deposit(depositAmount);

                // Assert
                Assert.AreEqual(initialBalance + depositAmount, account.Balance);
                Assert.AreEqual(1, account.TransactionHistory.Count);
                Assert.AreEqual(depositAmount, account.TransactionHistory[0]);
            }

            [Test]
            public void Deposit_WithNegativeAmount_ShouldThrowArgumentException()
            {
                // Assert
                Assert.Throws<ArgumentException>(() => account.Deposit(-depositAmount));
            }

            [Test]
            public void Withdraw_WithPositiveAmountAndSufficientFunds_ShouldDecreaseBalanceAndAddToHistory()
            {
                // Arrange
                account.Deposit(depositAmount);

                // Act
                account.Withdraw(withdrawAmount);

                // Assert
                Assert.AreEqual(initialBalance + depositAmount - withdrawAmount, account.Balance);
                Assert.AreEqual(2, account.TransactionHistory.Count);
                Assert.AreEqual(-withdrawAmount, account.TransactionHistory[1]);
            }

            [Test]
            public void Withdraw_WithPositiveAmountAndInsufficientFunds_ShouldThrowInvalidOperationException()
            {
                // Assert
                Assert.Throws<InvalidOperationException>(() => account.Withdraw(withdrawAmount));
            }

            [Test]
            public void Withdraw_WithNegativeAmount_ShouldThrowArgumentException()
            {
                // Assert
                Assert.Throws<ArgumentException>(() => account.Withdraw(-withdrawAmount));
            }

            [Test]
            public void ToString_ShouldReturnAllInformationAboutTheAccount()
            {
                // Arrange
                account.Deposit(depositAmount);
                account.Withdraw(withdrawAmount);

                // Act
                string result = account.ToString();

                // Assert
                Assert.AreEqual($"Sort code: {sortCode}\nAccount number: {accountNumber}\nOverdraft limit: {overdraftLimit}\nBalance: {initialBalance + depositAmount - withdrawAmount}\nTransaction history: {depositAmount}, {-withdrawAmount}\n", result);
            }
        }
    
}
