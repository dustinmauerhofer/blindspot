using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class StoragePage : ContentPage
{
	public StoragePage(StorageViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;	
	}
}