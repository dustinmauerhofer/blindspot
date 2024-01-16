namespace MyBlindSpot;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void LoginSucceeded_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void GoToRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }
}