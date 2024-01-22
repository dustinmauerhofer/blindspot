using Camera.MAUI;
using MyBlindSpot.Classes;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MyBlindSpot;

public partial class TempCamera : ContentPage
{
    UserInformation info;
    public TempCamera(UserInformation user)
    {
        InitializeComponent();

        var barcodeReaderOptions = new BarcodeReaderOptions()
        {
            AutoRotate = true,
        };

        info = user;
    }

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage(info));
    }

    private void Skip_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanDonePage(null,"",info));
    }

    // camera methods 

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        //Outout Method for Scanner
        Dispatcher.Dispatch(() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} " +
            $"{e.Results[0].Format}";

        });
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            var result = await cameraView.StartCameraAsync();


        });
    }

    private async void TakePhoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            ImageSource picture = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);


            Image image = new Image
            {
                Source = picture,
            };

            string output = await PictureRecognition.ScanPicture(picture);

            scannedImage = image;
            text.Text = output;

            Navigation.PushAsync(new ScanDonePage(image, output,info));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
