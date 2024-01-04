namespace MyBlindSpot;

public partial class ChoosePlace : ContentPage
{
	public ChoosePlace()
	{
		InitializeComponent();
	}

    private void ContinueToSpace_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChooseSpace());
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
        Navigation.PushAsync(new CreateStoragePage());
    }
}