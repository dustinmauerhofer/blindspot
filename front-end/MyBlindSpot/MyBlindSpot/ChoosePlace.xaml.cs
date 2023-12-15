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
}