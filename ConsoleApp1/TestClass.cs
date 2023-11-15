using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
   

    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void TestDeposit()
        {
            // Arrange
            BankAccount account = new BankAccount("123456", "789012");

            // Act
            account.Deposit(100);

            // Assert
            Assert.AreEqual(100, account.Balance);
        }



        [TestMethod]
        public void TestWithdraw()
        {
            // Arrange
            BankAccount account = new BankAccount("123456", "789012", 50);

            // Act
            account.Withdraw(30);

            // Assert
            Assert.AreEqual(20, account.Balance);
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void TestInsufficientFunds()
        {
            // Arrange
            BankAccount account = new BankAccount("123456", "789012");

            // Act & Assert
            account.Withdraw(50);
        }




        [TestMethod]
        public void TestTransactionHistory()
        {
            // Arrange
            BankAccount account = new BankAccount("123456", "789012");

            // Act
            account.Deposit(100);
            account.Withdraw(50);

            // Assert
            CollectionAssert.AreEqual(new List<double> { 100, -50 }, account.TransactionHistory);
        }



        [TestMethod]
        public void TestToString()
        {
            // Arrange
            BankAccount account = new BankAccount("123456", "789012", 50);

            // Act
            string result = account.ToString();

            // Assert
            Assert.AreEqual("Sort Code: 123456, Account Number: 789012, Overdraft Limit: 50, Balance: 0, Transaction History: []", result);
        }



        public static void Main(string[] args)
        {
            // Create an instance of BankAccount and perform some operations
            BankAccount account = new BankAccount("123456", "789012", 50);

            Console.WriteLine("Initial Account Details:");
            Console.WriteLine(account);

            account.Deposit(100);
            Console.WriteLine("\nAfter Deposit:");
            Console.WriteLine(account);

            account.Withdraw(30);
            Console.WriteLine("\nAfter Withdrawal:");
            Console.WriteLine(account);

            // Additional testing or operations can be performed here
        }
    }

   


}
