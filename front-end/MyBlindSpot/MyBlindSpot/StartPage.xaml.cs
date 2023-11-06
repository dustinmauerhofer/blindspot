using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class StartPage : ContentPage
{
	public StartPage( StartViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}