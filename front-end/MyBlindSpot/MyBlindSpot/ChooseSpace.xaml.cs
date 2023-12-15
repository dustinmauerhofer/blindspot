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
}