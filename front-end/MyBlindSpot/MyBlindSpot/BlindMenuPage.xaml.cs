namespace MyBlindSpot;

public partial class BlindMenuPage : ContentPage
{
	public BlindMenuPage(/*BlindMenuPage vm*/)
	{
		InitializeComponent();
		//BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}