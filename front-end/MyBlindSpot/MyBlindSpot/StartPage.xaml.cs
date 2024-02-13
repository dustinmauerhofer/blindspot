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

    private void Backbtn_Clicked(object sender, TappedEventArgs e)
    {
        // Back to Main
        Navigation.PopAsync();
    }

    private void Storagebtn_Clicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new StoragePage(user));

    }

    private void Camerabtn_Clicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ScanProductsPage(user));

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage(user));
    }
}