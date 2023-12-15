namespace MyBlindSpot;

public partial class ItemAdded : ContentPage
{
	public ItemAdded()
	{
		InitializeComponent();
	}

    private void BackToYourStroages_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new StoragePage());
    }
}