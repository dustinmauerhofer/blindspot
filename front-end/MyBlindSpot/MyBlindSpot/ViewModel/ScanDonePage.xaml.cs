using MyBlindSpot.ViewModel;
using Microsoft.Maui.Controls;
using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
    StorageInformation storageInformation;
    public ScanDonePage(Image img, string e)
    {
        InitializeComponent();

        if (img != null)
        {
            picture = img;
        }
        
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