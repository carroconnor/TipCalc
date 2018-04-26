using System;
using System.Text.RegularExpressions;
using TipCalc.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PercentagePage : ContentPage
    {
        PercentagePageViewModel vm;
        public PercentagePage()
        {
            InitializeComponent();
            vm = new PercentagePageViewModel();
            BindingContext = vm;
        }

        public void CalculateTip(object sender, EventArgs e)
        {

            Regex inputValidation = new Regex(@"^\d+(\.\d{1,2})?$");

            var TestBillDecimalPlace = inputValidation.IsMatch(BillEntry.Text);
            var TestTipDecimalPlace = inputValidation.IsMatch(TipEntry.Text);

            if (TestBillDecimalPlace && TestTipDecimalPlace == true)
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

            else
            {
                finalPercentage.Text = "That doesn't look like a valid money value.";
            }
        }
    }
}