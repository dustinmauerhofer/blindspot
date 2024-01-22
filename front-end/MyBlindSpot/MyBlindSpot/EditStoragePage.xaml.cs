using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class EditStoragePage : ContentPage
{
    UserInformation info;
    public EditStoragePage(UserInformation user)
    {
        InitializeComponent();
        info = user;
    }

    public EditStoragePage(EditStorageVM vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}

    private void Camera_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }

    private void DeleteItem_Click(object sender, EventArgs e)
    {
        // Delete Logic
    }

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage(info));
    }
}