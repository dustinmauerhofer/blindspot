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

    private void Register_Succeded(object sender, EventArgs e)
    {
        RegisterInformation info = new RegisterInformation();
        LoginPage page = new LoginPage();
        Handler += page.RegisterFeedBack;

        Task.Run(() =>
        {
            var response = APICalls.RegisterAccount(info).Result;
            Handler.Invoke(this, new RegisterArgs(response));
        });


        Navigation.PushAsync(page);
    }
}