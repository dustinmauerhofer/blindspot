using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class EditStoragePage : ContentPage
{
    public EditStoragePage()
    {
        InitializeComponent();
    }

    public EditStoragePage(EditStorageVM vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}

    private void Camera_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }

    private void DeleteItem_Click(object sender, EventArgs e)
    {
        // Delete Logic
    }

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }
}