using MyBlindSpot.Classes;
using ZXing.Net.Maui;
using Camera.MAUI;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlindSpot;

public partial class ScannerPage : ContentPage
{
	UserInformation info;
    private readonly HttpClient httpClient;

    public ScannerPage(UserInformation user)
	{
		InitializeComponent();
        var barcodeReaderOptions = new BarcodeReaderOptions()
        {
            AutoRotate = true,
        };
        info = user;
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "574fbb5e05msh80b0162c1a38993p1cd39cjsna7ee32839e9a");
        httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "ean-lookup.p.rapidapi.com");
    }

    private async Task<string> LookupBarcodeAsync(string barcode)
    {
        var url = $"https://ean-lookup.p.rapidapi.com/api?op=barcode-lookup&ean={barcode}&format=json";

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Failed with status code {response.StatusCode}";
            }
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new StoragePage(info));
    }

    private async void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        string barcode = e.Results[0].Value;
        //string format = e.Results[0].Format;

        string result = await LookupBarcodeAsync(barcode);

        Navigation.PushAsync(new ScanDonePage(null, result,info));
    }
}