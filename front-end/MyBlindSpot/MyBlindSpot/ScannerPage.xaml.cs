using MyBlindSpot.Classes;
using ZXing.Net.Maui;
using Camera.MAUI;

namespace MyBlindSpot;

public partial class ScannerPage : ContentPage
{
	UserInformation info;
	public ScannerPage(UserInformation user)
	{
		InitializeComponent();
        var barcodeReaderOptions = new BarcodeReaderOptions()
        {
            AutoRotate = true,
        };
        info = user;
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new StoragePage(info));
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        //Outout Method for Scanner
        Dispatcher.Dispatch(() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} " +
            $"{e.Results[0].Format}";

        });
    }
}