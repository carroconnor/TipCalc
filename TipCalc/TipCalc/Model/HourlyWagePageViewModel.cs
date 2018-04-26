namespace TipCalc.Model
{
    public class HourlyWagePageViewModel
    {
        public float MoneyMadeValue { get; set; }
        public float HourValue { get; set; }
        public float HourlyWage { get; set; }

        public float WageCalculate(float MoneyMadeValue, float HourValue)
        {
            HourlyWage = (MoneyMadeValue / HourValue);

            return HourlyWage;
        }
    }
}
