
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class APICalls
    {
        static HttpClient client = new HttpClient();
        static string apiUrl = "http://localhost:3000/";
        static string contentType = "application/json";

        public static List<StorageField> LoadStorages(UserInformation info)
        {
            //Funktion soll alle exsistierenden Storages eines Users über http pullen > diese in Storage objekte verwandeln und dann als gebündelte Liste returnen
            return new List<StorageField>();
        }

        public static StorageField LoadSpecificStorage(int id)
        {
            //diese Funktion soll einen Spezifischen Storage über http pullen und diesen als Storage object returnen
            return new StorageField("", 5, 5);
        }

        public static List<Items> LoadeItems(int id, UserInformation info )
        {
            return new List<Items>();
        }

        public static void SaveStorage(int id, StorageField storageInformation)
        {

        }

        public static  Task<HttpResponseMessage> RegisterAccount(RegisterInformation info)
        {
            string jsonString = JsonSerializer.Serialize(info);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, contentType);
            var response = client.PostAsync($"{apiUrl}users/register", content);
            return response;
        }
    }
}
