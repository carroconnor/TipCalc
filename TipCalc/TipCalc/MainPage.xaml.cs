using System;
using Xamarin.Forms;

namespace TipCalc
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        public void CalculateTip(object sender, EventArgs e)
        {
            var BillIsNumber = float.TryParse(BillEntry.Text, out _);
            var TipIsNumber = float.TryParse(TipEntry.Text, out _);

            if (BillIsNumber && TipIsNumber)
            {
                var BillValue = float.Parse(BillEntry.Text);
                var TipValue = float.Parse(TipEntry.Text);

                if (BillValue < 0 || TipValue < 0)
                {
                    finalPercentage.Text = "Please Enter In A Positive Number";
                }

                else
                {
                    var TipPercentage = vm.TipCalculate(BillValue, TipValue);

                    if (!float.IsNaN(TipPercentage))
                    {
                        finalPercentage.IsEnabled = true;
                        finalPercentage.Text = "Your Table Tipped You %" + Math.Round(TipPercentage, 4);
                    }
                }
            }

            else
            {
                finalPercentage.Text = "Enter in a number";
            }
        }
    }
}
