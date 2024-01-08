using MyBlindSpot.ViewModel;
using Microsoft.Maui.Controls;
using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
    StorageInformation storageInformation;
    public ScanDonePage(ImageSource img, string e)
    {
        InitializeComponent();

        var image = new Image
        {
            Source = img,
        };
        picture = image;
        evaluation.Text = e;
        storageInformation = new StorageInformation();
        storageInformation.StoredObject = e;
    }


    private void SaveNewItem_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddItemPage(storageInformation));
    }

    private void Retake_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }
}