using MyBlindSpot.ViewModel;
using Microsoft.Maui.Controls;
using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
    StorageInformation storageInformation;
    UserInformation info;
    public ScanDonePage(Image img, string e, UserInformation user)
    {
        InitializeComponent();

        if (img != null)
        {
            picture = img;
        }
        
        evaluation.Text = e;
        storageInformation = new StorageInformation();
        storageInformation.StoredObject = e;

        info = user;
    }


    private void SaveNewItem_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddItemPage(storageInformation,info));
    }

    private void Retake_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }
}