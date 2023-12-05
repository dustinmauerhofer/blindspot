using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    public StartPage( StartViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Back to Main
        Navigation.PopAsync();
    }

    private void YourStorages_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }

    private void Camera_Click(object sender, EventArgs e)
    {
        // CAM NAVIGATION
    }
}