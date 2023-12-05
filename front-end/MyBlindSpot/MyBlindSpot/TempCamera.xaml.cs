namespace MyBlindSpot;

public partial class TempCamera : ContentPage
{
	public TempCamera()
	{
		InitializeComponent();
	}

    private void ScanDone_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanDonePage());
    }

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }
}