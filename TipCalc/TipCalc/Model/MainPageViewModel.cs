using Xamarin.Forms;

namespace TipCalc
{
    public class MainPageViewModel
    {
        public float BillEntry { get; set; }
        public float TipEntry { get; set; }
        public string TipPercentage { get; set; }
        public string GetPercentage
        {
            get
            {
                return TipConfig(BillEntry, TipEntry);
            }
        }

        public Command TipCommand { get; set; }

        public string TipConfig(float BillAmount, float TipAmount)
        {
            if (BillAmount < 0 || TipAmount < 0)
                return "Bill or tip cannot be negative";

            float billAmount = BillAmount / 100;
            float tipPercentage = billAmount * TipAmount;

            return tipPercentage.ToString();
        }

        public MainPageViewModel()
        {
            //BillEntry = "Enter Total Bill Before Tip: ";
            //TipEntry = "Enter Total Tip Given:";
            TipPercentage = "Tip Percentage";

            TipCommand = new Command(
                execute: () =>
                {
                    TipConfig(BillEntry, TipEntry);
                });
        }


    }
}
