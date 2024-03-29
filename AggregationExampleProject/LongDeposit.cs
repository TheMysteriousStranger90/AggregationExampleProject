namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public override decimal Income()
        {
            decimal amountAfterPeriod = 0;
            decimal tempAmount = Amount;
            decimal tempValue = Amount;
            decimal percent = 1.15M;
            for (int i = 6; i < Period; i++)
            {
                tempValue *= percent;
                amountAfterPeriod = tempValue - tempAmount;
            }

            return amountAfterPeriod;
        }
    }
}