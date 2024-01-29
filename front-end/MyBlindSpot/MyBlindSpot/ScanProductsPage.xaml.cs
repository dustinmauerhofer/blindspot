using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class ScanProductsPage : ContentPage
{
    UserInformation info;
	public ScanProductsPage(UserInformation user)
	{
		InitializeComponent();
		info = user;
	}

    private void AiScanner_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }

    private void BarcodeScanner_Tapped(object sender, TappedEventArgs e)
    {

    }
}