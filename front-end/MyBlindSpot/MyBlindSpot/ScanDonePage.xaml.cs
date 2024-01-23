using MyBlindSpot.ViewModel;
using Microsoft.Maui.Controls;
using MyBlindSpot.Classes;
using CommunityToolkit.Maui.Converters;

namespace MyBlindSpot;

public partial class ScanDonePage : ContentPage
{
    StorageInformation storageInformation;
    UserInformation info;
    public ScanDonePage(byte[] bytes, string e, UserInformation user)
    {
        InitializeComponent();

        ByteArrayToImageSourceConverter converter = new ByteArrayToImageSourceConverter();

        //https://docs.telerik.com/devtools/maui/controls/imageeditor/loading-image

        picture.Source = converter.ConvertFrom(bytes);

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