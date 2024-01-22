using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;
using System.Diagnostics.CodeAnalysis;

namespace MyBlindSpot;

public partial class StartPage : ContentPage
{
    UserInformation user;
    public StartPage(UserInformation info)
    {
        InitializeComponent();
        user = info;
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
        Navigation.PushAsync(new StoragePage(user));
    }

    private void Camera_Click(object sender, EventArgs e)
    {
        // CAM NAVIGATION
        Navigation.PushAsync(new TempCamera(user));
    }
}