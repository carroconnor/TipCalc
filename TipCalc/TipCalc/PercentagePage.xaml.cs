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
        PercentagePageViewModel model;
        public PercentagePage()
        {
            InitializeComponent();
            model = new PercentagePageViewModel();
            BindingContext = model;
        }

        public void CalculateTip(object sender, EventArgs e)
        {

            Regex inputValidation = new Regex(@"^\d+(\.\d{1,2})?$");

            var testBillDecimalPlace = inputValidation.IsMatch(BillEntry.Text);
            var testTipDecimalPlace = inputValidation.IsMatch(TipEntry.Text);

            if (testBillDecimalPlace && testTipDecimalPlace == true)
            {
                var billIsNumber = float.TryParse(BillEntry.Text, out _);
                var tipIsNumber = float.TryParse(TipEntry.Text, out _);

                if (billIsNumber && tipIsNumber)
                {
                    var billValue = float.Parse(BillEntry.Text);
                    var tipValue = float.Parse(TipEntry.Text);

                    if (billValue < 0 || tipValue < 0)
                    {
                        finalPercentage.Text = "Please Enter In A Positive Number";
                    }
                    else
                    {
                        var tipPercentage = model.TipCalculate(billValue, tipValue);

                        if (!float.IsNaN(tipPercentage))
                        {
                            finalPercentage.Text = "Your Table Tipped You %" + Math.Round(tipPercentage, 4);
                        }
                    }
                }
                else
                {
                    finalPercentage.Text = "Enter a number";
                }
            }
            else
            {
                finalPercentage.Text = "That doesn't look like a valid amount.";
            }
        }
    }
}