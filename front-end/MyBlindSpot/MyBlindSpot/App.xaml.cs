using MyBlindSpot.ViewModel;

namespace MyBlindSpot
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new RegisterPage());
        }
    }
}