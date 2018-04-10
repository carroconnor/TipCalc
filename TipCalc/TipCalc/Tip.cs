using Xamarin.Forms;

namespace TipCalc
{
    public class Tip : ContentPage
    {
        public string TipConfig(float BillAmount, float TipAmount)
        {
            if (BillAmount < 0 || TipAmount < 0)
                return "Bill or tip cannot be negative";

            float billAmount = BillAmount / 100;
            float tipPercentage = billAmount * TipAmount;

            return tipPercentage.ToString();
        }
    }
}
