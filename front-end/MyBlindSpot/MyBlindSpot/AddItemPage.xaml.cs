using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class AddItemPage : ContentPage
{
	public AddItemPage(AddItemVM vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}