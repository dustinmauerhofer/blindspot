using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    
    public void RegisterFeedBack(object sender, RegisterArgs e)
    {
        ShowFeedbackFor5Sek(e.Response);
    }

    private async void ShowFeedbackFor5Sek(string response)
    {
        feedbackPopUp.Text = response;

       
        feedbackPopUp.Opacity = 0;
        feedbackPopUp.TranslationY = -50; 

        
        await feedbackPopUp.FadeTo(1, 500); 
        await feedbackPopUp.TranslateTo(0, 0, 500, Easing.SpringOut); 
     
        await Task.Delay(3000);
       
        await feedbackPopUp.FadeTo(0, 500); 
        await feedbackPopUp.TranslateTo(0, -50, 500, Easing.SpringIn); 

    }


    private void LoginSucceeded_Clicked(object sender, EventArgs e)
    {
        UserInformation info = new UserInformation(1, "TestAcc");
        
        Navigation.PushAsync(new MainPage(info));
    }

    private void GoToRegister_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }

    private void GoToRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }
}