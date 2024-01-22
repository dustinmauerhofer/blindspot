using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class StoragePage : ContentPage
{
    UserInformation info;
    public StoragePage(UserInformation user)
    {
        InitializeComponent();
        info = user;
    }

    public StoragePage(StorageViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void AddNewStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateStoragePage(info));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Back to Main
        Navigation.PushAsync(new StartPage(info));
    }

    private void YourStorages_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage(info));
    }

    private void Camera_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }

    private void SpecificStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditStoragePage(info));
    }

    private void ScanYourProducts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanProductsPage(info));
    }
}