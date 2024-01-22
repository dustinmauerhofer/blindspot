using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ChooseFrontBack : ContentPage
{
    StorageInformation storageInformation;
    StorageField storageField;
    UserInformation info;
	public ChooseFrontBack(StorageInformation si,StorageField sf,UserInformation user)
	{
		InitializeComponent();
        storageInformation = si;
        storageField = sf;
        info = user;
	}

    private void ContinueToItemAdded_Clicked_Front(object sender, EventArgs e)
    {
        storageInformation.FrontBackAlignment = 0;
        Navigation.PushAsync(new ItemAdded(storageInformation, info));
    }

    private void ContinueToItemAdded_Clicked_Back(object sender, EventArgs e)
    {
        storageInformation.FrontBackAlignment = 1;
        Navigation.PushAsync(new ItemAdded(storageInformation, info));
    }

    private void Camera_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }

    private void Storage_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new StoragePage(info));
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ChooseSpace(storageInformation, storageField, info));
    }

}