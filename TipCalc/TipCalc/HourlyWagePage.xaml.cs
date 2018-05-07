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
            BillEntry.TextChanged += BillEntry_TextChanged;
            TipEntry.TextChanged += TipEntry_TextChanged;
        }

        string previousBillInput = "";
        string previousTipInput = "";

        protected void BillEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$");
            Match matchBill = reg.Match(BillEntry.Text);
            if (matchBill.Success)
            {
                previousBillInput = BillEntry.Text;
            }
            else
            {
                BillEntry.Text = previousBillInput;
            }
        }

        protected void TipEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$");

            Match matchTip = reg.Match(TipEntry.Text);
            if (matchTip.Success)
            {
                previousTipInput = TipEntry.Text;
            }
            else
            {
                TipEntry.Text = e.OldTextValue;
            }
        }

        public void CalculateHourlyWage(object sender, EventArgs e)
        {

            Regex inputValidation = new Regex(@"^\d+(\.\d{1,2})?$");

            var testMoneyMadeDecimalPlace = inputValidation.IsMatch(BillEntry.Text);
            var testHoursDecimalPlace = inputValidation.IsMatch(TipEntry.Text);

            if (testMoneyMadeDecimalPlace && testHoursDecimalPlace == true)
            {
                var moneyMadeIsNumber = float.TryParse(BillEntry.Text, out _);
                var hoursIsNumber = float.TryParse(TipEntry.Text, out _);

                if (moneyMadeIsNumber && hoursIsNumber)
                {
                    var MoneyMadeValue = float.Parse(BillEntry.Text);
                    var HourValue = float.Parse(TipEntry.Text);

                    if (MoneyMadeValue < 0 || HourValue < 0)
                    {
                        finalHourlyWage.Text = "Please Enter In A Positive Number";
                    }
                    else
                    {
                        var hourlyWage = model.WageCalculate(MoneyMadeValue, HourValue);

                        if (!float.IsNaN(hourlyWage))
                        {
                            finalHourlyWage.Text = "Today You Made $" + Math.Round(hourlyWage, 2) + " An Hour";
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