using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ItemAdded : ContentPage
{
    StorageInformation storageInformation;
    UserInformation info;
	public ItemAdded(StorageInformation si, UserInformation user)
	{
		InitializeComponent();
        storageInformation = si;
        info = user;

        //Testing
        string outputString = $"Object:{storageInformation.StoredObject} ,Location in Storage X:{storageInformation.Location.Item1} Y:{storageInformation.Location.Item2},Location in Unit:";

        foreach(var x in storageInformation.Space)
        {
            outputString += x + " ";
        }
        outputString += $", Back / Front { storageInformation.FrontBackAlignment}";

        // adding user data test

        outputString += $",Id: {info.Id}, username: {info.UserName}";
        output.Text = outputString;

       
    }
    private void BackToYourStroages_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage(info));
    }
}