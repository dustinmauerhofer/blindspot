using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
	public ScanDonePage(ScanDoneVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}