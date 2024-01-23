using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class InsideStorage : ContentPage
{
	UserInformation info;
	StorageField storageField;
	public InsideStorage(UserInformation user, StorageField sf)
	{
		InitializeComponent();
		user = info;
		storageField = sf;
        PullItems();
	}

    private void PullItems()
    {
        var items = APICalls.LoadeItems()
    }
}