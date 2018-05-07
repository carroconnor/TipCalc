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


                    var tipPercentage = model.TipCalculate(billValue, tipValue);

                    if (!float.IsNaN(tipPercentage))
                    {
                        finalPercentage.Text = "Your Table Tipped You %" + Math.Round(tipPercentage, 4);
                    }
                }
            }
        }
    }
}