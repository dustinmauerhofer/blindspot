using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class EditStoragePage : ContentPage
{
	public EditStoragePage(EditStorageVM vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}