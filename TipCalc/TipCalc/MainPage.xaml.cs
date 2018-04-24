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

        public async void BtnPercentage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PercentagePage());
            btnPercentage.IsEnabled = true;
        }
    }
}


