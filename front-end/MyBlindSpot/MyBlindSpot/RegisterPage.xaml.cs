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
         Register_Succeded(null, null);
        //Navigation.PushAsync(new LoginPage());
    }

    private async void Register_Succeded(Object sender, EventArgs e)
    {
        RegisterInformation info = new RegisterInformation(username.Text, password.Text);
        HttpResponseMessage response = await APICalls.RegisterAccount(info);

        LoginPage page = new LoginPage();
        Handler += page.RegisterFeedBack;

        //Task.Run(() =>
        //{
            Handler.Invoke(this, new RegisterArgs(await response.Content.ReadAsStringAsync()));
        //});


        Navigation.PushAsync(page);

        
    }
}