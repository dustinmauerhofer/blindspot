using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class CreateStoragePage : ContentPage
{
    public CreateStoragePage()
    {
        InitializeComponent();
    }

    public CreateStoragePage(CreateStorageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void StorageDone_Clicked(object sender, EventArgs e)
    {
        // Add Storage to Database 

        Navigation.PushAsync(new StoragePage());
    }
}