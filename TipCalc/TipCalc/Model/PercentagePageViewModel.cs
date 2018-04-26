namespace TipCalc.Model
{
    public class PercentagePageViewModel
    {
        public float BillValue { get; set; }
        public float TipValue { get; set; }
        public float TipPercentage { get; set; }

        public float TipCalculate(float BillValue, float TipValue)
        {
            TipPercentage = (TipValue / BillValue) * 100;

            return TipPercentage;
        }
    }
}
