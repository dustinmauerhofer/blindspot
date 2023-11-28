using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace BlindSpot
{
    public class PictureRecognition
    {
        public static async Task<string> ScanPicture(ImageSource picture)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Set the URL of your Flask web service
                    string apiUrl = "http://127.0.0.1:5000/predict";

                    // Convert the ImageSource to a byte array
                    byte[] imageBytes = await GetImageBytesFromImageSource(picture);

                    // Create a ByteArrayContent to send the image as a POST request
                    ByteArrayContent content = new ByteArrayContent(imageBytes);

                    // Create a multipart form data content
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    form.Add(content, "image", "image.jpg");

                    // Send a POST request to the Flask web service
                    HttpResponseMessage response = await client.PostAsync(apiUrl, form);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read and print the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return "Predicted Label: " + responseContent;
                    }
                    else
                    {
                        return "Error: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    return "An error occurred: " + ex.Message;
                }
            }
        }

        private static async Task<byte[]> GetImageBytesFromImageSource(ImageSource imageSource)
        {
            try
            {
                if (imageSource is FileImageSource fileImageSource)
                {
                    // For a FileImageSource, load the image from a file
                    string filePath = fileImageSource.File;
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    return imageBytes;
                }
                else if (imageSource is StreamImageSource streamImageSource)
                {
                    // For a StreamImageSource, load the image from a stream
                    using (Stream stream = await streamImageSource.Stream(CancellationToken.None))
                    {
                        if (stream != null)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                await stream.CopyToAsync(memoryStream);
                                return memoryStream.ToArray();
                            }
                        }
                    }
                }

                return null; // Handle other types of ImageSource as needed
            }
            catch (Exception)
            {
                return null; // Handle any exceptions here
            }
        }

    }
}
