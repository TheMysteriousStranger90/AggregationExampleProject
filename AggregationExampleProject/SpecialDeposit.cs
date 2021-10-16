namespace Aggregation
{
    public class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public override decimal Income()
        {
            decimal amountAfterPeriod = 0;
            decimal tempAmount = Amount;
            decimal tempValue = Amount;
            decimal percent = 1.01M;
            for (int i = 0; i < Period; i++)
            {
                tempValue *= percent;
                amountAfterPeriod = tempValue - tempAmount;
                percent += 0.01M;
            }

            return amountAfterPeriod;
        }
    }
}