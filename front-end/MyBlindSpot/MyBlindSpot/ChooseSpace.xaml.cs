using MyBlindSpot.Classes;
using System.Xml.XPath;

namespace MyBlindSpot;

public partial class ChooseSpace : ContentPage
{
    StorageInformation storageInformation;
    StorageField storageField;
    List<int> space = new List<int>();
    public ChooseSpace(StorageInformation si,StorageField sf)
    {
        InitializeComponent();
        storageInformation = si;
        storageField = sf;
    }

    private async void ContinueToFrontBack_Clicked(object sender, EventArgs e)
    {
        storageInformation.Space = space;
        Navigation.PushAsync(new ChooseFrontBack(storageInformation,storageField));
    }

    private void Camera_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }

    private void Storage_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ChoosePlace(storageInformation,storageField));
    }

    private void Tapped_Left(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame && tappedFrame.Content is Border border)
        {

            if (border.BackgroundColor == Colors.Gray)
            {
                border.BackgroundColor = Color.FromHex("#42BBFF");
                space.Remove(-1);
                return;
            }
            border.BackgroundColor = Colors.Gray;
            space.Add(-1);

        }
    }

    private void Tapped_Mid(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame && tappedFrame.Content is Border border)
        {

            if (border.BackgroundColor == Colors.Gray)
            {
                border.BackgroundColor = Color.FromHex("#42BBFF");
                space.Remove(0);
                return;
            }
            border.BackgroundColor = Colors.Gray;
            space.Add(0);

        }
    }

    private void Tapped_Right(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame && tappedFrame.Content is Border border)
        {

            if (border.BackgroundColor == Colors.Gray)
            {
                border.BackgroundColor = Color.FromHex("#42BBFF");
                space.Remove(1);
                return;
            }
            border.BackgroundColor = Colors.Gray;
            space.Add(1);

        }
    }
}