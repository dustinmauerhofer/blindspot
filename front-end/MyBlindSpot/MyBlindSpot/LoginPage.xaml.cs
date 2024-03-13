using MyBlindSpot.Classes;
using System.Text.Json;

namespace MyBlindSpot;

public record User(string jwtToken, string userName);

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


    private async void LoginSucceeded_Clicked(object sender, EventArgs e)
    {
        //hier macht adam sachen
        string userName = username.Text;
        string pw = password.Text;

        if (userName == null || pw == null)
        {
            ShowFeedbackFor5Sek("Enter a username and a password.");
            return;
        }

        RegisterInformation login_info = new RegisterInformation(username.Text, pw);
        HttpResponseMessage response = await APICalls.LoginAccount(login_info);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string data = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(data);
            ShowFeedbackFor5Sek(user.userName + user.jwtToken);

            UserInformation info = new UserInformation(user.jwtToken, userName);
            Navigation.PushAsync(new MainPage(info));
        }
        else
        {
            ShowFeedbackFor5Sek("Login failed. Check your username and password again.");
        }

        
        
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