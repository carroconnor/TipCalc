
using Xamarin.Forms;

namespace TipCalc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new TipCalc.MainPage();
            MainPage = new TabbedPage
            {
                Children =
                {
                    new TipCalc.MainPage(),
                    new TipCalc.PercentagePage(),
                    new TipCalc.HourlyWagePage()
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
