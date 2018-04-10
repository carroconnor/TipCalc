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

        //public async string BtnLogin_OnClicked(float BillEntry, float TipEntry)
        //{
        //    // Make sure they filled all the fields.
        //    if (float.IsNaN(BillEntry) || float.IsNaN(TipEntry))
        //    {
        //        await DisplayAlert("Whoops", "Please enter a number.", "Sounds good");
        //        return (TipConfig);
        //    }
        //}
    }
}
