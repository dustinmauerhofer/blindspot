namespace MyBlindSpot
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StoragePage), typeof(StoragePage));
        }   
    }
}