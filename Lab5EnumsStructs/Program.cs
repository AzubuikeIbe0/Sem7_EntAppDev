using System;

namespace Lab5EnumsStructs
{
    public enum Currency
    {
        dollar,
        euro,
        yuan
    }

    public struct Money
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }

        private const double EURUSD = 1.10;
        private const double USDEUR = 1/EURUSD;

        public Money(double amount, Currency currency): this()
        {
            Amount = amount;
            Currency = currency;
        }

        public double ConvertCurrency(Currency toCurrency)
        {
            if(Currency == toCurrency)
            {
                return Amount;
            }
            else
            {
                if(toCurrency == Currency.dollar)
                {
                    return Amount * EURUSD;
                }
                else
                {
                    return Amount * USDEUR; 
                }
            }

        }

        public static Money operator +(Money lhs, Money rhs)
        {
            if(lhs.Currency == rhs.Currency)
            {
                return new Money(lhs.Amount + rhs.Amount, lhs.Currency);
            }
            else
            {
                return new Money(lhs.Amount + rhs.ConvertCurrency(lhs.Currency), lhs.Currency);
            }
        }

        public override string ToString()
        {
            return this.Currency + ": " + this.Amount;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new Money(50, Currency.dollar);
            Money m2 = new Money(40, Currency.euro);

            Money m3 = m1 + m2;

            Console.WriteLine(m3);

            Money m4 = m3 + (new Money(100, Currency.dollar));

            Console.WriteLine(m4);
        }
    }
}