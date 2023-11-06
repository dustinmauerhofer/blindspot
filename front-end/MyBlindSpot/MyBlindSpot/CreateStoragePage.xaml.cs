using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class CreateStoragePage : ContentPage
{
	public CreateStoragePage(CreateStorageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}