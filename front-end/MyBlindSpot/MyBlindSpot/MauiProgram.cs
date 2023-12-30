using Camera.MAUI;
using Microsoft.Extensions.Logging;
using MyBlindSpot.ViewModel;
using ZXing.Net.Maui.Controls;

namespace MyBlindSpot
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewmodel>();

            builder.Services.AddTransient<StoragePage>();
            builder.Services.AddTransient<StorageViewmodel>();

            builder.Services.AddTransient<AddItemPage>();
            builder.Services.AddTransient<AddItemVM>();

            builder.Services.AddTransient<BlindMenuPage>();
            builder.Services.AddTransient<BlindMenuViewModel>();

            builder.Services.AddTransient<CreateStoragePage>();
            builder.Services.AddTransient<CreateStorageVM>();

            builder.Services.AddTransient<EditStoragePage>();
            builder.Services.AddTransient<EditStorageVM>();

            builder.Services.AddTransient<ScanDonePage>();
            builder.Services.AddTransient<ScanDoneVM>();

            builder.Services.AddTransient<ScanProductsPage>();
            builder.Services.AddTransient<ScanProductsVM>();

            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<StartViewmodel>();

            return builder.Build();
        }

    }
}