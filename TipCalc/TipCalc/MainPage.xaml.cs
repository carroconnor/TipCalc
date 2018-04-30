using Xamarin.Forms;

namespace TipCalc
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel model;
        public MainPage()
        {
            InitializeComponent();
            model = new MainPageViewModel();
            BindingContext = model;
        }
    }
}


