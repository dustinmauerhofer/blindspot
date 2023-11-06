namespace MyBlindSpot;

public partial class BlindMenuPage : ContentPage
{
	public BlindMenuPage(BlindMenuPage vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}