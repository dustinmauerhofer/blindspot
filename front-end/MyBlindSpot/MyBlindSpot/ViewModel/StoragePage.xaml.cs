using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class StoragePage : ContentPage
{
    public StoragePage()
    {
        InitializeComponent();
    }

    public StoragePage(StorageViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void AddNewStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateStoragePage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Back to Main
        Navigation.PushAsync(new StartPage());
    }

    private void YourStorages_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }

    private void Camera_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }

    private void SpecificStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditStoragePage());
    }

    private void ScanYourProducts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanProductsPage());
    }
}