using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
    public ScanDonePage()
    {
        InitializeComponent();
    }

    public ScanDonePage(ScanDoneVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void SaveNewItem_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddItemPage());
    }

    private void Retake_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }
}