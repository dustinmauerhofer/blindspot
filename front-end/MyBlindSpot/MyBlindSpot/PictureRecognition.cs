
using System.Globalization;

public class PictureRecognition
{
    public static async Task<string> ScanPicture(ImageSource image)
    {
        // Convert ImageSource to byte array
        byte[] bytes = ConvertBackTo(image);

        var client = new HttpClient();
        client.BaseAddress = new Uri("https://foodprediction-f7xxgmeula-lm.a.run.app/");
        var content = new ByteArrayContent(bytes);
        content.Headers.Add("Content-Type", "application/octet-stream");
        var response = client.PostAsync("predict", content).Result;

        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
        else
        {
            return $"Error: {response.StatusCode}";
        }
    }

    public static byte[]? ConvertBackTo(ImageSource? value, CultureInfo? culture = null)
    {
        if (value is null)
        {
            return null;
        }

        if (value is not StreamImageSource streamImageSource)
        {
            throw new ArgumentException("Expected value to be of type StreamImageSource.", nameof(value));
        }

        var streamFromImageSource = streamImageSource.Stream(CancellationToken.None).GetAwaiter().GetResult();

        if (streamFromImageSource is null)
        {
            return null;
        }

        using var memoryStream = new MemoryStream();
        streamFromImageSource.CopyTo(memoryStream);

        return memoryStream.ToArray();
    }
}
