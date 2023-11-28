using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace BlindSpot
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //barcodeReader.Options = new BarcodeReaderOptions()
            //{
            //  AutoRotate = true,
            //};

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
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

        private void TakePhoto_Clicked(object sender, EventArgs e)
        {
            ImageSource picture = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);   
            Task<string> output = PictureRecognition.ScanPicture(picture);
            outputLabel.Text = output.Result;

        }
    }
}