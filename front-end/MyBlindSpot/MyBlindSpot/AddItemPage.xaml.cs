using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class AddItemPage : ContentPage
{
    public AddItemPage()
    {
        InitializeComponent();
    }

    public AddItemPage(AddItemVM vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void ItemAdded_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChoosePlace());
    }
}