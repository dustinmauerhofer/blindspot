using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MyBlindSpot;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

  

    private void Login_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    private void Register_Succeded(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}