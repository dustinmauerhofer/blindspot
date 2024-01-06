namespace MyBlindSpot;

public partial class ChooseSpace : ContentPage
{
	public ChooseSpace()
	{
		InitializeComponent();
	}

    private void ContinueToFrontBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChooseFrontBack());
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
        Navigation.PushAsync(new ChoosePlace());
    }
}