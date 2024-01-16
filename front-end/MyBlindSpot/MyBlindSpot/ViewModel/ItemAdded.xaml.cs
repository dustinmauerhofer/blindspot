using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ItemAdded : ContentPage
{
    StorageInformation storageInformation;
	public ItemAdded(StorageInformation si)
	{
		InitializeComponent();
        storageInformation = si;

        //Testing
        string outputString = $"Object:{storageInformation.StoredObject} ,Location in Storage X:{storageInformation.Location.Item1} Y:{storageInformation.Location.Item2},Location in Unit:";

        foreach(var x in storageInformation.Space)
        {
            outputString += x + " ";
        }
        outputString += $", Back / Front { storageInformation.FrontBackAlignment}";

        output.Text = outputString;
    }
    private void BackToYourStroages_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }
}