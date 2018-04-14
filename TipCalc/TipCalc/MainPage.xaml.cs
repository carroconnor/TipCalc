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
            float BillValue = float.Parse(BillEntry.Text);
            float TipValue = float.Parse(TipEntry.Text);

            float TipPercentage = vm.TipCalculate(BillValue, TipValue);

            if (!float.IsNaN(TipPercentage))
            {
                finalPercentage.IsEnabled = true;
                finalPercentage.Text = "Your Table Tipped You %" + Math.Round(TipPercentage, 4);
            }
        }
    }
}
