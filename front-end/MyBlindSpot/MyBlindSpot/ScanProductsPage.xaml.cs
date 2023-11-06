using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class ScanProductsPage : ContentPage
{
	public ScanProductsPage(ScanProductsVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}