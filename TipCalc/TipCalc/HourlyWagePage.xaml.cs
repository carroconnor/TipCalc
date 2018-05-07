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
            BillEntry.TextChanged += ProfitEntry_TextChanged;
            TipEntry.TextChanged += HourEntry_TextChanged;
        }

        string previousProfitInput;
        string previousHourInput;

        protected void ProfitEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$");
            Match matchProfit = reg.Match(BillEntry.Text);
            if (matchProfit.Success)
            {
                previousProfitInput = BillEntry.Text;
            }
            else
            {
                BillEntry.Text = e.OldTextValue;
            }
        }

        protected void HourEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex(@"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$");

            Match matchHour = reg.Match(TipEntry.Text);
            if (matchHour.Success)
            {
                previousHourInput = TipEntry.Text;
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

                    var hourlyWage = model.WageCalculate(MoneyMadeValue, HourValue);

                    if (!float.IsNaN(hourlyWage))
                    {
                        finalHourlyWage.Text = "Today You Made $" + Math.Round(hourlyWage, 2) + " An Hour";
                    }
                }
            }
        }
    }
}