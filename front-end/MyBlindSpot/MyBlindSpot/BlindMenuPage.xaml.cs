using MyBlindSpot.Classes;
using System.Globalization;

namespace MyBlindSpot;

public partial class BlindMenuPage : ContentPage
{
    private ISpeechToText speechToText;
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    public Command ListenCommand { get; set; }
    public Command ListenCancelCommand { get; set; }
    public string RecognitionText { get; set; }

    UserInformation info;

    public BlindMenuPage(ISpeechToText speechToText, UserInformation user)
    {
        InitializeComponent();
        //BindingContext = vm;

        info = user;

        this.speechToText = speechToText;

        this.ListenCommand = new Command(Listen);
        this.ListenCancelCommand = new Command(ListenCancel);
        this.BindingContext = this;

    }

    private void ListenCancel()
    {
        cancellationTokenSource?.Cancel();
    }

    private async void Listen()
    {
        var isAuthorized = await speechToText.RequestPermission();
        if (isAuthorized)
        {
            try
            {
                RecognitionText = await speechToText.Listen(CultureInfo.GetCultureInfo("de-DE"),
                    new Progress<string>(partialText =>
                    {
                        if (DeviceInfo.Platform == DevicePlatform.Android)
                        {
                            RecognitionText = partialText;
                        }
                        else
                        {
                            RecognitionText += partialText + " ";
                        }

                        OnPropertyChanged(nameof(RecognitionText));
                    }), cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        else
        {
            await DisplayAlert("Permission Error", "No microphone access", "OK");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage(info));
    }

    void GoBack_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushAsync(new MainPage(info));
    }

    // TEMP NAVIGATION!
    void OpenStorage_Clicked(System.Object sender, System.EventArgs e)
    {
        //Navigation.PushAsync(new StoragePage(null));
    }
}