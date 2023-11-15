using System;

namespace EnumeratorsOperatorOverloading_B
{
    public enum CurrencyUnit
    {
        Dollar,
        Euro
    }

    public struct Money
    {
        public double Amount { get; set; }
        public  CurrencyUnit Currency { get; set; }

        public const double toEuro = 1.96;
        public const double toDollar = 1 / toEuro;



        public Money(double amount, CurrencyUnit currency): this()
        {
            Amount = amount;
            Currency = currency;
        }

        public double Convert(CurrencyUnit toCurrency)
        {
            if(Currency == toCurrency)
            {
                return Amount;
            }
            else
            {
                if(Currency == CurrencyUnit.Euro)
                {
                    return Amount * toEuro;
                }
                else
                {
                    return Amount * toDollar;
                }
            }
        }

        // VB.Net

        /* public static Money Add(Money lhs, Money rhs)
         {
             return lhs + rhs;
         }*/

        public static Money operator +(Money lhs, Money rhs)
        {
            double resultAmount = lhs.Currency == rhs.Currency
                ? lhs.Amount + rhs.Amount
                : lhs.Amount + rhs.Convert(lhs.Currency);

            return new Money(resultAmount, lhs.Currency);
        }

        public override string ToString()
        {
            return $"{Currency}: {Amount}";
        }


    }

}