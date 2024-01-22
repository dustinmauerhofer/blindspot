using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class RegisterPage : ContentPage
{

    public event EventHandler<RegisterArgs> Handler;

    public RegisterPage()
    {
        InitializeComponent();
    }



    private void Login_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    private async void Register_Succeded(object sender, EventArgs e)
    {
        RegisterInformation info = new RegisterInformation(username.Text, password.Text);
        HttpResponseMessage response = await APICalls.RegisterAccount(info);

        LoginPage page = new LoginPage();
        Handler += page.RegisterFeedBack;

        //Task.Run(() =>
        //{
            Handler.Invoke(this, new RegisterArgs(response.ToString()));
        //});


        Navigation.PushAsync(page);
    }
}