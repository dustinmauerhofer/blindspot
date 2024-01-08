using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ChooseFrontBack : ContentPage
{
    StorageInformation storageInformation;
    StorageField storageField;
	public ChooseFrontBack(StorageInformation si,StorageField sf)
	{
		InitializeComponent();
        storageInformation = si;
        storageField = sf;
	}

    private void ContinueToItemAdded_Clicked_Front(object sender, EventArgs e)
    {
        storageInformation.FrontBackAlignment = 0;
        Navigation.PushAsync(new ItemAdded(storageInformation));
    }

    private void ContinueToItemAdded_Clicked_Back(object sender, EventArgs e)
    {
        storageInformation.FrontBackAlignment = 1;
        Navigation.PushAsync(new ItemAdded(storageInformation));
    }

    private void Camera_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }

    private void Storage_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ChooseSpace(storageInformation, storageField));
    }

}