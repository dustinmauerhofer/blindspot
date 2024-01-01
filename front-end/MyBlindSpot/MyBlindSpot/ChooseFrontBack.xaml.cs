namespace MyBlindSpot;

public partial class ChooseFrontBack : ContentPage
{
	public ChooseFrontBack()
	{
		InitializeComponent();
	}

    private void ContinueToItemAdded_Clicked_Front(object sender, EventArgs e)
    {
		Navigation.PushAsync(new ItemAdded());
    }

    private void ContinueToItemAdded_Clicked_Back(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ItemAdded());
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
        Navigation.PushAsync(new ChooseSpace());
    }

}