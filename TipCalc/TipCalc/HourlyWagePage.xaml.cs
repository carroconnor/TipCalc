using System;
using System.Text.RegularExpressions;
using TipCalc.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HourlyWagePage : ContentPage
    {
        HourlyWagePageViewModel model;
        public HourlyWagePage()
        {
            InitializeComponent();
            model = new HourlyWagePageViewModel();
            BindingContext = model;
        }

        public void CalculateHourlyWage(object sender, EventArgs e)
        {

            Regex inputValidation = new Regex(@"^\d+(\.\d{1,2})?$");

            var TestMoneyMadeDecimalPlace = inputValidation.IsMatch(BillEntry.Text);
            var TestHoursDecimalPlace = inputValidation.IsMatch(TipEntry.Text);

            if (TestMoneyMadeDecimalPlace && TestHoursDecimalPlace == true)
            {
                var MoneyMadeIsNumber = float.TryParse(BillEntry.Text, out _);
                var HoursIsNumber = float.TryParse(TipEntry.Text, out _);

                if (MoneyMadeIsNumber && HoursIsNumber)
                {
                    var MoneyMadeValue = float.Parse(BillEntry.Text);
                    var HourValue = float.Parse(TipEntry.Text);

                    if (MoneyMadeValue < 0 || HourValue < 0)
                    {
                        finalHourlyWage.Text = "Please Enter In A Positive Number";
                    }

                    else
                    {
                        var HourlyWage = model.WageCalculate(MoneyMadeValue, HourValue);

                        if (!float.IsNaN(HourlyWage))
                        {
                            finalHourlyWage.IsEnabled = true;
                            finalHourlyWage.Text = "Today You Made $" + Math.Round(HourlyWage, 2) + " An Hour";
                        }
                    }
                }

                else
                {
                    finalHourlyWage.Text = "Enter in a number";
                }
            }

            else
            {
                finalHourlyWage.Text = "That doesn't look like a valid value.";
            }
        }
    }
}