using MyBlindSpot.Classes;

namespace MyBlindSpot
{   
    public partial class MainPage : ContentPage
    {
        ISpeechToText speech;
        UserInformation info;
        public MainPage(UserInformation user)
        {
            InitializeComponent();
            info = user;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BlindMenuPage(speech,info));  
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            // Assistant
            Navigation.PushAsync(new StartPage(info));
        }

        private void Tapped_Blind(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new BlindMenuPage(speech, info));
        }

        private void Tapped_Assistant(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new StartPage(info));
        }
    }
}