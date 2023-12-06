    namespace MyBlindSpot
{   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BlindMenuPage());  
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            // Assistant
            Navigation.PushAsync(new StartPage());
        }

        private void Tapped_Blind(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new BlindMenuPage());
        }

        private void Tapped_Assistant(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new StartPage());
        }
    }
}