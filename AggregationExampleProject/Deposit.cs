using System;
using System.Collections.Generic;
using System.Text;

namespace Aggregation
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        public int CompareTo(Deposit other)
        {
            return Amount.CompareTo(other.Amount);
        }

        public Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();
    }
}